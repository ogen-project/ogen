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

using OGen.lib.generator;
using OGen.lib.metadata;
using OGen.SpreadsheetXML.lib.metadata.spreadsheet;

namespace OGen.SpreadsheetXML.lib.metadata {
	#if NET_1_1
	public class XS0__RootMetadata : MetadataInterface {
	#else
	public partial class XS__RootMetadata : MetadataInterface {
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
			int _total_spreadsheet = 0;
			for (int f = 0; f < metadatafiles_.MetadataFiles.Count; f++) {
				switch (metadatafiles_.MetadataFiles[f].XMLFileType) {
					case XS__spreadsheet.SPREADSHEET:
						_total_spreadsheet++;
						break;
				}
			}
			#endregion
			#region string[] _xxxFilepath = new string[_total_xxx];
			string[] _spreadsheetFilepath = new string[
				_total_spreadsheet
			];
			#endregion

			_total_spreadsheet = 0;
			for (int f = 0; f < metadatafiles_.MetadataFiles.Count; f++) {
				switch (metadatafiles_.MetadataFiles[f].XMLFileType) {
					case XS__spreadsheet.SPREADSHEET:
						_spreadsheetFilepath[_total_spreadsheet] = System.IO.Path.Combine(
							_metadataPath,
							metadatafiles_.MetadataFiles[f].XMLFilename
						);
						_total_spreadsheet++;
						break;
				}
			}

			spreadsheetcollection_ = new XS__spreadsheetCollection(
				XS__spreadsheet.Load_fromFile(
					(XS__RootMetadata)this, 
					_spreadsheetFilepath
				)
			);
		}
		#endregion

		#region public static Hashtable Metacache { get; }
		private static Hashtable metacache_ = new Hashtable();

		public static Hashtable Metacache {
			get {
				return metacache_;
			}
		}
		#endregion
		#region public static XS__RootMetadata Load_fromFile(...);
		public static XS__RootMetadata Load_fromFile(
			string metadataFilepath_in, 
			bool useMetacache_in
		) {
			XS__RootMetadata _output;
			lock (metacache_) {
				if (
					useMetacache_in
					&&
					Metacache.Contains(metadataFilepath_in)
				) {
					_output = (XS__RootMetadata)XS__RootMetadata.Metacache[metadataFilepath_in];
					return _output;
				} else {
					_output = new XS__RootMetadata(
						metadataFilepath_in
					);
					if (useMetacache_in) {
						XS__RootMetadata.Metacache.Add(
							metadataFilepath_in, 
							_output
						);
					}
					return _output;
				}
			}
		}
		#endregion

		#region public Metadatas MetadataFiles { get; }
		private Metadatas metadatafiles_;

		public Metadatas MetadataFiles {
			get { return metadatafiles_; }
		}
		#endregion

		#region public XS__spreadsheetCollection SpreadsheetCollection { get; }
		private XS__spreadsheetCollection spreadsheetcollection_;

		public XS__spreadsheetCollection SpreadsheetCollection {
			get { return spreadsheetcollection_; }
		}
		#endregion
		private const string ROOT_SPREADSHEET = XS__spreadsheet.ROOT + "." + XS__spreadsheet.SPREADSHEET + "[";

		#region public string Read_fromRoot(...);
		public string Read_fromRoot(string what_in) {
			string _begin;
			string _indexstring;
			string _end;

			if (OGen.lib.generator.utils.rootExpression_TryParse(
				what_in, 
				ROOT_SPREADSHEET, 
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				for (int i = 0; i < spreadsheetcollection_.Count; i++) {
					if (
						what_in.Substring(0, spreadsheetcollection_[i].Root_Spreadsheet.Length)
							== spreadsheetcollection_[i].Root_Spreadsheet
					) {
						return spreadsheetcollection_[i].Read_fromRoot(string.Format(
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
			OGen.lib.generator.utils.IterationFoundDelegate iteration_found_in,
			ref bool valueHasBeenFound_out
		) {
			valueHasBeenFound_out = false;
			bool _didit = false;
			string _begin;
			string _indexstring;
			string _end;
			if (OGen.lib.generator.utils.rootExpression_TryParse(
				iteration_in,
				ROOT_SPREADSHEET,
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				if (_indexstring == "n") {
					for (int i = 0; i < spreadsheetcollection_.Count; i++) {
						spreadsheetcollection_[i].IterateThrough_fromRoot(
							string.Format(
								"{0}{1}{2}",
								_begin, 
								i,
								_end
							), 
							iteration_found_in, 
							ref valueHasBeenFound_out
						);
					}
					_didit = true;
				} else {
					int _indexint = int.Parse(_indexstring);
					spreadsheetcollection_[
						_indexint
					].IterateThrough_fromRoot(
						string.Format(
							"{0}{1}{2}",
							_begin,
							_indexint,
							_end
						),
						iteration_found_in, 
						ref valueHasBeenFound_out
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