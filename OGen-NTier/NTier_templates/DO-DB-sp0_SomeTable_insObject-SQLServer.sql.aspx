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
int _aux_table_hasidentitykey = _aux_table.hasIdentityKey();
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE [dbo].[sp0_<%=_aux_table.Name%>_insObject]<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];%>
	@<%=_aux_field.Name%>_ <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? " (" + _aux_field.Size + ")" : ""%><%=(_aux_field.isDecimal && (_aux_field.Numeric_Scale > 0)) ? " (" + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale + ")" : ""%><%=(_aux_field.isIdentity) ? " OUT" : ""%>, <%
	}%>
	@SelectIdentity_ Bit
AS<%
	if (_aux_table_searches_hasexplicituniqueindex) {%>
	DECLARE @ConstraintExist Bit
	SET @ConstraintExist = [dbo].[fnc0_<%=_aux_table.Name%>__ConstraintExist](<%
		for (int f = 0; f < _aux_table.Fields.Count; f++) {
			_aux_field = _aux_table.Fields[f];%><%=""%>
		<%=(_aux_field.isPK) ? _aux_field.DBs[_aux_dbservertype].DBType_generic_DBEmptyValue() : "@" + _aux_field.Name + "_"%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
		}%>
	)
	IF (@ConstraintExist = 0) BEGIN<%
	}%>
		INSERT INTO [<%=_aux_table.Name%>] (<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				if (_aux_table_hasidentitykey != f) {
					_aux_field = _aux_table.Fields[f];%>
			[<%=_aux_field.Name%>]<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
				}
			}%>
		) VALUES (<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				if (_aux_table_hasidentitykey != f) {
					_aux_field = _aux_table.Fields[f];%>
			@<%=_aux_field.Name%>_<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
				}
			}%>
		)
		IF (@SelectIdentity_ = 1) BEGIN
			SET @<%=_aux_table.Fields[_aux_table_hasidentitykey]%>_ = @@IDENTITY
		END ELSE BEGIN
			SET @<%=_aux_table.Fields[_aux_table_hasidentitykey]%>_ = CAST(0 AS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>)
		END<%
	if (_aux_table_searches_hasexplicituniqueindex) {%>
	END ELSE BEGIN
		SET @<%=_aux_table.Fields[_aux_table_hasidentitykey]%>_ = CAST(-1 AS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>)
	END<%
	}%>
--GO


<%
//-----------------------------------------------------------------------------------------
%>