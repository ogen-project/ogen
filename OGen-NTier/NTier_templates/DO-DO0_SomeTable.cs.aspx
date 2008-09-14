<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table
	= _aux_db_metadata.Tables.TableCollection[
		_arg_TableName
	];
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table
	= _aux_db_table.parallel_ref;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

string _aux_xx_field_name;

OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update;
/*
OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update 
	= _aux_ex_table.TableUpdates.TableUpdateCollection[_arg_UpdateName];


XS_tableSearchType _aux_ex_search
	= _aux_ex_table.TableSearches.TableSearchCollection[_arg_SearchName];
XS_tableSearchUpdateType _aux_ex_update 
	= _aux_ex_search.TableSearchUpdates.TableSearchUpdateCollection[_arg_UpdateName];
*/
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_ex_metadata.CopyrightText != string.Empty) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Data;
using System.Xml.Serialization;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_db_table.Name%> DataObject which provides access to <%=_aux_db_table.Name%> <%=(_aux_db_table.isVirtualTable) ? "view" : "table"%> at Database.<%--
#if NET_1_1
	/// <note type="implementnotes">
	/// Access must be made via <see cref="DO_<%=_aux_db_table.Name%>">DO_<%=_aux_db_table.Name%></see>.
	/// </note>
#endif--%>
	/// </summary>
	[DOClassAttribute("<%=_aux_db_table.Name%>", "<%=_aux_ex_table.FriendlyName%>", "<%=_aux_ex_table.DBDescription%>", "<%=_aux_ex_table.ExtendedDescription%>", <%=_aux_db_table.isVirtualTable.ToString().ToLower()%>, <%=_aux_ex_table.isConfig.ToString().ToLower()%>)]
	public 
#if !NET_1_1
		partial 
#else
		abstract 
#endif
		class 
#if !NET_1_1
		DO_<%=_aux_db_table.Name%> 
#else
		DO0_<%=_aux_db_table.Name%> 
#endif
		: DO__base {
		#region public DO_<%=_aux_db_table.Name%>();
#if !NET_1_1
		///
		public DO_<%=_aux_db_table.Name%>
#else
		internal DO0_<%=_aux_db_table.Name%>
#endif
		() : base(
#if !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBServerType, 
#if !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBConnectionstring,
#if !NET_1_1
			DO__utils
#else
			DO0__utils
#endif
			.DBLogfile
		) {
			clrObject();
			Fields.haschanges_ = false;
		}
#if !NET_1_1
			/// <summary>
			/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
			/// </summary>
			/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
			public DO_<%=_aux_db_table.Name%>
#else
			internal DO0_<%=_aux_db_table.Name%>
#endif
		(
			DBConnection connection_in
		) : base(
			connection_in
		) {
			clrObject();
			Fields.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public FO0_<%=_aux_db_table.Name%> Fields { get; set; }
		internal SO0_<%=_aux_db_table.Name%> fields_;

		public SO0_<%=_aux_db_table.Name%> Fields {
			get { return fields_; }
			set { fields_ = value; }
		}
		#endregion
		#region public RO0_<%=_aux_db_table.Name%> Record { get; }
		private RO0_<%=_aux_db_table.Name%> record__;

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		public RO0_<%=_aux_db_table.Name%> Record {
			get {
				if (record__ == null) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...
					record__ = new RO0_<%=_aux_db_table.Name%>(this);
				}
				return record__;
			}
		}
		#endregion
		#endregion

		#region Methods...
		public override DBConnection DBConnection_createInstance(
			string dbServerType_in, 
			string connectionstring_in, 
			string logfile_in
		) {
			return 
				#if !NET_1_1
				DO__utils
				#else
				DO0__utils
				#endif
					.DBConnection_createInstance(
						dbServerType_in, 
						connectionstring_in, 
						logfile_in
					);
		}
		#region public SC0_<%=_aux_db_table.Name%> Serialize();
		public SO0_<%=_aux_db_table.Name%> Serialize() {
			return Fields;
		}
		#endregion
		#region public void clrObject();
		/// <summary>
		/// Clears all DO0_<%=_aux_db_table.Name%> properties, assigning them with their appropriate default property value.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void clrObject() {<%--
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
				_aux_ex_table = _aux_db_field.parallel_ref;
				if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
			<%=_aux_db_field.Name%>_isNull = true;<%
				} else {%><%=""%>
			<%=_aux_db_field.Name%> = <%=(_aux_ex_field.DefaultValue == "") ? _aux_db_field.DBType_generic.FWEmptyValue : _aux_ex_field.DefaultValue%>;<%
				}
			}--%>
			Fields = new SO0_<%=_aux_db_table.Name%>();
		}
		#endregion<%
if (!_aux_db_table.isVirtualTable) {%>
		#region public bool getObject(...);
		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database and assigns them to the appropriate DO0_<%=_aux_db_table.Name%> property.
		/// </summary>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool getObject() {
			return getObject(<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
				Fields.<%=_aux_db_field.Name%><%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			);
		}
		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database and assigns them to the appropriate DO0_<%=_aux_db_table.Name%> property.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool getObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {<%
			if (_aux_db_table.hasIdentityKey) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey];%>
			if (<%=_aux_db_field.Name%>_in != <%=_aux_db_field.DBType_generic.FWEmptyValue%>) {<%
			}%>
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.<%=(_aux_db_field.isPK) ? "Input" : ""%>Output, <%=(_aux_db_field.isPK) ? _aux_db_field.Name + "_in" : "null"%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
					}%>
				};
				base.Connection.Execute_SQLFunction("sp0_<%=_aux_db_table.Name%>_getObject", _dataparameters);

				if (_dataparameters[<%=_aux_db_table.firstKey%>].Value != DBNull.Value) {<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					if (_dataparameters[<%=f%>].Value == System.DBNull.Value) {<%
						if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
						Fields.<%=_aux_db_field.Name%>_isNull = true;<%
						} else {%><%=""%>
						Fields.<%=_aux_db_field.Name%> = <%=_aux_db_field.DBType_generic.FWEmptyValue%>;<%
						}%>
					} else {
						Fields.<%=_aux_db_field.Name%> = (<%=_aux_db_field.DBType_generic.FWType%>)_dataparameters[<%=f%>].Value;
					}<%
					}%>

					Fields.haschanges_ = false;
					return true;
				}<%
			if (_aux_db_table.hasIdentityKey) {%>
			}<%
			}%>

			//clrObject();
			//haschanges_ = false;

			return false;
		}
		#endregion
		#region public void delObject(...);
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject() {
			delObject(<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
				Fields.<%=_aux_db_field.Name%><%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			);
		}
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		public 
#if NET_1_1
			virtual 
#endif
		void delObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_db_field.Name%>_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			base.Connection.Execute_SQLFunction("sp0_<%=_aux_db_table.Name%>_delObject", _dataparameters);

			clrObject();
		}
		#endregion
		#region public bool isObject(...);
		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database
		/// </summary>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject() {
			return isObject(<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
				Fields.<%=_aux_db_field.Name%><%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			);
		}
		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public 
#if NET_1_1
			virtual 
#endif
		bool isObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_db_field.Name%>_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : "" %><%
				}%>
			};

			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion<%
		if (!_aux_db_table.hasIdentityKey) {%>
		#region public bool setObject(...);
		/// <summary>
		/// Inserts/Updates <%=_aux_db_table.Name%> values into/on Database. Inserts if <%=_aux_db_table.Name%> doesn't exist or Updates if <%=_aux_db_table.Name%> already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public 
#if NET_1_1
			virtual 
#endif
			bool setObject(bool forceUpdate_in<%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? ", out bool ConstraintExist_out" : ""%>) {
			<%if (!_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {
				%>bool ConstraintExist_out;
			<%}
			%>if (forceUpdate_in || Fields.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.<%=(_aux_db_field.isIdentity) ? "Out" : "In"%>put, <%=
(_aux_db_field.isIdentity) 
	?  "null" 
	: ((_aux_db_field.isNullable) 
		? "Fields." + _aux_db_field.Name + "_isNull ? null : (object)Fields." + _aux_db_field.Name 
		: "Fields." + _aux_db_field.Name
	)%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
					}%>

					//base.Connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)<%
					if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>, 
					//base.Connection.newDBDataParameter("ConstraintExist", DbType.Boolean, ParameterDirection.Output, 0, 1)<%
					}%>
					base.Connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				base.Connection.Execute_SQLFunction(
					"sp0_<%=_aux_db_table.Name%>_setObject", 
					_dataparameters
				);

				ConstraintExist_out = (((int)_dataparameters[<%=_aux_db_table.TableFields.TableFieldCollection.Count%>].Value & 2) == 1);
				if (!ConstraintExist_out) {
					Fields.haschanges_ = false;<%



					if (_aux_ex_table.isConfig) { %>

					#region DO__utils...._reset();<%
						string NameField;
						string ConfigField;
						string DatatypeField;
						System.Data.DataTable ConfigTable;
						//for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
						//	_aux_table = _aux_metadata.Tables[t];
						//	if (_aux_ex_table.isConfig) {
								NameField = "";
								ConfigField = "";
								DatatypeField = "";
								for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
									_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
									_aux_ex_field = _aux_db_field.parallel_ref;
									if (_aux_ex_field.isConfig_Name) {
										NameField = _aux_db_field.Name;
										continue;
									}
									if (_aux_ex_field.isConfig_Config) {
										ConfigField = _aux_db_field.Name;
										continue;
									}
									if (_aux_ex_field.isConfig_Datatype) {
										DatatypeField = _aux_db_field.Name;
										continue;
									}
								}
								DBConnection connection = DBConnectionsupport.CreateInstance(
									// ToDos: here! .net fw 2.0 specific
									(DBServerTypes)Enum.Parse(
										typeof(DBServerTypes), 
										_aux_ex_metadata.DBs.DB_FirstDefaultAvailable.DBServerType
									), 
									_aux_ex_metadata.DBs.DBConnection_FirstDefaultAvailable.Connectionstring
								);
								ConfigTable = connection.Execute_SQLQuery_returnDataTable(
									string.Format(
										"SELECT {4}{0}{4}, {4}{1}{4}, {4}{2}{4} FROM {4}{3}{4} ORDER BY {4}{0}{4}",
										/*00*/ NameField,
										/*01*/ ConfigField,
										/*02*/ DatatypeField,
										/*03*/ _aux_db_table.Name, 
#if MySQL
										/*04*/ (_aux_ex_metadata.DBs.DBCollection.FirstDefaultAvailable_DBServerType() == DBServerTypes.MySQL) ? "`" :"\""
#else
										/*04*/ "\""
#endif
									)
								);%>
					switch (Fields.<%=NameField%>) {<%
								for (int r = 0; r < ConfigTable.Rows.Count; r++) {%>
						case "<%=ConfigTable.Rows[r][NameField]%>": {
#if !NET_1_1
							DO__utils
#else
							DO0__utils
#endif
							.<%=ConfigTable.Rows[r][NameField]%>_reset();
							break;
						}<%
								}%>
					}<%
						//	}
						//}%>
					#endregion<%



					}%>
				}

				return (((int)_dataparameters[<%=_aux_db_table.TableFields.TableFieldCollection.Count%>].Value & 1) != 1);
			} else {
				ConstraintExist_out = false;

				return  false;
			}
		}
		#endregion<%
		} else {%>
		#region public <%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].DBType_generic.FWType%> insObject(...);
		/// <summary>
		/// Inserts <%=_aux_db_table.Name%> values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and insertion failed, and False if no constraint and insertion was successful</param><%
		}%>
		/// <returns>insertion sequence/identity seed</returns>
		public 
#if NET_1_1
			virtual 
#endif
		<%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].DBType_generic.FWType%> insObject(
			bool selectIdentity_in<%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>, 
			out bool constraintExist_out<%
			} %>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.<%=(_aux_db_field.isIdentity) ? "Out" : "In"%>put, <%=
(_aux_db_field.isIdentity) 
	? "null" 
	: ((_aux_db_field.isNullable) 
		? "Fields." + _aux_db_field.Name + "_isNull ? null : (object)Fields." + _aux_db_field.Name 
		: "Fields." + _aux_db_field.Name
	)%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}%>

				base.Connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			base.Connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_insObject", 
				_dataparameters
			);

			<%
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey];
			_aux_ex_field = _aux_db_field.parallel_ref;
			%>Fields.<%=_aux_db_field.Name%> = (<%=_aux_db_field.DBType_generic.FWType%>)_dataparameters[<%=_aux_db_table.IdentityKey%>].Value;<%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
			constraintExist_out = (Fields.<%=_aux_db_field.Name%> == -1L);
			if (!constraintExist_out) {
				Fields.haschanges_ = false;
			}<%
			} else {%>
			Fields.haschanges_ = false;
			<%}%>

			return Fields.<%=_aux_db_field.Name%>;
		}
		#endregion
		#region public void updObject(...);
		/// <summary>
		/// Updates <%=_aux_db_table.Name%> values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param><%
		}%>
		public 
#if NET_1_1
			virtual 
#endif
		void updObject(bool forceUpdate_in<%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? ", out bool constraintExist_out" : ""%>) {
			if (forceUpdate_in || Fields.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=
((_aux_db_field.isNullable) 
	? "Fields." + _aux_db_field.Name + "_isNull ? null : (object)Fields." + _aux_db_field.Name 
	: "Fields." + _aux_db_field.Name
)%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=((f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) || (_aux_ex_table.TableSearches.hasExplicitUniqueIndex)) ? ", " : ""%><%
					}%><%
					if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>

					base.Connection.newDBDataParameter("ConstraintExist_", DbType.Boolean, ParameterDirection.Output, null, 1)<%
					}%>
				};
				base.Connection.Execute_SQLFunction(
					"sp0_<%=_aux_db_table.Name%>_updObject", 
					_dataparameters
				);
				<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
				constraintExist_out = <%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? "(bool)_dataparameters[" + (_aux_db_table.TableFields.TableFieldCollection.Count) + "].Value" : "false"%>;
				if (!constraintExist_out) {
					Fields.haschanges_ = false;
				}<%
				} else {
				%>Fields.haschanges_ = false;<%
				}%>
			<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
			} else {
				constraintExist_out = false;<%
			}%>
			}
		}
		#endregion<%
		}
		}%>
		#endregion
		#region Methods - Search...<%









		for (int s = 0; s < _aux_ex_table.TableSearches.TableSearchCollection.Count; s++) {
			if (!_aux_ex_table.TableSearches.TableSearchCollection[s].isRange) {%>
		#region public void ???Object_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>
		#region public bool getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database (based on the search condition) and assigns them to the appropriate DO0_<%=_aux_db_table.Name%> property.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public bool getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				base.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Output, null, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			base.Connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters
			);

			if (_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count + _aux_db_table.firstKey%>].Value != DBNull.Value) {<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				if (_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count + f%>].Value == System.DBNull.Value) {<%
					if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
					Fields.<%=_aux_db_field.Name%>_isNull = true;<%
					} else {%><%=""%>
					Fields.<%=_aux_db_field.Name%> = <%=_aux_db_field.DBType_generic.FWEmptyValue%>;<%
					}%>
				} else {
					Fields.<%=_aux_db_field.Name%> = (<%=_aux_db_field.DBType_generic.FWType%>)_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count + f%>].Value;
				}<%
				}%>

				Fields.haschanges_ = false;
				return true;
			}

			//clrObject();
			//Fields.haschanges_ = false;

			return false;
		}
		#endregion<%
		if (!_aux_db_table.isVirtualTable) {%>
		#region public bool delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database (based on the search condition).
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"> <%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> existed and was Deleted at Database, False if it didn't exist</returns>
		public bool delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				base.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}%>

				base.Connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			base.Connection.Execute_SQLFunction("sp0_<%=_aux_db_table.Name%>_delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", _dataparameters);

			return ((bool)_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count%>].Value);
		}
		#endregion<%
		}%>
		#region public bool isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database (based on the search condition).
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public bool isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				base.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			return (bool)base.Connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
		}
		#endregion
		#endregion<%
			}
		}









%>
		#endregion
		#region Methods - Updates...<%
		for (int u = 0; u < _aux_ex_table.TableUpdates.TableUpdateCollection.Count; u++) {
			_aux_ex_update = _aux_ex_table.TableUpdates.TableUpdateCollection[u];%>
		#region public void updObject_<%=_aux_ex_update.Name%>(...);
		/// <summary>
		/// Updates <%=_aux_db_table.Name%> specific(only) values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param><%
		} %>
		public 
#if NET_1_1
			virtual 
#endif
		void updObject_<%=_aux_ex_update.Name%>(bool forceUpdate_in<%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? ", out bool constraintExist_out" : ""%>) {
			if (forceUpdate_in || Fields.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					base.Connection.newDBDataParameter("<%=_aux_db_field.Name%>", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%="Fields." + _aux_db_field.Name%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
					}
					for (int f = 0; f < _aux_ex_update.TableUpdateParameters.TableFieldRefCollection.Count; f++) {
						_aux_ex_field = _aux_ex_update.TableUpdateParameters.TableFieldRefCollection[f].TableField_ref;
						_aux_db_field = _aux_ex_field.parallel_ref;%>
					base.Connection.newDBDataParameter("<%=_aux_ex_field.Name%>_update", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%="Fields." + _aux_ex_field.Name%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=((f != _aux_ex_update.TableUpdateParameters.TableFieldRefCollection.Count - 1) || (_aux_ex_table.TableSearches.hasExplicitUniqueIndex)) ? ", " : ""%><%
					}
					if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>

					base.Connection.newDBDataParameter("ConstraintExist", DbType.Boolean, ParameterDirection.Output, null, 1)<%
					}%>
				};
				base.Connection.Execute_SQLFunction(
					"sp0_<%=_aux_db_table.Name%>_updObject_<%=_aux_ex_update.Name%>", 
					_dataparameters
				);
				<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
				constraintExist_out = <%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? "(bool)_dataparameters[" + (_aux_db_table.TableFields.TableFieldCollection.Count) + "].Value" : "false"%>;
				if (!constraintExist_out) {
					Fields.haschanges_ = false;
				}<%
				} else {
				%>Fields.haschanges_ = false;<%
				}%>
			<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
			} else {
				constraintExist_out = false;<%
			}%>
			}
		}
		#endregion<%
		}%>
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>
