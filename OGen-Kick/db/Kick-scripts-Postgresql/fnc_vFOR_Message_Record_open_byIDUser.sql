--drop function "fnc_vFOR_Message_Record_open_byIDUser"(
--	"IFTag__parent_search_" bigint
--)

CREATE OR REPLACE FUNCTION "fnc_vFOR_Message_Record_open_byIDUser"(
	"IDUser_search_" bigint
)
	RETURNS SETOF "v0_FOR_Message__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_FOR_Message__onlyKeys";
	BEGIN
		FOR _Output IN

			select
				"IDMessage"
			from "FOR_Message"
			where
				("IFUser__Publisher" = "IDUser_search_")

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
from "fnc_vFOR_Message_Record_open_byIDUser"(
	1
)