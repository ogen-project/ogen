#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Dia.Libraries.Generator {
	using System;
	using System.IO;
	using OGen.Dia.Libraries.Metadata;
	using OGen.Dia.Libraries.Metadata.Diagram;
	using OGen.Libraries.Generator;
	using OGen.Libraries.Templates;

	public class DiaGenerator {
		#region	public DiaGenerator();
		public DiaGenerator() {
			this.filename_ = string.Empty;
		}
		#endregion

		//#region public Properties...
		#region public string FileName { get; }
		private string filename_;
		public string FileName {
			get { return this.filename_; }
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
			get { return !string.IsNullOrEmpty(this.filename_); }
		}
		#endregion
		#region public XS__diagram Diagram { get ; }
		private XS__diagram diagram_;
		public XS__diagram Diagram {
			get { return this.diagram_; }
		}
		#endregion
		//#endregion

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
//              System.Globalization.CultureInfo.CurrentCulture,
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
			string fileName_in, 
			bool force_doNOTSave_in, 
			OGen.Dia.Libraries.Generator.NotifyBack notifyBack_in
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
			this.filename_ = fileName_in;

			if (notifyBack_in != null) notifyBack_in("opening...", true);
			if (notifyBack_in != null) notifyBack_in("- reading metadata from xml file", true);

			this.diagram_ = XS__diagram.Load_fromFile(
				this.filename_
			)[0];
			this.diagram_.FilePath = this.filename_;

			if (notifyBack_in != null) notifyBack_in("... finished", true);


			#region more Checking...
			if (notifyBack_in != null) notifyBack_in("checking...", true);

			OGen.Libraries.DataLayer.PostgreSQL.DBUtilities_convert_Postgresql _utilities_pgsql = new OGen.Libraries.DataLayer.PostgreSQL.DBUtilities_convert_Postgresql();
			OGen.Libraries.DataLayer.SQLServer.DBUtilities_convert_SQLServer _utilities_sqls = new OGen.Libraries.DataLayer.SQLServer.DBUtilities_convert_SQLServer();
			System.Data.DbType? _dbtype_psql;
			System.Data.DbType? _dbtype_sqls;
			bool _isUsingPostgreSQL = false;
			bool _isUsingSQLServer = false;
			DBTableField[] _dbtablefields;
			DBTableField[] _dbtablefields2;
			OGen.Dia.Libraries.Metadata.Diagram.ForeignKey[] __fks;
			System.Collections.Generic.Dictionary<string, OGen.Dia.Libraries.Metadata.Diagram.ForeignKey> _fks;
			bool _foundFKTable;
			bool _foundFKField;
			for (int l = 0; l < this.diagram_.LayerCollection.Count; l++) {
				for (int o = 0; o < this.diagram_.LayerCollection[l].ObjectCollection.Count; o++) {
					_dbtablefields = this.diagram_.Table_search(l, o).TableFields();
					this.diagram_.Table_search(l, o).TableForeignKeys(
						out __fks,
						out _fks
					);

					#region checking for invalid foreign keys
					if (
						_fks.ContainsKey("")
					) {
						throw new Exception(string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"invalid foreign key at table: {0}.? -> {1}.?",

							this.diagram_.Table_search(l, o).TableName,
							_fks[""].ForeignKey_TableName
						));
					}
					#endregion

					#region _isUsingPostgreSQL = ...; _isUsingSQLServer = ...;
					for (int f = 0; f < _dbtablefields.Length; f++) {
						if (!string.IsNullOrEmpty(_dbtablefields[f].PostgreSQLTypeName)) {
							_isUsingPostgreSQL = true;
						}
						if (!string.IsNullOrEmpty(_dbtablefields[f].SQLServerTypeName)) {
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
						#region checking if db server type supported
						if (
							!_isUsingPostgreSQL
							&&
							!_isUsingSQLServer
						) {
							throw new Exception(string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"no db type defined (should use at least one of the supported db servers: PostgreSQL or SQLServer)",
								_dbtablefields[f].TableName,
								_dbtablefields[f].Name
							));
						}
						#endregion

						#region checking postgresql field type . . .
						_dbtype_psql = null;

						if (
							_isUsingPostgreSQL
						) {
							if (string.IsNullOrEmpty(_dbtablefields[f].PostgreSQLTypeName)) {
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"invalid table field type - empty postgresql type: {0}.{1}",
									_dbtablefields[f].TableName,
									_dbtablefields[f].Name
								));
							}

							_dbtype_psql = _utilities_pgsql.XDbType2DbType(
								_utilities_pgsql.XDbType_Parse(
									_dbtablefields[f].PostgreSQLTypeName,
									false
								)
							);
						} 
						#endregion
						#region checking sql server field type . . .
						_dbtype_sqls = null;

						if (
							_isUsingSQLServer
						) {
							if (string.IsNullOrEmpty(_dbtablefields[f].SQLServerTypeName)) {
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"invalid table field type - empty sql server type: {0}.{1}",
									_dbtablefields[f].TableName,
									_dbtablefields[f].Name
								));
							}

							_dbtype_sqls = _utilities_sqls.XDbType2DbType(
								_utilities_sqls.XDbType_Parse(
									_dbtablefields[f].SQLServerTypeName,
									false
								)
							);
						} 
						#endregion

						#region checking if field types match . . .
						if (
							_isUsingPostgreSQL
							&&
							_isUsingSQLServer
						) {
							if (
								(_dbtype_psql == null)
								||
								(_dbtype_sqls == null)
								||
								(
									_dbtype_psql.Value
									!=
									_dbtype_sqls.Value
								)
							) {
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"table field types don't match: {0}.{1}",
									_dbtablefields[f].TableName,
									_dbtablefields[f].Name
								));
							}
						} 
						#endregion

						#region //checking FKs . . .
						//if (
						//    (_dbtablefields[f].ForeignKey_TableName != null)
						//    &&
						//    (_dbtablefields[f].ForeignKey_TableName.Trim() != "")
						//) {
						//    _foundFKTable = false;
						//    _foundFKField = false;
						//    for (int l2 = 0; l2 < diagram_.LayerCollection.Count; l2++) {
						//        for (int o2 = 0; o2 < diagram_.LayerCollection[l2].ObjectCollection.Count; o2++) {
						//            if (
						//                diagram_.Table_search(l2, o2).TableName
						//                ==
						//                _dbtablefields[f].ForeignKey_TableName
						//            ) {
						//                _dbtablefields2 = diagram_.Table_search(l2, o2).TableFields();

						//                for (int f2 = 0; f2 < _dbtablefields2.Length; f2++) {
						//                    if (
						//                        _dbtablefields2[f2].Name
						//                        ==
						//                        _dbtablefields[f].ForeignKey_TableFieldName
						//                    ) {

						//                        if (
						//                            _dbtablefields2[f2].PostgreSQLTypeName
						//                            !=
						//                            _dbtablefields[f].PostgreSQLTypeName
						//                        ) {
						//                            throw new Exception(string.Format(
						//                                System.Globalization.CultureInfo.CurrentCulture,
						//                                "foreign key postgresql db type mismatch: {0}.{1}",
						//                                _dbtablefields[f].ForeignKey_TableName,
						//                                _dbtablefields[f].ForeignKey_TableFieldName
						//                            ));
						//                        }
						//                        if (
						//                            _dbtablefields2[f2].SQLServerTypeName
						//                            !=
						//                            _dbtablefields[f].SQLServerTypeName
						//                        ) {
						//                            throw new Exception(string.Format(
						//                                System.Globalization.CultureInfo.CurrentCulture,
						//                                "foreign key sql server db type mismatch: {0}.{1}",
						//                                _dbtablefields[f].ForeignKey_TableName,
						//                                _dbtablefields[f].ForeignKey_TableFieldName
						//                            ));
						//                        }

						//                        _foundFKField = true;
						//                        break;
						//                    }
						//                }

						//                _foundFKTable = true;
						//                break;
						//            }
						//        }
						//    }

						//    if (!_foundFKTable) {
						//        throw new Exception(string.Format(
						//            System.Globalization.CultureInfo.CurrentCulture,
						//            "can't find foreign key TABLE: {0}.{1}",
						//            _dbtablefields[f].ForeignKey_TableName,
						//            _dbtablefields[f].ForeignKey_TableFieldName
						//        ));
						//    }
						//    if (!_foundFKField) {
						//        throw new Exception(string.Format(
						//            System.Globalization.CultureInfo.CurrentCulture,
						//            "can't find foreign key FIELD: {0}.{1}",
						//            _dbtablefields[f].ForeignKey_TableName,
						//            _dbtablefields[f].ForeignKey_TableFieldName
						//        ));
						//    }
						//}
						#endregion
						#region checking FKs . . .
						if (
							_fks.ContainsKey(
								_dbtablefields[f].Name
							)
						) {
							_foundFKTable = false;
							_foundFKField = false;
							for (int l2 = 0; l2 < this.diagram_.LayerCollection.Count; l2++) {
								for (int o2 = 0; o2 < this.diagram_.LayerCollection[l2].ObjectCollection.Count; o2++) {
									if (
										this.diagram_.Table_search(l2, o2).TableName
										==
										_fks[_dbtablefields[f].Name].ForeignKey_TableName
									) {
										_dbtablefields2 = this.diagram_.Table_search(l2, o2).TableFields();

										for (int f2 = 0; f2 < _dbtablefields2.Length; f2++) {
											if (
												_dbtablefields2[f2].Name
												==
												_fks[_dbtablefields[f].Name].ForeignKey_TableFieldName
											) {

												if (
													(
														(_dbtablefields2[f2].PostgreSQLTypeName == null)
														!=
														(_dbtablefields[f].PostgreSQLTypeName == null)
													)
													||
													(
														//_dbtablefields2[f2].PostgreSQLTypeName
														//!=
														//_dbtablefields[f].PostgreSQLTypeName

														!(
															(_dbtablefields2[f2].PostgreSQLTypeName == _dbtablefields[f].PostgreSQLTypeName)
															||
															(
																(_dbtablefields2[f2].PostgreSQLTypeName == "serial")
																&&
																(_dbtablefields[f].PostgreSQLTypeName == "integer")
															)
															||
															(
																(_dbtablefields[f].PostgreSQLTypeName == "serial")
																&&
																(_dbtablefields2[f2].PostgreSQLTypeName == "integer")
															)
															||
															(
																(_dbtablefields2[f2].PostgreSQLTypeName == "bigserial")
																&&
																(_dbtablefields[f].PostgreSQLTypeName == "bigint")
															)
															||
															(
																(_dbtablefields[f].PostgreSQLTypeName == "bigserial")
																&&
																(_dbtablefields2[f2].PostgreSQLTypeName == "bigint")
															)
														)
													)
												) {
													throw new Exception(string.Format(
														System.Globalization.CultureInfo.CurrentCulture,
														"foreign key postgresql db type mismatch: {0}.{1} -> {2}.{3}",

														this.diagram_.Table_search(l, o).TableName,
														_dbtablefields[f].Name,

														_fks[_dbtablefields[f].Name].ForeignKey_TableName,
														_fks[_dbtablefields[f].Name].ForeignKey_TableFieldName
													));
												}
												if (
													(
														(_dbtablefields2[f2].SQLServerTypeName == null)
														!=
														(_dbtablefields[f].SQLServerTypeName == null)
													)
													||
													(
														_dbtablefields2[f2].SQLServerTypeName
														!=
														_dbtablefields[f].SQLServerTypeName
													)
												) {
													throw new Exception(string.Format(
														System.Globalization.CultureInfo.CurrentCulture,
														"foreign key sql server db type mismatch: {0}.{1} -> {2}.{3}",

														this.diagram_.Table_search(l, o).TableName,
														_dbtablefields[f].Name,

														_fks[_dbtablefields[f].Name].ForeignKey_TableName,
														_fks[_dbtablefields[f].Name].ForeignKey_TableFieldName
													));
												}

												_foundFKField = true;
												break;
											}
										}

										_foundFKTable = true;
										break;
							        }
							    }
							}

							if (!_foundFKTable) {
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"can't find foreign key TABLE: {0}.{1} -> {2}.{3}",

									this.diagram_.Table_search(l, o).TableName,
									_dbtablefields[f].Name,

									_fks[_dbtablefields[f].Name].ForeignKey_TableName,
									_fks[_dbtablefields[f].Name].ForeignKey_TableFieldName
								));
							}
							if (!_foundFKField) {
								throw new Exception(string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"can't find foreign key FIELD: {0}.{1} -> {2}.{3}",

									this.diagram_.Table_search(l, o).TableName,
									_dbtablefields[f].Name,

									_fks[_dbtablefields[f].Name].ForeignKey_TableName,
									_fks[_dbtablefields[f].Name].ForeignKey_TableFieldName
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

			this.filename_ = string.Empty;
		}
		#endregion
		#region //public void Save(...);
//		public void Save() {
//			if (this.HasChanges) {
//
//				metadata_.SaveState_toFile(
//					filename_
//				);
//
//				haschanges_ = false;
//			}
//		}
		#endregion
		#region public void Build(...);
		public void Build(OGen.Libraries.Generator.Build notifyBase_in) {
			string _outputDir = Path.GetDirectoryName(this.filename_);
			if (notifyBase_in != null) notifyBase_in("generating...", true);

			MetaFile[] _metafiles = new MetaFile[1];
			_metafiles[0] = new MetaFile(
				this.filename_,
				XS__diagram.DIAGRAM
			);
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
				this.diagram_
			);
			if (notifyBase_in != null) notifyBase_in("...finished", true);
		}
		#endregion
		#endregion
	}
}