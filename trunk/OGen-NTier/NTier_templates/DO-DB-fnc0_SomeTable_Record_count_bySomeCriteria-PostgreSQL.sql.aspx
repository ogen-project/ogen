<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataExtended" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataDB" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
string _arg_SearchName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SearchName"]);
#endregion

#region varaux...
DBServerTypes _aux_dbservertype = DBServerTypes.PostgreSQL;

XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableType _aux_db_table
	= _aux_db_metadata.Tables.TableCollection[
		_arg_TableName
	];
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableType _aux_ex_table
	= _aux_db_table.parallel_ref;

XS_tableSearchType _aux_ex_search
	= _aux_ex_table.TableSearches.TableSearchCollection[_arg_SearchName];

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType _aux_ex_field;

string _aux_xx_field_name;

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE OR REPLACE FUNCTION "fnc0_<%=_aux_db_table.Name%>_Record_count_<%=_aux_ex_search.Name%>"(<%
for (int f = 0; f < _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
	_aux_ex_field = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
	_aux_db_field = _aux_ex_field.parallel_ref;
	_aux_xx_field_name = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
	"<%=_aux_xx_field_name%>_search_" <%=_aux_db_field.TableFieldDBs.TableFieldDBCollection[_aux_dbservertype].DBType%><%=(f != _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
}%>
)
RETURNS int8 AS $BODY$
	DECLARE
		_Output int8 = 0;
	BEGIN
		SELECT
			COUNT("<%=_aux_db_table.TableFields_onlyPK.TableFieldCollection[0].Name%>")
		INTO
			_Output
		FROM "fnc_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_search.Name%>"(<%
		for (int f = 0; f < _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
			"<%=_aux_xx_field_name%>_search_"<%=(f != _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
		}%>
		);
	
		RETURN _Output;
	END;
$BODY$ LANGUAGE 'plpgsql' STABLE;

<%
//-----------------------------------------------------------------------------------------
%>