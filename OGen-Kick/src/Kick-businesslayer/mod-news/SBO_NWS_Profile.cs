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
	[BOClassAttribute("BO_NWS_Profile", "")]
	public static class SBO_NWS_Profile {

		#region public static SO_vNWS_Profile getObject(...);
		[BOMethodAttribute("getObject", true)]
		public static SO_vNWS_Profile getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idProfile_in,

			out int[] errors_out
		) {
			
			SO_vNWS_Profile _output = null;
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
					PermitionType.News__Profile__select
				)
			) {
				_errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output = DO_vNWS_Profile.getObject_byProfile(
				idProfile_in,

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

			ref SO_vNWS_Profile profile_ref,

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
					PermitionType.News__Profile__insert,
					PermitionType.News__Profile__update
				)
			) {
				errorlist_out.Add(ErrorType.news__profile__lack_of_permitions_to_write);
				return false;
			}

			if (
				(
					!profile_ref.Approved_date_isNull
					||
					!profile_ref.IFUser__Approved_isNull
				)
				&&
				!sessionUser_out.hasPermition(PermitionType.News__Profile__approve)
			) {
				errorlist_out.Add(ErrorType.news__profile__lack_of_permitions_to_approve);
				return false;
			}
			#endregion

			#region check Profile ...
			if (
				(profile_ref.Name = profile_ref.Name.Trim())
				==
				""
			) {
				errorlist_out.Add(ErrorType.news__profile__invalid_name);
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

			SO_vNWS_Profile profile_in, 

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

				ref profile_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return _output;
			} 
			#endregion

			#region SO_CRD_Profile _crd_profile = new SO_CRD_Profile(...);
			SO_CRD_Profile _crd_profile
				= new SO_CRD_Profile(
					-1L,
					profile_in.Name,
					profile_in.IDApplication
				); 
			#endregion
			#region _crd_profile.IFApplication = profile_in.IDApplication;
			if (
				(profile_in.IDApplication_isNull)
				||
				(profile_in.IDApplication <= 0)
			) {
				_crd_profile.IFApplication_isNull = true;
			} else {
				_crd_profile.IFApplication = profile_in.IDApplication;
			}
			#endregion
			_crd_profile.Name = profile_in.Name;

			#region SO_NWS_Profile _nws_profile = new SO_NWS_Profile(...);
			SO_NWS_Profile _nws_profile 
				= new SO_NWS_Profile(
				); 
			#endregion
			#region _nws_profile.IFUser__Approved = ...;
			if (_sessionuser.hasPermition(PermitionType.News__Profile__approve)) {
				_nws_profile.Approved_date = DateTime.Now;
				_nws_profile.IFUser__Approved = _sessionuser.IDUser;
			} else {
				//// ALREADY CHECKED!!!
				//if (
				//    !profile_in.Approved_date_isNull
				//    ||
				//    !profile_in.IFUser__Approved_isNull
				//) {
				//    _errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_approve);
				//    errors_out = _errorlist.ToArray();
				//    return _output;
				//} else {
					_nws_profile.Approved_date_isNull = true;
					_nws_profile.IFUser__Approved_isNull = true;
				//}
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

				_output = DO_CRD_Profile.insObject(
					_crd_profile,
					true,

					_con
				);

				_nws_profile.IFProfile = _output;
				DO_NWS_Profile.setObject(
					_nws_profile,
					true,

					_con
				);

				_errorlist.Add(ErrorType.news__profile__successfully_created__WARNING);

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
			return _output;
		}
		#endregion
		#region public static void updObject(...);
		[BOMethodAttribute("updObject", true)]
		public static void updObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			SO_vNWS_Profile profile_in,

			out int[] errors_out
		) {

			Guid _sessionguid;
			Sessionuser _sessionuser;

			#region check...
			List<int> _errorlist;
			if (!check(
				sessionGuid_in,
				ip_forLogPurposes_in,

				ref profile_in,

				out _sessionguid,
				out _sessionuser,
				out _errorlist
			)) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . . SO_NWS_Profile _nws_profile = DO_NWS_Profile.getObject(...);
			SO_NWS_Profile _nws_profile;
			if (
				profile_in.IDProfile <= 0
				||
				(
					(_nws_profile = DO_NWS_Profile.getObject(
						profile_in.IDProfile
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region _nws_profile.IFUser__Approved = ...;
			if (
					_nws_profile.IFUser__Approved_isNull
					||
					_nws_profile.Approved_date_isNull
				) {
				if (_sessionuser.hasPermition(PermitionType.News__Profile__approve)) {
					_nws_profile.Approved_date = DateTime.Now;
					_nws_profile.IFUser__Approved = _sessionuser.IDUser;
				} else {
					_nws_profile.Approved_date_isNull = true;
					_nws_profile.IFUser__Approved_isNull = true;
				}
			}
			#endregion

			#region SO_CRD_Profile _crd_profile = DO_CRD_Profile.getObject(_nws_profile.IFProfile);
			SO_CRD_Profile _crd_profile
				= DO_CRD_Profile.getObject(
					_nws_profile.IFProfile
				); 
			#endregion
			//// preserve, hence comment:
			//_crd_profile.IFApplication = profile_in.IDApplication;
			_crd_profile.Name = profile_in.Name;


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

				DO_NWS_Profile.setObject(
					_nws_profile,
					true,

					_con
				);

				DO_CRD_Profile.updObject(
					_crd_profile,
					false, // I did getObject prior, so no problem. BE CAREFULL in future updates!

					_con
				);

				_errorlist.Add(ErrorType.news__profile__successfully_updated__WARNING);

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

		#region public static void updObject_Approve(...);
		[BOMethodAttribute("updObject_Approve", true)]
		public static void updObject_Approve(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idProfile_in,

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
					PermitionType.News__Profile__approve
				)
			) {
				_errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_approve);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Profile _profile;
			if (
				idProfile_in <= 0
				||
				(
					(_profile = DO_NWS_Profile.getObject(
						idProfile_in
					)) == null
				)
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			_profile.Approved_date = DateTime.Now;
			_profile.IFUser__Approved = _sessionuser.IDUser;
			DO_NWS_Profile.setObject(
				_profile,
				true,

				null
			);
			_errorlist.Add(ErrorType.news__profile__successfully_approved__WARNING);

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void delObject(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		[BOMethodAttribute("delObject", true)]
		public static void delObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idProfile_in,

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
					PermitionType.News__Profile__delete
				)
			) {
				_errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check existence . . .
			SO_NWS_Profile _profile;
			if (
				idProfile_in <= 0
				||
				(
					(_profile = DO_NWS_Profile.getObject(
						idProfile_in
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
					!_profile.IFUser__Approved_isNull
					||
					!_profile.Approved_date_isNull
				)
				&&
				// and no permition to approve
				!_sessionuser.hasPermition(
					PermitionType.News__Profile__approve
				)
			) {
				_errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_delete_approved);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check References . . .
			if (
				(DO_NWS_ContentProfile.getCount_inRecord_byProfile(
					idProfile_in
				) > 0)
				||
				(DO_CRD_ProfilePermition.getCount_inRecord_byProfile(
					idProfile_in
				) > 0)
				||
				(DO_CRD_UserProfile.getCount_inRecord_byProfile(
					idProfile_in
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
				_con.Open();
				_con.Transaction.Begin();

				DO_NWS_Profile.delObject(
					idProfile_in,

					_con
				);
				DO_CRD_Profile.delObject(
					idProfile_in,

					_con
				);

				_errorlist.Add(ErrorType.news__profile__successfully_deleted__WARNING);

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

		#region public static SO_vNWS_Profile[] getRecord_Approved(...);
		[BOMethodAttribute("getRecord_Approved", true)]
		public static SO_vNWS_Profile[] getRecord_Approved(
			#region params...
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idApplication_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
			#endregion
		) {
			SO_vNWS_Profile[] _output = null;
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
					PermitionType.News__Profile__select
				)
			) {
				_errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output 
				= DO_vNWS_Profile.getRecord_Approved(
					idApplication_search_in,

					page_in, 
					page_numRecords_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static SO_vNWS_Profile[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true)]
		public static SO_vNWS_Profile[] getRecord_all(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_vNWS_Profile[] _output = null;
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
				!_sessionuser.hasPermition(PermitionType.News__Profile__select)
			) {
				_errorlist.Add(ErrorType.news__profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_vNWS_Profile.getRecord_all(
					//(idApplication_in > 0)
					//    ? (object)idApplication_in
					//    : null,
					_sessionuser.IDApplication, 
					page_in,
					page_numRecords_in, 
					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static SO_NWS_ContentProfile[] getRecord_byContent(...);
		[BOMethodAttribute("getRecord_byContent", true)]
		public static SO_NWS_ContentProfile[] getRecord_byContent(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idContent_search_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_NWS_ContentProfile[] _output = null;
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
				= DO_NWS_ContentProfile.getRecord_byContent(
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