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
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
#if PostgreSQL
using Npgsql;
#endif
#if MySQL
using MySql.Data.MySqlClient;
#endif

namespace OGen.lib.datalayer {
	#region /// <summary>...</summary>
	/// <summary>
	///	Provides access to supported DataBases like PostgreSQL and SQL Server, allowing the execution of SQL Queries and Functions retrieving their existing data if any. It also supports Transactions.
	/// </summary>
	/// <threadsafety static="true" instance="false"/>
	/// <remarks>
	/// There is no need to Open a Connection in order to execute an SQL Query or Function. Open and Close methods are usually used when working with the Transaction
	/// </remarks>
	/// <example>
	/// This sample shows how to execute an SQL Query and populate a DataTable with it's return Output
	/// <code>
	/// cDBConnection _connection = new cDBConnection(
	///		eDBServerTypes.PostgreSQL, 
	///		OGen.lib.datalayer.utils.Connectionstring.Buildwith.Parameters(
	///			"127.0.0.1", 
	///			"postgres", 
	///			"password", 
	///			"TestDB", 
	///			eDBServerTypes.PostgreSQL
	///		)
	///	);
	///	
	///	DataTable _datatable 
	///		= _connection.Execute_SQLQuery_returnDataTable("select * from \"User\"");
	///	// ...
	///	
	///	_connection.Dispose(); _connection = null;
	///	</code>
	/// This sample shows how to execute an SQL Function and populate a DataTable with it's return Output
	///	<code>
	/// cDBConnection _connection = new cDBConnection(
	///		eDBServerTypes.PostgreSQL, 
	///		OGen.lib.datalayer.utils.Connectionstring.Buildwith.Parameters(
	///			"127.0.0.1", 
	///			"postgres", 
	///			"password", 
	///			"TestDB", 
	///			eDBServerTypes.PostgreSQL
	///		)
	///	);
	///	
	///	IDbDataParameter[] _dbdataparameters = new IDbDataParameter[] {
	///		_connection.newDBDataParameter(
	///			"SomeParameter_", 
	///			DbType.String, 
	///			ParameterDirection.Output, 
	///			null, 
	///			50
	///		), 
	///		_connection.newDBDataParameter(
	///			"SomeOtherParameter_", 
	///			DbType.String, 
	///			ParameterDirection.Output, 
	///			null, 
	///			50
	///		)
	///	};
	///	
	///	DataTable _datatable 
	///		= _connection.Execute_SQLFunction_returnDataTable(
	///			"SomeSQLFunction", 
	///			_dbdataparameters
	///		);
	///	// ...
	///	
	///	_connection.Dispose(); _connection = null;
	///	</code>
	/// </example>
	#endregion
	public sealed class cDBConnection : IDisposable {
//		#region public cDBConnection(...);
		/// <param name="dbServerType_in">DataBase Server Type</param>
		/// <param name="connectionstring_in">Connection String</param>
		public cDBConnection(
			eDBServerTypes dbServerType_in, 
			string connectionstring_in
		) {
			Logenabled = false;
			Logfile = null;

			dbservertype_ = dbServerType_in;
			isopen_ = false;
			connectionstring_ = connectionstring_in;
		}

		/// <param name="dbServerType_in">DataBase Server Type</param>
		/// <param name="connectionstring_in">Connection String</param>
		/// <param name="Logfile_in">Log File</param>
		public cDBConnection(
			eDBServerTypes dbServerType_in, 
			string connectionstring_in, 
			string Logfile_in
		) : this (
			dbServerType_in, 
			connectionstring_in
		) {
			if (
				(Logfile_in == null) 
				||
				(Logfile_in == string.Empty) 
				||
				(!File.Exists(Logfile_in))
			) {
				Logenabled = false;
				Logfile = null;
			} else {
				Logenabled = true;
				Logfile = Logfile_in;
			}
		}

		///
		~cDBConnection() {
			cleanUp();
		}
		/// <summary>
		/// Closes any left open Connection and terminates any initiated Transaction.
		/// </summary>
		public void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();
		}
		private void cleanUp() {
			if (isopen_) Close();

			if (transaction__ != null) {
				transaction__.Dispose(); transaction__ = null;
			}
		}
//		#endregion

		#region Exceptions...
		#region public static readonly Exception InvalidConnectionstringException_empty;
		/// <summary>
		/// Invalid Connection String Exception (empty).
		/// </summary>
		public static readonly Exception InvalidConnectionstringException_empty 
			= new Exception("invalid connection string (empty)");
		#endregion
		#region public static readonly Exception InvalidSQLQueryException_empty;
		/// <summary>
		/// Invalid SQL Query Exception (empty).
		/// </summary>
		public static readonly Exception InvalidSQLQueryException_empty 
			= new Exception("invalid sql query (empty)");
		#endregion
		#endregion

		#region private Properties...
		private bool Logenabled;
		private string Logfile;
		#endregion
		#region public Properties...
		#region public eDBServerTypes DBServerType { get; }
		private eDBServerTypes dbservertype_;

		/// <summary>
		/// DataBase Server Type.
		/// </summary>
		public eDBServerTypes DBServerType {
			get { return dbservertype_; }
		}
		#endregion
		#region public string Connectionstring { get; }
		private string connectionstring_;

		/// <summary>
		/// Connection String.
		/// </summary>
		public string Connectionstring {
			get { return connectionstring_; }
		}
		#endregion
		#region public IDbConnection Connection { get; }
		private IDbConnection connection_;

		/// <summary>
		/// Exposing real DataBase Connection as read only, should it be needed.
		/// </summary>
		public IDbConnection exposeConnection {
			get { return (IDbConnection)connection_; }
		}
		#endregion
		#region public cDBTransaction Transaction { get; }
		/// <summary>
		/// DataBase Connection's Transaction access.
		/// <note type="caution">
		/// IMPORTANT! access should be made via Transaction instead
		/// </note>
		/// </summary>
		private cDBTransaction transaction__;

		/// <summary>
		/// DataBase Connection's Transaction access.
		/// </summary>
		public cDBTransaction Transaction {
			get {
				if (transaction__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					transaction__ = new cDBTransaction(this);
				}
				return transaction__;
			}
		}
		#endregion
		#region public bool isOpen { get; }
		private bool isopen_;

		/// <summary>
		/// Indicates DataBase Connection state, True if oppened, False if closed.
		/// </summary>
		public bool isOpen {
			get { return isopen_; }
		}
		#endregion
		#endregion

		#region private Methods...
		#region private void Log(...);
		private void Log(
			string type_in, 
			string value_in
		) {
			Log(type_in, value_in, null);
		}
		private void Log(
			string type_in, 
			string value_in, 
			IDbDataParameter[] dataParameters_in
		) {
			StringBuilder _parameters = new StringBuilder(string.Empty);
			if (dataParameters_in == null) {
			} else {
				_parameters.Append("(");
				for (int i = 0; i < dataParameters_in.Length; i++) {
					_parameters.Append(
						string.Format(
							"{0}:{1}{2}", 
							dataParameters_in[i].ParameterName, 
							(dataParameters_in[i].Value == null) ? 
								"null" : 
								dataParameters_in[i].Value.ToString(), 
							(i != (dataParameters_in.Length -1)) ? 
								", " : 
								string.Empty
						)
					);
				}
				_parameters.Append(")");
			}

			StreamWriter _writer = new StreamWriter(Logfile, true);
			_writer.WriteLine(string.Format(
				"{0} - {1}: {2}{3}", 
				DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 
				type_in, 
				value_in, 
				_parameters.ToString()
			));
			_writer.Close(); //_writer.Dispose();
		}
		#endregion
		#region private IDbConnection newDBConnection();
		private IDbConnection newDBConnection() {
			switch (dbservertype_) {
				case eDBServerTypes.ODBC:
					return new OdbcConnection(connectionstring_);
				case eDBServerTypes.SQLServer:
					return new SqlConnection(connectionstring_);
				case eDBServerTypes.Access:
				case eDBServerTypes.Excel:
					return new OleDbConnection(connectionstring_);
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
					return new NpgsqlConnection(connectionstring_);
#endif
#if MySQL
				case eDBServerTypes.MySQL:
					return new MySql.Data.MySqlClient.MySqlConnection(connectionstring_);
#endif
				default:
					throw new Exception("invalid DBServerType");
			}
		}
		#endregion
		#region private IDbCommand newDBCommand(...);
		private IDbCommand newDBCommand(string command_in, IDbConnection connection_in) {
			switch (dbservertype_) {
				case eDBServerTypes.SQLServer: {
					SqlCommand _sqlcommand;

					if ((transaction__ != null) && (transaction__.inTransaction)) {
						_sqlcommand = new SqlCommand(
							command_in,
							(SqlConnection)connection_in, 
							(SqlTransaction)Transaction.exposeTransaction
						);
					} else {
						_sqlcommand = new SqlCommand(
							command_in,
							(SqlConnection)connection_in
						);
					}

					_sqlcommand.CommandTimeout = connection_in.ConnectionTimeout;

					return _sqlcommand;
				}
#if PostgreSQL
				case eDBServerTypes.PostgreSQL: {
					NpgsqlCommand _sqlcommand = new NpgsqlCommand(
						command_in,
						(NpgsqlConnection)connection_in
					);

					_sqlcommand.CommandTimeout = connection_in.ConnectionTimeout;

					return _sqlcommand;
				}
#endif
#if MySQL
				case eDBServerTypes.MySQL: {
					MySql.Data.MySqlClient.MySqlCommand _sqlcommand = new MySql.Data.MySqlClient.MySqlCommand(
						command_in,
						(MySql.Data.MySqlClient.MySqlConnection)connection_in
					);

					_sqlcommand.CommandTimeout = connection_in.ConnectionTimeout;

					return _sqlcommand;
				}
#endif
				case eDBServerTypes.Excel:
				case eDBServerTypes.Access:
					return new OleDbCommand(
						command_in,
						(OleDbConnection)connection_in
					);
				case eDBServerTypes.ODBC:
					return new OdbcCommand(
						command_in,
						(OdbcConnection)connection_in
					);
				default:
					throw new Exception("invalid DBServerType");
			}
		}
		#endregion
		#region private IDbDataAdapter newDBDataAdapter(...);
		private IDbDataAdapter newDBDataAdapter(string query_in, IDbConnection connection_in, bool isQuery_notProcedure_in) {
			switch (DBServerType) {
				case eDBServerTypes.SQLServer: {
					SqlDataAdapter _sqldataadapter = new SqlDataAdapter(
						query_in,
						(SqlConnection)connection_in
					);
					if ((transaction__ != null) && (transaction__.inTransaction)) {
						_sqldataadapter.SelectCommand.Transaction = (SqlTransaction)Transaction.exposeTransaction;
					}
					return _sqldataadapter;
				}
#if PostgreSQL
				case eDBServerTypes.PostgreSQL: {
					return new NpgsqlDataAdapter(
						(isQuery_notProcedure_in) ? query_in : "\"" + query_in + "\"",
						(NpgsqlConnection)connection_in
					);
				}
#endif
#if MySQL
				case eDBServerTypes.MySQL: {
					return new MySql.Data.MySqlClient.MySqlDataAdapter(
						query_in,
						(MySql.Data.MySqlClient.MySqlConnection)connection_in
					);
				}
#endif
				case eDBServerTypes.Excel:
				case eDBServerTypes.Access:
					return new OleDbDataAdapter(
						query_in,
						(OleDbConnection)connection_in
					);
				case eDBServerTypes.ODBC:
					return new OdbcDataAdapter(
						query_in,
						(OdbcConnection)connection_in
					);
				default:
					throw new Exception("invalid DBServerType");
			}
		}
		#endregion
		#endregion
//		#region public Methods...
		#region public string Connectionstring_database();
		/// <summary>
		/// Parses the ConnectionString to look for DataBase name.
		/// </summary>
		/// <returns>DataBase name</returns>
		public string Connectionstring_database() {
			return utils.Connectionstring.ParseParameter(
				Connectionstring, 
				DBServerType, 
				utils.Connectionstring.eParameter.Database
			);

			#region // old stuff...
			//string _connectionstring_database_out;

			//System.Text.RegularExpressions.Regex fields_reg = new System.Text.RegularExpressions.Regex(
			//    "^(?<before>.*)database=(?<db>.*);(?<after>.*)",
			//    System.Text.RegularExpressions.RegexOptions.Compiled |
			//    System.Text.RegularExpressions.RegexOptions.IgnoreCase
			//);
			//System.Text.RegularExpressions.Match matchingfields = fields_reg.Match(Connectionstring);
			//if (!matchingfields.Success) {
			//    throw new Exception(
			//        string.Format(
			//            "{0}.{1}.getTableFields: - error parsing db connectionstring to find database name: '{2}'",
			//            this.GetType().Namespace,
			//            this.GetType().Name,
			//            Connectionstring
			//        )
			//    );
			//} else {
			//    _connectionstring_database_out = matchingfields.Groups["db"].Value;
			//}

			//return _connectionstring_database_out;
			#endregion
		}
		#endregion
		#region public IDbDataParameter newDBDataParameter(...);
		/// <summary>
		/// Instantiates a new IDbDataParameter for the Connection's taking in consideration the appropriate DataBase Server Type.
		/// </summary>
		/// <param name="name_in">Parameter's Name</param>
		/// <param name="dbType_in">Parameter's DbType</param>
		/// <param name="parameterDirection_in">Parameter's Direction</param>
		/// <param name="value_in">Parameter's Value</param>
		/// <returns>new IDbDataParameter</returns>
		public IDbDataParameter newDBDataParameter(
			string name_in, 
			DbType dbType_in, 
			ParameterDirection parameterDirection_in, 
			object value_in
		) {
			return newDBDataParameter(
				name_in, 
				dbType_in,
				parameterDirection_in, 
				value_in,
				0, 
				(byte)0, 
				(byte)0
			);
		}
		/// <summary>
		/// Instantiates a new IDbDataParameter for the Connection's taking in consideration the appropriate DataBase Server Type.
		/// </summary>
		/// <param name="name_in">Parameter's Name</param>
		/// <param name="dbType_in">Parameter's DbType</param>
		/// <param name="parameterDirection_in">Parameter's Direction</param>
		/// <param name="value_in">Parameter's Value</param>
		/// <param name="size_in">Parameter's Size (the actual DataBase Parameter Size representation, if such exists for the Parameter)</param>
		/// <returns>new IDbDataParameter</returns>
		public IDbDataParameter newDBDataParameter(
			string name_in, 
			DbType dbType_in, 
			ParameterDirection parameterDirection_in, 
			object value_in, 
			int size_in
		) {
			return newDBDataParameter(
				name_in,
				dbType_in,
				parameterDirection_in,
				value_in,
				size_in,
				(byte)0,
				(byte)0
			);
		}
		/// <summary>
		/// Instantiates a new IDbDataParameter for the Connection's taking in consideration the appropriate DataBase Server Type.
		/// </summary>
		/// <param name="name_in">Parameter's Name</param>
		/// <param name="dbType_in">Parameter's DbType</param>
		/// <param name="parameterDirection_in">Parameter's Direction</param>
		/// <param name="value_in">Parameter's Value</param>
		/// <param name="size_in">Parameter's Size (the actual DataBase Parameter Size representation, if such exists for the Parameter)</param>
		/// <returns>new IDbDataParameter</returns>
		public IDbDataParameter newDBDataParameter(
			string name_in, 
			DbType dbType_in, 
			ParameterDirection parameterDirection_in, 
			object value_in, 
			int size_in, 
			byte precision_in, 
			byte scale_in
		) {
			IDbDataParameter _newdbdataparameter_out;

			switch (DBServerType) {
				case eDBServerTypes.SQLServer:
					_newdbdataparameter_out = new SqlParameter();
					_newdbdataparameter_out.ParameterName = 
						(name_in.Substring(0, 1) == "@") ?
					name_in : 
						string.Format("@{0}", name_in);
					break;
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
					_newdbdataparameter_out = new NpgsqlParameter();
					_newdbdataparameter_out.ParameterName = ":\"" + name_in + "\"";
					break;
#endif
#if MySQL
				case eDBServerTypes.MySQL:
					_newdbdataparameter_out = new MySql.Data.MySqlClient.MySqlParameter();
					_newdbdataparameter_out.ParameterName = "?" + name_in;
					break;
#endif
				case eDBServerTypes.Excel:
				case eDBServerTypes.Access:
					_newdbdataparameter_out = new OleDbParameter();
					_newdbdataparameter_out.ParameterName = name_in;
					break;
				case eDBServerTypes.ODBC:
					_newdbdataparameter_out = new OdbcParameter();
					_newdbdataparameter_out.ParameterName = name_in;
					break;
				default:
					throw new Exception("invalid DBServerType");
			}

#if PostgreSQL
// fmonteiro: by default npgsql assumes any datetime 
// to be time zoned
if (
	(DBServerType == eDBServerTypes.PostgreSQL)
	&&
	(dbType_in == DbType.DateTime)
) {
	_newdbdataparameter_out.DbType = dbType_in;
	// EXPLICITLY assuming datetime without time zone
	((NpgsqlParameter)_newdbdataparameter_out).NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Timestamp;
} else {
#endif
	_newdbdataparameter_out.DbType = dbType_in;
#if PostgreSQL
}
#endif


			_newdbdataparameter_out.Direction = parameterDirection_in;
			if ((value_in == null) || (value_in == DBNull.Value)) {
				if (DBServerType == eDBServerTypes.SQLServer) {
					((SqlParameter)_newdbdataparameter_out).IsNullable = true;
				}
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
		//---
		#region public void Open(...);
		#region public static readonly Exception OpenException_alreadyOpened;
		/// <summary>
		/// Can't Open Connection Exception, Connection already opened.
		/// </summary>
		public static readonly Exception OpenException_alreadyOpened 
			= new Exception("can't open, connection already opened");
		#endregion

		/// <summary>
		/// Opens DataBase Connection.
		/// </summary>
		/// <exception cref="InvalidConnectionstringException_empty">
		/// Thrown when an empty Connection String has been supplied
		/// </exception>
		/// <exception cref="OpenException_alreadyOpened">
		/// Thrown when the Connection is already opened
		/// </exception>
		/// <remarks>
		/// There is no need to Open a Connection in order to execute an SQL Query or Function. Open and Close methods are usually used when working with the Transaction
		/// </remarks>
		public void Open() {
			#region Checking...
			if (connectionstring_.Trim() == string.Empty)
				throw InvalidConnectionstringException_empty;
			if (isopen_)
				throw OpenException_alreadyOpened;
			#endregion
			connection_ = newDBConnection();
			connection_.Open();

			isopen_ = true;
		}
		#endregion
		#region public void Close(...);
		#region public static readonly Exception CloseException_alreadyClosed;
		/// <summary>
		/// Can't Close Connection Exception, Connection already Closed.
		/// </summary>
		public static readonly Exception CloseException_alreadyClosed 
			= new Exception("can't close, connection already closed");
		#endregion
		#region public static readonly Exception CloseException_unterminatedTransaction;
		/// <summary>
		/// Can't Close Connection Exception, unterminated Transaction initiated.
		/// </summary>
		public static readonly Exception CloseException_unterminatedTransaction 
			= new Exception("can't close, unterminated transaction initiated");
		#endregion

		/// <summary>
		/// Closes DataBase Connection.
		/// </summary>
		/// <exception cref="CloseException_alreadyClosed">
		/// Thrown when the Connection is already closed
		/// </exception>
		/// <exception cref="CloseException_unterminatedTransaction">
		/// Thrown when the Connection has an unterminated Transaction initiated
		/// </exception>
		public void Close() {
			#region Checking...
			if (!isopen_)
				throw CloseException_alreadyClosed;
			if ((transaction__ != null) && transaction__.inTransaction)
				throw CloseException_unterminatedTransaction;
			#endregion Checking
			connection_.Close();
			connection_.Dispose();
			connection_ = null;

			isopen_ = false;
		}
		#endregion
		//---
//		#region public void Execute_SQLQuery(...);
//		#region private void Execute_SQLQuery(...);
		private void Execute_SQLQuery(string query_in, IDbCommand command_in) {

if (Logenabled) {
	Log("sql query", query_in);
}

			command_in.CommandType = CommandType.Text;
			try {
				command_in.ExecuteNonQuery();
			} catch (Exception e) {
				throw new Exception(
					string.Format(
						"--- query:\n{0}\n\n--- ConnectionString:\n{1}\n\n--- exception:\n{2}\n",
						query_in,
						connectionstring_, 
						e.ToString()
					)
				);
			}
		}
//		#endregion
		#region public void Execute_SQLQuery(string query_in);
		/// <summary>
		/// Executes an SQL Query on DataBase.
		/// </summary>
		/// <param name="query_in">SQL Query</param>
		/// <exception cref="InvalidSQLQueryException_empty">
		/// Thrown when an empty SQL Query has been supplied
		/// </exception>
		/// <exception cref="InvalidConnectionstringException_empty">
		/// Thrown when an empty Connection String has been supplied
		/// </exception>
		public void Execute_SQLQuery(string query_in) {
			#region Checking...
			if (
				(query_in == null)
				||
				(query_in.Trim() == string.Empty)
			)
				throw InvalidSQLQueryException_empty;
			#endregion

			if (isopen_) {
				#region Using Opened Connection...
				IDbCommand _command = newDBCommand(query_in, connection_);
				if ((transaction__ != null) && transaction__.inTransaction) {
					_command.Transaction = Transaction.exposeTransaction;
				}
				Execute_SQLQuery(query_in, _command);
				_command.Dispose(); _command = null;
				#endregion
			} else {
				#region Creating new Connection...
				#region Checking...
				if (connectionstring_.Trim() == string.Empty)
					throw InvalidConnectionstringException_empty;
				#endregion

				IDbConnection _connection2 = newDBConnection();
				_connection2.Open();

				IDbCommand _command = newDBCommand(query_in, _connection2);
				Execute_SQLQuery(query_in, _command);
				_command.Dispose(); _command = null;

				_connection2.Close();
				_connection2.Dispose(); _connection2 = null;
				#endregion
			}
		}
		#endregion
//		#endregion
//		#region public DataSet Execute_SQLQuery_returnDataSet(...);
//		#region private DataSet Execute_SQLQuery_returnDataSet(...);
		private DataSet Execute_SQLQuery_returnDataSet(
			string query_in, 
			IDbConnection connection_in
		) {
			DataSet Execute_SQLQuery_returnDataSet_out;

			IDbDataAdapter _dataadapter = newDBDataAdapter(query_in, connection_in, true);
			try {

if (Logenabled) {
	Log("sql query", query_in);
}

				Execute_SQLQuery_returnDataSet_out = new DataSet();
				_dataadapter.Fill(Execute_SQLQuery_returnDataSet_out);
			} catch (Exception e) {
				throw new Exception(
					string.Format(
						"query: {0}\nConnectionString: {1}\nexception: {2}\n",
						query_in,
						connectionstring_, 
						e.ToString()
					)
				);
			}
			//_dataadapter.Dispose(); // not implemented in IDbDataAdapter
			_dataadapter = null;

			return Execute_SQLQuery_returnDataSet_out;
		}
//		#endregion
		#region public DataSet Execute_SQLQuery_returnDataSet(string query_in);
		/// <summary>
		/// Executes an SQL Query on DataBase.
		/// </summary>
		/// <param name="query_in">SQL Query</param>
		/// <exception cref="InvalidConnectionstringException_empty">
		/// Thrown when an empty Connection String has been supplied
		/// </exception>
		/// <returns>populated DataSet with SQL Query's Output</returns>
		public DataSet Execute_SQLQuery_returnDataSet(string query_in) {
			DataSet Execute_SQLQuery_returnDataSet_out;

			if (isopen_) {	// Using Opened Connection
				Execute_SQLQuery_returnDataSet_out 
					= Execute_SQLQuery_returnDataSet(
						query_in, 
						connection_
					);
			} else {		// Creating new Connection
				#region Checking...
				if (connectionstring_ == string.Empty)
					throw InvalidConnectionstringException_empty;
				#endregion
				IDbConnection _connection2 = newDBConnection();
				_connection2.Open();

				Execute_SQLQuery_returnDataSet_out 
					= Execute_SQLQuery_returnDataSet(
						query_in, 
						_connection2
					);

				_connection2.Close();
				_connection2.Dispose(); _connection2 = null;
			}

			return Execute_SQLQuery_returnDataSet_out;
		}
		#endregion
//		#endregion
		#region public DataTable Execute_SQLQuery_returnDataTable(string query_);
		/// <summary>
		/// Executes an SQL Query on DataBase.
		/// </summary>
		/// <param name="query_in">SQL Query</param>
		/// <returns>populated DataTable with SQL Query's Output</returns>
		public DataTable Execute_SQLQuery_returnDataTable(string query_in) {
			DataTable Execute_SQLQuery_returnDataTable_out;

			#region Execute_SQLQuery_returnDataTable_out = Execute_SQLQuery_returnDataSet(query_in).Tables[0];
			DataSet _dataset = Execute_SQLQuery_returnDataSet(query_in);
			Execute_SQLQuery_returnDataTable_out = _dataset.Tables[0];
			_dataset.Dispose(); _dataset = null;
			#endregion

			return Execute_SQLQuery_returnDataTable_out;
		}
		#endregion
//		#region public object Execute_SQLFunction(...);
//		#region private object Execute_SQLFunction(...);
		private object Execute_SQLFunction(
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
#if PostgreSQL
			#region //depricated Npgsql stuff...
//			if (DBServerType == eDBServerTypes.PostgreSQL) {
//				string in_parameters = "";
//				string out_parameters = "";
//				for (int i = 0; i < Parameters_.Length; i++) {
//					switch (Parameters_[i].Direction) {
//						case ParameterDirection.Input:
//							in_parameters += string.Format(
//								"{0}{1}", 
//								(in_parameters != "") ? ", " : "",
//								// NOTA: a classe Npgsql já mete o nome com dois pontos!!!
//								/*":" +*/ Parameters_[i].ParameterName
//							);
//							break;
//						case ParameterDirection.Output:
////							out_parameters += string.Format(
////								"{0}{1}", 
////								(out_parameters != "") ? ", " : "", 
////								Parameters_[i].ParameterName
////							);
//							break;
//						case ParameterDirection.InputOutput:
//						case ParameterDirection.ReturnValue:
//							break;
//					}
//				}
//				command_.CommandText = string.Format(
//					"{0}{1}{2}",
//					Storedprocedure_,
//					(in_parameters != "") ? "(" + in_parameters + ")": "",
//					(out_parameters != "") ? " as (" + out_parameters + ")" : ""
//				);
//			} else {
//				command_.CommandText = Storedprocedure_;
//			}
			#endregion
#endif
			#region command_in.CommandText = function_in;
			switch (dbservertype_) {
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
					command_in.CommandText =
						string.Format("\"{0}\"", function_in);
					break;
#endif
				case eDBServerTypes.SQLServer:
#if MySQL
				case eDBServerTypes.MySQL:
#endif
				default:
					command_in.CommandText = function_in;
					break;
			}
			#endregion
			command_in.CommandType = CommandType.StoredProcedure;
			try {
				if (returnValue_Size_in >= 0) {
					switch (dbservertype_) {
#if MySQL
						case eDBServerTypes.MySQL:
#endif
						case eDBServerTypes.SQLServer:
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
							break;
#if PostgreSQL
						case eDBServerTypes.PostgreSQL:
							Execute_SQLFunction_out = 
								command_in.ExecuteScalar();
							break;
#endif
						default:
							throw new Exception("invalid DBServerType");
					}
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
		#region public object Execute_SQLFunction(string function_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(string function_in) {
			return Execute_SQLFunction(
				function_in, 
				new IDbDataParameter[] { }, 
				DbType.Boolean, 
				-1
			);
		}
		#endregion
		#region public object Execute_SQLFunction(string function_in, DbType returnValue_DbType_in, int returnValue_Size_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="returnValue_DbType_in">DbType for return value</param>
		/// <param name="returnValue_Size_in">Size for return value (the actual DataBase return value Size representation, if such exists)</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(
			string function_in, 
			DbType returnValue_DbType_in, 
			int returnValue_Size_in
		) {
			return Execute_SQLFunction(
				function_in, 
				new IDbDataParameter[] { }, 
				returnValue_DbType_in, 
				returnValue_Size_in
			);
		}
		#endregion
		#region public object Execute_SQLFunction(string function_in, IDbDataParameter[] dataParameters_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(
			string function_in, 
			IDbDataParameter[] dataParameters_in
		) {
			return Execute_SQLFunction(function_in, dataParameters_in, DbType.Boolean, -1);
		}
		#endregion
		#region public object Execute_SQLFunction(string function_in, IDbDataParameter[] dataParameters_in, DbType returnValue_DbType_in, int returnValue_Size_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <param name="returnValue_DbType_in">DbType for return value</param>
		/// <param name="returnValue_Size_in">Size for return value (the actual DataBase return value Size representation, if such exists)</param>
		/// <exception cref="InvalidConnectionstringException_empty">
		/// Thrown when an empty Connection String has been supplied
		/// </exception>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(
			string function_in, 
			IDbDataParameter[] dataParameters_in, 
			DbType returnValue_DbType_in, 
			int returnValue_Size_in
		) {
			object Execute_SQLFunction_out;

			if (isopen_) {
				#region Using Opened Connection...
				IDbCommand _command = newDBCommand(
					function_in, 
					(IDbConnection)connection_
				);
				if ((transaction__ != null) && transaction__.inTransaction)
					_command.Transaction = transaction__.exposeTransaction;
				Execute_SQLFunction_out 
					= Execute_SQLFunction(
						function_in, 
						dataParameters_in, 
						_command, 
						returnValue_DbType_in, 
						returnValue_Size_in
					);
				_command.Dispose(); _command = null;
				#endregion
			} else {
				#region Creating new Connection...
				#region Checking...
				if (connectionstring_ == string.Empty)
					throw InvalidConnectionstringException_empty;
				#endregion
				IDbConnection _connection2 = newDBConnection();
				IDbCommand _command = newDBCommand(
					function_in, 
					_connection2
				);

				_connection2.Open();
				Execute_SQLFunction_out = Execute_SQLFunction(
					function_in, 
					dataParameters_in, 
					_command, 
					returnValue_DbType_in, 
					returnValue_Size_in
				);
				_connection2.Close();

				_command.Dispose(); _command = null;
				_connection2.Dispose(); _connection2 = null;
				#endregion
			}

			return Execute_SQLFunction_out;
		}
		#endregion
//		#endregion
//		#region public DataSet Execute_SQLFunction_returnDataSet(...);
//		#region private DataSet Execute_SQLFunction_returnDataSet(...);
		private DataSet Execute_SQLFunction_returnDataSet(
			string function_in, 
			IDbDataParameter[] dataParameters_in, 
			IDbConnection connection_in
		) {

if (Logenabled) {
	Log("sql function", function_in, dataParameters_in);
}

			DataSet Execute_SQLFunction_returnDataSet_out;

			IDbDataAdapter _dataadapter = newDBDataAdapter(
				function_in, 
				connection_in, 
				false
			);
			_dataadapter.SelectCommand.CommandType = CommandType.StoredProcedure;
			#region _dataadapter.SelectCommand.Parameters = dataParameters_in;
			for (int i = 0; i < dataParameters_in.Length; i++)
				_dataadapter.SelectCommand.Parameters.Add(dataParameters_in[i]);
			#endregion
			try {
				Execute_SQLFunction_returnDataSet_out = new DataSet();
				_dataadapter.Fill(Execute_SQLFunction_returnDataSet_out);
			} catch (Exception e) {
				throw new Exception(
					string.Format(
						"Stored Procedure: {0}\nParameters: {1}\nConnectionString: {2}\nexception: {3}\n",
						function_in,
						dataParameters_in,
						connectionstring_,
						e.ToString()
					)
				);
			}

			//_dataadapter.Dispose(); // not implemented in IDbDataAdapter
			_dataadapter = null;

			return Execute_SQLFunction_returnDataSet_out;
		}
//		#endregion
		#region public DataSet Execute_SQLFunction_returnDataSet(string function_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <returns>populated DataSet with SQL Function's Output</returns>
		public DataSet Execute_SQLFunction_returnDataSet(string function_in) {
			return Execute_SQLFunction_returnDataSet(function_in, new IDbDataParameter[] {});
		}
		#endregion
		#region public DataSet Execute_SQLFunction_returnDataSet(string function_in, IDbDataParameter[] dataParameters_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <exception cref="InvalidConnectionstringException_empty">
		/// Thrown when an empty Connection String has been supplied
		/// </exception>
		/// <returns>populated DataSet with SQL Function's Output</returns>
		public DataSet Execute_SQLFunction_returnDataSet(
			string function_in, 
			IDbDataParameter[] dataParameters_in
		) {
			DataSet Execute_SQLFunction_returnDataSet_out;

			if (isopen_) {
				#region Using Opened Connection...
				Execute_SQLFunction_returnDataSet_out 
					= Execute_SQLFunction_returnDataSet(
						function_in, 
						dataParameters_in, 
						exposeConnection
					);
				#endregion
			} else {
				#region Creating new Connection...
				#region Checking...
				if (connectionstring_ == string.Empty)
					throw InvalidConnectionstringException_empty;
				#endregion
				IDbConnection _connection2 = newDBConnection();
				_connection2.Open();

				Execute_SQLFunction_returnDataSet_out 
					= Execute_SQLFunction_returnDataSet(
						function_in, 
						dataParameters_in, 
						_connection2
					);

				_connection2.Close();
				_connection2.Dispose(); _connection2 = null;
				#endregion
			}

			return Execute_SQLFunction_returnDataSet_out;
		}
		#endregion
//		#endregion
		#region public DataTable Execute_SQLFunction_returnDataTable(...);
		#region public DataTable Execute_SQLFunction_returnDataTable(string function_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <returns>populated DataTable with SQL Function's Output</returns>
		public DataTable Execute_SQLFunction_returnDataTable(string function_in) {
			return Execute_SQLFunction_returnDataTable(function_in, new IDbDataParameter[] {});
		}
		#endregion
		#region public DataTable Execute_SQLFunction_returnDataTable(string function_in, IDbDataParameter[] dataParameters_in);
		/// <summary>
		/// Executes an SQL Function on DataBase.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <returns>populated DataTable with SQL Function's Output</returns>
		public DataTable Execute_SQLFunction_returnDataTable(
			string function_in, 
			IDbDataParameter[] dataParameters_in
		) {
			DataTable Execute_SQLFunction_returnDataTable_out;

			#region Execute_SQLFunction_returnDataTable_out = Execute_SQLFunction_returnDataSet(function_in, dataParameters_in).Tables[0];
			DataSet _dataset = 
				Execute_SQLFunction_returnDataSet(
					function_in, 
					dataParameters_in
				);
			Execute_SQLFunction_returnDataTable_out = _dataset.Tables[0];
			_dataset.Dispose(); _dataset = null;
			#endregion

			return Execute_SQLFunction_returnDataTable_out;
		}
		#endregion
		#endregion
		//---
		#region public bool SQLFunction_exists(...);
		private string sqlfunction_exists(string name_in) {
			return sqlfunction_exists(name_in, dbservertype_);
		}
		private /*static*/ string sqlfunction_exists(string name_in, eDBServerTypes dbServerType_in) {
			switch (dbServerType_in) {
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
#endif
				case eDBServerTypes.SQLServer:
					return string.Format(
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
#if MySQL
				case eDBServerTypes.MySQL:
					string _database = Connectionstring_database();
					return string.Format(
						#region "SELECT ...", 
@"
SELECT null
FROM INFORMATION_SCHEMA.ROUTINES
WHERE
	(routine_type = 'FUNCTION')
	AND
	(routine_name = '{0}')
	AND
	(routine_schema = '{1}')
", 
						#endregion
						name_in, 
						_database
					);
#endif
				default:
					throw new Exception(string.Format(
						"{0}.{1}.sqlfunction_exists(): - not implemented!",
						typeof(cDBConnection).Namespace,
						typeof(cDBConnection).Name
					));
			}
		}

		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to determine if an SQL Function exists on DataBase, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Function Name</param>
		/// <returns>True if SQL Function exists, False if not</returns>
		public bool SQLFunction_exists(string name_in) {
			return (Execute_SQLQuery_returnDataTable(
				sqlfunction_exists(name_in)
			).Rows.Count == 1);
		}
		#endregion
		#region public bool SQLFunction_delete(...);
		private string sqlfunction_delete(string name_in) {
			return sqlfunction_delete(name_in, dbservertype_);
		}
		private static string sqlfunction_delete(string name_in, eDBServerTypes dbServerType_in) {
			switch (dbServerType_in) {
				case eDBServerTypes.SQLServer: {
					return string.Format(
						"DROP FUNCTION {0}",
						name_in
					);
				}
#if MySQL
				case eDBServerTypes.MySQL: {
					return string.Format(
						"DROP FUNCTION `{0}`",
						name_in
					);
				}
#endif
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
					// ToDos: here! not implemented
					// NOTES: It's not as easy as it is for SQLServer and MySQL. PostgreSQL 
					// allows you to create diferent signatures for the same function, so in 
					// order to drop a function we need to know the parameters for such 
					// function.
					// To overcome such probleme, remember that in PostgreSQL you can use:
					// CREATE OR REPLACE FUNCTION "some_function"
#endif
				default: {
					throw new Exception(
						string.Format(
							"{0}.{1}.sqlfunction_delete(): - not implemented!", 
							typeof(cDBConnection).Namespace, 
							typeof(cDBConnection).Name
						)
					);
				}
			}
		}

		/// <summary>
		/// Deletes a specific SQL Function on DataBase, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Function Name</param>
		/// <returns>True if SQL Function existed and was deleted, False if not</returns>
		public bool SQLFunction_delete(string name_in) {
			if (SQLFunction_exists(name_in)) {
				Execute_SQLQuery(sqlfunction_delete(name_in));
				return true;
			} else {
				return false;
			}
		}
		#endregion
		#region public bool SQLStoredProcedure_exists(...);
		private string sqlstoredprocedure_exists(string name_in) {
			return sqlstoredprocedure_exists(name_in, dbservertype_);
		}
		private /*static*/ string sqlstoredprocedure_exists(string name_in, eDBServerTypes dbServerType_in) {
			switch (dbServerType_in) {
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
#endif
				case eDBServerTypes.SQLServer:
					return string.Format(
						#region "SELECT ...", 
						@"
SELECT null
FROM INFORMATION_SCHEMA.ROUTINES
WHERE
	(routine_type = 'PROCEDURE')
	AND
	(routine_name = '{0}')
", 
						#endregion
						name_in
					);
#if MySQL
				case eDBServerTypes.MySQL:
					string _database = Connectionstring_database();
					return string.Format(
						#region "SELECT ...", 
						@"
SELECT null
FROM INFORMATION_SCHEMA.ROUTINES
WHERE
	(routine_type = 'PROCEDURE')
	AND
	(routine_name = '{0}')
	AND
	(routine_schema = '{1}')
", 
						#endregion
						name_in, 
						_database
					);
#endif
				default: {
					throw new Exception("not implemented");
				}
			}
		}
		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to determine if an SQL Stored Procedure exists on DataBase, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Stored Procedure Name</param>
		/// <returns>True if SQL Stored Procedure exists, False if not</returns>
		public bool SQLStoredProcedure_exists(string name_in) {
			return (Execute_SQLQuery_returnDataTable(
				sqlstoredprocedure_exists(name_in)
			).Rows.Count == 1);
		}
		#endregion
		#region public bool SQLStoredProcedure_delete(...);
		private string sqlstoredprocedure_delete(string name_in) {
			return sqlstoredprocedure_delete(name_in, dbservertype_);
		}
		private static string sqlstoredprocedure_delete(string name_in, eDBServerTypes dbServerType_in) {
			switch (dbServerType_in) {
				case eDBServerTypes.SQLServer: {
					return string.Format(
						"DROP PROCEDURE {0}",
						name_in
					);
				}
#if MySQL
				case eDBServerTypes.MySQL: {
					return string.Format(
						"DROP PROCEDURE `{0}`",
						name_in
					);
				}
#endif
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
					// ToDos: here! not implemented
					// NOTES: It's not as easy as it is for SQLServer and MySQL. PostgreSQL 
					// allows you to create diferent signatures for the same procedure, so in 
					// order to drop a procedure we need to know the parameters for such 
					// procedure.
					// To overcome such probleme, remember that in PostgreSQL you can use:
					// CREATE OR REPLACE PROCEDURE "some_procedure"
					// PostgreSQL supports Stored Procedures.
#endif
				default: {
					throw new Exception(
						string.Format(
							"{0}.{1}.sqlstoredprocedure_delete(): - not implemented!", 
							typeof(cDBConnection).Namespace, 
							typeof(cDBConnection).Name
						)
					);
				}
			}
		}
		/// <summary>
		/// Deletes a specific SQL Stored Procedure on DataBase, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Stored Procedure Name</param>
		/// <returns>True if SQL Stored Procedure existed and was deleted, False if not</returns>
		public bool SQLStoredProcedure_delete(string name_in) {
			if (SQLStoredProcedure_exists(name_in)) {
				Execute_SQLQuery(sqlstoredprocedure_delete(name_in));
				return true;
			} else {
				return false;
			}
		}
		#endregion
		#region public bool SQLView_exists(...);
		private string sqlview_exists(string name_in) {
			return sqlview_exists(name_in, dbservertype_);
		}
		private /*static*/ string sqlview_exists(string name_in, eDBServerTypes dbServerType_in) {
			switch (dbServerType_in) {
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
#endif
				case eDBServerTypes.SQLServer:
					return string.Format(
						#region "SELECT ...", 
						@"
SELECT null
FROM INFORMATION_SCHEMA.TABLES
WHERE
	(TABLE_TYPE = 'VIEW')
	AND
	(TABLE_NAME = '{0}')
", 
						#endregion
						name_in
					);
#if MySQL
				case eDBServerTypes.MySQL:
					string _database = Connectionstring_database();
					return string.Format(
						#region "SELECT ...", 
@"
SELECT null
FROM INFORMATION_SCHEMA.TABLES
WHERE
	(TABLE_TYPE = 'VIEW')
	AND
	(TABLE_NAME = '{0}')
	AND
	(TABLE_SCHEMA = '{1}')
", 
						#endregion
						name_in, 
						_database
					);
#endif
				default:
					throw new Exception(string.Format(
						"{0}.{1}.sqlview_exists(): - not implemented!",
						typeof(cDBConnection).Namespace,
						typeof(cDBConnection).Name
					));
			}
		}
		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to determine if an SQL View exists on DataBase, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL View Name</param>
		/// <returns>True if SQL View exists, False if not</returns>
		public bool SQLView_exists(string name_in) {
			return (Execute_SQLQuery_returnDataTable(
				sqlview_exists(name_in)
			).Rows.Count == 1);
		}
		#endregion
		#region public bool SQLView_delete(...);
		private string sqlview_delete(string name_in) {
			return sqlview_delete(name_in, dbservertype_);
		}
		private static string sqlview_delete(string name_in, eDBServerTypes dbServerType_in) {
			switch (dbServerType_in) {
				case eDBServerTypes.SQLServer:
					return string.Format(
						"DROP VIEW {0}",
						name_in
					);
#if MySQL
				case eDBServerTypes.MySQL:
					return string.Format(
						"DROP VIEW `{0}`",
						name_in
					);
#endif
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
					// ToDos: here! not implemented, needed if droping, 
					// no need when replacing, you can use:
					// CREATE OR REPLACE VIEW "some_view"
#endif
				default: {
					throw new Exception(
						string.Format(
							"{0}.{1}.sqlview_delete(): - not implemented!", 
							typeof(cDBConnection).Namespace, 
							typeof(cDBConnection).Name
						)
					);
				}
			}
		}
		/// <summary>
		/// Deletes a specific SQL View on DataBase, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL View Name</param>
		/// <returns>True if SQL View existed and was deleted, False if not</returns>
		public bool SQLView_delete(string name_in) {
			if (SQLView_exists(name_in)) {
				Execute_SQLQuery(sqlview_delete(name_in));
				return true;
			} else {
				return false;
			}
		}
		#endregion
		//---
		#region public string[] getBDs(...);
		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to get a list of available DataBase names.
		/// </summary>
		/// <returns>String array, representing a list of available DataBase names</returns>
		public string[] getBDs() {
			string[] getBDs_out;

			string _query;
			switch (dbservertype_) {
#if PostgreSQL
				case eDBServerTypes.PostgreSQL:
#endif
				case eDBServerTypes.SQLServer:
					_query = @"
SELECT CATALOG_NAME 
FROM INFORMATION_SCHEMA.SCHEMATA 
WHERE
	(CATALOG_NAME != 'master') 
	AND
	(CATALOG_NAME != 'tempdb') 
	AND 
	(CATALOG_NAME != 'model') 
	AND 
	(CATALOG_NAME != 'msdb') 
	AND 
	(CATALOG_NAME != 'pubs') 
GROUP BY CATALOG_NAME 
ORDER BY CATALOG_NAME"
					;
					break;
#if MySQL
				case eDBServerTypes.MySQL:
					_query = @"
SELECT SCHEMA_NAME 
FROM INFORMATION_SCHEMA.SCHEMATA 
WHERE 
	(SCHEMA_NAME != 'information_schema') 
	AND 
	(SCHEMA_NAME != 'mysql') 
ORDER BY SCHEMA_NAME"
					;
					break;
#endif
				default: {
					throw new Exception(
						string.Format(
							"{0}.{1}.getTables: - not implemented", 
							this.GetType().Namespace, 
							this.GetType().Name
						)
					);
				}
			}

			DataTable _datatable = Execute_SQLQuery_returnDataTable(_query);

			getBDs_out = new string[_datatable.Rows.Count];
			for (int i = 0; i < _datatable.Rows.Count; i++)
				getBDs_out[i] = (string)_datatable.Rows[i][0];

			_datatable.Dispose(); _datatable = null;		

			return getBDs_out;
		}
		#endregion
		#region public cDBTable[] getTables(...);
		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to get a list of Table names for the current DataBase Connection.
		/// </summary>
		/// <returns>String array, representing a list of Table names</returns>
		public cDBTable[] getTables(
		) {
			return getTables(
				string.Empty,
				string.Empty
			);
		}

		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to get a list of Table names for the current DataBase Connection.
		/// </summary>
		/// <param name="subAppName_in">Table Filter. If your Application is to be hosted at some ASP, which provides you with one DataBase only, and you're using that DataBase for more than one Application. I assume you're using some convention for Table naming like: AP1_Table1, AP1_Table2, AP2_Table1, ... . Or even if you have several modules sharing same data base. If so, you can use this parameter to filter Table names for some specific Application, like: AP1 or AP2</param>
		/// <returns>String array, representing a list of Table names</returns>
		public cDBTable[] getTables(
			string subAppName_in
		) {
			return getTables(
				subAppName_in, 
				string.Empty
			);
		}

		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to get a list of Table names for the current DataBase Connection.
		/// </summary>
		/// <param name="subAppName_in">Table Filter. If your Application is to be hosted at some ASP, which provides you with one DataBase only, and you're using that DataBase for more than one Application. I assume you're using some convention for Table naming like: AP1_Table1, AP1_Table2, AP2_Table1, ... . Or even if you have several modules sharing same data base. If so, you can use this parameter to filter Table names for some specific Application, like: AP1 or AP2</param>
		/// <returns>String array, representing a list of Table names</returns>
		public cDBTable[] getTables(
			string subAppName_in, 
			string sqlFuncion_in
		) {
			cDBTable[] getTables_out;

			#region DataTable _dtemp = ...;
			DataTable _dtemp;
			if (
				(sqlFuncion_in == null)
				||
				(sqlFuncion_in == string.Empty)
			) {
				StringBuilder _query = new StringBuilder(string.Empty);
				switch (dbservertype_) {
#if PostgreSQL
					case eDBServerTypes.PostgreSQL:
#endif
					case eDBServerTypes.SQLServer:
						#region query.Append("SELECT ...");
						_query.Append(@"
SELECT
	TABLE_NAME AS ""Name"",
	CASE
		WHEN (TABLE_TYPE = 'VIEW') THEN
			CAST(1 AS Int)
		ELSE
			CAST(0 AS Int)
	END AS ""isVT""
FROM INFORMATION_SCHEMA.TABLES
WHERE
	(
		(TABLE_TYPE = 'BASE TABLE')
		OR
		(TABLE_TYPE = 'VIEW')
	)
	AND
	(
		(TABLE_TYPE != 'VIEW')
		OR
		(
			(TABLE_TYPE = 'VIEW')
			AND
			(TABLE_NAME NOT LIKE 'v0_%')
		)
	)
	AND
	(TABLE_NAME != 'dtproperties')
	AND
	(TABLE_NAME NOT LIKE 'sql_%')
	AND
	(TABLE_NAME NOT LIKE 'pg_%')
	AND
	(TABLE_NAME NOT LIKE 'sys%')
	AND
	(TABLE_NAME NOT LIKE '%__base')
	AND
	(TABLE_SCHEMA NOT LIKE 'information_schema')
");
						if (subAppName_in != "") {
							_query.Append("AND (");
							string[] _subAppNames = subAppName_in.Split('|');
							for (int i = 0; i < _subAppNames.Length; i++) {
								_query.Append(string.Format(
									"(TABLE_NAME {0} '{1}'){2}",
									(_subAppNames[i].IndexOf('%') >= 0) ? "LIKE" : "=", 
									_subAppNames[i],
									(i == _subAppNames.Length - 1) ? "" : " OR "
								));
							}
							_query.Append(") ");
						}
						_query.Append(@"ORDER BY ""Name"" ");
						#endregion
						break;
#if MySQL
					case eDBServerTypes.MySQL:
						string _database = Connectionstring_database();
						#region _query.Append("SELECT ...");
						_query.Append(string.Format(@"
SELECT
	TABLE_NAME AS ""Name"",
	CASE
		WHEN (TABLE_TYPE = 'VIEW') THEN
			CAST(1 AS Signed Int)
		ELSE
			CAST(0 AS Signed Int)
	END AS ""isVT""
FROM INFORMATION_SCHEMA.TABLES
WHERE
	(
		(TABLE_TYPE = 'BASE TABLE')
		OR
		(TABLE_TYPE = 'VIEW')
	)
	AND
	(TABLE_SCHEMA = '{0}')
", 
							_database
						));
						if (subAppName_in != "" ) {
							_query.Append("AND (");
							string[] _subAppNames = subAppName_in.Split('|');
							for (int i = 0; i < _subAppNames.Length; i++) {
								_query.Append(string.Format(
									"(TABLE_NAME {0} '{1}'){2}",
									(_subAppNames[i].IndexOf('%') >= 0) ? "LIKE" : "=",
									_subAppNames[i],
									(i == _subAppNames.Length - 1) ? "" : " OR "
								));
							}
							_query.Append(") ");
						}
						_query.Append(@"ORDER BY ""Name"" ");
						#endregion
						break;
#endif
					default:
						throw new Exception("not implemented");
				}
				_dtemp = Execute_SQLQuery_returnDataTable(_query.ToString());
			} else {
				_dtemp = Execute_SQLFunction_returnDataTable(
					sqlFuncion_in,
					new IDbDataParameter[] {
						newDBDataParameter("subApp_", DbType.String, ParameterDirection.Input, subAppName_in, subAppName_in.Length)
					}
				);
			}
			#endregion
			getTables_out = new cDBTable[_dtemp.Rows.Count];
			for (int r = 0; r < _dtemp.Rows.Count; r++)
				getTables_out[r] = new cDBTable(
					(string)_dtemp.Rows[r]["Name"],
#if MySQL
					(dbservertype_ == eDBServerTypes.MySQL) ? 
						((long)_dtemp.Rows[r]["isVT"] == 1L) : 
#endif
						((int)_dtemp.Rows[r]["isVT"] == 1)
					, 
// ToDos: here!
string.Empty
				);
			_dtemp.Dispose(); _dtemp = null;

			return getTables_out;
		}
		#endregion
		#region public cDBTableField[] getTableFields(...);
		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to get a list of Field names for some specific Table.
		/// </summary>
		/// <param name="tableName_in">Table name for which Field names are to be retrieved</param>
		/// <returns>String array, representing a list of Field names</returns>
		public cDBTableField[] getTableFields(
			string tableName_in
		) {
			return getTableFields(
				tableName_in,
				string.Empty
			);
		}

		/// <summary>
		/// Makes use of the DataBase INFORMATION_SCHEMA to get a list of Field names for some specific Table.
		/// </summary>
		/// <param name="tableName_in">Table name for which Field names are to be retrieved</param>
		/// <returns>String array, representing a list of Field names</returns>
		public cDBTableField[] getTableFields(
			string tableName_in,
			string sqlFuncion_in
		) {
			cDBTableField[] getTableFields_out;

			#region DataTable _dtemp = ...;
			DataTable _dtemp;
			if (
				(sqlFuncion_in == null)
				||
				(sqlFuncion_in == string.Empty)
			) {
				string _query;
				switch (dbservertype_) {
					case eDBServerTypes.SQLServer:
						#region _query = "SELECT ...";
						_query = string.Format(@"
SELECT
	t1.COLUMN_NAME AS ""Name"", 
	CASE
		WHEN t1.IS_NULLABLE = 'No' THEN
			CAST(0 AS Int)
		ELSE
			CAST(1 AS Int)
	END AS ""isNullable"", 
	t1.DATA_TYPE AS ""Type"", 
	t1.CHARACTER_MAXIMUM_LENGTH AS ""Size"", 
	CASE
		WHEN (t6.TABLE_TYPE = 'VIEW') THEN
			CASE
				WHEN (
					(SUBSTRING(t1.COLUMN_NAME, 3, 1) = ',') AND 
					(SUBSTRING(t1.COLUMN_NAME, 2, 1) = 'K')
				) THEN
					CAST(1 AS Int)
				ELSE
					CAST(0 AS Int)
			END
		WHEN t2.CONSTRAINT_NAME IS NULL THEN
			CAST(0 AS Int)
		ELSE
			CAST(1 AS Int)
	END AS ""isPK"", 
	CASE
		WHEN (t6.TABLE_TYPE != 'VIEW') THEN
			CAST(COLUMNPROPERTY(OBJECT_ID(t1.TABLE_NAME), t1.COLUMN_NAME, 'IsIdentity') AS Int)
		ELSE
			CASE
				WHEN (
					(SUBSTRING(t1.COLUMN_NAME, 3, 1) = ',') AND 
					(SUBSTRING(t1.COLUMN_NAME, 1, 1) = 'I')
				) THEN
					CAST(1 AS Int)
				ELSE
					CAST(0 AS Int)
			END
			--COLUMNPROPERTY(OBJECT_ID(t5.TABLE_NAME), t5.COLUMN_NAME, 'IsIdentity')
	END AS ""isIdentity"", 
	CASE
		WHEN (t6.TABLE_TYPE != 'VIEW') THEN
			t8.TABLE_NAME
		ELSE
			/*
			CASE
				WHEN (SUBSTRING(t1.COLUMN_NAME, 3, 1) = ',') THEN
					SUBSTRING(
						t1.COLUMN_NAME,
						dbo.fnc__FIND(
							',', 
							t1.COLUMN_NAME, 
							1
						) + 1,
						dbo.fnc__FIND(
							',', 
							t1.COLUMN_NAME, 
							dbo.fnc__FIND(
								',', 
								t1.COLUMN_NAME, 
								1
							) + 1
						)
						- dbo.fnc__FIND(
							',', 
							t1.COLUMN_NAME, 
							1
						)
						- 1
					)
				ELSE
					NULL
			END
			*/
			NULL
			--t5.TABLE_NAME
	END AS ""FK_TableName"", 
	CASE
		WHEN (t6.TABLE_TYPE != 'VIEW') THEN
			t8.COLUMN_NAME
		ELSE
			/*
			CASE
				WHEN (SUBSTRING(t1.COLUMN_NAME, 3, 1) = ',') THEN
					SUBSTRING(
						t1.COLUMN_NAME,
						dbo.fnc__FIND(
							',', 
							t1.COLUMN_NAME, 
							dbo.fnc__FIND(
								',', 
								t1.COLUMN_NAME, 
								1
							) + 1
						) + 1,
						LEN(t1.COLUMN_NAME)
					)
				ELSE
					NULL
			END
			*/
			NULL
			--t5.COLUMN_NAME
	END AS ""FK_FieldName"", 
	t1.COLUMN_DEFAULT, 
	t1.COLLATION_NAME, 
	t1.NUMERIC_PRECISION, 
	t1.NUMERIC_SCALE
FROM INFORMATION_SCHEMA.COLUMNS AS t1
	LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE t2 ON
		(t2.COLUMN_NAME = t1.COLUMN_NAME)
		AND
		(t2.TABLE_NAME = t1.TABLE_NAME)
		AND
		(
			--(t2.CONSTRAINT_NAME LIKE 'PK%')

			(t2.CONSTRAINT_NAME = 'PK_' + t2.TABLE_NAME) -- the microsoft sql server way
			OR
			(t2.CONSTRAINT_NAME = t2.TABLE_NAME + '_PK') -- the microsoft visio way
		)
	--LEFT JOIN INFORMATION_SCHEMA.Referential_Constraints t3 ON
	--	(t3.UNIQUE_CONSTRAINT_NAME = t2.CONSTRAINT_NAME)
	LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE t4 ON
		(t4.COLUMN_NAME = t1.COLUMN_NAME)
		AND
		(t4.TABLE_NAME = t1.TABLE_NAME)
		AND
		(
			(t4.CONSTRAINT_NAME LIKE '%_FK%')
			OR
			(t4.CONSTRAINT_NAME LIKE '%FK_%')
		)
	--LEFT JOIN INFORMATION_SCHEMA.View_Column_Usage t5 ON
	--	(t5.VIEW_NAME = t1.TABLE_NAME)
	--	AND
	--	(t5.COLUMN_NAME = t1.COLUMN_NAME)
	LEFT JOIN INFORMATION_SCHEMA.TABLES t6 ON
		(t6.TABLE_NAME = t1.TABLE_NAME)
	LEFT JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS t7 ON
		(t4.CONSTRAINT_NAME = t7.CONSTRAINT_NAME)
	LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE t8 ON
		(t7.UNIQUE_CONSTRAINT_NAME = t8.CONSTRAINT_NAME)
--WHERE (t1.TABLE_NAME LIKE 'vUserGroup%') --OR (t1.TABLE_NAME = 'UserGroup') OR (t1.TABLE_NAME = 'User') OR (t1.TABLE_NAME = 'Group')
--WHERE (t1.TABLE_NAME != 'dtproperties') AND (t1.TABLE_NAME NOT LIKE 'sql_%') AND (t1.TABLE_NAME NOT LIKE 'pg_%') AND (t1.TABLE_NAME NOT LIKE 'sys%')
WHERE (t1.TABLE_NAME = '{0}') 
ORDER BY t1.TABLE_NAME, t1.ORDINAL_POSITION", 
							tableName_in
						);
						#endregion
						break;
#if PostgreSQL
					case eDBServerTypes.PostgreSQL:
						#region _query = "SELECT ...";
						_query = string.Format(@"
SELECT
	t1.COLUMN_NAME AS ""Name"", 
	CASE
		WHEN t1.IS_NULLABLE = 'NO' THEN
			CAST(0 AS Int)
		ELSE
			CAST(1 AS Int)
	END
	AS ""isNullable"", 
	t1.DATA_TYPE AS ""Type"", 
	t1.CHARACTER_MAXIMUM_LENGTH AS ""Size"", 
	CASE
		WHEN (t6.TABLE_TYPE = 'VIEW') THEN
			CAST(0 AS Int)
		WHEN t7.column_name IS NULL THEN
			CASE
				WHEN (t6.TABLE_TYPE != 'VIEW') THEN
					CASE
						WHEN (column_default LIKE 'nextval(''%') THEN
							CAST(1 AS Int)
						ELSE
							CAST(0 AS Int)
					END
				ELSE
					CAST(0 AS Int)
			END
		ELSE
			CAST(1 AS Int)
	END AS ""isPK"", 
	CASE
		WHEN (t6.TABLE_TYPE != 'VIEW') THEN
			CASE
				WHEN (column_default LIKE 'nextval(''%') THEN
					CAST(1 AS Int)
				ELSE
					CAST(0 AS Int)
			END
		ELSE
			CAST(0 AS Int)
	END AS ""isIdentity"", 
--	CASE
--		WHEN (t6.TABLE_TYPE != 'VIEW') THEN
----			CASE
----				WHEN t4.CONSTRAINT_NAME IS NULL THEN
--					NULL
----				ELSE
----					t4.table_name
----			END
--		ELSE
			NULL
--	END
	AS ""FK_TableName"", 
--	CASE
--		WHEN (t6.TABLE_TYPE != 'VIEW') THEN
----			CASE
----				WHEN t4.CONSTRAINT_NAME IS NULL THEN
--					NULL
----				ELSE
----					t4.column_name
----			END
--		ELSE
			NULL
--	END
	AS ""FK_FieldName"", 
	t1.COLUMN_DEFAULT, 
	t1.COLLATION_NAME, 
	CAST(0 AS Int) as ""NUMERIC_PRECISION"", 
	CAST(0 AS Int) as ""NUMERIC_SCALE""
FROM INFORMATION_SCHEMA.COLUMNS AS t1
	LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE t7 ON (
		(t7.column_name = t1.COLUMN_NAME)
		AND
		(t7.constraint_name = t1.table_name || '_pkey')
	)
--	LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE t4 ON (
--		(t4.CONSTRAINT_NAME = t1.TABLE_NAME || '_' || t1.COLUMN_NAME || '_fkey')
--		OR
--		(t4.CONSTRAINT_NAME = t1.TABLE_NAME || '__base_' || t1.COLUMN_NAME || '_fkey')
--	)
	--LEFT JOIN INFORMATION_SCHEMA.View_Column_Usage t5 ON
	--	(t5.VIEW_NAME = t1.TABLE_NAME)
	--	AND
	--	(t5.COLUMN_NAME = t1.COLUMN_NAME)
	LEFT JOIN INFORMATION_SCHEMA.TABLES t6 ON
		(t6.TABLE_NAME = t1.TABLE_NAME)
WHERE (t1.TABLE_NAME = '{0}') 
ORDER BY t1.TABLE_NAME, t1.ORDINAL_POSITION
", 
							tableName_in
						);
						#endregion
						break;
#endif
#if MySQL
					case eDBServerTypes.MySQL:
						string _database = Connectionstring_database();
						#region _query = "SELECT ...";
						_query = string.Format(@"
SELECT
	t1.COLUMN_NAME AS ""Name"", 
--	CASE
--		WHEN t1.IS_NULLABLE = 'NO' THEN
			CAST(0 AS Signed Int)
--		ELSE
--			CAST(1 AS Signed Int)
--	END
	AS ""isNullable"", 
	t1.DATA_TYPE AS ""Type"", 
	t1.CHARACTER_MAXIMUM_LENGTH AS ""Size"", 
	CASE
		WHEN ((t6.TABLE_TYPE != 'VIEW') AND (t1.COLUMN_KEY = 'PRI')) THEN
			CAST(1 AS Signed Int)
		ELSE
			CAST(0 AS Signed Int)
	END AS ""isPK"", 
	CASE
		WHEN ((t6.TABLE_TYPE != 'VIEW') AND (t1.EXTRA = 'auto_increment')) THEN
			CAST(1 AS Signed Int)
		ELSE
			CAST(0 AS Signed Int)
	END AS ""isIdentity"", 
	NULL AS ""FK_TableName"", 
	NULL AS ""FK_FieldName"", 
	t1.COLUMN_DEFAULT, 
	t1.COLLATION_NAME, 
	CAST(0 AS unsigned) as ""NUMERIC_PRECISION"", 
	CAST(0 AS unsigned) as ""NUMERIC_SCALE""
FROM INFORMATION_SCHEMA.COLUMNS AS t1
	LEFT JOIN INFORMATION_SCHEMA.TABLES t6 ON ((t6.TABLE_SCHEMA = t1.TABLE_SCHEMA) AND (t6.TABLE_NAME = t1.TABLE_NAME))
WHERE 
	(t1.TABLE_NAME = '{0}') 
	AND
	(t1.TABLE_SCHEMA = '{1}')
ORDER BY t1.TABLE_NAME, t1.ORDINAL_POSITION
", 
							tableName_in, 
							_database
						);
						#endregion
						break;
#endif
					default:
						throw new Exception(string.Format(
							"{0}.{1}.getTableFields: - not implemented", 
							this.GetType().Namespace, 
							this.GetType().Name
						));
				}
				_dtemp = Execute_SQLQuery_returnDataTable(_query);
			} else {
				_dtemp = Execute_SQLFunction_returnDataTable(
					sqlFuncion_in,
					new IDbDataParameter[] {
						newDBDataParameter("tableName_", DbType.String, ParameterDirection.Input, tableName_in, tableName_in.Length)
					}
				);
			}
			#endregion
			getTableFields_out = new cDBTableField[_dtemp.Rows.Count];
			for (int r = 0; r < _dtemp.Rows.Count; r++) {
				getTableFields_out[r] = new cDBTableField();

				getTableFields_out[r].Name				= (string)_dtemp.Rows[r]["Name"];
				switch (dbservertype_) {
#if MySQL
					case eDBServerTypes.MySQL:
						getTableFields_out[r].Size = (_dtemp.Rows[r]["Size"] == DBNull.Value) ? 0 : (int)(long)_dtemp.Rows[r]["Size"];
						getTableFields_out[r].isNullable = ((long)_dtemp.Rows[r]["isNullable"] == 1L);
						//---						
						getTableFields_out[r].FK_TableName = (_dtemp.Rows[r]["FK_FieldName"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["FK_TableName"];
						getTableFields_out[r].FK_FieldName = (_dtemp.Rows[r]["FK_FieldName"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["FK_FieldName"];
						//---
						getTableFields_out[r].isIdentity = ((long)_dtemp.Rows[r]["isIdentity"] == 1L);
						getTableFields_out[r].isPK = ((long)_dtemp.Rows[r]["isPK"] == 1L);
						//---
						getTableFields_out[r].Numeric_Precision = (_dtemp.Rows[r]["Numeric_Precision"] == DBNull.Value) ? 0 : (int)(long)_dtemp.Rows[r]["Numeric_Precision"];
						getTableFields_out[r].Numeric_Scale = (_dtemp.Rows[r]["Numeric_Scale"] == DBNull.Value) ? 0 : (int)(long)_dtemp.Rows[r]["Numeric_Scale"];
						break;
#endif
#if PostgreSQL
					case eDBServerTypes.PostgreSQL:
						getTableFields_out[r].Size = (_dtemp.Rows[r]["Size"] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r]["Size"];
						getTableFields_out[r].isNullable = ((int)_dtemp.Rows[r]["isNullable"] == 1);
						//---						
						getTableFields_out[r].FK_TableName = (_dtemp.Rows[r]["FK_FieldName"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["FK_TableName"];
						getTableFields_out[r].FK_FieldName = (_dtemp.Rows[r]["FK_FieldName"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["FK_FieldName"];
						//---
						getTableFields_out[r].isIdentity = ((int)_dtemp.Rows[r]["isIdentity"] == 1);
						getTableFields_out[r].isPK = ((int)_dtemp.Rows[r]["isPK"] == 1);
						//---
						getTableFields_out[r].Numeric_Precision = (_dtemp.Rows[r]["Numeric_Precision"] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r]["Numeric_Precision"];
						getTableFields_out[r].Numeric_Scale = (_dtemp.Rows[r]["Numeric_Scale"] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r]["Numeric_Scale"];
						break;
#endif
					case eDBServerTypes.SQLServer: {
						getTableFields_out[r].Size = (_dtemp.Rows[r]["Size"] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r]["Size"];
						getTableFields_out[r].isNullable = ((int)_dtemp.Rows[r]["isNullable"] == 1);
						//---						
						getTableFields_out[r].FK_TableName = (_dtemp.Rows[r]["FK_FieldName"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["FK_TableName"];
						getTableFields_out[r].FK_FieldName = (_dtemp.Rows[r]["FK_FieldName"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["FK_FieldName"];
						//---
						getTableFields_out[r].isIdentity = ((int)_dtemp.Rows[r]["isIdentity"] == 1);
						getTableFields_out[r].isPK = ((int)_dtemp.Rows[r]["isPK"] == 1);
						//---
						getTableFields_out[r].Numeric_Precision = (_dtemp.Rows[r]["Numeric_Precision"] == DBNull.Value) ? 0 : (int)(byte)_dtemp.Rows[r]["Numeric_Precision"];
						getTableFields_out[r].Numeric_Scale = (_dtemp.Rows[r]["Numeric_Scale"] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r]["Numeric_Scale"];
						break;
					}
					default: {
						throw new Exception(
							string.Format(
								"{0}.{1}.getTables: - not implemented", 
								this.GetType().Namespace, 
								this.GetType().Name
							)
						);
					}
				}
				//---
				#region //getTableFields_out[r].DBType_inDB_name = ...;
				//switch (dbservertype_) {
				//	case eDBServerTypes.SQLServer:
				//		getTableFields_out[r].DBType_inDB = (int)sConvert.SqlDbType_Parse((string)_dtemp.Rows[r]["Type"], false);
				//		break;
				//	case eDBServerTypes.PostgreSQL:
				//		getTableFields_out[r].DBType_inDB = (int)sConvert.PgsqlDbType_Parse((string)_dtemp.Rows[r]["Type"]);
				//		break;
				//}
				#endregion
				getTableFields_out[r].DBType_inDB_name = (string)_dtemp.Rows[r]["Type"];
				getTableFields_out[r].DBDefaultValue = (_dtemp.Rows[r]["COLUMN_DEFAULT"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["COLUMN_DEFAULT"];
				getTableFields_out[r].DBCollationName = (_dtemp.Rows[r]["COLLATION_NAME"] == DBNull.Value) ? "" : (string)_dtemp.Rows[r]["COLLATION_NAME"];
// ToDos: here!
getTableFields_out[r].DBDescription = string.Empty;
			}
			_dtemp.Dispose(); _dtemp = null;

			return getTableFields_out;
		}
		#endregion
//		#endregion
	}
}
