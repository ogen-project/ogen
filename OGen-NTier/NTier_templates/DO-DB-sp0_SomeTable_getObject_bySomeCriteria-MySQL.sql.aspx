<%--

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

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
string _arg_SearchName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SearchName"]);
#endregion

#region varaux...
eDBServerTypes _aux_dbservertype = eDBServerTypes.MySQL;

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
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE `sp0_<%=_aux_table.Name%>_getObject_<%=_aux_search.Name%>`(<%
for (int f = 0; f < _aux_search.SearchParameters.Count; f++) {
	_aux_field = _aux_search.SearchParameters[f].Field;
	_aux_field_name = _aux_search.SearchParameters[f].ParamName;%>
	IN `<%=_aux_field_name%>_search_` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_field.Size + ")" : ""%>, <%
}
for (int f = 0; f < _aux_table.Fields.Count; f++) {
	_aux_field = _aux_table.Fields[f];%>
	IN `<%=_aux_field.Name%>` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_field.Size + ")" : ""%> OUT<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
}%>
)
	NOT DETERMINISTIC
	SQL SECURITY DEFINER
	COMMENT ''
BEGIN<%if (_aux_metadata.CopyrightTextLong != string.Empty) {
%>
/*

<%=_aux_metadata.CopyrightTextLong%>

*/<%
}%>
	DECLARE `Exists` BOOLEAN DEFAULT false;

	SELECT<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];%>
		t1.`<%=_aux_field.Name%>` INTO `<%=_aux_field.Name%>`, <%
	}%>
		true INTO `Exists`
	FROM `<%=_aux_table.Name%>` t1
	INNER JOIN `fnc_<%=_aux_table.Name%>_isObject_<%=_aux_search.Name%>`(<%
	for (int f = 0; f < _aux_search.SearchParameters.Count; f++) {
		_aux_field = _aux_search.SearchParameters[f].Field;
		_aux_field_name = _aux_search.SearchParameters[f].ParamName;%>
		`<%=_aux_field_name%>_search_`<%=(f != _aux_search.SearchParameters.Count - 1) ? ", " : ""%><%
	}%>
	) t2 ON (<%
	for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
		_aux_field = _aux_table.Fields_onlyPK[k];%>
		(t2.`<%=_aux_field.Name%>` = t1.`<%=_aux_field.Name%>`)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
	}%>
	);

	IF (NOT `Exists`) THEN<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];%>
		SET `<%=_aux_field.Name%>` = NULL;<%
	}%>
	END IF;
END

<%
//-----------------------------------------------------------------------------------------
%>