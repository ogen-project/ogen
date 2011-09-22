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
	[BOClassAttribute("BO_NWS_Source", "")]
	public static class SBO_NWS_Source {

		#region public static SO_NWS_Source getObject(...);
		[BOMethodAttribute("getObject", true)]
		public static SO_NWS_Source getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idSource_in,

			out int[] errors_out
		) {
			SO_NWS_Source _output = null;
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
			#region check Permitions . . .
			if (
				!_sessionuser.hasPermition(
					PermitionType.Source__select
				)
			) {
				_errorlist.Add(ErrorType.source__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_NWS_Source.getObject(
				idSource_in,

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

			ref SO_NWS_Source source_ref,

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
					PermitionType.Source__insert,
					PermitionType.Source__update
				)
			) {
				errorlist_out.Add(ErrorType.source__lack_of_permitions_to_write);
				return false;
			}

			if (
				!sessionUser_out.hasPermition(PermitionType.Source__approve)
				&&
				(
					!source_ref.Approved_date_isNull
					||
					!source_ref.IFUser__Approved_isNull
				)
			) {
				errorlist_out.Add(ErrorType.source__lack_of_permitions_to_approve);
				return false;
			}
			#endregion

			// ToDos: here! check parent existence
			// ToDos: here! check if parent within same application
			// ToDos: here! check if any other checkings needed ...
			if (source_ref.IFSource__parent <= 0) {
				source_ref.IFSource__parent_isNull = true;
			}

			#region check Source ...
			if (
				(source_ref.Name = source_ref.Name.Trim())
				==
				""
			) {
				errorlist_out.Add(ErrorType.source__invalid_name);
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

			SO_NWS_Source source_in, 
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

				ref source_in, 

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			} 
			#endregion

			if (_sessionuser.hasPermition(PermitionType.Source__approve)) {
				source_in.Approved_date = DateTime.Now;
				source_in.IFUser__Approved = _sessionuser.IDUser;
			} else {
				source_in.Approved_date_isNull = true;
				source_in.IFUser__Approved_isNull = true;
			}
			source_in.IFApplication = _sessionuser.IDApplication;
			_output = DO_NWS_Source.insObject(
				source_in,
				selectIdentity_in,

				null
			);
			_errorlist.Add(ErrorType.source__successfully_created__WARNING);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_NWS_Source source_in,

			out int[] errors_out
		) {
			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in,

				ref source_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Source _source;
			if (
				source_in.IDSource <= 0
				||
				(
					(_source = DO_NWS_Source.getObject(
						source_in.IDSource
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			if (
				_source.IFUser__Approved_isNull
				||
				_source.Approved_date_isNull
			) {
				if (_sessionuser.hasPermition(PermitionType.Source__approve)) {
					source_in.Approved_date = DateTime.Now;
					source_in.IFUser__Approved = _sessionuser.IDUser;
				} else {
					source_in.Approved_date_isNull = true;
					source_in.IFUser__Approved_isNull = true;
				}
			} else {
				source_in.Approved_date = _source.Approved_date;
				source_in.IFUser__Approved = _source.IFUser__Approved;
			}

			source_in.IFApplication = _source.IFApplication;
			DO_NWS_Source.updObject(
				source_in,
				true,

				null
			);
			_errorlist.Add(ErrorType.source__successfully_updated__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void updObject_Approve(...);
		[BOMethodAttribute("updObject_Approve", true)]
		public static void updObject_Approve(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idSource_in,

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
			#region check Permitions . . .
			if (
				!_sessionuser.hasPermition(
					PermitionType.Source__approve
				)
			) {
				_errorlist.Add(ErrorType.source__lack_of_permitions_to_approve);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Source _source;
			if (
				idSource_in <= 0
				||
				(
					(_source = DO_NWS_Source.getObject(
						idSource_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			_source.Approved_date = DateTime.Now;
			_source.IFUser__Approved = _sessionuser.IDUser;
			DO_NWS_Source.updObject(
				_source,
				true,

				null
			);
			_errorlist.Add(ErrorType.source__successfully_approved__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void delObject(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		[BOMethodAttribute("delObject", true)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idSource_in,

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
			#region check Permitions . . .
			if (
				!_sessionuser.hasPermition(
					PermitionType.Source__delete
				)
			) {
				_errorlist.Add(ErrorType.source__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Source _source;
			if (
				idSource_in <= 0
				||
				(
					(_source = DO_NWS_Source.getObject(
						idSource_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Permitions . . . (more)
			if (
				// is approved
				(
					!_source.IFUser__Approved_isNull
					||
					!_source.Approved_date_isNull
				)
				&&
				// and no permition to approve
				!_sessionuser.hasPermition(
					PermitionType.Source__approve
				)
			) {
				_errorlist.Add(ErrorType.source__lack_of_permitions_to_delete_approved);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check References . . .
			if (
				(DO_NWS_ContentSource.getCount_inRecord_bySource(
					idSource_in
				) > 0)
				||
				(DO_NWS_Source.getCount_inRecord_byParent(
					idSource_in
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

				DO_NWS_Source.delObject(
					idSource_in,

					_con
				);

				_errorlist.Add(ErrorType.source__successfully_deleted__WARNING);

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

		#region public static SO_vNWS_Source[] getRecord_Approved(...);
		[BOMethodAttribute("getRecord_Approved", true)]
		public static SO_vNWS_Source[] getRecord_Approved(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Source[] _output = null;
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
			#region check Permitions . . .
			if (
				!_sessionuser.hasPermition(
					PermitionType.Source__select
				)
			) {
				_errorlist.Add(ErrorType.source__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Source.getRecord_Approved(
					_sessionuser.IDApplication,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Source[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true)]
		public static SO_vNWS_Source[] getRecord_all(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Source[] _output = null;
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
			#region check Permitions . . .
			if (
				!_sessionuser.hasPermition(
					PermitionType.Source__select_notApproved
				)
			) {
				_errorlist.Add(ErrorType.source__lack_of_permitions_to_read__not_approved);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Source.getRecord_all(
					_sessionuser.IDApplication,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static SO_NWS_ContentSource[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true)]
		public static SO_NWS_ContentSource[] getRecord_byContent(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_NWS_ContentSource[] _output = null;
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
			#region check Permitions . . .
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
				= DO_NWS_ContentSource.getRecord_byContent(
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