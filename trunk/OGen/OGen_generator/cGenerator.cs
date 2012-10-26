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
		/// <param name="dbConnectionStrings_in">DataBase Connectionstring (use if you're generating code on a DataBase)</param>
/// <param name="outputDir_in">ToDos: here!</param>
/// <param name="metaFiles_in">ToDos: here!</param>
		public cGenerator(
			string xmlTemplatesFile_in, 
			DBConnectionstrings dbConnectionStrings_in, 
			string outputDir_in, 
			params MetaFile[] metaFiles_in
		) {
			//---
			xmltemplatesfileuri_ = new Uri(xmlTemplatesFile_in);
			dbconnectionstrings_ = dbConnectionStrings_in;
			outputdir_ = outputDir_in;
			metafiles_ = metaFiles_in;
			//---
		}
		#endregion

		public const string DEVNULL = "/dev/null";

		#region private Fields/Properties...
		private Uri xmltemplatesfileuri_;
		private string xmltemplatesdir_;
		private MetadataInterface metadata_;
		private XS__templates templates_;
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
//#region case "CONFIG.outputPath": translate_out = ...; break;
case "CONFIG.metadatasPath":
	translate_out = Path.GetDirectoryName(Metafiles[0].Path);
	break;
//#endregion
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
			string message_in,
			XS_templateType template_in,
			DBConnectionstrings dbConnectionStrings_in,
			Statistics statistics_in
		) {
			// ToDos: here!
//			cDBConnection _con = null;

			#region int _verifiedConditions = ...;
			int _verifiedConditions = 0;
			for (int c = 0; c < template_in.Conditions.ConditionCollection.Count; c++) {
				if (
					translate(
						template_in.Conditions.ConditionCollection[c].Eval, 
						message_in
					)
					==
					template_in.Conditions.ConditionCollection[c].To
				) _verifiedConditions++;
			}
			#endregion
			if (_verifiedConditions == template_in.Conditions.ConditionCollection.Count) {
				#region Hashtable _args = ...;
				Hashtable _args = new Hashtable(template_in.Arguments.ArgumentCollection.Count);
				for (int a = 0; a < template_in.Arguments.ArgumentCollection.Count; a++) {
					_args.Add(
						template_in.Arguments.ArgumentCollection[a].Name, 
						//System.Web.HttpUtility.UrlEncode(
							translateFully(
								template_in.Arguments.ArgumentCollection[a].Value, 
								message_in
							)
						//)
					);
				}
				#endregion
				for (int o = 0; o < template_in.Outputs.OutputCollection.Count; o++) {
					#region if (!dbConnectionStrings_in.Contains(DBServerTypes. ...)) continue;
					switch (template_in.Outputs.OutputCollection[o].Type) {
						#region case XS_OutputEnumeration.someDBServer_whatever: ... break;
#if PostgreSQL
						case XS_OutputEnumeration.PostgreSQL_Function: 
						case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
						case XS_OutputEnumeration.PostgreSQL_View: {
							if (!dbConnectionStrings_in.Contains_disableIfNot(DBServerTypes.PostgreSQL)) continue;
//							_con = (cDBConnection)connection_[DBServerTypes.PostgreSQL];
							break;
						}
#else
						case XS_OutputEnumeration.PostgreSQL_Function: 
						case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
						case XS_OutputEnumeration.PostgreSQL_View: {
							continue;
						}
#endif
#if MySQL
						case XS_OutputEnumeration.MySQL_Function: 
						case XS_OutputEnumeration.MySQL_StoredProcedure: 
						case XS_OutputEnumeration.MySQL_View: {
							if (!dbConnectionStrings_in.Contains_disableIfNot(DBServerTypes.MySQL)) continue;
//							_con = (cDBConnection)connection_[DBServerTypes.MySQL];
							break;
						}
#else
						case XS_OutputEnumeration.MySQL_Function: 
						case XS_OutputEnumeration.MySQL_StoredProcedure: 
						case XS_OutputEnumeration.MySQL_View: {
							continue;
						}
#endif
						case XS_OutputEnumeration.SQLServer_Function: 
						case XS_OutputEnumeration.SQLServer_StoredProcedure: 
						case XS_OutputEnumeration.SQLServer_View: {
							if (!dbConnectionStrings_in.Contains_disableIfNot(DBServerTypes.SQLServer)) continue;
//							_con = (cDBConnection)connection_[DBServerTypes.SQLServer];
							break;
						}
						#endregion
					}
					#endregion
					string _ouputTo = translateFully(
						template_in.Outputs.OutputCollection[o].To, 
						message_in
					);
//					#region bool _exists = ...;
bool _exists_aux = false;
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	dbConnectionStrings_in[d].exists_aux__ = false;
}
					switch (template_in.Outputs.OutputCollection[o].Type) {
						case XS_OutputEnumeration.File: {
							_exists_aux = (_ouputTo == DEVNULL) ? true : File.Exists(_ouputTo);
							break;
						}

						#region case XS_OutputEnumeration.someDBServer_whatever: ... break;
						case XS_OutputEnumeration.MySQL_Function: 
						case XS_OutputEnumeration.PostgreSQL_Function:
						case XS_OutputEnumeration.SQLServer_Function: {
//_exists = _con.SQLFunction_exists(_ouputTo);
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;

	dbConnectionStrings_in[d].exists_aux__ 
		= dbConnectionStrings_in[d].Connection.SQLFunction_exists(_ouputTo);

	if (!_exists_aux && dbConnectionStrings_in[d].exists_aux__) _exists_aux = true;
}
							break;
						}

						case XS_OutputEnumeration.MySQL_StoredProcedure: 
						case XS_OutputEnumeration.PostgreSQL_StoredProcedure: 
						case XS_OutputEnumeration.SQLServer_StoredProcedure: {
//_exists = _con.SQLStoredProcedure_exists(_ouputTo);
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;

	dbConnectionStrings_in[d].exists_aux__ 
		= dbConnectionStrings_in[d].Connection.SQLStoredProcedure_exists(_ouputTo);

	if (!_exists_aux && dbConnectionStrings_in[d].exists_aux__) _exists_aux = true;
}
							break;
						}
						case XS_OutputEnumeration.MySQL_View: 
						case XS_OutputEnumeration.PostgreSQL_View: 
						case XS_OutputEnumeration.SQLServer_View: {
//_exists = _con.SQLView_exists(_ouputTo);
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;

	dbConnectionStrings_in[d].exists_aux__ 
		= dbConnectionStrings_in[d].Connection.SQLView_exists(_ouputTo);

	if (!_exists_aux && dbConnectionStrings_in[d].exists_aux__) _exists_aux = true;
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
						(template_in.Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Replace)
						||
						(template_in.Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
					) {
						#region string _parsedOutput = ...;
						string _parsedOutput;
						if (template_in.ParserType == XS_ParserEnumeration.xslt) {
							System.Text.StringBuilder _stringbuilder = new System.Text.StringBuilder();
							StringWriter _stringwriter = new StringWriter(_stringbuilder);

							string _xmltemplatesfile 
								= xmltemplatesdir_ 
								+ (xmltemplatesfileuri_.IsFile
									? Path.DirectorySeparatorChar.ToString() 
									: "/")
								+ template_in.Name;
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
								switch (template_in.ParserType) {
									case XS_ParserEnumeration.aspx: {
										ParserASPX.Parse(
											xmltemplatesdir_, 
											template_in.Name, 
											_args, 
											out _parsedOutput
										);

										if (statistics_in != null) {
											statistics_in.Lines_Add(_parsedOutput);
											statistics_in.Bytes_Add(_parsedOutput);
										}

										break;
									}
									case XS_ParserEnumeration.none: {

if (template_in.Outputs.OutputCollection[o].Type == XS_OutputEnumeration.File) {
	_parsedOutput = null; // will be copied
} else {
	// needs to be read
	_parsedOutput = new StreamReader(
		Path.Combine(
			xmltemplatesdir_,
			template_in.Name
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
								switch (template_in.ParserType) {
									case XS_ParserEnumeration.aspx:
									case XS_ParserEnumeration.none: {
										_parsedOutput = OGen.lib.presentationlayer.webforms.utils.ReadURL_ToString(
											xmltemplatesdir_ + "/" + template_in.Name, 
											_args
										);

										if (statistics_in != null) {
											statistics_in.Lines_Add(_parsedOutput);
											statistics_in.Bytes_Add(_parsedOutput);
										}

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

						switch (template_in.Outputs.OutputCollection[o].Type) {
							case XS_OutputEnumeration.File: {
if (
	(_ouputTo == string.Empty)
	||
	(_ouputTo == DEVNULL)
	||
	(Directory.Exists(_ouputTo))
)
	break;

								#region Directory.CreateDirectory(_ouputTo);
								string _directory = System.IO.Path.GetDirectoryName(_ouputTo);
								if (!System.IO.Directory.Exists(_directory)) {
									System.IO.Directory.CreateDirectory(
										_directory
									);
								}
								#endregion
								if (
									(template_in.ParserType == XS_ParserEnumeration.none)
									&&
									(xmltemplatesfileuri_.IsFile)
								) {
//									#region File.Copy(...);
// ToDos: here!
if (
	(template_in.Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
)
	throw new Exception(string.Format("not implemented (at template: {0})", template_in.Name));
									File.Copy(
										Path.Combine(
											xmltemplatesdir_, 
											template_in.Name
										), 
										_ouputTo, 
										true // (!_exists || template_in.Outputs.OutputCollection[o].Replace)
									);
//									#endregion
								} else {
									#region new StreamWriter(_ouputTo).Write(_parsedOutput);
									StreamWriter _writer = new StreamWriter(
										_ouputTo,
										(template_in.Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
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
								if (template_in.Outputs.OutputCollection[o].Mode == XS_OutputModeEnumeration.Append)
									throw new Exception("can't handle append over a db function");

//								#region if (_exists_aux) connection_.Function_delete(_ouputTo);
								if (_exists_aux) {
									switch (template_in.Outputs.OutputCollection[o].Type) {
										case XS_OutputEnumeration.MySQL_Function:
										case XS_OutputEnumeration.SQLServer_Function: {
//_con.SQLFunction_delete(_ouputTo);
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;

	switch (dbConnectionStrings_in[d].DBServerType) {
#if MySQL
		case DBServerTypes.MySQL:
#endif
		case DBServerTypes.SQLServer: {
			if (dbConnectionStrings_in[d].exists_aux__) 
				dbConnectionStrings_in[d].Connection.SQLFunction_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case XS_OutputEnumeration.MySQL_StoredProcedure: 
										case XS_OutputEnumeration.SQLServer_StoredProcedure: {
//_con.SQLStoredProcedure_delete(_ouputTo);
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;

	switch (dbConnectionStrings_in[d].DBServerType) {
#if MySQL
		case DBServerTypes.MySQL:
#endif
		case DBServerTypes.SQLServer: {
			if (dbConnectionStrings_in[d].exists_aux__) 
				dbConnectionStrings_in[d].Connection.SQLStoredProcedure_delete(_ouputTo);
			break;
		}
	}
}
											break;
										}
										case XS_OutputEnumeration.MySQL_View: 
										case XS_OutputEnumeration.SQLServer_View: {
//_con.SQLView_delete(_ouputTo);
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;

	switch (dbConnectionStrings_in[d].DBServerType) {
#if MySQL
		case DBServerTypes.MySQL:
#endif
		case DBServerTypes.SQLServer: {
			if (dbConnectionStrings_in[d].exists_aux__) 
				dbConnectionStrings_in[d].Connection.SQLView_delete(_ouputTo);
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
for (int d = 0; d < dbConnectionStrings_in.Count; d++) {
	if (!dbConnectionStrings_in[d].enabled_aux__) continue;
	try {
		dbConnectionStrings_in[d].Connection.Execute_SQLQuery(_parsedOutput);
	} catch (Exception _ex) {
		System.Text.StringBuilder _sb = new System.Text.StringBuilder();
		for (int a = 0; a < template_in.Arguments.ArgumentCollection.Count; a++) {
			_sb.Append(string.Format(
				"{0}:\n\t{1}\n\t{2}\n",
				template_in.Arguments.ArgumentCollection[a].Name,
				template_in.Arguments.ArgumentCollection[a].Value,
				_args[template_in.Arguments.ArgumentCollection[a].Name]
			));
		}

		throw new Exception(string.Format(
			"---\nTEMPLATE: {0}\n---\nARGUMENTS:\n\n{5}\n---\nDBServerType:\n\n{2}\n---\nQUERY:\n\n{1}\n---\nEXCEPTION:\n\n{3}\n---\nINNER-EXCEPTION:\n\n{4}\n---\n",
			template_in.Name,
			_parsedOutput, 
			dbConnectionStrings_in[d].DBServerType.ToString(), 
			_ex.Message,
			_ex.InnerException,
			_sb.ToString()
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
		#region private class WorkerThread { ... }
		private class WorkerThread {
			public WorkerThread(
				System.Threading.Thread thread_int,
				DBConnectionstrings dbConnectionstrings_in
			) {
				this.Thread = thread_int;
				this.DBConnectionstrings = dbConnectionstrings_in;
			}

			public System.Threading.Thread Thread;
			public DBConnectionstrings DBConnectionstrings;
#if DEBUG
			public long TotalTicks = 0L;
#endif
		}
		#endregion

		private void build(
			dBuild notifyBack_in, 
//			bool loadMetadata_in, 
			MetadataInterface metadata_in,
			Statistics statistics_in,
			params string[] templateTypes_in
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

			#region int _templateName_MaxLength = ...;
			int _templateName_MaxLength = 0;
			for (int i = 0; i < templates_.TemplateCollection.Count; i++) {
				if (templates_.TemplateCollection[i].ID.Length > _templateName_MaxLength) {
					_templateName_MaxLength = templates_.TemplateCollection[i].ID.Length;
				}
			}
			#endregion

#if NET_1_1
			OGen.lib.worker.WorkItem[] _templatesState
				= new worker.WorkItem[templates_.TemplateCollection.Count];
#else
			OGen.lib.worker.WorkItem<XS_templateType>[] _templatesState
				= new worker.WorkItem<XS_templateType>[templates_.TemplateCollection.Count];
#endif
			int _threadIterarionCounter = 0;
			object _threadIterarionCounterLocker = new object();
			for (int i = 0; i < templates_.TemplateCollection.Count; i++) {

				// must check priorities, hence Waiting, otherwise Ready
				#region WorkItemState _state = (skipping) ? WorkItemState.Done : WorkItemState.Waiting;
				OGen.lib.worker.WorkItemState _state
					= OGen.lib.worker.WorkItemState.Waiting;
				if (
					(templateTypes_in != null)
					&&
					(templateTypes_in.Length > 0)
					&&
					(templates_.TemplateCollection[i].TemplateType != "")
					&&
					!OGen.lib.utils.StringArrayContains(
						templateTypes_in,
						templates_.TemplateCollection[i].TemplateType
					)
				) {
					string _stepNum = (++_threadIterarionCounter).ToString();
					string _stepOf = templates_.TemplateCollection.Count.ToString();
					notifyback_(
						string.Format(
							"thread 0: {0}#{1}/{2} - {3} {4} skipping!",
							"".PadLeft(_stepOf.Length - _stepNum.Length, ' '),
							_stepNum,
							_stepOf,
							templates_.TemplateCollection[i].ID,

							"".PadLeft(_templateName_MaxLength - templates_.TemplateCollection[i].ID.Length + 3, '.')
						),
						true
					);

					_state = OGen.lib.worker.WorkItemState.Done;
				}
				#endregion

#if NET_1_1
				_templatesState[i] = new OGen.lib.worker.WorkItem(
#else
				_templatesState[i] = new OGen.lib.worker.WorkItem<XS_templateType>(
#endif
					templates_.TemplateCollection[i],
					_state
				);
			}

			OGen.lib.worker.Worker _worker = new worker.Worker();
			int _numthreads = 4;
			WorkerThread[] _workthreads = new WorkerThread[_numthreads];
			for (int t = 0; t < _workthreads.Length; t++) {
				#region DBConnectionstrings _dbconnectionstrings = ...;
				DBConnectionstrings _dbconnectionstrings = new DBConnectionstrings();
				for (int d = 0; d < dbconnectionstrings_.Count; d++) {
					_dbconnectionstrings.Add(
						dbconnectionstrings_[d].DBServerType,
						dbconnectionstrings_[d].Connectionstring
					);
				}
				for (int d = 0; d < _dbconnectionstrings.Count; d++) {
					_dbconnectionstrings[d].Connection_createInstance();
				}
				#endregion

#if DEBUG
				int T = t;
#endif
				System.Threading.Thread _thread = new System.Threading.Thread(delegate() {
#if NET_1_1
					_worker.DoWork(
#else
					_worker.DoWork<XS_templateType>(
#endif
						_templatesState,
						delegate(
#if NET_1_1
							object template_in
#else
							XS_templateType template_in
#endif
						) {
#if NET_1_1
							XS_templateType _template = (XS_templateType)template_in;
#else
							XS_templateType _template = template_in;
#endif

							#region int _finishedDependencies = ...;
							int _finishedDependencies = 0;
							for (int d = 0; d < _template.Dependencies.DependencyCollection.Count; d++) {
								for (int f = 0; f < _templatesState.Length; f++) {
									if (
										_template.Dependencies.DependencyCollection[d].TemplateID
										==
#if NET_1_1
										((XS_templateType)_templatesState[f].Item).ID
#else
										_templatesState[f].Item.ID
#endif
									) {
										if (_templatesState[f].State == worker.WorkItemState.Done) {
											_finishedDependencies++;
										}
										break;
									}
								}
							}
							#endregion
							return (_finishedDependencies == _template.Dependencies.DependencyCollection.Count);
						},
						delegate(
#if NET_1_1
							object template_in
#else
							XS_templateType template_in
#endif
						) {
#if NET_1_1
							XS_templateType _template = (XS_templateType)template_in;
#else
							XS_templateType _template = template_in;
#endif

#if DEBUG
							long _begin = DateTime.Now.Ticks;
#endif

							#region RUNNING: _template ...

							bool _valuehasbeenfound_out = false;
							metadata_.IterateThrough_fromRoot(
								_template.IterationType,
								new utils.IterationFoundDelegate(
									delegate(string message_in) {
										notifyme(
											message_in,
											_template,
											_dbconnectionstrings,
											statistics_in
										);
									}
								),
								ref _valuehasbeenfound_out
							);
							#endregion

							int _threaditerarion;
							lock (_threadIterarionCounterLocker) {
								_threaditerarion = _threadIterarionCounter;

								_threadIterarionCounter = ++_threaditerarion;
							}

#if DEBUG
							_workthreads[T].TotalTicks += DateTime.Now.Ticks - _begin;
							TimeSpan _end = new TimeSpan(DateTime.Now.Ticks - _begin);
#endif
							string _stepNum = _threaditerarion.ToString();
							string _stepOf = templates_.TemplateCollection.Count.ToString();
							notifyback_(
								string.Format(
#if DEBUG
									"thread {6}: {0}#{1}/{2} - {3} {4} {5} ({7}s {8}m)",
#else
									"thread {6}: {0}#{1}/{2} - {3} {4} {5}",
#endif
									"".PadLeft(_stepOf.Length - _stepNum.Length, ' '),
									_stepNum,
									_stepOf,
#if NET_1_1
									((XS_templateType)template_in).ID,
									"".PadLeft(_templateName_MaxLength - ((XS_templateType)template_in).ID.Length + 3, '.'),
#else
									template_in.ID,
									"".PadLeft(_templateName_MaxLength - template_in.ID.Length + 3, '.'),
#endif
									(_valuehasbeenfound_out ? "DONE!" : "NOT doing!"),
									System.Threading.Thread.CurrentThread.Name

#if DEBUG
									,
									Convert.ToInt32(_end.TotalSeconds),
									_end.Milliseconds
#endif

								),
								true
							);

						}
					);
				});
				_thread.Name = string.Format("{0}", t + 1);
				_thread.IsBackground = true;
				_workthreads[t] = new WorkerThread(
					_thread,
					_dbconnectionstrings
				);
				_thread.Start();
			}

			for (int t = 0; t < _workthreads.Length; t++) {
				_workthreads[t].Thread.Join();
				#region _workthreads[t].DBConnectionstrings[0..n].Connection_createInstance();
				for (int d = 0; d < _workthreads[t].DBConnectionstrings.Count; d++) {
					_workthreads[t].DBConnectionstrings[d].Connection_clearInstance();
				}
				#endregion
			}

#if DEBUG
			for (int t = 0; t < _workthreads.Length; t++) {
				TimeSpan _span = new TimeSpan(_workthreads[t].TotalTicks);
				Console.WriteLine(
					"thread {0}: work span: {1}s {2}m",
					_workthreads[t].Thread.Name,
					Convert.ToInt32(_span.TotalSeconds),
					_span.Milliseconds
				);
			}
#endif
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
			MetadataInterface metadata_in,
			params string[] templateTypes_in
		) {
			Build(
				notifyBack_in,
				metadata_in,
				null,
				templateTypes_in
			);
		}
		public void Build(
			dBuild notifyBack_in,
			MetadataInterface metadata_in,
			Statistics statistics_in,
			params string[] templateTypes_in
		) {
			build(
				notifyBack_in, 
//				false, 
				metadata_in,
				statistics_in,
				templateTypes_in
			);
		}
		#endregion
		#endregion
	}
}
