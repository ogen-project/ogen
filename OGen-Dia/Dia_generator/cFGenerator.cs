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
using OGen.Dia.lib.metadata;
using OGen.Dia.lib.metadata.diagram;

namespace OGen.Dia.lib.generator {
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
		#region public XS__diagram Diagram { get ; }
		private XS__diagram diagram_;
		public XS__diagram Diagram {
			get { return diagram_; }
		}
		#endregion
		//#endregion

		#region public Delegates...
		public delegate void dNotifyBack(string message_in, bool onANewLine_in);
		#endregion

		#region public Methods...
		#region //public void New(...);
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
		#endregion
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

			diagram_ = XS__diagram.Load_fromFile(
				filename_
			)[0];
			diagram_.FilePath = filename_;

			if (notifyBack_in != null) notifyBack_in("... finished", true);


			#region more Checking...
			if (notifyBack_in != null) notifyBack_in("checking...", true);

			OGen.lib.datalayer.PostgreSQL.DBUtils_convert_Postgresql _utils_pgsql = new OGen.lib.datalayer.PostgreSQL.DBUtils_convert_Postgresql();
			OGen.lib.datalayer.SQLServer.DBUtils_convert_SQLServer _utils_sqls = new OGen.lib.datalayer.SQLServer.DBUtils_convert_SQLServer();
			System.Data.DbType _dbtype_psql;
			System.Data.DbType _dbtype_sqls;
			bool _isUsingPostgreSQL = false;
			bool _isUsingSQLServer = false;
			DBTableField[] _dbtablefields;
			for (int l = 0; l < diagram_.LayerCollection.Count; l++) {
				for (int o = 0; o < diagram_.LayerCollection[l].ObjectCollection.Count; o++) {
					_dbtablefields = diagram_.Table_search(l, o).TableFields();

					#region _isUsingPostgreSQL = ...; _isUsingSQLServer = ...;
					for (int f = 0; f < _dbtablefields.Length; f++) {
						if (_dbtablefields[f].PostgreSQLTypeName.Trim() != "") {
							_isUsingPostgreSQL = true;
						}
						if (_dbtablefields[f].SQLServerTypeName.Trim() != "") {
							_isUsingSQLServer = true;
						}
						if (
							_isUsingPostgreSQL
							&&
							_isUsingSQLServer
						) {
							break;
						}
					}
					#endregion

					for (int f = 0; f < _dbtablefields.Length; f++) {
						#region checking postgresql field type . . .
						if (
							_isUsingPostgreSQL
							&&
							(_dbtablefields[f].PostgreSQLTypeName.Trim() == "")
						) {
							throw new Exception(string.Format(
								"invalid table field type - empty postgresql type: {0}.{1}",
								_dbtablefields[f].TableName,
								_dbtablefields[f].Name
							));
						} 
						#endregion
						#region checking sql server field type . . .
						if (
							_isUsingSQLServer
							&&
							(_dbtablefields[f].SQLServerTypeName.Trim() == "")
						) {
							throw new Exception(string.Format(
								"invalid table field type - empty sql server type: {0}.{1}",
								_dbtablefields[f].TableName,
								_dbtablefields[f].Name
							));
						} 
						#endregion
						#region checking if field types match . . .
						if (
							_isUsingPostgreSQL
							&&
							_isUsingSQLServer
						) {
							_dbtype_psql = _utils_pgsql.XDbType2DbType(
								_utils_pgsql.XDbType_Parse(
									_dbtablefields[f].PostgreSQLTypeName,
									false
								)
							);
							_dbtype_sqls = _utils_sqls.XDbType2DbType(
								_utils_sqls.XDbType_Parse(
									_dbtablefields[f].SQLServerTypeName,
									false
								)
							);
							if (
								_dbtype_psql
								!=
								_dbtype_sqls
							) {
								throw new Exception(string.Format(
									"table field types don't match: {0}.{1}",
									_dbtablefields[f].TableName,
									_dbtablefields[f].Name
								));
							}
						} 
						#endregion
					}
				}
			}

			if (notifyBack_in != null) notifyBack_in("... finished", true);
			#endregion
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
		#region //public void Save(...);
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
		#endregion
		#region public void Build(cGenerator.dBuild notifyBase_in);
		public void Build(cGenerator.dBuild notifyBase_in) {
			string _outputDir = Path.GetDirectoryName(filename_);
			if (notifyBase_in != null) notifyBase_in("generating...", true);

			MetaFile[] _metafiles = new MetaFile[1];
			_metafiles[0] = new MetaFile(
				filename_,
				XS__diagram.DIAGRAM
			);
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
				diagram_
			);
			if (notifyBase_in != null) notifyBase_in("...finished", true);
		}
		#endregion
		#endregion
	}
}