CREATE OR REPLACE FUNCTION "fnc_NWS_User_Record_open_Publisher"(
	"IDApplication_search_" integer
)
	RETURNS SETOF "v0_NWS_Content__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_NWS_Content__onlyKeys";
	BEGIN
		FOR _Output IN

			select
				distinct "IFUser__Publisher" as "IFUser"
			from "NWS_Content"
			where 
				("IDApplication_search_" is null)
				or
				("IDApplication_search_" <= 0)
				OR
				("IDApplication_search_" = "NWS_Content"."IFApplication")

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
from "fnc_NWS_User_Record_open_Publisher"(
	1
)










