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
	[BOClassAttribute("BO_NWS_Attachment", "")]
	public static class SBO_NWS_Attachment {

		#region public static SO_NWS_Attachment getObject(...);
		[BOMethodAttribute("getObject", true)]
		public static SO_NWS_Attachment getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idAttachment_in,

			out int[] errors_out
		) {
			SO_NWS_Attachment _output = null;
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(
					false, 
					PermitionType.News__select_OnSchedule, 
					PermitionType.News__select_OffSchedule
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_NWS_Attachment.getObject(
				idAttachment_in,

				null
			);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region private static bool check(...);
		private static bool check(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			ref SO_NWS_Attachment attachment_ref,

			out Guid sessionGuid_out,
			out Sessionuser sessionUser_out,
			out List<int> errorlist_out,
			out int[] errors_out
		) {
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out sessionGuid_out,
				out sessionUser_out,
				out errorlist_out,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return false;
			}
			#endregion
			#region check Permitions . . .
			if (
				!sessionUser_out.hasPermition(
					false, 
					PermitionType.News__insert,
					PermitionType.News__update_Approved,
					PermitionType.News__update_Mine_notApproved
				)
			) {
				errorlist_out.Add(ErrorType.news__lack_of_permitions_to_write);
				return false;
			}
			#endregion

			#region //check Attachment ... (nothing to check!)
			#endregion

			return true;
		} 
		#endregion
		#region public static long insObject(...);
		[BOMethodAttribute("insObject", true)]
		public static long insObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Attachment attachment_in,
			SO_DIC__TextLanguage[] tx_Name_in,
			SO_DIC__TextLanguage[] tx_Description_in,
			int idApplication_in, 

			bool selectIdentity_in, 

			out string guid_out, 

			out int[] errors_out
		) {
			guid_out = "";
			long _output = -1L;

			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				ref attachment_in, 

				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			} 
			#endregion
			#region check Existence . . .
			if (
				(attachment_in.IFContent <= 0)
				||
				!DO_NWS_Content.isObject(attachment_in.IFContent)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			// ToDos: here! should mark Content to be re-Approved!
			// ToDos: here! or not allow if no approve permition

			Exception _exception = null;
			#region DBConnection _con = DO__utils.DBConnection_createInstance(...);
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType,
				DO__utils.DBConnectionstring,
				DO__utils.DBLogfile
			); 
			#endregion
			try {
				//if (
				//    (
				//        (tx_Name_in != null) 
				//        && 
				//        (tx_Name_in.Length != 0)) 
				//    ||
				//    (
				//        (tx_Description_in != null) 
				//        && 
				//        (tx_Description_in.Length != 0)
				//    )
				//) {
				_con.Open();
				_con.Transaction.Begin();
				//}

				#region content_in.TX_Name = ...;
				if (
					(tx_Name_in == null)
					||
					(tx_Name_in.Length == 0)
				) {
					attachment_in.TX_Name_isNull = true;
				} else {
					attachment_in.TX_Name = SBO_DIC_Dic.insObject(
						_con,

						idApplication_in,
						OGen.NTier.Kick.lib.businesslayer.shared.TableFieldSource.NWS_ATTACHMENT__TX_NAME,

						tx_Name_in
					);
				}
				#endregion
				#region content_in.TX_Description = ...;
				if (
					(tx_Description_in == null)
					||
					(tx_Description_in.Length == 0)
				) {
					attachment_in.TX_Description_isNull = true;
				} else {
					attachment_in.TX_Description = SBO_DIC_Dic.insObject(
						_con,

						idApplication_in,
						OGen.NTier.Kick.lib.businesslayer.shared.TableFieldSource.NWS_ATTACHMENT__TX_DESCRIPTION,

						tx_Description_in
					);
				}
				#endregion

				attachment_in.GUID 
					= guid_out 
					= Guid.NewGuid().ToString("N");
				attachment_in.OrderNum = DateTime.Now.Ticks;
				_output = DO_NWS_Attachment.insObject(
					attachment_in,
					selectIdentity_in,

					_con
				);
				_errorlist.Add(ErrorType.news__attachment__successfully_created__WARNING);

				#region _con.Transaction.Commit();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Commit();
				}
				#endregion
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
				#region SBO_LOG_Log.Log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L, 
					idApplication_in,
					"{0}",
					new string[] {
			            _exception.Message
			        }
				);
				#endregion
				_errorlist.Add(ErrorType.data);
			}

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Attachment attachment_in,
			SO_DIC__TextLanguage[] tx_Name_in,
			SO_DIC__TextLanguage[] tx_Description_in,
			int idApplication_in, 

			out int[] errors_out
		) {
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in,

				ref attachment_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist,
				out errors_out
			)) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			#region check existence . . .
			SO_NWS_Attachment _attachment;
			if (
				attachment_in.IDAttachment <= 0
				||
				(
					(_attachment = DO_NWS_Attachment.getObject(
						attachment_in.IDAttachment
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			// ToDos: here! should mark Content to be re-Approved!
			// ToDos: here! or not allow if no approve permition

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

				#region TX_Name . . .
				if ((tx_Name_in != null) && (tx_Name_in.Length != 0)) {
					if (_attachment.TX_Name_isNull) {
						_attachment.TX_Name = SBO_DIC_Dic.insObject(
							_con,
							idApplication_in,
							OGen.NTier.Kick.lib.businesslayer.shared.TableFieldSource.NWS_ATTACHMENT__TX_NAME,
							tx_Name_in
						);
					} else {
						SBO_DIC_Dic.updObject(
							_con,
							_attachment.TX_Name,
							tx_Name_in
						);
					}
				}
				#endregion
				#region TX_Description . . .
				if ((tx_Description_in != null) && (tx_Description_in.Length != 0)) {
					if (_attachment.TX_Description_isNull) {
						_attachment.TX_Description = SBO_DIC_Dic.insObject(
							_con,
							idApplication_in,
							OGen.NTier.Kick.lib.businesslayer.shared.TableFieldSource.NWS_ATTACHMENT__TX_DESCRIPTION,
							tx_Description_in
						);
					} else {
						SBO_DIC_Dic.updObject(
							_con,
							_attachment.TX_Description,
							tx_Description_in
						);
					}
				}
				#endregion

				//_attachment.??? = attachment_in.???;
				DO_NWS_Attachment.updObject(
					_attachment,
					true,

					_con
				);
				_errorlist.Add(ErrorType.news__attachment__successfully_updated__WARNING);

				#region _con.Transaction.Commit();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Commit();
				}
				#endregion
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
				#region SBO_LOG_Log.Log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L, 
					idApplication_in,
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

		#region public static void delObject(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		[BOMethodAttribute("delObject", true)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idAttachment_in,

			int idApplication_in,

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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(
					false, 
					PermitionType.News__delete_Approved,
					PermitionType.News__delete_Mine_notApproved
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence...
			SO_NWS_Attachment _attachment;
			if (
				idAttachment_in <= 0
				||
				(
					(_attachment = DO_NWS_Attachment.getObject(
						idAttachment_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region //check References . . . (no references to check)
			//if (
			//    (DO_NWS_ContentAuthor.getCount_inRecord_byAuthor(
			//        idAttachment_in
			//    ) > 0)
			//) {
			//    _errors.Add(ErrorType.data__constraint_violation);
			//    errors_out = _errors.ToArray();
			//    return;
			//}
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

				DO_NWS_Attachment.delObject(
					idAttachment_in,

					_con
				);
				#region SBO_DIC_Dic.delObject(_con, _attachment.TX_Name);
				if (!_attachment.TX_Name_isNull) {
					SBO_DIC_Dic.delObject(
						_con,

						_attachment.TX_Name
					);
				}
				#endregion
				#region SBO_DIC_Dic.delObject(_con, _attachment.TX_Description);
				if (!_attachment.TX_Description_isNull) {
					SBO_DIC_Dic.delObject(
						_con,

						_attachment.TX_Description
					);
				}
				#endregion

				_errorlist.Add(ErrorType.news__attachment__successfully_deleted__WARNING);

				#region _con.Transaction.Commit();
				if (
					_con.isOpen
					&&
					_con.Transaction.inTransaction
				) {
					_con.Transaction.Commit();
				}
				#endregion
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
				#region SBO_LOG_Log.Log(ErrorType.data);
				OGen.NTier.Kick.lib.businesslayer.SBO_LOG_Log.log(
					_sessionuser,
					LogType.error,
					ErrorType.data,
					-1L, 
					idApplication_in,
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

		#region public static SO_vNWS_Attachment[] getRecord_byContent_andLanguage(...);
		[BOMethodAttribute("getRecord_byContent_andLanguage", true)]
		public static SO_vNWS_Attachment[] getRecord_byContent_andLanguage(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long IDContent_search_in,
			int IDLanguage_search_in, 

			out int[] errors_out
		) {
			SO_vNWS_Attachment[] _output = null;
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(
					false, 
					PermitionType.News__select_OnSchedule, 
					PermitionType.News__select_OffSchedule
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_vNWS_Attachment.getRecord_byContent_andL(
				IDContent_search_in, 
				IDLanguage_search_in, 

				0, 0, 
				null
			);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Attachment[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true)]
		public static SO_vNWS_Attachment[] getRecord_byContent(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Attachment[] _output = null;
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(
					false,
					PermitionType.News__select_OnSchedule,
					PermitionType.News__select_OffSchedule
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Attachment.getRecord_byContent(
					idContent_search_in,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
	}
}