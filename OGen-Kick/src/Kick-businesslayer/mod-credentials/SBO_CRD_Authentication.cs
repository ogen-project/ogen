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
		public static string Login(
			string login_in,
			string password_in,

			int idApplication_in,

			out long idUser_out,
			out int[] errors_out
		) {
			throw new NotImplementedException();
		}
		public static bool CheckCredentials(
			string credentials_in
		) {
			throw new NotImplementedException();
		}
		//#region public static bool CheckCredentials(...);
		//[BOMethodAttribute("CheckCredentials", true)]
		//public static bool CheckCredentials(
		//    string credentials_in
		//) {
		//    List<int> _errors;

		//    ServerCredentials _credentials = new ServerCredentials(
		//        credentials_in,
		//        out _errors
		//    );

		//    return (_errors.Count == 0);
		//}
		//#endregion


		public class Usersession {
			public Usersession(
				DateTime sessionstart_in, 
				long idUser_in, 
				long[] idPermitions_in
			) {
				Sessionstart = sessionstart_in;
				IDUser = idUser_in;
				IDPermitions = idPermitions_in;
			}

			public DateTime Sessionstart;
			public long IDUser;
			public long[] IDPermitions;
		}
		internal static Dictionary<Guid, Usersession> UserSession
			= new Dictionary<Guid, Usersession>();

		#region public static void Login(...);
		#region internal static void login(long idUser_in, ...);
		internal static void login(
			long idUser_in,
			Guid sessionGuid_in, 

			string login_forLogPurposes_in,
			string whoAmI_forLogPurposes_in, 

			bool andCheckPassword_in, 
			string password_in,

			int idApplication_in,

			out long idUser_out, 
			out string login_out, 
			out long[] idPermitions_out, 
			ref List<int> errors_ref
		) {
			login(
				DO_CRD_User.getObject(
					idUser_in
				),
				sessionGuid_in, 

				login_forLogPurposes_in, 
				whoAmI_forLogPurposes_in, 

				andCheckPassword_in, 
				password_in,

				idApplication_in,

				out idUser_out,
				out login_out, 
				out idPermitions_out, 
				ref	errors_ref
			);
		}
		#endregion
		#region internal static void login(SO_CRD_User user_in, ...);
		internal static void login(
			SO_CRD_User user_in,
			Guid sessionGuid_in, 

			string login_forLogPurposes_in, 
			string whoAmI_forLogPurposes_in, 

			bool andCheckPassword_in, 
			string password_in,

			int idApplication_in,

			out long idUser_out,
			out  string login_out, 
			out long[] idPermitions_out, 
			ref List<int> errors_ref
		) {
			//// NOTES: 
			//// - this method allows login without password (if andCheckPassword_in == false), 
			//// hence MUST NEVER be distributed (at least not directly)

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
					Usersession _usersession = UserSession[sessionGuid_in];
					if (_usersession.IDUser == user_in.IDUser) {
						_usersession.Sessionstart = DateTime.Now;
						_usersession.IDUser = user_in.IDUser;
						_usersession.IDPermitions = idPermitions_out;
					} else {
						errors_ref.Add(ErrorType.authentication__guid_not_yours);
						UserSession.Remove(sessionGuid_in);
						return;

					}
				} else {
					UserSession.Add(
						sessionGuid_in,
						new Usersession(
							DateTime.Now,
							user_in.IDUser, 
							idPermitions_out
						)
					);
				}

				idUser_out = user_in.IDUser;
				#endregion
			} else {
				idPermitions_out = new long[] { };

				errors_ref.Add(ErrorType.authentication__invalid_login);
				#region SBO_LOG_Log.Log(...);
				SBO_LOG_Log.Log(
					null,
					LogType.error,
					ErrorType.authentication,
					idApplication_in,
					"IDUser:{0};password:{1}**********;whoAmI:{2};",
					new string[] { 
						login_forLogPurposes_in, // user_in.IDUser.ToString(), 
						password_in.Length > 0 ? password_in.Substring(0, 1) : "", 
						whoAmI_forLogPurposes_in
					}
				);
				#endregion
			}
		}
		#endregion

		[BOMethodAttribute("Login", true)]
		public static void Login(
			string login_in,
			string password_in,
			string sessionGuid_in,

			string whoAmI_forLogPurposes_in, 

			int idApplication_in,

			out long idUser_out,
			out long[] idPermitions_out, 
			out int[] errors_out
		) {
			idUser_out = -1L;
			Guid _guid;

			List<int> _errors = new List<int>();
			#region check...
			if (login_in.Trim() == string.Empty) {
				_errors.Add(ErrorType.authentication__invalid_login);

				idPermitions_out = new long[] { };
				errors_out = _errors.ToArray();
				return;
			}

			if (!utils.Guid_TryParse(sessionGuid_in, out _guid)) {
				_errors.Add(ErrorType.authentication__invalid_guid);

				idPermitions_out = new long[] { };
				errors_out = _errors.ToArray();
				return;
			}
			#endregion

			string _login;
			login(
				DO_CRD_User.getObject_byLogin(
					login_in,
					idApplication_in
				),
				_guid, 
 
				login_in, 
				whoAmI_forLogPurposes_in, 

				true, 
				password_in,

				idApplication_in,

				out idUser_out,
				out _login, 
				out idPermitions_out, 
				ref _errors
			);

			errors_out = _errors.ToArray();
		}
		#endregion
		#region public static void ChangePassword(...);
		[BOMethodAttribute("ChangePassword", true)]
		public static void ChangePassword(
			string sessionGuid_in,

			string password_old_in,
			string password_new_in,

			out int[] errors_out
		) {
			List<int> _errors = new List<int>();

			Guid _sessionguid;
			Usersession _sessionuser;
			SO_CRD_User _user;
			#region check...
			if (!utils.Guid_TryParse(sessionGuid_in, out _sessionguid)) {
				_errors.Add(ErrorType.authentication__invalid_guid);

				errors_out = _errors.ToArray();
				return;
			} else if (!UserSession.ContainsKey(_sessionguid)) {
				_errors.Add(ErrorType.authentication__expired_guid);

				errors_out = _errors.ToArray();
				return;
			}

			_sessionuser = UserSession[_sessionguid];

			_user = DO_CRD_User.getObject(
				_sessionuser.IDUser
			);
			if (_user == null) {
				_errors.Add(ErrorType.authentication__no_such_user);
				UserSession.Remove(_sessionguid);

				errors_out = _errors.ToArray();
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
				_errors.Add(ErrorType.authentication__change_password__wrong_password);
			} else if (
				password_new_in.Trim() == ""
			) {
				_errors.Add(ErrorType.authentication__change_password__invalid_password);
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

			errors_out = _errors.ToArray();
		}
		#endregion
	}
}