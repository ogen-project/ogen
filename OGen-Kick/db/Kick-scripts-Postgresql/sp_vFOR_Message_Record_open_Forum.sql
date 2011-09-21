CREATE OR REPLACE FUNCTION "sp_vFOR_Message_Record_open_Forum"(
	"IDApplication_search_" integer
)
	RETURNS SETOF "v0_vFOR_Message__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vFOR_Message__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDMessage"
			FROM "vFOR_Message" t1
			INNER JOIN "fnc_vFOR_Message_Record_open_Forum"(
				"IDApplication_search_"
			) t2 ON (
				(t2."IDMessage" = t1."IDMessage")
			)

			-- change where condition in: "fnc_vFOR_Message_Record_open_Forum"
			-- NOT HERE!

			-- change order by HERE:
			ORDER BY t1."IDMessage" desc

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE plpgsql STABLE
	COST 100
	ROWS 1000;
