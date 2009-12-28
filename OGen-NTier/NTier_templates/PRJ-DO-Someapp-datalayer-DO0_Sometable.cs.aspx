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
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataBusiness" %><%
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
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

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

#endregion
//-----------------------------------------------------------------------------------------
if (_aux_ex_metadata.CopyrightText != string.Empty) {
	if (_aux_ex_metadata.CopyrightTextLong == string.Empty) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
#endregion
<%
	} else {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
	}
}%>using System;
using System.Data;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.shared.structures;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_db_table.Name%> DataObject which provides access to <%=_aux_db_table.Name%>'s Database table.
	/// </summary>
	[DOClassAttribute("<%=_aux_db_table.Name%>", "", "", "", false, false)]
	public 
#if !NET_1_1
		partial 
#endif
		class 
#if NET_1_1
			DO0_<%=_aux_db_table.Name%> 
#else
			DO_<%=_aux_db_table.Name%> 
#endif
	{

	 	#region Methods...<%
if (!_aux_db_table.isVirtualTable) {%>
		#region public static SO_<%=_aux_db_table.Name%> getObject(...);
		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database and assigns them to the appropriate DO0_<%=_aux_db_table.Name%> property.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <returns>null if <%=_aux_db_table.Name%> doesn't exists at Database</returns>
		public static SO_<%=_aux_db_table.Name%> getObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			return getObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
				<%=_aux_db_field.Name%>_in, <%
			}%>
				null
			);
		}

		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database and assigns them to the appropriate DO_<%=_aux_db_table.Name%> property.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if <%=_aux_db_table.Name%> doesn't exists at Database</returns>
		public static SO_<%=_aux_db_table.Name%> getObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			SO_<%=_aux_db_table.Name%> _output = null;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.<%=(_aux_db_field.isPK) ? "Input" : ""%>Output, <%=(_aux_db_field.isPK) ? _aux_db_field.Name + "_in" : "null"%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_connection.Execute_SQLFunction("sp0_<%=_aux_db_table.Name%>_getObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[<%=_aux_db_table.firstKey%>].Value != DBNull.Value) {
				_output = new SO_<%=_aux_db_table.Name%>();
<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				if (_dataparameters[<%=f%>].Value == System.DBNull.Value) {<%
					if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
					_output.<%=_aux_db_field.Name%>_isNull = true;<%
					} else {%><%=""%>
					_output.<%=_aux_db_field.Name%> = <%=_aux_db_field.DBType_generic.FWEmptyValue%>;<%
					}%>
				} else {
					_output.<%=_aux_db_field.Name%> = (<%=_aux_db_field.DBType_generic.FWType%>)_dataparameters[<%=f%>].Value;
				}<%
				}%>

				_output.haschanges_ = false;
				return _output;
			}

			return null;
		}
		#endregion
		#region public static void delObject(...);
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		public static void delObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			delObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
				<%=_aux_db_field.Name%>_in, <%
			}%>
				null
			);
		}

		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_db_field.Name%>_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_connection.Execute_SQLFunction("sp0_<%=_aux_db_table.Name%>_delObject", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion
		#region public static bool isObject(...);
		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public static bool isObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			return isObject(<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
					_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
				<%=_aux_db_field.Name%>_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_field.Name%></param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public static bool isObject(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
				_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_db_field.Name%>_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : "" %><%
				}%>
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_isObject", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion<%
		if (!_aux_db_table.hasIdentityKey) {%>
		#region public static bool setObject(...);
		/// <summary>
		/// Inserts/Updates <%=_aux_db_table.Name%> values into/on Database. Inserts if <%=_aux_db_table.Name%> doesn't exist or Updates if <%=_aux_db_table.Name%> already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in, 
			bool forceUpdate_in<%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @", 
			out bool ConstraintExist_out" : ""%>
		) {
			return setObject(
				<%=_aux_db_table.Name%>_in, 
				forceUpdate_in, <%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @"
				out ConstraintExist_out, " : ""%>
				null
			);
		}

		/// <summary>
		/// Inserts/Updates <%=_aux_db_table.Name%> values into/on Database. Inserts if <%=_aux_db_table.Name%> doesn't exist or Updates if <%=_aux_db_table.Name%> already exists.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if it didn't exist (INSERT), and False if it did exist (UPDATE)</returns>
		public static bool setObject(
			SO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in, 
			bool forceUpdate_in, <%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @"
			out bool ConstraintExist_out, " : ""%>
			DBConnection dbConnection_in
		) {
			<%if (!_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {
				%>bool ConstraintExist_out;
			<%}
			%>if (forceUpdate_in || <%=_aux_db_table.Name%>_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.<%=(_aux_db_field.isIdentity) ? "Out" : "In"%>put, <%=
						(_aux_db_field.isIdentity) 
							?  "null" 
							: ((_aux_db_field.isNullable) 
								? _aux_db_table.Name + "_in." + _aux_db_field.Name + "_isNull ? null : (object)" + _aux_db_table.Name + "_in." + _aux_db_field.Name 
								: _aux_db_table.Name + "_in." + _aux_db_field.Name
							)%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
					}%>

					//_connection.newDBDataParameter("Exists", DbType.Boolean, ParameterDirection.Output, 0, 1)<%
					if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>, 
					//_connection.newDBDataParameter("ConstraintExist", DbType.Boolean, ParameterDirection.Output, 0, 1)<%
					}%>
					_connection.newDBDataParameter("Output_", DbType.Int32, ParameterDirection.Output, null, 0)
				};
				_connection.Execute_SQLFunction(
					"sp0_<%=_aux_db_table.Name%>_setObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }

				ConstraintExist_out = (((int)_dataparameters[<%=_aux_db_table.TableFields.TableFieldCollection.Count%>].Value & 2) == 1);
				if (!ConstraintExist_out) {
					<%=_aux_db_table.Name%>_in.haschanges_ = false;<%



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
					switch (<%=_aux_db_table.Name%>_in.<%=NameField%>) {<%
								for (int r = 0; r < ConfigTable.Rows.Count; r++) {%>
						case "<%=ConfigTable.Rows[r][NameField]%>": {
#if USE_PARTIAL_CLASSES && !NET_1_1
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
		#region public static <%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].DBType_generic.FWType%> insObject(...);
		/// <summary>
		/// Inserts <%=_aux_db_table.Name%> values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and insertion failed, and False if no constraint and insertion was successful</param><%
		}%>
		/// <returns>insertion sequence/identity seed</returns>
		public static <%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].DBType_generic.FWType%> insObject(
			SO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in, 
			bool selectIdentity_in<%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>, 
			out bool constraintExist_out<%
			} %>
		) {
			return insObject(
				<%=_aux_db_table.Name%>_in, 
				selectIdentity_in, <%
				if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
				out constraintExist_out, <%
				} %>
				null
			);
		}

		/// <summary>
		/// Inserts <%=_aux_db_table.Name%> values into Database.
		/// </summary>
		/// <param name="selectIdentity_in">assign with True if you wish to retrieve insertion sequence/identity seed and with False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and insertion failed, and False if no constraint and insertion was successful</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>insertion sequence/identity seed</returns>
		public static <%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].DBType_generic.FWType%> insObject(
			SO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in, 
			bool selectIdentity_in, <%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
			out bool constraintExist_out, <%
			} %>
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.<%=(_aux_db_field.isIdentity) ? "Out" : "In"%>put, <%=
					(_aux_db_field.isIdentity) 
						? "null" 
						: ((_aux_db_field.isNullable) 
							? _aux_db_table.Name + "_in." + _aux_db_field.Name + "_isNull ? null : (object)" + _aux_db_table.Name + "_in." + _aux_db_field.Name 
							: _aux_db_table.Name + "_in." + _aux_db_field.Name
						)%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}%>

				_connection.newDBDataParameter("SelectIdentity_", DbType.Boolean, ParameterDirection.Input, selectIdentity_in, 1)
			};
			_connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_insObject", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			<%
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey];
			_aux_ex_field = _aux_db_field.parallel_ref;
			%><%=_aux_db_table.Name%>_in.<%=_aux_db_field.Name%> = (<%=_aux_db_field.DBType_generic.FWType%>)_dataparameters[<%=_aux_db_table.IdentityKey%>].Value;<%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
			constraintExist_out = (<%=_aux_db_table.Name%>_in.<%=_aux_db_field.Name%> == -1L);
			if (!constraintExist_out) {
				<%=_aux_db_table.Name%>_in.haschanges_ = false;
			}<%
			} else {%>
			<%=_aux_db_table.Name%>_in.haschanges_ = false;
			<%}%>

			return <%=_aux_db_table.Name%>_in.<%=_aux_db_field.Name%>;
		}
		#endregion
		#region public static void updObject(...);
		/// <summary>
		/// Updates <%=_aux_db_table.Name%> values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param><%
		}%>
		public static void updObject(
			SO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in, 
			bool forceUpdate_in<%=
			(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @", 
			out bool constraintExist_out" : ""%>
		) {
			updObject(
				<%=_aux_db_table.Name%>_in, 
				forceUpdate_in, <%=
				(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @"
				out constraintExist_out, " : ""%>
				null
			);
		}

		/// <summary>
		/// Updates <%=_aux_db_table.Name%> values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updObject(
			SO_<%=_aux_db_table.Name%> <%=_aux_db_table.Name%>_in, 
			bool forceUpdate_in, <%=
			(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @"
			out bool constraintExist_out, " : ""%>
			DBConnection dbConnection_in
		) {
			if (forceUpdate_in || <%=_aux_db_table.Name%>_in.haschanges_) {
				DBConnection _connection = (dbConnection_in == null)
					? DO__utils.DBConnection_createInstance(
						DO__utils.DBServerType,
						DO__utils.DBConnectionstring,
						DO__utils.DBLogfile
					) 
					: dbConnection_in;

				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=
						((_aux_db_field.isNullable) 
							? _aux_db_table.Name + "_in." + _aux_db_field.Name + "_isNull ? null : (object)" + _aux_db_table.Name + "_in." + _aux_db_field.Name 
							: _aux_db_table.Name + "_in." + _aux_db_field.Name
						)%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=((f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) || (_aux_ex_table.TableSearches.hasExplicitUniqueIndex)) ? ", " : ""%><%
					}%><%
					if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>

					_connection.newDBDataParameter("ConstraintExist_", DbType.Boolean, ParameterDirection.Output, null, 1)<%
					}%>
				};
				_connection.Execute_SQLFunction(
					"sp0_<%=_aux_db_table.Name%>_updObject", 
					_dataparameters
				);
				if (dbConnection_in == null) { _connection.Dispose(); }
				<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
				constraintExist_out = <%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? "(bool)_dataparameters[" + (_aux_db_table.TableFields.TableFieldCollection.Count) + "].Value" : "false"%>;
				if (!constraintExist_out) {
					<%=_aux_db_table.Name%>_in.haschanges_ = false;
				}<%
				} else {
				%><%=_aux_db_table.Name%>_in.haschanges_ = false;<%
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
		#region Methods - Object Searches...<%









		for (int s = 0; s < _aux_ex_table.TableSearches.TableSearchCollection.Count; s++) {
			if (!_aux_ex_table.TableSearches.TableSearchCollection[s].isRange) {%>
		#region ???Object_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>...
		#region public static SO_<%=_aux_db_table.Name%> getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database (based on the search condition) and assigns them to the appropriate DO0_<%=_aux_db_table.Name%> property.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>null if <%=_aux_db_table.Name%> doesn't exists at Database</returns>
		public static SO_<%=_aux_db_table.Name%> getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			return getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Selects <%=_aux_db_table.Name%> values from Database (based on the search condition) and assigns them to the appropriate DO0_<%=_aux_db_table.Name%> property.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>null if <%=_aux_db_table.Name%> doesn't exists at Database</returns>
		public static SO_<%=_aux_db_table.Name%> getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			SO_<%=_aux_db_table.Name%> _output = null;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				_connection.newDBDataParameter("<%=_aux_db_field.Name%>", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Output, null, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_getObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			if (_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count + _aux_db_table.firstKey%>].Value != DBNull.Value) {
				_output = new SO_<%=_aux_db_table.Name%>();<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%>
				if (_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count + f%>].Value == System.DBNull.Value) {<%
					if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
					_output.<%=_aux_db_field.Name%>_isNull = true;<%
					} else {%><%=""%>
					_output.<%=_aux_db_field.Name%> = <%=_aux_db_field.DBType_generic.FWEmptyValue%>;<%
					}%>
				} else {
					_output.<%=_aux_db_field.Name%> = (<%=_aux_db_field.DBType_generic.FWType%>)_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count + f%>].Value;
				}<%
				}%>

				<%--_output.haschanges_ = false;
				--%>return _output;
			}

			return null;
		}
		#endregion<%
		if (!_aux_db_table.isVirtualTable) {%>
		#region public static bool delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database (based on the search condition).
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"> <%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			return delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> from Database (based on the search condition).
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"> <%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if <%=_aux_db_table.Name%> existed and was Deleted at Database, False if it didn't exist</returns>
		public static bool delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}%>

				_connection.newDBDataParameter("Exists_", DbType.Boolean, ParameterDirection.Output, null, 1)
			};
			_connection.Execute_SQLFunction("sp0_<%=_aux_db_table.Name%>_delObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", _dataparameters);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return ((bool)_dataparameters[<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count%>].Value);
		}
		#endregion<%
		}%>
		#region public static bool isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database (based on the search condition).
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public static bool isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			return isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Checks to see if <%=_aux_db_table.Name%> exists at Database (based on the search condition).
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if <%=_aux_db_table.Name%> exists at Database, False if not</returns>
		public static bool isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=_aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			bool _output;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters, 
				DbType.Boolean, 
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#endregion<%
			}
		}









%>
		#endregion
		#region Methods - Object Updates...<%
		for (int u = 0; u < _aux_ex_table.TableUpdates.TableUpdateCollection.Count; u++) {
			_aux_ex_update = _aux_ex_table.TableUpdates.TableUpdateCollection[u];%>
		#region public static void updObject_<%=_aux_ex_update.Name%>(...);
		/// <summary>
		/// Updates <%=_aux_db_table.Name%> specific(only) values on Database.
		/// </summary>
		/// <param name="forceUpdate_in">assign with True if you wish to force an Update (even if no changes have been made since last time getObject method was run) and False if not</param><%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) { %>
		/// <param name="constraintExist_out">returns True if constraint exists and Update failed, and False if no constraint and Update was successful</param><%
		} %>
		public static void updObject_<%=_aux_ex_update.Name%>(
			bool forceUpdate_in<%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? @", 
			out bool constraintExist_out" : ""%>
		) {
			if (forceUpdate_in || fields_.haschanges_) {
				IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
					for (int f = 0; f < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[f];
						_aux_ex_field = _aux_db_field.parallel_ref;%>
					_connection.newDBDataParameter("<%=_aux_db_field.Name%>", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%="fields_." + _aux_db_field.Name%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
					}
					for (int f = 0; f < _aux_ex_update.TableUpdateParameters.TableFieldRefCollection.Count; f++) {
						_aux_ex_field = _aux_ex_update.TableUpdateParameters.TableFieldRefCollection[f].TableField_ref;
						_aux_db_field = _aux_ex_field.parallel_ref;%>
					_connection.newDBDataParameter("<%=_aux_ex_field.Name%>_update", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%="fields_." + _aux_ex_field.Name%>, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=((f != _aux_ex_update.TableUpdateParameters.TableFieldRefCollection.Count - 1) || (_aux_ex_table.TableSearches.hasExplicitUniqueIndex)) ? ", " : ""%><%
					}
					if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>

					_connection.newDBDataParameter("ConstraintExist", DbType.Boolean, ParameterDirection.Output, null, 1)<%
					}%>
				};
				_connection.Execute_SQLFunction(
					"sp0_<%=_aux_db_table.Name%>_updObject_<%=_aux_ex_update.Name%>", 
					_dataparameters
				);
				<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
				constraintExist_out = <%=(_aux_ex_table.TableSearches.hasExplicitUniqueIndex) ? "(bool)_dataparameters[" + (_aux_db_table.TableFields.TableFieldCollection.Count) + "].Value" : "false"%>;
				if (!constraintExist_out) {
					fields_.haschanges_ = false;
				}<%
				} else {
				%>fields_.haschanges_ = false;<%
				}%>
			<%if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
			} else {
				constraintExist_out = false;<%
			}%>
			}
		}
		#endregion<%
		}%>
		#endregion<%





%>

		#region Methods - Record Searches...
		#region private static SO_<%=_aux_db_table.Name%>[] getRecord(DataTable dataTable_in);
		private static SO_<%=_aux_db_table.Name%>[] getRecord(
			DataTable dataTable_in
		) {
			SO_<%=_aux_db_table.Name%>[] _output 
				= new SO_<%=_aux_db_table.Name%>[dataTable_in.Rows.Count];
			for (int r = 0; r < dataTable_in.Rows.Count; r++) {
				_output[r] = new SO_<%=_aux_db_table.Name%>();
<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
				if (dataTable_in.Rows[r]["<%=_aux_db_field.Name%>"] == System.DBNull.Value) {<%
					if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%>
					_output[r].<%=_aux_db_field.Name%>_isNull = true;<%
					} else {%><%=""%>
					_output[r].<%=_aux_db_field.Name.ToLower()%>_ = <%=_aux_db_field.DBType_generic.FWEmptyValue%>;<%
					}%>
				} else {
					_output[r].<%=_aux_db_field.Name.ToLower()%>_ = (<%=_aux_db_field.DBType_generic.FWType%>)dataTable_in.Rows[r]["<%=_aux_db_field.Name%>"];
				}<%
				}%>

				_output[r].haschanges_ = false;
			}

			return _output;
		}
		#endregion
<%
		for (int s = 0; s < _aux_ex_table.TableSearches.TableSearchCollection.Count; s++) {
			if (_aux_ex_table.TableSearches.TableSearchCollection[s].isRange) {%>
		#region ???_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>...
		#region public static SO_<%=_aux_db_table.Name%>[] getRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Gets Record, based on '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search. It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public static SO_<%=_aux_db_table.Name%>[] getRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			int page_in, 
			int page_numRecords_in
		) {
			return getRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				page_in, 
				page_numRecords_in, 
				null
			);
		}

		/// <summary>
		/// Gets Record, based on '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search. It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static SO_<%=_aux_db_table.Name%>[] getRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			int page_in, 
			int page_numRecords_in, 
			DBConnection dbConnection_in
		) {
			SO_<%=_aux_db_table.Name%>[] _output;
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = 
				(page_in > 0)
					? new IDbDataParameter[] {<%
						for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
							_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
							_aux_db_field = _aux_ex_field.parallel_ref;
							_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
						_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
						}%>
					}
					: new IDbDataParameter[] {<%
						for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
							_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
							_aux_db_field = _aux_ex_field.parallel_ref;
							_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
						_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
						}%>
						_connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
						_connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
					}
				;
			_output = getRecord(
				_connection.Execute_SQLFunction_returnDataTable(
					(page_in > 0)
						? "sp0_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>_fullmode"
						: "sp0_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>_page_fullmode", 
					_dataparameters
				)
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;			
		}
		#endregion<%
		if (!_aux_db_table.isVirtualTable) {
			for (int u = 0; u < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection.Count; u++) {
		%>
		#region public static void updRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Updates (some) <%=_aux_db_table.Name%> values on Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;%><%=""%>
		/// <param name="<%=_aux_ex_field.Name%>_update_in"><%=_aux_ex_field.Name%> update value</param><%
		}%>
		public static void updRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_ex_field.Name%>_update_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			updRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;%><%=""%>
				<%=_aux_ex_field.Name%>_update_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Updates (some) <%=_aux_db_table.Name%> values on Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;%><%=""%>
		/// <param name="<%=_aux_ex_field.Name%>_update_in"><%=_aux_ex_field.Name%> update value</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void updRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_ex_field.Name%>_update_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;%>
				_connection.newDBDataParameter("<%=_aux_ex_field.Name%>_update_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_ex_field.Name%>_update_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_Record_update_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion<%
			}
		}
		%>
		#region public static bool isObject_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search and checks to see if <%=_aux_db_table.Name%> Keys(passed as parameters) are met.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%> Key used for checking</param><%
		}
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_db_table.Name%> Keys are met in the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search, False if not</returns>
		public static bool isObject_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;
			%>, 
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%
			}%>
		) {
			return isObject_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
				<%=_aux_db_field.Name%>_in, <%
				}
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;
				%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search and checks to see if <%=_aux_db_table.Name%> Keys(passed as parameters) are met.
		/// </summary><%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
		/// <param name="<%=_aux_db_field.Name%>_in"><%=_aux_db_table.Name%>'s <%=_aux_db_field.Name%> Key used for checking</param><%
		}
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>True if <%=_aux_db_table.Name%> Keys are met in the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search, False if not</returns>
		public static bool isObject_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_db_field.Name%>_in, <%
			}
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;
			%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			bool _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
				_connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_db_field.Name%>_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;
				%>, 
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%
			}%>
			};
			_output = (bool)_connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_Record_hasObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion
		#region public static long getCount_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Count's number of search results from <%=_aux_db_table.Name%> at Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <returns>number of existing Records for the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search</returns>
		public static long getCount_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			return getCount_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Count's number of search results from <%=_aux_db_table.Name%> at Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		/// <returns>number of existing Records for the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search</returns>
		public static long getCount_inRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			long _output;

			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_output = (long)_connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_Record_count_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters, 
				DbType.Int64,
				0
			);
			if (dbConnection_in == null) { _connection.Dispose(); }

			return _output;
		}
		#endregion<%
		if (!_aux_db_table.isVirtualTable) {%>
		#region public static void delRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		public static void delRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			delRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in, <%
				}%>
				null
			);
		}

		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="dbConnection_in">Database connection, making the use of Database Transactions possible on a sequence of operations across the same or multiple DataObjects</param>
		public static void delRecord_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in, <%
			}%>
			DBConnection dbConnection_in
		) {
			DBConnection _connection = (dbConnection_in == null)
				? DO__utils.DBConnection_createInstance(
					DO__utils.DBServerType,
					DO__utils.DBConnectionstring,
					DO__utils.DBLogfile
				) 
				: dbConnection_in;
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				_connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			_connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_Record_delete_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters
			);
			if (dbConnection_in == null) { _connection.Dispose(); }
		}
		#endregion<%
		}%>
		#endregion<%
			}
		}%>
		#endregion
	}
}