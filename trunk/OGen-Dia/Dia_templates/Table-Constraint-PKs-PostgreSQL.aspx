﻿<%/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="System.IO" %>
<%@ import namespace="OGen.Dia.Libraries.Metadata" %>
<%@ import namespace="OGen.Dia.Libraries.Metadata.Diagram" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
string _arg_tableId = System.Web.HttpUtility.UrlDecode(Request.QueryString["tableId"]);
#endregion

#region varaux...
XS__diagram _aux_diagram = XS__diagram.Load_fromFile(
	_arg_MetadataFilePath
)[0];
XS_objectType _aux_table = _aux_diagram.Table_search(_arg_tableId);
DBTableField[] _tablefields = _aux_table.TableFields();
OGen.Dia.Libraries.Metadata.Diagram.ForeignKey[] _aux_fks = _aux_table.TableForeignKeys();

bool _aux_first;
bool _aux_HasUnique = false;
bool _aux_HasPK = false;
for (int f = 0; f < _tablefields.Length; f++) {
	if (_tablefields[f].isUnique) {
		_aux_HasUnique = true;
	}

	if (_tablefields[f].IsPK) {
		_aux_HasPK = true;
	}

	if (_aux_HasUnique && _aux_HasPK) {
		break;
	}
}
#endregion
//-----------------------------------------------------------------------------------------

if (_aux_HasPK) {
%>ALTER TABLE "<%=_aux_table.TableName%>"
  ADD CONSTRAINT "<%=_aux_table.TableName%>_pkey" PRIMARY KEY (<%
	_aux_first = true;
	for (int f = 0; f < _tablefields.Length; f++) {
		if (!_tablefields[f].IsPK) {
			continue;
		}%><%=(_aux_first) ? "" : ","%>
    "<%=_tablefields[f].Name%>"<%
		_aux_first = false;
	}%>
  )
;

<%
}%>