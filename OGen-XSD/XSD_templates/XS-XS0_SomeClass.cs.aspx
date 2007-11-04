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
XS_ElementCollection _aux_elements = _aux_complextype.Sequence.Element;

ComplexTypeItem[] _aux_complextype_keys = null;
bool _aux_complextype_mustimplementcollection = _aux_complextype.mustImplementCollection(
	_arg_SchemaName,
	out _aux_complextype_keys
);

bool __aux_isCollection = false;
ComplexTypeItem[] __aux_isCollection_items = null;

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

namespace <%=_aux_rootmetadata.ExtendedMetadata.Namespace%>.<%=_aux_schema.Element.Name%> {
	public class <%=XS0_%><%=_aux_complextype.Name%> {
		public <%=XS0_%><%=_aux_complextype.Name%> (
		) {<%
			for (int e = 0; e < _aux_elements.Count; e++) {
				if (_aux_elements[e].MaxOccurs == XS_Element.MaxOccursEnum.unbounded) {
					__aux_isCollection = _aux_elements[e].isCollection(
						_arg_SchemaName, 
						out __aux_isCollection_items
					);%><%=""%>
			<%=_aux_elements[e].Name.ToLower()%>collection_ = new <%=XS_%><%=_aux_elements[e].Type%>Collection();<%
				}
			}%>
		}<%
		if (_aux_complextype_keys != null) {%>
		public <%=XS0_%><%=_aux_complextype.Name%> (<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) : this (
		) {<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].Name.ToLower()%>_ = <%=_aux_complextype_keys[k].Name%>_in;<%
		}%>
		}<%
		}

if (!_aux_rootmetadata.ExtendedMetadata.isSimple) {%><%=""%>

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;<%

				for (int e = 0; e < _aux_elements.Count; e++) {
					if (_aux_elements[e].MaxOccurs == XS_Element.MaxOccursEnum.unbounded) {%><%=""%>
				<%=_aux_elements[e].Name.ToLower()%>collection_.parent_ref = this;<%

					} else {
						_aux_ntype = OGen.XSD.lib.metadata.utils.Convert_NType(
							_aux_rootmetadata,
							_aux_elements[e].Type,
							out _aux_isstandardntype
						);
						if (!_aux_isstandardntype) {%>
				if (<%=_aux_elements[e].Name.ToLower()%>__ != null) <%=_aux_elements[e].Name.ToLower()%>__.parent_ref = this;<%
						}
					}
				}%>
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public <%=XS__%>RootMetadata root_ref { get; }
		private <%=XS__%>RootMetadata root_ref_;

		[XmlIgnore()]
		public <%=XS__%>RootMetadata root_ref {
			set {
				root_ref_ = value;<%

				for (int e = 0; e < _aux_elements.Count; e++) {
					if (_aux_elements[e].MaxOccurs == XS_Element.MaxOccursEnum.unbounded) {%><%=""%>
				<%=_aux_elements[e].Name.ToLower()%>collection_.root_ref = value;<%

					} else {
						_aux_ntype = OGen.XSD.lib.metadata.utils.Convert_NType(
							_aux_rootmetadata,
							_aux_elements[e].Type,
							out _aux_isstandardntype
						);
						if (!_aux_isstandardntype) {%>
				if (<%=_aux_elements[e].Name.ToLower()%>__ != null) <%=_aux_elements[e].Name.ToLower()%>__.root_ref = value;<%
						}
					}
				}%>
			}
			get { return root_ref_; }
		}
		#endregion<%
}

		for (int a = 0; a < _aux_complextype.Attribute.Count; a++) {%>
		#region public <%=_aux_complextype.Attribute[a].NType%> <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_complextype.Attribute[a].Name)%> { get; set; }
		private <%=_aux_complextype.Attribute[a].NType%> <%=_aux_complextype.Attribute[a].Name.ToLower()%>_;

		[XmlAttribute("<%=_aux_complextype.Attribute[a].Name%>")]
		public <%=_aux_complextype.Attribute[a].NType%> <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_complextype.Attribute[a].Name)%> {
			get {
				return <%=_aux_complextype.Attribute[a].Name.ToLower()%>_;
			}
			set {
				<%=_aux_complextype.Attribute[a].Name.ToLower()%>_ = value;
			}
		}
		#endregion<%
		}%>

<%
		for (int e = 0; e < _aux_elements.Count; e++) {
			if (_aux_elements[e].MaxOccurs == XS_Element.MaxOccursEnum.unbounded) {%>
		#region public <%=XS_%><%=_aux_elements[e].Type%>Collection <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_elements[e].Name)%>Collection { get; }
		private <%=XS_%><%=_aux_elements[e].Type%>Collection <%=_aux_elements[e].Name.ToLower()%>collection_;

		[XmlElement("<%=_aux_elements[e].Name%>")]
		public <%=XS_%><%=_aux_elements[e].Type%>[] <%=_aux_elements[e].Name.ToLower()%>collection__xml {
			get { return <%=_aux_elements[e].Name.ToLower()%>collection_.cols__; }
			set { <%=_aux_elements[e].Name.ToLower()%>collection_.cols__ = value; }
		}

		[XmlIgnore()]
		public <%=XS_%><%=_aux_elements[e].Type%>Collection <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_elements[e].Name)%>Collection {
			get { return <%=_aux_elements[e].Name.ToLower()%>collection_; }
		}
		#endregion<%

		//////////////////////////////////////////////////////////////

			} else {
				_aux_ntype = OGen.XSD.lib.metadata.utils.Convert_NType(
					_aux_rootmetadata,
					_aux_elements[e].Type,
					out _aux_isstandardntype
				);
				if (_aux_isstandardntype) {%>
		#region public <%=_aux_ntype%> <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_elements[e].Name)%> { get; set; }
		private <%=_aux_ntype%> <%=_aux_elements[e].Name.ToLower()%>_;

		[XmlElement("<%=_aux_elements[e].Name%>")]
		public <%=_aux_ntype%> <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_elements[e].Name)%> {
			get { return <%=_aux_elements[e].Name.ToLower()%>_; }
			set { <%=_aux_elements[e].Name.ToLower()%>_ = value; }
		}
		#endregion<%

		//////////////////////////////////////////////////////////////

				} else {%>
		#region public <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_elements[e].Name)%> { get; set; }
		private <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_elements[e].Name.ToLower()%>__;

		[XmlIgnore()]
		public <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_elements[e].Name)%> {
			get {
				if (<%=_aux_elements[e].Name.ToLower()%>__ == null) {
					<%=_aux_elements[e].Name.ToLower()%>__ = new <%=XS_%><%=_aux_elements[e].Type%>();
				}
				return <%=_aux_elements[e].Name.ToLower()%>__;
			}
			set {
				<%=_aux_elements[e].Name.ToLower()%>__ = value;
			}
		}

		[XmlElement("<%=_aux_elements[e].Name%>")]
		public <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_elements[e].Name.ToLower()%>__xml {
			get { return <%=_aux_elements[e].Name.ToLower()%>__; }
			set { <%=_aux_elements[e].Name.ToLower()%>__ = value; }
		}
		#endregion<%
				}
			}
		}%>

		#region public void CopyFrom(...);
		public void CopyFrom(<%=XS_%><%=_aux_complextype.Name%> <%=_aux_complextype.Name%>_in) {
			int _index = -1;
<%
		for (int a = 0; a < _aux_complextype.Attribute.Count; a++) {%><%=""%>
			<%=_aux_complextype.Attribute[a].Name.ToLower()%>_ = <%=_aux_complextype.Name%>_in.<%=_aux_complextype.Attribute[a].Name.ToLower()%>_;<%
		}

		//////////////////////////////////////////////////////////////

		for (int e = 0; e < _aux_elements.Count; e++) {
			if (_aux_elements[e].MaxOccurs == XS_Element.MaxOccursEnum.unbounded) {%><%=""%>
			<%=_aux_elements[e].Name.ToLower()%>collection_.Clear();
			for (int d = 0; d < <%=_aux_complextype.Name%>_in.<%=_aux_elements[e].Name.ToLower()%>collection_.Count; d++) {
				<%=_aux_elements[e].Name.ToLower()%>collection_.Add(
					out _index,
					new <%=XS_%><%=_aux_elements[e].Type%>()
				);
				<%=_aux_elements[e].Name.ToLower()%>collection_[_index].CopyFrom(
					<%=_aux_complextype.Name%>_in.<%=_aux_elements[e].Name.ToLower()%>collection_[d]
				);
			}<%

		//////////////////////////////////////////////////////////////

			} else {
				_aux_ntype = OGen.XSD.lib.metadata.utils.Convert_NType(
					_aux_rootmetadata,
					_aux_elements[e].Type,
					out _aux_isstandardntype
				);
				if (_aux_isstandardntype) {%>
			<%=_aux_elements[e].Name.ToLower()%>_ = <%=_aux_complextype.Name%>_in.<%=_aux_elements[e].Name.ToLower()%>_;<%

		//////////////////////////////////////////////////////////////

				} else {%>
			if (<%=_aux_complextype.Name%>_in.<%=_aux_elements[e].Name.ToLower()%>__ != null) <%=_aux_elements[e].Name.ToLower()%>__.CopyFrom(<%=_aux_complextype.Name%>_in.<%=_aux_elements[e].Name.ToLower()%>__);<%
				}
			}
		}%>
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>
