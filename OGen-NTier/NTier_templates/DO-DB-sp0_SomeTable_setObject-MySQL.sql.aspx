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
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
bool isFirst;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE `sp0_<%=_aux_table.Name%>_setObject`(<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];%>
	IN `<%=_aux_field.Name%>_` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_field.Size + ")" : ""%>, <%
	}%>

	OUT `Output_` Int
)
	NOT DETERMINISTIC
	SQL SECURITY DEFINER
	COMMENT ''
BEGIN
	DECLARE `Exists` BOOLEAN;
	DECLARE `ConstraintExist` BOOLEAN;

	IF NOT EXISTS (
		SELECT NULL--`<%=_aux_table.Fields[0].Name%>`
		FROM `<%=_aux_table.Name%>`
		WHERE<%
			for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
				_aux_field = _aux_table.Fields_onlyPK[k];%>
			(`<%=_aux_field.Name%>` = `<%=_aux_field.Name%>_`)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
			}%>
	) THEN
		SET `Exists` = false;
		SET `ConstraintExist` = <%
		if (_aux_table_searches_hasexplicituniqueindex) {
			%>`fnc0_<%=_aux_table.Name%>__ConstraintExist`(<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%><%=""%>
			<%=(_aux_field.isPK) ? _aux_field.DBs[_aux_dbservertype].DBType_generic_DBEmptyValue() : "`" + _aux_field.Name + "_`"%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
		)<%
		} else {
			%>false<%
		}%>;
		IF (NOT `ConstraintExist`) THEN
			INSERT INTO `<%=_aux_table.Name%>` (<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
				`<%=_aux_field.Name%>`<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
			) VALUES (<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
				`<%=_aux_field.Name%>_`<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
			);
		END IF;
	ELSE
		SET `Exists` = true;<%

	// Comment: no need to update if table has only (it's) keys,
	// no other fields to update
	if (_aux_table.Fields.Count == _aux_table.Fields.Count_onlyPK()) {%>
		SET `ConstraintExist` = 0;<%
	} else {%>
		SET `ConstraintExist` = <%
		if (_aux_table_searches_hasexplicituniqueindex) {
			%>`fnc0_<%=_aux_table.Name%>__ConstraintExist`(<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
			`<%=_aux_field.Name%>_`<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
		)<%
		} else {
			%>false<%
		}%>;<%
		if (_aux_table.Fields_noPK.Count == 0) {%>
		/* no need!<%
		}%>
		IF (NOT `ConstraintExist`) THEN
			UPDATE `<%=_aux_table.Name%>`
			SET<%
				for (int nk = 0; nk < _aux_table.Fields_noPK.Count; nk++) {
					_aux_field = _aux_table.Fields_noPK[nk];%>
				`<%=_aux_field.Name%>` = `<%=_aux_field.Name%>_`<%=(nk != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
				}%>
			WHERE<%
				for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
					_aux_field = _aux_table.Fields_onlyPK[k];%>
				(`<%=_aux_field.Name%>` = `<%=_aux_field.Name%>_`)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
				}%>;
		END IF;<%
		if (_aux_table.Fields_noPK.Count == 0) {
		%>
		*/<%
		}
	}%>
	END IF;

	SET `Output_` = 0;
	IF (`Exists`) THEN
		SET `Output_` = `Output_` + 1;
	END IF;
	IF (`ConstraintExist`) THEN
		SET `Output_` = `Output_` + 2;
	END IF;
END

<%
//-----------------------------------------------------------------------------------------
%>