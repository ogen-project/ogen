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
#endregion

#region varaux...
RootMetadata _aux_rootmetadata = RootMetadata.Load_fromFile(
	_arg_MetadataFilepath,
	true
);

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

using OGen.lib.metadata;
using OGen.lib.collections;<%
for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
using <%=_aux_rootmetadata.ExtendedMetadata.Namespace%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>;<%
}%>

namespace <%=_aux_rootmetadata.ExtendedMetadata.Namespace%> {
	public class <%=XS0__%>RootMetadata : iClaSSe_metadata {
		#region public <%=XS0__%>RootMetadata(...);
		public <%=XS0__%>RootMetadata(
			string metadataFilepath_in
		) {
			string _metadataPath = System.IO.Path.GetDirectoryName(metadataFilepath_in);

			metadatafiles_ = Metadatas.Load_fromFile(metadataFilepath_in);

			#region int _total_xxx = ...;<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			int _total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%> = 0;<%
			}
			%>
			for (int f = 0; f < metadatafiles_.MetadataFiles.Count; f++) {
				switch (metadatafiles_.MetadataFiles[f].XMLFileType) {<%
					for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
					case <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>:
						_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>++;
						break;<%
					}%>
				}
			}
			#endregion
			#region string[] _xxxFilepath = new string[_total_xxx];<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			string[] _<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>Filepath = new string[
				_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>
			];<%
			}%>
			#endregion
<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%> = 0;<%
			}%>
			for (int f = 0; f < metadatafiles_.MetadataFiles.Count; f++) {
				switch (metadatafiles_.MetadataFiles[f].XMLFileType) {<%
					for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
					case <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>:
						_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>Filepath[_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>] = System.IO.Path.Combine(
							_metadataPath,
							metadatafiles_.MetadataFiles[f].XMLFilename
						);
						_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>++;
						break;<%
					}%>
				}
			}
<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%><%=""%>
			<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_ = new <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection(
				<%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.Load_fromFile(
					(<%=XS__%>RootMetadata)this, 
					_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>Filepath
				)
			);<%
			}%>
		}
		#endregion

		#region public static Hashtable Metacache { get; }
		private static Hashtable metacache__;

		public static Hashtable Metacache {
			get {
				if (metacache__ == null) {
					metacache__ = new Hashtable();
				}
				return metacache__;
			}
		}
		#endregion
		#region public static <%=XS__%>RootMetadata Load_fromFile(...);
		public static <%=XS__%>RootMetadata Load_fromFile(
			string metadataFilepath_in, 
			bool useMetacache_in
		) {
			string _key = metadataFilepath_in;
			if (
				useMetacache_in
				&&
				(metacache__ != null)
				&&
				Metacache.Contains(_key)
			) {
				return (<%=XS__%>RootMetadata)<%=XS__%>RootMetadata.Metacache[_key];
			} else {
				<%=XS__%>RootMetadata _rootmetadata = new <%=XS__%>RootMetadata(
					metadataFilepath_in
				);
				if (useMetacache_in) {
					<%=XS__%>RootMetadata.Metacache.Add(
						_key, 
						_rootmetadata
					);
				}
				return _rootmetadata;
			}
		}
		#endregion

		#region public Metadatas MetadataFiles { get; }
		private Metadatas metadatafiles_;

		public Metadatas MetadataFiles {
			get { return metadatafiles_; }
		}
		#endregion
<%
		for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
		#region public <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name)%>Collection { get; }
		private <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_;

		public <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection <%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name)%>Collection {
			get { return <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_; }
		}
		#endregion<%
		}%>

<%
		for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
		private const string ROOT_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%> = <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.ROOT + "." + <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%> + "[";<%
		}%>

		#region public string Read_fromRoot(...);
		public string Read_fromRoot(string what_in) {
			string _begin;
			string _indexstring;
			string _end;

			<%for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {
			%><%=(s == 0) ? "" : " else "%>if (OGen.lib.generator.utils.rootExpression_TryParse(
				what_in, 
				ROOT_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>, 
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				for (int i = 0; i < <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_.Count; i++) {
					if (
						what_in.Substring(0, <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_[i].Root_<%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name)%>.Length)
							== <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_[i].Root_<%=_aux_rootmetadata.ExtendedMetadata.CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name)%>
					) {
						return <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_[i].Read_fromRoot(string.Format(
							"{0}{1}{2}",
							_begin,
							i,
							_end
						));
					}
				}
			}<%
			}%>
			throw new Exception(string.Format(
				"\n---\n{0}.{1}.Read_fromRoot(string what_in): can't handle: {2}\n---",
				typeof(<%=XS0__%>RootMetadata).Namespace,
				typeof(<%=XS0__%>RootMetadata).Name,
				what_in
			));
		}
		#endregion
		#region public void IterateThrough_fromRoot(...);
		public void IterateThrough_fromRoot(
			string iteration_in, 
			cClaSSe.dIteration_found iteration_found_in
		) {
			bool _didit = false;
			string _begin;
			string _indexstring;
			string _end;<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			if (OGen.lib.generator.utils.rootExpression_TryParse(
				iteration_in,
				ROOT_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>,
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				if (_indexstring == "n") {
					for (int i = 0; i < <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_.Count; i++) {
						<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_[i].IterateThrough_fromRoot(
							string.Format(
								"{0}{1}{2}",
								_begin, 
								i,
								_end
							), 
							iteration_found_in
						);
					}
					_didit = true;
				} else {
					int _indexint = int.Parse(_indexstring);
					<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower()%>collection_[
						_indexint
					].IterateThrough_fromRoot(
						string.Format(
							"{0}{1}{2}",
							_begin,
							_indexint,
							_end
						),
						iteration_found_in
					);
					_didit = true;
				}
			}<%
			}%>
			if (!_didit) {
				throw new Exception(string.Format(
					"\n---\n{0}.{1}.IterateThrough_fromRoot(...): can't handle: {2}\n---",
					typeof(<%=XS0__%>RootMetadata).Namespace,
					typeof(<%=XS0__%>RootMetadata).Name,
					iteration_in
				));
			}
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>
