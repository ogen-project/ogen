CREATE OR REPLACE FUNCTION "sp_vNWS_Content_Record_open_generic"(
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
				t1."IDContent", 
				t1."IDLanguage"
			FROM "vNWS_Content" t1
			INNER JOIN "fnc_vNWS_Content_Record_open_generic"(
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
			) t2 ON (
				(t2."IDContent" = t1."IDContent") AND
				(t2."IDLanguage" = t1."IDLanguage")
			)

			-- change where condition in: "fnc_vNWS_Content_Record_open_generic"
			-- NOT HERE!

			-- change order by HERE:
			ORDER BY 
				t1."IDContent" desc
				--, t1."IDLanguage"

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE plpgsql STABLE
	COST 100
	ROWS 1000;