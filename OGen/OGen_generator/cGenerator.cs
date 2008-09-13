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
			string xmlTemplatesFile_in, 
			string outputDir_in,
			params MetaFile[] metaFiles_in
		) : this (
			xmlTemplatesFile_in, 
			new DBConnectionstrings(), 
			outputDir_in, 
			metaFiles_in
		) {}

		/// <summary>
		/// ToDos: here! (use if you're generating code on a DataBase)
		/// </summary>
/// <param name="xmlTemplatesFile_in">ToDos: here!</param>
		/// <param name="connectionType_in">DataBase Server Type (use if you're generating code on a DataBase)</param>
		/// <param name="connectionString_in">DataBase Connectionstring (use if you're generating code on a DataBase)</param>
/// <param name="outputDir_in">ToDos: here!</param>
/// <param name="metaFiles_in">ToDos: here!</param>
		public cGenerator(
			string xmlTemplatesFile_in, 
			DBConnectionstrings dbconnectionstrings_in, 
			string outputDir_in, 
			params MetaFile[] metaFiles_in
		) {
			//---
			xmltemplatesfileuri_ = new Uri(xmlTemplatesFile_in);
			dbconnectionstrings_ = dbconnectionstrings_in;
			outputdir_ = outputDir_in;
			metafiles_ = metaFiles_in;
			//---
		}
		#endregion

		#region private Fields/Properties...
		private Uri xmltemplatesfileuri_;
		private string xmltemplatesdir_;
		private MetadataInterface metadata_;
		private XS__templates templates_;
		private int template_;
		private dBuild notifyback_;
		#endregion
		#region public Fields/Properties...
		#region public MetaFile Metafile { get; set; }
		private MetaFile[] metafiles_;

		public MetaFile[] Metafiles {
			get { return metafiles_; }
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
		private string translateFully(
			string this_in, 
			string withThis_in
		) {
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
		private string translate(
			string this_in, 
			string withThis_in
		) {
			string translate_out;

			switch (this_in) {
				#region case "CONFIG.ogenPath": translate_out = ...; break;
				case "CONFIG.ogenPath":
					translate_out = 
						#if !NET_1_1
						System.Configuration.ConfigurationManager.AppSettings["ogenPath"]
						#else
						System.Configuration.ConfigurationSettings.AppSettings["ogenPath"]
						#endif
					;
					break;
				#endregion
				#region case "CONFIG.outputPath": translate_out = ...; break;
				case "CONFIG.outputPath":
					translate_out = outputdir_;
					break;
				#endregion
//				#region default: translate_out = ...; break;
				default:
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

					translate_out = metadata_.Read_fromRoot(
						translate_out
					);
//					#endregion
					break;
//				#endregion
			}

			return translate_out;
		}
//		#endregion
//		#region private void notifyme(string message_in);
		private static Exception notifyme_Exception = new Exception("ToDos: here!");
		private void notifyme(
			string message_in
		) {
			// ToDos: here!
//			cDBConnection _con = null;

			#region int _verifiedConditions = ...;
			int _verifiedConditions = 0;
			for (int c = 0; c < templates_.TemplateCollection[template_].Conditions.ConditionCollection.Count; c++) {
				if (
					translate(
						templates_.TemplateCollection[template_].Conditions.ConditionCollection[c].Eval, 
						message_in
					)
					==
					templates_.TemplateCollection[template_].Conditions.ConditionCollection[c].To
				) _verifiedConditions++;
			}
			#endregion
			if (_verifiedConditions == templates_.TemplateCollection[template_].Conditions.ConditionCollection.Count) {
				#region Hashtable _args = ...;
				Hashtable _args = new Hashtable(templates_.TemplateCollection[template_].Arguments.ArgumentCollection.Count);
				for (int a = 0; a < templates_.TemplateCollection[template_].Arguments.ArgumentCollection.Count; a++) {
					_args.Add(
						templates_.TemplateCollection[template_].Arguments.ArgumentCollection[a].Name, 
						//System.Web.HttpUtility.UrlEncode(
							translateFully(
								templates_.TemplateCollection[template_].Arguments.ArgumentCollection[a].Value, 
								message_in
							)
						//)
					);
				}
				#endregion
				for (int o = 0; o < templates_.TemplateCollection[template_].Outputs.OutputCollection.Count; o++) {
					#region if (!dbconnectionstrings_.Contains(DBServerTypes. ...)) continue;
					switch (templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Type) {
						#region case XS_OutputEnumeration.someDBServer_whatever: ... break;
#if PostgreSQL
						case XS_OutputEnumeration.PostgreSQL_Function: 
						case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
						case XS_OutputEnumeration.PostgreSQL_View: {
							if (!dbconnectionstrings_.Contains_disableIfNot(DBServerTypes.PostgreSQL)) continue;
//							_con = (cDBConnection)connection_[DBServerTypes.PostgreSQL];
							break;
						}
#endif
#if MySQL
						case XS_OutputEnumeration.MySQL_Function: 
						case XS_OutputEnumeration.MySQL_StoredProcedure: 
						case XS_OutputEnumeration.MySQL_View: {
							if (!dbconnectionstrings_.Contains_disableIfNot(DBServerTypes.MySQL)) continue;
//							_con = (cDBConnection)connection_[DBServerTypes.MySQL];
							break;
						}
#endif
						case XS_OutputEnumeration.SQLServer_Function: 
						case XS_OutputEnumeration.SQLServer_StoredProcedure: 
						case XS_OutputEnumeration.SQLServer_View: {
							if (!dbconnectionstrings_.Contains_disableIfNot(DBServerTypes.SQLServer)) continue;
//							_con = (cDBConnection)connection_[DBServerTypes.SQLServer];
							break;
						}
						#endregion
					}
					#endregion
					string _ouputTo = translateFully(
						templates_.TemplateCollection[template_].Outputs.OutputCollection[o].To, 
						message_in
					);
//					#region bool _exists = ...;
bool _exists_aux = false;
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	dbconnectionstrings_[d].exists_aux__ = false;
}
					switch (templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Type) {
						case XS_OutputEnumeration.File: {
							_exists_aux = File.Exists(_ouputTo);
							break;
						}

						#region case XS_OutputEnumeration.someDBServer_whatever: ... break;
						case XS_OutputEnumeration.MySQL_Function: 
						case XS_OutputEnumeration.PostgreSQL_Function:
						case XS_OutputEnumeration.SQLServer_Function: {
//_exists = _con.SQLFunction_exists(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	dbconnectionstrings_[d].exists_aux__ 
		= dbconnectionstrings_[d].Connection.SQLFunction_exists(_ouputTo);

	if (!_exists_aux && dbconnectionstrings_[d].exists_aux__) _exists_aux = true;
}
							break;
						}

						case XS_OutputEnumeration.MySQL_StoredProcedure: 
						case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
						case XS_OutputEnumeration.SQLServer_StoredProcedure: {
//_exists = _con.SQLStoredProcedure_exists(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	dbconnectionstrings_[d].exists_aux__ 
		= dbconnectionstrings_[d].Connection.SQLStoredProcedure_exists(_ouputTo);

	if (!_exists_aux && dbconnectionstrings_[d].exists_aux__) _exists_aux = true;
}
							break;
						}
						case XS_OutputEnumeration.MySQL_View: 
						case XS_OutputEnumeration.PostgreSQL_View: 
						case XS_OutputEnumeration.SQLServer_View: {
//_exists = _con.SQLView_exists(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	dbconnectionstrings_[d].exists_aux__ 
		= dbconnectionstrings_[d].Connection.SQLView_exists(_ouputTo);

	if (!_exists_aux && dbconnectionstrings_[d].exists_aux__) _exists_aux = true;
}
							break;
						}
						#endregion

						default: {
							throw notifyme_Exception;
						}
					}
//					#endregion

					if (
						!_exists_aux 
						|| 
						(templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Replace)
						||
						(templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
					) {
						#region string _parsedOutput = ...;
						string _parsedOutput;
						if (templates_.TemplateCollection[template_].ParserType == XS_ParserEnumeration.xslt) {
							System.Text.StringBuilder _stringbuilder = new System.Text.StringBuilder();
							StringWriter _stringwriter = new StringWriter(_stringbuilder);

							string _xmltemplatesfile 
								= xmltemplatesdir_ 
								+ (xmltemplatesfileuri_.IsFile
									? Path.DirectorySeparatorChar.ToString() 
									: "/")
								+ templates_.TemplateCollection[template_].Name;
							ParserXSLT.Parse(
//xmlmetadatafile_, 
metafiles_[
	utils.MetaFile_find(
		metafiles_, 
		message_in.Split('.')[1]
	)
].Path, 
								_xmltemplatesfile, 
								_args, 
								_stringwriter
							);

							_parsedOutput = _stringbuilder.ToString();
						} else {
							if (xmltemplatesfileuri_.IsFile) {
								switch (templates_.TemplateCollection[template_].ParserType) {
									case XS_ParserEnumeration.aspx: {
										ParserASPX.Parse(
											xmltemplatesdir_, 
											templates_.TemplateCollection[template_].Name, 
											_args, 
											out _parsedOutput
										);
										break;
									}
									case XS_ParserEnumeration.none: {

if (templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Type == XS_OutputEnumeration.File) {
	_parsedOutput = null; // will be copied
} else {
	// needs to be read
	_parsedOutput = new StreamReader(
		Path.Combine(
			xmltemplatesdir_,
			templates_.TemplateCollection[template_].Name
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
								switch (templates_.TemplateCollection[template_].ParserType) {
									case XS_ParserEnumeration.aspx:
									case XS_ParserEnumeration.none: {
										_parsedOutput = OGen.lib.presentationlayer.webforms.utils.ReadURL_ToString(
											xmltemplatesdir_ + "/" + templates_.TemplateCollection[template_].Name, 
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

						switch (templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Type) {
							case XS_OutputEnumeration.File: {
								#region Directory.CreateDirectory(_ouputTo);
								string _directory = System.IO.Path.GetDirectoryName(_ouputTo);
								if (!System.IO.Directory.Exists(_directory)) {
									System.IO.Directory.CreateDirectory(
										_directory
									);
								}
								#endregion
								if (
									(templates_.TemplateCollection[template_].ParserType == XS_ParserEnumeration.none)
									&&
									(xmltemplatesfileuri_.IsFile)
								) {
//									#region File.Copy(...);
// ToDos: here!
if (
	(templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
)
	throw new Exception(string.Format("not implemented (at template: {0})", templates_.TemplateCollection[template_].Name));
									File.Copy(
										Path.Combine(
											xmltemplatesdir_, 
											templates_.TemplateCollection[template_].Name
										), 
										_ouputTo, 
										true // (!_exists || templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Replace)
									);
//									#endregion
								} else {
									#region new StreamWriter(_ouputTo).Write(_parsedOutput);
									StreamWriter _writer = new StreamWriter(
										_ouputTo,
										(templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
									);
									_writer.Write(_parsedOutput);
									_writer.Close();
									#endregion
								}
								break;
							}
							#region case XS_OutputEnumeration.someDBServer_whatever: ... break;
							case XS_OutputEnumeration.MySQL_Function: 
							case XS_OutputEnumeration.MySQL_StoredProcedure: 
							case XS_OutputEnumeration.MySQL_View: 
							case XS_OutputEnumeration.PostgreSQL_Function: 
							case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
							case XS_OutputEnumeration.PostgreSQL_View: 
							case XS_OutputEnumeration.SQLServer_Function: 
							case XS_OutputEnumeration.SQLServer_StoredProcedure: 
							case XS_OutputEnumeration.SQLServer_View: {
								if (templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
									throw new Exception("can't handle append over a db function");

//								#region if (_exists_aux) connection_.Function_delete(_ouputTo);
								if (_exists_aux) {
									switch (templates_.TemplateCollection[template_].Outputs.OutputCollection[o].Type) {
										case XS_OutputEnumeration.MySQL_Function:
										case XS_OutputEnumeration.SQLServer_Function: {
//_con.SQLFunction_delete(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	switch (dbconnectionstrings_[d].DBServerType) {
#if MySQL
		case DBServerTypes.MySQL:
#endif
		case DBServerTypes.SQLServer: {
			if (dbconnectionstrings_[d].exists_aux__) 
				dbconnectionstrings_[d].Connection.SQLFunction_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case XS_OutputEnumeration.MySQL_StoredProcedure: 
										case XS_OutputEnumeration.SQLServer_StoredProcedure: {
//_con.SQLStoredProcedure_delete(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	switch (dbconnectionstrings_[d].DBServerType) {
#if MySQL
		case DBServerTypes.MySQL:
#endif
		case DBServerTypes.SQLServer: {
			if (dbconnectionstrings_[d].exists_aux__) 
				dbconnectionstrings_[d].Connection.SQLStoredProcedure_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case XS_OutputEnumeration.MySQL_View: 
										case XS_OutputEnumeration.SQLServer_View: {
//_con.SQLView_delete(_ouputTo);
for (int d = 0; d < dbconnectionstrings_.Count; d++) {
	if (!dbconnectionstrings_[d].enabled_aux__) continue;

	switch (dbconnectionstrings_[d].DBServerType) {
#if MySQL
		case DBServerTypes.MySQL:
#endif
		case DBServerTypes.SQLServer: {
			if (dbconnectionstrings_[d].exists_aux__) 
				dbconnectionstrings_[d].Connection.SQLView_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case XS_OutputEnumeration.PostgreSQL_Function: 
										case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
										case XS_OutputEnumeration.PostgreSQL_View: 
											// No Need! unlike SQL Server and MySQL,
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
	try {
		dbconnectionstrings_[d].Connection.Execute_SQLQuery(_parsedOutput);
	} catch (Exception _ex) {
		throw new Exception(string.Format(
			"---\nTEMPLATE: {0}\n---\nQUERY:\n\n{1}\n---\nDBServerType:\n\n{2}\n---\nEXCEPTION:\n\n{3}\n---\nINNER-EXCEPTION:\n\n{4}\n---\n",
			templates_.TemplateCollection[template_].Name,
			_parsedOutput, 
			dbconnectionstrings_[d].DBServerType.ToString(), 
			_ex.Message,
			_ex.InnerException
		));
	}
}
								break;
							}
							#endregion
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
		private void build(
			dBuild notifyBack_in, 
//			bool loadMetadata_in, 
			MetadataInterface metadata_in
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
//            if (loadMetadata_in) {
//// ToDos: now! index must be sinchronized, not very convenient :(
//                for (int m = 0; m < metadatas_.Length; m++) {
//                    metadatas_[m].LoadState_fromFile(
//                        //xmlmetadatafile_, 
//                        metafiles_[m].Path, 
//                        //xmlmetadataroot_
//                        metafiles_[m].Root
//                    );
//                }
//            }

			templates_ = (xmltemplatesfileuri_.IsFile)
				? XS__templates.Load_fromFile(xmltemplatesfileuri_.LocalPath)[0]
				: XS__templates.Load_fromURI(xmltemplatesfileuri_)[0]
			;

			bool _finished;
			ArrayList _finishedTemplates = new ArrayList(templates_.TemplateCollection.Count);
			do {
				_finished = true;
				for (template_ = 0; template_ < templates_.TemplateCollection.Count; template_++) {
					#region if (_finishedPreviously = ...) continue;
					bool _finishedPreviously = false;
					for (int f = 0; f < _finishedTemplates.Count; f++) {
						if (
							templates_.TemplateCollection[template_].Name
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
					for (int d = 0; d < templates_.TemplateCollection[template_].Dependencies.DependencyCollection.Count; d++) {
						for (int f = 0; f < _finishedTemplates.Count; f++) {
							if (
								templates_.TemplateCollection[template_].Dependencies.DependencyCollection[d].Name
								==
								(string)_finishedTemplates[f]
							) {
								_finishedDependencies++;
								break;
							}
						}
					}
					#endregion
					if (_finishedDependencies == templates_.TemplateCollection[template_].Dependencies.DependencyCollection.Count) {
						#region RUNNING: templates_[template_] ...

						notifyback_(
							string.Format(
								"#{0}/{1} - {2} ... ",
								_finishedTemplates.Count + 1,
								templates_.TemplateCollection.Count,
								templates_.TemplateCollection[template_].Name
							),
							false
						);

						metadata_.IterateThrough_fromRoot(
							templates_.TemplateCollection[template_].IterationType,
							new utils.IterationFoundDelegate(notifyme)
						);
						#endregion

						// adding template to finished list of templates
						_finishedTemplates.Add(templates_.TemplateCollection[template_].Name);
						_finished = false;

						notifyback_("DONE!", true);
					}
					#endregion
				}
			} while (!_finished);
			#region if (templates_.Count != _finishedTemplates.Count) throw new Exception("unsolved dependencies");
			if (templates_.TemplateCollection.Count != _finishedTemplates.Count) {
				string _error = "list of Templates with unsolved dependencies:\n";
				for (int t = 0; t < templates_.TemplateCollection.Count; t++) {
					_finished = false;
					for (int f = 0; f < _finishedTemplates.Count; f++) {
						if ((string)_finishedTemplates[f] == templates_.TemplateCollection[template_].Name) {
							_finished = true;
							break;
						}
					}
					if (!_finished) {
						_error += string.Format(
							"\t{0}\n", 
							templates_.TemplateCollection[template_].Name
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
//		public void Build(
//			dBuild notifyBack_in, 
//			Type[] typeofClaSSe_in
//		) {
//			#region Checking...
//			Type[] _interfaces = typeofClaSSe_in.GetInterfaces();
//			bool _found = false;
//			for (int i = 0; i < _interfaces.Length; i++) {
//				if (_interfaces[i] == typeof(iClaSSe_metadata)) {
//					_found = true;
//					break;
//				}
//			}
//			if (!_found)
//				throw new Exception(
//					string.Format(
//						"{0}.{1}.Build(): - invalid type supplied!", 
//						this.GetType().Namespace, 
//						this.GetType().Name
//					)
//				);
//			#endregion
//			build(
//				notifyBack_in, 
//				(iClaSSe_metadata)Activator.CreateInstance(typeofClaSSe_in), 
//				true
//			);
//		}
		public void Build(
			dBuild notifyBack_in, 
			MetadataInterface metadata_in
		) {
			build(
				notifyBack_in, 
//				false, 
				metadata_in
			);
		}
		#endregion
		#endregion
	}
}
