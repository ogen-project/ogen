CREATE OR REPLACE FUNCTION "fnc_vNWS_Tag_Record_open_Approved_byLang"(
	"IDApplication_search_" integer, 
	"IDLanguage_search_" integer
)
  RETURNS SETOF "v0_vNWS_Tag__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Tag__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDTag", 
				"IDLanguage"
			FROM "vNWS_Tag"
			WHERE
				(
					("IDApplication_search_" IS NULL)
					OR
					("IDApplication_search_" <= 0)
					OR
					("IFApplication" = "IDApplication_search_")
				)
				and
				(
					("IDLanguage_search_" <= 0)
					OR
					("IDLanguage_search_" = "IDLanguage")
				)
				and
				(not "IFUser__Approved" is null)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
  LANGUAGE 'plpgsql' STABLE
  COST 100
  ROWS 1000;
ALTER FUNCTION "fnc_vNWS_Tag_Record_open_Approved_byLang"(integer, integer) OWNER TO postgres;
