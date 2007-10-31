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
using System.Collections.Generic;
using System.Text;

//using Npgsql;
//using Npgsql.Design;
//using NpgsqlTypes;

using OGen.lib.datalayer;
using OGen.NTier.lib.metadata;
using OGen.NTier.lib.metadata.metadataDB;
using OGen.NTier.lib.metadata.metadataExtended;

namespace OGen.NTier.presentationlayer.test {
	class Program {
		#region //test1...
		//static void xpto(cDBMetadata aux_metadata_in) {
		//    cDBMetadata_Table_Field _aux_field;
		//    cDBMetadata_Table _aux_table;
		//    for (int t = 0; t < aux_metadata_in.Tables.Count; t++) {
		//        _aux_table = aux_metadata_in.Tables[t];

		//        //Console.WriteLine(_aux_table.Name);

		//        //if (_aux_table.Name == "TipoDocumento") {
		//        //    Console.WriteLine(_aux_table.hasIdentityKey());
		//        //    for (int k = 0; k < _aux_table.Fields_onlyPK.Count; k++) {
		//        //        _aux_field = _aux_table.Fields_onlyPK[k];
		//        //        Console.WriteLine("\t> {0}", _aux_field.Name);
		//        //    }
		//        //}

		//        if (_aux_table.Name == "Config") {
		//            for (int f = 0; f < _aux_table.Fields.Count; f++) {
		//                _aux_field = _aux_table.Fields[f];
		//                Console.WriteLine(_aux_field.FriendlyName);
		//            }
		//        }
		//    }
		//    Console.WriteLine("---");
		//}
		#endregion

		static void Main(string[] args) {
//			XS__metadataDB _dbmetadatas = XS__metadataDB.Load_fromDB(
//				
//			);

			Console.WriteLine();
			Console.ReadLine();
			return;

			#region //test1...
			//string _file1 = 
			//    System.IO.Path.Combine(
			//        #if !NET_1_1
			//        System.Configuration.ConfigurationManager.AppSettings
			//        #else
			//        System.Configuration.ConfigurationSettings.AppSettings
			//        #endif
			//            ["ogenPath"],

			//        //@"..\..\OGen-NTier_UTs\OGen-metadatas\MD_OGen-NTier_UTs.OGen-metadata.xml"
			//        @"..\..\OGen-NTier_UTs\OGen-metadatas\xxx_apagar.xml"
			//    )
			//;
			//string _file2 =
			//    System.IO.Path.Combine(
			//        #if !NET_1_1
			//        System.Configuration.ConfigurationManager.AppSettings
			//        #else
			//        System.Configuration.ConfigurationSettings.AppSettings
			//        #endif
			//            ["ogenPath"],

			//        //@"..\..\OGen-NTier_UTs\OGen-metadatas\MD0_OGen-NTier_UTs.OGen-metadata.xml"
			//        @"..\..\OGen-NTier_UTs\OGen-metadatas\xxx0_apagar.xml"
			//    )
			//;
			//DBServerTypes _aux_dbservertype = DBServerTypes.SQLServer;
			//cDBMetadata _aux_metadata;

			//_aux_metadata = new cDBMetadata();
			//#region //testings...
			////_aux_metadata.LoadState_fromDB(
			////    null, 
			////    DBServerTypes.SQLServer,
			////    "server=127.0.0.1;uid=sa;pwd=passpub;database=OGen-NTier_UTs;", 
			////    "", 
			////    true
			////);
			////for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
			////    Console.WriteLine(_aux_metadata.Tables[t].Name);
			////}
			////return;
			//#endregion

			//_aux_metadata.LoadState_fromFile(
			//    _file1
			//);
			//Console.WriteLine("--- {0}", _aux_metadata.ApplicationName);
			//xpto(_aux_metadata);
			//_aux_metadata.SaveState_toFile(
			//    _file2
			//);

			//_aux_metadata = new cDBMetadata();
			//_aux_metadata.LoadState_fromFile(
			//    _file2
			//);
			//xpto(_aux_metadata);
			#endregion
		}
	}
}
