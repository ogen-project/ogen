CREATE OR REPLACE FUNCTION "fnc_NWS_Source__fullname"(
	"idSource_in" bigint
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
					when "NWS_Source"."IFSource__parent" is null then '' 
					else 
						"fnc_NWS_Source__fullname"(
							"NWS_Source"."IFSource__parent"
						) 
						|| 
						' / '
				end
			) 
			|| 
			"NWS_Source"."Name"
		into 
			_output 
		from "NWS_Source"
		where "NWS_Source"."IDSource" = "idSource_in";

		return _output;
	end;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100;


select 
	"fnc_NWS_Source__fullname"(
		"IDSource"
	), *
from "NWS_Source"