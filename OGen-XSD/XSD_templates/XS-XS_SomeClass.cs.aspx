<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/plain" %>
<%//@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.XSD.lib.metadata" %>
<%@ import namespace="OGen.XSD.lib.metadata.schema" %>
<%@ import namespace="OGen.XSD.lib.metadata.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_SchemaName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SchemaName"]);
string _arg_ComplexTypeName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ComplexTypeName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_rootmetadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath,
	true
);
XS_schemaType _aux_schema = _aux_rootmetadata.SchemaCollection[_arg_SchemaName];

OGen.XSD.lib.metadata.schema.XS_complexTypeType _aux_complextype = _aux_schema.ComplexTypeCollection[_arg_ComplexTypeName];
XS_elementTypeCollection _aux_elements = _aux_complextype.Sequence.ElementCollection;

ComplexTypeItem[] _aux_complextype_keys = null;
bool _aux_complextype_mustimplementcollection = _aux_complextype.mustImplementCollection(
	_arg_SchemaName,
	out _aux_complextype_keys
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
}%>using System;
using System.Xml.Serialization;

namespace <%=_aux_rootmetadata.MetadataCollection[0].Namespace%>.<%=_aux_schema.Element.Name%> {
	#if NET_1_1
	public class <%=XS_%><%=_aux_complextype.Name%> : <%=XS0_%><%=_aux_complextype.Name%> {
	#else
	public partial class <%=XS_%><%=_aux_complextype.Name%> {
	#endif<%
		if (_aux_complextype_keys != null) {%>
		public <%=XS_%><%=_aux_complextype.Name%> (
		) {
		}
		public <%=XS_%><%=_aux_complextype.Name%> (<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType(_arg_SchemaName)%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].Name.ToLower()%>_ = <%=_aux_complextype_keys[k].Name%>_in;<%
		}%>
		}<%
		}%>
	}
}<%
//-----------------------------------------------------------------------------------------
%>
