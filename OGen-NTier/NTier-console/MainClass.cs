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
using OGen.lib.generator;
using OGen.NTier.lib.metadata;
using OGen.NTier.lib.generator;

namespace OGen.NTier.presentationlayer.console {
	class MainClass {
		[STAThread]
		static void Main(string[] args_in) {
			#region Console.WriteLine("Copyright (C) 2002 Francisco Monteiro");
			Console.WriteLine(
				@"

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the ""Software""), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

"
			);
			#endregion
			if (args_in.Length == 1) {
				if (File.Exists(args_in[0])) {
					DoIt(args_in[0]);
				} else {
					Console.WriteLine("file doesn't exist");
				}
			} else {
				#if DEBUG
					try {
						long _begin_ticks = DateTime.Now.Ticks;
						DoIt(
							System.IO.Path.Combine(
								#if !NET_1_1
								System.Configuration.ConfigurationManager.AppSettings
								#else
								System.Configuration.ConfigurationSettings.AppSettings
								#endif
									["ogenPath"],

								//@"..\..\OGen-NTier_UTs\OGen-metadatas\MD_OGen-NTier_UTs.OGen-metadata.xml"
								//@"..\..\OGen-NTier_UTs-newTest\OGen-metadatas\MD_OGen-NTier_UTs.OGenXSD-metadata.xml"
								@"..\..\OGen-NTier_UTs\OGen-metadatas\MD_OGen-NTier_UTs.OGenXSD-metadata.xml"
							)
						);
						Console.WriteLine("time: {0}", new DateTime(DateTime.Now.Ticks - _begin_ticks).ToString("HH'H' mm'm' ss's' fff"));
					} catch (Exception _ex) {
						Console.WriteLine(_ex.ToString());
					}

					Console.WriteLine("Press any key to continue...");
					#if !NET_1_1
						Console.ReadKey();
					#else
						Console.ReadLine();
					#endif
				#else
					Console.WriteLine("must provide xml file");
				#endif
			}
		}

		static void DoIt(string filePath_in) {
			cFGenerator _generator = new cFGenerator();
			_generator.Open(
				filePath_in, 
				true, 
				new cFGenerator.dNotifyBack(
					Notify
				)
			);
			_generator.Build(new cGenerator.dBuild(Notify));

			#region oldstuff...
//			#region string _outputDir = ...;
//			string _outputDir = System.IO.Directory.GetParent(
//				Path.GetDirectoryName(filePath_in)
//			).FullName;
//			#endregion
//
//			Notify("", true);
//			Notify("opening...", true);
//			#region _metadata_temp = new cDBMetadata().LoadState_fromXML(filePath_in);
//			Notify("- reading configuration from xml file", true);
//			cDBMetadata _metadata_temp = new cDBMetadata();
//			_metadata_temp.LoadState_fromXML(filePath_in);
//			#endregion
//			#region _metadata = new cDBMetadata().LoadState_fromDB(...);
//			Notify("- reading metadata from db", true);
//			cDBMetadata _metadata = new cDBMetadata();
//			_metadata.LoadState_fromDB(
//				new cDBMetadata.dLoadState_fromDB(
//					Notify
//				), 
//				_metadata_temp.DBs.Default.DBServerType, 
//				_metadata_temp.DBs.Default.Connectionstring, 
//				_metadata_temp.SubAppName
//			);
//			#endregion
//			#region _metadata.LoadState_fromXML(filePath_in, All_butDatabaseER);
//			Notify("- updating metadata with xml file", true);
//			_metadata.LoadState_fromXML(
//				filePath_in, 
//				cDBMetadata.eMetadata.All_butDatabaseER
//			);
//			#endregion
//			#region string _metadataFilePath = ...;
//			string _metadataFilePath = string.Format(
//				"{0}{1}OGen-metadatas{1}MD0_{2}-{3}.OGen-metadata.xml", 
//				/*00*/ _outputDir, 
//				/*01*/ Path.DirectorySeparatorChar, 
//				/*02*/ _metadata_temp.ApplicationName, 
//				/*03*/ _metadata_temp.DBs.Default.DBServerType.ToString()
//			);
//			string _dir = Path.GetDirectoryName(_metadataFilePath);
//			if (!Directory.Exists(_dir)) Directory.CreateDirectory(_dir);
//			#endregion
//			_metadata.SaveState_toXML(_metadataFilePath);
//			Notify("...finished!", true);
//			Notify("", true);
//
//			Notify("generating...", true);
//			#region new cGenerator(...).Build(...);
//			new cGenerator(
//				ConfigurationSettingsBinder.Read("OGen"), 
//				_metadataFilePath, 
//				cDBMetadata.root4xml,
//				ConfigurationSettingsBinder.Read("Templates"), 
//				cTemplates.root4xml,
//				_metadata_temp.DBs.Default.DBServerType, 
//				_metadata_temp.DBs.Default.Connectionstring, 
//				_outputDir
//			).Build(
//				new cGenerator.dBuild(
//					Notify
//				), 
//				_metadata
//			);
//			#endregion
//			Notify("...finished!", true);
//			//Notify("", true);
			#endregion
		}
		#region private static void Notify(string message_in, bool onANewLine_in);
		private static void Notify(string message_in, bool onANewLine_in) {
			if (onANewLine_in) {
				Console.WriteLine(message_in);
			} else {
				Console.Write(message_in);
			}
		}
		#endregion
	}
}
