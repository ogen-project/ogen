CREATE OR REPLACE FUNCTION "fnc_DIC_TextLanguage_Record_open_byLanguage_short"("IDLanguage_search_" integer)
	RETURNS SETOF "v0_DIC_TextLanguage__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_DIC_TextLanguage__onlyKeys";
	BEGIN
		FOR _Output IN

			select
				t3."IFText", 
				t3."IFLanguage"
			from "DIC_Language" as t1
			inner join "DIC_Text" as t2 on (
				t2."IDText" = t1."TX_Name"
			)
			inner join "DIC_TextLanguage" as t3 on (
				t3."IFText" = t2."IDText"
			)
			where t3."IFLanguage" = "IDLanguage_search_"

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE plpgsql STABLE
	COST 100
	ROWS 1000;
ALTER FUNCTION "fnc_DIC_TextLanguage_Record_open_byLanguage_short"(integer)
	OWNER TO postgres;
