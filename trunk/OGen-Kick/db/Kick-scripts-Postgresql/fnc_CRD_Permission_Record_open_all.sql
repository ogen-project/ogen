CREATE OR REPLACE FUNCTION "fnc_CRD_Permission_Record_open_all"(
	"IFApplication_search_" integer
)
	RETURNS SETOF "v0_CRD_Permission__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_CRD_Permission__onlyKeys";
	BEGIN
		FOR _Output IN

			SELECT
				"IDPermission"
			FROM "CRD_Permission"
			WHERE
				("IFApplication_search_" IS NULL)
				OR
				("IFApplication_search_" <= 0)
				OR
				("IFApplication" = "IFApplication_search_")

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100
	ROWS 1000;
