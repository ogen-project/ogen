#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Libraries.DataLayer.SQLServer {
	using System;
	using System.Data;

	public sealed class DBUtilities_SQLServer : DBUtilities {
		#region public override DBUtilities_convert Convert { get; }
		private static DBUtilities_convert_SQLServer convert__;
		private static object convert__locker = new object();

		public override DBUtilities_convert Convert {
			get {

				// check before lock
				if (convert__ == null) {

					lock (convert__locker) {

						// double check, thread safer!
						if (convert__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							convert__ = new DBUtilities_convert_SQLServer();
						}
					}
				}

				return convert__;
			}
		}
		#endregion
		#region public override DBUtilities_connectionString ConnectionString { get; }
		private static DBUtilities_connectionString_SQLServer connectionstring__;
		private static object connectionstring__locker = new object();

		public override DBUtilities_connectionString ConnectionString {
			get {

				// check before lock
				if (connectionstring__ == null) {

					lock (connectionstring__locker) {

						// double check, thread safer!
						if (connectionstring__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							connectionstring__ = new DBUtilities_connectionString_SQLServer();
						}
					}
				}

				return connectionstring__;
			}
		}
		#endregion
	}
	public sealed class DBUtilities_convert_SQLServer : DBUtilities_convert {
		#region public override string object2SQLobject(...);
		public override string object2SQLobject(
			object object_in
		) {
			if (object_in == null) {
				return "null";
			} else {
				switch (object_in.GetType().ToString()) {
					case "System.Char":
					case "System.String":
						return string.Format(
							System.Globalization.CultureInfo.CurrentCulture, 
							"\'{0}\'", 
							object_in.ToString().Replace("\'", "\'\'")
						);

					case "System.DateTime":
						DateTime _datetime = ((DateTime)object_in);
						if (DateTime.Compare(_datetime, DateTime.MinValue) == 0) {
							return this.object2SQLobject(null);
						} else {
							return string.Format(
								System.Globalization.CultureInfo.CurrentCulture, 
								"CONVERT(DATETIME, \'{0}\', 120)", 
								_datetime.ToString(
									"yyyy-MM-dd HH:mm:ss",
									System.Globalization.CultureInfo.CurrentCulture
								)
							);
						}

					case "System.Boolean":
						return (((bool)object_in) ? "1" : "0");

					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.Double":
					case "System.Decimal":
					case "System.Single":
						// ToDos: later! this will likely change accordingly with regional 
						// settings configurations, I need to come up with a better 
						// approach to this:
						return object_in.ToString().Replace(",", ".");

					case "System.DBNull": {
						return this.object2SQLobject(null);
					}
				}
			}

			throw new Exception (string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"not implemented for: {0}",
				object_in.GetType().ToString()
			));
		}
		#endregion

		#region public override int XDbType_Parse(string value_in, bool caseSensitive_in);
		public override int XDbType_Parse(string value_in, bool caseSensitive_in) {
			string _value = (caseSensitive_in) ? value_in : value_in.ToLower(System.Globalization.CultureInfo.CurrentCulture);

			switch (_value) {
				case "numeric":
					return (int)SqlDbType.Decimal;
#if NET_1_1
				case "date":
					return (int)SqlDbType.Date;
#endif
				default:
#if NET_1_1
					for (int i = 0; ((SqlDbType)i).ToString() != i.ToString(); i++) {
						if (
							(
								caseSensitive_in
								&&
								(((SqlDbType)i).ToString() == _value)
							)
							||
							(
								!caseSensitive_in
								&&
								(((SqlDbType)i).ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture) == _value)
							)
						) {
							//return (SqlDbType)i;
							return i;
						}
					}
#else
					string[] _sqldbtypes = Enum.GetNames(typeof(SqlDbType));
					for (int i = 0; i < _sqldbtypes.Length; i++) {
						if (
							(
								caseSensitive_in
								&&
								(_sqldbtypes[i] == _value)
							)
							||
							(
								!caseSensitive_in
								&&
								(_sqldbtypes[i].ToLower(System.Globalization.CultureInfo.CurrentCulture) == _value)
							)
						) {
							return (int)(SqlDbType)Enum.Parse(typeof(SqlDbType), _sqldbtypes[i]);
						}
					}
#endif
					break;
			}

			throw new Exception(string.Format(
				System.Globalization.CultureInfo.CurrentCulture, 
				"invalid db type: {0}", 
				value_in
			));
		}
		#endregion
		#region public override DbType XDbType2DbType(int xDbType_in);
		public override DbType XDbType2DbType(int xDbType_in) {
			switch ((SqlDbType)xDbType_in) {
				case SqlDbType.BigInt:
					return DbType.Int64;

				case SqlDbType.Bit:
					return DbType.Boolean;

				case SqlDbType.Char:
				case SqlDbType.VarChar:
				case SqlDbType.Text:
					return DbType.AnsiString;
				case SqlDbType.NChar:
				case SqlDbType.NVarChar:
				case SqlDbType.NText:
					return DbType.String;

				case SqlDbType.Date:
					return DbType.Date;

				case SqlDbType.DateTime:
				case SqlDbType.SmallDateTime:
					return DbType.DateTime;

				case SqlDbType.Decimal:
				case SqlDbType.Money:
				case SqlDbType.SmallMoney:
					return DbType.Decimal;

				case SqlDbType.Float:
					return DbType.Double;

				case SqlDbType.Int:
					return DbType.Int32;

				case SqlDbType.Real:
					return DbType.Single;

				case SqlDbType.UniqueIdentifier:
					return DbType.Guid;

				case SqlDbType.SmallInt:
					return DbType.Int16;

				case SqlDbType.TinyInt:
					return DbType.Byte;

				case SqlDbType.Variant:
					return DbType.Object;

				case SqlDbType.Binary:
					return DbType.Binary;

				case SqlDbType.Image:
				case SqlDbType.Timestamp:
				case SqlDbType.VarBinary:
				default: {
					throw new Exception(string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"undefined variable type: {0}",
						((SqlDbType)xDbType_in).ToString()
					));
				}
			}
		}
		#endregion
	}
	public sealed class DBUtilities_connectionString_SQLServer : DBUtilities_connectionString {
		#region public override string ParseParameter(...);
		public override string ParseParameter(
			string connectionString_in, 
			ParameterName parameterName_in
		) {
			switch (parameterName_in) {
				case ParameterName.DBName:
					return DBUtilities_connectionString.ParseParameter(connectionString_in, "database");

				case ParameterName.Server:
					return DBUtilities_connectionString.ParseParameter(connectionString_in, "server");

				case ParameterName.User:
					return DBUtilities_connectionString.ParseParameter(connectionString_in, "uid");
			}
			throw new Exception(
				string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"{0}.{1}.ParseParameter(): - error parsing db connectionstring: 'SQLServer|{2}'",
					typeof(DBUtilities_connectionString_SQLServer).Namespace,
					typeof(DBUtilities_connectionString_SQLServer).Name,
#if DEBUG
					connectionString_in
#else
					"- not available -"
#endif
				)
			);
		}
		#endregion
		#region public override string Build(...);
		public override string Build(
			string serverName_in, 
			string userName_in, 
			string userPassword_in, 
			string databaseName_in
		) {
			return string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"server={0};uid={1};pwd={2};database={3};", 
				serverName_in, 
				userName_in, 
				userPassword_in, 
				databaseName_in
			);
		}
		#endregion
	}
}
