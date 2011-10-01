CREATE OR REPLACE FUNCTION "fnc_vNWS_Source_Record_open_all"("IDApplication_search_" integer)
  RETURNS SETOF "v0_vNWS_Source__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Source__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDSource"
			FROM "vNWS_Source"
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
ALTER FUNCTION "fnc_vNWS_Source_Record_open_all"(integer) OWNER TO postgres;
