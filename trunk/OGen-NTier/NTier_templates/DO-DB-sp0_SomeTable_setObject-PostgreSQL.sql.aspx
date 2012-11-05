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
DBServerTypes _aux_dbservertype = DBServerTypes.PostgreSQL;

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

#endregion
//-----------------------------------------------------------------------------------------
%>CREATE OR REPLACE FUNCTION "sp0_<%=_aux_db_table.Name%>_setObject"(<%
	for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
		_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
	"<%=_aux_db_field.Name%>_" <%=_aux_db_field.TableFieldDBs.TableFieldDBCollection[_aux_dbservertype].DBType%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
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
			FROM "<%=_aux_db_table.Name%>"
			WHERE<%
				for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
					_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
				("<%=_aux_db_field.Name%>" = "<%=_aux_db_field.Name%>_")<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? " AND" : ""%><%
				}%>
		);
		IF (_Exists) THEN
			_ConstraintExist := <%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {
				%>"fnc0_<%=_aux_db_table.Name%>__ConstraintExist"(<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
				"<%=_aux_db_field.Name%>_"<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			)<%
			} else {
				%>0<%
			}%>;<%
			if (_aux_db_table.TableFields_nopk.TableFieldCollection.Count == 0) {%>
			/* no need!<%
			}%>
			IF NOT (_ConstraintExist) THEN
				UPDATE "<%=_aux_db_table.Name%>"
				SET<%
					for (int nk = 0; nk < _aux_db_table.TableFields_nopk.TableFieldCollection.Count; nk++) {
						_aux_db_field = _aux_db_table.TableFields_nopk.TableFieldCollection[nk];%>
					"<%=_aux_db_field.Name%>" = "<%=_aux_db_field.Name%>_"<%=(nk != _aux_db_table.TableFields_nopk.TableFieldCollection.Count - 1) ? ", " : ""%><%
					}%>
				WHERE<%
					for (int k = 0; k < _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count; k++) {
						_aux_db_field = _aux_db_table.TableFields_onlyPK.TableFieldCollection[k];%>
					("<%=_aux_db_field.Name%>" = "<%=_aux_db_field.Name%>_")<%=(k != _aux_db_table.TableFields_onlyPK.TableFieldCollection.Count - 1) ? " AND" : ""%><%
					}%>;
			END IF;<%
			if (_aux_db_table.TableFields_nopk.TableFieldCollection.Count == 0) {
			%>
			*/<%
			}%>
		ELSE
			_ConstraintExist := <%
			if (_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {
				%>"fnc0_<%=_aux_db_table.Name%>__ConstraintExist"(<%
				for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
					_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%><%=""%>
				<%=

					//(_aux_db_field.isPK) 
					//	? "_aux_db_field.TableFieldDBs.TableFieldDBCollection[_aux_dbservertype].DBType_generic.FWEmptyValue 
					//	: "\"" + _aux_db_field.Name + "_\""

					"\"" + _aux_db_field.Name + "_\""

				%><%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
				}%>
			)<%
			} else {
				%>0<%
			}%>;
			IF NOT (_ConstraintExist) THEN
				INSERT INTO "<%=_aux_db_table.Name%>" (<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
					"<%=_aux_db_field.Name%>"<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
					}%>
				) VALUES (<%
					for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
						_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];%>
					"<%=_aux_db_field.Name%>_"<%=(f != _aux_db_table.TableFields.TableFieldCollection.Count - 1) ? ", " : ""%><%
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