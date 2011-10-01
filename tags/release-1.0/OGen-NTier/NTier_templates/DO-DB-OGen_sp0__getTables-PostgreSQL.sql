CREATE OR REPLACE FUNCTION "OGen_sp0__getTables"(
	"dbName_" character varying,
	"subApp_" character varying
)
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
--RETURNS SETOF ANYELEMENT AS $BODY$
RETURNS SETOF "v0__getTables" AS $BODY$
	DECLARE
		_Output "v0__getTables";
--		_Output SETOF ANYELEMENT;
	BEGIN
		FOR _Output IN




			SELECT
				DISTINCT
				_table.table_name,
				CASE
					WHEN (_table.table_type = 'VIEW') THEN
						CAST(1 AS INT)
					ELSE
						CAST(0 AS INT)
				END
				AS is_view
			FROM information_schema.tables _table
			INNER JOIN "OGen_fnc0__Split"(
				string_to_array("subApp_", '|')
			) ON (
				(_table.table_name LIKE "OGen_fnc0__Split")
			)
			WHERE
				(
					(_table.table_type = 'BASE TABLE')
					OR
					(_table.table_type = 'VIEW')
				)
			
				-- <PostgreSQL>
				AND
				(
					(_table.table_type != 'VIEW')
					OR
					(
						(_table.table_type = 'VIEW')
						AND
						(_table.table_name NOT LIKE 'v0_%')
					)
				)
				-- </PostgreSQL>
			
				-- <PostgreSQL>
				AND
				(_table.table_schema NOT IN (
					'information_schema', 
					'pg_catalog'
				))
				-- </PostgreSQL>
			
				-- <SQLServer>
				AND
				(_table.table_name NOT IN (
					'sysconstraints', 
					'syssegments', 
					'dtproperties'
				))
				-- </SQLServer>
			
				AND
				(_table.table_catalog = "dbName_")
			ORDER BY _table.table_name



		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$ LANGUAGE 'plpgsql' STABLE