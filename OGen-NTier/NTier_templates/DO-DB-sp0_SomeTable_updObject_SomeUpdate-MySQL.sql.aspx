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
string _arg_UpdateName = System.Web.HttpUtility.UrlDecode(Request.QueryString["UpdateName"]);
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
cDBMetadata_Update aux_update = _aux_table.Updates[_arg_UpdateName];
int _aux_table_hasidentitykey = _aux_table.hasIdentityKey();
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
string aux_string;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE `sp0_<%=_aux_table.Name%>_updObject_<%=aux_update.Name%>`(<%
for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
	_aux_field = _aux_table.Fields_onlyPK[k];%>
	IN `<%=_aux_field.Name%>_` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_field.Size + ")" : ""%>, <%
}
for (int f = 0; f < aux_update.UpdateParameters.Count; f++) {
	_aux_field = aux_update.UpdateParameters[f].Field;%>
	IN `<%=_aux_field.Name%>_update_` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_field.Size + ")" : ""%><%=(f != aux_update.UpdateParameters.Count - 1) ? ", " : ""%><%
}
if (_aux_table_searches_hasexplicituniqueindex) {%>, 
	OUT `ConstraintExist_` BOOLEAN<%
}%>
)
	NOT DETERMINISTIC
	SQL SECURITY DEFINER
	COMMENT ''
BEGIN<%
if (_aux_table_searches_hasexplicituniqueindex) {%>
	SET `ConstraintExist_` = `fnc0_<%=_aux_table.Name%>__ConstraintExist`(<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];

		if (_aux_field.isPK) {
			aux_string = "`" + _aux_field.Name + "_`";
		} else {
			aux_string = "NULL";
			for (int uf = 0; uf < aux_update.UpdateParameters.Count; uf++) {
				if (_aux_field.Name == aux_update.UpdateParameters[uf].Field.Name) {
					aux_string = "`" + _aux_field.Name + "_update_`";
				}
			}
		}%><%=""%>
		<%=aux_string%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
	}%>
	);

	IF (NOT `ConstraintExist_`) THEN<%
}%>
		UPDATE `<%=_aux_table.Name%>`
		SET<%
		for (int f = 0; f < aux_update.UpdateParameters.Count; f++) {
			_aux_field = aux_update.UpdateParameters[f].Field;%>
			`<%=_aux_field.Name%>` = `<%=_aux_field.Name%>_update_`<%=(f != aux_update.UpdateParameters.Count - 1) ? ", " : ""%><%
		}%>
		WHERE<%
		for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
			_aux_field = _aux_table.Fields_onlyPK[k];%>
			(`<%=_aux_field.Name%>` = `<%=_aux_field.Name%>_`)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
		}%>;<%
if (_aux_table_searches_hasexplicituniqueindex) {%>
	END IF;<%
}%>
END

<%
//-----------------------------------------------------------------------------------------
%>