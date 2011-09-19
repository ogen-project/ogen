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
	[BOClassAttribute("BO_NWS_Highlight", "")]
	public static class SBO_NWS_Highlight {

		#region public static SO_NWS_Highlight getObject(...);
		[BOMethodAttribute("getObject", true)]
		public static SO_NWS_Highlight getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idHighlight_in,

			out int[] errors_out
		) {
			SO_NWS_Highlight _output = null;
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
					PermitionType.Highlight__select
				)
			) {
				_errorlist.Add(ErrorType.highlight__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_NWS_Highlight.getObject(
				idHighlight_in,

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

			ref SO_NWS_Highlight highlight_ref,

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
			#region check Permitions . . .
			if (
				!sessionUser_out.hasPermition(
					false, 
					PermitionType.Highlight__insert,
					PermitionType.Highlight__update
				)
			) {
				errorlist_out.Add(ErrorType.highlight__lack_of_permitions_to_write);
				return false;
			}

			if (
				!sessionUser_out.hasPermition(PermitionType.Highlight__approve)
				&&
				(
					!highlight_ref.Approved_date_isNull
					||
					!highlight_ref.IFUser__Approved_isNull
				)
			) {
				errorlist_out.Add(ErrorType.highlight__lack_of_permitions_to_approve);
				return false;
			}
			#endregion

			// ToDos: here! check parent existence
			// ToDos: here! check if parent within same application
			// ToDos: here! check if any other checkings needed ...
			if (highlight_ref.IFHighlight__parent <= 0) {
				highlight_ref.IFHighlight__parent_isNull = true;
			}

			#region check Highlight ...
			if (
				(highlight_ref.Name = highlight_ref.Name.Trim())
				==
				""
			) {
				errorlist_out.Add(ErrorType.highlight__invalid_name);
				return false;
			}
			#endregion

			return true;
		} 
		#endregion
		#region public static int insObject(...);
		[BOMethodAttribute("insObject", true)]
		public static long insObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Highlight highlight_in, 
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

				ref highlight_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			if (_sessionuser.hasPermition(PermitionType.Highlight__approve)) {
				highlight_in.Approved_date = DateTime.Now;
				highlight_in.IFUser__Approved = _sessionuser.IDUser;
			} else {
				highlight_in.Approved_date_isNull = true;
				highlight_in.IFUser__Approved_isNull = true;
			}
			_output = DO_NWS_Highlight.insObject(
				highlight_in,
				selectIdentity_in,

				null
			);
			_errorlist.Add(ErrorType.highlight__successfully_created__WARNING);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Highlight highlight_in,

			out int[] errors_out
		) {
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in,

				ref highlight_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Highlight _highlight;
			if (
				highlight_in.IDHighlight <= 0
				||
				(
					(_highlight = DO_NWS_Highlight.getObject(
						highlight_in.IDHighlight
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			if (
				_highlight.IFUser__Approved_isNull
				||
				_highlight.Approved_date_isNull
			) {
				if (_sessionuser.hasPermition(PermitionType.Highlight__approve)) {
					highlight_in.Approved_date = DateTime.Now;
					highlight_in.IFUser__Approved = _sessionuser.IDUser;
				} else {
					highlight_in.Approved_date_isNull = true;
					highlight_in.IFUser__Approved_isNull = true;
				}
			} else {
				highlight_in.Approved_date = _highlight.Approved_date;
				highlight_in.IFUser__Approved = _highlight.IFUser__Approved;
			}

			highlight_in.IFApplication = _highlight.IFApplication;
			DO_NWS_Highlight.updObject(
				highlight_in,
				true,

				null
			);
			_errorlist.Add(ErrorType.highlight__successfully_updated__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void updObject_Approve(...);
		[BOMethodAttribute("updObject_Approve", true)]
		public static void updObject_Approve(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idHighlight_in,

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
					PermitionType.Highlight__approve
				)
			) {
				_errorlist.Add(ErrorType.highlight__lack_of_permitions_to_approve);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Highlight _highlight;
			if (
				idHighlight_in <= 0
				||
				(
					(_highlight = DO_NWS_Highlight.getObject(
						idHighlight_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			_highlight.Approved_date = DateTime.Now;
			_highlight.IFUser__Approved = _sessionuser.IDUser;
			DO_NWS_Highlight.updObject(
				_highlight,
				true,

				null
			);
			_errorlist.Add(ErrorType.highlight__successfully_approved__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void delObject(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		[BOMethodAttribute("delObject", true)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idHighlight_in,

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
					PermitionType.Highlight__delete
				)
			) {
				_errorlist.Add(ErrorType.highlight__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence...
			SO_NWS_Highlight _highlight;
			if (
				idHighlight_in <= 0
				||
				(
					(_highlight = DO_NWS_Highlight.getObject(
						idHighlight_in
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
					!_highlight.IFUser__Approved_isNull
					||
					!_highlight.Approved_date_isNull
				)
				&&
				// and no permition to approve
				!_sessionuser.hasPermition(
					PermitionType.Highlight__approve
				)
			) {
				_errorlist.Add(ErrorType.highlight__lack_of_permitions_to_delete_approved);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check References...
			if (
				(DO_NWS_ContentHighlight.getCount_inRecord_byHighlight(
					idHighlight_in
				) > 0)
				||
				(DO_NWS_Highlight.getCount_inRecord_byParent(
					idHighlight_in
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

				DO_NWS_Highlight.delObject(
					idHighlight_in,

					_con
				);

				_errorlist.Add(ErrorType.highlight__successfully_deleted__WARNING);

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

		#region public static SO_NWS_ContentHighlight[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true)]
		public static SO_NWS_ContentHighlight[] getRecord_byContent(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_NWS_ContentHighlight[] _output = null;
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
				= DO_NWS_ContentHighlight.getRecord_byContent(
					idContent_search_in,

					page_in,
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion

		#region public static SO_vNWS_Highlight[] getRecord_Approved(...);
		[BOMethodAttribute("getRecord_Approved", true)]
		public static SO_vNWS_Highlight[] getRecord_Approved(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idApplication_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Highlight[] _output = null;
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
					PermitionType.Highlight__select
				)
			) {
				_errorlist.Add(ErrorType.highlight__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Highlight.getRecord_Approved(
					idApplication_search_in,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Highlight[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true)]
		public static SO_vNWS_Highlight[] getRecord_all(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idApplication_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Highlight[] _output = null;
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
					PermitionType.Highlight__select_notApproved
				)
			) {
				_errorlist.Add(ErrorType.highlight__lack_of_permitions_to_read__not_approved);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Highlight.getRecord_all(
					idApplication_search_in,

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