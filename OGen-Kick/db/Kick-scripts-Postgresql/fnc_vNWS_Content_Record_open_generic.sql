CREATE OR REPLACE FUNCTION "fnc_vNWS_Content_Record_open_generic"(
	"IFApplication_search_" integer, 
	"IFUser__Publisher_search_" bigint, 
	"IFUser__Aproved_search_" bigint, 
	"Begin_date_search_" timestamp with time zone, 
	"End_date_search_" timestamp with time zone, 
	"IDTag_search_" character varying, 
	"IDAuthor_search_" character varying, 
	"IDSource_search_" character varying, 
	"IDHighlight_search_" character varying, 
	"IDProfile_search_" character varying, 
	"Keywords_search_" character varying, 
	"IDLanguage_search_" integer, 
	"isAND_notOR_search_" boolean
)
	RETURNS SETOF "v0_vNWS_Content__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Content__onlyKeys";
	BEGIN
		FOR _Output IN

			SELECT
				"IDContent", 
				"IDLanguage_search_" as "IDLanguage"
			FROM "fnc_NWS_Content_Record_open_generic"(
				"IFApplication_search_", 
				"IFUser__Publisher_search_", 
				"IFUser__Aproved_search_", 
				"Begin_date_search_", 
				"End_date_search_", 
				"IDTag_search_", 
				"IDAuthor_search_", 
				"IDSource_search_", 
				"IDHighlight_search_", 
				"IDProfile_search_", 
				"Keywords_search_", 
				"IDLanguage_search_", 
				"isAND_notOR_search_"
			)

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100
	ROWS 1000;

select * 
from "fnc_vNWS_Content_Record_open_generic"(
	cast(1 as integer), -- "IFApplication_search_"
	cast(1 as bigint), --"IFUser__Publisher_search_"
	cast(1 as bigint), --"IFUser__Aproved_search_"
	now(), --"Begin_date_search_"
	now(), --"End_date_search_"
	'1', --"IDTag_search_"
	'1', --"IDAuthor_search_"
	'1', --"IDSource_search_"
	'1', --"IDHighlight_search_"
	'1', --"IDProfile_search_"
	'a', --"Keywords_search_"
	1, --"IDLanguage_search_"
	true --"isAND_notOR_search_"
)