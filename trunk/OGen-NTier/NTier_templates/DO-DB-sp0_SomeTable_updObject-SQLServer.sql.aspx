<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataExtended" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataDB" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
DBServerTypes _aux_dbservertype = DBServerTypes.SQLServer;

XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableType _aux_db_table
	= _aux_db_metadata.Tables.TableCollection[
		_arg_TableName
	];
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableType _aux_ex_table
	= _aux_db_table.parallel_ref;

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType _aux_ex_field;

bool isFirst;

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE [dbo].[sp0_<%=_aux_db_table.Name%>_updObject]<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
	@<%=_aux_db_field.Name%>_ <%=_aux_db_field.TableFieldDBs.TableFieldDBCollection[_aux_dbservertype].DBType%><%=(_aux_db_field.IsText && (_aux_db_field.Size <= 8000)) ? " (" + _aux_db_field.Size + ")" : ""%><%=(_aux_db_field.IsDecimal && (_aux_db_field.NumericScale > 0)) ? " (" + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale + ")" : ""%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
	}%><%
	if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>, 
	@ConstraintExist_ Bit OUT<%
	}%>
AS<%
	if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
	SET @ConstraintExist_ = [dbo].[fnc0_<%=_aux_db_table.Name%>__ConstraintExist](<%
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
		@<%=_aux_db_field.Name%>_<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
	)

	IF (@ConstraintExist_ = 0) BEGIN<%
	}%>
		UPDATE [<%=_aux_db_table.Name%>]
		SET<%
		isFirst = true;
		for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
			_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
			if (!_aux_db_field.IsIdentity) {
				if (!isFirst) {
					%>, <%
				} else {
					isFirst = false;
				}%>
			[<%=_aux_db_field.Name%>] = @<%=_aux_db_field.Name%>_<%
			}
		}%>
		WHERE
			[<%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].Name%>] = @<%=_aux_db_table.TableFields.TableFieldCollection[_aux_db_table.IdentityKey].Name%>_<%
	if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {%>
	END<%
	}%>
--GO


<%
//-----------------------------------------------------------------------------------------
%>