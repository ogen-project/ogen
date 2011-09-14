CREATE OR REPLACE FUNCTION "fnc_LOG_Log_Record_open_generic"(
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
				"IDLog"
			FROM "LOG_Log"
			WHERE
				(
					("IFApplication_search_" IS NULL)
					or
					("IFApplication_search_" <= 0)
					OR
					("IFApplication_search_" = "IFApplication")
				)
				and
				(
					("IDLogtype_search_" is null)
					or
					("IDLogtype_search_" <= 0)
					or
					("IDLogtype_search_" = "IFLogtype") 
				)
				and
				(
					("IDUser_search_" is null)
					or
					("IDUser_search_" <= 0)
					or
					("IDUser_search_" = "IFUser")
				)
				and
				(
					("IDErrortype_search_" is null)
					or
					("IDErrortype_search_" <= 0)
					or
					("IDErrortype_search_" = "IFErrortype")
				)
				and
				(
					("Stamp_begin_search_" is null)
					or
					("Stamp_end_search_" is null)
					or
					("Stamp_begin_search_" < date '2010-01-01')
					or
					("Stamp_end_search_" < date '2010-01-01')
					or
					("Stamp" between "Stamp_begin_search_" and "Stamp_end_search_")
				)
				and
				(
					("Read_search_" is null)
					or
					(
						("Read_search_" = true)
						and
						(not "IFUser__read" is null)
					)
					or
					(
						("Read_search_" = false)
						and
						("IFUser__read" is null)
					)
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
from "fnc_LOG_Log_Record_open_generic"(
	-1, -- "IDLogtype_search_" integer, 
	-1, -- "IDUser_search_" bigint, 
	-1, -- "IDErrortype_search_" integer, 

	--date '1900-01-01', 
	--date '1900-01-01', 
	--null, 
	--null, 
	--date '2010-01-01', 
	--date '2010-01-01', 
	date '2010-01-01', 
	date '2010-05-01', 

	false, -- "Read_search_" boolean

	null -- "IFApplication_search_"
);
