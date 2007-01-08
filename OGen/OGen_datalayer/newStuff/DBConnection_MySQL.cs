#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

    Free Software Foundation, Inc., 
    59 Temple Place, Suite 330, 
    Boston, MA 02111-1307 USA 

                            - or -

    http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;

namespace OGen.lib.datalayer.newStuff {
	public sealed class cDBConnection_MySQL : cDBConnection {
		//#region public cDBConnection_MySQL(...);
		public cDBConnection_MySQL(
			string connectionstring_in
		) : base (
			eDBServerTypes.MySQL, 
			connectionstring_in,
			string.Empty
		) {
		}
		public cDBConnection_MySQL(
			string connectionstring_in,
			string logfile_in
		) : base (
			eDBServerTypes.MySQL, 
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
					utils__ = new cDBUtils_MySQL();
				}
				return utils__;
			}
		}
		#endregion
		//#endregion
		//#region public properties...
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
				_newdbdataadapter_out.SelectCommand.Transaction = (MySqlTransaction)transaction__.exposeTransaction;
			}

			return _newdbdataadapter_out;
		}
		#endregion
		//#endregion
		//#region public Methods...
		#region public override IDbDataParameter newDBDataParameter(...);
		public override IDbDataParameter newDBDataParameter(string name_in, DbType dbType_in, ParameterDirection parameterDirection_in, object value_in, int size_in) {
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
			#region command_in.CommandText = function_in;
			//switch (dbservertype_) {
			//    case eDBServerTypes.PostgreSQL: {
			//            command_in.CommandText =
			//                string.Format("\"{0}\"", function_in);
			//            break;
			//        }
			//    case eDBServerTypes.SQLServer:
			//    case eDBServerTypes.MySQL:
			//    default: {
						command_in.CommandText = function_in;
			//            break;
			//        }
			//}
			#endregion
			command_in.CommandType = CommandType.StoredProcedure;
			try {
				if (returnValue_Size_in >= 0) {
					//switch (dbservertype_) {
					//    case eDBServerTypes.SQLServer:
					//    case eDBServerTypes.MySQL: {
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
					//            break;
					//        }
					//    case eDBServerTypes.PostgreSQL: {
					//            Execute_SQLFunction_out =
					//                command_in.ExecuteScalar();
					//            break;
					//        }
					//    default:
					//        throw new Exception("invalid DBServerType");
					//}
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
//		#region protected override string sqlfunction_exists(...);
		protected override string sqlfunction_exists(string name_in) {

// ToDos: here!
throw new Exception("not implemented!");

//			string _database = Connectionstring_database();
//			return string.Format(
//                #region "SELECT ...", 
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
//                #endregion
//                name_in, 
//                _database
//            );
		}
//		#endregion
//		#region protected override string sqlfunction_delete(...);
        protected override string sqlfunction_delete(string name_in) {

// ToDos: here! i'm half sure database name is needed!
throw new Exception("not implemented!");

			//return string.Format(
			//    "DROP FUNCTION `{0}`",
			//    name_in
			//);
		}
//		#endregion
//		#region protected override string sqlstoredprocedure_exists(...);
		protected override string sqlstoredprocedure_exists(string name_in) {

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
//		#region protected override string sqlstoredprocedure_delete(...);
		protected override string sqlstoredprocedure_delete(string name_in) {

// ToDos: here! i'm half sure database name is needed!
throw new Exception("not implemented!");

			//return string.Format(
			//    "DROP PROCEDURE `{0}`",
			//    name_in
			//);
		}
//		#endregion
//		#region protected override string sqlview_exists(...);
		protected override string sqlview_exists(string name_in) {

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
//		#region protected override string sqlview_delete(...);
		protected override string sqlview_delete(string name_in) {

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
		#region protected override string getdbs();
		protected override string getdbs() {
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
//		#region protected override string gettables(string subAppName_in);
		protected override string gettables(string subAppName_in) {

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
//		#region protected override string gettablefields(...);
		protected override string gettablefields(
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
//                _database
//            );
//            #endregion
		}
//		#endregion
	}
}