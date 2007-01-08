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
#endregion

#region varaux...
eDBServerTypes _aux_dbservertype = eDBServerTypes.PostgreSQL;

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

cDBMetadata_Table_Field _aux_field;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE OR REPLACE FUNCTION "fnc0_<%=_aux_table.Name%>__ConstraintExist"(<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];
	%>"<%=_aux_field.Name%>_" <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
	}
%>)
RETURNS boolean
AS '
	DECLARE
		-- nothing to declare!
	BEGIN<%
		for (int s = 0; s < _aux_table.Searches.Count; s++) {
			if (_aux_table.Searches[s].isExplicitUniqueIndex) {%>
		IF EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "fnc_<%=_aux_table.Name%>_isObject_<%=_aux_table.Searches[s].Name%>"(<%
			for (int p = 0; p < _aux_table.Searches[s].SearchParameters.Count; p++) {%>
				$<%=_aux_table.Fields.Search(_aux_table.Searches[s].SearchParameters[p].FieldName) + 1%><%=(p != _aux_table.Searches[s].SearchParameters.Count - 1) ? ", " : ""%><%
			}%>
			)
			WHERE NOT (<%
				for (int f = 0; f < _aux_table.Fields_onlyPK.Count; f++) {
					_aux_field = _aux_table.Fields_onlyPK[f];%>
				("<%=_aux_field.Name%>" = $<%=_aux_table.Fields.Search(_aux_field.Name) + 1%>)<%=(f != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
				}%>
			)
		) THEN
			RETURN true;
		END IF;<%
			}
		}%>

		RETURN false;
	END;
'
LANGUAGE 'plpgsql' STABLE;

<%
//-----------------------------------------------------------------------------------------
%>