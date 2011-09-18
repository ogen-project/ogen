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
	[BOClassAttribute("BO_CRD_Authentication", "")]
	public static class SBO_CRD_Authentication {

		internal static Dictionary<Guid, Sessionuser> UserSession
			= new Dictionary<Guid, Sessionuser>();
		#region public static bool isSessionGuid_valid(...);
		public static bool isSessionGuid_valid(
			string sessionGuid_in,

			out Guid sessionGuid_out,
			out List<int> errorlist_out,
			out int[] errors_out
		) {
			errorlist_out = new List<int>();

			if (!utils.Guid_TryParse(sessionGuid_in, out sessionGuid_out)) {
				errorlist_out.Add(ErrorType.authentication__invalid_guid);

				errors_out = errorlist_out.ToArray();
				return false;
			}

			errors_out = null;
			return true;
		}

		public static bool isSessionGuid_valid(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			out Guid sessionGuid_out,
			out Sessionuser sessionUser_out,
			out List<int> errorlist_out,
			out int[] errors_out
		) {
			if (!isSessionGuid_valid(
				sessionGuid_in,

				out sessionGuid_out,
				out errorlist_out,
				out errors_out
			)) {
				sessionUser_out = null;
				return false;
			}

			if (!UserSession.TryGetValue(sessionGuid_out, out sessionUser_out)) {
				SBO_LOG_Log.log(
					null,
					LogType.error,
					ErrorType.authentication__expired_guid,
					-1L,
					-1,
					"IP:{0};",
					ip_forLogPurposes_in
				);


				errorlist_out.Add(ErrorType.authentication__expired_guid);
				errors_out = errorlist_out.ToArray();
				return false;
			}

			return true;
		}
		#endregion

		#region public static void Login(...);
		#region internal static void login(long idUser_in, ...);
		internal static void login(
			long idUser_in,
			Guid sessionGuid_in, 

			string login_forLogPurposes_in,
			string ip_forLogPurposes_in, 

			bool andCheckPassword_in, 
			string password_in,

			out long idUser_out, 
			out string login_out, 
			out long[] idPermitions_out, 
			ref List<int> errorlist_ref
		) {
			login(
				DO_CRD_User.getObject(
					idUser_in
				),
				sessionGuid_in, 

				login_forLogPurposes_in, 
				ip_forLogPurposes_in, 

				andCheckPassword_in, 
				password_in,

				out idUser_out,
				out login_out, 
				out idPermitions_out, 
				ref	errorlist_ref
			);
		}
		#endregion
		#region internal static void login(SO_CRD_User user_in, ...);
		internal static void login(
			SO_CRD_User user_in,
			Guid sessionGuid_in, 

			string login_forLogPurposes_in, 
			string ip_forLogPurposes_in, 

			bool andCheckPassword_in, 
			string password_in,

			out long idUser_out,
			out  string login_out, 
			out long[] idPermitions_out, 
			ref List<int> errorlist_ref
		) {
			//// NOTES: 
			//// - this method allows login without password (if andCheckPassword_in == false), 
			//// hence MUST NEVER be distributed (at least not directly)

			idPermitions_out = null;
			idUser_out = -1L;
			login_out = "";

			if (
				(user_in != null)
				&&
				(
					!andCheckPassword_in
					||
					SimpleHash.VerifyHash(
						password_in,
						SimpleHash.HashAlgotithm.SHA256,
						user_in.Password
					)
				)
			) {
				login_out = user_in.Login;

				#region login...
				#region idPermitions_out = ...;
				SO_CRD_Permition[] _so_permitions
					= DO_CRD_Permition.getRecord_byUser(
						user_in.IDUser,
						-1,
						-1
					);

				idPermitions_out = new long[_so_permitions.Length];
				for (int i = 0; i < _so_permitions.Length; i++) {
					idPermitions_out[i] = _so_permitions[i].IDPermition;
				}
				#endregion

				if (UserSession.ContainsKey(sessionGuid_in)) {
					Sessionuser _usersession = UserSession[sessionGuid_in];
					if (_usersession.IDUser == user_in.IDUser) {
						_usersession.Sessionstart = DateTime.Now;
						_usersession.IDUser = user_in.IDUser;
						_usersession.IDPermitions = idPermitions_out;
					} else {
						errorlist_ref.Add(ErrorType.authentication__guid_not_yours);
						UserSession.Remove(sessionGuid_in);
						return;

					}
				} else {
					UserSession.Add(
						sessionGuid_in,
						new Sessionuser(
							user_in.IDUser,
							idPermitions_out,

							user_in.IFApplication,
							DateTime.Now
						)
					);
				}

				idUser_out = user_in.IDUser;
				#endregion
			} else {
				errorlist_ref.Add(ErrorType.authentication__invalid_login);
				#region SBO_LOG_Log.log(...);
				SBO_LOG_Log.log(
					null,
					LogType.error, 
					ErrorType.authentication,
					-1L,
					(user_in == null) ? -1 : user_in.IFApplication,
					"IDUser:{0};password:{1}**********;whoAmI:{2};",
					new string[] { 
						login_forLogPurposes_in, // user_in.IDUser.ToString(), 
						password_in.Length > 0 ? password_in.Substring(0, 1) : "", 
						ip_forLogPurposes_in
					}
				);
				#endregion
			}
		}
		#endregion

		[BOMethodAttribute("Login", true, false, 3)]
		public static void Login(
			string login_in,
			string password_in,
			string sessionGuid_in,

			string ip_forLogPurposes_in, 

			int idApplication_in,

			out long idUser_out,
			out long[] idPermitions_out, 
			out int[] errors_out
		) {
			idPermitions_out = null;
			idUser_out = -1L;
			Guid _sessionguid;

			List<int> _errorlist;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in, 
				out _sessionguid,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}

			if (login_in.Trim() == string.Empty) {
				_errorlist.Add(ErrorType.authentication__invalid_login);

				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			string _login;
			login(
				DO_CRD_User.getObject_byLogin(
					login_in,
					idApplication_in
				),
				_sessionguid, 
 
				login_in, 
				ip_forLogPurposes_in, 

				true, 
				password_in,

				out idUser_out,
				out _login, 
				out idPermitions_out, 
				ref _errorlist
			);

			errors_out = _errorlist.ToArray();
		}
		#endregion
		#region public static void ChangePassword(...);
		[BOMethodAttribute("ChangePassword", true, false, 1)]
		public static void ChangePassword(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			string password_old_in,
			string password_new_in,

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

			SO_CRD_User _user = DO_CRD_User.getObject(_sessionuser.IDUser);
			if (_user == null) {
				_errorlist.Add(ErrorType.authentication__no_such_user);
				UserSession.Remove(_sessionguid);

				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			bool _constraint;
			if (
				!SimpleHash.VerifyHash(
					password_old_in,
					SimpleHash.HashAlgotithm.SHA256,
					_user.Password
				)
			) {
				_errorlist.Add(ErrorType.authentication__change_password__wrong_password);
			} else if (password_new_in.Trim() == "") {
				_errorlist.Add(ErrorType.authentication__change_password__invalid_password);
			} else {
				_user.Password
					= SimpleHash.ComputeHash(
						password_new_in,
						SimpleHash.HashAlgotithm.SHA256,
						null
					);

				DO_CRD_User.updObject(
					_user,
					true,
					out _constraint
				);
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion
	}
}