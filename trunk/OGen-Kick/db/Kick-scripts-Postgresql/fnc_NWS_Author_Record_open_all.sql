CREATE OR REPLACE FUNCTION "fnc_NWS_Author_Record_open_all"("IDApplication_search_" integer)
  RETURNS SETOF "v0_NWS_Author__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_NWS_Author__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDAuthor"
			FROM "NWS_Author"
			WHERE
				(
					("IDApplication_search_" IS NULL)
					OR
					("IDApplication_search_" <= 0)
					OR
					("IFApplication" = "IDApplication_search_")
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
ALTER FUNCTION "fnc_NWS_Author_Record_open_all"(integer) OWNER TO postgres;
