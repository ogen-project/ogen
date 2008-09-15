CREATE OR REPLACE FUNCTION "OGen_sp0__getTableFields"(
	"dbName_" character varying,
	"tableName_" character varying
)
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
--RETURNS SETOF ANYELEMENT AS $BODY$
RETURNS SETOF "v0__getTableFields" AS $BODY$
	DECLARE
		_Output "v0__getTableFields";
--		_Output SETOF ANYELEMENT;
	BEGIN
		FOR _Output IN




			SELECT
				_field.table_name,
				_field.column_name,

				CASE
					WHEN (_table.table_type = 'VIEW') THEN
						CAST(0 AS INT)
					WHEN _field.is_nullable = 'YES' THEN
						CAST(1 AS INT)
					ELSE
						CAST(0 AS INT)
				END
				AS is_nullable,

				_field.data_type
				AS data_type,

				_field.character_maximum_length
				AS character_maximum_length,

				CASE
					WHEN (_table.table_type = 'VIEW') THEN
						CAST(0 AS INT)
					WHEN (_field.column_name = _pk.column_name) THEN
						CAST(1 AS INT)
					ELSE
						CAST(0 AS INT)
				END
				AS is_pk,

				CASE
					WHEN (_table.table_type = 'VIEW') THEN
						CAST(0 AS INT)
					ELSE
						CASE
							WHEN (_field.column_default LIKE 'nextval(''%') THEN
								CAST(1 AS INT)
							ELSE
								CAST(0 AS INT)
						END
				END
				AS is_identity,

				_fk.fk_table_name AS fk_table_name,

				_fk.fk_column_name AS fk_column_name,

				_field.column_default,

				_field.collation_name,

				_field.numeric_precision,

				_field.numeric_scale

			FROM information_schema.columns AS _field

				LEFT JOIN information_schema.tables _table ON (
					(_table.table_catalog = _field.table_catalog)
					AND
					(_table.table_schema = _field.table_schema)
					AND
					(_table.table_name = _field.table_name)
				)

				LEFT JOIN (
					SELECT
						_kcu.table_name,
						_kcu.column_name,
						_kcu.table_catalog,
						_kcu.table_schema
					FROM information_schema.table_constraints _tc
					INNER JOIN information_schema.key_column_usage _kcu ON
						(_kcu.constraint_catalog = _tc.constraint_catalog)
						AND
						(_kcu.constraint_schema = _tc.constraint_schema)
						AND
						(_kcu.constraint_name = _tc.constraint_name)
						AND
						(_tc.constraint_type = 'PRIMARY KEY')
				) _pk ON
					(_pk.table_catalog = _field.table_catalog)
					AND
					(_pk.table_schema = _field.table_schema)
					AND
					(_pk.table_name = _field.table_name)
					AND
					(_pk.column_name = _field.column_name)

				LEFT JOIN (
					SELECT
						_pk.table_name AS fk_table_name,
						_pk.column_name AS fk_column_name,

						_fks.table_name,
						_fks.column_name,
						_fks.table_catalog,
						_fks.table_schema
					FROM information_schema.referential_constraints _rc
					INNER JOIN information_schema.key_column_usage _fks ON
						(_fks.constraint_catalog = _rc.constraint_catalog)
						AND
						(_fks.constraint_schema = _rc.constraint_schema)
						AND
						(_fks.constraint_name = _rc.constraint_name)
					INNER JOIN information_schema.key_column_usage _pk ON
						(_pk.constraint_catalog = _rc.constraint_catalog)
						AND
						(_pk.constraint_schema = _rc.constraint_schema)
						AND
						(_pk.constraint_name = _rc.unique_constraint_name)
				) _fk ON
					(_fk.table_catalog = _field.table_catalog)
					AND
					(_fk.table_schema = _field.table_schema)
					AND
					(_fk.table_name = _field.table_name)
					AND
					(_fk.column_name = _field.column_name)

			WHERE
				(_field.table_schema = 'public')
				AND
				(_field.table_name NOT LIKE 'v0%')
				AND
				(_field.table_catalog = "dbName_")
				AND
				(
					('' = "tableName_")
					OR
					(_field.table_name = "tableName_")
				)
			ORDER BY
				_field.table_name,
			--	_field.column_name,
				_field.ordinal_position




		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$BODY$ LANGUAGE 'plpgsql' STABLE