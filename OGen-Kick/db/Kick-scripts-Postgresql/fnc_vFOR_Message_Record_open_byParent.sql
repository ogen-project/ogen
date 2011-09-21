--DROP FUNCTION "fnc_vFOR_Message_Record_open_byParent"(
--	"IDMessage__parent_search_" bigint
--)
CREATE OR REPLACE FUNCTION "fnc_vFOR_Message_Record_open_byParent"(
	"IDMessage__parent_search_" bigint
)
	RETURNS SETOF "v0_FOR_Message__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_FOR_Message__onlyKeys";
	BEGIN
		FOR _Output IN

			SELECT
				"IDMessage"
			FROM "FOR_Message"
			WHERE
				("IFMessage__parent" = "IDMessage__parent_search_")

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
from "fnc_vFOR_Message_Record_open_byParent"(
	1
)