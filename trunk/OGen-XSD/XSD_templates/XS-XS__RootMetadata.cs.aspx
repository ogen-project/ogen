<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/plain" %>
<%//@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.XSD.Libraries.Metadata" %>
<%@ import namespace="OGen.XSD.Libraries.Metadata.Schema" %>
<%@ import namespace="OGen.XSD.Libraries.Metadata.Metadata" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_rootmetadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);

string XS0_ = _aux_rootmetadata.MetadataCollection[0].PrefixGenerated;
string XS_ = _aux_rootmetadata.MetadataCollection[0].Prefix;
string XS0__ = _aux_rootmetadata.MetadataCollection[0].PrefixBaseGenerated;
string XS__ = _aux_rootmetadata.MetadataCollection[0].PrefixBase;
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_rootmetadata.MetadataCollection[0].CopyrightText != string.Empty) && (_aux_rootmetadata.MetadataCollection[0].CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_rootmetadata.MetadataCollection[0].CopyrightText%>
/*

<%=_aux_rootmetadata.MetadataCollection[0].CopyrightTextLong%>

*/
#endregion
<%
}%>

namespace <%=_aux_rootmetadata.MetadataCollection[0].Namespace%> {
	using System;
	using System.Xml.Serialization;
<%
	for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
	using <%=_aux_rootmetadata.MetadataCollection[0].FullNamespaceForSchema(_aux_rootmetadata.SchemaCollection[s].Element.Name)%>;<%
	}%>

	#if NET_1_1
	public class <%=XS__%>RootMetadata : <%=XS0__%>RootMetadata {
	#else
	public partial class <%=XS__%>RootMetadata {
	#endif
		#if NET_1_1
		public <%=XS__%>RootMetadata (
			string metadataFilePath_in
		) : base (
			metadataFilePath_in
		) {
		}
		#endif
	}
}<%
//-----------------------------------------------------------------------------------------
%>