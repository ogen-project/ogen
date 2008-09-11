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
string _arg_UpdateName = System.Web.HttpUtility.UrlDecode(Request.QueryString["UpdateName"]);
#endregion

#region varaux...
DBServerTypes _aux_dbservertype = DBServerTypes.SQLServer;

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

OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update 
	= _aux_ex_table.TableUpdates.TableUpdateCollection[_arg_UpdateName];

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

string aux_string;

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE [dbo].[sp0_<%=_aux_db_table.Name%>_updObject_<%=aux_update.Name%>]<%
for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
	_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
	@<%=_aux_field.Name%>_ <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? " (" + _aux_db_field.Size + ")" : ""%><%=(_aux_db_field.isDecimal && (_aux_db_field.NumericScale > 0)) ? " (" + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale + ")" : ""%>, <%
}
for (int f = 0; f < aux_update.TableUpdateParameters.TableFieldRefCollection.Count; f++) {
	_aux_field = aux_update.TableUpdateParameters.TableFieldRefCollection[f].TableField_ref;%>
	@<%=_aux_field.Name%>_update_ <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? " (" + _aux_db_field.Size + ")" : ""%><%=(_aux_db_field.isDecimal && (_aux_db_field.NumericScale > 0)) ? " (" + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale + ")" : ""%><%=(f != aux_update.TableUpdateParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
}
if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>, 
	@ConstraintExist_ Bit OUT<%
}%>
AS<%
if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
	SET @ConstraintExist_ = [dbo].[fnc0_<%=_aux_db_table.Name%>__ConstraintExist](<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_field = _aux_table.TableFields.TableFieldCollection[f];

		if (_aux_field.isPK) {
			aux_string = "@" + _aux_field.Name + "_";
		} else {
			aux_string = "NULL";
			for (int uf = 0; uf < aux_update.TableUpdateParameters.TableFieldRefCollection.Count; uf++) {
				if (_aux_field.Name == aux_update.TableUpdateParameters.TableFieldRefCollection[uf].Field.Name) {
					aux_string = "@" + _aux_field.Name + "_update_";
				}
			}
		}%><%=""%>
		<%=aux_string%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
	}%>
	)

	IF (@ConstraintExist_ = 0) BEGIN<%
}%>
		UPDATE [<%=_aux_db_table.Name%>]
		SET<%
		for (int f = 0; f < aux_update.TableUpdateParameters.TableFieldRefCollection.Count; f++) {
			_aux_field = aux_update.TableUpdateParameters.TableFieldRefCollection[f].TableField_ref;%>
			[<%=_aux_field.Name%>] = @<%=_aux_field.Name%>_update_<%=(f != aux_update.TableUpdateParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
		}%>
		WHERE<%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
			([<%=_aux_field.Name%>] = @<%=_aux_field.Name%>_)<%=(k != _aux_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? " AND" : ""%><%
		}
if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
	END<%
}%>
--GO


<%
//-----------------------------------------------------------------------------------------
%>