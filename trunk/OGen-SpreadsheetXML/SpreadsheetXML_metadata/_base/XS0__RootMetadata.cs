#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.SpreadsheetXML.Libraries.Metadata {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	using OGen.Libraries.Generator;
	using OGen.Libraries.Metadata;
	using OGen.SpreadsheetXML.Libraries.Metadata.Spreadsheet;

	#if NET_1_1
	public class XS0__RootMetadata : IMetadata {
	#else
	public partial class XS__RootMetadata : IMetadata {
	#endif
		#region public XS__RootMetadata(...);
		#if NET_1_1
		public XS0__RootMetadata(
		#else
		public XS__RootMetadata(
		#endif
			string metadataFilePath_in
		) {
			string _metadataPath = System.IO.Path.GetDirectoryName(metadataFilePath_in);

			this.metadatafiles_ = Metadatas.Load_fromFile(metadataFilePath_in);

			#region int _total_xxx = ...;
			int _total_spreadsheet = 0;
			for (int f = 0; f < this.metadatafiles_.MetadataFiles.Count; f++) {
				switch (this.metadatafiles_.MetadataFiles[f].XMLFileType) {
					case XS__spreadsheet.SPREADSHEET:
						_total_spreadsheet++;
						break;
				}
			}
			#endregion
			#region string[] _xxxFilePath = new string[_total_xxx];
			string[] _spreadsheetFilePath = new string[
				_total_spreadsheet
			];
			#endregion

			_total_spreadsheet = 0;
			for (int f = 0; f < this.metadatafiles_.MetadataFiles.Count; f++) {
				switch (this.metadatafiles_.MetadataFiles[f].XMLFileType) {
					case XS__spreadsheet.SPREADSHEET:
						_spreadsheetFilePath[_total_spreadsheet] = System.IO.Path.Combine(
							_metadataPath,
							this.metadatafiles_.MetadataFiles[f].XMLFileName
						);
						_total_spreadsheet++;
						break;
				}
			}

			this.spreadsheetcollection_ = new XS__spreadsheetCollection(
				XS__spreadsheet.Load_fromFile(
					(XS__RootMetadata)this, 
					_spreadsheetFilePath
				)
			);
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
		#region public static XS__RootMetadata Load_fromFile(...);
		public static XS__RootMetadata Load_fromFile(
			string metadataFilePath_in, 
			bool useMetadataCache_in,
			bool reinitializeCache_in
		) {
			XS__RootMetadata _output;

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
							XS__RootMetadata.MetadataCache.Add(
								metadataFilePath_in,
								new XS__RootMetadata(
									metadataFilePath_in
								)
							);
						}
					}
				}

				_output = (XS__RootMetadata)XS__RootMetadata.MetadataCache[metadataFilePath_in];
				return _output;
			} else {
				_output = new XS__RootMetadata(
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

		#region public XS__spreadsheetCollection SpreadsheetCollection { get; }
		private XS__spreadsheetCollection spreadsheetcollection_;

		public XS__spreadsheetCollection SpreadsheetCollection {
			get { return this.spreadsheetcollection_; }
		}
		#endregion
		private const string ROOT_SPREADSHEET = XS__spreadsheet.ROOT + "." + XS__spreadsheet.SPREADSHEET + "[";

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

			if (OGen.Libraries.Generator.Utilities.rootExpression_TryParse(
				what_in, 
				ROOT_SPREADSHEET, 
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				for (int i = 0; i < this.spreadsheetcollection_.Count; i++) {
					if (
						what_in.Substring(0, this.spreadsheetcollection_[i].Root_Spreadsheet.Length)
							== this.spreadsheetcollection_[i].Root_Spreadsheet
					) {
						_output = this.spreadsheetcollection_[i].Read_fromRoot(string.Format(
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
			}

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
					typeof(XS__RootMetadata).Namespace,
					typeof(XS__RootMetadata).Name,
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
			OGen.Libraries.Generator.Utilities.IterationFoundDelegate iteration_found_in,
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
			OGen.Libraries.Generator.Utilities.IterationFoundDelegate iteration_found_in,
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
			
			if (OGen.Libraries.Generator.Utilities.rootExpression_TryParse(
				iteration_in,
				ROOT_SPREADSHEET,
				out _begin, 
				out _indexstring, 
				out _end
			)) {
				if (_indexstring == "n") {
					for (int i = 0; i < this.spreadsheetcollection_.Count; i++) {
						this.spreadsheetcollection_[i].IterateThrough_fromRoot(
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
					this.spreadsheetcollection_[
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
			}

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
					typeof(XS__RootMetadata).Namespace,
					typeof(XS__RootMetadata).Name,
					iteration_in
				));
			}
		}
		#endregion
	}
}