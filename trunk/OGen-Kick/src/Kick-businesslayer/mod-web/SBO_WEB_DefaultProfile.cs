#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.BusinessLayer {
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Text;

	using OGen.Libraries.Crypt;
	using OGen.Libraries.DataLayer;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	//using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.DataLayer;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;
	using OGen.NTier.Libraries.BusinessLayer;

	[BOClassAttribute("BO_WEB_DefaultProfile", "")]
	public static class SBO_WEB_DefaultProfile {
		#region public static void setObject(...);
		[BOMethodAttribute("setObject", true, false, 1)]
		public static void setObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			long[] idProfile_in,

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
			#region check Permissions...
			if (
				!_sessionuser.hasPermission(PermissionType.Profile__insert)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permissions_to_write);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion


			Exception _exception = null;
			#region DBConnection _con = DO__Utilities.DBConnection_createInstance(...);
			DBConnection _con = DO__Utilities.DBConnection_createInstance(
				DO__Utilities.DBServerType,
				DO__Utilities.DBConnectionstring,
				DO__Utilities.DBLogfile
			);
			#endregion
			try {
				_con.Open();
				_con.Transaction.Begin();

				DO_NET_Profile__default.delRecord_all(
					_sessionuser.IDApplication,
					_con
				);
				for (int i = 0; i < idProfile_in.Length; i++) {
					//if (!DO_vNET_Profile.isObject_inRecord_all(
					//	idProfile_in[i],
					//	_sessionuser.IDApplication
					//)) {
					DO_NET_Profile__default.setObject(
						new SO_NET_Profile__default(
							idProfile_in[i]
						),
						false,

						_con
					);
					//}
				}

				#region _con.Transaction.Commit();
				if (_con.Transaction.inTransaction) {
					_con.Transaction.Commit();
				}
				#endregion
				_errorlist.Add(ErrorType.profile__successfully_updated__WARNING);
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
				OGen.NTier.Kick.Libraries.BusinessLayer.SBO_LOG_Log.log(
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
			return;
		}
		#endregion

		#region //public static void delObject(...);
		//[BOMethodAttribute("delObject", true, false, 1)]
		//public static void delObject(
		//    string sessionGuid_in,
		//    string ip_forLogPurposes_in,

		//    long[] idProfile_in,

		//    out int[] errors_out
		//) {
		//    List<int> _errorlist;
		//    Guid _sessionguid;
		//    Sessionuser _sessionuser;

		//    #region check...
		//    if (!SBO_CRD_Authentication.isSessionGuid_valid(
		//        sessionGuid_in,
		//        ip_forLogPurposes_in,
		//        out _sessionguid,
		//        out _sessionuser,
		//        out _errorlist,
		//        out errors_out
		//    )) {
		//        //// no need!
		//        //errors_out = _errors.ToArray();

		//        return;
		//    }
		//    #endregion
		//    #region check Permissions...
		//    if (
		//        !_sessionuser.hasPermission(PermissionType.Profile__delete)
		//    ) {
		//        _errorlist.Add(ErrorType.profile__lack_of_permissions_to_delete);
		//        errors_out = _errorlist.ToArray();
		//        return;
		//    }
		//    #endregion

		//    for (int i = 0; i < idProfile_in.Length; i++) {
		//        DO_NET_Profile__default.delObject_byProfile(
		//            idProfile_in[i],

		//            null
		//        );
		//    }

		//    errors_out = _errorlist.ToArray();
		//    return;
		//}
		#endregion

		#region public static SO_vNET_Profile[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true, false, 1)]
		public static SO_vNET_Profile[] getRecord_all(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			//bool allProfiles_notJustApplication_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out, 

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
			SO_vNET_Profile[] _output = null;
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
			#region check Permissions...
			if (
				!_sessionuser.hasPermission(PermissionType.Profile__select)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_vNET_Profile.getRecord_all(
					//(allProfiles_notJustApplication_in)
					//	? null
					//	: (object)_sessionuser.IDApplication,
					_sessionuser.IDApplication, 
					page_orderBy_in, 
					page_in,
					page_itemsPerPage_in,
					out page_itemsCount_out, 
					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
	}
}