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

namespace OGen.lib.datalayer.MySQL {
	public sealed class DBUtils_MySQL : DBUtils {
		#region public override DBUtils_convert Convert { get; }
		private static DBUtils_convert_MySQL convert__;

		public override DBUtils_convert Convert {
			get {
				if (convert__ == null) {
					convert__ = new DBUtils_convert_MySQL();
				}

				return convert__;
			}
		}
		#endregion
		#region public override DBUtils_connectionString ConnectionString { get; }
		private static DBUtils_connectionString_MySQL connectionstring__;

		public override DBUtils_connectionString ConnectionString {
			get {
				if (connectionstring__ == null) {
					connectionstring__ = new DBUtils_connectionString_MySQL();
				}

				return connectionstring__;
			}
		}
		#endregion
	}
	public sealed class DBUtils_convert_MySQL : DBUtils_convert {
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
						// ToDos: here!
						break;

					case "System.DateTime":
						DateTime _datetime = ((DateTime)object_in);
						if (DateTime.Compare(_datetime, DateTime.MinValue) == 0) {
							return object2SQLobject(null);
						} else {
							// ToDos: here! check if changes made are correct (I need test units for this)
							// return string.Format("timestamp ''{0}''", _datetime.ToString("yyyy-MM-dd HH:mm:ss"));
							return string.Format("timestamp '{0}'", _datetime.ToString("yyyy-MM-dd HH:mm:ss"));
						}

					case "System.Boolean":
						return (((bool)object_in) ? "true" : "false");

					case "System.Int16":
					case "System.Int32":
					case "System.Int64":
					case "System.Double":
					case "System.Decimal":
					case "System.Single":
						// ToDos: here!
						break;

					case "System.DBNull":
						return object2SQLobject(null);
				}
			}
			throw new Exception (string.Format(
				"not implemented for: {0}",
				object_in.GetType().ToString()
			));
		}
		#endregion

		#region public override int XDbType_Parse(string value_in, bool caseSensitive_in);
		public override int XDbType_Parse(string value_in, bool caseSensitive_in) {
			switch (value_in.ToLower()) {
				case "float": return (int)MySqlDbType.Float;
				case "double": return (int)MySqlDbType.Double;
				case "decimal": return (int)MySqlDbType.Decimal;
				case "date": return (int)MySqlDbType.Date;
				case "datetime": return (int)MySqlDbType.Datetime;
				case "timestamp": return (int)MySqlDbType.Timestamp;
				case "time": return (int)MySqlDbType.Time;
				case "year": return (int)MySqlDbType.Year;
				case "varchar": return (int)MySqlDbType.VarChar;
				case "tinyblob": return (int)MySqlDbType.TinyBlob;
				case "blob": return (int)MySqlDbType.Blob;
				case "mediumblob": return (int)MySqlDbType.MediumBlob;
				case "longblob": return (int)MySqlDbType.LongBlob;
				case "geometry": return (int)MySqlDbType.Geometry;
				case "bit": return (int)MySqlDbType.Bit;
				case "tinyint": return (int)MySqlDbType.Byte;
				case "smallint": return (int)MySqlDbType.Int16;
				case "mediumint": return (int)MySqlDbType.Int24;
				case "int": return (int)MySqlDbType.Int32;
				case "bigint": return (int)MySqlDbType.Int64;

				default:
					throw new Exception(string.Format("invalid db type: {0}", value_in));
			}
		}
		#endregion
		#region public override DbType XDbType2DbType(int xDbType_in);
		public override DbType XDbType2DbType(int xDbType_in) {
			switch ((MySqlDbType)xDbType_in) {
				case MySqlDbType.Float:
					return DbType.Double;

				case MySqlDbType.Double:
					return DbType.Double;

				case MySqlDbType.Decimal:
					return DbType.Decimal;

				case MySqlDbType.Date:
					return DbType.Date;

				case MySqlDbType.Datetime:
					return DbType.DateTime;

				case MySqlDbType.Timestamp:
					// ToDos: here! check if appropriate
					return DbType.DateTime;

				case MySqlDbType.Time:
					return DbType.Time;

				case MySqlDbType.Year:
					// ToDos: here! check if appropriate
					return DbType.DateTime;

//				case MySqlDbType.TinyBlob:
//				case MySqlDbType.Blob:
//				case MySqlDbType.MediumBlob:
//				case MySqlDbType.LongBlob:
				case MySqlDbType.VarChar:
					// ToDos: here! check if appropriate
					return DbType.String;

//				case MySqlDbType.Geometry:
//					return DbType.Geometry;

				case MySqlDbType.Bit:
					// ToDos: here! check if appropriate
					return DbType.Boolean;

				case MySqlDbType.Byte:
					return DbType.Byte;

				case MySqlDbType.Int16:
					return DbType.Int16;

//				case MySqlDbType.Int24:
//					return DbType.Int24;

				case MySqlDbType.Int32:
					return DbType.Int32;

				case MySqlDbType.Int64:
					return DbType.Int64;

				default: {
					throw new Exception(string.Format(
						"undefined variable type: {0}",
						((MySqlDbType)xDbType_in).ToString()
					));
				}
			}
		}
		#endregion
	}
	public sealed class DBUtils_connectionString_MySQL : DBUtils_connectionString {
		#region public override string ParseParameter(...);
		public override string ParseParameter(
			string connectionstring_in, 
			eParameter parameter_in
		) {
			switch (parameter_in) {
				case eParameter.DBName:
					return ParseParameter(connectionstring_in, "database");

				case eParameter.Server:
					return ParseParameter(connectionstring_in, "server");

				case eParameter.User:
					return ParseParameter(connectionstring_in, "uid");
			}
			throw new Exception(
				string.Format(
					"{0}.{1}.ParseParameter(): - error parsing db connectionstring: '{2}'",
					typeof(DBUtils_connectionString_MySQL).Namespace,
					typeof(DBUtils_connectionString_MySQL).Name,
					connectionstring_in
				)
			);
		}
		#endregion
		#region public override string Build(...);
		public override string Build(
			string serverName_in, 
			string userName_in, 
			string userPassword_in, 
			string dataBaseName_in
		) {
			return string.Format(
				"Server={0};Uid={1};Pwd={2};Database={3};",
				serverName_in,
				userName_in,
				userPassword_in,
				dataBaseName_in
			);
		}
		#endregion
	}
}
