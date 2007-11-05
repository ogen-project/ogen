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
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
DBServerTypes _aux_dbservertype = DBServerTypes.PostgreSQL;

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

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE OR REPLACE FUNCTION "sp0_<%=_aux_db_table.Name%>_insObject"(<%
	for (int f = 0; f < _aux_table.Fields_noPK.Count; f++) {
		_aux_field = _aux_table.Fields_noPK[f];
		%>"<%=_aux_field.Name%>_" <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%>, <%
	}
%> "SelectIdentity_" boolean)
RETURNS <%=_aux_table.Fields[_aux_db_table.hasIdentityKey].DBs[_aux_dbservertype].DBType_inDB_name%>
AS $BODY$
	/**********************************
	 *  returns                       *
	 *   -1: constraint exists        *
	 *    0: no need to get Identity  *
	 *   >0: Identity                 *
	 **********************************/

	DECLARE
		IdentityKey <%=_aux_table.Fields[_aux_db_table.hasIdentityKey].DBs[_aux_dbservertype].DBType_inDB_name%> = CAST(0 AS <%=_aux_table.Fields[_aux_db_table.hasIdentityKey].DBs[_aux_dbservertype].DBType_inDB_name%>);
	BEGIN<%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
		IF ("fnc0_<%=_aux_db_table.Name%>__ConstraintExist"(
			CAST(0 AS <%=_aux_table.Fields[_aux_db_table.hasIdentityKey].DBs[_aux_dbservertype].DBType_inDB_name%>), <%
			for (int f = 0; f < _aux_table.Fields_noPK.Count; f++) {
				_aux_field = _aux_table.Fields_noPK[f];%>
			"<%=_aux_field.Name%>_"<%=(f != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
			}%>
		)) THEN
			IdentityKey := CAST(-1 AS <%=_aux_table.Fields[_aux_db_table.hasIdentityKey].DBs[_aux_dbservertype].DBType_inDB_name%>);
		ELSE<%
		}%>
			INSERT INTO "<%=_aux_db_table.Name%>" (<%
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
					"<%=_aux_table.Fields[_aux_db_table.hasIdentityKey].Name%>"
				INTO
					IdentityKey
				FROM "<%=_aux_db_table.Name%>"
				ORDER BY "<%=_aux_table.Fields[_aux_db_table.hasIdentityKey].Name%>" DESC LIMIT 1;
			ELSE
				IdentityKey := CAST(0 AS <%=_aux_table.Fields[_aux_db_table.hasIdentityKey].DBs[_aux_dbservertype].DBType_inDB_name%>);
			END IF;<%
		if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
		END IF;<%
		}%>

		RETURN IdentityKey AS "<%=_aux_table.Fields[_aux_db_table.hasIdentityKey].Name%>_";
	END;
$BODY$ LANGUAGE 'plpgsql' VOLATILE;

<%
//-----------------------------------------------------------------------------------------
%>