CREATE PROCEDURE `OGen_sp0__getTableFields`(
	IN `dbName_` VARCHAR (138),
	IN `tableName_` VARCHAR (138)
)
	NOT DETERMINISTIC
	SQL SECURITY DEFINER
	COMMENT ''
BEGIN

SELECT
	_columns.table_name,

	_columns.column_name,

	CASE
		WHEN ((_tables.table_type = 'VIEW') OR (_columns.is_nullable = 'No')) THEN
			CAST(0 AS unsigned)
		ELSE
			CAST(1 AS unsigned)
	END 
	AS is_nullable,

	_columns.data_type,

	_columns.character_maximum_length,

	CASE
		WHEN ((_tables.table_type != 'VIEW') AND (_columns.column_key = 'PRI')) THEN
			CAST(1 AS unsigned)
		ELSE
			CAST(0 AS unsigned)
	END 
	AS is_pk,

	CASE
		WHEN ((_tables.table_type != 'VIEW') AND (_columns.extra = 'auto_increment')) THEN
			CAST(1 AS unsigned)
		ELSE
			CAST(0 AS unsigned)
	END 
	AS is_identity,

	_key_column_usage.referenced_table_name
	AS fk_table_name,

	_key_column_usage.referenced_column_name
	AS fk_column_name,

	_columns.column_default,

	_columns.collation_name,

	_columns.numeric_precision,

	_columns.numeric_scale

FROM information_schema.columns AS _columns

	LEFT JOIN information_schema.tables AS _tables ON (


		(_tables.table_schema = _columns.table_schema)
		AND
		(_tables.table_name = _columns.table_name)
	)
	LEFT JOIN information_schema.key_column_usage AS _key_column_usage ON (
		(_key_column_usage.table_name = _columns.table_name)
		AND
		(_key_column_usage.column_name = _columns.column_name)
		AND
		(_key_column_usage.referenced_table_schema = `dbName_`)
		AND 
		(_key_column_usage.referenced_table_name is not null)
	)
WHERE
	(_columns.table_schema = `dbName_`)
	AND
	(
		('' = `tableName_`)
		OR
		(_columns.table_name = `tableName_`)
	)
ORDER BY
	_columns.table_name,
	_columns.ordinal_position;

END