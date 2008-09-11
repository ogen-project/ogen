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
using OGen.XSD.lib.metadata;

namespace OGen.XSD.lib.generator {
	public class cFGenerator {
		#region	public cFGenerator();
		public cFGenerator() {
			filenameextendedmetadata_ = string.Empty;
		}
		#endregion

		//#region Properties...
		#region public string FilenameExtendedMetadata { get; }
		private string filenameextendedmetadata_;

		public string FilenameExtendedMetadata {
			get { return filenameextendedmetadata_; }
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
			get { return (filenameextendedmetadata_ != string.Empty); }
		}
		#endregion
		#region public RootMetadata RootMetadata { get ; }
		private RootMetadata rootmetadata_;

		public RootMetadata RootMetadata {
			get { return rootmetadata_; }
		}
		#endregion
		//#endregion

		#region public Delegates...
		public delegate void dNotifyBack(string message_in, bool onANewLine_in);
		#endregion

//		#region Methods...
		#region //public void New(...);
//		public void New(
//			string applicationPath_in, 
//string documentationName_in, 
//			dNotifyBack notifyBack_in
//		) {
//			if (notifyBack_in != null) notifyBack_in("creating...", true);
//			#region XS_Schema _metadata_temp = new XS_Schema(); ...;
//			XS_Schema _metadata_temp = new XS_Schema();
//			_metadata_temp.DocumentationName = documentationName_in;
//			#endregion
//
//			if (notifyBack_in != null) notifyBack_in("- generating xml file", true);
//			#region string _xmlfile = ...;
//			string _xmlfile = string.Format(
//				"{0}{1}OGenXSD-metadatas{1}MD_{2}.OGenXSD-metadata.xml", 
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
		#endregion
//		#region public void Open(...);
		public void Open(
			string filenameextendedmetadata_in,
			bool force_doNOTsave_in, 
			dNotifyBack notifyBack_in
		) {
			#region Checking...
			if (this.hasChanges) {
				if (!force_doNOTsave_in) {
					throw new Exception(string.Format("{0}.{1}.Open(): - must save before open", this.GetType().Namespace, this.GetType().Name));
				}
			}
			#endregion
			filenameextendedmetadata_ = filenameextendedmetadata_in;

			if (notifyBack_in != null) notifyBack_in("opening...", true);
			if (notifyBack_in != null) notifyBack_in("- reading metadata from xml files", true);

			rootmetadata_ = RootMetadata.Load_fromFile(
				filenameextendedmetadata_,
				false
			);

			if (notifyBack_in != null) notifyBack_in("... finished", true);
		}
//		#endregion
		#region public void Close(...);
		public void Close(bool force_doNOTsave_in) {
			if (
				(this.hasChanges) && 
				(!force_doNOTsave_in)
			) {
				throw new Exception(string.Format("{0}.{1}.Open(): - must save before open", this.GetType().Namespace, this.GetType().Name));
			}

			filenameextendedmetadata_ = string.Empty;
		}
		#endregion
//		#region public void Save(...);
//		public void Save() {
//			if (this.hasChanges) {
//
//				rootmetadata_.ExtendedMetadata.SaveState_toFile(
//					filenameextendedmetadata_
//				);
//				for (int i = 0; i < rootmetadata_.SchemaCollection.Count; i++) {
//					rootmetadata_.SchemaCollection[i].SaveState_toFile(
//						Path.Combine(
//							Path.GetDirectoryName(filenameextendedmetadata_),
//							rootmetadata_.ExtendedMetadata.MetadataIndex[i].XMLFilename
//						)
//					);
//				}
//
//				haschanges_ = false;
//			}
//		}
//		#endregion
//		#region public void Build(cGenerator.dBuild notifyBase_in);
		public void Build(cGenerator.dBuild notifyBase_in) {
			#region string _outputDir = ...;
			string _outputDir = System.IO.Directory.GetParent(
				Path.GetDirectoryName(filenameextendedmetadata_)
			).FullName;
			#endregion
			if (notifyBase_in != null) notifyBase_in("generating...", true);

			MetaFile[] _metafiles = new MetaFile[1 + rootmetadata_.MetadataFiles.MetadataFiles.Count];
			_metafiles[0] = new MetaFile(
				filenameextendedmetadata_,
				ExtendedMetadata.METADATA
			);
			for (int i = 0; i < rootmetadata_.MetadataFiles.MetadataFiles.Count; i++) {
				_metafiles[1 + i] = new MetaFile(
					Path.Combine(
						Path.GetDirectoryName(filenameextendedmetadata_), 
						rootmetadata_.MetadataFiles.MetadataFiles[i].XMLFilename
					),
					XS_Schema.SCHEMA
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
//		#endregion
//		#endregion
	}
}
