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
eDBServerTypes _aux_dbservertype = eDBServerTypes.SQLServer;

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
%>CREATE PROCEDURE [dbo].[sp0_<%=_aux_table.Name%>_setObject]<%
	for (int f = 0; f < _aux_table.Fields.Count; f++) {
		_aux_field = _aux_table.Fields[f];%>
	@<%=_aux_field.Name%>_ <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? " (" + _aux_field.Size + ")" : ""%><%=(_aux_field.Numeric_Scale > 0) ? " (" + _aux_field.Numeric_Precision + ", " + _aux_field.Numeric_Scale + ")" : ""%>, <%
	}%>

	@Output_ Int OUT
AS
	DECLARE @Exists Bit
	DECLARE @ConstraintExist Bit

	IF NOT EXISTS (
		SELECT NULL--[<%=_aux_table.Fields[0].Name%>]
		FROM [<%=_aux_table.Name%>]
		WHERE<%
			for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
				_aux_field = _aux_table.Fields_onlyPK[k];%>
			([<%=_aux_field.Name%>] = @<%=_aux_field.Name%>_)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
			}%>
	) BEGIN
		SET @Exists = 0
		SET @ConstraintExist = <%
		if (_aux_table_searches_hasexplicituniqueindex) {
			%>"dbo"."fnc0_<%=_aux_table.Name%>__ConstraintExist"(<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%><%=""%>
			<%=(_aux_field.isPK) ? _aux_field.DBs[_aux_dbservertype].DBType_generic_DBEmptyValue() : "@" + _aux_field.Name + "_"%><%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
		)<%
		} else {
			%>0<%
		}%>
		IF (@ConstraintExist = 0) BEGIN
			INSERT INTO [<%=_aux_table.Name%>] (<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
				[<%=_aux_field.Name%>]<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
			) VALUES (<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
				@<%=_aux_field.Name%>_<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
			)
		END
	END ELSE BEGIN
		SET @Exists = 1<%

	// Comment: no need to update if table has only (it's) keys,
	// no other fields to update
	if (_aux_table.Fields.Count == _aux_table.Fields.Count_onlyPK()) {%>
		SET @ConstraintExist = 0<%
	} else {%>
		SET @ConstraintExist = <%
		if (_aux_table_searches_hasexplicituniqueindex) {
			%>"dbo"."fnc0_<%=_aux_table.Name%>__ConstraintExist"(<%
			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				_aux_field = _aux_table.Fields[f];%>
			@<%=_aux_field.Name%>_<%=(f != _aux_table.Fields.Count - 1) ? ", " : ""%><%
			}%>
		)<%
		} else {
			%>0<%
		}
		if (_aux_table.Fields_noPK.Count == 0) {%>
		/* no need!<%
		}%>
		IF (@ConstraintExist = 0) BEGIN
			UPDATE [<%=_aux_table.Name%>]
			SET<%
				for (int nk = 0; nk < _aux_table.Fields_noPK.Count; nk++) {
					_aux_field = _aux_table.Fields_noPK[nk];%>
				[<%=_aux_field.Name%>] = @<%=_aux_field.Name%>_<%=(nk != _aux_table.Fields_noPK.Count - 1) ? ", " : ""%><%
				}%>
			WHERE<%
				for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
					_aux_field = _aux_table.Fields_onlyPK[k];%>
				([<%=_aux_field.Name%>] = @<%=_aux_field.Name%>_)<%=(k != _aux_table.Fields_onlyPK.Count - 1) ? " AND" : ""%><%
				}%>
		END<%
		if (_aux_table.Fields_noPK.Count == 0) {
		%>
		*/<%
		}
	}%>
	END

	SET @Output_ = 0
	IF (@Exists = 1) BEGIN
		SET @Output_ = @Output_ + 1
	END
	IF (@ConstraintExist = 1) BEGIN
		SET @Output_ = @Output_ + 2
	END
--GO


<%
//-----------------------------------------------------------------------------------------
%>