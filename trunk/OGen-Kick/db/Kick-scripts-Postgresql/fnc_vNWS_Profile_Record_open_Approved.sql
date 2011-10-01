CREATE OR REPLACE FUNCTION "fnc_vNWS_Profile_Record_open_Approved"(
	"IDApplication_search_" integer
)
	RETURNS SETOF "v0_vNWS_Profile__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_vNWS_Profile__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDProfile"
			FROM "NWS_Profile"
			inner join "CRD_Profile" on (
				"CRD_Profile"."IDProfile" = "NWS_Profile"."IFProfile"
			)
			WHERE
				(
					("IDApplication_search_" is null)
					or
					("IDApplication_search_" <= 0)
					or
					("IDApplication_search_" = "CRD_Profile"."IFApplication")
				)
				and
				(not "NWS_Profile"."IFUser__Approved" is null)
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
from "fnc_vNWS_Profile_Record_open_Approved"(
	null--"IDApplication_search_" integer
);