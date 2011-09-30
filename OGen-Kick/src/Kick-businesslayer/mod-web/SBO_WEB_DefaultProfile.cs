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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__insert)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_write);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			for (int i = 0; i < idProfile_in.Length; i++) {
				if (!DO_vNET_Profile.isObject_inRecord_all(
					idProfile_in[i],
					_sessionuser.IDApplication
				)) {
					DO_NET_Defaultprofile.insObject(
						new SO_NET_Defaultprofile(
							-1L,
							idProfile_in[i]
						),
						false,

						null
					);
				}
			}
		}
		#endregion

		#region public static void delObject(...);
		[BOMethodAttribute("delObject", true, false, 1)]
		public static void delObject(
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__delete)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_delete);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			for (int i = 0; i < idProfile_in.Length; i++) {
				DO_NET_Defaultprofile.delObject_byProfile(
					idProfile_in[i],

					null
				);
			}
		}
		#endregion

		#region public static SO_vNET_Profile[] getRecord_all(...);
		[BOMethodAttribute("getRecord_all", true, false, 1)]
		public static SO_vNET_Profile[] getRecord_all(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			//bool allProfiles_notJustApplication_in,

			int page_in,
			int page_numRecords_in,

			out int[] errors_out
		) {
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
			#region check Permitions...
			if (
				!_sessionuser.hasPermition(PermitionType.Profile__select)
			) {
				_errorlist.Add(ErrorType.profile__lack_of_permitions_to_read);
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