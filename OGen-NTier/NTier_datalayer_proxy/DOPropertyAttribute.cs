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

namespace OGen.NTier.lib.datalayer {
	/// <summary>
	/// DataObject Property Attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class DOPropertyAttribute : System.Attribute {
//		#region public DOPropertyAttribute(...);
//		/// <param name="dbDescription_in">Description at DataBase</param>
		/// <param name="name_in">Name</param>
		/// <param name="friendlyName_in">Friendly name</param>
		/// <param name="extendedDescription_in">Extended description</param>
		/// <param name="isPK_in">True if it is a Primary Key, False if not</param>
		/// <param name="isIdentity_in">True if it is a Sequence/Identity Seed, False if not</param>
		/// <param name="isNullable_in">True if it allows null Values, False if not</param>
		/// <param name="defaultValue_in">Default Value</param>
		/// <param name="fk_TableName_in">Foreign Key Table Name</param>
		/// <param name="fk_FieldName_in">Foreign Key Field Name</param>
		/// <param name="isConfig_Name_in">True if it represents a Config Name, False if not</param>
		/// <param name="isConfig_Config_in">True if it represents a Config Config, False if not</param>
		/// <param name="isConfig_Datatype_in">True if it represents a Config DataType, False if not</param>
		/// <param name="isBool_in">True if it is a Boolean Value, False if not</param>
		/// <param name="isDateTime_in">True if it is a DateTime Value, False if not</param>
		/// <param name="isInt_in">True if it is an Integer Value, False if not</param>
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
			string			fk_TableName_in, 
			string			fk_FieldName_in, 
			bool			isConfig_Name_in, 
			bool			isConfig_Config_in, 
			bool			isConfig_Datatype_in, 
			bool			isBool_in, 
			bool			isDateTime_in, 
			bool			isInt_in, 
			bool			isDecimal_in, 
			bool			isText_in,
			bool			isListItemValue_in,
			bool			isListItemText_in, 
			int				size_in, 
			string			aditionalInfo_in
		) {
			name_					= name_in;
			friendlyname_			= friendlyName_in;
//			dbdescription_			= dbDescription_in;
			extendeddescription_	= extendedDescription_in;
			ispk_					= isPK_in;
			isidentity_				= isIdentity_in;
			isnullable_				= isNullable_in;
			defaultvalue_			= defaultValue_in;
			fk_tablename_			= fk_TableName_in;
			fk_fieldname_			= fk_FieldName_in;
			isconfig_name_			= isConfig_Name_in;
			isconfig_config_		= isConfig_Config_in;
			isconfig_datatype_		= isConfig_Datatype_in;
			isbool_					= isBool_in;
			isdatetime_				= isDateTime_in;
			isint_					= isInt_in;
			isdecimal_				= isDecimal_in;
			istext_					= isText_in;
			islistitemvalue_		= isListItemValue_in;
			islistitemtext_			= isListItemText_in;
			size_					= size_in;
			aditionalinfo_			= aditionalInfo_in;
		}
//		#endregion

		#region public string Name { get; }
		private string name_;

		/// <summary>
		/// Name
		/// </summary>
		public string Name {
			get { return name_; }
		}
		#endregion
		#region public string FriendlyName { get; }
		private string friendlyname_;

		/// <summary>
		/// Friendly name
		/// </summary>
		public string FriendlyName {
			get { return friendlyname_; }
		}
		#endregion
//        #region public string DBDescription { get; }
//        private string dbdescription_;
//
//        /// <summary>
//        /// Description at DataBase
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
			get { return extendeddescription_; }
		}
		#endregion
		#region public bool isPK { get; }
		private bool ispk_;

		/// <summary>
		/// Indicates if it is a Primary Key. True if it is a Primary Key, False if not.
		/// </summary>
		public bool isPK {
			get { return ispk_; }
		}
		#endregion
		#region public bool isIdentity { get; }
		private bool isidentity_;

		/// <summary>
		/// Indicates if it is a Sequence/Identity Seed. True if it is a Sequence/Identity Seed, False if not.
		/// </summary>
		public bool isIdentity {
			get { return isidentity_; }
		}
		#endregion
		#region public bool isNullable { get; }
		private bool isnullable_;

		/// <summary>
		/// Indicates if it allows null Values. True if it allows null Values, False if not.
		/// </summary>
		public bool isNullable {
			get { return isnullable_; }
		}
		#endregion
		#region public string DefaultValue { get; }
		private string defaultvalue_;

		/// <summary>
		/// Default Value.
		/// </summary>
		public string DefaultValue {
			get { return defaultvalue_; }
		}
		#endregion
		#region public string FK_TableName { get; }
		private string fk_tablename_;

		/// <summary>
		/// Foreign Key Table Name
		/// </summary>
		public string FK_TableName {
			get { return fk_tablename_; }
		}
		#endregion
		#region public string FK_FieldName { get; }
		private string fk_fieldname_;

		/// <summary>
		/// Foreign Key Field Name
		/// </summary>
		public string FK_FieldName {
			get { return fk_fieldname_; }
		}
		#endregion
		#region public bool isConfig_Name { get; }
		private bool isconfig_name_;

		/// <summary>
		/// Indicates if it represents a Config Name. True if it represents a Config Name, False if not.
		/// </summary>
		public bool isConfig_Name {
			get { return isconfig_name_; }
		}
		#endregion
		#region public bool isConfig_Config { get; }
		private bool isconfig_config_;

		/// <summary>
		/// Indicates if it represents a Config Config. True if it represents a Config Config, False if not.
		/// </summary>
		public bool isConfig_Config {
			get { return isconfig_config_; }
		}
		#endregion
		#region public bool isConfig_Datatype { get; }
		private bool isconfig_datatype_;

		/// <summary>
		/// Indicates if it represents a Config DataType. True if it represents a Config DataType, False if not.
		/// </summary>
		public bool isConfig_Datatype {
			get { return isconfig_datatype_; }
		}
		#endregion
		#region public bool isBool { get; }
		private bool isbool_;

		/// <summary>
		/// Indicates if it is a Boolean Value. True if it is a Boolean Value, False if not.
		/// </summary>
		public bool isBool {
			get { return isbool_; }
		}
		#endregion
		#region public bool isDateTime { get; }
		private bool isdatetime_;

		/// <summary>
		/// Indicates if it is a DateTime Value. True if it is a DateTime Value, False if not.
		/// </summary>
		public bool isDateTime {
			get { return isdatetime_; }
		}
		#endregion
		#region public bool isInt { get; }
		private bool isint_;

		/// <summary>
		/// Indicates if it is an Integer Value. True if it is an Integer Value, False if not.
		/// </summary>
		public bool isInt {
			get { return isint_; }
		}
		#endregion
		#region public bool isDecimal { get; }
		private bool isdecimal_;

		/// <summary>
		/// Indicates if it is a Decimal Value. True if it is a Decimal Value, False if not.
		/// </summary>
		public bool isDecimal {
			get { return isdecimal_; }
		}
		#endregion
		#region public bool isText { get; }
		private bool istext_;

		/// <summary>
		/// Indicates if it is a Text Value. True if it is a Text Value, False if not.
		/// </summary>
		public bool isText {
			get { return istext_; }
		}
		#endregion
//		#region public bool isListItemValue { get; }
		private bool islistitemvalue_;

		public bool isListItemValue {
			get { return islistitemvalue_; }
		}
//		#endregion
//		#region public bool isListItemText { get; }
		private bool islistitemtext_;

		public bool isListItemText {
			get { return islistitemtext_; }
		}
//		#endregion
//		#region public int Size { get; }
		private int size_;

		public int Size {
			get { return size_; }
		}
//		#endregion
//		#region public string AditionalInfo { get; }
		private string aditionalinfo_;

		public string AditionalInfo {
			get { return aditionalinfo_; }
		}
//		#endregion
	}
}
