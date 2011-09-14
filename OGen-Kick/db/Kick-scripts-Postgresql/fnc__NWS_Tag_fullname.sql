CREATE OR REPLACE FUNCTION "fnc_NWS_Tag__fullname"(
	"idTag_in" bigint, 
	"idLanguage_in" bigint
) 
returns character varying(8000) as
$BODY$
	declare _output character varying(8000) = '';
	
	begin
		select 
			_output 
			+ case 
				when "NWS_Tag"."IFTag__parent" is null then '' 
				else "fnc_NWS_Tag__fullname"(
					"NWS_Tag"."IFTag__parent", 
					"idLanguage_in"
				) + ' / '
			end
			+ case 
				when not "DIC_TextLanguage"."CharVar8000" is null 
					then "DIC_TextLanguage"."CharVar8000"
				when not "DIC_TextLanguage"."Text" is null 
					then 'ERROR!'
				else ''
			end
		into 
			_output 
		from "NWS_Tag"
		inner join "DIC_TextLanguage" on (
			("DIC_TextLanguage"."IFLanguage" = "idLanguage_in")
			and
			("DIC_TextLanguage"."IFText" = "NWS_Tag"."TX_Name")
		)
		where "NWS_Tag"."IDTag" = "idTag_in";

		return _output;
	end;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100;


select 
	"fnc_NWS_Tag__fullname"(
		"IDTag", 
		1
	), *
from "NWS_Tag";
