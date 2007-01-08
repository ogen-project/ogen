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
	/// <summary>
	/// Provides a mean of storing the DataBase INFORMATION_SCHEMA for some Table Field.
	/// </summary>
	public class cDBTableField {
		/// <summary>
		/// Indicates if it is a Sequence/Identity Seed. True if it is a Sequence/Identity Seed, False if not.
		/// </summary>
		public bool isIdentity;

		/// <summary>
		/// Indicates if it is a Primary Key. True if it is a Primary Key, False if not.
		/// </summary>
		public bool isPK;

		/// <summary>
		/// Indicates if it allows null Values. True if it allows null Values, False if not.
		/// </summary>
		public bool isNullable;

		/// <summary>
		/// Name.
		/// </summary>
		public string Name;

		public int Size;

		#region public virtual string DBType_inDB_name { get; set; }
		private string dbtype_indb_name_;
		public virtual string DBType_inDB_name {
			get { return dbtype_indb_name_; }
			set { dbtype_indb_name_ = value; }
		}
		#endregion

		/// <summary>
		/// Foreign Key Table Name.
		/// </summary>
		public string FK_TableName;

		/// <summary>
		/// Foreign Key Field Name.
		/// </summary>
		public string FK_FieldName;

		/// <summary>
		/// Description.
		/// </summary>
		public string DBDescription;

		/// <summary>
		/// Default Value.
		/// </summary>
		public string DBDefaultValue;

		/// <summary>
		/// Collation Name.
		/// </summary>
		public string DBCollationName;

		/// <summary>
		/// Numeric Precision.
		/// </summary>
		public int Numeric_Precision;

		/// <summary>
		/// Numeric Scale.
		/// </summary>
		public int Numeric_Scale;

		public override string ToString() {
			return Name;
		}
	}
}