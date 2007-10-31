<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
cDBMetadata _aux_metadata;
if (cDBMetadata.Metacache.Contains(_arg_MetadataFilepath)) {
	_aux_metadata = (cDBMetadata)cDBMetadata.Metacache[_arg_MetadataFilepath];
} else {
	_aux_metadata = new cDBMetadata();
	_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);
	cDBMetadata.Metacache.Add(_arg_MetadataFilepath, _aux_metadata);
}
cDBMetadata_Table _aux_table = _aux_metadata.Tables[_arg_TableName];
int _aux_table_hasidentitykey = _aux_table.hasIdentityKey();
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
string _aux_field_name;
cDBMetadata_Update _aux_update;
int firstKey = _aux_table.firstKey();
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_metadata.CopyrightText != string.Empty) && (_aux_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_metadata.CopyrightText%>
/*

<%=_aux_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Data;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_table.Name%> RecordObject which provides access to searches defined for <%=_aux_table.Name%> table at Database.
	/// </summary>
	public sealed class RO0_<%=_aux_table.Name%> : RO__base {
		#region internal RO0_<%=_aux_table.Name%>();
		internal RO0_<%=_aux_table.Name%>(
#if !NET_1_1
			DO_<%=_aux_table.Name%> 
#else
			DO0_<%=_aux_table.Name%> 
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
			DO_<%=_aux_table.Name%> 
#else
			DO0_<%=_aux_table.Name%> 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC0_<%=_aux_table.Name%> Serialize();
		//public SC0_<%=_aux_table.Name%> Serialize() {
		//	return new SC0_<%=_aux_table.Name%>(Record);
		//}
		#endregion
		#region public SC0_<%=_aux_table.Name%> Serialize();
		public SC0_<%=_aux_table.Name%> Serialize() {
			SO0_<%=_aux_table.Name%>[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO0_<%=_aux_table.Name%>[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO0_<%=_aux_table.Name%>(<%
							for (int f = 0; f < _aux_table.Fields.Count; f++) {
								_aux_field = _aux_table.Fields[f];%><%=""%>
							parent_ref_.Fields.<%=_aux_field.Name%><%=(f != _aux_table.Fields.Count - 1) ? "," : ""%><%
							}%>
						);
				}

				Current = _current;
			}

			SC0_<%=_aux_table.Name%> _serialize_out = new SC0_<%=_aux_table.Name%>();
			_serialize_out.SO0_<%=_aux_table.Name%> = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC0_<%=_aux_table.Name%> serialisablecollection_in);
		public void Open(SC0_<%=_aux_table.Name%> serialisablecollection_in) {
			Open(serialisablecollection_in.SO0_<%=_aux_table.Name%>);
		}
		#endregion
		#region public void Open(SO0_<%=_aux_table.Name%>[] serialisableobject_in);
		public void Open(SO0_<%=_aux_table.Name%>[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();<%
				for (int f = 0; f < _aux_table.Fields.Count; f++) {
					_aux_field = _aux_table.Fields[f];%><%=""%>
				_datarow["<%=_aux_field.Name%>"] = serialisableobject_in[i].<%=_aux_field.Name%>;<%
				}%>

				_datatable.Rows.Add(_datarow);
			}

			Open(true, _datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate <%=_aux_table.Name%> DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			return Read(false);
		}

		/// <summary>
		/// Reads values from Record, assigns them to the appropriate <%=_aux_table.Name%> DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <param name="doNOTgetObject_in">do NOT get object: - if set to true, only PKs will be available for reading, you should be carefull (updates aren't advisable, other issues may occur)</param>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read(bool doNOTgetObject_in) {
			if (base.read()) {
				if (base.Fullmode) {<%
					for (int f = 0; f < _aux_table.Fields.Count; f++) {
						_aux_field = _aux_table.Fields[f];%><%=""%>
					if (base.Record.Rows[Current]["<%=_aux_field.Name%>"] == System.DBNull.Value) {<%
						if (_aux_field.isNullable && !_aux_field.isPK) {%><%=""%><%
						// parent_ref_.< %=_aux_field.Name.ToLower()% >_ = null;%>
						parent_ref_.Fields.<%=_aux_field.Name%>_isNull = true;<%
						} else {%><%=""%>
						parent_ref_.Fields.<%=_aux_field.Name.ToLower()%>_ = <%=_aux_field.DBType_generic.FWEmptyValue%>;<%
						}%>
					} else {
						parent_ref_.Fields.<%=_aux_field.Name.ToLower()%>_ = (<%=_aux_field.DBType_generic.FWType%>)base.Record.Rows[Current]["<%=_aux_field.Name%>"];
					}<%
					//parent_ref_.Fields.< %=_aux_field.Name% > = (< %=_aux_field.DBType_generic.FWType% >)base.Record.Rows[Current]["< %=_aux_field.Name% >"];
					//parent_ref_.Fields.< %=_aux_field.Name% > = (base.Record.Rows[Current]["< %=_aux_field.Name% >"] == System.DBNull.Value) ? < %=_aux_field.DBType_generic.FWEmptyValue% > : (< %=_aux_field.DBType_generic.FWType% >)base.Record.Rows[Current]["< %=_aux_field.Name% >"];
					}%>

					parent_ref_.Fields.haschanges_ = false;
				} else {<%
					for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
						_aux_field = _aux_table.Fields[k];
					//parent_ref_.< %=_aux_field.Name.ToLower()% >_ = (< %=_aux_field.DBType_generic.FWType% >)base.Record.Rows[Current]["< %=_aux_field.Name% >"];
					%>
					parent_ref_.Fields.<%=_aux_field.Name%> = (<%=_aux_field.DBType_generic.FWType%>)((base.Record.Rows[Current]["<%=_aux_field.Name%>"] == System.DBNull.Value) ? <%=_aux_field.DBType_generic.FWEmptyValue%> : base.Record.Rows[Current]["<%=_aux_field.Name%>"]);<%
					}%>

					if (!doNOTgetObject_in) {
						parent_ref_.getObject();
					}
				}

				return true;
			} else {
				parent_ref_.clrObject();

				return false;
			}
		}
		#endregion
		//---<%
		for (int s = 0; s < _aux_table.Searches.Count; s++) {
			if (_aux_table.Searches[s].isRange) {%>
		#region public void ????_<%=_aux_table.Searches[s].Name%>
		#region public void Open_<%=_aux_table.Searches[s].Name%>(...);
		/// <summary>
		/// Opens Record, based on '<%=_aux_table.Searches[s].Name%>' search. It selects <%=_aux_table.Name%> values from Database based on the '<%=_aux_table.Searches[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		public void Open_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}%>
		) {
			Open_<%=_aux_table.Searches[s].Name%>(<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
				<%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
				}
				%><%=(_aux_table.Searches[s].SearchParameters.Count != 0) ? ", " : ""%>
				true
			);
		}

		/// <summary>
		/// Opens Record, based on '<%=_aux_table.Searches[s].Name%>' search. It selects <%=_aux_table.Name%> values from Database based on the '<%=_aux_table.Searches[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		/// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		public void Open_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}%><%=(_aux_table.Searches[s].SearchParameters.Count != 0) ? ", " : ""%>
			bool fullmode_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field_name%>_search_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field_name%>_search_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>)<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
				}%>
			};
			base.Open(
				string.Format(
					"sp{0}_<%=_aux_table.Name%>_Record_open_<%=_aux_table.Searches[s].Name%>{1}", 
					fullmode_in ? "0" : "", 
					fullmode_in ? "_fullmode" : ""
				), 
				_dataparameters, 
				fullmode_in
			);
		}

		/// <summary>
		/// Opens Record, based on '<%=_aux_table.Searches[s].Name%>' search. It selects <%=_aux_table.Name%> values from Database based on the '<%=_aux_table.Searches[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}
			%><%=(_aux_table.Searches[s].SearchParameters.Count != 0) ? ", " : ""%>
			int page_in, 
			int page_numRecords_in
		) {
			Open_<%=_aux_table.Searches[s].Name%>(<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
				<%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
				}
				%><%=(_aux_table.Searches[s].SearchParameters.Count != 0) ? ", " : ""%>
				true, 
				page_in, 
				page_numRecords_in
			);
		}

		/// <summary>
		/// Opens Record, based on '<%=_aux_table.Searches[s].Name%>' search. It selects <%=_aux_table.Name%> values from Database based on the '<%=_aux_table.Searches[s].Name%>' search and assigns them to the Record, opening it.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		/// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}
			%><%=(_aux_table.Searches[s].SearchParameters.Count != 0) ? ", " : ""%>
			bool fullmode_in, 
			int page_in, 
			int page_numRecords_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field_name%>_search_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field_name%>_search_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>), <%
				}%>
				parent_ref_.Connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
			};
			base.Open(
				string.Format(
					"sp0_<%=_aux_table.Name%>_Record_open_<%=_aux_table.Searches[s].Name%>_page{0}", 
					fullmode_in ? "_fullmode" : ""
				), 
				_dataparameters, 
				fullmode_in
			);
		}
		#endregion<%
		if (!_aux_table.isVirtualTable) {
			for (int u = 0; u < _aux_table.Searches[s].Updates.Count; u++) {
		%>
		#region public bool Update_<%=_aux_table.Searches[s].Updates[u].Name%>_<%=_aux_table.Searches[s].Name%>(...);
		/// <summary>
		/// Updates (some) <%=_aux_table.Name%> values on Database based on the '<%=_aux_table.Searches[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}
		for (int f = 0; f < _aux_table.Searches[s].Updates[u].UpdateParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].Updates[u].UpdateParameters[f].Field;%><%=""%>
		/// <param name="<%=_aux_field.Name%>_update_in"><%=_aux_field.Name%> update value</param><%
		}%>
		public void Update_<%=_aux_table.Searches[s].Updates[u].Name%>_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in, <%
			}
			for (int f = 0; f < _aux_table.Searches[s].Updates[u].UpdateParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].Updates[u].UpdateParameters[f].Field;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field.Name%>_update_in<%=(f != _aux_table.Searches[s].Updates[u].UpdateParameters.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field_name%>_search_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field_name%>_search_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>), <%
				}
				for (int f = 0; f < _aux_table.Searches[s].Updates[u].UpdateParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].Updates[u].UpdateParameters[f].Field;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field.Name%>_update_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field.Name%>_update_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>)<%=(f != _aux_table.Searches[s].Updates[u].UpdateParameters.Count - 1) ? ", " : ""%><%
				}%>
			};
			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_<%=_aux_table.Name%>_Record_update_<%=_aux_table.Searches[s].Updates[u].Name%>_<%=_aux_table.Searches[s].Name%>", 
				_dataparameters
			);
		}
		#endregion<%
			}
		}
		%>
		#region public bool hasObject_<%=_aux_table.Searches[s].Name%>(...);
		/// <summary>
		/// It selects <%=_aux_table.Name%> values from Database based on the '<%=_aux_table.Searches[s].Name%>' search and checks to see if <%=_aux_table.Name%> Keys(passed as parameters) are met.
		/// </summary><%
		for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
			_aux_field = _aux_table.Fields_onlyPK[k];%><%=""%>
		/// <param name="<%=_aux_field.Name%>_in"><%=_aux_table.Name%>'s <%=_aux_field.Name%> Key used for checking</param><%
		}
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		/// <returns>True if <%=_aux_table.Name%> Keys are met in the '<%=_aux_table.Searches[s].Name%>' search, False if not</returns>
		public bool hasObject_<%=_aux_table.Searches[s].Name%>(<%
			for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
				_aux_field = _aux_table.Fields_onlyPK[k];%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field.Name%>_in<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? ", " : ""%><%
			}
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;
			%>, 
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
			for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
				_aux_field = _aux_table.Fields_onlyPK[k];%><%=""%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field.Name%>_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field.Name%>_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? ", " : ""%><%
			}
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;
				%>, 
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field_name%>_search_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field_name%>_search_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>)<%
			}%>
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_<%=_aux_table.Name%>_Record_hasObject_<%=_aux_table.Searches[s].Name%>", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_<%=_aux_table.Searches[s].Name%>(...);
		/// <summary>
		/// Count's number of search results from <%=_aux_table.Name%> at Database based on the '<%=_aux_table.Searches[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		/// <returns>number of existing Records for the '<%=_aux_table.Searches[s].Name%>' search</returns>
		public long Count_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field_name%>_search_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field_name%>_search_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>)<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
				}%>
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_<%=_aux_table.Name%>_Record_count_<%=_aux_table.Searches[s].Name%>", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion<%
		if (!_aux_table.isVirtualTable) {%>
		#region public void Delete_<%=_aux_table.Searches[s].Name%>(...);
		/// <summary>
		/// Deletes <%=_aux_table.Name%> values from Database based on the '<%=_aux_table.Searches[s].Name%>' search.
		/// </summary><%
		for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
			_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
			_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
		/// <param name="<%=_aux_field_name%>_search_in"><%=_aux_field_name%> search condition</param><%
		}%>
		public void Delete_<%=_aux_table.Searches[s].Name%>(<%
			for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
				_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
				_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%><%=""%>
			<%=(_aux_field.isNullable && !_aux_field.isPK) ? "object" : _aux_field.DBType_generic.FWType%> <%=_aux_field_name%>_search_in<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}%>
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {<%
				for (int f = 0; f < _aux_table.Searches[s].SearchParameters.Count; f++) {
					_aux_field = _aux_table.Searches[s].SearchParameters[f].Field;
					_aux_field_name = _aux_table.Searches[s].SearchParameters[f].ParamName;%>
				parent_ref_.Connection.newDBDataParameter("<%=_aux_field_name%>_search_", DbType.<%=_aux_field.DBType_generic.Value.ToString()%>, ParameterDirection.Input, <%=_aux_field_name%>_search_in, <%=_aux_field.Size%><%=(_aux_field.isDecimal) ? ", " + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale : ""%>)<%=(f != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
				}%>
			};

			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_<%=_aux_table.Name%>_Record_delete_<%=_aux_table.Searches[s].Name%>", 
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