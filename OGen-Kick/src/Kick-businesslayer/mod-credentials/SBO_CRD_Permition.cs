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
using System.Configuration;
using System.Collections.Generic;
using System.Text;

using OGen.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.lib.crypt;

using OGen.NTier.Kick.lib.datalayer;
using OGen.NTier.Kick.lib.datalayer.shared;
using OGen.NTier.Kick.lib.datalayer.shared.structures;

using OGen.NTier.Kick.lib.businesslayer.shared;
//using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	[BOClassAttribute("BO_CRD_Permition", "")]
	public static class SBO_CRD_Permition {

		#region public static SO_CRD_Permition[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true)]
		public static SO_CRD_Permition[] getRecord_all(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			int idApplication_in,
			bool idApplication_isNull_in,
			
			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_CRD_Permition[] _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			utils.Sessionuser _sessionuser;

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
				!_sessionuser.hasPermition(PermitionType.Permition__select)
			) {
				_errorlist.Add(ErrorType.permition__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_CRD_Permition.getRecord_all(
					idApplication_isNull_in 
						? null 
						: (object)idApplication_in, 
					page_in,
					page_numRecords_in,
					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static void setProfilePermitions(...);
		[BOMethodAttribute("setProfilePermitions", true)]
		public static void setProfilePermitions(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idProfile_in,
			long[] idPermitions_in,

			int idApplication_in,

			out int[] errors_out
		) {
			List<int> _errorlist;
			Guid _sessionguid;
			utils.Sessionuser _sessionuser;

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
			#region check permitions . . .
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__insert)
				&&
				!_sessionuser.hasPermition(PermitionType.Profile__update)
			) {
				_errorlist.Add(ErrorType.lack_of_permitions);
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

				DO_CRD_ProfilePermition.delRecord_byProfile(
					idProfile_in,

					_con
				);
				foreach (long _idpermition in idPermitions_in) {
					DO_CRD_ProfilePermition.setObject(
						new SO_CRD_ProfilePermition(
							idProfile_in,
							_idpermition
						),
						true,

						_con
					);
				}

				_errorlist.Add(ErrorType.profile_permition__successfully_set__WARNING);
				_con.Transaction.Commit();
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

		#region public static SO_vCRD_ProfilePermition[] getRecord_ofProfilePermition_byProfile(...);
		[BOMethodAttribute("getRecord_ofProfilePermition_byProfile", true)]
		public static SO_vCRD_ProfilePermition[] getRecord_ofProfilePermition_byProfile(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long IDProfile_search_in,
			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
			SO_vCRD_ProfilePermition[] _output = null;
			List<int> _errorlist;
			Guid _sessionguid;
			utils.Sessionuser _sessionuser;

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
			#region check Admin . . .
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__select)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_read);
				errors_out = _errorlist.ToArray();
				return _output;
			}
			#endregion

			_output
				= DO_vCRD_ProfilePermition.getRecord_byProfile(
					IDProfile_search_in,
					page_in,
					page_numRecords_in
				);

			errors_out = _errorlist.ToArray();
			return _output;
		} 
		#endregion
	}
}