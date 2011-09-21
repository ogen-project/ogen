CREATE OR REPLACE FUNCTION "fnc_vFOR_Message_Record_open_Forum"(
	"IDApplication_search_" integer
)
	RETURNS SETOF "v0_vFOR_Message__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vFOR_Message__onlyKeys";
	BEGIN
		FOR _Output IN

			SELECT
				"IDMessage"
			FROM "vFOR_Message"
			WHERE
				(
					("IDApplication_search_" is null)
					or
					("IDApplication_search_" = "IFApplication")
				)
				and
				("vFOR_Message"."IDMessage__parent" is null)

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
from "fnc_vFOR_Message_Record_open_Forum"(
	1
)