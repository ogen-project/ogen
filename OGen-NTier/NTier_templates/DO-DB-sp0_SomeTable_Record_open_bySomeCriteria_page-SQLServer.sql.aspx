<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
string _arg_SearchName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SearchName"]);
#endregion

#region varaux...
DBServerTypes _aux_dbservertype = DBServerTypes.SQLServer;

cDBMetadata _aux_metadata;
if (cDBMetadata.Metacache.Contains(_arg_MetadataFilepath)) {
	_aux_metadata = (cDBMetadata)cDBMetadata.Metacache[_arg_MetadataFilepath];
} else {
	_aux_metadata = new cDBMetadata();
	_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);
	cDBMetadata.Metacache.Add(_arg_MetadataFilepath, _aux_metadata);
}
cDBMetadata_Table _aux_table = _aux_metadata.Tables[_arg_TableName];
cDBMetadata_Table_Search _aux_search = _aux_table.Searches[_arg_SearchName];
int _aux_table_hasidentitykey = _aux_table.hasIdentityKey();

cDBMetadata_Table_Field _aux_field;
string _aux_field_name;
bool isFirst;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE [dbo].[sp0_<%=_aux_table.Name%>_Record_open_<%=_aux_search.Name%>_page]<%
	for (int f = 0; f < _aux_search.SearchParameters.Count; f++) {
		//_aux_field = _aux_metadata.Tables[_aux_search.SearchParameters[f].TableIndex].Fields[_aux_search.SearchParameters[f].FieldIndex];
		_aux_field = _aux_search.SearchParameters[f].Field;
		_aux_field_name = _aux_search.SearchParameters[f].ParamName;%>
	@<%=_aux_field_name%>_search_ <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? " (" + _aux_field.Size + ")" : ""%><%=(_aux_field.isDecimal && (_aux_field.Numeric_Scale > 0)) ? " (" + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale + ")" : ""%>, <%
	}%>
	@page_ Int,
	@page_numRecords_ Int
AS
	DECLARE @ID_range_begin BigInt
	DECLARE @ID_range_end BigInt
	SET @ID_range_begin = ((@page_ - 1) * @page_numRecords_ + 1)
	SET @ID_range_end = (@page_ * @page_numRecords_)

	SET NOCOUNT ON

	CREATE TABLE [#Table_temp] (
		[ID_range] BigInt IDENTITY,<%
		for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
			_aux_field = _aux_table.Fields_onlyPK[k];%>
		[<%=_aux_field.Name%>] <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? " (" + _aux_field.Size + ")" : ""%><%=(_aux_field.isDecimal && (_aux_field.Numeric_Scale > 0)) ? " (" + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale + ")" : ""%><%=(k != _aux_table.Fields_onlyPK.Count - 1) ? ", " : ""%><%
		}%>
	)
	
	SET ROWCOUNT @ID_range_end
	INSERT INTO [#Table_temp] (<%
		for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
			_aux_field = _aux_table.Fields_onlyPK[k];%>
		[<%=_aux_field.Name%>]<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? ", " : ""%><%
		}%>
	)
	EXEC [dbo].[sp_<%=_aux_table.Name%>_Record_open_<%=_aux_search.Name%>] <%
	for (int f = 0; f < _aux_search.SearchParameters.Count; f++) {
		//_aux_field = _aux_metadata.Tables[_aux_search.SearchParameters[f].TableIndex].Fields[_aux_search.SearchParameters[f].FieldIndex];
		_aux_field = _aux_search.SearchParameters[f].Field;
		_aux_field_name = _aux_search.SearchParameters[f].ParamName;
		%>@<%=_aux_field_name%>_search_<%=(f != _aux_search.SearchParameters.Count - 1) ? ", " : ""%><%
	}%>

	SELECT<%
	for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
		_aux_field = _aux_table.Fields_onlyPK[k];%>
		t1.[<%=_aux_field.Name%>]<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? ", " : ""%><%
	}%>
	FROM [<%=_aux_table.Name%>] t1
		INNER JOIN [#Table_temp] t2 ON<%
		for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
			_aux_field = _aux_table.Fields_onlyPK[k];%>
			(t2.[<%=_aux_field.Name%>] = t1.[<%=_aux_field.Name%>]<%=(_aux_field.isText) ? " COLLATE SQL_Latin1_General_CP1_CI_AI" : ""%>)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? "AND " : ""%><%
		}%>

	-- CHANGE WHERE CONDITION IN: [dbo].[fnc_<%=_aux_table.Name%>_Record_open_<%=_aux_search.Name%>]
	-- NOT HERE!
	WHERE (t2.[ID_range] BETWEEN @ID_range_begin AND @ID_range_end)

	-- CHANGE ORDER BY IN: [dbo].[sp_<%=_aux_table.Name%>_Record_open_<%=_aux_search.Name%>]
	-- NOT HERE!
	ORDER BY t2.[ID_range]

	DROP TABLE [#Table_temp]

	SET NOCOUNT OFF
--GO


<%
//-----------------------------------------------------------------------------------------
%>