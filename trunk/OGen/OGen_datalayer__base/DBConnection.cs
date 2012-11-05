#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DataLayer {
	using System;
	using System.Data;
	using System.IO;
	using System.Text;

	#region /// <summary>...</summary>
	/// <summary>
	///	Provides access to supported Databases like PostgreSQL and SQL Server, allowing the execution of SQL Queries and Functions retrieving their existing data if any. It also supports Transactions.
	/// </summary>
	/// <threadsafety static="true" instance="false"/>
	/// <remarks>
	/// There is no need to Open a Connection in order to execute an SQL Query or Function. Open and Close methods are usually used when working with the Transaction.
	/// <see cref="DBConnection">DBConnection</see> instances should not be shared among multiple threads (it doesn't have any connection pooling mechanism, and no plans on having one), it is not thread safe.
	/// </remarks>
	/// <example>
	/// This sample shows how to execute an SQL Query and populate a DataTable with it's return Output
	/// <code>
	/// DBConnection _connection = new DBConnection(
	///		DBServerTypes.PostgreSQL, 
	///		OGen.Libraries.DataLayer.Utilities.Connectionstring.Buildwith.Parameters(
	///			"127.0.0.1", 
	///			"postgres", 
	///			"password", 
	///			"TestDB", 
	///			DBServerTypes.PostgreSQL
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
	/// DBConnection _connection = new DBConnection(
	///		DBServerTypes.PostgreSQL, 
	///		OGen.Libraries.DataLayer.Utilities.Connectionstring.Buildwith.Parameters(
	///			"127.0.0.1", 
	///			"postgres", 
	///			"password", 
	///			"TestDB", 
	///			DBServerTypes.PostgreSQL
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
	public abstract class DBConnection : IDisposable {

		#region public DBConnection(...);
		/// <summary>
		/// Initializes a new instance of <see cref="DBConnection">DBConnection</see>
		/// </summary>
		/// <param name="connectionstring_in">Connection String</param>
		protected DBConnection(
			string connectionstring_in
		) : this (
			connectionstring_in,
			string.Empty
		) {
		}

		/// <summary>
		/// Initializes a new instance of <see cref="DBConnection">DBConnection</see>
		/// </summary>
		/// <param name="connectionstring_in">Connection String</param>
		/// <param name="logfile_in">Log File (null or empty string disables log)</param>
		protected DBConnection(
			string connectionstring_in, 
			string logfile_in
		) {
			if (string.IsNullOrEmpty(connectionstring_in))
				throw new InvalidConnectionstringException_empty();

			this.connectionstring_ = connectionstring_in;

			this.logfile_ = (logfile_in != null)
				? logfile_in
				: string.Empty;
			this.logenabled_ = 
				!string.IsNullOrEmpty(logfile_in)

				//// prefer to let exception be raised and let user know 
				//// he has to revise his config file, hence comment:
				//&& File.Exists(logfile_in)
			;
			this.isopen_ = false;
		}

		~DBConnection() {
			this.Dispose(false);
		}

		#region public void Dispose(...);

		/// <summary>
		/// Releases all resources used by <see cref="DBConnection">DBConnection</see>.
		/// </summary>
		/// <param name="disposing_in"></param>
		private void Dispose(bool disposing_in) {
			if (this.transaction__ != null) {
				this.transaction__.Dispose(); this.transaction__ = null;
			}

			if (this.isopen_) this.Close();
			if (this.connection__ != null) {
				this.connection__.Dispose(); this.connection__ = null;
			}
		}

		/// <summary>
		/// Releases all resources used by <see cref="DBConnection">DBConnection</see>.
		/// </summary>
		public void Dispose() {
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		#endregion
		#endregion

		#region public Properties...
		#region public string Connectionstring { get; }
		/// <summary>
		/// Connection String.
		/// </summary>
		protected string connectionstring_;

		/// <summary>
		/// Connection String.
		/// </summary>
		public string Connectionstring {
			get { return this.connectionstring_; }
		}
		#endregion
		#region public string Connectionstring_DBName { get; }
		private string connectionstring_dbname__ = string.Empty;
		private object connectionstring_dbname__locker = new object();

		public string Connectionstring_DBName {
			get {

				// check before lock
				if (string.IsNullOrEmpty(this.connectionstring_dbname__)) {

					lock (this.connectionstring_dbname__locker) {

						// double check, thread safer!
						if (string.IsNullOrEmpty(this.connectionstring_dbname__)) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.connectionstring_dbname__ = this.Utilities.ConnectionString.ParseParameter(
								this.Connectionstring,
								DBUtilities_connectionString.eParameter.DBName
							);
						}
					}
				}

				return this.connectionstring_dbname__;
			}
		}
		#endregion
		public abstract string DBServerType { get; }
		#region public string Logfile { get; }
		protected string logfile_;

		public string Logfile {
			get { return this.logfile_; }
		}
		#endregion
		#region public bool Logenabled { get; }
		protected bool logenabled_;

		public bool Logenabled {
			get { return this.logenabled_; }
		}
		#endregion
		#region public bool isOpen { get; }
		/// <summary>
		/// Indicates Database Connection state, True if oppened, False if closed.
		/// </summary>
		protected bool isopen_;

		/// <summary>
		/// Indicates Database Connection state, True if oppened, False if closed.
		/// </summary>
		public bool isOpen {
			get { return this.isopen_; }
		}
		#endregion
		#region public abstract IDbConnection exposeConnection { get; }
		/// <summary>
		/// Database Connection's access.
		/// <note type="caution">
		/// IMPORTANT! access should be made via exposeConnection instead
		/// </note>
		/// </summary>
		protected IDbConnection connection__ = null;

		/// <summary>
		/// Exposing real Database Connection as read only, should it be needed.
		/// </summary>
		public abstract IDbConnection exposeConnection { get; }
		#endregion
		#region public DBTransaction Transaction { get; }

		/// <summary>
		/// Database Connection's Transaction access.
		/// <note type="caution">
		/// IMPORTANT! access should be made via Transaction instead
		/// </note>
		/// </summary>
		protected DBTransaction transaction__;

		private object transaction__locker = new object();

		/// <summary>
		/// Database Connection's Transaction access.
		/// </summary>
		public DBTransaction Transaction {
			get {

				// check before lock
				if (this.transaction__ == null) {

					lock (this.transaction__locker) {

						// double check, thread safer!
						if (this.transaction__ == null) {

							// instantiating for the first time and
							// only because it became needed, otherwise
							// never instantiated...

							// initialization...
							// ...attribution (last thing before unlock)
							this.transaction__ = new DBTransaction(this);
						}
					}
				}

				return this.transaction__;
			}
		}
		#endregion
		public abstract DBUtilities Utilities { get; }
		#endregion

		#region public static Methods...
		#endregion
		#region private Methods...
		#region protected void Log(...);
		protected void Log(
			string type_in, 
			string value_in
		) {
			this.Log(type_in, value_in, null);
		}

		protected void Log(
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
							System.Globalization.CultureInfo.CurrentCulture,
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

			StreamWriter _writer = new StreamWriter(this.Logfile, true);
			_writer.WriteLine(string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"{0} - {1}: {2}{3}", 
				DateTime.Now.ToString(
					"yyyy-MM-dd HH:mm:ss",
					System.Globalization.CultureInfo.CurrentCulture
				), 
				type_in, 
				value_in, 
				_parameters.ToString()
			));
			_writer.Close();
			_writer.Dispose();
		}
		#endregion

		protected abstract IDbCommand newDBCommand(
			string command_in, 
			IDbConnection connection_in
		);
		protected abstract IDbDataAdapter newDBDataAdapter(
			string query_in, 
			IDbConnection connection_in, 
			bool isQuery_notProcedure_in
		);
		#endregion
		#region public Methods...
		#region public void Open();
		/// <summary>
		/// Opens Database Connection.
		/// </summary>
		/// <exception cref="OpenException_alreadyOpened">
		/// Thrown when the Connection is already opened
		/// </exception>
		/// <remarks>
		/// There is no need to Open a Connection in order to execute an SQL Query or Function. Open and Close methods are usually used when working with the Transaction
		/// </remarks>
		public void Open() {
			if (this.isopen_) {
				throw new OpenException_alreadyOpened();
			} else {
				this.exposeConnection.Open();

				this.isopen_ = true;
			}
		}
		#endregion
		#region public void Close();
		/// <summary>
		/// Closes Database Connection.
		/// </summary>
		/// <exception cref="CloseException_alreadyClosed">
		/// Thrown when the Connection is already closed
		/// </exception>
		/// <exception cref="CloseException_unterminatedTransaction">
		/// Thrown when the Connection has an unterminated Transaction initiated
		/// </exception>
		public void Close() {
			if (!this.isopen_) {
				throw new CloseException_alreadyClosed();
			} else if ((this.transaction__ != null) && this.transaction__.inTransaction) {
				throw new CloseException_unterminatedTransaction();
			} else {
				this.exposeConnection.Close();

				this.isopen_ = false;
			}
		}
		#endregion
		// ---
		#region public abstract IDbDataParameter newDBDataParameter(...);
		/// <summary>
		/// Instantiates a new IDbDataParameter for the Connection's taking in consideration the appropriate Database Server Type.
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
			return this.newDBDataParameter(
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
		/// Instantiates a new IDbDataParameter for the Connection's taking in consideration the appropriate Database Server Type.
		/// </summary>
		/// <param name="name_in">Parameter's Name</param>
		/// <param name="dbType_in">Parameter's DbType</param>
		/// <param name="parameterDirection_in">Parameter's Direction</param>
		/// <param name="value_in">Parameter's Value</param>
		/// <param name="size_in">Parameter's Size (the actual Database Parameter Size representation, if such exists for the Parameter)</param>
		/// <returns>new IDbDataParameter</returns>
		public IDbDataParameter newDBDataParameter(
			string name_in, 
			DbType dbType_in, 
			ParameterDirection parameterDirection_in, 
			object value_in, 
			int size_in
		) {
			return this.newDBDataParameter(
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
		/// Instantiates a new IDbDataParameter for the Connection's taking in consideration the appropriate Database Server Type.
		/// </summary>
		/// <param name="name_in">Parameter's Name</param>
		/// <param name="dbType_in">Parameter's DbType</param>
		/// <param name="parameterDirection_in">Parameter's Direction</param>
		/// <param name="value_in">Parameter's Value</param>
		/// <param name="size_in">Parameter's Size (the actual Database Parameter Size representation, if such exists for the Parameter)</param>
		/// <param name="precision_in">Parameter's Precision</param>
		/// <param name="scale_in">Parameter's Scale</param>
		/// <returns>new IDbDataParameter</returns>
		public abstract IDbDataParameter newDBDataParameter(
			string name_in, 
			DbType dbType_in, 
			ParameterDirection parameterDirection_in, 
			object value_in, 
			int size_in, 
			byte precision_in, 
			byte scale_in
		);
		#endregion
		// ---
		#region public void Execute_SQLQuery(...);
		#region private void Execute_SQLQuery(...);
		private void Execute_SQLQuery(string query_in, IDbCommand command_in) {
			if (this.Logenabled) {
				this.Log("sql query", query_in);
			}

			command_in.CommandType = CommandType.Text;
			try {
				command_in.ExecuteNonQuery();
			} catch (Exception _ex) {
				#region throw new Exception("...");
				throw new Exception(
					string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"--- query:\n{0}\n\n--- ConnectionString:\n{1}|{2}\n\n--- exception:\n{3}\n\n--- inner-exception:\n{4}\n",
						query_in,
						this.DBServerType,
						this.connectionstring_, 
						_ex.Message, 
						_ex.InnerException
					)
				);
				#endregion
			}
		}
		#endregion

		#region public void Execute_SQLQuery(string query_in);
		/// <summary>
		/// Executes an SQL Query on Database.
		/// </summary>
		/// <param name="query_in">SQL Query</param>
		/// <exception cref="InvalidSQLQueryException_empty">
		/// Thrown when an empty SQL Query has been supplied
		/// </exception>
		public void Execute_SQLQuery(string query_in) {
			#region Checking...
			if (string.IsNullOrEmpty(query_in))
				throw new InvalidSQLQueryException_empty();
			#endregion

			if (this.isopen_) {
				#region Using Opened Connection...
				IDbCommand _command = this.newDBCommand(
					query_in,
					this.exposeConnection
				);
				this.Execute_SQLQuery(query_in, _command);
				_command.Dispose(); _command = null;
				#endregion
			} else {
				#region Opening, Using and Closing Connection...
				this.exposeConnection.Open();

				IDbCommand _command = this.newDBCommand(
					query_in,
					this.exposeConnection
				);
				this.Execute_SQLQuery(query_in, _command);
				_command.Dispose(); _command = null;

				this.exposeConnection.Close();
				#endregion
			}
		}
		#endregion
		#endregion
		#region public DataSet Execute_SQLQuery_returnDataSet(...);
		#region private DataSet Execute_SQLQuery_returnDataSet(...);
		private DataSet Execute_SQLQuery_returnDataSet(string query_in, IDbConnection connection_in) {
			DataSet _output;

			if (this.Logenabled) {
				this.Log("sql query", query_in);
			}

			IDbDataAdapter _dataadapter = this.newDBDataAdapter(
				query_in, 
				connection_in, 
				true
			);
			try {
				_output = new DataSet();
				_dataadapter.Fill(_output);
			} catch (Exception _ex) {
				#region throw new Exception("...");
				throw new Exception(
					string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"query: {0}\nConnectionString: {1}|{2}\nexception: {3}\ninner-exception: {4}\n",
						query_in,
						this.DBServerType,
						this.connectionstring_,
						_ex.Message,
						_ex.InnerException
					)
				);
				#endregion
			}
			//_dataadapter.Dispose(); // not implemented in IDbDataAdapter
			_dataadapter = null;

			return _output;
		}
		#endregion

		#region public DataSet Execute_SQLQuery_returnDataSet(string query_in);
		/// <summary>
		/// Executes an SQL Query on Database.
		/// </summary>
		/// <exception cref="InvalidSQLQueryException_empty">
		/// Thrown when an empty SQL Query has been supplied
		/// </exception>
		/// <param name="query_in">SQL Query</param>
		/// <returns>populated DataSet with SQL Query's Output</returns>
		public DataSet Execute_SQLQuery_returnDataSet(string query_in) {
			DataSet _output;

			#region Checking...
			if (string.IsNullOrEmpty(query_in))
				throw new InvalidSQLQueryException_empty();
			#endregion

			if (this.isopen_) {
				#region Using Opened Connection...
				_output
					= this.Execute_SQLQuery_returnDataSet(
						query_in,
						this.exposeConnection
					);
				#endregion
			} else {
				#region Opening, Using and Closing Connection...
				this.exposeConnection.Open();

				_output
					= this.Execute_SQLQuery_returnDataSet(
						query_in,
						this.exposeConnection
					);

				this.exposeConnection.Close();
				#endregion
			}

			return _output;
		}
		#endregion
		#endregion
		#region public DataTable Execute_SQLQuery_returnDataTable(...);
		/// <summary>
		/// Executes an SQL Query on Database.
		/// </summary>
		/// <param name="query_in">SQL Query</param>
		/// <returns>populated DataTable with SQL Query's Output</returns>
		public DataTable Execute_SQLQuery_returnDataTable(string query_in) {
			DataTable _output;

			#region Execute_SQLQuery_returnDataTable_out = Execute_SQLQuery_returnDataSet(query_in).Tables[0];
			DataSet _dataset = this.Execute_SQLQuery_returnDataSet(query_in);
			_output = _dataset.Tables[0];
			_dataset.Dispose(); _dataset = null;
			#endregion

			return _output;
		}
		#endregion
		// ---
		#region public object Execute_SQLFunction(...);
		#region protected abstract object Execute_SQLFunction(...);
		protected abstract object Execute_SQLFunction(
			string function_in,
			IDbDataParameter[] dataParameters_in,
			IDbCommand command_in,
			DbType returnValue_DbType_in,
			int returnValue_Size_in
		);
		#endregion
		#region public object Execute_SQLFunction(string function_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(string function_in) {
			return this.Execute_SQLFunction(
				function_in, 
				new IDbDataParameter[] { }, 
				DbType.Boolean, 
				-1
			);
		}
		#endregion
		#region public object Execute_SQLFunction(string function_in, DbType returnValue_DbType_in, int returnValue_Size_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="returnValue_DbType_in">DbType for return value</param>
		/// <param name="returnValue_Size_in">Size for return value (the actual Database return value Size representation, if such exists)</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(
			string function_in, 
			DbType returnValue_DbType_in, 
			int returnValue_Size_in
		) {
			return this.Execute_SQLFunction(
				function_in, 
				new IDbDataParameter[] { }, 
				returnValue_DbType_in, 
				returnValue_Size_in
			);
		}
		#endregion
		#region public object Execute_SQLFunction(string function_in, IDbDataParameter[] dataParameters_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(
			string function_in, 
			IDbDataParameter[] dataParameters_in
		) {
			return this.Execute_SQLFunction(
				function_in, 
				dataParameters_in, 
				DbType.Boolean, 
				-1
			);
		}
		#endregion
		#region public object Execute_SQLFunction(string function_in, IDbDataParameter[] dataParameters_in, DbType returnValue_DbType_in, int returnValue_Size_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <param name="returnValue_DbType_in">DbType for return value</param>
		/// <param name="returnValue_Size_in">Size for return value (the actual Database return value Size representation, if such exists)</param>
		/// <returns>populated Object with SQL Function's Output</returns>
		public object Execute_SQLFunction(
			string function_in,
			IDbDataParameter[] dataParameters_in,
			DbType returnValue_DbType_in,
			int returnValue_Size_in
		) {
			object _output;

			if (this.isopen_) {
				#region Using Opened Connection...
				IDbCommand _command = this.newDBCommand(
					function_in,
					(IDbConnection)this.exposeConnection
				);
				if ((this.transaction__ != null) && this.transaction__.inTransaction) {
					_command.Transaction = this.transaction__.exposeTransaction;
				}
				_output
					= this.Execute_SQLFunction(
						function_in,
						dataParameters_in,
						_command,
						returnValue_DbType_in,
						returnValue_Size_in
					);
				_command.Dispose(); _command = null;
				#endregion
			} else {
				#region Opening, Using and Closing Connection...
				IDbCommand _command = this.newDBCommand(
					function_in,
					this.exposeConnection
				);

				this.exposeConnection.Open();
				_output = this.Execute_SQLFunction(
					function_in,
					dataParameters_in,
					_command,
					returnValue_DbType_in,
					returnValue_Size_in
				);
				this.exposeConnection.Close();

				_command.Dispose(); _command = null;
				#endregion
			}

			return _output;
		}
		#endregion
		#endregion
		#region public DataSet Execute_SQLFunction_returnDataSet(...);
		#region private DataSet Execute_SQLFunction_returnDataSet(...);
		private DataSet Execute_SQLFunction_returnDataSet(string function_in, IDbDataParameter[] dataParameters_in, IDbConnection connection_in) {
			if (this.Logenabled) {
				this.Log("sql function", function_in, dataParameters_in);
			}

			DataSet _output;

			IDbDataAdapter _dataadapter = this.newDBDataAdapter(
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
				_output = new DataSet();
				_dataadapter.Fill(_output);
			} catch (Exception _ex) {
				throw new Exception(
					string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"Stored Procedure: {0}({6})\nParameters: {1}\nConnectionString: {2}|{3}\nexception: {4}\ninner-exception: {5}\n",
						function_in,
						dataParameters_in,
						this.DBServerType,
						this.connectionstring_,
						_ex.Message,
						_ex.InnerException,
						DBUtilities.IDbDataParameter2String(dataParameters_in)
					)
				);
			}

			//_dataadapter.Dispose(); // not implemented in IDbDataAdapter
			_dataadapter = null;

			return _output;
		}
		#endregion
		#region public DataSet Execute_SQLFunction_returnDataSet(string function_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <returns>populated DataSet with SQL Function's Output</returns>
		public DataSet Execute_SQLFunction_returnDataSet(string function_in) {
			return this.Execute_SQLFunction_returnDataSet(
				function_in, 
				new IDbDataParameter[] { }
			);
		}
		#endregion
		#region public DataSet Execute_SQLFunction_returnDataSet(string function_in, IDbDataParameter[] dataParameters_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <returns>populated DataSet with SQL Function's Output</returns>
		public DataSet Execute_SQLFunction_returnDataSet(
			string function_in, 
			IDbDataParameter[] dataParameters_in
		) {
			DataSet _output;

			if (this.isopen_) {
				#region Using Opened Connection...
				_output
					= this.Execute_SQLFunction_returnDataSet(
						function_in,
						dataParameters_in,
						this.exposeConnection
					);
				#endregion
			} else {
				#region Opening, Using and Closing Connection...
				this.exposeConnection.Open();

				_output
					= this.Execute_SQLFunction_returnDataSet(
						function_in,
						dataParameters_in,
						this.exposeConnection
					);

				this.exposeConnection.Close();
				#endregion
			}

			return _output;
		}
		#endregion
		#endregion
		#region public DataTable Execute_SQLFunction_returnDataTable(...);
		#region public DataTable Execute_SQLFunction_returnDataTable(string function_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <returns>populated DataTable with SQL Function's Output</returns>
		public DataTable Execute_SQLFunction_returnDataTable(string function_in) {
			return this.Execute_SQLFunction_returnDataTable(
				function_in, 
				new IDbDataParameter[] { }
			);
		}
		#endregion
		#region public DataTable Execute_SQLFunction_returnDataTable(string function_in, IDbDataParameter[] dataParameters_in);
		/// <summary>
		/// Executes an SQL Function on Database.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <returns>populated DataTable with SQL Function's Output</returns>
		public DataTable Execute_SQLFunction_returnDataTable(
			string function_in, 
			IDbDataParameter[] dataParameters_in
		) {
			DataTable _output;

			#region Execute_SQLFunction_returnDataTable_out = Execute_SQLFunction_returnDataSet(function_in, dataParameters_in).Tables[0];
			DataSet _dataset =
				this.Execute_SQLFunction_returnDataSet(
					function_in,
					dataParameters_in
				);
			_output = _dataset.Tables[0];
			_dataset.Dispose(); _dataset = null;
			#endregion

			return _output;
		}
		#endregion
		#endregion
		// ---
		#region public bool SQLFunction_exists(...);
		public abstract string SQLFunction_exists_query(string name_in);

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to determine if an SQL Function exists on Database, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Function Name</param>
		/// <returns>True if SQL Function exists, False if not</returns>
		public bool SQLFunction_exists(string name_in) {
			return (this.Execute_SQLQuery_returnDataTable(
				this.SQLFunction_exists_query(name_in)
			).Rows.Count == 1);
		}
		#endregion
		#region public bool SQLFunction_delete(...);
		public abstract string SQLFunction_delete_query(string name_in);

		/// <summary>
		/// Deletes a specific SQL Function on Database, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Function Name</param>
		/// <returns>True if SQL Function existed and was deleted, False if not</returns>
		public bool SQLFunction_delete(string name_in) {
			if (this.SQLFunction_exists(name_in)) {
				this.Execute_SQLQuery(this.SQLFunction_delete_query(name_in));
				return true;
			} else {
				return false;
			}
		}
		#endregion
		#region public bool SQLStoredProcedure_exists(...);
		public abstract string SQLStoredProcedure_exists_query(string name_in);

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to determine if an SQL Stored Procedure exists on Database, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Stored Procedure Name</param>
		/// <returns>True if SQL Stored Procedure exists, False if not</returns>
		public bool SQLStoredProcedure_exists(string name_in) {
			return (this.Execute_SQLQuery_returnDataTable(
				this.SQLStoredProcedure_exists_query(name_in)
			).Rows.Count == 1);
		}
		#endregion
		#region public bool SQLStoredProcedure_delete(...);
		public abstract string SQLStoredProcedure_delete_query(string name_in);

		/// <summary>
		/// Deletes a specific SQL Stored Procedure on Database, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL Stored Procedure Name</param>
		/// <returns>True if SQL Stored Procedure existed and was deleted, False if not</returns>
		public bool SQLStoredProcedure_delete(string name_in) {
			if (this.SQLStoredProcedure_exists(name_in)) {
				this.Execute_SQLQuery(this.SQLStoredProcedure_delete_query(name_in));
				return true;
			} else {
				return false;
			}
		}
		#endregion
		#region public bool SQLView_exists(...);
		public abstract string SQLView_exists_query(string name_in);

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to determine if an SQL View exists on Database, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL View Name</param>
		/// <returns>True if SQL View exists, False if not</returns>
		public bool SQLView_exists(string name_in) {
			return (this.Execute_SQLQuery_returnDataTable(
				this.SQLView_exists_query(name_in)
			).Rows.Count == 1);
		}
		#endregion
		#region public bool SQLView_delete(...);
		public abstract string SQLView_delete_query(string name_in);

		/// <summary>
		/// Deletes a specific SQL View on Database, based on it's name.
		/// </summary>
		/// <param name="name_in">SQL View Name</param>
		/// <returns>True if SQL View existed and was deleted, False if not</returns>
		public bool SQLView_delete(string name_in) {
			if (this.SQLView_exists(name_in)) {
				this.Execute_SQLQuery(this.SQLView_delete_query(name_in));
				return true;
			} else {
				return false;
			}
		}
		#endregion
		// ---
		#region public string[] getBDs(...);
		public abstract string getDBs_query();

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to get a list of available Database names.
		/// </summary>
		/// <returns>String array, representing a list of available Database names</returns>
		public string[] getDBs() {
			DataTable _datatable = this.Execute_SQLQuery_returnDataTable(this.getDBs_query());

			string[] _output = new string[_datatable.Rows.Count];
			for (int i = 0; i < _datatable.Rows.Count; i++)
				_output[i] = (string)_datatable.Rows[i][0];

			_datatable.Dispose(); _datatable = null;

			return _output;
		}
		#endregion
		#region public cDBTable[] getTables(...);
		private const string INFORMATION_SCHEMA_TABLES_TABLE_NAME = "table_name";
		private const string INFORMATION_SCHEMA_TABLES_IS_VIEW = "is_view";
		private const string INFORMATION_SCHEMA_TABLES_TABLE_DESCRIPTION = "table_description";

		public abstract string getTables_query(
			string dbName_in, 
			string subAppName_in
		);

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to get a list of Table names for the current Database Connection.
		/// </summary>
		/// <returns>String array, representing a list of Table names</returns>
		public DBTable[] getTables(
		) {
			return this.getTables(
				string.Empty
			);
		}

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to get a list of Table names for the current Database Connection.
		/// </summary>
		/// <param name="subAppName_in">Table Filter. If your Application is to be hosted at some ASP, which provides you with one Database only, and you're using that Database for more than one Application. I assume you're using some convention for Table naming like: AP1_Table1, AP1_Table2, AP2_Table1, ... . Or even if you have several modules sharing same data base. If so, you can use this parameter to filter Table names for some specific Application, like: AP1 or AP2</param>
		/// <returns>String array, representing a list of Table names</returns>
		public DBTable[] getTables(
			string subAppName_in
		) {
			return this.getTables(
				subAppName_in, 
				null
			);
		}

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to get a list of Table names for the current Database Connection.
		/// </summary>
		/// <param name="subAppName_in">Table Filter. If your Application is to be hosted at some ASP, which provides you with one Database only, and you're using that Database for more than one Application. I assume you're using some convention for Table naming like: AP1_Table1, AP1_Table2, AP2_Table1, ... . Or even if you have several modules sharing same data base. If so, you can use this parameter to filter Table names for some specific Application, like: AP1 or AP2</param>
		/// <returns>String array, representing a list of Table names</returns>
		public DBTable[] getTables(
			string subAppName_in, 
			string sqlFuncion_in
		) {
			DBTable[] _output;

			#region DataTable _dtemp = base.Execute_SQLQuery_returnDataTable(gettables(subAppName_in));
			DataTable _dtemp;
			if (string.IsNullOrEmpty(sqlFuncion_in)) {
				_dtemp = this.Execute_SQLQuery_returnDataTable(
					this.getTables_query(
						this.Connectionstring_DBName, 
						subAppName_in
					)
				);
			} else {
				_dtemp = this.Execute_SQLFunction_returnDataTable(
					sqlFuncion_in,
					new IDbDataParameter[] {
						this.newDBDataParameter("dbName_", DbType.String, ParameterDirection.Input, this.Connectionstring_DBName, this.Connectionstring_DBName.Length), 
						this.newDBDataParameter("subApp_", DbType.String, ParameterDirection.Input, subAppName_in, subAppName_in.Length)
					}
				);
			}
			#endregion
			_output = new DBTable[_dtemp.Rows.Count];
			for (int r = 0; r < _dtemp.Rows.Count; r++) {
				_output[r] = new DBTable(
					(string)_dtemp.Rows[r][INFORMATION_SCHEMA_TABLES_TABLE_NAME],
					(1 == (int)Convert.ChangeType(
						_dtemp.Rows[r][INFORMATION_SCHEMA_TABLES_IS_VIEW], 
						typeof(int),
						System.Globalization.CultureInfo.CurrentCulture
					)),
					(_dtemp.Rows[r][INFORMATION_SCHEMA_TABLES_TABLE_DESCRIPTION] == DBNull.Value) ? string.Empty : (string)_dtemp.Rows[r][INFORMATION_SCHEMA_TABLES_TABLE_DESCRIPTION]
				);
			}
			_dtemp.Dispose(); _dtemp = null;

			return _output;
		}
		#endregion
		#region public cDBTableField[] getTableFields(...);
		private const string INFORMATION_SCHEMA_COLUMNS_TABLE_NAME = "table_name";
		private const string INFORMATION_SCHEMA_COLUMNS_COLUMN_NAME = "column_name";
		private const string INFORMATION_SCHEMA_COLUMNS_CHARACTER_MAXIMUM_LENGTH = "character_maximum_length";
		private const string INFORMATION_SCHEMA_COLUMNS_IS_NULLABLE = "is_nullable";
		private const string INFORMATION_SCHEMA_COLUMNS_IS_IDENTITY = "is_identity";
		private const string INFORMATION_SCHEMA_COLUMNS_IS_PK = "is_pk";
		private const string INFORMATION_SCHEMA_COLUMNS_FK_TABLE_NAME = "fk_table_name";
		private const string INFORMATION_SCHEMA_COLUMNS_FK_COLUMN_NAME = "fk_column_name";
		private const string INFORMATION_SCHEMA_COLUMNS_NUMERIC_PRECISION = "numeric_precision";
		private const string INFORMATION_SCHEMA_COLUMNS_NUMERIC_SCALE = "numeric_scale";
		private const string INFORMATION_SCHEMA_COLUMNS_DATA_TYPE = "data_type";
		private const string INFORMATION_SCHEMA_COLUMNS_COLUMN_DEFAULT = "column_default";
		private const string INFORMATION_SCHEMA_COLUMNS_COLLATION_NAME = "collation_name";
		private const string INFORMATION_SCHEMA_COLUMNS_COLUMN_DESCRIPTION = "column_description";

		public abstract string getTableFields_query(
			string tableName_in
		);

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to get a list of Field names for some specific Table.
		/// </summary>
		/// <param name="tableName_in">Table name for which Field names are to be retrieved</param>
		/// <returns>String array, representing a list of Field names</returns>
		public DBTableField[] getTableFields(
			string tableName_in
		) {
			return this.getTableFields(
				tableName_in,
				null
			);
		}

		/// <summary>
		/// Makes use of the Database INFORMATION_SCHEMA to get a list of Field names for some specific Table.
		/// </summary>
		/// <param name="tableName_in">Table name for which Field names are to be retrieved</param>
		/// <returns>String array, representing a list of Field names</returns>
		public DBTableField[] getTableFields(
			string tableName_in,
			string sqlFuncion_in
		) {
			DBTableField[] _output;

			#region DataTable _dtemp = ...;
			DataTable _dtemp;
			if (string.IsNullOrEmpty(sqlFuncion_in)) {
				_dtemp = this.Execute_SQLQuery_returnDataTable(
					this.getTableFields_query(
						tableName_in
					)
				);
			} else {
				_dtemp = this.Execute_SQLFunction_returnDataTable(
					sqlFuncion_in,
					new IDbDataParameter[] {
						this.newDBDataParameter("dbName_", DbType.String, ParameterDirection.Input, this.Connectionstring_DBName, this.Connectionstring_DBName.Length), 
						this.newDBDataParameter("tableName_", DbType.String, ParameterDirection.Input, tableName_in, tableName_in.Length)
					}
				);
			}
			#endregion
			bool _includetablename = _dtemp.Columns.Contains(INFORMATION_SCHEMA_COLUMNS_TABLE_NAME);
			_output = new DBTableField[_dtemp.Rows.Count];
			for (int r = 0; r < _dtemp.Rows.Count; r++) {
				_output[r] = new DBTableField();

				_output[r].TableName 
					= _includetablename
						? (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_TABLE_NAME]
						: string.Empty;

				_output[r].Name = (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLUMN_NAME];

				// comment: some providers send int, other long, hence using convert change type:
				//getTableFields_out[r].Size = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_CHARACTER_MAXIMUM_LENGTH] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_CHARACTER_MAXIMUM_LENGTH];
				_output[r].Size 
					= (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_CHARACTER_MAXIMUM_LENGTH] == DBNull.Value) 
						? 0 
						: (int)Convert.ChangeType(
							_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_CHARACTER_MAXIMUM_LENGTH], 
							typeof(int),
							System.Globalization.CultureInfo.CurrentCulture
						);

				// comment: some providers send int, other long, hence using convert change type:
				//getTableFields_out[r].isNullable = ((int)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_IS_NULLABLE] == 1);
				_output[r].isNullable = (
					1 == (int)Convert.ChangeType(
						_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_IS_NULLABLE], 
						typeof(int),
						System.Globalization.CultureInfo.CurrentCulture
					)
				);

				_output[r].FK_TableName = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_FK_COLUMN_NAME] == DBNull.Value) ? string.Empty : (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_FK_TABLE_NAME];

				_output[r].FK_FieldName = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_FK_COLUMN_NAME] == DBNull.Value) ? string.Empty : (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_FK_COLUMN_NAME];

				// comment: some providers send int, other long, hence using convert change type:
				//getTableFields_out[r].isIdentity = ((int)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_IS_IDENTITY] == 1);
				_output[r].isIdentity = (
					1 == (int)Convert.ChangeType(
						_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_IS_IDENTITY], 
						typeof(int),
						System.Globalization.CultureInfo.CurrentCulture
					)
				);

				// comment: some providers send int, other long, hence using convert change type:
				//getTableFields_out[r].isPK = ((int)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_IS_PK] == 1);
				_output[r].isPK = (
					1 == (int)Convert.ChangeType(
						_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_IS_PK], 
						typeof(int),
						System.Globalization.CultureInfo.CurrentCulture
					)
				);

				// comment: some providers send int, other long, hence using convert change type:
				//getTableFields_out[r].Numeric_Precision = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_PRECISION] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_PRECISION];
				_output[r].Numeric_Precision 
					= (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_PRECISION] == DBNull.Value) 
						? 0 
						: (int)Convert.ChangeType(
							_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_PRECISION], 
							typeof(int),
							System.Globalization.CultureInfo.CurrentCulture
						);

				// comment: some providers send int, other long, hence using convert change type:
				//getTableFields_out[r].Numeric_Scale = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_SCALE] == DBNull.Value) ? 0 : (int)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_SCALE];
				_output[r].Numeric_Scale 
					= (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_SCALE] == DBNull.Value) 
						? 0 
						: (int)Convert.ChangeType(
							_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_NUMERIC_SCALE], 
							typeof(int),
							System.Globalization.CultureInfo.CurrentCulture
						);

				_output[r].DBType_inDB_name = (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_DATA_TYPE];

				_output[r].DBDefaultValue = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLUMN_DEFAULT] == DBNull.Value) ? string.Empty : (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLUMN_DEFAULT];

				_output[r].DBCollationName = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLLATION_NAME] == DBNull.Value) ? string.Empty : (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLLATION_NAME];

				_output[r].DBDescription = (_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLUMN_DESCRIPTION] == DBNull.Value) ? string.Empty : (string)_dtemp.Rows[r][INFORMATION_SCHEMA_COLUMNS_COLUMN_DESCRIPTION];
			}
			_dtemp.Dispose(); _dtemp = null;

			return _output;
		}
		#endregion
		#endregion
	}
}
