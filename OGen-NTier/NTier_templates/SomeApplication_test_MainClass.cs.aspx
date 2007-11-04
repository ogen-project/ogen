<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

//cDBMetadata_Table _aux_table;
//
//OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
//OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;
//
//int _aux_db_table.hasIdentityKey;
//string[] _aux_configmodes = _aux_metadata.ConfigModes();

#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_ex_metadata.CopyrightText != string.Empty) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;

using OGen.lib.datalayer;

using <%=_aux_ex_metadata.Namespace%>.lib.datalayer;
using <%=_aux_ex_metadata.Namespace%>.lib.businesslayer;

namespace <%=_aux_ex_metadata.Namespace%>.test {
	class MainClass {
		[STAThread]
		static void Main(string[] args) {
			// ...
		}
	}
}