#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.IO;
using OGen.lib.templates;
using OGen.lib.generator;
using OGen.Doc.lib.metadata;
using OGen.Doc.lib.metadata.documentation;

namespace OGen.Doc.lib.generator {
	public class cFGenerator {
		#region	public cFGenerator();
		public cFGenerator() {
			filename_ = string.Empty;
		}
		#endregion

		//#region public Properties...
		#region public string Filename { get; }
		private string filename_;
		public string Filename {
			get { return filename_; }
		}
		#endregion
		#region public bool hasChanges { get; }
		private bool haschanges_;
		public bool hasChanges {
			get { return haschanges_; }
			set { haschanges_ = value; }
		}
		#endregion
		#region public bool isOpened { get; }
		public bool isOpened {
			get { return (filename_ != string.Empty); }
		}
		#endregion
		#region public XS__RootMetadata RootMetadata { get ; }
		private XS__RootMetadata rootmetadata_;
		public XS__RootMetadata RootMetadata {
			get { return rootmetadata_; }
		}
		#endregion
		//#endregion

		#region public Delegates...
		public delegate void dNotifyBack(string message_in, bool onANewLine_in);
		#endregion

		#region public Methods...
//		#region public void New(...);
//		public void New(
//			string applicationPath_in, 
//			string documentationName_in, 
//			dNotifyBack notifyBack_in
//		) {
//			if (notifyBack_in != null) notifyBack_in("creating...", true);
//			#region DocMetadata _metadata_temp = new DocMetadata(); ...;
//			XS__documentation _metadata_temp = new XS__documentation();
//			_metadata_temp.DocumentationName = documentationName_in;
//			#endregion
//
//			if (notifyBack_in != null) notifyBack_in("- generating xml file", true);
//			#region string _xmlfile = ...;
//			string _xmlfile = string.Format(
//				"{0}{1}OGenDoc-metadatas{1}MD_{2}.OGenDoc-metadata.xml", 
//				/*0*/applicationPath_in, 
//				/*1*/System.IO.Path.DirectorySeparatorChar, 
//				/*2*/documentationName_in
//			);
//			#endregion
//			_metadata_temp.SaveState_toFile(_xmlfile);
//
//			if (notifyBack_in != null) notifyBack_in("... finished!", true);
//			if (notifyBack_in != null) notifyBack_in("", true);
//
//			Open(
//				_xmlfile, 
//				true, 
//				notifyBack_in
//			);
//		}
//		#endregion
		#region public void Open(...);
		public void Open(
			string filename_in, 
			bool force_doNOTsave_in, 
			dNotifyBack notifyBack_in
		) {
			#region Checking...
			if (this.hasChanges) {
				if (!force_doNOTsave_in) {
					throw new Exception(string.Format(
						"{0}.{1}.Open(): - must save before open", 
						this.GetType().Namespace, 
						this.GetType().Name
					));
				}
			}
			#endregion
			filename_ = filename_in;

			if (notifyBack_in != null) notifyBack_in("opening...", true);
			if (notifyBack_in != null) notifyBack_in("- reading metadata from xml file", true);

			rootmetadata_ = XS__RootMetadata.Load_fromFile(
				filename_, 
				false
			);

			if (notifyBack_in != null) notifyBack_in("... finished", true);
		}
		#endregion
		#region public void Close(...);
		public void Close(bool force_doNOTsave_in) {
			if (
				(this.hasChanges) && 
				(!force_doNOTsave_in)
			) {
				throw new Exception(string.Format(
					"{0}.{1}.Open(): - must save before open", 
					this.GetType().Namespace, 
					this.GetType().Name
				));
			}

			filename_ = string.Empty;
		}
		#endregion
//		#region public void Save(...);
//		public void Save() {
//			if (this.hasChanges) {
//
//				metadata_.SaveState_toFile(
//					filename_
//				);
//
//				haschanges_ = false;
//			}
//		}
//		#endregion
		#region public void Build(cGenerator.dBuild notifyBase_in);
		public void Build(cGenerator.dBuild notifyBase_in) {
			#region string _outputDir = ...;
			string _outputDir = System.IO.Directory.GetParent(
				Path.GetDirectoryName(filename_)
			).FullName;
			#endregion
			if (notifyBase_in != null) notifyBase_in("generating...", true);

			MetaFile[] _metafiles = new MetaFile[rootmetadata_.MetadataFiles.MetadataFiles.Count];
			for (int i = 0; i < rootmetadata_.MetadataFiles.MetadataFiles.Count; i++) {
				_metafiles[i] = new MetaFile(
					Path.Combine(
						Path.GetDirectoryName(filename_), 
						rootmetadata_.MetadataFiles.MetadataFiles[i].XMLFilename
					),
					XS__documentation.DOCUMENTATION
				);
			}
			new cGenerator(
				#if !NET_1_1
				System.Configuration.ConfigurationManager.AppSettings
				#else
				System.Configuration.ConfigurationSettings.AppSettings
				#endif
					["Templates"],
				_outputDir, 
				_metafiles
			).Build(
				notifyBase_in, 
				rootmetadata_
			);
			if (notifyBase_in != null) notifyBase_in("...finished", true);
		}
		#endregion
		#endregion
	}
}
