<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/plain" %>
<%//@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.XSD.lib.metadata" %>
<%@ import namespace="OGen.lib.collections" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_SchemaName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SchemaName"]);
string _arg_ComplexTypeName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ComplexTypeName"]);
#endregion

#region varaux...
RootMetadata _aux_rootmetadata = RootMetadata.Load_fromFile(
	_arg_MetadataFilepath,
	true
);
XS_Schema _aux_schema = _aux_rootmetadata.SchemaCollection[_arg_SchemaName];

XS_ComplexType _aux_complextype = _aux_schema.ComplexType[_arg_ComplexTypeName];
OGenCollection<XS_Element, string> _aux_elements = _aux_complextype.Sequence.Element;

string _aux_complextype_keys_ntype = string.Empty;
string _aux_complextype_keys_name = string.Empty;
bool _aux_complextype_mustimplementcollection = _aux_complextype.mustImplementCollection(
	_arg_SchemaName, 
	out _aux_complextype_keys_ntype, 
	out _aux_complextype_keys_name
);

bool _aux_isstandardntype;
string _aux_ntype;

string XS0_ = _aux_rootmetadata.ExtendedMetadata.PrefixGenerated;
string XS_ = _aux_rootmetadata.ExtendedMetadata.Prefix;
string XS0__ = _aux_rootmetadata.ExtendedMetadata.PrefixBaseGenerated;
string XS__ = _aux_rootmetadata.ExtendedMetadata.PrefixBase;
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_rootmetadata.ExtendedMetadata.CopyrightText != string.Empty) && (_aux_rootmetadata.ExtendedMetadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_rootmetadata.ExtendedMetadata.CopyrightText%>
/*

<%=_aux_rootmetadata.ExtendedMetadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;

namespace <%=_aux_rootmetadata.ExtendedMetadata.Namespace%>.<%=_aux_schema.Element.Name%> {<%--
#if NET_1_1--%>
	#region public class <%=XS_%><%=_aux_complextype.Name%>Collection { ... }
	public class <%=XS_%><%=_aux_complextype.Name%>Collection {
		public <%=XS_%><%=_aux_complextype.Name%>Collection() {
			cols_ = new ArrayList();
		}
<%
if (!_aux_rootmetadata.ExtendedMetadata.isSimple) {%>
		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return parent_ref_;
			}
			set {
				parent_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((<%=XS_%><%=_aux_complextype.Name%>)cols_[i]).parent_ref = this;
				}
			}
		}
		#endregion
		#region public <%=XS__%>RootMetadata root_ref { get; }
		private <%=XS__%>RootMetadata root_ref_;

		public <%=XS__%>RootMetadata root_ref {
			get {
				return root_ref_;
			}
			set {
				root_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((<%=XS_%><%=_aux_complextype.Name%>)cols_[i]).root_ref = value;
				}
			}
		}
		#endregion<%
}%>

		#region internal <%=XS_%><%=_aux_complextype.Name%>[] cols__ { get; set; }
		private ArrayList cols_;

		internal <%=XS_%><%=_aux_complextype.Name%>[] cols__ {
			get {
				<%=XS_%><%=_aux_complextype.Name%>[] _output = new <%=XS_%><%=_aux_complextype.Name%>[cols_.Count];
				cols_.CopyTo(_output);
				return _output;
			}
			set {
				cols_.Clear();
				if (value != null) {
					for (int i = 0; i < value.Length; i++) {
						cols_.Add(value[i]);
					}
				}
			}
		}
		#endregion

		#region public int Count { get; }
		public int Count {
			get {
				return cols_.Count;
			}
		}
		#endregion

		#region public <%=XS_%><%=_aux_complextype.Name%> this[int index_in] { get; }
		public <%=XS_%><%=_aux_complextype.Name%> this[int index_in] {
			get {
				return (<%=XS_%><%=_aux_complextype.Name%>)cols_[index_in];
			}
		}
		#endregion<%
		if (_aux_complextype_keys_name != string.Empty) {%>
		#region public <%=XS_%><%=_aux_complextype.Name%> this[<%=_aux_complextype_keys_ntype%> <%=_aux_complextype_keys_name%>_in] { get; }
		public <%=XS_%><%=_aux_complextype.Name%> this[<%=_aux_complextype_keys_ntype%> <%=_aux_complextype_keys_name%>_in] {
			get {
				int _index = Search(<%=_aux_complextype_keys_name%>_in);
				return (_index == -1)
					? null
					: (<%=XS_%><%=_aux_complextype.Name%>)cols_[_index];
			}
		}
		#endregion
		#region public int Search(...);<%
		if (_aux_complextype_keys_ntype == "string") {%>
		public int Search(string <%=_aux_complextype_keys_name%>_in, bool caseSensitive_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (
					(
						caseSensitive_in
						&&
						(
							<%=_aux_complextype_keys_name%>_in.ToLower() 
							== 
							((XS_<%=_aux_complextype.Name%>)cols_[i]).<%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_complextype_keys_name)%>.ToLower()
						)
					)
					||
					(
						!caseSensitive_in
						&&
						(
							<%=_aux_complextype_keys_name%>_in
							==
							((XS_<%=_aux_complextype.Name%>)cols_[i]).<%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_complextype_keys_name)%>
						)
					)
				) {
					return i;
				}
			}

			return -1;
		}<%
		}%>
		public int Search(<%=_aux_complextype_keys_ntype%> <%=_aux_complextype_keys_name%>_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (<%=_aux_complextype_keys_name%>_in.Equals(((<%=XS_%><%=_aux_complextype.Name%>)cols_[i]).<%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_complextype_keys_name)%>)) {
					return i;
				}
			}

			return -1;
		}
		#endregion<%
		}%>

		#region public int Add(params <%=XS_%><%=_aux_complextype.Name%>[] col_in);
		public int Add(params <%=XS_%><%=_aux_complextype.Name%>[] col_in) {
			int _output = -1;

			for (int i = 0; i < col_in.Length; i++) {
				_output = cols_.Add(col_in[i]);
			}

			return _output;
		}
		#endregion
	}
	#endregion<%--
#endif--%>
}<%
//-----------------------------------------------------------------------------------------
%>
