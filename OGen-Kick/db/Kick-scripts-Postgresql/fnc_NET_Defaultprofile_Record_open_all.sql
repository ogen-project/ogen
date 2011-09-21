--drop function "fnc_NET_Defaultprofile_Record_open_all"(
--	"IFApplication_search_" integer
--)
CREATE OR REPLACE FUNCTION "fnc_NET_Defaultprofile_Record_open_all"(
	"IFApplication_search_" integer
)
	RETURNS SETOF "v0_NET_Defaultprofile__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_CRD_Permition__onlyKeys";
	BEGIN
		FOR _Output IN
			select
				d1."IDDefaultprofile"
			from "NET_Defaultprofile" as d1
			inner join "CRD_Profile" as p1 on (
				(
					("IFApplication_search_" is null)
					or
					("IFApplication_search_" <= 0)
					or
					("IFApplication_search_" = p1."IFApplication")
				)
				and
				p1."IDProfile" = d1."IFProfile"
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

select 
	*
from "fnc_NET_Defaultprofile_Record_open_all"(
	1
);