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
string _arg_SchemaName = System.Web.HttpUtility.UrlDecode(Request.QueryString["SchemaName"]);
string _arg_ComplexTypeName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ComplexTypeName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_rootmetadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS_schemaType _aux_schema = _aux_rootmetadata.SchemaCollection[_arg_SchemaName];

OGen.XSD.Libraries.Metadata.Schema.XS_complexTypeType _aux_complextype = _aux_schema.ComplexTypeCollection[_arg_ComplexTypeName];
XS_elementTypeCollection _aux_elements = _aux_complextype.Sequence.ElementCollection;

ComplexTypeItem[] _aux_complextype_keys = null;
bool _aux_complextype_mustimplementcollection = _aux_complextype.mustImplementCollection(
	_arg_SchemaName,
	out _aux_complextype_keys
);

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
}%>

namespace <%=_aux_rootmetadata.MetadataCollection[0].Namespace%>.<%=_aux_rootmetadata.MetadataCollection[0].MetadataIndexCollection[_arg_SchemaName].Namespace%> {
	using System;
	using System.Collections;
	#if !NET_1_1
	using System.Collections.Generic;
	#endif
	using System.Xml.Serialization;

	#if NET_1_1
	public class <%=XS0_%><%=_aux_complextype.Name%>Collection {
	#else
	public partial class <%=XS_%><%=_aux_complextype.Name%>Collection {
	#endif
		#if NET_1_1
		public <%=XS0_%><%=_aux_complextype.Name%>Collection() {
		#else
		public <%=XS_%><%=_aux_complextype.Name%>Collection() {
		#endif
			this.cols_ = new
				#if NET_1_1
				ArrayList()
				#else
				List<<%=XS_%><%=_aux_complextype.Name%>>()
				#endif
			;
		}
<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>
		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return this.parent_ref_;
			}
			set {
				this.parent_ref_ = value;
				for (int i = 0; i < this.cols_.Count; i++) {
					#if NET_1_1
					((<%=XS_%><%=_aux_complextype.Name%>)this.cols_[i])
					#else
					this.cols_[i]
					#endif
						.parent_ref = this;
				}
			}
		}
		#endregion
		#region public <%=XS__%>RootMetadata root_ref { get; }
		private <%=XS__%>RootMetadata root_ref_;

		public <%=XS__%>RootMetadata root_ref {
			get {
				return this.root_ref_;
			}
			set {
				this.root_ref_ = value;
				for (int i = 0; i < this.cols_.Count; i++) {
					#if NET_1_1
					((<%=XS_%><%=_aux_complextype.Name%>)this.cols_[i])
					#else
					this.cols_[i]
					#endif
						.root_ref = value;
				}
			}
		}
		#endregion
		#region private void refresh_refs(params <%=XS_%><%=_aux_complextype.Name%>[] col_in);
		private void refresh_refs(params <%=XS_%><%=_aux_complextype.Name%>[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				col_in[i].parent_ref = this;
				col_in[i].root_ref = this.root_ref;
			}
		}
		#endregion<%
}%>

		#region internal <%=XS_%><%=_aux_complextype.Name%>[] cols__ { get; set; }
		#if NET_1_1
		protected ArrayList
		#else
		private List<<%=XS_%><%=_aux_complextype.Name%>>
		#endif
		cols_;

		internal <%=XS_%><%=_aux_complextype.Name%>[] cols__ {
			get {
				<%=XS_%><%=_aux_complextype.Name%>[] _output = new <%=XS_%><%=_aux_complextype.Name%>[this.cols_.Count];
				this.cols_.CopyTo(_output);
				return _output;
			}
			set {
				lock (this.cols_) {
					this.cols_.Clear();
					if (value != null) {
						for (int i = 0; i < value.Length; i++) {
							this.cols_.Add(value[i]);
						}
					}
				}
			}
		}
		#endregion

		#region public int Count { get; }
		public int Count {
			get {
				return this.cols_.Count;
			}
		}
		#endregion

		#region public <%=XS_%><%=_aux_complextype.Name%> this[int index_in] { get; }
		public <%=XS_%><%=_aux_complextype.Name%> this[int index_in] {
			get {
				return 
					#if NET_1_1
					(<%=XS_%><%=_aux_complextype.Name%>)
					#endif
					this.cols_[index_in]
				;
			}
		}
		#endregion<%
if (_aux_complextype_keys != null) {%>
		#region public <%=XS_%><%=_aux_complextype.Name%> this[...] { get; }
		public <%=XS_%><%=_aux_complextype.Name%> this[<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		] {
			get {
				int _index = this.Search(<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				);
				return (_index == -1)
					? null
					: 
						#if NET_1_1
						(<%=XS_%><%=_aux_complextype.Name%>)
						#endif
						this.cols_[_index]
				;
			}
		}
		#endregion

		#region public void Remove(...);
		public void Remove(<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {
			this.RemoveAt(
				this.Search(<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				)
			);
		}
		#endregion
		#region public int Search(...);
		public int Search(<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {
			return this.Search(<%
			for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
				<%=_aux_complextype_keys[k].Name%>_in, 
				<%=(_aux_complextype_keys[k].CaseSensitive) ? "true" : "false"%><%=(k != _aux_complextype_keys.Length - 1) ? ", " : ""%><%
			}%>
			);
		}

		public int Search(<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in, 
			bool <%=_aux_complextype_keys[k].Name%>_caseSensitive_in<%=(k != _aux_complextype_keys.Length - 1) ? ", " : ""%><%
		}%>
		) {
			for (int i = 0; i < this.cols_.Count; i++) {
				if (<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					(
						(
							<%=_aux_complextype_keys[k].Name%>_caseSensitive_in
							&&
							(
								#if NET_1_1
								((<%=XS_%><%=_aux_complextype.Name%>)this.cols_[i])
								#else
								this.cols_[i]
								#endif
									.<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_complextype_keys[k].Name, _arg_SchemaName)%>
								==
								<%=_aux_complextype_keys[k].Name%>_in 
							)
						)
						||
						(
							!<%=_aux_complextype_keys[k].Name%>_caseSensitive_in
							&&
							(
								#if NET_1_1
								((<%=XS_%><%=_aux_complextype.Name%>)this.cols_[i])
								#else
								this.cols_[i]
								#endif
									.<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_complextype_keys[k].Name, _arg_SchemaName)%>.Equals(
										<%=_aux_complextype_keys[k].Name%>_in,
										StringComparison.CurrentCultureIgnoreCase
									)
							)
						)
					)<%=(k == _aux_complextype_keys.Length - 1) ? "" : " &&"%><%
				}%>
				) {
					return i;
				}
			}

			return -1;
		}
		public int Search(<%=XS_%><%=_aux_complextype.Name%> collectionItem_in) {
			for (int i = 0; i < this.cols_.Count; i++) {
				if (<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					(
						#if NET_1_1
						((<%=XS_%><%=_aux_complextype.Name%>)this.cols_[i])
						#else
						this.cols_[i]
						#endif
							.<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_complextype_keys[k].Name, _arg_SchemaName)%>.Equals(
								collectionItem_in.<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_complextype_keys[k].Name, _arg_SchemaName)%>,
								StringComparison.CurrentCulture<%=(_aux_complextype_keys[k].CaseSensitive) ? "" : "IgnoreCase"%>
							)
					)
					<%=(k == _aux_complextype_keys.Length - 1) ? "" : "&&"%><%
				}%>
				) {
					return i;
				}
			}

			return -1;
		}
		#endregion
		#region public void Add(...);
		public virtual void Add(
			bool onlyIfNotExists_in,<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {

			// ToDos: here! this is not thread safe!

			if (
				// even if exists
				!onlyIfNotExists_in
				||
				// doesn't exist
				(this.Search(<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				) == -1)
			) {
				this.Add(<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				);
			}
		}
		public virtual void Add(
			out int returnIndex_out, 
			bool onlyIfNotExists_in, <%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {

			// ToDos: here! this is not thread safe!

			if (
				// even if exists
				!onlyIfNotExists_in
				||
				// doesn't exist
				((returnIndex_out = this.Search(<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				)) == -1)
			) {
				this.Add(
					out returnIndex_out,<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				);
			}
		}
		public void Add(<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {
			this.Add(new <%=XS_%><%=_aux_complextype.Name%>(<%
			for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
				<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
			}%>
			));
		}
		public void Add(
			out int returnIndex_out,<%
		for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
			<%=_aux_complextype_keys[k].NType%> <%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
		}%>
		) {
			this.Add(
				out returnIndex_out, 
				new <%=XS_%><%=_aux_complextype.Name%>(<%
				for (int k = 0; k < _aux_complextype_keys.Length; k++) {%><%=""%>
					<%=_aux_complextype_keys[k].Name%>_in<%=(k == _aux_complextype_keys.Length - 1) ? "" : ","%><%
				}%>
				)
			);
		}
		public virtual void Add(bool onlyIfNotExists_in, params <%=XS_%><%=_aux_complextype.Name%>[] col_in) {

			// ToDos: here! this is not thread safe!

			for (int i = 0; i < col_in.Length; i++) {
				if (
					// even if exists
					!onlyIfNotExists_in
					||
					// doesn't exist
					(this.Search(col_in[i]) == -1)
				) {
					this.Add(col_in[i]);
				}
			}
		}
		public virtual void Add(out int returnIndex_out, bool onlyIfNotExists_in, params <%=XS_%><%=_aux_complextype.Name%>[] col_in) {

			// ToDos: here! this is not thread safe!

			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length; i++) {
				if (
					// even if exists
					!onlyIfNotExists_in
					||
					// doesn't exist
					((returnIndex_out = this.Search(col_in[i])) == -1)
				) {
					this.Add(out returnIndex_out, col_in[i]);
				}
			}
		}
		#endregion<%
}%>
		#region public void Clear();
		public void Clear() {
			this.cols_.Clear();
		}
		#endregion
		#region public void RemoveAt(int index_in);
		public void RemoveAt(int index_in) {
			this.cols_.RemoveAt(index_in);
		}
		#endregion
		#region public void Add(...);
		public void Add(params <%=XS_%><%=_aux_complextype.Name%>[] col_in) {
			int _index = -1;
			this.Add(out _index, col_in);
		}
		public void Add(out int returnIndex_out, params <%=XS_%><%=_aux_complextype.Name%>[] col_in) {<%
if (!_aux_rootmetadata.MetadataCollection[0].isSimple) {%>
			this.refresh_refs(col_in);
<%}%>
			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length - 1; i++) {
				this.cols_.Add(col_in[i]);
			}

			int j = col_in.Length - 1;
			if (j >= 0) {
				#if NET_1_1
				returnIndex_out = this.cols_.Add(col_in[j]);
				#else
				lock (this.cols_) {
					this.cols_.Add(col_in[j]);
					returnIndex_out = this.cols_.Count - 1;
				}
				#endif
			}
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>