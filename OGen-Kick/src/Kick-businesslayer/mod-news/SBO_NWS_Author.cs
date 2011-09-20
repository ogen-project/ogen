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
	[BOClassAttribute("BO_NWS_Author", "")]
	public static class SBO_NWS_Author {

		#region public static SO_NWS_Author getObject(...);
		[BOMethodAttribute("getObject", true)]
		public static SO_NWS_Author getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idAuthor_in,

			out int[] errors_out
		) {
			SO_NWS_Author _output = null;
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
					PermitionType.Author__select
				)
			) {
				_errorlist.Add(ErrorType.author__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_NWS_Author.getObject(
				idAuthor_in,

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

			ref SO_NWS_Author author_ref,

			out Guid sessionGuid_out,
			out Sessionuser sessionUser_out,
			out List<int> errorlist_out
		) {
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				ip_forLogPurposes_in,
				out sessionGuid_out,
				out sessionUser_out,
				out errorlist_out
			)) {
				return false;
			}
			#endregion
			#region check Permitions...
			if (
				!sessionUser_out.hasPermition(
					false, 
					PermitionType.Author__insert,
					PermitionType.Author__update
				)
			) {
				errorlist_out.Add(ErrorType.author__lack_of_permitions_to_write);
				return false;
			}

			if (
				!sessionUser_out.hasPermition(PermitionType.Author__approve)
				&&
				(
					!author_ref.Approved_date_isNull
					||
					!author_ref.IFUser__Approved_isNull
				)
			) {
				errorlist_out.Add(ErrorType.author__lack_of_permitions_to_approve);
				return false;
			}
			#endregion
			#region check Author...
			if (
				(author_ref.Name = author_ref.Name.Trim())
				==
				""
			) {
				errorlist_out.Add(ErrorType.author__invalid_name);
				return false;
			}
			#endregion

			return true;
		} 
		#endregion
		#region public static long insObject(...);
		[BOMethodAttribute("insObject", true)]
		public static long insObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Author author_in, 
			bool selectIdentity_in, 

			out int[] errors_out
		) {
			long _output = -1L;

			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in, 

				ref author_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			} 
			#endregion

			if (_sessionuser.hasPermition(PermitionType.Author__approve)) {
				author_in.Approved_date = DateTime.Now;
				author_in.IFUser__Approved = _sessionuser.IDUser;
			} else {
				author_in.Approved_date_isNull = true;
				author_in.IFUser__Approved_isNull = true;
			}
			_output = DO_NWS_Author.insObject(
				author_in,
				selectIdentity_in,

				null
			);
			_errorlist.Add(ErrorType.author__successfully_created__WARNING);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Author author_in,

			out int[] errors_out
		) {
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in,

				ref author_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence...
			SO_NWS_Author _author;
			if (
				author_in.IDAuthor <= 0
				||
				(
					(_author = DO_NWS_Author.getObject(
						author_in.IDAuthor
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			if (
				_author.IFUser__Approved_isNull
				||
				_author.Approved_date_isNull
			) {
				if (_sessionuser.hasPermition(PermitionType.Author__approve)) {
					author_in.Approved_date = DateTime.Now;
					author_in.IFUser__Approved = _sessionuser.IDUser;
				} else {
					author_in.Approved_date_isNull = true;
					author_in.IFUser__Approved_isNull = true;
				}
			} else {
				author_in.Approved_date = _author.Approved_date;
				author_in.IFUser__Approved = _author.IFUser__Approved;
			}

			author_in.IFApplication = _author.IFApplication;
			DO_NWS_Author.updObject(
				author_in,
				true,

				null
			);
			_errorlist.Add(ErrorType.author__successfully_updated__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void updObject_Approve(...);
		[BOMethodAttribute("updObject_Approve", true)]
		public static void updObject_Approve(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idAuthor_in,

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
					PermitionType.Author__approve
				)
			) {
				_errorlist.Add(ErrorType.author__lack_of_permitions_to_approve);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence...
			SO_NWS_Author _author;
			if (
				idAuthor_in <= 0
				||
				(
					(_author = DO_NWS_Author.getObject(
						idAuthor_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			_author.Approved_date = DateTime.Now;
			_author.IFUser__Approved = _sessionuser.IDUser;
			DO_NWS_Author.updObject(
				_author,
				true,

				null
			);
			_errorlist.Add(ErrorType.author__successfully_approved__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void delObject(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		[BOMethodAttribute("delObject", true)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idAuthor_in,

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
					PermitionType.Author__delete
				)
			) {
				_errorlist.Add(ErrorType.author__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence...
			SO_NWS_Author _author;
			if (
				idAuthor_in <= 0
				||
				(
					(_author = DO_NWS_Author.getObject(
						idAuthor_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Permitions... (more)
			if (
				// is approved
				(
					!_author.IFUser__Approved_isNull
					||
					!_author.Approved_date_isNull
				)
				&&
				// and no permition to approve
				!_sessionuser.hasPermition(
					PermitionType.Author__approve
				)
			) {
				_errorlist.Add(ErrorType.author__lack_of_permitions_to_delete_approved);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check References...
			if (
				(DO_NWS_ContentAuthor.getCount_inRecord_byAuthor(
					idAuthor_in
				) > 0)
			) {
				_errorlist.Add(ErrorType.data__constraint_violation);
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
				//_con.Open();
				//_con.Transaction.Begin();

				DO_NWS_Author.delObject(
					idAuthor_in,

					_con
				);

				_errorlist.Add(ErrorType.author__successfully_deleted__WARNING);

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

		#region public static SO_vNWS_Author[] getRecord_Approved(...);
		[BOMethodAttribute("getRecord_Approved", true)]
		public static SO_vNWS_Author[] getRecord_Approved(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Author[] _output = null;
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
					PermitionType.Author__select
				)
			) {
				_errorlist.Add(ErrorType.author__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Author.getRecord_Approved(
					_sessionuser.IDApplication,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Author[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true)]
		public static SO_vNWS_Author[] getRecord_all(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Author[] _output = null;
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
					PermitionType.Author__select_notApproved
				)
			) {
				_errorlist.Add(ErrorType.author__lack_of_permitions_to_read__not_approved);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Author.getRecord_all(
					_sessionuser.IDApplication,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static SO_NWS_ContentAuthor[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true)]
		public static SO_NWS_ContentAuthor[] getRecord_byContent(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_NWS_ContentAuthor[] _output = null;
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
					PermitionType.News__select_OffSchedule,
					PermitionType.News__select_OnSchedule
				)
			) {
				_errorlist.Add(ErrorType.news__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_NWS_ContentAuthor.getRecord_byContent(
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