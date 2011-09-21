--DROP FUNCTION "fnc_vNWS_Author_Record_open_Approved"(
--	"IDApplication_search_" integer
--)

CREATE OR REPLACE FUNCTION "fnc_vNWS_Author_Record_open_Approved"(
	"IDApplication_search_" integer
)
	RETURNS SETOF "v0_vNWS_Author__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Author__onlyKeys";
	BEGIN
		FOR _Output IN

			SELECT
				"IDAuthor"
			FROM "fnc_NWS_Author_Record_open_Approved"(
				"IDApplication_search_"
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

select *
from "fnc_vNWS_Author_Record_open_Approved"(
	null
)