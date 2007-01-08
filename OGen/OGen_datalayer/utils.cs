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
using NpgsqlTypes;
using MySql.Data.MySqlClient;
//using OGen.lib.config;

namespace OGen.lib.datalayer {
	/// <summary>
	/// Provides a number of classes with static auxiliar methods for the OGen.lib.datalayer namespace.
	/// </summary>
	public class utils { private utils() {}

		/// <summary>
		/// Provides means of manipulating ConnectionsStrings.
		/// </summary>
		public class Connectionstring { private Connectionstring() {}

			public enum eParameter {
				Server = 0, 
				User = 1, 
				Database = 2,

				invalid = 3
			}

			public static string ParseParameter(string connectionstring_in, eDBServerTypes dbServerTypes_in, string parameter_in) {
				System.Text.RegularExpressions.Regex fields_reg = new System.Text.RegularExpressions.Regex(
					string.Format("^(?<before>.*){0}=(?<param>.*);(?<after>.*)", parameter_in),
					System.Text.RegularExpressions.RegexOptions.IgnoreCase
				);
				System.Text.RegularExpressions.Match matchingfields = fields_reg.Match(connectionstring_in);
				if (!matchingfields.Success) {
					throw new Exception(
						string.Format(
							"{0}.{1}.ParseParameter(): - error parsing db connectionstring: '{2}'",
							typeof(Connectionstring).Namespace,
							typeof(Connectionstring).Name,
							connectionstring_in
						)
					);
				} else {
					return matchingfields.Groups["param"].Value;
				}
			}
			public static string ParseParameter(string connectionstring_in, eDBServerTypes dbServerTypes_in, eParameter parameter_in) {
				switch (parameter_in) {
					case eParameter.Database: {
						return ParseParameter(connectionstring_in, dbServerTypes_in, "database");
					}
					case eParameter.Server: {
						return ParseParameter(connectionstring_in, dbServerTypes_in, "server");
					}
					case eParameter.User: {
						switch (dbServerTypes_in) {
							case eDBServerTypes.PostgreSQL: {
								return ParseParameter(connectionstring_in, dbServerTypes_in, "User ID");
							}
							case eDBServerTypes.MySQL:
							case eDBServerTypes.SQLServer: {
								return ParseParameter(connectionstring_in, dbServerTypes_in, "uid");
							}
						}
						break;
					}
				}
				throw new Exception(
					string.Format(
						"{0}.{1}.ParseParameter(): - error parsing db connectionstring: '{2}'",
						typeof(Connectionstring).Namespace,
						typeof(Connectionstring).Name,
						connectionstring_in
					)
				);
			}

			/// <summary>
			/// Provides a number of static methods to build a ConnectionString.
			/// </summary>
			public class Buildwith { private Buildwith() {}

				//#region enums...
				#region public enum eOptions;
				/// <summary>
				/// Enumeration of Build Options.
				/// </summary>
				public enum eOptions {
//					/// <summary>
//					/// Windows Registry
//					/// </summary>
//					Registry = 0,

//					/// <summary>
//					/// some Configuration File
//					/// </summary>
//					File = 0,

					/// <summary>
					/// configuration\appSettings key value at app.config or Web.config File
					/// </summary>
					AppSettings = 0,

					/// <summary>
					/// invalid option
					/// </summary>
					invalid = 1
				}

				/// <summary>
				/// Provides means of manipulating the eOptions Enumeration.
				/// </summary>
				public class Options { private Options() {}
					/// <summary>
					/// Provides a number of static methods to play conversions upon the eOptions Enumeration.
					/// </summary>
					public class convert { private convert() {}

						#region public static eOptions FromString(string value_in);
						/// <summary>
						/// Converts a string value to an eOptions Enumeration.
						/// </summary>
						/// <param name="value_in">value</param>
						/// <returns>an eOptions Enumeration representative of the string value passed as parameter</returns>
						public static OGen.lib.datalayer.utils.Connectionstring.Buildwith.eOptions FromString(string value_in) {
							for (int i = 0;; i++) {
								if (((OGen.lib.datalayer.utils.Connectionstring.Buildwith.eOptions)i).ToString() == value_in) {
									return (OGen.lib.datalayer.utils.Connectionstring.Buildwith.eOptions)i;
								} else if (((OGen.lib.datalayer.utils.Connectionstring.Buildwith.eOptions)i).ToString() == OGen.lib.datalayer.utils.Connectionstring.Buildwith.eOptions.invalid.ToString()) {
									return OGen.lib.datalayer.utils.Connectionstring.Buildwith.eOptions.invalid;
								}
							}
						}
						#endregion
					}
				}
				#endregion
				//#endregion

				#region public void ThisOption(...);
				/// <summary>
				/// Uses an eOptions to retrieve a configuration used to build the ConnectionString.
				/// </summary>
				/// <param name="buildwith_in">build options</param>
				/// <param name="value_in">value</param>
				/// <returns>ConnectionString</returns>
				public static string ThisOption(eOptions buildwith_in, object value_in) {
					switch (buildwith_in) {
//						case eOptions.Registry:
//							return Registry((string)value_in);
//						case eOptions.File:
//							return File((string)value_in);
						case eOptions.AppSettings:
							return AppSettings((string)value_in);
						default:
							throw new Exception(
								string.Format(
									"{0}.{1}.ThisOption(): - I don't know what to use", 
									typeof(Buildwith).Namespace, 
									typeof(Buildwith).Name
								)
							);
					}
				}
				#endregion
				//---
				#region //public void Registry(...);
//				/// <summary>
//				/// Uses the Windows Registry to retrieve a configuration used to build the ConnectionString.
//				/// </summary>
//				/// <param name="dataBaseName_in">Database Name</param>
//				/// <returns>ConnectionString</returns>
//				public static string Registry(string dataBaseName_in) {
//					return new sConfig_registry("OGen\\Connectionstring", true)[dataBaseName_in];
//				}
				#endregion
				#region //public void File(...);
//				/// <summary>
//				/// Uses a File to retrieve a configuration used to build the ConnectionString.
//				/// </summary>
//				/// <param name="filePath_in">File Path</param>
//				/// <returns>ConnectionString</returns>
//				public static string File(string filePath_in) {
//					return new sConfig_list(filePath_in)[0];
//				}
				#endregion
				#region public void AppSettings(...);
				/// <summary>
				/// Uses the configuration\appSettings key value at app.config or Web.config File to retrieve a configuration used to build the ConnectionString.
				/// </summary>
				/// <param name="appSettings_in">appSettings key name</param>
				/// <returns>ConnectionString</returns>
				public static string AppSettings(string appSettings_in) {
					//return ConfigurationSettingsBinder.Read(appSettings_in);
					return System.Configuration.ConfigurationSettings.AppSettings[appSettings_in];
				}
				#endregion
				//---
				#region public void Parameters(...);
				/// <summary>
				/// Uses a range of parameters to build the ConnectionString.
				/// </summary>
				/// <param name="serverName_in">database server name/ip</param>
				/// <param name="userName_in">database user</param>
				/// <param name="userPassword_in">database user password</param>
				/// <param name="dataBaseName_in">database name</param>
				/// <param name="dbServerTypes_in">database type</param>
				/// <returns>ConnectionString</returns>
				public static string Parameters(string serverName_in, string userName_in, string userPassword_in, string dataBaseName_in, eDBServerTypes dbServerTypes_in) {
					switch (dbServerTypes_in) {
						case eDBServerTypes.SQLServer:
							return string.Format(
								"server={0};uid={1};pwd={2};database={3};", 
								serverName_in, 
								userName_in, 
								userPassword_in, 
								dataBaseName_in
							);
						case eDBServerTypes.PostgreSQL:
							return string.Format(
								"Server={0};User ID={1};Password={2};Database={3};", 
								serverName_in, 
								userName_in, 
								userPassword_in, 
								dataBaseName_in
							);
						case eDBServerTypes.MySQL:
							return string.Format(
								"Server={0};Uid={1};Pwd={2};Database={3};",
								serverName_in,
								userName_in,
								userPassword_in,
								dataBaseName_in
							);
						case eDBServerTypes.ODBC:
						case eDBServerTypes.Access:
						case eDBServerTypes.Excel:
						default:
							throw new Exception("invalid DBServerType");
					}
				}
				#endregion
				#region public void Parameters_forAccess(...);
				/// <summary>
				/// Builds the ConnectionString for an Access file, based on it's file path.
				/// </summary>
				/// <param name="filePath_in">Access file path</param>
				/// <returns>ConnectionString</returns>
				public static string Parameters_forAccess(string filePath_in) {
					return string.Format(
						"Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties=\"\";Jet OLEDB:System database=\"\";Jet OLEDB:Registry Path=\"\";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False", 
						filePath_in
					);
				}
				#endregion
				#region public void Parameters_forExcel(...);
				/// <summary>
				/// Builds the ConnectionString for an Excel file, based on it's file path.
				/// </summary>
				/// <param name="filePath_in">Excel file path</param>
				/// <returns>ConnectionString</returns>
				public static string Parameters_forExcel(string filePath_in) {
					return string.Format(
						"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;",
						filePath_in
					);
				}
				#endregion
			}

			// ...
		}

		/// <summary>
		/// Provides means of manipulating the eDBServerTypes Enumeration.
		/// </summary>
		public class DBServerTypes { private DBServerTypes() {}
			/// <summary>
			/// Provides a number of static methods to play conversions upon the eDBServerTypes Enumeration.
			/// </summary>
			public class convert { private convert() {}

				#region public static eDBServerTypes FromName(...);
				/// <summary>
				/// Converts a string value to an eDBServerTypes Enumeration.
				/// </summary>
				/// <param name="value_in">value</param>
				/// <returns>an eDBServerTypes Enumeration representative of the string value passed as parameter</returns>
				public static eDBServerTypes FromName(string value_in) {
					for (int i = 0;; i++) {
						if (((eDBServerTypes)i).ToString() == value_in) {
							return (eDBServerTypes)i;
						} else if (((eDBServerTypes)i).ToString() == eDBServerTypes.invalid.ToString()) {
							return eDBServerTypes.invalid;
						}
					}
				}
				#endregion
			}

			#region public static string[] Names(...);
			/// <summary>
			/// Runs through the eDBServerTypes Enumeration an collects it's items name in a string array.
			/// </summary>
			/// <returns>eDBServerTypes Enumeration items name in a string array</returns>
			public static string[] Names() {
				string[] Names_out;

				for (int i = 0;; i++) {
					if (((eDBServerTypes)i).ToString() == "invalid") {
						Names_out
							= new string[i];
						break;
					}
				}
				for (int i = 0;; i++) {
					if (((eDBServerTypes)i).ToString() == "invalid") {
						break;
					} else {
						Names_out[i]
							= ((eDBServerTypes)i).ToString();
					}
				}

				return Names_out;
			}
			#endregion
			#region public static string[] Names_supportedForGeneration(...);
			/// <summary>
			/// Runs through the eDBServerTypes_supportedForGeneration Enumeration an collects it's items name in a string array.
			/// </summary>
			/// <returns>eDBServerTypes_supportedForGeneration Enumeration items name in a string array</returns>
			public static string[] Names_supportedForGeneration() {
				string[] Names_out;

				int _counter = 0;
				for (int i = 0;; i++) {
					if (((eDBServerTypes_supportedForGeneration)i).ToString() == i.ToString())
						continue;

					if (((eDBServerTypes_supportedForGeneration)i).ToString() == "invalid")
						break;

					_counter++;
				}
				Names_out = new string[_counter];

				_counter = 0;
				for (int i = 0;; i++) {
					if (((eDBServerTypes_supportedForGeneration)i).ToString() == i.ToString())
						continue;

					if (((eDBServerTypes_supportedForGeneration)i).ToString() == "invalid") {
						break;
					}
					Names_out[_counter]
						= ((eDBServerTypes_supportedForGeneration)i).ToString();

					_counter++;
				}

				return Names_out;
			}
			#endregion
		}

		/// <summary>
		/// Provides a number of static methods to play conversions on: - .Net System Types; - System.DbType; - NpgsqlTypes.NpgsqlDbType; - System.Data.SqlTypes.
		/// </summary>
		public class convert { private convert() {}
			#region public static string object2SQLobject(...);
			/// <summary>
			/// Converts any .net framework object value to a string that can be used to buil an SQL Query.
			/// </summary>
			/// <param name="object_in">.net framework object value to be converted</param>
			/// <param name="dbServerType_in">DataBase Server Type</param>
			/// <returns>a string that can be used to buil an SQL Query</returns>
			public static string object2SQLobject(object object_in, eDBServerTypes dbServerType_in) {
				if (object_in == null) {
					switch (dbServerType_in) {
						case eDBServerTypes.PostgreSQL:
						case eDBServerTypes.MySQL:
						case eDBServerTypes.SQLServer: {
							return "null";
						}
					}
				} else {
					switch (object_in.GetType().ToString()) {
						case "System.Char":
						case "System.String": {
							switch (dbServerType_in) {
								//case eDBServerTypes.PostgreSQL: {
								//	// ToDos: here! check if changes made are correct (I need test units for this)
								//	// return string.Format("''{0}''", object_in.ToString ().Replace("'", "''"));
								//	return string.Format("'{0}'", object_in.ToString ().Replace("'", "''"));
								//}
								case eDBServerTypes.SQLServer: {
									return string.Format("\'{0}\'", object_in.ToString ().Replace("\'", "\'\'"));
								}
							}
							break;
						}
						case "System.DateTime": {
							DateTime _datetime = ((DateTime)object_in);
							if (DateTime.Compare(_datetime, DateTime.MinValue) == 0) {
								return object2SQLobject(null, dbServerType_in);
							} else {
								switch (dbServerType_in) {
									case eDBServerTypes.PostgreSQL:
									case eDBServerTypes.MySQL: {
										// ToDos: here! check if changes made are correct (I need test units for this)
										// return string.Format("timestamp ''{0}''", _datetime.ToString("yyyy-MM-dd HH:mm:ss"));
										return string.Format("timestamp '{0}'", _datetime.ToString("yyyy-MM-dd HH:mm:ss"));
									}
									case eDBServerTypes.SQLServer: {
										return string.Format("CONVERT(DATETIME, \'{0}\', 120)", _datetime.ToString("yyyy-MM-dd HH:mm:ss"));
									}
								}
							}
							break;
						}
						case "System.Boolean": {
							switch (dbServerType_in) {
								case eDBServerTypes.PostgreSQL:
								case eDBServerTypes.MySQL: {
									return (((bool)object_in) ? "true" : "false");
								}
								case eDBServerTypes.SQLServer: {
									return (((bool)object_in) ? "1" : "0");
								}
							}
							break;
						}
						case "System.Int16":
						case "System.Int32":
						case "System.Int64":
						case "System.Double":
						case "System.Decimal":
						case "System.Single": {
							switch (dbServerType_in) {
								//case eDBServerTypes.PostgreSQL: {
								//	return object_in.ToString().Replace(",", ".");
								//}
								case eDBServerTypes.SQLServer: {
									// ToDos: here! this will likely change accordingly with regional 
									// settings configurations, I need to come up with a better 
									// approach to this:
									return object_in.ToString().Replace(",", ".");
								}
							}
							break;
						}
						case "System.DBNull": {
							return object2SQLobject(null, dbServerType_in);
						}
					}
				}
				throw new Exception (string.Format(
					"not implemented for: {0}",
					object_in.GetType().ToString()
				));
			}
			#endregion

			// ToDos: here! have a look at: sSqlDbType.cs
			#region public static string DbType2NSysType(...);
			// <summary>
			// Aimed for code generator, hence returning straight string.
			// NSysType - .Net System Type
			// </summary>
			public static string DbType2NSysType(DbType dbType_in) {
				switch (dbType_in) {
					case DbType.Boolean: {
						return "bool"; //typeof(bool).Name;
					}
					case DbType.Int16: {
						return typeof(Int16).Name;
					}
					case DbType.Int32: {
						return "int"; //typeof(int).Name;
					}
					case DbType.Int64: {
						return "long"; //typeof(long).Name;
					}
					case DbType.UInt16: {
						return typeof(UInt16).Name;
					}
					case DbType.UInt32: {
						return typeof(UInt32).Name;
					}
					case DbType.UInt64: {
						return typeof(UInt64).Name;
					}
					case DbType.String: {
							return "string"; //typeof(string).Name;
					}
					case DbType.DateTime:
					case DbType.Date:
					case DbType.Time: {
						return typeof(DateTime).Name;
					}
					case DbType.Guid: {
						return typeof(Guid).Name;
					}
					case DbType.Byte: {
						return typeof(Byte).Name;
					}
					case DbType.Object: {
						return typeof(Object).Name;
					}

					case DbType.Single: {
						// ToDos: here! check if appropriate...
						return typeof(Single).Name;
					}
					case DbType.Binary: {
						// ToDos: here! check if appropriate...
						return typeof(Byte[]).Name;
					}
					case DbType.Decimal: {
						// ToDos: here! check if appropriate...
						return typeof(Decimal).Name;
					}
					case DbType.Double: {
						// ToDos: here! check if appropriate...
						return typeof(Double).Name;
					}

					case DbType.AnsiString:
					case DbType.AnsiStringFixedLength:
					case DbType.Currency:
					case DbType.SByte:
					case DbType.StringFixedLength:
					case DbType.VarNumeric: {
						// ToDos: here!
						break;
					}

					default: {
						break;
					}
				}

				throw new Exception(string.Format(
					"undefined variable type: {0}",
					dbType_in.GetType().ToString()
				));
			}
			#endregion
			#region public static string DBType2NSysEmptyValue(...);
			// <summary>
			// Aimed for code generator, hence returning straight string.
			// .Net System (default/) Empty Value
			// </summary>
			public static string DBType2NSysEmptyValue(DbType dbType_in) {
				switch (dbType_in) {
					case DbType.DateTime:
					case DbType.Date:
					case DbType.Time:
						// .net fw minimum value for datetime is undetermined
						// in db, hence a specific one:
						return "new DateTime(1900, 1, 1)"; // "DateTime.MinValue";

					case DbType.Int16: 
					case DbType.Int32: 
					case DbType.UInt16: 
					case DbType.UInt32: 
					case DbType.Byte: 
					case DbType.Single:
						return "0";
					case DbType.Double:
						return "0D";
					case DbType.Decimal:
						return "0M";
					case DbType.Int64:
					case DbType.UInt64:
						return "0L";
					case DbType.Boolean:
						return "false";
					case DbType.String:
						return "string.Empty";
					case DbType.Guid:
						return "Guid.Empty";
					case DbType.Binary:
						return "null";

					// ToDos: here!
				}

				throw new Exception(string.Format(
					"undefined variable type: {0}",
					dbType_in.ToString()
				));
			}
			#endregion
			#region public static string DBType2NUnitTestValue(...);
			// <summary>
			// Aimed for NUnit testing.
			// </summary>
			public static string DBType2NUnitTestValue(DbType dbType_in) {
				switch (dbType_in) {
					case DbType.DateTime:
					case DbType.Date:
					case DbType.Time: {
						// sql server friendly
						return "new DateTime(2341, 12, 12)";
					}
					case DbType.Int64:
					case DbType.UInt64: {
						return "123L";
					}
					case DbType.Int16: 
					case DbType.Int32: 
					case DbType.UInt16: 
					case DbType.UInt32: 
					case DbType.Byte: 
					case DbType.Single: 
					case DbType.Double: 
					case DbType.Decimal: {
						return "123";
					}
					case DbType.Boolean: {
						return "true";
					}
					case DbType.String: {
						return "\"123\"";
					}
					case DbType.Guid: {
						return "Guid.NewGuid()";
					}
					case DbType.Binary: {
						return "new Byte[] { 1, 2, 3 }";
					}

// ToDos: here! check if appropriate...
//case DbType.Single:
//return "0F";

					// ToDos: here!
				}

				throw new Exception(string.Format(
					"undefined variable type: {0}",
					dbType_in.GetType().ToString()
				));
			}
			#endregion
			#region public static string DBType2DBEmptyValue(...);
			// <summary>
			// Aimed for code generator, hence returning straight string.
			// </summary>
			public static string DBType2DBEmptyValue(DbType dbType_in, eDBServerTypes dbServerType_in) {
				switch (dbType_in) {
					case DbType.DateTime:
					case DbType.Date:
					case DbType.Time: {
						return object2SQLobject(
							new DateTime(1900, 1, 1), 
							dbServerType_in
						);
					}
					case DbType.Int16: 
					case DbType.Int32: 
					case DbType.Int64:
					case DbType.UInt16: 
					case DbType.UInt32: 
					case DbType.UInt64:
					case DbType.Byte: 
					case DbType.Single: 
					case DbType.Double: 
					case DbType.Decimal:
					case DbType.Boolean: {
						return "0";
					}
					case DbType.String: {
						return "''";
					}
					case DbType.Binary: {
						return "new Byte[] {}";
					}

					// ToDos: here!
				}
				throw new Exception(string.Format(
					"undefined variable type: {0}",
					dbType_in.ToString() // dbType_in.GetType().ToString()
				));
			}
			#endregion

			#region public static DbType DbType_Parse(string value_in);
			public static DbType DbType_Parse(string value_in) {
				return DbType_Parse(value_in, true);
			}
			public static DbType DbType_Parse(string value_in, bool caseSensitive_in) {
				string _value = (caseSensitive_in) ? value_in : value_in.ToLower();
				for (int i = 0; ((DbType)i).ToString() != i.ToString(); i++) {
					if (
						(
							caseSensitive_in
							&&
							(((DbType)i).ToString() == _value)
						)
						||
						(
							!caseSensitive_in
							&&
							(((DbType)i).ToString().ToLower() == _value)
						)
					) {
						return (DbType)i;
					}
				}
				throw new Exception(string.Format("invalid db type: {0}", value_in));
			}
			#endregion
			#region public static SqlDbType SqlDbType_Parse(string value_in);
			public static SqlDbType SqlDbType_Parse(string value_in) {
				return SqlDbType_Parse(value_in, true);
			}
			public static SqlDbType SqlDbType_Parse(string value_in, bool caseSensitive_in) {
				string _value = (caseSensitive_in) ? value_in : value_in.ToLower();

				switch (_value) {
					case "numeric": {
						return SqlDbType.Decimal;
					}
					default: {
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
									(((SqlDbType)i).ToString().ToLower() == _value)
								)
							) {
								return (SqlDbType)i;
							}
						}
						break;
					}
				}

				throw new Exception(string.Format("invalid db type: {0}", value_in));
			}
			#endregion
			#region public static NpgsqlDbType PgsqlDbType_Parse(string value_in);
			public static NpgsqlDbType PgsqlDbType_Parse(string value_in) {
				switch (value_in.ToLower()) {
					case "timestamp with time zone": 
					case "timestamptz":
						return NpgsqlDbType.TimestampTZ;

					case "timestamp without time zone": 
					case "timestamp":
						return NpgsqlDbType.Timestamp;

					case "boolean": 
					case "bool":
						return NpgsqlDbType.Boolean;

					case "bigint": 
					case "int8":
						return NpgsqlDbType.Bigint;

					case "integer": 
					case "int4":
						return NpgsqlDbType.Integer;

					case "smallint": 
					case "int2":
						return NpgsqlDbType.Smallint;

					case "text":
						return NpgsqlDbType.Text;

					case "character varying": 
					case "varchar":
						return NpgsqlDbType.Varchar;

					case "real": 
					case "float4":
						return NpgsqlDbType.Real;

					case "double precision": 
					case "float8":
						return NpgsqlDbType.Double;

					case "numeric":
						return NpgsqlDbType.Numeric;

					case "bytea":
						return NpgsqlDbType.Bytea;

					case "date":
						return NpgsqlDbType.Date;

					case "time without time zone": 
					case "time": 
					case "time with time zone": 
					case "timetz":
						return NpgsqlDbType.Time;

					case "money":
						return NpgsqlDbType.Money;

					#region default: throw new Exception("...");
					//case "bigserial":
					//case "serial8":
					//	return ePgsqlDbType.BigSerial;
					//case "serial":
					//case "serial4":
					//	return ePgsqlDbType.Serial;
					default: { throw new Exception(string.Format("invalid db type: {0}", value_in)); }
					#endregion
				}
			}
			#endregion
			#region public static MySqlDbType MySqlDbType_Parse(string value_in);
			public static MySqlDbType MySqlDbType_Parse(string value_in) {
				switch (value_in.ToLower()) {
					case "float": { return MySqlDbType.Float; }
					case "double": { return MySqlDbType.Double; }
					case "decimal": { return MySqlDbType.Decimal; }
					case "date": { return MySqlDbType.Date; }
					case "datetime": { return MySqlDbType.Datetime; }
					case "timestamp": { return MySqlDbType.Timestamp; }
					case "time": { return MySqlDbType.Time; }
					case "year": { return MySqlDbType.Year; }
					case "varchar": { return MySqlDbType.VarChar; }
					case "tinyblob": { return MySqlDbType.TinyBlob; }
					case "blob": { return MySqlDbType.Blob; }
					case "mediumblob": { return MySqlDbType.MediumBlob; }
					case "longblob": { return MySqlDbType.LongBlob; }
					case "geometry": { return MySqlDbType.Geometry; }
					case "bit": { return MySqlDbType.Bit; }
					case "tinyint": { return MySqlDbType.Byte; }
					case "smallint": { return MySqlDbType.Int16; }
					case "mediumint": { return MySqlDbType.Int24; }
					case "int": { return MySqlDbType.Int32; }
					case "bigint": { return MySqlDbType.Int64; }

					default: { throw new Exception(string.Format("invalid db type: {0}", value_in)); }
				}
			}
			#endregion

			#region public static DbType SqlDbType2DbType(...);
			public static DbType SqlDbType2DbType(SqlDbType sqlDbType_in) {
				switch (sqlDbType_in) {
					case SqlDbType.BigInt: { return DbType.Int64; }
					case SqlDbType.Bit: { return DbType.Boolean; }

					case SqlDbType.Char:
					case SqlDbType.NChar:
					case SqlDbType.NText:
					case SqlDbType.NVarChar:
					case SqlDbType.Text:
					case SqlDbType.VarChar: { return DbType.String; }

					case SqlDbType.DateTime:
					case SqlDbType.SmallDateTime: { return DbType.DateTime; }

					case SqlDbType.Decimal:
					case SqlDbType.Money:
					case SqlDbType.SmallMoney: { return DbType.Decimal; }

					case SqlDbType.Float: { return DbType.Double; }
					case SqlDbType.Int: { return DbType.Int32; }
					case SqlDbType.Real: { return DbType.Single; }
					case SqlDbType.UniqueIdentifier: { return DbType.Guid; }
					case SqlDbType.SmallInt: { return DbType.Int16; }
					case SqlDbType.TinyInt: { return DbType.Byte; }
					case SqlDbType.Variant: { return DbType.Object; }
					case SqlDbType.Binary: { return DbType.Binary; }

					case SqlDbType.Image:
					case SqlDbType.Timestamp:
					case SqlDbType.VarBinary:

					#region default: throw new Exception("...");
					default: {
						throw new Exception(string.Format(
							"undefined variable type: {0}",
							sqlDbType_in.ToString()
						));
					}
					#endregion
				}
			}
			#endregion
			#region public static DbType PgsqlDbType2DbType(...);
			public static DbType PgsqlDbType2DbType(NpgsqlDbType pgsqlDbType_in) {
				switch (pgsqlDbType_in) {
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
						return DbType.String;

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

					#region default: throw new Exception("...");
					default: {
						throw new Exception(string.Format(
							"undefined variable type: {0}",
							pgsqlDbType_in.ToString()
						));
					}
					#endregion
				}
			}
			#endregion
			#region public static DbType MySqlDbType2DbType(MySqlDbType mySqlDbType_in);
			public static DbType MySqlDbType2DbType(MySqlDbType mySqlDbType_in) {
				switch (mySqlDbType_in) {
					case MySqlDbType.Float: { return DbType.Double; }
					case MySqlDbType.Double: { return DbType.Double; }
					case MySqlDbType.Decimal: { return DbType.Decimal; }
					case MySqlDbType.Date: { return DbType.Date; }
					case MySqlDbType.Datetime: { return DbType.DateTime; }
					case MySqlDbType.Timestamp: { return DbType.DateTime; } // ToDos: here! check if appropriate
					case MySqlDbType.Time: { return DbType.Time; }
					case MySqlDbType.Year: { return DbType.DateTime; } // ToDos: here! check if appropriate

//					case MySqlDbType.TinyBlob:
//					case MySqlDbType.Blob:
//					case MySqlDbType.MediumBlob:
//					case MySqlDbType.LongBlob:
					case MySqlDbType.VarChar: { return DbType.String; } // ToDos: here! check if appropriate

//					case MySqlDbType.Geometry: { return DbType.Geometry; }
					case MySqlDbType.Bit: { return DbType.Boolean; } // ToDos: here! check if appropriate
					case MySqlDbType.Byte: { return DbType.Byte; }
					case MySqlDbType.Int16: { return DbType.Int16; }
//					case MySqlDbType.Int24: { return DbType.Int24; }
					case MySqlDbType.Int32: { return DbType.Int32; }
					case MySqlDbType.Int64: { return DbType.Int64; }

					#region default: throw new Exception("...");
					default: {
						throw new Exception(string.Format(
							"undefined variable type: {0}",
							mySqlDbType_in.ToString()
						));
					}
					#endregion
				}
			}
			#endregion
		}

		#region public static bool isBool(...);
		/// <summary>
		/// Determines if a specific DbType is a valid Boolean type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid Boolean type</param>
		/// <returns>True if DbType is a valid Boolean type, False if not</returns>
		public static bool isBool(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Boolean: {
					return true;
				}
				default: {
					return false;
				}
			}
		}
		#endregion
		#region public static bool isDateTime(...);
		/// <summary>
		/// Determines if a specific DbType is a valid DateTime type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid DateTime type</param>
		/// <returns>True if DbType is a valid DateTime type, False if not</returns>
		public static bool isDateTime(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.DateTime:
				case DbType.Date: {
				//case DbType.Time:
					return true;
				}
				default: {
					return false;
				}
			}
		}
		#endregion
		#region public static bool isInt(...);
		/// <summary>
		/// Determines if a specific DbType is a valid Integer type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid Integer type</param>
		/// <returns>True if DbType is a valid Integer type, False if not</returns>
		public static bool isInt(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Byte:
				case DbType.SByte:
				case DbType.Int16:
				case DbType.Int32:
				case DbType.Int64:
				case DbType.UInt16:
				case DbType.UInt32:
				case DbType.UInt64:
				case DbType.VarNumeric: {
					return true;
				}
				default: {
					return false;
				}
			}
		}
		#endregion
		#region public static bool isDecimal(...);
		/// <summary>
		/// Determines if a specific DbType is a valid Decimal type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid Decimal type</param>
		/// <returns>True if DbType is a valid Decimal type, False if not</returns>
		public static bool isDecimal(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Currency:
				case DbType.Decimal:
				case DbType.Double:
				case DbType.Single: {
					return true;
				}
				default: {
					return false;
				}
			}
		}
		#endregion
		#region public static bool isText(...);
		/// <summary>
		/// Determines if a specific DbType is a valid String type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid String type</param>
		/// <returns>True if DbType is a valid String type, False if not</returns>
		public static bool isText(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.String:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength: {
					return true;
				}
				default: {
					return false;
				}
			}
		}
		#endregion
	}
}