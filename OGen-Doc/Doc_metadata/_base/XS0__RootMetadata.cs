#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.metadata;
using OGen.lib.collections;
using OGen.Doc.lib.metadata.documentation;

namespace OGen.Doc.lib.metadata {
	#if NET_1_1
	public class XS0__RootMetadata : iClaSSe_metadata {
	#else
	public partial class XS__RootMetadata : iClaSSe_metadata {
	#endif
		#region public XS__RootMetadata(...);
		#if NET_1_1
		public XS0__RootMetadata(
		#else
		public XS__RootMetadata(
		#endif
			string metadataFilepath_in
		) {
			string _metadataPath = System.IO.Path.GetDirectoryName(metadataFilepath_in);

			metadatafiles_ = Metadatas.Load_fromFile(metadataFilepath_in);

			#region int _total_xxx = ...;
			int _total_documentation = 0;
			for (int f = 0; f < metadatafiles_.MetadataFiles.Count; f++) {
				switch (metadatafiles_.MetadataFiles[f].XMLFileType) {
					case XS__documentation.DOCUMENTATION:
						_total_documentation++;
						break;
				}
			}
			#endregion
			#region string[] _xxxFilepath = new string[_total_xxx];
			string[] _documentationFilepath = new string[
				_total_documentation
			];
			#endregion

			_total_documentation = 0;
			for (int f = 0; f < metadatafiles_.MetadataFiles.Count; f++) {
				switch (metadatafiles_.MetadataFiles[f].XMLFileType) {
					case XS__documentation.DOCUMENTATION:
						_documentationFilepath[_total_documentation] = System.IO.Path.Combine(
							_metadataPath,
							metadatafiles_.MetadataFiles[f].XMLFilename
						);
						_total_documentation++;
						break;
				}
			}

			documentationcollection_ = new XS__documentationCollection(
				XS__documentation.Load_fromFile(
					(XS__RootMetadata)this, 
					_documentationFilepath
				)
			);
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
		#region public static XS__RootMetadata Load_fromFile(...);
		public static XS__RootMetadata Load_fromFile(
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
				return (XS__RootMetadata)XS__RootMetadata.Metacache[_key];
			} else {
				XS__RootMetadata _rootmetadata = new XS__RootMetadata(
					metadataFilepath_in
				);
				if (useMetacache_in) {
					XS__RootMetadata.Metacache.Add(
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

		#region public XS__documentationCollection DocumentationCollection { get; }
		private XS__documentationCollection documentationcollection_;

		public XS__documentationCollection DocumentationCollection {
			get { return documentationcollection_; }
		}
		#endregion
		private const string ROOT_DOCUMENTATION = XS__documentation.ROOT + "." + XS__documentation.DOCUMENTATION + "[";

		#region public string Read_fromRoot(...);
		public string Read_fromRoot(string what_in) {
			string _begin;
			string _indexstring;
			string _end;

			if (OGen.lib.generator.utils.rootExpression_TryParse(
				what_in, 
				ROOT_DOCUMENTATION, 
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				for (int i = 0; i < documentationcollection_.Count; i++) {
					if (
						what_in.Substring(0, documentationcollection_[i].Root_Documentation.Length)
							== documentationcollection_[i].Root_Documentation
					) {
						return documentationcollection_[i].Read_fromRoot(string.Format(
							"{0}{1}{2}",
							_begin,
							i,
							_end
						));
					}
				}
			}
			throw new Exception(string.Format(
				"\n---\n{0}.{1}.Read_fromRoot(string what_in): can't handle: {2}\n---",
				typeof(XS__RootMetadata).Namespace,
				typeof(XS__RootMetadata).Name,
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
			string _end;
			if (OGen.lib.generator.utils.rootExpression_TryParse(
				iteration_in,
				ROOT_DOCUMENTATION,
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				if (_indexstring == "n") {
					for (int i = 0; i < documentationcollection_.Count; i++) {
						documentationcollection_[i].IterateThrough_fromRoot(
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
					documentationcollection_[
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
			}
			if (!_didit) {
				throw new Exception(string.Format(
					"\n---\n{0}.{1}.IterateThrough_fromRoot(...): can't handle: {2}\n---",
					typeof(XS__RootMetadata).Namespace,
					typeof(XS__RootMetadata).Name,
					iteration_in
				));
			}
		}
		#endregion
	}
}