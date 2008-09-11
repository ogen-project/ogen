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
string _arg_SearchName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SearchName"]);
#endregion

#region varaux...
DBServerTypes _aux_dbservertype = DBServerTypes.MySQL;

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

XS_tableSearchType _aux_ex_search
	= _aux_ex_table.TableSearches.TableSearchCollection[_arg_SearchName];

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

string _aux_xx_field_name;

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE PROCEDURE `sp0_<%=_aux_db_table.Name%>_Record_open_<%=_aux_search.Name%>_page`(<%
	for (int f = 0; f < _aux_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
		//_aux_field = _aux_metadata.Tables[_aux_search.TableSearchParameters.TableFieldRefCollection[f].TableIndex].TableFields.TableFieldCollection[_aux_search.TableSearchParameters.TableFieldRefCollection[f].TableField_refIndex];
		_aux_field = _aux_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
		_aux_xx_field_name = _aux_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;%>
	IN `<%=_aux_xx_field_name%>_search_` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_db_field.Size + ")" : ""%>, <%
	}%>
	IN `page_` Int,
	IN `page_numRecords_` Int
)
	NOT DETERMINISTIC
	SQL SECURITY DEFINER
	COMMENT ''
BEGIN
	DECLARE `ID_range_begin` BigInt;
	DECLARE `ID_range_end` BigInt;
	SET `ID_range_begin` = ((`page_` - 1) * `page_numRecords_` + 1);
	SET `ID_range_end` = (`page_` * `page_numRecords_`);

	SET NOCOUNT ON;

	CREATE TEMPORARY TABLE `#Table_temp` (
		`ID_range` BigInt IDENTITY,<%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
		`<%=_aux_field.Name%>` <%=_aux_field.DBs[_aux_dbservertype].DBType_inDB_name%><%=(_aux_field.isText) ? "(" + _aux_db_field.Size + ")" : ""%><%=(k != _aux_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
	);
	
	SET ROWCOUNT `ID_range_end`;
	INSERT INTO `#Table_temp` (<%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
		`<%=_aux_field.Name%>`<%=(k != _aux_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
		}%>
	);
	CALL `sp_<%=_aux_db_table.Name%>_Record_open_<%=_aux_search.Name%>`(<%
	for (int f = 0; f < _aux_search.TableSearchParameters.TableFieldRefCollection.Count; f++) {
		//_aux_field = _aux_metadata.Tables[_aux_search.TableSearchParameters.TableFieldRefCollection[f].TableIndex].TableFields.TableFieldCollection[_aux_search.TableSearchParameters.TableFieldRefCollection[f].TableField_refIndex];
		_aux_field = _aux_search.TableSearchParameters.TableFieldRefCollection[f].TableField_ref;
		_aux_xx_field_name = _aux_search.TableSearchParameters.TableFieldRefCollection[f].ParamName;
		%>`<%=_aux_xx_field_name%>_search_`<%=(f != _aux_search.TableSearchParameters.TableFieldRefCollection.Count - 1) ? ", " : ""%><%
	}%>);

	SELECT<%
	for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
		_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
		t1.`<%=_aux_field.Name%>`<%=(k != _aux_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? ", " : ""%><%
	}%>
	FROM `<%=_aux_db_table.Name%>` t1
		INNER JOIN `#Table_temp` t2 ON<%
		for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
			_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
			(t2.`<%=_aux_field.Name%>` = t1.`<%=_aux_field.Name%>`)<%=(k != _aux_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? "AND " : ""%><%
		}%>;

	-- CHANGE where CONDITION IN: `fnc_<%=_aux_db_table.Name%>_Record_open_<%=_aux_search.Name%>`
	-- NOT HERE!
	WHERE (t2.`ID_range` BETWEEN `ID_range_begin` AND `ID_range_end`)

	-- CHANGE order by IN: `sp_<%=_aux_db_table.Name%>_Record_open_<%=_aux_search.Name%>`
	-- NOT HERE!

	DROP TABLE `#Table_temp`;

	SET NOCOUNT OFF;
END

<%
//-----------------------------------------------------------------------------------------
%>