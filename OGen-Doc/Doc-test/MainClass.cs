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
using System.Xml;
using OGen.lib.collections;
using OGen.lib.generator;
using OGen.lib.templates;
using OGen.Doc.lib.generator;
using OGen.Doc.lib.metadata;
using OGen.Doc.lib.metadata.documentation;

namespace Doc_test {
	public class MainClass {
		#region //test2
//		static void Iteration_found(string message_in) {
//			Console.WriteLine(
//				"iterating: {0} . . .",
//				message_in
//			);
//		}
		#endregion

		[STAThread]
		static void Main(string[] args) {

//			#region test3 - translate bug...
//Console.WriteLine(OGen.Doc.lib.metadata.utils.translate(
//	@"---${code::1}
//---
//${code::1}
//---
//${code::1}
//---",
//	rootmetadata_.DocumentationCollection[0]
//));
//
//			return;
//			#endregion

			#region //test2 - performance tweaks...
//			long _begin_ticks = DateTime.Now.Ticks;
//
//			string filename_
//				= System.IO.Path.Combine(
//					#if !NET_1_1
//					System.Configuration.ConfigurationManager.AppSettings
//					#else
//					System.Configuration.ConfigurationSettings.AppSettings
//					#endif
//						["ogenPath"],
//
//					@"..\..\OGen-NTier\OGen-NTier-Doc\OGenDoc-metadatas\MD_OGen.OGenDoc-metadata.xml"
//				);
//			string _outputDir = System.IO.Directory.GetParent(
//				Path.GetDirectoryName(filename_)
//			).FullName;
//
//			XS__RootMetadata rootmetadata_ = XS__RootMetadata.Load_fromFile(
//				filename_,
//				false
//			);
//
//			Console.WriteLine(
//				"--- instance:  -------------------------------\n{0}\n----------------------------------------------",
//				//rootmetadata_.DocumentationCollection[0].Subjects.SubjectCollection.Count
//				//rootmetadata_.DocumentationCollection[0].DocumentationName
//				//rootmetadata_.DocumentationCollection[0].Subjects.SubjectCollection[0].Description
//				//rootmetadata_.DocumentationCollection[0].Subjects.SubjectCollection[2].IDSubject
//				//rootmetadata_.DocumentationCollection[0].Subjects.SubjectCollection[18].Documents.DocumentCollection[2].IDDocument
//				rootmetadata_.DocumentationCollection[0].Subjects.SubjectCollection[19].Documents.DocumentCollection[1].Document
//			);
//			Console.WriteLine(
//				"--- reflection: ------------------------------\n{0}\n----------------------------------------------",
//				rootmetadata_.Read_fromRoot(
//					//"ROOT.documentation[0].subjects.subject.Count"
//					//"ROOT.documentation[0].documentationName"
//					//"ROOT.documentation[0].subjects.subject[0].description"
//					//"ROOT.documentation[0].subjects.subject[2].idSubject"
//					//"ROOT.documentation[0].subjects.subject[18].documents.document[2].idDocument"
//					"ROOT.documentation[0].subjects.subject[19].documents.document[1].document"
//				)
//			);
//			rootmetadata_.IterateThrough_fromRoot(
//				"ROOT.documentation[n].subjects.subject[n]",
//				//"ROOT.documentation[n].subjects.subject[n].documents.document[n]", 
//				Iteration_found
//			);
//
//			Console.WriteLine("time: {0}", new DateTime(DateTime.Now.Ticks - _begin_ticks).ToString("HH'H' mm'm' ss's' fff"));
//			return;
			#endregion
			#region //test1 - generator...
//			MetaFile[] _metafiles = new MetaFile[rootmetadata_.MetadataFiles.MetadataFiles.Count];
//			for (int i = 0; i < rootmetadata_.MetadataFiles.MetadataFiles.Count; i++) {
//				_metafiles[i] = new MetaFile(
//					Path.Combine(
//						Path.GetDirectoryName(filename_), 
//						rootmetadata_.MetadataFiles.MetadataFiles[i].XMLFilename
//					),
//					XS__documentation.DOCUMENTATION
//				);
//			}
//			cGenerator _generator = new cGenerator(
//				#if !NET_1_1
//				System.Configuration.ConfigurationManager.AppSettings
//				#else
//				System.Configuration.ConfigurationSettings.AppSettings
//				#endif
//					["Templates"],
//				_outputDir, 
//				_metafiles
//			);
//			_generator.Build(
//				Notify, 
//				rootmetadata_
//			);
//			return;
			#endregion
		}
	}
}
