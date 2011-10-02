CREATE OR REPLACE FUNCTION "fnc_vDIC_Language_Record_open_byLanguage"(
	"IDLanguage_translation_search_" integer
)
	RETURNS SETOF "v0_vDIC_Language__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vDIC_Language__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDLanguage", 
				"IDLanguage_translation"
			FROM "vDIC_Language"
			WHERE
				("IDLanguage_translation_search_" is null)
				or
				("IDLanguage_translation_search_" <= 0)
				or
				("IDLanguage_translation" = "IDLanguage_translation_search_")
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE plpgsql STABLE
	COST 100
	ROWS 1000;

select * 
from "sp0_vDIC_Language_Record_open_byLanguage_fullmode"(
	1
);