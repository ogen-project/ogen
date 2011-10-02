#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Collections.Generic;

using OGen.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.lib.crypt;
using OGen.NTier.Kick.lib.datalayer;
using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
//using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	[BOClassAttribute("BO_DIC_Dic", "")]
	public static class SBO_DIC_Dic {

		#region public static void insLanguage(...);
		[BOMethodAttribute("insLanguage", true, false, 1)]
		public static void insLanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			SO_DIC__TextLanguage[] languageName_in, 

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}
			#endregion
			#region check permitions...
			if (!_sessionuser.hasPermition(PermitionType.Language__insert)) {
				_errorlist.Add(ErrorType.language__lack_of_permitions_to_write);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion


			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();


				#region long _idtext = DO_DIC_Text.insObject(...);
				#region SO_DIC_Text _text = ...;
				SO_DIC_Text _text = new SO_DIC_Text(
					-1L, 
					-1, 
					-1
				);
				_text.IFApplication_isNull = true;
				_text.SourceTableField_ref_isNull = true;
				#endregion

				long _idtext = DO_DIC_Text.insObject(
					_text,
					true,
					_con
				);
				#endregion
				#region int _idlanguage = DO_DIC_Language.insObject(...);
				int _idlanguage = DO_DIC_Language.insObject(
					new SO_DIC_Language(
						-1,
						_idtext
					),
					true,
					_con
				);
				#endregion
				for (int i = 0; i < languageName_in.Length; i++) {
					if (languageName_in[i].IFLanguage > 0) {
						updObject(
							_con, 
							_idtext,
							(languageName_in[i].IFLanguage > 0) 

								// name of the new language on existing languages
								? languageName_in[i]

								// name of the new language (on new language)
								: new SO_DIC__TextLanguage(
									_idlanguage, 
									languageName_in[i].Text
								)

						);
					}
				}

				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.language__successfully_created__WARNING);
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

				_exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
						_exception.Message
					}
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}


			errors_out = _errorlist.ToArray();
		}
		#endregion
		#region public static void updLanguage(...);
		[BOMethodAttribute("updLanguage", true, false, 1)]
		public static void updLanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			int idLanguage_in,
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in, 

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}
			#endregion
			#region check permitions...
			if (!_sessionuser.hasPermition(PermitionType.Language__update)) {
				_errorlist.Add(ErrorType.language__lack_of_permitions_to_write);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence... SO_DIC_Language _language = ...;
			SO_DIC_Language _language = DO_DIC_Language.getObject(idLanguage_in);

			if (_language == null) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();
			
				updObject(
					_con,
					_language.TX_Name,
					textLanguage_in
				);
			
				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.language__successfully_updated__WARNING);
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

				_exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
						_exception.Message
					}
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion
		#region public static void delLanguage(...);
		[BOMethodAttribute("delLanguage", true, false, 1)]
		public static void delLanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			int idLanguage_in,

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}
			#endregion
			#region check permitions...
			if (!_sessionuser.hasPermition(PermitionType.Language__delete)) {
				_errorlist.Add(ErrorType.language__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence... SO_DIC_Language _language = ...;
			SO_DIC_Language _language = DO_DIC_Language.getObject(idLanguage_in);

			if (_language == null) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();

				DO_DIC_LanguageApplication.delRecord_byLanguage(
					idLanguage_in,
					_con
				);
				DO_DIC_Language.delObject(
					idLanguage_in,
					_con
				);
				delObject(
					_con,
					_language.TX_Name
				);
			
				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.language__successfully_deleted__WARNING);
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

				_exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
						_exception.Message
					}
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void setSupportedLanguages(...);
		[BOMethodAttribute("setSupportedLanguages", true, false, 1)]
		public static void setSupportedLanguages(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			int[] idLanguages_in,

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}
			#endregion
			#region check permitions...
			if (!_sessionuser.hasPermition(PermitionType.Language__set_supported)) {
				_errorlist.Add(ErrorType.language__lack_of_permitions_to_set);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			);
			#endregion
			try {
				if (
					(idLanguages_in != null)
					&&
					(idLanguages_in.Length > 0)
				) {
					_con.Open();
					_con.Transaction.Begin();
				}

				DO_DIC_LanguageApplication.delRecord_byApplication(
					_sessionuser.IDApplication,

					_con
				);
				if (
					(idLanguages_in != null)
					&&
					(idLanguages_in.Length > 0)
				) {
					for (int i = 0; i < idLanguages_in.Length; i++) {
						DO_DIC_LanguageApplication.setObject(
							new SO_DIC_LanguageApplication(
								idLanguages_in[i],
								_sessionuser.IDApplication
							),
							true,
							_con
						);
					}
				}


				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.language__successfully_set__WARNING);
			} catch (Exception _ex) {
				#region _con.Transaction.Rollback();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Rollback();
				}
				#endregion

				_exception = _ex;
			} finally {
				#region _con.Transaction.Terminate(); _con.Close(); _con.Dispose();
				if (_con.isOpen) {
					if (_con.Transaction.inTransaction) {
						_con.Transaction.Terminate();
					}
					_con.Close();
				}

				_con.Dispose();
				#endregion
			}
			if (_exception != null) {
				#region SBO_LOG_Log.log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L,
					_sessionuser.IDApplication,
					"{0}",
					new string[] {
						_exception.Message
					}
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region internal static long insObject(...);
		internal static long insObject(
			DBConnection dbConnection_in, 

			int idApplication_in,
			int sourceTableField_ref_in, 

			params OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in
		) {
			if (textLanguage_in.Length == 0) return -1L;

			#region SO_DIC_Text _text = ...;
			SO_DIC_Text _text = new SO_DIC_Text(
					-1,
					idApplication_in,
					sourceTableField_ref_in
				);
			if (idApplication_in <= 0) {
				_text.IFApplication_isNull = true;
			}
			if (sourceTableField_ref_in <= 0) {
				_text.SourceTableField_ref_isNull = true;
			} 
			#endregion

			long _idtext = DO_DIC_Text.insObject(
				_text,
				true, 

				dbConnection_in
			);

			updObject(
				dbConnection_in,

				_idtext,
				textLanguage_in
			);

			return _idtext;
		}
		#endregion
		#region internal static void updObject(...);
		internal static void updObject(
			DBConnection dbConnection_in,

			long idText_in,

			params OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in
		) {
			SO_DIC_TextLanguage _textlanguage;
			foreach (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage _text in textLanguage_in) {
				#region _textlanguage = ...;
				_textlanguage 
					= new SO_DIC_TextLanguage(
						idText_in,
						_text.IFLanguage,
						"",
						""
					);
				if (_text.Text.Length > 8000) {
					_textlanguage.Text = _text.Text;
					_textlanguage.CharVar8000_isNull = true;
				} else {
					_textlanguage.Text_isNull = true;
					_textlanguage.CharVar8000 = _text.Text;
				}
				#endregion
				DO_DIC_TextLanguage.setObject(
					_textlanguage,
					true, 

					dbConnection_in
				);
			}
		}
		#endregion
//		#region internal static void delObject(...);
		internal static void delObject(
			DBConnection dbConnection_in,

			long idText_in

		//) {
		//    delObject(
		//        dbConnection_in,

		//        idText_in,

		//        -1
		//    );
		//}

		//public static void delObject(
		//    DBConnection dbConnection_in,

		//    long idText_in,

		//    int sourceTableField_ref_in
		) {

			DO_DIC_TextLanguage.delRecord_byText(
				idText_in,

				dbConnection_in
			);
			DO_DIC_Text.delObject(
				idText_in, 

				dbConnection_in
			);
		}
//		#endregion

		#region public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(...);
		[BOMethodAttribute("getRecord_byApplication", true, false, 1)]
		public static SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			out int[] errors_out
		) {
			SO_vDIC_ApplicationLanguage[]  _output = null;

			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return _output;
			}
			#endregion

			return DO_vDIC_ApplicationLanguage.getRecord_byApplication(
				_sessionuser.IDApplication,
				0,
				0,
				null
			);
		}
		#endregion

		#region public static SO_vDIC_Language[] getRecord_byLanguage(...);
		[BOMethodAttribute("getRecord_byLanguage", true, false, 1)]
		public static SO_vDIC_Language[] getRecord_byLanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			int idLanguage_in, 

			out int[] errors_out
		) {
			SO_vDIC_Language[] _output = null;

			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return _output;
			}
			#endregion

			// ToDos: here! check permitions... not very important

			return DO_vDIC_Language.getRecord_byLanguage(
				idLanguage_in, 
				0,
				0,
				null
			);
		}
		#endregion
		#region public static SO_vDIC_Language[] getRecord_Language(...);
		[BOMethodAttribute("getRecord_Language", true, false, 1)]
		public static SO_vDIC_Language[] getRecord_Language(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			int idLanguage_in, 

			out int[] errors_out
		) {
			SO_vDIC_Language[] _output = null;

			List<int> _errorlist;
			Guid _sessionguid;
			Sessionuser _sessionuser;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return _output;
			}
			#endregion

			// ToDos: here! check permitions... not very important

			return DO_vDIC_Language.getRecord_Language(
				idLanguage_in, 
				0,
				0,
				null
			);
		}
		#endregion
	}
}