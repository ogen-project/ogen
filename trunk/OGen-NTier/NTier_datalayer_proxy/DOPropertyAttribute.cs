#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.DataLayer {
	using System;

	/// <summary>
	/// DataObject Property Attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class DOPropertyAttribute : System.Attribute {
//		#region public DOPropertyAttribute(...);
//		/// <param name="dbDescription_in">Description at Database</param>
		/// <param name="name_in">Name</param>
		/// <param name="friendlyName_in">Friendly name</param>
		/// <param name="extendedDescription_in">Extended description</param>
		/// <param name="isPK_in">True if it is a Primary Key, False if not</param>
		/// <param name="isIdentity_in">True if it is a Sequence/Identity Seed, False if not</param>
		/// <param name="isNullable_in">True if it allows null Values, False if not</param>
		/// <param name="defaultValue_in">Default Value</param>
		/// <param name="foreignKey_TableName_in">Foreign Key Table Name</param>
		/// <param name="foreignKey_TableFieldName_in">Foreign Key Field Name</param>
		/// <param name="isConfig_Name_in">True if it represents a Config Name, False if not</param>
		/// <param name="isConfig_Config_in">True if it represents a Config Config, False if not</param>
		/// <param name="isConfig_Datatype_in">True if it represents a Config DataType, False if not</param>
		/// <param name="isBoolean_in">True if it is a Boolean Value, False if not</param>
		/// <param name="isDateTime_in">True if it is a DateTime Value, False if not</param>
		/// <param name="isInteger_in">True if it is an Integer Value, False if not</param>
		/// <param name="isDecimal_in">True if it is a Decimal Value, False if not</param>
		/// <param name="isText_in">True if it is a Text Value, False if not</param>
		public DOPropertyAttribute(
			string			name_in, 
			string			friendlyName_in, 
			string			extendedDescription_in, 
//			string			dbDescription_in, 
			bool			isPK_in, 
			bool			isIdentity_in,
			bool			isNullable_in, 
			string			defaultValue_in,
			string			foreignKey_TableName_in, 
			string			foreignKey_TableFieldName_in, 
			bool			isConfig_Name_in, 
			bool			isConfig_Config_in, 
			bool			isConfig_Datatype_in, 
			bool			isBoolean_in, 
			bool			isDateTime_in, 
			bool			isInteger_in, 
			bool			isDecimal_in, 
			bool			isText_in,
			bool			isListItemValue_in,
			bool			isListItemText_in, 
			int				size_in, 
			string			aditionalInfo_in
		) {
			this.name_ = name_in;
			this.friendlyname_ = friendlyName_in;
//			this.dbdescription_ = dbDescription_in;
			this.extendeddescription_ = extendedDescription_in;
			this.ispk_ = isPK_in;
			this.isidentity_ = isIdentity_in;
			this.isnullable_ = isNullable_in;
			this.defaultvalue_ = defaultValue_in;
			this.foreignkey_tablename_ = foreignKey_TableName_in;
			this.foreignkey_tablefieldname_ = foreignKey_TableFieldName_in;
			this.isconfig_name_ = isConfig_Name_in;
			this.isconfig_config_ = isConfig_Config_in;
			this.isconfig_datatype_ = isConfig_Datatype_in;
			this.isboolean_ = isBoolean_in;
			this.isdatetime_ = isDateTime_in;
			this.isinteger_ = isInteger_in;
			this.isdecimal_ = isDecimal_in;
			this.istext_ = isText_in;
			this.islistitemvalue_ = isListItemValue_in;
			this.islistitemtext_ = isListItemText_in;
			this.size_ = size_in;
			this.aditionalinfo_ = aditionalInfo_in;
		}
//		#endregion

		#region public string Name { get; }
		private string name_;

		/// <summary>
		/// Name
		/// </summary>
		public string Name {
			get { return this.name_; }
		}
		#endregion
		#region public string FriendlyName { get; }
		private string friendlyname_;

		/// <summary>
		/// Friendly name
		/// </summary>
		public string FriendlyName {
			get { return this.friendlyname_; }
		}
		#endregion
//        #region public string DBDescription { get; }
//        private string dbdescription_;
//
//        /// <summary>
//        /// Description at Database
//        /// </summary>
//        public string DBDescription {
//            get { return dbdescription_; }
//        }
//        #endregion
		#region public string ExtendedDescription { get; }
		private string extendeddescription_;

		/// <summary>
		/// Extended description
		/// </summary>
		public string ExtendedDescription {
			get { return this.extendeddescription_; }
		}
		#endregion
		#region public bool IsPK { get; }
		private bool ispk_;

		/// <summary>
		/// Indicates if it is a Primary Key. True if it is a Primary Key, False if not.
		/// </summary>
		public bool IsPK {
			get { return this.ispk_; }
		}
		#endregion
		#region public bool IsIdentity { get; }
		private bool isidentity_;

		/// <summary>
		/// Indicates if it is a Sequence/Identity Seed. True if it is a Sequence/Identity Seed, False if not.
		/// </summary>
		public bool IsIdentity {
			get { return this.isidentity_; }
		}
		#endregion
		#region public bool IsNullable { get; }
		private bool isnullable_;

		/// <summary>
		/// Indicates if it allows null Values. True if it allows null Values, False if not.
		/// </summary>
		public bool IsNullable {
			get { return this.isnullable_; }
		}
		#endregion
		#region public string DefaultValue { get; }
		private string defaultvalue_;

		/// <summary>
		/// Default Value.
		/// </summary>
		public string DefaultValue {
			get { return this.defaultvalue_; }
		}
		#endregion
		#region public string ForeignKey_TableName { get; }
		private string foreignkey_tablename_;

		/// <summary>
		/// Foreign Key Table Name
		/// </summary>
		public string ForeignKey_TableName {
			get { return this.foreignkey_tablename_; }
		}
		#endregion
		#region public string ForeignKey_TableFieldName { get; }
		private string foreignkey_tablefieldname_;

		/// <summary>
		/// Foreign Key Field Name
		/// </summary>
		public string ForeignKey_TableFieldName {
			get { return this.foreignkey_tablefieldname_; }
		}
		#endregion
		#region public bool IsConfig_Name { get; }
		private bool isconfig_name_;

		/// <summary>
		/// Indicates if it represents a Config Name. True if it represents a Config Name, False if not.
		/// </summary>
		public bool IsConfig_Name {
			get { return this.isconfig_name_; }
		}
		#endregion
		#region public bool IsConfig_Config { get; }
		private bool isconfig_config_;

		/// <summary>
		/// Indicates if it represents a Config Config. True if it represents a Config Config, False if not.
		/// </summary>
		public bool IsConfig_Config {
			get { return this.isconfig_config_; }
		}
		#endregion
		#region public bool IsConfig_Datatype { get; }
		private bool isconfig_datatype_;

		/// <summary>
		/// Indicates if it represents a Config DataType. True if it represents a Config DataType, False if not.
		/// </summary>
		public bool IsConfig_Datatype {
			get { return this.isconfig_datatype_; }
		}
		#endregion
		#region public bool IsBoolean { get; }
		private bool isboolean_;

		/// <summary>
		/// Indicates if it is a Boolean Value. True if it is a Boolean Value, False if not.
		/// </summary>
		public bool IsBoolean {
			get { return this.isboolean_; }
		}
		#endregion
		#region public bool IsDateTime { get; }
		private bool isdatetime_;

		/// <summary>
		/// Indicates if it is a DateTime Value. True if it is a DateTime Value, False if not.
		/// </summary>
		public bool IsDateTime {
			get { return this.isdatetime_; }
		}
		#endregion
		#region public bool IsInteger { get; }
		private bool isinteger_;

		/// <summary>
		/// Indicates if it is an Integer Value. True if it is an Integer Value, False if not.
		/// </summary>
		public bool IsInteger {
			get { return this.isinteger_; }
		}
		#endregion
		#region public bool IsDecimal { get; }
		private bool isdecimal_;

		/// <summary>
		/// Indicates if it is a Decimal Value. True if it is a Decimal Value, False if not.
		/// </summary>
		public bool IsDecimal {
			get { return this.isdecimal_; }
		}
		#endregion
		#region public bool IsText { get; }
		private bool istext_;

		/// <summary>
		/// Indicates if it is a Text Value. True if it is a Text Value, False if not.
		/// </summary>
		public bool IsText {
			get { return this.istext_; }
		}
		#endregion
//		#region public bool IsListItemValue { get; }
		private bool islistitemvalue_;

		public bool IsListItemValue {
			get { return this.islistitemvalue_; }
		}
//		#endregion
//		#region public bool IsListItemText { get; }
		private bool islistitemtext_;

		public bool IsListItemText {
			get { return this.islistitemtext_; }
		}
//		#endregion
//		#region public int Size { get; }
		private int size_;

		public int Size {
			get { return this.size_; }
		}
//		#endregion
//		#region public string AditionalInfo { get; }
		private string aditionalinfo_;

		public string AditionalInfo {
			get { return this.aditionalinfo_; }
		}
//		#endregion
	}
}
