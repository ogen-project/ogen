#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

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

	This program is free software; you can redistribute it and/or modify
	it under the terms of the GNU General Public License as published by
	the Free Software Foundation; either version 2 of the License, or
	at your option) any later version.

	This program is distributed in the hope that it will be useful, 
	but WITHOUT ANY WARRANTY; without even the implied warranty of 
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License 
	along with this program; if not, write to the Free Software 
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 

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
				DoIt(@"X:\MyDocuments\_RAM-unsorted-COPY\MySharedProjects.BerliOS.SVN\OGen-NTier_UTs\OGen-metadatas\MD_OGen-NTier_UTs.OGen-metadata.xml");
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
				new cDBMetadata.dLoadState_fromDB(
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