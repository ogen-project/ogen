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
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE OR REPLACE FUNCTION "sp0_<%=_aux_table.Name%>_insObject"(<%
	for (int f = 0; f < _aux_table.Fields_noPK.Count; f++) {
		_aux_field = _aux_table.Fields_noPK[f];
		%>"<%=_aux_field.Name%>_" <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%>, <%
	}
%> "SelectIdentity_" boolean)
RETURNS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>
AS '
	/**********************************
	 *  returns                       *
	 *   -1: constraint exists        *
	 *    0: no need to get Identity  *
	 *   >0: Identity                 *
	 **********************************/

	DECLARE
		IdentityKey <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%> = CAST(0 AS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>);
	BEGIN<%
		if (_aux_table_searches_hasexplicituniqueindex) {%>
		IF ("fnc0_<%=_aux_table.Name%>__ConstraintExist"(
			CAST(0 AS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>), <%
			for (int f = 0; f < _aux_table.Fields_noPK.Count; f++) {
				_aux_field = _aux_table.Fields_noPK[f];%>
			"<%=_aux_field.Name%>_"<%=(f != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
			}%>
		)) THEN
			IdentityKey := CAST(-1 AS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>);
		ELSE<%
		}%>
			INSERT INTO "<%=_aux_table.Name%>" (<%
				for (int f = 0; f < _aux_table.Fields_noPK.Count; f++) {
					_aux_field = _aux_table.Fields_noPK[f];%>
				"<%=_aux_field.Name%>"<%=(f != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
				}%>
			) VALUES (<%
				for (int f = 0; f < _aux_table.Fields_noPK.Count; f++) {
					_aux_field = _aux_table.Fields_noPK[f];%>
				"<%=_aux_field.Name%>_"<%=(f != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
				}%>
			);
			IF ("SelectIdentity_") THEN
				SELECT
					"<%=_aux_table.Fields[_aux_table_hasidentitykey].Name%>"
				INTO
					IdentityKey
				FROM "<%=_aux_table.Name%>"
				ORDER BY "<%=_aux_table.Fields[_aux_table_hasidentitykey].Name%>" DESC LIMIT 1;
			ELSE
				IdentityKey := CAST(0 AS <%=_aux_table.Fields[_aux_table_hasidentitykey].DBs[_aux_dbservertype].DBType_inDB_name%>);
			END IF;<%
		if (_aux_table_searches_hasexplicituniqueindex) {%>
		END IF;<%
		}%>

		RETURN IdentityKey AS "<%=_aux_table.Fields[_aux_table_hasidentitykey].Name%>_";
	END;
' LANGUAGE 'plpgsql' VOLATILE;

<%
//-----------------------------------------------------------------------------------------
%>