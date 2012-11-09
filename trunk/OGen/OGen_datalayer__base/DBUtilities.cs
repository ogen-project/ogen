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
	using System.Text;

	/// <summary>
	/// Provides a number of classes with static auxiliar methods for the OGen.Libraries.DataLayer namespace.
	/// </summary>
	public abstract class DBUtilities {
		public abstract DBUtilities_convert Convert { get; }
		public abstract DBUtilities_connectionString ConnectionString { get; }
		#region public static bool IsBoolean(...);
		/// <summary>
		/// Determines if a specific DbType is a valid Boolean type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid Boolean type</param>
		/// <returns>True if DbType is a valid Boolean type, False if not</returns>
		public static bool IsBoolean(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Boolean:
					return true;

				default:
					return false;
			}
		}
		#endregion
		#region public static bool IsDateTime(...);
		/// <summary>
		/// Determines if a specific DbType is a valid DateTime type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid DateTime type</param>
		/// <returns>True if DbType is a valid DateTime type, False if not</returns>
		public static bool IsDateTime(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.DateTime:
				case DbType.Date:
				//case DbType.Time:
					return true;

				default:
					return false;
			}
		}
		#endregion
		#region public static bool IsInteger(...);
		/// <summary>
		/// Determines if a specific DbType is a valid Integer type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid Integer type</param>
		/// <returns>True if DbType is a valid Integer type, False if not</returns>
		public static bool IsInteger(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Byte:
				case DbType.SByte:
				case DbType.Int16:
				case DbType.Int32:
				case DbType.Int64:
				case DbType.UInt16:
				case DbType.UInt32:
				case DbType.UInt64:
				case DbType.VarNumeric:
					return true;

				default:
					return false;
			}
		}
		#endregion
		#region public static bool IsDecimal(...);
		/// <summary>
		/// Determines if a specific DbType is a valid Decimal type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid Decimal type</param>
		/// <returns>True if DbType is a valid Decimal type, False if not</returns>
		public static bool IsDecimal(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Currency:
				case DbType.Decimal:
				case DbType.Double:
				case DbType.Single:
					return true;

				default:
					return false;
			}
		}
		#endregion
		#region public static bool IsText(...);
		/// <summary>
		/// Determines if a specific DbType is a valid String type.
		/// </summary>
		/// <param name="dbType_in">the DbType to determine if it is a valid String type</param>
		/// <returns>True if DbType is a valid String type, False if not</returns>
		public static bool IsText(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
					return true;

				default:
					return false;
			}
		}
		#endregion

		#region public static string IDbDataParameter2String(...);
		public static string IDbDataParameter2String(
			IDbDataParameter[] dataParameters_in
		) {
			StringBuilder _sb = new StringBuilder();
			for (int i = 0; i < dataParameters_in.Length; i++) {
				_sb.Append(string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"\n\t{1}{2}\t\t--{0}",
					dataParameters_in[i].ParameterName,
					(
						(dataParameters_in[i].Value == null) 
						|| 
						(dataParameters_in[i].Value == DBNull.Value)
					)
						? "NULL"
						: dataParameters_in[i].Value,
					(i == dataParameters_in.Length - 1) ? "\n" : ","
				));
			}
			return _sb.ToString();
		}
		#endregion
	}

	/// <summary>
	/// Provides a number of static methods to play conversions on: - .Net System Types; - System.DbType; - NpgsqlTypes.NpgsqlDbType; - System.Data.SqlTypes.
	/// </summary>
	public abstract class DBUtilities_convert {
		#region public abstract string object2SQLobject(...);
		/// <summary>
		/// Converts any .net framework object value to a string that can be used to buil an SQL Query.
		/// </summary>
		/// <param name="object_in">.net framework object value to be converted</param>
		/// <returns>a string that can be used to buil an SQL Query</returns>
		public abstract string object2SQLobject(
			object object_in
		);
		#endregion

		// ToDos: here! have a look at: sSqlDbType.cs
		#region public static string DbType2NSysType(...) {
		// <summary>
		// Aimed for code generator, hence returning straight string.
		// NSysType - .Net System Type
		// </summary>
		/// <param name="dbType_in"></param>
		/// <returns></returns>
		public static string DbType2NSysType(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.Boolean:
					return "bool"; //typeof(bool).Name;

				case DbType.Int16:
					return typeof(short).Name;

				case DbType.Int32:
					return "int"; //typeof(int).Name;

				case DbType.Int64:
					return "long"; //typeof(long).Name;

				case DbType.UInt16:
					return typeof(ushort).Name;

				case DbType.UInt32:
					return typeof(uint).Name;

				case DbType.UInt64:
					return typeof(ulong).Name;

				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
					return "string"; //typeof(string).Name;

				case DbType.DateTime:
				case DbType.Date:
				case DbType.Time:
					return typeof(DateTime).Name;

				case DbType.Guid:
					return typeof(Guid).Name;

				case DbType.Byte:
					return typeof(byte).Name;

				case DbType.Object:
					return typeof(object).Name;

				case DbType.Single:
					// ToDos: here! check if appropriate...
					return typeof(float).Name;

				case DbType.Binary:
					// ToDos: here! check if appropriate...
					return typeof(byte[]).Name;

				case DbType.Decimal:
					// ToDos: here! check if appropriate...
					return typeof(decimal).Name;

				case DbType.Double:
					// ToDos: here! check if appropriate...
					return typeof(double).Name;

				case DbType.Currency:
				case DbType.SByte:
				case DbType.VarNumeric:
					// ToDos: here!
					break;

				default: {
					break;
				}
			}

			throw new Exception(string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
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
				case DbType.StringFixedLength:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
					return "string.Empty";

				case DbType.Guid:
					return "Guid.Empty";

				case DbType.Binary:
					return "null";

				// ToDos: here!
			}

			throw new Exception(string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
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
				case DbType.Time:
					// sql server friendly
					return "new DateTime(2341, 12, 12)";

				case DbType.Int64:
				case DbType.UInt64:
					return "123L";

				case DbType.Int16: 
				case DbType.Int32: 
				case DbType.UInt16: 
				case DbType.UInt32: 
				case DbType.Byte: 
				case DbType.Single: 
				case DbType.Double: 
				case DbType.Decimal:
					return "123";

				case DbType.Boolean:
					return "true";

				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
					return "\"123\"";

				case DbType.Guid:
					return "Guid.NewGuid()";

				case DbType.Binary:
					return "new Byte[] { 1, 2, 3 }";

// ToDos: here! check if appropriate...
//case DbType.Single:
//return "0F";

				// ToDos: here!
			}

			throw new Exception(string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"undefined variable type: {0}",
				dbType_in.GetType().ToString()
			));
		}
		#endregion
		#region public string DBType2DBEmptyValue(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);
		// <summary>
		// Aimed for code generator, hence returning straight string.
		// </summary>
		public string DBType2DBEmptyValue(DbType dbType_in) {
			switch (dbType_in) {
				case DbType.DateTime:
				case DbType.Date:
				case DbType.Time:
					return this.object2SQLobject(
						datetime_minvalue_
					);

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
				case DbType.Boolean:
					return "0";

				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
					return "''";

				case DbType.Binary:
					return "new Byte[] {}";

				// ToDos: here!
			}
			throw new Exception(string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
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
#if NET_1_1
			string _value = (caseSensitive_in) ? value_in : value_in.ToLower(System.Globalization.CultureInfo.CurrentCulture);
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
						(((DbType)i).ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture) == _value)
					)
				) {
					return (DbType)i;
				}
			}
			throw new Exception(string.Format(System.Globalization.CultureInfo.CurrentCulture, "invalid db type: {0}", value_in));
#else
			return (DbType)Enum.Parse(typeof(DbType), value_in, !caseSensitive_in);
#endif
		}
		#endregion
		#region public abstract int XDbType_Parse(string value_in, bool caseSensitive_in);
		public int XDbType_Parse(string value_in) {
			return this.XDbType_Parse(value_in, true);
		}
		public abstract int XDbType_Parse(string value_in, bool caseSensitive_in);
		#endregion
		public abstract DbType XDbType2DbType(int xDbType_in);
	}

	/// <summary>
	/// Provides means of manipulating ConnectionsStrings.
	/// </summary>
	public abstract class DBUtilities_connectionString {
		#region public abstract string ParseParameter(...);
		public enum ParameterName : int {
			Server = 0, 
			User = 1, 
			DBName = 2,

			invalid = 3
		}

		public static string ParseParameter(
			string connectionString_in, 
			string parameterName_in
		) {
			System.Text.RegularExpressions.Regex fields_reg = new System.Text.RegularExpressions.Regex(
				string.Format(
					System.Globalization.CultureInfo.CurrentCulture, 
					"^(?<before>.*){0}=(?<param>.*);(?<after>.*)", 
					parameterName_in
				),
				System.Text.RegularExpressions.RegexOptions.IgnoreCase
			);
			System.Text.RegularExpressions.Match matchingfields = fields_reg.Match(connectionString_in);
			if (!matchingfields.Success) {
				throw new Exception(
					string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"{0}.{1}.ParseParameter(): - error parsing db connectionstring: '{2}'",
						typeof(DBUtilities_connectionString).Namespace,
						typeof(DBUtilities_connectionString).Name,
						connectionString_in
					)
				);
			} else {
				return matchingfields.Groups["param"].Value;
			}
		}
		public abstract string ParseParameter(
			string connectionString_in, 
			ParameterName parameterName_in
		);
		#endregion

		#region public abstract string Build(...);
		/// <summary>
		/// Builds the ConnectionString based on a range of needed parameters.
		/// </summary>
		/// <param name="serverName_in">database server name/ip</param>
		/// <param name="userName_in">database user</param>
		/// <param name="userPassword_in">database user password</param>
		/// <param name="databaseName_in">database name</param>
		/// <returns>connection string</returns>
		public abstract string Build(
			string serverName_in, 
			string userName_in, 
			string userPassword_in, 
			string databaseName_in
		);
		#endregion
	}
}