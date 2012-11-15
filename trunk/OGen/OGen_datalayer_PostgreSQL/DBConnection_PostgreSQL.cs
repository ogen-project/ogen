#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DataLayer.PostgreSQL {
	using System;
	using System.Data;
	using System.Text;
	using Npgsql;

	/// <summary>
	///	Provides access to PostgreSQL Databases, allowing the execution of SQL Queries and Functions retrieving their existing data if any. It also supports Transactions.
	/// </summary>
	public sealed class DBConnection_PostgreSQL : DBConnection {
		//#region public DBConnection_PostgreSQL(...);

		/// <summary>
		/// Initializes a new instance of <see cref="DBConnection_PostgreSQL">DBConnection_PostgreSQL</see>
		/// </summary>
		/// <param name="connectionString_in">Connection String</param>
		public DBConnection_PostgreSQL(
			string connectionString_in
		) : base (
//			DBServerTypes.PostgreSQL, 
			connectionString_in,
			string.Empty
		) {
		}

		/// <summary>
		/// Initializes a new instance of <see cref="DBConnection_PostgreSQL">DBConnection_PostgreSQL</see>
		/// </summary>
		/// <param name="connectionString_in">Connection String</param>
		/// <param name="logFile_in">Log File (null or empty string disables log)</param>
		public DBConnection_PostgreSQL(
			string connectionString_in,
			string logFile_in
		) : base (
//			DBServerTypes.PostgreSQL, 
			connectionString_in,
			logFile_in
		) {
		}

		/// <summary>
		/// Releases all resources used by <see cref="DBConnection_PostgreSQL">DBConnection_PostgreSQL</see>.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing) {
			base.Dispose(disposing);
		}
		//#endregion

		//#region public static properties...
		#region public static DBUtilities Utils { get; }
		private static DBUtilities utils__ = null;
		private static object utils__locker = new object();

		public static DBUtilities Utils {
			get {

				// check before lock
				if (utils__ == null) {

					lock (utils__locker) {

						// double check, thread safer!
						if (utils__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							utils__ = new DBUtilities_PostgreSQL();
						}
					}
				}

				return utils__;
			}
		}
		#endregion
		//#endregion
		//#region public properties...
		#region public abstract string DBServerType { get; }
		public const string DBSERVERTYPE = "PostgreSQL";

		public override string DBServerType {
			get {
				return DBSERVERTYPE;
			}
		}
		#endregion
		#region public override DBUtilities Utilities { get; }
		public override DBUtilities Utilities {
			get {
				return DBConnection_PostgreSQL.Utils;
			}
		}
		#endregion
		#region public override IDbConnection exposeConnection { get; }
		public object exposeConnection_locker = new object();

		public override IDbConnection exposeConnection {
			get {

				// check before lock
				if (this.connection__ == null) {

					lock (this.exposeConnection_locker) {

						// double check, thread safer!
						if (this.connection__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.connection__ = new NpgsqlConnection(this.Connectionstring);
						}
					}
				}

				return this.connection__;
			}
		}
		#endregion
		//#endregion

		//#region private Methods...
		#region protected override IDbCommand newDBCommand(string command_in, IDbConnection connection_in);
		protected override IDbCommand newDBCommand(string command_in, IDbConnection connection_in) {
			IDbCommand _output;

			if ((this.transaction__ != null) && (this.transaction__.InTransaction)) {
				_output = new NpgsqlCommand(
					command_in, 
					(NpgsqlConnection)connection_in,
					(NpgsqlTransaction)this.Transaction.exposeTransaction
				);
			} else {
				_output = new NpgsqlCommand(
					command_in, 
					(NpgsqlConnection)connection_in
				);
			}

			_output.CommandTimeout = connection_in.ConnectionTimeout;

			return _output;
		}
		#endregion
		#region protected override IDbDataAdapter newDBDataAdapter(string query_in, IDbConnection connection_in, bool isQuery_notProcedure_in);
		protected override IDbDataAdapter newDBDataAdapter(string query_in, IDbConnection connection_in, bool isQuery_notProcedure_in) {
			IDbDataAdapter _output = new NpgsqlDataAdapter(
				(isQuery_notProcedure_in) ? query_in : "\"" + query_in + "\"",
				(NpgsqlConnection)connection_in
			);

			if ((this.transaction__ != null) && (this.transaction__.InTransaction)) {
				_output.SelectCommand.Transaction
					= (NpgsqlTransaction)this.transaction__.exposeTransaction;
			}

			return _output;
		}
		#endregion
		//#endregion
		//#region public Methods...
		#region public override IDbDataParameter newDBDataParameter(...);
		public override IDbDataParameter newDBDataParameter(
			string name_in, 
			DbType dbType_in, 
			ParameterDirection parameterDirection_in, 
			object value_in, 
			int size_in, 
			byte precision_in, 
			byte scale_in
		) {
			IDbDataParameter _newdbdataparameter_out;

			_newdbdataparameter_out = new NpgsqlParameter();
			_newdbdataparameter_out.ParameterName = ":\"" + name_in + "\"";

			// fmonteiro: by default npgsql assumes any datetime 
			// to be time zoned
			if (dbType_in == DbType.DateTime) {
				_newdbdataparameter_out.DbType = dbType_in;
				// EXPLICITLY assuming datetime without time zone
				((NpgsqlParameter)_newdbdataparameter_out).NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Timestamp;
			} else {
				_newdbdataparameter_out.DbType = dbType_in;
			}

			_newdbdataparameter_out.Direction = parameterDirection_in;
			if ((value_in == null) || (value_in == DBNull.Value)) {
				_newdbdataparameter_out.Value = DBNull.Value;
			} else {
				_newdbdataparameter_out.Value = value_in;
			}
			if (size_in != 0) {
				_newdbdataparameter_out.Size = size_in;
			}
			if (precision_in != 0) {
				_newdbdataparameter_out.Precision = precision_in;
			}
			if (scale_in != 0) {
				_newdbdataparameter_out.Scale = scale_in;
			}

			return _newdbdataparameter_out;
		}
		#endregion
		//#endregion




//		#region protected override object Execute_SQLFunction(...);
		protected override object Execute_SQLFunction(
			string function_in, 
			IDbDataParameter[] dataParameters_in, 
			IDbCommand command_in, 
			DbType returnValue_DbType_in, 
			int returnValue_Size_in
		) {
			if (this.Logenabled) {
				this.Log("sql function", function_in, dataParameters_in);
			}

			object _output = null;
			#region command_.Parameters = dataParameters_in;
			for (int i = 0; i < dataParameters_in.Length; i++) {
				command_in.Parameters.Add(dataParameters_in[i]);
			}
			#endregion

			command_in.CommandText = string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"\"{0}\"", 
				function_in
			);

			command_in.CommandType = CommandType.StoredProcedure;
			try {
				if (returnValue_Size_in >= 0) {
					_output =
						command_in.ExecuteScalar();
				} else {
					command_in.ExecuteNonQuery();
					//Execute_SQLFunction_out = null;
				}
			} catch (Exception _ex) {
				throw new Exception(
					string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"Stored Procedure: {0}({5})\nConnectionString: {1}|{2}\nexception: {3}\ninner-exception: {4}\n",
						function_in,
						this.DBServerType, 
#if DEBUG
						connectionstring_, 
#else
						"- not available -", 
#endif
						_ex.Message, 
						_ex.InnerException,

						DBUtilities.IDbDataParameter2String(dataParameters_in)
					),
					_ex
				);
			}

			return _output;
		}
//		#endregion




		//---
		#region public override string sqlfunction_exists(...);
		public override string SQLFunction_exists_query(string name_in) {
			return string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				#region "SELECT ...", 
@"
SELECT null
FROM INFORMATION_SCHEMA.ROUTINES
WHERE
	(routine_type = 'FUNCTION')
	AND
	(routine_name = '{0}')
", 
				#endregion
				name_in
			);
		}
		#endregion
		#region public override string SQLFunction_delete_query(...);
		public override string SQLFunction_delete_query(string name_in) {
			// ToDos: later! not implemented
			// NOTES: It's not as easy as it is for SQLServer and MySQL. PostgreSQL 
			// allows you to create diferent signatures for the same function, so in 
			// order to drop a function we need to know the parameters for such 
			// function.
			// To overcome such probleme, remember that in PostgreSQL you can use:
			// CREATE OR REPLACE FUNCTION "some_function"

			throw new Exception("- not implemented!");
		}
		#endregion
		#region public override string SQLStoredProcedure_exists_query(...);
		public override string SQLStoredProcedure_exists_query(string name_in) {
			return string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				#region "SELECT ...",
@"
SELECT null
FROM INFORMATION_SCHEMA.ROUTINES
WHERE
	(routine_type = 'PROCEDURE')
	AND
	(routine_name = '{0}')
",
				name_in
				#endregion
			);
		}
		#endregion
		#region public override string SQLStoredProcedure_delete_query(...);
		public override string SQLStoredProcedure_delete_query(string name_in) {
			// ToDos: later! not implemented
			// NOTES: It's not as easy as it is for SQLServer and MySQL. PostgreSQL 
			// allows you to create diferent signatures for the same procedure, so in 
			// order to drop a procedure we need to know the parameters for such 
			// procedure.
			// To overcome such probleme, remember that in PostgreSQL you can use:
			// CREATE OR REPLACE PROCEDURE "some_procedure"
			// PostgreSQL supports Stored Procedures.

			throw new Exception("- not implemented!");
		}
		#endregion
		#region public override string SQLView_exists_query(...);
		public override string SQLView_exists_query(string name_in) {
			return string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				#region "SELECT ...",
@"
SELECT null
FROM INFORMATION_SCHEMA.TABLES
WHERE
	(TABLE_TYPE = 'VIEW')
	AND
	(TABLE_NAME = '{0}')
",
				name_in
				#endregion
			);
		}
		#endregion
		#region public override string SQLView_delete_query(...);
		public override string SQLView_delete_query(string name_in) {
			// ToDos: later! not implemented, needed if droping, 
			// no need when replacing, you can use:
			// CREATE OR REPLACE VIEW "some_view"

			throw new Exception("- not implemented!");
		}
		#endregion
		//---
		#region public override string SchemaDatabases_query(...);
		public override string SchemaDatabases_query() {
			return
@"
SELECT CATALOG_NAME 
FROM INFORMATION_SCHEMA.SCHEMATA 
WHERE
	(CATALOG_NAME != 'postgres') 
GROUP BY CATALOG_NAME 
ORDER BY CATALOG_NAME
"
			;
		}
		#endregion
		#region public override string SchemaDatabaseTables_query(...);
		public override string SchemaDatabaseTables_query(
			string dbName_in, 
			string subAppName_in
		) {
			StringBuilder _query = new StringBuilder(string.Empty);
			#region _query.Append(@"SELECT ...");
			_query.Append(string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
@"
SELECT
	_table.table_name,
	CASE
		WHEN (_table.table_type = 'VIEW') THEN
			CAST(1 AS INT)
		ELSE
			CAST(0 AS INT)
	END
	AS is_view, 
	obj_description(
		(
			select
				c.oid
			from pg_catalog.pg_class c 
			where
				(c.relname = _table.table_name)

		), 
		'pg_class'
	) AS table_description 
FROM information_schema.tables _table
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
	(_table.table_catalog = '{0}')
",
				dbName_in
			));
			#endregion
			if (!string.IsNullOrEmpty(subAppName_in)) {
				_query.Append("AND (");
				string[] _subAppNames = subAppName_in.Split('|');
				for (int i = 0; i < _subAppNames.Length; i++) {
					_query.Append(string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"(_table.table_name {0} '{1}'){2}",
						(_subAppNames[i].IndexOf('%') >= 0) ? "LIKE" : "=", 
						_subAppNames[i],
						(i == _subAppNames.Length - 1) ? "" : " OR "
					));
				}
				_query.Append(") ");
			}
			_query.Append("ORDER BY _table.table_name");

			return _query.ToString();
		}
		#endregion
		#region public override string SchemaDatabaseTableFields_query(...);
		public override string SchemaDatabaseTableFields_query(
			string tableName_in
		) {
			#region return "SELECT ...";
			return string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
@"
SELECT
	_field.table_name,
	_field.column_name,

	CASE
--		WHEN (_table.table_type = 'VIEW') THEN
--			CAST(0 AS INT)
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

	_field.numeric_scale, 

	col_description(
		(
			select
				c.oid
			from pg_catalog.pg_class c 
			where
				(c.relname = _field.table_name)

		), 
		_field.ordinal_position
	) 
	AS column_description

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
	(_field.table_catalog = '{0}')
	AND
	(
		('' = '{1}')
		OR
		(_field.table_name = '{1}')
	)
ORDER BY
	_field.table_name,
--	_field.column_name,
	_field.ordinal_position
",
				this.Connectionstring_DBName, 
				tableName_in
			);
			#endregion
		}
		#endregion
	}
}
