CREATE OR REPLACE FUNCTION "sp_LOG_Log_Record_open_generic"(
	"IDLogtype_search_" integer, 
	"IDUser_search_" bigint, 
	"IDErrortype_search_" integer, 
	"Stamp_begin_search_" timestamp with time zone, 
	"Stamp_end_search_" timestamp with time zone, 
	"Read_search_" boolean, 
	"IFApplication_search_" integer
)
	RETURNS SETOF "v0_LOG_Log__onlyKeys" AS
$BODY$
	DECLARE
		_Output "v0_LOG_Log__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDLog"
			FROM "LOG_Log" t1
			INNER JOIN "fnc_LOG_Log_Record_open_generic"(
				"IDLogtype_search_", 
				"IDUser_search_", 
				"IDErrortype_search_", 
				"Stamp_begin_search_", 
				"Stamp_end_search_", 
				"Read_search_", 
				"IFApplication_search_"
			) t2 ON (
				(t2."IDLog" = t1."IDLog")
			)

			-- change where condition in: "fnc_LOG_Log_Record_open_generic"
			-- NOT HERE!

			-- change order by HERE:
			ORDER BY t1."IDLog" desc

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$
	LANGUAGE 'plpgsql' STABLE
	COST 100
	ROWS 1000;
