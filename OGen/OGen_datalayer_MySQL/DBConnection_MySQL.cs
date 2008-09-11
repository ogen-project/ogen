#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace OGen.lib.datalayer.MySQL {
	public sealed class DBConnection_MySQL : DBConnection {
		//#region public DBConnection_MySQL(...);
		public DBConnection_MySQL(
			string connectionstring_in
		) : base (
//			DBServerTypes.MySQL, 
			connectionstring_in,
			string.Empty
		) {
		}
		public DBConnection_MySQL(
			string connectionstring_in,
			string logfile_in
		) : base (
//			DBServerTypes.MySQL, 
			connectionstring_in,
			logfile_in
		) {
		}
		//#endregion

		//#region public static properties...
		#region public static DBUtils Utils { get; }
		private static DBUtils utils__ = null;

		public static DBUtils Utils {
			get {
				if (utils__ == null) {
					utils__ = new DBUtils_MySQL();
				}
				return utils__;
			}
		}
		#endregion
		//#endregion
		//#region public properties...
		#region public abstract string DBServerType { get; }
		public const string DBSERVERTYPE = "MySQL";

		public override string DBServerType {
			get {
				return DBSERVERTYPE;
			}
		}
		#endregion
		#region public override DBUtils utils { get; }
		public override DBUtils utils {
			get {
				return Utils;
			}
		}
		#endregion
		#region public override IDbConnection exposeConnection { get; }
		public override IDbConnection exposeConnection {
			get {
				if (connection__ == null) {
					connection__ = new MySqlConnection(Connectionstring);
				}

				return connection__;
			}
		}
		#endregion
		//#endregion

		//#region private Methods...
		#region protected override IDbCommand newDBCommand(string command_in, IDbConnection connection_in);
		protected override IDbCommand newDBCommand(string command_in, IDbConnection connection_in) {
			IDbCommand _newdbcommand_out;

			if ((transaction__ != null) && (transaction__.inTransaction)) {
				_newdbcommand_out = new MySqlCommand(
					command_in,
					(MySqlConnection)connection_in,
					(MySqlTransaction)Transaction.exposeTransaction
				);
			} else {
				_newdbcommand_out = new MySqlCommand(
					command_in,
					(MySqlConnection)connection_in
				);
			}

			_newdbcommand_out.CommandTimeout = connection_in.ConnectionTimeout;

			return _newdbcommand_out;
		}
		#endregion
		#region protected override IDbDataAdapter newDBDataAdapter(string query_in, IDbConnection connection_in, bool isQuery_notProcedure_in);
		protected override IDbDataAdapter newDBDataAdapter(string query_in, IDbConnection connection_in, bool isQuery_notProcedure_in) {
			IDbDataAdapter _newdbdataadapter_out = new MySqlDataAdapter(
				query_in,
				(MySqlConnection)connection_in
			);

			if ((transaction__ != null) && (transaction__.inTransaction)) {
				_newdbdataadapter_out.SelectCommand.Transaction 
					= (MySqlTransaction)transaction__.exposeTransaction;
			}

			return _newdbdataadapter_out;
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

			_newdbdataparameter_out = new MySqlParameter();
			_newdbdataparameter_out.ParameterName = "?" + name_in;

			_newdbdataparameter_out.DbType = dbType_in;
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
			if (Logenabled) {
				Log("sql function", function_in, dataParameters_in);
			}

			object Execute_SQLFunction_out = null;
			#region command_.Parameters = dataParameters_in;
			for (int i = 0; i < dataParameters_in.Length; i++) {
				command_in.Parameters.Add(dataParameters_in[i]);
			}
			#endregion

			command_in.CommandText = function_in;

			command_in.CommandType = CommandType.StoredProcedure;
			try {
				if (returnValue_Size_in >= 0) {
					command_in.Parameters.Add(
						newDBDataParameter(
							"SomeOutput",
							(DbType)returnValue_DbType_in,
							ParameterDirection.ReturnValue,
							null,
							returnValue_Size_in
						)
					);
					command_in.ExecuteNonQuery();
					Execute_SQLFunction_out
						= ((IDbDataParameter)command_in.Parameters[
							command_in.Parameters.Count - 1
						]).Value;
				} else {
					command_in.ExecuteNonQuery();
					//Execute_SQLFunction_out = null;
				}
			} catch (Exception e) {
				throw new Exception(
					string.Format(
						"Stored Procedure: {0}\nConnectionString: {1}\nexception: {2}\n",
						function_in,
						connectionstring_,
						e.ToString()
					)
				);
			}

			return Execute_SQLFunction_out;
		}
//		#endregion




		//---
//		#region public override string SQLFunction_exists_query(...);
		public override string SQLFunction_exists_query(string name_in) {

// ToDos: here!
throw new Exception("not implemented!");

//			string _database = Connectionstring_database();
//			return string.Format(
//				#region "SELECT ...", 
//@"
//SELECT null
//FROM INFORMATION_SCHEMA.ROUTINES
//WHERE
//	(routine_type = 'FUNCTION')
//	AND
//	(routine_name = '{0}')
//	AND
//	(routine_schema = '{1}')
//", 
//					#endregion
//					name_in, 
//					_database
//			);
		}
//		#endregion
//		#region public override string SQLFunction_delete_query(...);
		public override string SQLFunction_delete_query(string name_in) {

// ToDos: here! i'm half sure database name is needed!
throw new Exception("not implemented!");

			//return string.Format(
			//    "DROP FUNCTION `{0}`",
			//    name_in
			//);
		}
//		#endregion
//		#region public override string SQLStoredProcedure_exists_query(...);
		public override string SQLStoredProcedure_exists_query(string name_in) {

// ToDos: here!
throw new Exception("not implemented!");

//            string _database = Connectionstring_database();
//            return string.Format(
//                #region "SELECT ...",
//@"
//SELECT null
//FROM INFORMATION_SCHEMA.ROUTINES
//WHERE
//	(routine_type = 'PROCEDURE')
//	AND
//	(routine_name = '{0}')
//	AND
//	(routine_schema = '{1}')
//",
//                    name_in,
//                    _database
//                #endregion
//            );
		}
//		#endregion
//		#region public override string SQLStoredProcedure_delete_query(...);
		public override string SQLStoredProcedure_delete_query(string name_in) {

// ToDos: here! i'm half sure database name is needed!
throw new Exception("not implemented!");

			//return string.Format(
			//    "DROP PROCEDURE `{0}`",
			//    name_in
			//);
		}
//		#endregion
//		#region public override string SQLView_exists_query(...);
		public override string SQLView_exists_query(string name_in) {

// ToDos: here!
throw new Exception("not implemented!");

//            string _database = Connectionstring_database();
//            return string.Format(
//                #region "SELECT ...",
//@"
//SELECT null
//FROM INFORMATION_SCHEMA.TABLES
//WHERE
//	(TABLE_TYPE = 'VIEW')
//	AND
//	(TABLE_NAME = '{0}')
//	AND
//	(TABLE_SCHEMA = '{1}')
//",
//                name_in,
//                _database
//                #endregion
//            );
        }
//		#endregion
//		#region public override string SQLView_delete_query(...);
		public override string SQLView_delete_query(string name_in) {

// ToDos: here! i'm half sure database name is needed!
throw new Exception("not implemented!");

			//return string.Format(
			//    "DROP VIEW `{0}`",
			//    name_in
			//);
		}
//		#endregion
		//---
		//---
		#region public override string getDBs_query();
		public override string getDBs_query() {
			return
@"
SELECT SCHEMA_NAME 
FROM INFORMATION_SCHEMA.SCHEMATA 
WHERE 
	(SCHEMA_NAME != 'information_schema') 
	AND 
	(SCHEMA_NAME != 'mysql') 
ORDER BY SCHEMA_NAME
"
			;
		}
		#endregion
//		#region public override string getTables_query(string subAppName_in);
		public override string getTables_query(
			string dbName_in, 
			string subAppName_in
		) {

// ToDos: here! 1 - Connectionstring_database() not supported!
// ToDos: here! 2 - CAST(1 AS Signed Int) carefull on how provider converts server var to .net var, 
//					check DBConnection.getTables(...);
throw new Exception("not implemented!");

//            StringBuilder _query = new StringBuilder(string.Empty);
//            string _database = Connectionstring_database();
//            #region _query.Append("SELECT ...");
//            _query.Append(string.Format(@"
//SELECT
//	TABLE_NAME AS ""Name"",
//	CASE
//		WHEN (TABLE_TYPE = 'VIEW') THEN
//			CAST(1 AS Signed Int)
//		ELSE
//			CAST(0 AS Signed Int)
//	END AS ""isVT""
//FROM INFORMATION_SCHEMA.TABLES
//WHERE
//	(
//		(TABLE_TYPE = 'BASE TABLE')
//		OR
//		(TABLE_TYPE = 'VIEW')
//	)
//	AND
//	(TABLE_SCHEMA = '{0}')
//", 
//                _database
//            ));
//            #endregion
//            if (subAppName_in != "" ) {
//                _query.Append("AND (");
//                string[] _subAppNames = subAppName_in.Split('|');
//                for (int i = 0; i < _subAppNames.Length; i++) {
//                    _query.Append(string.Format(
//                        "(TABLE_NAME {0} '{1}'){2}",
//                        (_subAppNames[i].IndexOf('%') >= 0) ? "LIKE" : "=",
//                        _subAppNames[i],
//                        (i == _subAppNames.Length - 1) ? "" : " OR "
//                    ));
//                }
//                _query.Append(") ");
//            }
//            _query.Append(@"ORDER BY ""Name"" ");

//            return _query.ToString();
		}
//		#endregion
//		#region public override string getTableFields_query(...);
		public override string getTableFields_query(
			string tableName_in
		) {

// ToDos: here! 1 - Connectionstring_database() not supported!
// ToDos: here! 2 - CAST(1 AS Signed Int) carefull on how provider converts server var to .net var, 
//					check DBConnection.getTableFields(...);
throw new Exception("not implemented!");

//            string _database = Connectionstring_database();
//            #region return "SELECT ...";
//            return string.Format(@"
//SELECT
//	t1.COLUMN_NAME AS ""Name"", 
//--	CASE
//--		WHEN t1.IS_NULLABLE = 'NO' THEN
//			CAST(0 AS Signed Int)
//--		ELSE
//--			CAST(1 AS Signed Int)
//--	END
//	AS ""isNullable"", 
//	t1.DATA_TYPE AS ""Type"", 
//	t1.CHARACTER_MAXIMUM_LENGTH AS ""Size"", 
//	CASE
//		WHEN ((t6.TABLE_TYPE != 'VIEW') AND (t1.COLUMN_KEY = 'PRI')) THEN
//			CAST(1 AS Signed Int)
//		ELSE
//			CAST(0 AS Signed Int)
//	END AS ""isPK"", 
//	CASE
//		WHEN ((t6.TABLE_TYPE != 'VIEW') AND (t1.EXTRA = 'auto_increment')) THEN
//			CAST(1 AS Signed Int)
//		ELSE
//			CAST(0 AS Signed Int)
//	END AS ""isIdentity"", 
//	NULL AS ""FK_TableName"", 
//	NULL AS ""FK_FieldName""
//FROM INFORMATION_SCHEMA.COLUMNS AS t1
//	LEFT JOIN INFORMATION_SCHEMA.TABLES t6 ON ((t6.TABLE_SCHEMA = t1.TABLE_SCHEMA) AND (t6.TABLE_NAME = t1.TABLE_NAME))
//WHERE 
//	(t1.TABLE_NAME = '{0}') 
//	AND
//	(t1.TABLE_SCHEMA = '{1}')
//ORDER BY t1.TABLE_NAME, t1.ORDINAL_POSITION
//",
//                tableName_in,
//                Connectionstring_DBName
//            );
//            #endregion
		}
//		#endregion
	}
}
