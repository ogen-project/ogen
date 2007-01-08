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

		/// <summary>
		/// PostgreSQL Client
		/// </summary>
		PostgreSQL = 4,			// PostgreSQL

		/// <summary>
		/// MySQL Client
		/// </summary>
		MySQL = 5,				// MySQL

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

		/// <summary>
		/// PostgreSQL Client
		/// </summary>
		PostgreSQL = 4,

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