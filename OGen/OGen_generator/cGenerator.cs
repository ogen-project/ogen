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
using System.Collections;
using System.Web;
using OGen.lib.collections;
using OGen.lib.templates;
using OGen.lib.datalayer;
using OGen.lib.parser;

namespace OGen.lib.generator {
	public class cGenerator {
		#region public cGenerator(...);
		public cGenerator(
			string					xmlMetadataFile_in, 
			string					xmlMetadataRoot_in, 
			string					xmlTemplatesFile_in, 
			string					xmlTemplatesRoot_in, 
			string					outputDir_in
		) : this (
			xmlMetadataFile_in, 
			xmlMetadataRoot_in, 
			xmlTemplatesFile_in, 
			xmlTemplatesRoot_in, 
			new DBConnectionstrings(), 
			outputDir_in
		) {}

		/// <summary>
		/// ToDos: here! (use if you're generating code on a DataBase)
		/// </summary>
		/// <param name="xmlMetadataFile_in">ToDos: here!</param>
		/// <param name="xmlMetadataRoot_in">ToDos: here!</param>
		/// <param name="xmlTemplatesFile_in">ToDos: here!</param>
		/// <param name="xmlTemplatesRoot_in">ToDos: here!</param>
		/// <param name="connectionType_in">DataBase Server Type (use if you're generating code on a DataBase)</param>
		/// <param name="connectionString_in">DataBase Connectionstring (use if you're generating code on a DataBase)</param>
		/// <param name="outputDir_in">ToDos: here!</param>
		public cGenerator(
			string					xmlMetadataFile_in, 
			string					xmlMetadataRoot_in, 
			string					xmlTemplatesFile_in, 
			string					xmlTemplatesRoot_in, 
			DBConnectionstrings		dbconnectionstrings_in, 
			string					outputDir_in
		) {
			//---
			xmlmetadatafile_		= xmlMetadataFile_in;
			xmlmetadataroot_		= xmlMetadataRoot_in;
			xmltemplatesfileuri_	= new Uri(xmlTemplatesFile_in);
			xmltemplatesroot_		= xmlTemplatesRoot_in;
			dbconnectionstrings_	= dbconnectionstrings_in;
			outputdir_				= outputDir_in;
			//---
		}
		#endregion

		#region private Fields/Properties...
		private Uri xmltemplatesfileuri_;
		private string xmltemplatesdir_;
		private iClaSSe metadata_;
		private cTemplates templates_;
		private int template_;
		private dBuild notifyback_;
		#endregion
		#region public Fields/Properties...
		#region public string XMLMetadataFile { get; }
		private string xmlmetadatafile_;
		public string XMLMetadataFile {
			get { return xmlmetadatafile_; }
		}
		#endregion
		#region string XMLMetadataRoot { get; }
		private string xmlmetadataroot_; 
		public string XMLMetadataRoot {
			get { return xmlmetadataroot_; }
		}
		#endregion
		#region string XMLTemplatesRoot { get; }
		private string xmltemplatesroot_; 
		public string XMLTemplatesRoot {
			get { return xmltemplatesroot_; }
		}
		#endregion
		#region DBConnectionstrings DBConnectionstrings { get; }
		private DBConnectionstrings dbconnectionstrings_;
		public DBConnectionstrings DBConnectionstrings {
			get { return dbconnectionstrings_; }
		}
		#endregion
		#region string OutputDir { get; }
		private string outputdir_;
		public string OutputDir {
			get { return outputdir_; }
		}
		#endregion
		#endregion

//		#region private Methods...
		#region private string translateFully(string this_in, string withThis_in);
		private string translateFully(string this_in, string withThis_in) {
			string translateFully_out = this_in;

			int _begin;
			while ((_begin = translateFully_out.IndexOf("${")) >= 0) {
				int _end = translateFully_out.IndexOf("}", _begin);

				#region translateFully_out = ...;
				translateFully_out = 
					(
						(_begin > 0) 
							? translateFully_out.Substring(
								0, 
								_begin
							) 
							: ""
					)

					+ translate(
						translateFully_out.Substring(
							_begin + 2, 
							_end - _begin - 2
						), 
						withThis_in
					)

					+ translateFully_out.Substring(_end + 1);
				#endregion
			}

			return translateFully_out.Replace('/', Path.DirectorySeparatorChar);
		}
		#endregion
//		#region private string translate(string this_in, string withThis_in);
		private string translate(string this_in, string withThis_in) {
			string translate_out;

			switch (this_in) {
				case "CONFIG.ogenPath": {
					translate_out = System.Configuration.ConfigurationSettings.AppSettings["ogenPath"];
					break;
				}
				case "CONFIG.outputPath": {
					translate_out = outputdir_;
					break;
				}
				default: {
//					#region translate_out = metadata_.Read_fromRoot(...);
					translate_out = this_in;

					int _indexOfN;
					while ((_indexOfN = translate_out.IndexOf("[n]", 0)) != -1) {

// ToDos: here! 
// infinite loop, case baddly formed expression...

						if (
							translate_out.Substring(0, _indexOfN) 
							== 
							withThis_in.Substring(0, _indexOfN)
						) {
							translate_out = withThis_in.Substring(
								0, 
								withThis_in.IndexOf("]", _indexOfN) + 1
							) + translate_out.Substring(
								translate_out.IndexOf("]", _indexOfN) + 1
							);
						} else {
							throw new Exception(string.Format(
								"\n\n---\n{0}.{1}.translate()\n- can't handle: {2}\n---\n", 
								this.GetType().Namespace, 
								this.GetType().Name, 
								this_in
							));
						}
					}

					translate_out = metadata_.Read_fromRoot(translate_out);
//					#endregion
					break;
				}
			}

			return translate_out;
		}
//		#endregion
//		#region private void notifyme(string message_in);
		private void notifyme(string message_in) {
			// ToDos: here!
			Exception notifyme_Exception = new Exception("ToDos: here!");
//			cDBConnection _con = null;

			#region int _verifiedConditions = ...;
			int _verifiedConditions = 0;
			for (int c = 0; c < templates_[template_].Conditions.Count; c++) {
				if (
					translate(templates_[template_].Conditions[c].Eval, message_in)
					==
					templates_[template_].Conditions[c].To
				) _verifiedConditions++;
			}
			#endregion
			if (_verifiedConditions == templates_[template_].Conditions.Count) {
				#region Hashtable _args = ...;
				Hashtable _args = new Hashtable(templates_[template_].Arguments.Count);
				for (int a = 0; a < templates_[template_].Arguments.Count; a++) {
					_args.Add(
						templates_[template_].Arguments[a].Name, 
						//System.Web.HttpUtility.UrlEncode(
							translateFully(
								templates_[template_].Arguments[a].Value, 
								message_in
							)
						//)
					);
				}
				#endregion
				for (int o = 0; o < templates_[template_].Outputs.Count; o++) {
//					#region if (!dbconnectionstrings_.Contains(eDBServerTypes. ...)) continue;
					switch (templates_[template_].Outputs[o].Type) {
						case cOutput.eType.PostgreSQL_Function: 
						case cOutput.eType.PostgreSQL_StoredProcedure: 
						case cOutput.eType.PostgreSQL_View: {
							if (!dbconnectionstrings_.Contains_disableIfNot(eDBServerTypes.PostgreSQL)) continue;
//							_con = (cDBConnection)connection_[eDBServerTypes.PostgreSQL];
							break;
						}
						case cOutput.eType.MySQL_Function: 
						case cOutput.eType.MySQL_StoredProcedure: 
						case cOutput.eType.MySQL_View: {
							if (!dbconnectionstrings_.Contains_disableIfNot(eDBServerTypes.MySQL)) continue;
//							_con = (cDBConnection)connection_[eDBServerTypes.MySQL];
							break;
						}
						case cOutput.eType.SQLServer_Function: 
						case cOutput.eType.SQLServer_StoredProcedure: 
						case cOutput.eType.SQLServer_View: {
							if (!dbconnectionstrings_.Contains_disableIfNot(eDBServerTypes.SQLServer)) continue;
//							_con = (cDBConnection)connection_[eDBServerTypes.SQLServer];
							break;
						}
					}
//					#endregion
					string _ouputTo = translateFully(
						templates_[template_].Outputs[o].To, 
						message_in
					);
//					#region bool _exists = ...;
bool _exists_aux = false;
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	dbconnectionstrings_[d].exists_aux__ = false;
}
					switch (templates_[template_].Outputs[o].Type) {
						case cOutput.eType.File: {
							_exists_aux = File.Exists(_ouputTo);
							break;
						}
						case cOutput.eType.MySQL_Function: 
						case cOutput.eType.PostgreSQL_Function: 
						case cOutput.eType.SQLServer_Function: {
//_exists = _con.SQLFunction_exists(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	dbconnectionstrings_[d].exists_aux__ 
		= dbconnectionstrings_[d].Connection.SQLFunction_exists(_ouputTo);

	if (!_exists_aux && dbconnectionstrings_[d].exists_aux__) _exists_aux = true;
}
							break;
						}

						case cOutput.eType.MySQL_StoredProcedure: 
						case cOutput.eType.PostgreSQL_StoredProcedure: 
						case cOutput.eType.SQLServer_StoredProcedure: {
//_exists = _con.SQLStoredProcedure_exists(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	dbconnectionstrings_[d].exists_aux__ 
		= dbconnectionstrings_[d].Connection.SQLStoredProcedure_exists(_ouputTo);

	if (!_exists_aux && dbconnectionstrings_[d].exists_aux__) _exists_aux = true;
}
							break;
						}
						case cOutput.eType.MySQL_View: 
						case cOutput.eType.PostgreSQL_View: 
						case cOutput.eType.SQLServer_View: {
//_exists = _con.SQLView_exists(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	dbconnectionstrings_[d].exists_aux__ 
		= dbconnectionstrings_[d].Connection.SQLView_exists(_ouputTo);

	if (!_exists_aux && dbconnectionstrings_[d].exists_aux__) _exists_aux = true;
}
							break;
						}
						default: {
							throw notifyme_Exception;
						}
					}
//					#endregion

					if (
						!_exists_aux 
						|| 
						(templates_[template_].Outputs[o].Mode == cOutput.eMode.Replace)
						||
						(templates_[template_].Outputs[o].Mode == cOutput.eMode.Append)
					) {
						#region string _parsedOutput = ...;
						string _parsedOutput;
						if (templates_[template_].ParserType == cTemplate.eParserType.xslt) {
							System.Text.StringBuilder _stringbuilder = new System.Text.StringBuilder();
							StringWriter _stringwriter = new StringWriter(_stringbuilder);

							string _xmltemplatesfile 
								= xmltemplatesdir_ 
								+ (xmltemplatesfileuri_.IsFile
									? Path.DirectorySeparatorChar.ToString() 
									: "/")
								+ templates_[template_].Name;
							ParserXSLT.Parse(
								xmlmetadatafile_, 
								_xmltemplatesfile, 
								_args, 
								_stringwriter
							);

							_parsedOutput = _stringbuilder.ToString();
						} else {
							if (xmltemplatesfileuri_.IsFile) {
								switch (templates_[template_].ParserType) {
									case cTemplate.eParserType.aspx: {
										ParserASPX.Parse(
											xmltemplatesdir_, 
											templates_[template_].Name, 
											_args, 
											out _parsedOutput
										);
										break;
									}
									case cTemplate.eParserType.none: {

if (templates_[template_].Outputs[o].Type == cOutput.eType.File) {
	_parsedOutput = null; // will be copied
} else {
	// needs to be read
	_parsedOutput = new StreamReader(
		Path.Combine(
			xmltemplatesdir_,
			templates_[template_].Name
		)
	).ReadToEnd();
}

										break;
									}
									default: {
										// ToDos: here!
										throw new Exception("ToDos: here!");
									}
								}
							} else {
								switch (templates_[template_].ParserType) {
									case cTemplate.eParserType.aspx:
									case cTemplate.eParserType.none: {
										_parsedOutput = OGen.lib.presentationlayer.webforms.utils.ReadURL(
											xmltemplatesdir_ + "/" + templates_[template_].Name, 
											_args
										);
										break;
									}
									default: {
										// ToDos: here!
										throw new Exception("ToDos: here!");
									}
								}
							}
						}
						#endregion

						switch (templates_[template_].Outputs[o].Type) {
							case cOutput.eType.File: {
								#region Directory.CreateDirectory(_ouputTo);
								string _directory = System.IO.Path.GetDirectoryName(_ouputTo);
								if (!System.IO.Directory.Exists(_directory)) {
									System.IO.Directory.CreateDirectory(
										_directory
									);
								}
								#endregion
								if (
									(templates_[template_].ParserType == cTemplate.eParserType.none)
									&&
									(xmltemplatesfileuri_.IsFile)
								) {
//									#region File.Copy(...);
// ToDos: here!
if (
	(templates_[template_].Outputs[o].Mode == cOutput.eMode.Append)
)
	throw new Exception(string.Format("not implemented (at template: {0})", templates_[template_].Name));
									File.Copy(
										Path.Combine(
											xmltemplatesdir_, 
											templates_[template_].Name
										), 
										_ouputTo, 
										true // (!_exists || templates_[template_].Outputs[o].Replace)
									);
//									#endregion
								} else {
									#region new StreamWriter(_ouputTo).Write(_parsedOutput);
									StreamWriter _writer = new StreamWriter(
										_ouputTo,
										(templates_[template_].Outputs[o].Mode == cOutput.eMode.Append)
									);
									_writer.Write(_parsedOutput);
									_writer.Close();
									#endregion
								}
								break;
							}
							case cOutput.eType.MySQL_Function: 
							case cOutput.eType.MySQL_StoredProcedure: 
							case cOutput.eType.MySQL_View: 
							case cOutput.eType.PostgreSQL_Function: 
							case cOutput.eType.PostgreSQL_StoredProcedure: 
							case cOutput.eType.PostgreSQL_View: 
							case cOutput.eType.SQLServer_Function: 
							case cOutput.eType.SQLServer_StoredProcedure: 
							case cOutput.eType.SQLServer_View: {
								if (templates_[template_].Outputs[o].Mode == cOutput.eMode.Append)
									throw new Exception("can't handle append over a db function");

//								#region if (_exists_aux) connection_.Function_delete(_ouputTo);
								if (_exists_aux) {
									switch (templates_[template_].Outputs[o].Type) {
										case cOutput.eType.MySQL_Function:
										case cOutput.eType.SQLServer_Function: {
//_con.SQLFunction_delete(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	switch (dbconnectionstrings_[d].Connection.DBServerType) {
		case eDBServerTypes.MySQL:
		case eDBServerTypes.SQLServer: {
			if (dbconnectionstrings_[d].exists_aux__) 
				dbconnectionstrings_[d].Connection.SQLFunction_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case cOutput.eType.MySQL_StoredProcedure: 
										case cOutput.eType.SQLServer_StoredProcedure: {
//_con.SQLStoredProcedure_delete(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	switch (dbconnectionstrings_[d].Connection.DBServerType) {
		case eDBServerTypes.MySQL:
		case eDBServerTypes.SQLServer: {
			if (dbconnectionstrings_[d].exists_aux__) 
				dbconnectionstrings_[d].Connection.SQLStoredProcedure_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case cOutput.eType.MySQL_View: 
										case cOutput.eType.SQLServer_View: {
//_con.SQLView_delete(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	switch (dbconnectionstrings_[d].Connection.DBServerType) {
		case eDBServerTypes.MySQL:
		case eDBServerTypes.SQLServer: {
			if (dbconnectionstrings_[d].exists_aux__) 
				dbconnectionstrings_[d].Connection.SQLView_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case cOutput.eType.PostgreSQL_Function: 
										case cOutput.eType.PostgreSQL_StoredProcedure: 
										case cOutput.eType.PostgreSQL_View: 
											// No Need! unlike SQL Server,
											// PostgreSQL allows:
											// "CREATE OR REPLACE FUNCTION/VIEW" :)
											break;
										default: {
											break;
										}
									}
								}
//								#endregion
//_con.Execute_SQLQuery(_parsedOutput);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;
	dbconnectionstrings_[d].Connection.Execute_SQLQuery(_parsedOutput);
}
								break;
							}
							default: {
								throw notifyme_Exception;
							}
						}
					}
				}
			}
		}
//		#endregion
//		#endregion
		#region public Methods...
		#region public void Build();
		public delegate void dBuild(string message_in, bool onANewLine_in);
		#region private void Build(...);
		private void Build(
			dBuild notifyBack_in, 
			iClaSSe metadata_in, 
			bool loadMetadate_in
		) {
			notifyback_ = notifyBack_in;
			//notifyback_("- common items", true);

			if (xmltemplatesfileuri_.IsFile) {
				xmltemplatesdir_ = Path.GetDirectoryName(
					xmltemplatesfileuri_.LocalPath
				);
			} else {
				xmltemplatesdir_ = xmltemplatesfileuri_.ToString().Substring(
					0, 
					xmltemplatesfileuri_.ToString().LastIndexOf("/")
				);
			}

			#region dbconnectionstrings_[0..n].Connection_createInstance();
			for (int d = 0; d < dbconnectionstrings_.Count; d++) {
				dbconnectionstrings_[d].Connection_createInstance();
			}
			#endregion

			//metadata_ = new cDBMetadata(xmlmetadatafile_, xmlmetadataroot_);
			metadata_ = metadata_in;
			if (loadMetadate_in) {
				metadata_.LoadState_fromFile(xmlmetadatafile_, xmlmetadataroot_);
			}

			templates_ = new cTemplates(
				xmltemplatesfileuri_, 
				xmltemplatesroot_
			);

			bool _finished;
			ArrayList _finishedTemplates = new ArrayList(templates_.Count);
			do {
				_finished = true;
				for (template_ = 0; template_ < templates_.Count; template_++) {
					#region if (_finishedPreviously = ...) continue;
					bool _finishedPreviously = false;
					for (int f = 0; f < _finishedTemplates.Count; f++) {
						if (
							templates_[template_].Name
							==
							(string)_finishedTemplates[f]
						) {
							_finishedPreviously = true;
							break;
						}
					}
					if (_finishedPreviously) continue;
					#endregion
					#region if ((_finishedDependencies = ...) == templates_[template_].Dependencies.Count) { _finishedTemplates.Add(templates_[template_].Name); _finished = false; }
					#region int _finishedDependencies = ...;
					int _finishedDependencies = 0;
					for (int d = 0; d < templates_[template_].Dependencies.Count; d++) {
						for (int f = 0; f < _finishedTemplates.Count; f++) {
							if (
								templates_[template_].Dependencies[d].Name
								==
								(string)_finishedTemplates[f]
							) {
								_finishedDependencies++;
								break;
							}
						}
					}
					#endregion
					if (_finishedDependencies == templates_[template_].Dependencies.Count) {
						#region RUNNING: templates_[template_] ...
						metadata_.IterateThrough_fromRoot(
							templates_[template_].IterationType, 
							new cClaSSe.dIteration_found(notifyme)
						);
						#endregion

						// adding template to finished list of templates
						_finishedTemplates.Add(templates_[template_].Name);
						_finished = false;

						notifyback_(
							string.Format(
								"#{0}/{1} - {2}", 
								_finishedTemplates.Count, 
								templates_.Count, 
								templates_[template_].Name
							), 
							true
						);
					}
					#endregion
				}
			} while (!_finished);
			#region if (templates_.Count != _finishedTemplates.Count) throw new Exception("unsolved dependencies");
			if (templates_.Count != _finishedTemplates.Count) {
				string _error = "list of Templates with unsolved dependencies:\n";
				for (int t = 0; t < templates_.Count; t++) {
					_finished = false;
					for (int f = 0; f < _finishedTemplates.Count; f++) {
						if ((string)_finishedTemplates[f] == templates_[template_].Name) {
							_finished = true;
							break;
						}
					}
					if (!_finished) {
						_error += string.Format(
							"\t{0}\n", 
							templates_[template_].Name
						);
					}
				}
				throw new Exception(_error);
			}
			#endregion

			#region dbconnectionstrings_[0..n].Connection_clearInstance();
			for (int d = 0; d < dbconnectionstrings_.Count; d++) {
				dbconnectionstrings_[d].Connection_clearInstance();
			}
			#endregion
		}
		#endregion
		public void Build(
			dBuild notifyBack_in, 
			Type typeofClaSSe_in
		) {
			#region Checking...
			Type[] _interfaces = typeofClaSSe_in.GetInterfaces();
			bool _found = false;
			for (int i = 0; i < _interfaces.Length; i++) {
				if (_interfaces[i] == typeof(iClaSSe)) {
					_found = true;
					break;
				}
			}
			if (!_found)
				throw new Exception(
					string.Format(
						"{0}.{1}.Build(): - invalid type supplied!", 
						this.GetType().Namespace, 
						this.GetType().Name
					)
				);
			#endregion
			Build(
				notifyBack_in, 
				(iClaSSe)Activator.CreateInstance(typeofClaSSe_in), 
				true
			);
		}
		public void Build(
			dBuild notifyBack_in, 
			iClaSSe metadata_in
		) {
			Build(
				notifyBack_in, 
				metadata_in, 
				false
			);
		}
		#endregion
		#endregion
	}
}