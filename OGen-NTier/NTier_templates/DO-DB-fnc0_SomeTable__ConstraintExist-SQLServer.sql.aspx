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

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE FUNCTION [dbo].[fnc0_<%=_aux_db_table.Name%>__ConstraintExist](<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
	@<%=_aux_db_field.Name%> <%=_aux_db_field.TableFieldDBs.TableFieldDBCollection[_aux_dbservertype].DBType%><%=(_aux_db_field.isText && (_aux_db_field.Size <= 8000)) ? " (" + _aux_db_field.Size + ")" : ""%><%=(_aux_db_field.isDecimal && (_aux_db_field.NumericScale > 0)) ? " (" + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale + ")" : ""%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
	}%>
)
RETURNS Bit
AS
BEGIN
	DECLARE @ConstraintExist Bit
	SET @ConstraintExist = 0
	<%for (int s = 0; s < _aux_ex_table.TableSearches.TableSearchCollection.Count; s++) {
		if (_aux_ex_table.TableSearches.TableSearchCollection[s].isExplicitUniqueIndex) {%>
	IF (@ConstraintExist = 0) BEGIN
		SELECT
			@ConstraintExist = 1
		FROM [dbo].[fnc_<%=_aux_db_table.Name%>_isObject_<%=_aux_ex_table.TableSearches.TableSearchCollection[s].Name%>](<%
		for (int p = 0; p < _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count; p++) {%>
			@<%=_aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection[p].TableField_ref.Name%><%=(p != _aux_ex_table.TableSearches.TableSearchCollection[s].TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
		}%>
		)
		WHERE
			NOT (<%
				for (int f = 0; f < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[f];%>
				([<%=_aux_db_field.Name%>] = @<%=_aux_db_field.Name%>)<%=(f != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? " AND" : ""%><%
				}%>
			)
	END
		<%}
	}%>
	RETURN @ConstraintExist
END
--GO


<%
//-----------------------------------------------------------------------------------------
%>