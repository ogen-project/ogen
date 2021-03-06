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
string _arg_SearchName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SearchName"]);
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

XS_tableSearchType _aux_ex_search
	= _aux_ex_table.TableSearches.TableSearchCollection[_arg_SearchName];

string _aux_xx_field_name;

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType _aux_ex_field;

bool _aux_bool;
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE [dbo].[sp_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_search.Name%>_page]<%
	for (int f = 0; f < _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
		//_aux_ex_field = _aux_metadata.Tables[_aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableIndex].TableFields.TableFieldCollection[_aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableField_refIndex];
		_aux_ex_field = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
		_aux_db_field = _aux_ex_field.parallel_ref;
		_aux_xx_field_name = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
	@<%=_aux_xx_field_name%>_search_ <%=_aux_db_field.TableFieldDBs.TableFieldDBCollection[_aux_dbservertype].DBType%><%=(_aux_db_field.IsText && (_aux_db_field.Size <= 8000)) ? " (" + _aux_db_field.Size + ")" : ""%><%=(_aux_db_field.IsDecimal && (_aux_db_field.NumericScale > 0)) ? " (" + _aux_db_field.NumericPrecision + ", " + _aux_db_field.NumericScale + ")" : ""%>, <%
	}%>
	@page_orderBy_ INT, 
	@page_ BIGINT,
	@page_itemsPerPage_ INT

	-- , @page_itemsCount_ INT

AS
	DECLARE @ID_range_begin BIGINT
	DECLARE @ID_range_end BIGINT
	SET @ID_range_begin = ((@page_ - 1) * @page_itemsPerPage_ + 1)
	SET @ID_range_end = (@page_ * @page_itemsPerPage_)

	SELECT<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
		[<%=_aux_db_field.Name%>]<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
	}%>
	FROM (
		SELECT<%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
			t1.[<%=_aux_db_field.Name%>], <%
			}%>

			ROW_NUMBER() OVER (
				ORDER BY <%
					_aux_bool = false;
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
						if (!(
							_aux_db_field.IsBoolean ||
							(_aux_db_field.IsText && (_aux_db_field.Size > 0) && (_aux_db_field.Size <= 100)) || 
							_aux_db_field.IsInteger || 
							_aux_db_field.IsDecimal ||
							_aux_db_field.IsDateTime
						)) continue;%><%=(_aux_bool) ? "," : ""%>
					CASE WHEN (@page_orderBy_ = <%=f + 1%>) THEN t1.[<%=_aux_db_field.Name%>] END ASC<%
						_aux_bool = true;
					}%>
			) AS __rownum

		FROM [<%=_aux_db_table.Name%>] AS t1
		INNER JOIN [dbo].[fnc_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_search.Name%>](<%
		for (int f = 0; f < _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
			@<%=_aux_xx_field_name%>_search_<%=(f != _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
		}%>
		) AS t2 ON (<%
			for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
				_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
				(t2."<%=_aux_db_field.Name%>" = t1."<%=_aux_db_field.Name%>")<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? " AND" : ""%><%
			}%>
		)
	) AS [<%=_aux_db_table.Name%>]
	WHERE 
		(__rownum BETWEEN @ID_range_begin AND @ID_range_end)

	-- CHANGE WHERE CONDITION IN: [dbo].[fnc_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_search.Name%>]
	-- NOT HERE!

	--SELECT @page_itemsCount_ = COUNT(1) FROM [dbo].[fnc_<%=_aux_db_table.Name%>_Record_open_<%=_aux_ex_search.Name%>](<%
		for (int f = 0; f < _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
			_aux_ex_field = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
			_aux_xx_field_name = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
	--		@<%=_aux_xx_field_name%>_search_<%=(f != _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
		}%>
	--)
--GO


<%
//-----------------------------------------------------------------------------------------
%>