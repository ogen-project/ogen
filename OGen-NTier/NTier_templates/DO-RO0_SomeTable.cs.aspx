<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
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

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.proxy;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_db_table.Name%> RecordObject which provides access to searches defined for <%=_aux_db_table.Name%> table at Database.
	/// </summary>
	public sealed class RO0_<%=_aux_db_table.Name%> : RO__base {
		#region internal RO0_<%=_aux_db_table.Name%>();
		internal RO0_<%=_aux_db_table.Name%>(
#if !NET_1_1
			DO_<%=_aux_db_table.Name%> 
#else
			DO0_<%=_aux_db_table.Name%> 
#endif
			parent_ref_in
		) : base(
			parent_ref_in
		) {
			parent_ref_ = parent_ref_in;
		}
		#endregion

		#region private Properties...
		private 
#if !NET_1_1
			DO_<%=_aux_db_table.Name%> 
#else
			DO0_<%=_aux_db_table.Name%> 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_<%=_aux_db_table.Name%> Serialize();
		//public SC_<%=_aux_db_table.Name%> Serialize() {
		//	return new SC_<%=_aux_db_table.Name%>(Record);
		//}
		#endregion
		#region public SC_<%=_aux_db_table.Name%> Serialize();
		public SC_<%=_aux_db_table.Name%> Serialize() {
			SO_<%=_aux_db_table.Name%>[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_<%=_aux_db_table.Name%>[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_<%=_aux_db_table.Name%>(<%
							for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
								_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
							parent_ref_.Fields.<%=_aux_db_field.Name%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? "," : ""%><%
							}%>
						);
				}

				Current = _current;
			}

			SC_<%=_aux_db_table.Name%> _serialize_out = new SC_<%=_aux_db_table.Name%>();
			_serialize_out.SO_<%=_aux_db_table.Name%> = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_<%=_aux_db_table.Name%> serialisablecollection_in);
		public void Open(SC_<%=_aux_db_table.Name%> serialisablecollection_in) {
			Open(serialisablecollection_in.SO_<%=_aux_db_table.Name%>);
		}
		#endregion
		#region public void Open(SO_<%=_aux_db_table.Name%>[] serialisableobject_in);
		public void Open(SO_<%=_aux_db_table.Name%>[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
				_datarow["<%=_aux_db_field.Name%>"] = serialisableobject_in[i].<%=_aux_db_field.Name%>;<%
				}%>

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate <%=_aux_db_table.Name%> DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
					_aux_ex_field = _aux_db_field.parallel_ref;%><%=""%>
				if (base.Record.Rows[Current]["<%=_aux_db_field.Name%>"] == System.DBNull.Value) {<%
					if (_aux_db_field.isNullable && !_aux_db_field.isPK) {%><%=""%><%
					// parent_ref_.< %=_aux_db_field.Name.ToLower()% >_ = null;%>
					parent_ref_.Fields.<%=_aux_db_field.Name%>_isNull = true;<%
					} else {%><%=""%>
					parent_ref_.Fields.<%=_aux_db_field.Name.ToLower()%>_ = <%=_aux_db_field.DBType_generic.FWEmptyValue%>;<%
					}%>
				} else {
					parent_ref_.Fields.<%=_aux_db_field.Name.ToLower()%>_ = (<%=_aux_db_field.DBType_generic.FWType%>)base.Record.Rows[Current]["<%=_aux_db_field.Name%>"];
				}<%
				//parent_ref_.Fields.< %=_aux_db_field.Name% > = (< %=_aux_db_field.DBType_generic.FWType% >)base.Record.Rows[Current]["< %=_aux_db_field.Name% >"];
				//parent_ref_.Fields.< %=_aux_db_field.Name% > = (base.Record.Rows[Current]["< %=_aux_db_field.Name% >"] == System.DBNull.Value) ? < %=_aux_db_field.DBType_generic.FWEmptyValue% > : (< %=_aux_db_field.DBType_generic.FWType% >)base.Record.Rows[Current]["< %=_aux_db_field.Name% >"];
				}%>

				parent_ref_.Fields.haschanges_ = false;

				return true;
			} else {
				parent_ref_.clrObject();

				return false;
			}
		}
		#endregion
		//---<%
		for (int s = 0; s < _aux_ex_table.TableSearches.TableSearchCollection.Count; s++) {
			if (_aux_ex_table.TableSearches.TableSearchCollection[s].isRange) {%>
		#region public void ????_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>
		#region public void Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);<%--
		/// <summary>
		/// Opens Record, based on '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search. It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		public void Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}
				%><%=(_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count != 0) ? ", " : ""%>
				true
			);
		}--%>
		/// <summary>
		/// Opens Record, based on '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search. It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		public void Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			base.Open(
				"sp0_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>_fullmode", 
				_dataparameters
			);
		}
<%--
		/// <summary>
		/// Opens Record, based on '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search. It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}
			%><%=(_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count != 0) ? ", " : ""%>
			int page_in, 
			int page_numRecords_in
		) {
			Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				<%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}
				%><%=(_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count != 0) ? ", " : ""%>
				true, 
				page_in, 
				page_numRecords_in
			);
		}
--%>
		/// <summary>
		/// Opens Record, based on '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search. It selects <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}
			%><%=(_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count != 0) ? ", " : ""%>
			int page_in, 
			int page_numRecords_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}%>
				parent_ref_.Connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
			};
			base.Open(
				"sp0_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>_page_fullmode", 
				_dataparameters
			);
		}
		#endregion<%
		if (!_aux_db_table.isVirtualTable) {
			for (int u = 0; u < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection.Count; u++) {
		%>
		#region public bool Update_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
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
		public void Update_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
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
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>), <%
				}
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_ex_field.Name%>_update_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_ex_field.Name%>_update_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].TableSearchUpdateParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};
			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_Record_update_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchUpdates.TableSearchUpdateCollection[u].Name%>_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters
			);
		}
		#endregion<%
			}
		}
		%>
		#region public bool hasObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
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
		public bool hasObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
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
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%><%=""%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_db_field.Name%>_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_db_field.Name%>_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
			}
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;
				%>, 
				parent_ref_.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%
			}%>
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_Record_hasObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
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
		public long Count_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_<%=_aux_db_table.Name%>_Record_count_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion<%
		if (!_aux_db_table.isVirtualTable) {%>
		#region public void Delete_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(...);
		/// <summary>
		/// Deletes <%=_aux_db_table.Name%> values from Database based on the '<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_db_field = _aux_ex_field.parallel_ref;
			_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_xx_field_name%>_search_in"><%=_aux_xx_field_name%> search condition</param><%
		}%>
		public void Delete_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>(<%
			for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
				_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
				_aux_db_field = _aux_ex_field.parallel_ref;
				_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%><%=""%>
			<%=(_aux_db_field.isNullable && !_aux_db_field.isPK) ? "object" : _aux_db_field.DBType_generic.FWType%> <%=_aux_xx_field_name%>_search_in<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; f++) {
					_aux_ex_field = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
					_aux_db_field = _aux_ex_field.parallel_ref;
					_aux_xx_field_name = _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_xx_field_name%>_search_", DbType.<%=_aux_db_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_xx_field_name%>_search_in, <%=_aux_db_field.Size%><%=(_aux_db_field.isDecimal) ? ", " + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale : ""%>)<%=(f != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
				}%>
			};

			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_<%=_aux_db_table.Name%>_Record_delete_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>", 
				_dataparameters
			);
		}
		#endregion<%
		}%>
		#endregion<%
			}
		}%>
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>