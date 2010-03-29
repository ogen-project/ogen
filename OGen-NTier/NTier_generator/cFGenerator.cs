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
using System.Collections;
using System.IO;
using OGen.lib.templates;
using OGen.lib.generator;
using OGen.lib.datalayer;
using OGen.NTier.lib.metadata;

namespace OGen.NTier.lib.generator {
	public class cFGenerator {
		#region	public cFGenerator();
		public cFGenerator() {
			Filename = string.Empty;
		}
		#endregion

		#region public Delegates...
		public delegate void dNotifyBack(string message_in, bool onANewLine_in);
		#endregion

		//#region public Properties...
		#region public string Filename { get; }
		private string filename__;

		public string Filename {
			get { return filename__; }
			set {
				filename__ = value;
				directoryname__ 
					= (value == string.Empty) 
						? string.Empty 
						: Path.GetDirectoryName(value);
				parentdirectoryname__
					= (value == string.Empty)
						? string.Empty
						: Directory.GetParent(directoryname__).FullName;
			}
		}
		#endregion
		#region public string Directoryname { get; }
		private string directoryname__;

		public string Directoryname {
			get { return directoryname__; }
		}
		#endregion
		#region public string ParentDirectoryname { get; }
		private string parentdirectoryname__;

		public string ParentDirectoryname {
			get { return parentdirectoryname__; }
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
			get { return (Filename != string.Empty); }
		}
		#endregion
		#region public XS__RootMetadata Metadata { get ; }
		private XS__RootMetadata metadata_;

		public XS__RootMetadata Metadata {
			get { return metadata_; }
		}
		#endregion
		//#endregion

		#region private Methods...
		private string businessAssembly(
			string applicationName_in, 
			string applicationNamespace_in, 
			bool isRelease_notDebug_in
		) {
			return string.Format(
				//"{1}_businesslayer{0}bin{0}{4}{0}{2}.lib.businesslayer-{3}.dll",
				"src{0}{1}-businesslayer{0}bin{0}{4}{0}{2}.lib.businesslayer-{3}.dll",
				Path.DirectorySeparatorChar, // __________________ 0
				applicationName_in, // ___________________________ 1
				applicationNamespace_in, // ______________________ 2
				#if NET_1_1
				"1.1",  // _______________________________________ 3
				#elif NET_2_0
				"2.0",  // _______________________________________ 3
				#endif
				isRelease_notDebug_in ? "Release" : "Debug" // ___ 4
			);
		}
		#endregion
		//#region public Methods...
		//#region public void New(...);
		public void New(
			string applicationPath_in, 
			string applicationName_in, 
			string namespace_in, 
			OGen.NTier.lib.metadata.metadataExtended.XS_dbType[] dbs_in,
			dNotifyBack notifyBack_in
		) {
throw new Exception("// ToDos: not implemented!");
			//int _justadded;

			//if (notifyBack_in != null) notifyBack_in("creating...", true);
			//#region cDBMetadata _metadata_temp = new cDBMetadata(); ...;
			//cDBMetadata _metadata_temp = new cDBMetadata();
			//_metadata_temp.ApplicationName = applicationName_in;
			//_metadata_temp.Namespace = namespace_in;
			//_metadata_temp.DBs.Clear();
			//for (int d = 0; d < dbs_in.Length; d++) {
			//    _justadded = _metadata_temp.DBs.Add(
			//        dbs_in[d].DBServerType, 
			//        false
			//    );
			//    _metadata_temp.DBs[_justadded].CopyFrom(
			//        dbs_in[d]
			//    );

			//    //if (d == 0) {
			//    //    // ToDos: here! document this behaviour and describe it throught unit testing
			//    //    // first item in the array, represents default db connection
			//    //    _metadata_temp.Default_DBServerType = _metadata_temp.DBs[_justadded].DBServerType;
			//    //    _metadata_temp.Default_ConfigMode = _metadata_temp.DBs[_justadded].Connections[0].ConfigMode;
			//    //}
			//}
			//_metadata_temp.GUIDDatalayer = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDDatalayer_proxy = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDDatalayer_UTs = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDBusinesslayer = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDBusinesslayer_proxy = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDBusinesslayer_UTs = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDBusiness_client = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDDistributedlayer_webservices_server = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDDistributedlayer_webservices_client = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDDistributedlayer_remoting_server = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDDistributedlayer_remoting_client = System.Guid.NewGuid().ToString("D").ToUpper();
			//_metadata_temp.GUIDTest = System.Guid.NewGuid().ToString("D").ToUpper();
			//#endregion

			//if (notifyBack_in != null) notifyBack_in("- generating xml file", true);
			//#region string _xmlfile = ...;
			//string _xmlfile = string.Format(
			//    //"{0}{1}OGen-metadatas{1}MD_{2}-{3}.OGen-metadata.xml", 
			//    "{0}{1}OGen-metadatas{1}MD_{2}.OGen-metadata.xml", 
			//    /*0*/applicationPath_in, 
			//    /*1*/System.IO.Path.DirectorySeparatorChar, 
			//    /*2*/applicationName_in

			//    // first item in the array, represents default db connection
			//    ///*3*/, dbs_in[0].DBServerType.ToString()
			//);
			//#endregion
			//_metadata_temp.SaveState_toFile(_xmlfile);

			//if (notifyBack_in != null) notifyBack_in("... finished!", true);
			//if (notifyBack_in != null) notifyBack_in("", true);

			//Open(_xmlfile, true, notifyBack_in);
		}
		//#endregion
//		#region public void Open(...);
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
			Filename = filename_in;

			if (notifyBack_in != null) notifyBack_in("opening...", true);
			if (notifyBack_in != null) notifyBack_in("- reading configuration from xml file", true);
			metadata_ = XS__RootMetadata.Load_fromFile(
				Filename,
				false
			);

			#region - reading metadata from business assembly
			string _debug_assembly = Path.Combine(
				ParentDirectoryname,
				businessAssembly(
					metadata_.MetadataExtendedCollection[0].ApplicationName, 
					metadata_.MetadataExtendedCollection[0].ApplicationNamespace, 
					false
				)
			);
			string _release_assembly = Path.Combine(
				ParentDirectoryname,
				businessAssembly(
					metadata_.MetadataExtendedCollection[0].ApplicationName,
					metadata_.MetadataExtendedCollection[0].ApplicationNamespace,
					true
				)
			);
			bool _debug_exits = File.Exists(_debug_assembly);
			bool _release_exits = File.Exists(_release_assembly);
			if (_debug_exits || _release_exits) {
				DateTime _debug_datetime = (_debug_exits) ? File.GetLastWriteTime(_debug_assembly) : DateTime.MinValue;
				DateTime _release_datetime = (_release_exits) ? File.GetLastWriteTime(_release_assembly) : DateTime.MinValue;
				string _assembly 
					= (_debug_datetime > _release_datetime)
						? _debug_assembly
						: _release_assembly;

				if (notifyBack_in != null) notifyBack_in("- reading metadata from business assembly", true);

				OGen.NTier.lib.metadata.metadataBusiness.XS__metadataBusiness _metadatabusiness;
				try {
					_metadatabusiness
						= OGen.NTier.lib.metadata.metadataBusiness.XS__metadataBusiness.Load_fromAssembly(
							_assembly,
							null,
							0
						);
				} catch (Exception _ex) {
					throw new Exception(string.Format(
						"\n---\nfailed to load assembly: {0}\n---\n{1}\n---\n{2}\n---\n{3}\n---", 
						_assembly, 
						_ex.Message, 
						_ex.InnerException,
						_ex.HelpLink
					));
					//_assembly
				}
				_metadatabusiness.ApplicationName = metadata_.MetadataExtendedCollection[0].ApplicationName;

				_metadatabusiness.SaveState_toFile(
					Path.Combine(
						Directoryname,
						string.Format(
							"MD_{0}.OGenXSD-metadataBusiness.xml",
							metadata_.MetadataExtendedCollection[0].ApplicationName
						)
					)
				);

				if (notifyBack_in != null) notifyBack_in("- saving business metadata to xml file", true);
			} else {
				if (notifyBack_in != null) notifyBack_in("- WARNING: no metadata from business assembly to read from", true);
			}
			#endregion

			#region - reading metadata from db
			if (notifyBack_in != null) notifyBack_in("- reading metadata from db", true);
			OGen.NTier.lib.metadata.metadataDB.XS__metadataDB _metadatadb 
				= OGen.NTier.lib.metadata.metadataDB.XS__metadataDB.Load_fromDB(
					null,
					metadata_.MetadataExtendedCollection[0].SubAppName,
					metadata_,
					0,
					metadata_dbconnectionstrings().Convert_toArray()
				);

			// NOTE: this is very important, every parameter / information
			// that's not comming from the database is empty,
			// and needs to be filled in order to be serialized to the xml file:
			_metadatadb.ApplicationName = metadata_.MetadataExtendedCollection[0].ApplicationName;
			for (int ff, tt, t = 0; t < metadata_.MetadataExtendedCollection[0].Tables.TableCollection.Count; t++) {
				for (int f = 0; f < metadata_.MetadataExtendedCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection.Count; f++) {
					if (metadata_.MetadataExtendedCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection[f].isViewPK) {
						tt = _metadatadb.Tables.TableCollection.Search(
							metadata_.MetadataExtendedCollection[0].Tables.TableCollection[t].Name,
							!metadata_.MetadataExtendedCollection[0].DBs.Supports_MySQL
						);
						if (tt < 0) continue;

						ff = _metadatadb.Tables.TableCollection[tt].TableFields.TableFieldCollection.Search(
							metadata_.MetadataExtendedCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection[f].Name,
							!metadata_.MetadataExtendedCollection[0].DBs.Supports_MySQL
						);
						if (ff < 0) continue;

						_metadatadb.Tables.TableCollection[
							tt
						].TableFields.TableFieldCollection[
							ff
						].isPK 
							= true;
					}
				}
			}


			for (int i = 0; i < metadata_.MetadataFiles.MetadataFiles.Count; i++) {
				if (
					metadata_.MetadataFiles.MetadataFiles[i].XMLFileType
					==
					OGen.NTier.lib.metadata.metadataDB.XS__metadataDB.METADATADB
				) {
					if (notifyBack_in != null) notifyBack_in("- saving db metadata to xml file", true);

					//--- BUG: using old db information
					//metadata_.MetadataDBCollection[0].SaveState_toFile(
					//    Path.Combine(
					//        Directoryname,
					//        metadata_.MetadataFiles.MetadataFiles[i].XMLFilename
					//    )
					//);

					//--- DEBUG: using new db information
					_metadatadb.SaveState_toFile(
						Path.Combine(
							Directoryname,
							metadata_.MetadataFiles.MetadataFiles[i].XMLFilename
						)
					);
					break;
				}
			}
			#endregion

			if (notifyBack_in != null) notifyBack_in("- re-reading configuration from xml file", true);
			metadata_ = XS__RootMetadata.Load_fromFile(
				Filename,
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
				throw new Exception(string.Format(
					"{0}.{1}.Open(): - must save before open", 
					this.GetType().Namespace, 
					this.GetType().Name
				));
			}

			Filename = string.Empty;
		}
		#endregion
		//#region public void Save(...);
		public void Save() {
			throw new Exception("// ToDos: not implemented!");

			//if (this.hasChanges) {

			//    metadata_.SaveState_toFile(
			//        Filename
			//    );

			//    haschanges_ = false;
			//}
		}
		//#endregion
//		#region public void Build(cGenerator.dBuild notifyBase_in);
		public void Build(
			cGenerator.dBuild notifyBase_in,
			params string[] templateTypes_in
		) {
			#region string _outputDir = ...;
			string _outputDir = ParentDirectoryname;
			#endregion
			if (notifyBase_in != null) notifyBase_in("generating...", true);

// ToDos: now! need to save MetadataDB to xml file

			MetaFile[] _metafiles = new MetaFile[metadata_.MetadataFiles.MetadataFiles.Count];
			for (int i = 0; i < metadata_.MetadataFiles.MetadataFiles.Count; i++) {
				_metafiles[i] = new MetaFile(
					Path.Combine(
						Directoryname, 
						metadata_.MetadataFiles.MetadataFiles[i].XMLFilename
					),
					metadata_.MetadataFiles.MetadataFiles[i].XMLFileType
				);
			}

			new cGenerator(
				#if !NET_1_1
				System.Configuration.ConfigurationManager.AppSettings
				#else
				System.Configuration.ConfigurationSettings.AppSettings
				#endif
					["Templates"],
				metadata_dbconnectionstrings(), 
				_outputDir, 
				_metafiles
			).Build(
				notifyBase_in, 
				metadata_,
				templateTypes_in
			);
			if (notifyBase_in != null) notifyBase_in("...finished", true);
		}
//		#endregion
		#region private DBConnectionstrings metadata_dbconnectionstrings();
		private DBConnectionstrings metadata_dbconnectionstrings(
		) {
			//#region int _paramCount = ...;
			//int _paramCount = 0;
			//for (int d = 0; d < metadata_.MetadataExtendedCollection[0].DBs.DBCollection.Count; d++)
			//    for (int c = 0; c < metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection.Count; c++)
			//        if (metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection[c].generateSQL)
			//            _paramCount++;
			//#endregion
			//DBSimpleConnectionstring[] _output = new DBSimpleConnectionstring[_paramCount];
			//_paramCount = 0;

			//for (int d = 0; d < metadata_.MetadataExtendedCollection[0].DBs.DBCollection.Count; d++) {
			//    for (int c = 0; c < metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection.Count; c++) {
			//        if (metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection[c].generateSQL) {
			//            _output[_paramCount] = new DBSimpleConnectionstring(
			//                (DBServerTypes)Enum.Parse(
			//                    typeof(DBServerTypes),
			//                    metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBServerType
			//                ),
			//                metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection[c].Connectionstring
			//            );
			//            _paramCount++;
			//        }
			//    }
			//}

			//return _output;

			DBConnectionstrings _output = new DBConnectionstrings();
			for (int d = 0; d < metadata_.MetadataExtendedCollection[0].DBs.DBCollection.Count; d++) {
				for (int c = 0; c < metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection.Count; c++) {
					if (metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection[c].generateSQL) {
						_output.Add(
							(DBServerTypes)Enum.Parse(
								typeof(DBServerTypes), 
								metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBServerType
							), 
							metadata_.MetadataExtendedCollection[0].DBs.DBCollection[d].DBConnections.DBConnectionCollection[c].Connectionstring
						);
					}
				}
			}

			return _output;
		}
		#endregion
		//#endregion
	}
}
