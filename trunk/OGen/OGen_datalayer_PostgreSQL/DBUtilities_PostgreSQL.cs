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
	using NpgsqlTypes;

	public sealed class DBUtilities_PostgreSQL : DBUtilities {
		#region public override DBUtilities_convert Convert { get; }
		private static DBUtilities_convert_Postgresql convert__;
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
							convert__ = new DBUtilities_convert_Postgresql();
						}
					}
				}

				return convert__;
			}
		}
		#endregion
		#region public override DBUtilities_connectionString ConnectionString { get; }
		private static DBUtilities_connectionString_PostgreSQL connectionstring__;
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
							connectionstring__ = new DBUtilities_connectionString_PostgreSQL();
						}
					}
				}

				return connectionstring__;
			}
		}
		#endregion
	}
	public sealed class DBUtilities_convert_Postgresql : DBUtilities_convert {
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
						// ToDos: later! check if changes made are correct (I need test units for this)
						//return string.Format(System.Globalization.CultureInfo.CurrentCulture, "''{0}''", object_in.ToString ().Replace("'", "''"));
						//return string.Format(System.Globalization.CultureInfo.CurrentCulture, "'{0}'", object_in.ToString ().Replace("'", "''"));
						break;

					case "System.DateTime":
						DateTime _datetime = ((DateTime)object_in);
						if (DateTime.Compare(_datetime, DateTime.MinValue) == 0) {
							return this.object2SQLobject(null);
						} else {
							// ToDos: later! check if changes made are correct (I need test units for this)
							// return string.Format(System.Globalization.CultureInfo.CurrentCulture, "timestamp ''{0}''", _datetime.ToString("yyyy-MM-dd HH:mm:ss"));
							return string.Format(
								System.Globalization.CultureInfo.CurrentCulture, 
								"timestamp '{0}'", 
								_datetime.ToString(
									"yyyy-MM-dd HH:mm:ss",
									System.Globalization.CultureInfo.CurrentCulture
								)
							);
						}

					case "System.Boolean":
						return (((bool)object_in) ? "true" : "false");

					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.Double":
					case "System.Decimal":
					case "System.Single":
						// ToDos: later!
						//case eDBServerTypes.PostgreSQL: {
						//	return object_in.ToString().Replace(",", ".");
						//}
						break;

					case "System.DBNull":
						return this.object2SQLobject(null);
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
			switch (value_in.ToLower(System.Globalization.CultureInfo.CurrentCulture)) {
				case "timestamp with time zone": 
				case "timestamptz":
					return (int)NpgsqlDbType.TimestampTZ;

				case "timestamp without time zone": 
				case "timestamp":
					return (int)NpgsqlDbType.Timestamp;

				case "boolean": 
				case "bool":
					return (int)NpgsqlDbType.Boolean;

				case "bigserial": // fmonteiro: bigserial is needed for Dia
				case "bigint": 
				case "int8":
					return (int)NpgsqlDbType.Bigint;

				case "serial": // fmonteiro: serial is needed for Dia
				case "integer": 
				case "int4":
					return (int)NpgsqlDbType.Integer;

				case "smallint": 
				case "int2":
					return (int)NpgsqlDbType.Smallint;

				case "text":
					return (int)NpgsqlDbType.Text;

				case "character varying": 
				case "varchar":
					return (int)NpgsqlDbType.Varchar;

				case "real": 
				case "float4":
					return (int)NpgsqlDbType.Real;

				case "double precision": 
				case "float8":
					return (int)NpgsqlDbType.Double;

				case "numeric":
					return (int)NpgsqlDbType.Numeric;

				case "bytea":
					return (int)NpgsqlDbType.Bytea;

				case "date":
					return (int)NpgsqlDbType.Date;

				case "time without time zone": 
				case "time": 
				case "time with time zone": 
				case "timetz":
					return (int)NpgsqlDbType.Time;

				case "money":
					return (int)NpgsqlDbType.Money;

				//case "interval":
				//    return (int)NpgsqlDbType.Interval;

				//case "bigserial":
				//case "serial8":
				//	return ePgsqlDbType.BigSerial;
				//case "serial":
				//case "serial4":
				//	return ePgsqlDbType.Serial;

				default:
					throw new Exception(string.Format(
						System.Globalization.CultureInfo.CurrentCulture, 
						"invalid db type: {0}", 
						value_in
					));
			}
		}
		#endregion
		#region public override DbType XDbType2DbType(int xDbType_in);
		public override DbType XDbType2DbType(int xDbType_in) {
			switch ((NpgsqlDbType)xDbType_in) {
				case NpgsqlDbType.Bigint:
					return DbType.Int64;

				case NpgsqlDbType.Integer:
					return DbType.Int32;

				case NpgsqlDbType.Smallint:
					return DbType.Int16;

				case NpgsqlDbType.Boolean:
					return DbType.Boolean;

				case NpgsqlDbType.Varchar:
				case NpgsqlDbType.Text:
					return DbType.AnsiString;

				case NpgsqlDbType.TimestampTZ:
				case NpgsqlDbType.Timestamp:
					return DbType.DateTime;

				case NpgsqlDbType.Real:
					return DbType.Single;

				case NpgsqlDbType.Double:
					return DbType.Double;

				case NpgsqlDbType.Numeric:
					return DbType.Decimal;

				case NpgsqlDbType.Bytea:
					return DbType.Binary;

				case NpgsqlDbType.Date:
					return DbType.Date;

				case NpgsqlDbType.Time:
					return DbType.Time;

				case NpgsqlDbType.Money:
					return DbType.Decimal;

				//case NpgsqlDbType.Interval:
				//    return DbType.

				default:
					throw new Exception(string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"undefined variable type: {0}",
						((NpgsqlDbType)xDbType_in).ToString()
					));
			}
		}
		#endregion
	}
	public sealed class DBUtilities_connectionString_PostgreSQL : DBUtilities_connectionString {
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
					return DBUtilities_connectionString.ParseParameter(connectionString_in, "User ID");
			}
			throw new Exception(
				string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"{0}.{1}.ParseParameter(): - error parsing db connectionstring: 'PostgreSQL|{2}'",
					typeof(DBUtilities_connectionString_PostgreSQL).Namespace,
					typeof(DBUtilities_connectionString_PostgreSQL).Name,
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
				"Server={0};User ID={1};Password={2};Database={3};", 
				serverName_in, 
				userName_in, 
				userPassword_in, 
				databaseName_in
			);
		}
		#endregion
	}
}
