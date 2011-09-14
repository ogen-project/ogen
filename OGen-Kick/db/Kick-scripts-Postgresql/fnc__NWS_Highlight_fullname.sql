CREATE OR REPLACE FUNCTION "fnc_NWS_Highlight__fullname"(
	"idHighlight_in" bigint
) 
returns character varying(8000) as
$BODY$
	declare _output character varying(8000) = '';
	begin
		select 
			_output 
			|| 
			(
				case 
					when "NWS_Highlight"."IFHighlight__parent" is null then '' 
					else 
						"fnc_NWS_Highlight__fullname"(
							"NWS_Highlight"."IFHighlight__parent"
						) 
						|| 
						' / '
				end
			) 
			|| 
			"NWS_Highlight"."Name"
		into 
			_output 
		from "NWS_Highlight"
		where "NWS_Highlight"."IDHighlight" = "idHighlight_in";

		return _output;
	end;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100;


select 
	"fnc_NWS_Highlight__fullname"(
		"IDHighlight"
	), *
from "NWS_Highlight"