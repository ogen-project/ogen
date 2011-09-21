CREATE OR REPLACE FUNCTION "fnc_NWS_Tag_Record_open_byParent"(
	"IFTag__parent_search_" bigint, 
	"IFApplication_search_" integer
)
	RETURNS SETOF "v0_NWS_Tag__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_NWS_Tag__onlyKeys";
	BEGIN
		FOR _Output IN

			select
				"IDTag"
			from "NWS_Tag"
			where
				(
					(
						("IFTag__parent_search_" IS NULL)
						AND
						("IFTag__parent" IS NULL)
					) 
					OR 
					(
						NOT ("IFTag__parent_search_" IS NULL)
						AND
						("IFTag__parent" = "IFTag__parent_search_")
					)
				) 
				AND
				(
					("IFApplication_search_" IS NULL)
					OR 
					("IFApplication_search_" <= 0)
					OR 
					("IFApplication" = "IFApplication_search_")
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
from "fnc_NWS_Tag_Record_open_byParent"(
	1, 
	1
)










