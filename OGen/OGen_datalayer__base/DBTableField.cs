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
	/// <summary>
	/// Provides a mean of storing the DataBase INFORMATION_SCHEMA for some Table Field.
	/// </summary>
	public class cDBTableField {
		/// <summary>
		/// Table Name.
		/// </summary>
		public string TableName;

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
