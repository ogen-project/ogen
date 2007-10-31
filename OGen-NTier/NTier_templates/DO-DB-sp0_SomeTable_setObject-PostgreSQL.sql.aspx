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
DBServerTypes _aux_dbservertype = DBServerTypes.PostgreSQL;

cDBMetadata _aux_metadata;
if (cDBMetadata.Metacache.Contains(_arg_MetadataFilepath)) {
	_aux_metadata = (cDBMetadata)cDBMetadata.Metacache[_arg_MetadataFilepath];
} else {
	_aux_metadata = new cDBMetadata();
	_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);
	cDBMetadata.Metacache.Add(_arg_MetadataFilepath, _aux_metadata);
}
cDBMetadata_Table _aux_table = _aux_metadata.Tables[_arg_TableName];
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
bool isFirst;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE OR REPLACE FUNCTION "sp0_<%=_aux_table.Name%>_setObject"(<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];%>
	"<%=_aux_field.Name%>_" <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
	}%>
)
RETURNS int4 AS
$BODY$
	/*************************************
	 *  returns                          *
	 *    00 0: not exist, no constraint *
	 *    01 1: exists, no constraint    *
	 *    10 2: constraint, not exist    *
	 *    11 3: exists, constraint       *
	 *                                   *
	 *  bit 0: existance                 *
	 *  bit 1: constraint                *
	 *************************************/

	DECLARE
		_Exists bool; 
		_ConstraintExist bool;
		_Output int4;
	BEGIN
		_Exists := EXISTS (
			SELECT true -- whatever, just checking existence
			FROM "<%=_aux_table.Name%>"
			WHERE<%
				for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
					_aux_field = _aux_table.Fields_onlyPK[k];%>
				("<%=_aux_field.Name%>" = "<%=_aux_field.Name%>_")<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
				}%>
		);
		IF (_Exists) THEN
			_ConstraintExist := <%
			if (_aux_table_searches_hasexplicituniqueindex) {
				%>"fnc0_<%=_aux_table.Name%>__ConstraintExist"(<%
				for (int f = 0; f < _aux_table.Fields.Count; f++) {
					_aux_field = _aux_table.Fields[f];%>
				"<%=_aux_field.Name%>_"<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
				}%>
			)<%
			} else {
				%>0<%
			}%>;<%
			if (_aux_table.Fields_noPK.Count == 0) {%>
			/* no need!<%
			}%>
			IF NOT (_ConstraintExist) THEN
				UPDATE "<%=_aux_table.Name%>"
				SET<%
					for (int nk = 0; nk < _aux_table.Fields_noPK.Count; nk++) {
						_aux_field = _aux_table.Fields_noPK[nk];%>
					"<%=_aux_field.Name%>" = "<%=_aux_field.Name%>_"<%=(nk != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
					}%>
				WHERE<%
					for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
						_aux_field = _aux_table.Fields_onlyPK[k];%>
					("<%=_aux_field.Name%>" = "<%=_aux_field.Name%>_")<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
					}%>;
			END IF;<%
			if (_aux_table.Fields_noPK.Count == 0) {
			%>
			*/<%
			}%>
		ELSE
			_ConstraintExist := <%
			if (_aux_table_searches_hasexplicituniqueindex) {
				%>"fnc0_<%=_aux_table.Name%>__ConstraintExist"(<%
				for (int f = 0; f < _aux_table.Fields.Count; f++) {
					_aux_field = _aux_table.Fields[f];%>
				<%=(_aux_field.isPK) ? _aux_field.DBs[_aux_dbservertype].DBType_generic_DBEmptyValue() : "\"" + _aux_field.Name + "_\""%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
				}%>
			)<%
			} else {
				%>0<%
			}%>;
			IF NOT (_ConstraintExist) THEN
				INSERT INTO "<%=_aux_table.Name%>" (<%
					for (int f = 0; f < _aux_table.Fields.Count; f++) {
						_aux_field = _aux_table.Fields[f];%>
					"<%=_aux_field.Name%>"<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
					}%>
				) VALUES (<%
					for (int f = 0; f < _aux_table.Fields.Count; f++) {
						_aux_field = _aux_table.Fields[f];%>
					"<%=_aux_field.Name%>_"<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
					}%>
				);
			END IF;
		END IF;

		_Output := 0;
		IF (_Exists) THEN _Output := _Output + 1; END IF;
		IF (_ConstraintExist) THEN _Output := _Output + 2; END IF;
		RETURN _Output AS "Output_";
	END;
$BODY$ LANGUAGE 'plpgsql' VOLATILE;

<%
//-----------------------------------------------------------------------------------------
%>