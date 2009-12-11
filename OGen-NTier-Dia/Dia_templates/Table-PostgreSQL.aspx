<%/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="System.IO" %>
<%@ import namespace="OGen.NTier.Dia.lib.metadata" %>
<%@ import namespace="OGen.NTier.Dia.lib.metadata.diagram" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_tableId = System.Web.HttpUtility.UrlDecode(Request.QueryString["tableId"]);
#endregion

#region varaux...
XS__diagram _aux_diagram = XS__diagram.Load_fromFile(
	_arg_MetadataFilepath
)[0];
XS_objectType _aux_table = _aux_diagram.Table_search(_arg_tableId);
//XS__documentation _aux_doc
//	= _aux_rootmetadata.DocumentationCollection[
//		_arg_DocumentationName
//	];

string _aux_path = Path.GetDirectoryName(_arg_MetadataFilepath);
string _aux_path_directoryname = Path.GetFileName(_aux_path);
#endregion
//-----------------------------------------------------------------------------------------
%>CREATE TABLE "<%=_aux_table.TableName%>" (
  "IDCoworker" serial NOT NULL,
  "Login" character varying(20) NOT NULL,
  "Password" character varying(255) NOT NULL,
  "Name" character varying(100) NOT NULL,
  "EMail" character varying(25) NOT NULL
)
WITH (OIDS=FALSE);