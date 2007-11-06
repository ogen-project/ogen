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

bool __aux_isCollection = false;
ComplexTypeItem[] __aux_isCollection_items = null;

bool _aux_isstandardntype;
string _aux_ntype;

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
using System.Collections;

namespace <%=_aux_rootmetadata.MetadataCollection[0].Namespace%>.<%=_aux_schema.Element.Name%> {
	#if NET_1_1
	public class <%=XS0_%><%=_aux_complextype.Name%> {
	#else
	public partial class <%=XS_%><%=_aux_complextype.Name%> {
	#endif<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%><%=""%>

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;<%

				for (int e = 0; e < _aux_elements.Count; e++) {
					if (_aux_elements[e].MaxOccurs == XS_MaxOccursType.unbounded) {%><%=""%>
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
		internal <%=XS__%>RootMetadata root_ref_;

		[XmlIgnore()]
		public <%=XS__%>RootMetadata root_ref {
			set {
				root_ref_ = value;<%

				for (int e = 0; e < _aux_elements.Count; e++) {
					if (_aux_elements[e].MaxOccurs == XS_MaxOccursType.unbounded) {%><%=""%>
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

		for (int a = 0; a < _aux_complextype.AttributeCollection.Count; a++) {%>
		#region public <%=_aux_complextype.AttributeCollection[a].NType%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_complextype.AttributeCollection[a].Name)%> { get; set; }
		internal <%=_aux_complextype.AttributeCollection[a].NType%> <%=_aux_complextype.AttributeCollection[a].Name.ToLower()%>_;

		[XmlAttribute("<%=_aux_complextype.AttributeCollection[a].Name%>")]
		public <%=_aux_complextype.AttributeCollection[a].NType%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_complextype.AttributeCollection[a].Name)%> {
			get {
				return <%=_aux_complextype.AttributeCollection[a].Name.ToLower()%>_;
			}
			set {
				<%=_aux_complextype.AttributeCollection[a].Name.ToLower()%>_ = value;
			}
		}
		#endregion<%
		}%>

<%
		for (int e = 0; e < _aux_elements.Count; e++) {
			if (_aux_elements[e].MaxOccurs == XS_MaxOccursType.unbounded) {%>
		#region public <%=XS_%><%=_aux_elements[e].Type%>Collection <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_elements[e].Name)%>Collection { get; }
		internal <%=XS_%><%=_aux_elements[e].Type%>Collection <%=_aux_elements[e].Name.ToLower()%>collection_ 
			= new <%=XS_%><%=_aux_elements[e].Type%>Collection();

		[XmlElement("<%=_aux_elements[e].Name%>")]
		public <%=XS_%><%=_aux_elements[e].Type%>[] <%=_aux_elements[e].Name.ToLower()%>collection__xml {
			get { return <%=_aux_elements[e].Name.ToLower()%>collection_.cols__; }
			set { <%=_aux_elements[e].Name.ToLower()%>collection_.cols__ = value; }
		}

		[XmlIgnore()]
		public <%=XS_%><%=_aux_elements[e].Type%>Collection <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_elements[e].Name)%>Collection {
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
		#region public <%=_aux_ntype%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_elements[e].Name)%> { get; set; }
		internal <%=_aux_ntype%> <%=_aux_elements[e].Name.ToLower()%>_;

		[XmlElement("<%=_aux_elements[e].Name%>")]
		public <%=_aux_ntype%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_elements[e].Name)%> {
			get { return <%=_aux_elements[e].Name.ToLower()%>_; }
			set { <%=_aux_elements[e].Name.ToLower()%>_ = value; }
		}
		#endregion<%

		//////////////////////////////////////////////////////////////

				} else {%>
		#region public <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_elements[e].Name)%> { get; set; }
		internal <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_elements[e].Name.ToLower()%>__;

		[XmlIgnore()]
		public <%=XS_%><%=_aux_elements[e].Type%> <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_elements[e].Name)%> {
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
		for (int a = 0; a < _aux_complextype.AttributeCollection.Count; a++) {%><%=""%>
			<%=_aux_complextype.AttributeCollection[a].Name.ToLower()%>_ = <%=_aux_complextype.Name%>_in.<%=_aux_complextype.AttributeCollection[a].Name.ToLower()%>_;<%
		}

		//////////////////////////////////////////////////////////////

		for (int e = 0; e < _aux_elements.Count; e++) {
			if (_aux_elements[e].MaxOccurs == XS_MaxOccursType.unbounded) {%><%=""%>
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
