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

namespace OGen.lib.datalayer {
	#region public enum eDBServerTypes;
	/// <summary>
	/// Enumeration of supported DBs.
	/// </summary>
	public enum eDBServerTypes {
		/// <summary>
		/// ODBC
		/// </summary>
		ODBC = 0,				// ODBC

		/// <summary>
		/// Microsoft Access, through OleDB
		/// </summary>
		Access = 1,				// OleDB

		/// <summary>
		/// Microsoft Excel, through OleDB
		/// </summary>
		Excel = 2,				// OleDB

		/// <summary>
		/// SQL Server Client
		/// </summary>
		SQLServer = 3,			// SQLClient

#if PostgreSQL
		/// <summary>
		/// PostgreSQL Client
		/// </summary>
		PostgreSQL = 4,			// PostgreSQL
#endif
#if MySQL
		/// <summary>
		/// MySQL Client
		/// </summary>
		MySQL = 5,				// MySQL
#endif

		/// <summary>
		/// invalid type
		/// </summary>
		invalid = 6
	}
	#endregion
	#region public enum eDBServerTypes_supportedForGeneration;
	/// <summary>
	/// Enumeration of supported DBs for generation purposes.
	/// </summary>
	public enum eDBServerTypes_supportedForGeneration {
		/// <summary>
		/// SQL Server Client
		/// </summary>
		SQLServer = 3,

#if PostgreSQL
		/// <summary>
		/// PostgreSQL Client
		/// </summary>
		PostgreSQL = 4,
#endif

		/// <summary>
		/// invalid type
		/// </summary>
		invalid = 6
	}
	#endregion

	#region //oldstuff...
//	public class DBServerTypes {
//		private DBServerTypes() {}
//
//		#region public static string[] Names(...);
//		public static string[] Names() {
//			string[] Names_;
//
//			for (int i = 0;; i++) {
//				if (((eDBServerTypes)i).ToString() == "invalid") {
//					Names_
//						= new string[i];
//					break;
//				}
//			}
//			for (int i = 0;; i++) {
//				if (((eDBServerTypes)i).ToString() == "invalid") {
//					break;
//				} else {
//					Names_[i]
//						= ((eDBServerTypes)i).ToString();
//				}
//			}
//
//			return Names_;
//		}
//		#endregion
//		#region public static string[] Names_supportedForGeneration(...);
//		public static string[] Names_supportedForGeneration() {
//			return new string[] {
//				"SQLServer", 
//				"PostgreSQL"
//			};
//		}
//		#endregion
//		#region public static eDBServerTypes convert_FromName(...);
//		public static eDBServerTypes convert_FromName(string Name_) {
//			for (int i = 0;; i++) {
//				if (((eDBServerTypes)i).ToString() == Name_) {
//					return (eDBServerTypes)i;
//				} else if (((eDBServerTypes)i).ToString() == eDBServerTypes.invalid.ToString()) {
//					return eDBServerTypes.invalid;
//				}
//			}
//		}
//		#endregion
//	}
	#endregion
}