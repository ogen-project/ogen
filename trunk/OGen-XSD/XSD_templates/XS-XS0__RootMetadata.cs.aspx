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

int _aux_alpha = 0;
if (_aux_rootmetadata.SchemaCollection.Count != 0) {
	_aux_alpha = string.Compare(
		"OGen.Libraries.",
		_aux_rootmetadata.MetadataCollection[0].FullNamespaceForSchema(_aux_rootmetadata.SchemaCollection[0].Element.Name),
		false,
		System.Globalization.CultureInfo.CurrentCulture
	);
}

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
	using System.Collections;
	using System.Xml.Serialization;
<%
	if (_aux_alpha <= 0) {%>
	using OGen.Libraries.Generator;
	using OGen.Libraries.Metadata;<%
	}
	for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
	using <%=_aux_rootmetadata.MetadataCollection[0].FullNamespaceForSchema(_aux_rootmetadata.SchemaCollection[s].Element.Name)%>;<%
	}
	if (_aux_alpha > 0) {%>
	using OGen.Libraries.Generator;
	using OGen.Libraries.Metadata;<%
	}%>

	#if NET_1_1
	public class <%=XS0__%>RootMetadata : IMetadata {
	#else
	public partial class <%=XS__%>RootMetadata : IMetadata {
	#endif
		#region public <%=XS__%>RootMetadata(...);
		#if NET_1_1
		public <%=XS0__%>RootMetadata(
		#else
		public <%=XS__%>RootMetadata(
		#endif
			string metadataFilePath_in
		) {
			string _metadataPath = System.IO.Path.GetDirectoryName(metadataFilePath_in);

			this.metadatafiles_ = Metadatas.Load_fromFile(metadataFilePath_in);

			#region int _total_xxx = ...;<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			int _total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = 0;<%
			}
			%>
			for (int f = 0; f < this.metadatafiles_.MetadataFiles.Count; f++) {
				switch (this.metadatafiles_.MetadataFiles[f].XMLFileType) {<%
					for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
					case <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>:
						_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>++;
						break;<%
					}%>
				}
			}
			#endregion
			#region string[] _xxxFilePath = new string[_total_xxx];<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			string[] _<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>FilePath = new string[
				_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>
			];<%
			}%>
			#endregion
<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
			_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%> = 0;<%
			}%>
			for (int f = 0; f < this.metadatafiles_.MetadataFiles.Count; f++) {
				switch (this.metadatafiles_.MetadataFiles[f].XMLFileType) {<%
					for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
					case <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>:
						_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>FilePath[_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>] = System.IO.Path.Combine(
							_metadataPath,
							this.metadatafiles_.MetadataFiles[f].XMLFileName
						);
						_total_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>++;
						break;<%
					}%>
				}
			}
<%
			for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%><%=""%>
			this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_ = new <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection(
				<%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.Load_fromFile(
					(<%=XS__%>RootMetadata)this, 
					_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>FilePath
				)
			);<%
			}%>
		}
		#endregion

		#region public static Hashtable MetadataCache { get; }
		private static Hashtable metadatacache_ = new Hashtable();
		private static object metadatacache_locker = new object();

		public static Hashtable MetadataCache {
			get {
				return metadatacache_;
			}
		}
		#endregion
		#region public static <%=XS__%>RootMetadata Load_fromFile(...);
		public static <%=XS__%>RootMetadata Load_fromFile(
			string metadataFilePath_in, 
			bool useMetadataCache_in,
			bool reinitializeCache_in
		) {
			<%=XS__%>RootMetadata _output;

			if (!useMetadataCache_in || reinitializeCache_in) {
				XS__RootMetadata.MetadataCache.Clear();
				OGen.Libraries.Generator.Utilities.ReflectThrough_Cache_Clear();
			}

			if (useMetadataCache_in) {

				// check before lock
				if (!MetadataCache.Contains(metadataFilePath_in)) {

					lock (metadatacache_locker) {

						// double check, thread safer!
						if (!MetadataCache.Contains(metadataFilePath_in)) {

							// initialization...
							// ...attribution (last thing before unlock)
							<%=XS__%>RootMetadata.MetadataCache.Add(
								metadataFilePath_in,
								new <%=XS__%>RootMetadata(
									metadataFilePath_in
								)
							);
						}
					}
				}

				_output = (<%=XS__%>RootMetadata)<%=XS__%>RootMetadata.MetadataCache[metadataFilePath_in];
				return _output;
			} else {
				_output = new <%=XS__%>RootMetadata(
					metadataFilePath_in
				);
				return _output;
			}
		}
		#endregion

		#region public Metadatas MetadataFiles { get; }
		private Metadatas metadatafiles_;

		public Metadatas MetadataFiles {
			get { return this.metadatafiles_; }
		}
		#endregion
<%
		for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
		#region public <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name, _arg_SchemaName)%>Collection { get; }
		private <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection <%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_;

		public <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>Collection <%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name, _arg_SchemaName)%>Collection {
			get { return this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_; }
		}
		#endregion<%
		}%>

<%
		for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {%>
		private const string ROOT_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%> = <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.ROOT + "." + <%=XS__%><%=_aux_rootmetadata.SchemaCollection[s].Element.Name%>.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%> + "[";<%
		}%>

		#region public string Read_fromRoot(...);
#if NET_1_1
		private Hashtable Read_fromRoot_cache 
			= new Hashtable();
#else
		private System.Collections.Generic.Dictionary<string, string> Read_fromRoot_cache 
			= new System.Collections.Generic.Dictionary<string, string>();
#endif
		private object Read_fromRoot_locker = new object();

		public string Read_fromRoot(string what_in) {
			return this.Read_fromRoot(
				what_in,
				true
			);
		}
		public string Read_fromRoot(
			string what_in,
			bool useCache_in
		) {

			if (useCache_in && this.Read_fromRoot_cache.ContainsKey(what_in)) {
#if NET_1_1
				return (string)this.Read_fromRoot_cache[what_in];
#else
				return this.Read_fromRoot_cache[what_in];
#endif
			}

			bool _didit = false;
			string _output = null;
			string _begin;
			string _indexstring;
			string _end;

			<%for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {
			%><%=(s == 0) ? "" : " else "%>if (OGen.Libraries.Generator.Utilities.rootExpression_TryParse(
				what_in, 
				ROOT_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>, 
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				for (int i = 0; i < this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_.Count; i++) {
					if (
						what_in.Substring(0, this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_[i].Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name, _arg_SchemaName)%>.Length)
							== this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_[i].Root_<%=_aux_rootmetadata.MetadataCollection[0].CaseTranslate(_aux_rootmetadata.SchemaCollection[s].Element.Name, _arg_SchemaName)%>
					) {
						_output = this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_[i].Read_fromRoot(string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"{0}{1}{2}",
							_begin,
							i,
							_end
						));

						_didit = true;
						break;
					}
				}
			}<%
			}%>

			if (_didit) {

				// check before lock
				if (useCache_in && !this.Read_fromRoot_cache.ContainsKey(what_in)) {

					lock (this.Read_fromRoot_locker) {

						// double check, thread safer!
						if (!this.Read_fromRoot_cache.ContainsKey(what_in)) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.Read_fromRoot_cache.Add(what_in, _output);
						}
					}
				}

				return _output;
			} else {
				throw new Exception(string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"\n---\n{0}.{1}.Read_fromRoot(string what_in): can't handle: {2}\n---",
					typeof(<%=XS__%>RootMetadata).Namespace,
					typeof(<%=XS__%>RootMetadata).Name,
					what_in
				));
			}
		}
		#endregion
		#region public void IterateThrough_fromRoot(...);
#if NET_1_1
		private Hashtable IterateThrough_fromRoot_cache
			= new Hashtable();
#else
		private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> IterateThrough_fromRoot_cache 
			= new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>>();
#endif
		private object IterateThrough_fromRoot_locker = new object();

		public void IterateThrough_fromRoot(
			string iteration_in,
			OGen.Libraries.Generator.IterationFound iteration_found_in,
			ref bool valueHasBeenFound_out
		) {
			this.IterateThrough_fromRoot(
				iteration_in,
				iteration_found_in,
				ref valueHasBeenFound_out,
				true
			);
		}
		public void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.Libraries.Generator.IterationFound iteration_found_in,
			ref bool valueHasBeenFound_out,
			bool useCache_in
		) {
#if NET_1_1
			ArrayList _aux;
#else
			System.Collections.Generic.List<string> _aux;
#endif

			if (useCache_in && this.IterateThrough_fromRoot_cache.ContainsKey(iteration_in)) {
#if NET_1_1
				_aux = (ArrayList)this.IterateThrough_fromRoot_cache[iteration_in];
#else
				_aux = this.IterateThrough_fromRoot_cache[iteration_in];
#endif
				for (int i = 0; i < _aux.Count; i++) {
#if NET_1_1
					iteration_found_in((string)_aux[i]);
#else
					iteration_found_in(_aux[i]);
#endif
				}
				valueHasBeenFound_out = _aux.Count > 0;

				return;
			}

#if NET_1_1
			_aux = new ArrayList();
#else
			_aux = new System.Collections.Generic.List<string>();
#endif
			valueHasBeenFound_out = false;
			bool _didit = false;
			string _begin;
			string _indexstring;
			string _end;
			
			<%for (int s = 0; s < _aux_rootmetadata.SchemaCollection.Count; s++) {
			%><%=(s == 0) ? "" : " else "%>if (OGen.Libraries.Generator.Utilities.rootExpression_TryParse(
				iteration_in,
				ROOT_<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToUpper()%>,
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				if (_indexstring == "n") {
					for (int i = 0; i < this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_.Count; i++) {
						this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_[i].IterateThrough_fromRoot(
							string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"{0}{1}{2}",
								_begin, 
								i,
								_end
							), 
							useCache_in
								? delegate(string message_in) {
									_aux.Add(message_in);
								} 
								: iteration_found_in,
							ref valueHasBeenFound_out
						);
					}
					_didit = true;
				} else {
					int _indexint = int.Parse(_indexstring, System.Globalization.CultureInfo.CurrentCulture);
					this.<%=_aux_rootmetadata.SchemaCollection[s].Element.Name.ToLower(System.Globalization.CultureInfo.CurrentCulture)%>collection_[
						_indexint
					].IterateThrough_fromRoot(
						string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"{0}{1}{2}",
							_begin,
							_indexint,
							_end
						),
						useCache_in
							? delegate(string message_in) {
								_aux.Add(message_in);
							} 
							: iteration_found_in,
						ref valueHasBeenFound_out
					);

					_didit = true;
				}
			}<%
			}%>

			if (_didit) {
				if (useCache_in) {
					for (int i = 0; i < _aux.Count; i++) {
#if NET_1_1
						iteration_found_in((string)_aux[i]);
#else
						iteration_found_in(_aux[i]);
#endif
					}
					valueHasBeenFound_out = _aux.Count > 0;

					// check before lock
					if (!this.IterateThrough_fromRoot_cache.ContainsKey(iteration_in)) {

						lock (this.IterateThrough_fromRoot_locker) {

							// double check, thread safer!
							if (!this.IterateThrough_fromRoot_cache.ContainsKey(iteration_in)) {

								// initialization...
								// ...attribution (last thing before unlock)
								this.IterateThrough_fromRoot_cache.Add(
									iteration_in,
									_aux
								);
							}
						}
					}
				}
			} else {
				throw new Exception(string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"\n---\n{0}.{1}.IterateThrough_fromRoot(...): can't handle: {2}\n---",
					typeof(<%=XS__%>RootMetadata).Namespace,
					typeof(<%=XS__%>RootMetadata).Name,
					iteration_in
				));
			}
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>