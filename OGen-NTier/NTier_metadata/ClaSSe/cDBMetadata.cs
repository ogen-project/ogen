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
using System.Reflection;
using System.Collections;
using System.Xml;
using System.IO;
using OGen.lib.datalayer;
using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata : cClaSSe {
//		#region public cDBMetadata(...);
		public cDBMetadata(
			string xmlFileName_in, 
			string xmlObjectName_in
		) : this () {
			LoadState_fromFile(
				xmlFileName_in, 
				xmlObjectName_in
			);
		}
		public cDBMetadata(
			#region // ToDos: here!
			// parameterless constructor, should have:
			// - Namespace
			// - any db related arguments
			// alternatively (using xml configuration), should have.
			// - xml path
			#endregion
		) : base (
			null
		) {
			//#region ClaSSe...
			applicationname_ = string.Empty;
			namespace_ = string.Empty;
			//default_dbservertype_ = eDBServerTypes.invalid;
			//default_configmode_ = string.Empty;
			subappname_ = string.Empty;
			pseudoreflectionable_ = false;
			sqlscriptoption_ = eSQLScriptOptions.RunImmediately;
			//---
			dbs_ = new cDBMetadata_DBs(this, this);
			tables_ = new cDBMetadata_Tables(this, this);
			//#endregion
		}
//		#endregion

		#region Implementing - iClaSSe...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}", 
						this.GetType().Namespace,
						this.GetType().Name,
						name_in
					));
			}
		}
		#endregion
		#region public PropertyInfo[] Properties { get; }
		private static PropertyInfo[] properties__ = null;
		public override PropertyInfo[] Properties {
			get {
				if (properties__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return properties__;
			}
		}
		#endregion
		#region public ClaSSPropertyAttribute[] Attributes { get; }
		private static ClaSSPropertyAttribute[] attributes__ = null;
		public override ClaSSPropertyAttribute[] Attributes {
			get {
				if (attributes__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return attributes__;
			}
		}
		#endregion
		#endregion

		#region enums...
		#region public enum eMetadata;
		public enum eMetadata {
			All = 1,
			All_butDatabaseER = 2
		}
		#endregion
		#region public enum eSQLscriptOptions;
		public enum eSQLScriptOptions {
			OneScriptFile = 0,
			SeparateScriptFiles = 1,
			RunImmediately = 2,

			invalid = 3
		}
		#endregion
		#endregion


//		#region public static Hashtable Metacache { get; }
		private static Hashtable metacache__;
		public static Hashtable Metacache {
			get {
				if (metacache__ == null) {
					metacache__ = new Hashtable();
				}
				return metacache__;
			}
		}
//		#endregion


//		#region Properties - ClaSSe...
		#region public string ApplicationName { get; set; }
		private string applicationname_;

		[ClaSSPropertyAttribute("applicationName", ClaSSPropertyAttribute.eType.standard, true)]
		public string ApplicationName {
			get { return applicationname_; }
			set { applicationname_ = value; }
		}
		#endregion
		#region public string Namespace { get; set; }
		private string namespace_;

		[ClaSSPropertyAttribute("namespace", ClaSSPropertyAttribute.eType.standard, true)]
		public string Namespace {
			get { return namespace_; }
			set { namespace_ = value; }
		}
		#endregion
		//#region internal eDBServerTypes default_dbservertype_ { get; set; }
		//internal eDBServerTypes default_dbservertype_;
		//public  eDBServerTypes Default_DBServerType {
		//    get { return default_dbservertype_; }
		//    set { default_dbservertype_ = value; }
		//}

		//[ClaSSPropertyAttribute("default_DBServerType", ClaSSPropertyAttribute.eType.standard, true)]
		//private string default_dbservertype_reflection {
		//    get { return default_dbservertype_.ToString(); }
		//    set { default_dbservertype_ = OGen.lib.datalayer.utils.DBServerTypes.convert.FromName(value);}
		//}
		//#endregion
		//#region internal string default_configmode_ { get; set; }
		//internal string default_configmode_;
		//public  string Default_ConfigMode {
		//    get { return default_configmode_; }
		//    set { default_configmode_ = value; }
		//}

		//[ClaSSPropertyAttribute("default_ConfigMode", ClaSSPropertyAttribute.eType.standard, true)]
		//private string default_configmode_reflection {
		//    get { return default_configmode_; }
		//    set { default_configmode_ = value; }
		//}
		//#endregion
		#region public string SubAppName { get; set; }
		private string subappname_;

		[ClaSSPropertyAttribute("subAppName", ClaSSPropertyAttribute.eType.standard, true)]
		public string SubAppName {
			get { return subappname_; }
			set { subappname_ = value; }
		}
		#endregion
		#region public bool PseudoReflectionable { get; set; }
		private bool pseudoreflectionable_;
		public bool PseudoReflectionable {
			get { return pseudoreflectionable_; }
			set { pseudoreflectionable_ = value; }
		}

		[ClaSSPropertyAttribute("pseudoReflectionable", ClaSSPropertyAttribute.eType.standard, true)]
		private string pseudoreflectionable_reflection {
			get { return pseudoreflectionable_.ToString(); }
			set { pseudoreflectionable_ = bool.Parse(value); }
		}
		#endregion
		#region public eSQLScriptOptions SQLScriptOption { get; set; }
		private eSQLScriptOptions sqlscriptoption_;
		public eSQLScriptOptions SQLScriptOption {
			get { return sqlscriptoption_; }
			set { sqlscriptoption_ = value; }
		}

		[ClaSSPropertyAttribute("sqlScriptOption", ClaSSPropertyAttribute.eType.standard, true)]
		private string sqlscriptoption_reflection {
			get { return sqlscriptoption_.ToString(); }
			set { sqlscriptoption_ = OGen.NTier.lib.metadata.utils.SQLScriptOptions.convert.FromName(value); }
		}
		#endregion
		#region //public string GUIDSolution { get; set; }
//		private string guidsolution_;
//
//		[ClaSSPropertyAttribute("guidSolution", ClaSSPropertyAttribute.eType.standard, true)]
//		public string GUIDSolution {
//			get { return guidsolution_; }
//			set { guidsolution_ = value; }
//		}
		#endregion
		#region public string GUIDDatalayer { get; set; }
		private string guiddatalayer_;

		[ClaSSPropertyAttribute("guidDatalayer", ClaSSPropertyAttribute.eType.standard, true)]
		public string GUIDDatalayer {
			get { return guiddatalayer_; }
			set { guiddatalayer_ = value; }
		}
		#endregion
		#region public string GUIDDatalayer_UTs { get; set; }
		private string guiddatalayer_uts_;

		[ClaSSPropertyAttribute("guidDatalayer_UTs", ClaSSPropertyAttribute.eType.standard, true)]
		public string GUIDDatalayer_UTs {
			get { return guiddatalayer_uts_; }
			set { guiddatalayer_uts_ = value; }
		}
		#endregion
		#region public string GUIDBusinesslayer { get; set; }
		private string guidbusinesslayer_;

		[ClaSSPropertyAttribute("guidBusinesslayer", ClaSSPropertyAttribute.eType.standard, true)]
		public string GUIDBusinesslayer {
			get { return guidbusinesslayer_; }
			set { guidbusinesslayer_ = value; }
		}
		#endregion
		#region public string GUIDBusinesslayer_UTs { get; set; }
		private string guidbusinesslayer_uts_;

		[ClaSSPropertyAttribute("guidBusinesslayer_UTs", ClaSSPropertyAttribute.eType.standard, true)]
		public string GUIDBusinesslayer_UTs {
			get { return guidbusinesslayer_uts_; }
			set { guidbusinesslayer_uts_ = value; }
		}
		#endregion
		#region public string GUIDTest { get; set; }
		private string guidtest_;

		[ClaSSPropertyAttribute("guidTest", ClaSSPropertyAttribute.eType.standard, true)]
		public string GUIDTest {
			get { return guidtest_; }
			set { guidtest_ = value; }
		}
		#endregion
		#region public string FeedbackEmailAddress { get; set; }
		private string feedbackemailaddress_;

		[ClaSSPropertyAttribute("feedbackEmailAddress", ClaSSPropertyAttribute.eType.standard, true)]
		public string FeedbackEmailAddress {
			get { return feedbackemailaddress_; }
			set { feedbackemailaddress_ = value; }
		}
		#endregion
		#region public string CopyrightText { get; set; }
		private string copyrighttext_;

		[ClaSSPropertyAttribute("copyrightText", ClaSSPropertyAttribute.eType.standard, true)]
		public string CopyrightText {
			get { return copyrighttext_; }
			set { copyrighttext_ = value; }
		}
		#endregion
		#region public string CopyrightTextLong { get; set; }
		private string copyrighttextlong_;

		[ClaSSPropertyAttribute("copyrightTextLong", ClaSSPropertyAttribute.eType.standard, true)]
		public string CopyrightTextLong {
			get { return copyrighttextlong_; }
			set { copyrighttextlong_ = value; }
		}
		#endregion
		//---
		#region private iDBMetadata_DBs dbs_ { get; set; }
		private iDBMetadata_DBs dbs_;

		[ClaSSPropertyAttribute("dbs", ClaSSPropertyAttribute.eType.aggregate, true)]
		public iDBMetadata_DBs DBs {
			get { return dbs_; }
		}
		#endregion
		#region private iDBMetadata_Tables tables_ { get; set; }
		private iDBMetadata_Tables tables_;

		[ClaSSPropertyAttribute("tables", ClaSSPropertyAttribute.eType.aggregate, true)]
		public iDBMetadata_Tables Tables {
			get { return tables_; }
		}
		#endregion
//		#endregion

		//#region Methods...
		//#region public string Default_Connectionstring();
		//public string Default_Connectionstring() {
		//    return DBs[Default_DBServerType].Connections[Default_ConfigMode].Connectionstring;
		//}
		//#endregion
		#region public string[] ConfigModes();
		public string[] ConfigModes() {
			ArrayList _configmodes = new ArrayList();
			for (int d = 0; d < dbs_.Count; d++) {
				for (int c = 0; c < dbs_[d].Connections.Count; c++) {
					if (!_configmodes.Contains(
						dbs_[d].Connections[c].ConfigMode
					)) {
						_configmodes.Add(
							dbs_[d].Connections[c].ConfigMode
						);
					}
				}
			}
			return (string[])_configmodes.ToArray(typeof(string));
		}
		#endregion
//		#region public void LoadState_fromDB(...);
		public delegate void dLoadState_fromDB(string message_in, bool onANewLine_in);
		public void LoadState_fromDB(
			dLoadState_fromDB	notifyBack_in, 
			eDBServerTypes		DBServerType_in, 
			string				Connectionstring_in, 
			string				subAppName_in, 
			bool				clear_in
		) {
			const string OGEN_SP0__GETTABLEFIELDS = "OGen_sp0__getTableFields";
			const string OGEN_SP0__GETTABLES = "OGen_sp0__getTables";
			bool _exits_getTables = false;
			bool _exits_getTableFields = false;

//			#region for (...) Tables.Add();
			cDBConnection _connection 
				= new cDBConnection(
					DBServerType_in, 
					Connectionstring_in
				);
			_exits_getTables = _connection.SQLStoredProcedure_exists(OGEN_SP0__GETTABLES);
			_exits_getTableFields = _connection.SQLStoredProcedure_exists(OGEN_SP0__GETTABLEFIELDS);
			cDBTable[] _tables_aux = _connection.getTables(
				subAppName_in,
				_exits_getTables 
					? OGEN_SP0__GETTABLES
					: string.Empty
			);

if (clear_in)
			tables_.Clear();
			for (int t = 0; t < _tables_aux.Length; t++) {


// ToDos: here! virtual names
//for (int ) {
//}


				int T = tables_.Add(_tables_aux[t].Name, true);

if (notifyBack_in != null) notifyBack_in(string.Format("#{0}/{1} - {2}", t + 1, _tables_aux.Length, _tables_aux[t].Name), true);

				tables_[T].isVirtualTable = _tables_aux[t].isVirtualTable;
				tables_[T].DBDescription = _tables_aux[t].DBDescription;


// ToDos: here! virtual names
//int TD = tables_[T].DBs.Add(
//    _connection.DBServerType,
//    _tables_aux[t].Name,
//    true
//);


				cDBTableField[] _fields_aux = _connection.getTableFields(
					_tables_aux[t].Name,
					_exits_getTables 
						? OGEN_SP0__GETTABLEFIELDS
						: string.Empty
				);
if (clear_in)
				tables_[T].Fields.Clear();
				for (int f = 0; f < _fields_aux.Length; f++) {
					int F = tables_[T].Fields.Add(_fields_aux[f].Name, true);

					tables_[T].Fields[F].Name				= _fields_aux[f].Name;
					tables_[T].Fields[F].isIdentity			= _fields_aux[f].isIdentity;
					tables_[T].Fields[F].isPK				= _fields_aux[f].isPK;
					tables_[T].Fields[F].FK_TableName		= _fields_aux[f].FK_TableName;
					tables_[T].Fields[F].FK_FieldName		= _fields_aux[f].FK_FieldName;
					tables_[T].Fields[F].isNullable			= _fields_aux[f].isNullable;
					tables_[T].Fields[F].Size				= _fields_aux[f].Size;
					tables_[T].Fields[F].Numeric_Precision	= _fields_aux[f].Numeric_Precision;
					tables_[T].Fields[F].Numeric_Scale		= _fields_aux[f].Numeric_Scale;
					//tables_[T].Fields[F].DBDescription		= _fields_aux[f].DBDescription;
					//tables_[T].Fields[F].DBDefaultValue		= _fields_aux[f].DBDefaultValue;
					//tables_[T].Fields[F].DBCollationName	= _fields_aux[f].DBCollationName;
					//---


					int FD = tables_[T].Fields[F].DBs.Add(
						_connection.DBServerType, 
						true
					);
					tables_[T].Fields[F].DBs[FD].DBType_inDB_name	= _fields_aux[f].DBType_inDB_name;
					tables_[T].Fields[F].DBs[FD].DBDescription		= _fields_aux[f].DBDescription;
					tables_[T].Fields[F].DBs[FD].DBDefaultValue		= _fields_aux[f].DBDefaultValue;
					tables_[T].Fields[F].DBs[FD].DBCollationName	= _fields_aux[f].DBCollationName;
					#region //oldstuff...
					//tables_[T].Fields[F].DBType_inDB_name	= _fields_aux[f].DBType_inDB_name;
					//tables_[T].Fields[F].Size				= _fields_aux[f].Size;
					#endregion


				}
				_fields_aux = null;
			}
			_tables_aux = null;
//			#endregion
		}
//		#endregion
		#region public void SaveState_toFile(...);
		public void SaveState_toFile(string fileName_in) {
			base.SaveState_toFile(fileName_in, root4xml);
		}
		#endregion
		//#region public void LoadState_fromFile(...);
		public const string root4xml = "metadata";
		public void LoadState_fromFile(string fileName_in) {
			base.LoadState_fromFile(fileName_in, root4xml);
		}
		public void LoadState_fromFile(
			string fileName_in, 
			eMetadata metadata_in
		) {
//			#region ...
			cDBMetadata _xmlFile_metadata;
			switch (metadata_in) {
				case eMetadata.All:
					_xmlFile_metadata = this;
					break;
				case eMetadata.All_butDatabaseER:
					_xmlFile_metadata = new cDBMetadata();
					//_xmlFile_metadata.default_dbservertype_ = default_dbservertype_;
					//_xmlFile_metadata.default_configmode_ = default_configmode_;
					break;
				default:
					throw new Exception("not implemented!");
			}

			_xmlFile_metadata.LoadState_fromFile(fileName_in, root4xml);

			switch (metadata_in) {
				case eMetadata.All:
					#region this = _xmlFile_metadata;
					#endregion
					break;
				case eMetadata.All_butDatabaseER:
//			#endregion

					//---
					ApplicationName			= _xmlFile_metadata.ApplicationName;
					Namespace				= _xmlFile_metadata.Namespace;
					//default_dbservertype_	= _xmlFile_metadata.default_dbservertype_;
					//default_configmode_		= _xmlFile_metadata.default_configmode_;
					PseudoReflectionable	= _xmlFile_metadata.PseudoReflectionable;
					SubAppName				= _xmlFile_metadata.SubAppName;
					SQLScriptOption			= _xmlFile_metadata.SQLScriptOption;
					//guidsolution_			= _xmlFile_metadata.guidsolution_;
					guiddatalayer_			= _xmlFile_metadata.guiddatalayer_;
					guiddatalayer_uts_		= _xmlFile_metadata.guiddatalayer_uts_;
					guidbusinesslayer_		= _xmlFile_metadata.guidbusinesslayer_;
					guidbusinesslayer_uts_	= _xmlFile_metadata.guidbusinesslayer_uts_;
					guidtest_				= _xmlFile_metadata.guidtest_;
					feedbackemailaddress_	= _xmlFile_metadata.feedbackemailaddress_;
					copyrighttext_			= _xmlFile_metadata.copyrighttext_;
					copyrighttextlong_		= _xmlFile_metadata.copyrighttextlong_;
					//---

					dbs_.CopyFrom(
						_xmlFile_metadata.dbs_
					);

					for (int t = 0; t < _xmlFile_metadata.Tables.Count; t++) {
						int _T = tables_.Search(_xmlFile_metadata.Tables[t].Name);
						if (_T != -1) {
							//---
							tables_[_T].FriendlyName = _xmlFile_metadata.Tables[t].FriendlyName;
//							tables_[_T].DBDescription = _xmlFile_metadata.Tables[t].DBDescription;
							tables_[_T].ExtendedDescription = _xmlFile_metadata.Tables[t].ExtendedDescription;
							//---
							tables_[_T].Searches.CopyFrom(
								_xmlFile_metadata.Tables[t].Searches
							);
							//---
							tables_[_T].Updates.CopyFrom(
								_xmlFile_metadata.Tables[t].Updates
							);
							//---
							// USE isVirtualTable FROM DB, NOT XML:
							//tables_[_T].isVirtualTable = _xmlFile_metadata.Tables[t].isVirtualTable;
							tables_[_T].isConfig = _xmlFile_metadata.Tables[t].isConfig;
							//---

							for (int f = 0; f < _xmlFile_metadata.Tables[t].Fields.Count; f++) {
								int _F = tables_[_T].Fields.Search(_xmlFile_metadata.Tables[t].Fields[f].Name);
								if (_F != -1) {
									//---
									tables_[_T].Fields[_F].FriendlyName = _xmlFile_metadata.Tables[t].Fields[f].FriendlyName;
//									tables_[_T].Fields[_F].DBDescription = _xmlFile_metadata.Tables[t].Fields[f].DBDescription;
//									tables_[_T].Fields[_F].DBDefaultValue = _xmlFile_metadata.Tables[t].Fields[f].DBDefaultValue;
									tables_[_T].Fields[_F].ExtendedDescription = _xmlFile_metadata.Tables[t].Fields[f].ExtendedDescription;
									tables_[_T].Fields[_F].AditionalInfo = _xmlFile_metadata.Tables[t].Fields[f].AditionalInfo;
									//---
									tables_[_T].Fields[_F].isListItemText = _xmlFile_metadata.Tables[t].Fields[f].isListItemText;
									tables_[_T].Fields[_F].isListItemValue = _xmlFile_metadata.Tables[t].Fields[f].isListItemValue;
									//---
									tables_[_T].Fields[_F].DefaultValue = _xmlFile_metadata.Tables[t].Fields[f].DefaultValue;
									//---
									tables_[_T].Fields[_F].isPseudoIdentity = _xmlFile_metadata.Tables[t].Fields[f].isPseudoIdentity;
									//---
									if (tables_[_T].isVirtualTable) {
										tables_[_T].Fields[_F].isIdentity = _xmlFile_metadata.Tables[t].Fields[f].isIdentity;
										tables_[_T].Fields[_F].isPK = _xmlFile_metadata.Tables[t].Fields[f].isPK;

										tables_[_T].Fields[_F].FK_TableName = _xmlFile_metadata.Tables[t].Fields[f].FK_TableName;
										tables_[_T].Fields[_F].FK_FieldName = _xmlFile_metadata.Tables[t].Fields[f].FK_FieldName;
									}
									//---
									tables_[_T].Fields[_F].isConfig_Name = _xmlFile_metadata.Tables[t].Fields[f].isConfig_Name;
									tables_[_T].Fields[_F].isConfig_Config = _xmlFile_metadata.Tables[t].Fields[f].isConfig_Config;
									tables_[_T].Fields[_F].isConfig_Datatype = _xmlFile_metadata.Tables[t].Fields[f].isConfig_Datatype;
									//---
									//...
									//---
								} else {
//NotifyBase(string.Format("HEY! someone changed field:{0}.{1} and I've lost it's ListItems", xmlFile_metadata.Tables[t].Name, xmlFile_metadata.Tables[t].Fields[f].Name));
								}
							}
						} else {
//NotifyBase(string.Format("HEY! someone changed table:{0} and I've lost it's Searches", xmlFile_metadata.Tables[t].Name));
						}
					}

			#region ...
					break;
				default:
					throw new Exception("not implemented!");
			}
			#endregion
		}
		//#endregion
		//#endregion
	}
}