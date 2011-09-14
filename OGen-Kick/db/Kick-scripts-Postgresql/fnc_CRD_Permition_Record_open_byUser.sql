CREATE OR REPLACE FUNCTION "fnc_CRD_Permition_Record_open_byUser"("IDUser_search_" bigint)
	RETURNS SETOF "v0_CRD_Permition__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_CRD_Permition__onlyKeys";
	BEGIN
		FOR _Output IN
			select
				distinct pp1."IFPermition" as "IDPermition"
			from "CRD_UserProfile" as up1
			left join "CRD_ProfilePermition" as pp1 on (
				pp1."IFProfile" = up1."IFProfile"
			)
			where 
				(up1."IFUser" = "IDUser_search_")
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
from "fnc_CRD_Permition_Record_open_byUser"(
	1
);