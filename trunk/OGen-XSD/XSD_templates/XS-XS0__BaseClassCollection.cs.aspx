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
#endregion

#region varaux...
XS__RootMetadata _aux_rootmetadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath,
	true,
	false
);
XS_schemaType _aux_schema = _aux_rootmetadata.SchemaCollection[_arg_SchemaName];

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

namespace <%=_aux_rootmetadata.MetadataCollection[0].Namespace%>.<%=_aux_schema.Element.Name%> {
	using System;
	using System.IO;
	using System.Xml.Serialization;

	#if NET_1_1
	public class <%=XS0__%><%=_aux_schema.Element.Name%>Collection {
	#else
	public partial class <%=XS__%><%=_aux_schema.Element.Name%>Collection {
	#endif
		#if NET_1_1
		public <%=XS0__%><%=_aux_schema.Element.Name%>Collection(
		#else
		public <%=XS__%><%=_aux_schema.Element.Name%>Collection(
		#endif
			<%=XS__%><%=_aux_schema.Element.Name%>[] <%=_aux_schema.Element.Name.ToLower()%>collection_in
		) {
			this.<%=_aux_schema.Element.Name.ToLower()%>collection_ = <%=_aux_schema.Element.Name.ToLower()%>collection_in;
		}

		#region public <%=XS__%><%=_aux_schema.Element.Name%> this[...] { get; }
		private <%=XS__%><%=_aux_schema.Element.Name%>[] <%=_aux_schema.Element.Name.ToLower()%>collection_;

		public <%=XS__%><%=_aux_schema.Element.Name%> this[int index_in] {
			get {
				return this.<%=_aux_schema.Element.Name.ToLower()%>collection_[index_in];
			}
		}
		public <%=XS__%><%=_aux_schema.Element.Name%> this[string name_in] {
			get {
				// ToDos: later! performance

				for (int i = 0; i < this.<%=_aux_schema.Element.Name.ToLower()%>collection_.Length; i++) {
					if (this.<%=_aux_schema.Element.Name.ToLower()%>collection_[i].<%=_aux_rootmetadata.MetadataCollection[0].MetadataIndexCollection[_aux_schema.Element.Name].Index%> == name_in) {
						return this.<%=_aux_schema.Element.Name.ToLower()%>collection_[i];
					}
				}
				throw new Exception(string.Format(
					"{0}.{1}[string name_in]: can't find: {2}",
					typeof(<%=XS__%><%=_aux_schema.Element.Name%>Collection).Namespace, 
					typeof(<%=XS__%><%=_aux_schema.Element.Name%>Collection).Name, 
					name_in
				));
			}
		}
		#endregion
		public int Count { get {
			return this.<%=_aux_schema.Element.Name.ToLower()%>collection_.Length;
		} }
	}
}<%
//-----------------------------------------------------------------------------------------
%>