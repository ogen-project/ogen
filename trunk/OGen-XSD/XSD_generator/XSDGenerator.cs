#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.XSD.Libraries.Generator {
	using System;
	using System.IO;

	using OGen.Libraries.Generator;
	using OGen.Libraries.Templates;
	using OGen.XSD.Libraries.Metadata;
	using OGen.XSD.Libraries.Metadata.Metadata;
	using OGen.XSD.Libraries.Metadata.Schema;

	public class XSDGenerator {
		#region	public XSDGenerator();
		public XSDGenerator() {
			this.filenameextendedmetadata_ = string.Empty;
		}
		#endregion

		//#region Properties...
		#region public string FilenameExtendedMetadata { get; }
		private string filenameextendedmetadata_;

		public string FilenameExtendedMetadata {
			get { return this.filenameextendedmetadata_; }
		}
		#endregion
		#region public bool HasChanges { get; }
		private bool haschanges_;

		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion
		#region public bool IsOpened { get; }
		public bool IsOpened {
			get { return !string.IsNullOrEmpty(this.filenameextendedmetadata_); }
		}
		#endregion
		#region public XS__RootMetadata RootMetadata { get ; }
		private XS__RootMetadata rootmetadata_;

		public XS__RootMetadata RootMetadata {
			get { return this.rootmetadata_; }
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
//				System.Globalization.CultureInfo.CurrentCulture,
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
			string fileNameExtendedMetadata_in,
			bool force_doNOTSave_in, 
			dNotifyBack notifyBack_in
		) {
			#region Checking...
			if (this.HasChanges) {
				if (!force_doNOTSave_in) {
					throw new Exception(string.Format(
						System.Globalization.CultureInfo.CurrentCulture, 
						"{0}.{1}.Open(): - must save before open", 
						this.GetType().Namespace, 
						this.GetType().Name
					));
				}
			}
			#endregion
			this.filenameextendedmetadata_ = fileNameExtendedMetadata_in;

			if (notifyBack_in != null) notifyBack_in("opening...", true);
			if (notifyBack_in != null) notifyBack_in("- reading metadata from xml files", true);

			this.rootmetadata_ = XS__RootMetadata.Load_fromFile(
				this.filenameextendedmetadata_,
				false,
				true
			);

			if (notifyBack_in != null) notifyBack_in("... finished", true);
		}
//		#endregion
		#region public void Close(...);
		public void Close(bool force_doNOTSave_in) {
			if (
				(this.HasChanges) && 
				(!force_doNOTSave_in)
			) {
				throw new Exception(string.Format(
					System.Globalization.CultureInfo.CurrentCulture, 
					"{0}.{1}.Open(): - must save before open", 
					this.GetType().Namespace, 
					this.GetType().Name
				));
			}

			this.filenameextendedmetadata_ = string.Empty;
		}
		#endregion
//		#region public void Save(...);
//		public void Save() {
//			if (this.HasChanges) {
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
//		#region public void Build(OGenGenerator.dBuild notifyBase_in);
		public void Build(OGenGenerator.dBuild notifyBase_in) {
			#region string _outputDir = ...;
			string _outputDir = System.IO.Directory.GetParent(
				Path.GetDirectoryName(this.filenameextendedmetadata_)
			).FullName;
			#endregion
			if (notifyBase_in != null) notifyBase_in("generating...", true);

			MetaFile[] _metafiles = new MetaFile[1 + this.rootmetadata_.MetadataFiles.MetadataFiles.Count];
			_metafiles[0] = new MetaFile(
				this.filenameextendedmetadata_,
				XS__metadata.METADATA
			);
			for (int i = 0; i < this.rootmetadata_.MetadataFiles.MetadataFiles.Count; i++) {
				_metafiles[1 + i] = new MetaFile(
					Path.Combine(
						Path.GetDirectoryName(this.filenameextendedmetadata_),
						this.rootmetadata_.MetadataFiles.MetadataFiles[i].XMLFilename
					),
					XS__schema.SCHEMA
				);
			}
			new OGenGenerator(
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
				this.rootmetadata_
			);
			if (notifyBase_in != null) notifyBase_in("...finished", true);
		}
//		#endregion
//		#endregion
	}
}
