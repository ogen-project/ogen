﻿#region Copyright (C) 2002 Francisco Monteiro
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

	[BOClassAttribute("BO_CRD_User", "")]
	public static class SBO_CRD_User {
		#region public static void insObject_CreateUser(string credentials_in, string login_in, ...);
		#region internal static long insObject_CreateUser(ServerCredentials credentials_in, string login_in, ...);
		internal static long insObject_CreateUser(
			Sessionuser sessionUser_in,

			string login_in,

			bool selectIdentity_in, 
			ref List<int> errorlist_in, 

			DBConnection con_in
		) {
			long _output = -1L;

			// ToDos: here! must have permission to create user
			if (!sessionUser_in.hasPermission(
				PermissionType.User__insert
			)) {
				errorlist_in.Add(ErrorType.user__lack_of_permissions_to_write);
				return _output;
			}

			if (!Sessionuser.checkLogin(login_in, ref errorlist_in)) {
				return _output;
			}

			bool _constraint;
			_output = DO_CRD_User.insObject(
				new SO_CRD_User(
					-1L,
					login_in,

// ToDos: here! encrypt before sending...
					login_in, // default: password = login

					sessionUser_in.IDApplication
				),

				selectIdentity_in,
				out _constraint, 

				con_in
			);

			if (_constraint) {
				errorlist_in.Add(ErrorType.data__constraint_violation);
			} else {
				if (con_in == null) {
					// assuming NO other (internal) operations are going on
					errorlist_in.Add(ErrorType.user__successfully_created__WARNING);
				}
			}

			return _output;
		}
		#endregion

		[BOMethodAttribute("insObject_CreateUser", true, false, 1)]
		public static void insObject_CreateUser(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			string login_in,

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

			// must have permission to create user
			// ...
			// password = login

			insObject_CreateUser(
				_sessionuser,

				login_in,

				false, 
				ref _errorlist, 

				null
			);

			errors_out = _errorlist.ToArray();
		}
		#endregion
		#region public static void insObject_Registration(string login_in, string password_in, ...);
		#region internal static long insObject_Registration(string login_in, string password_in, ...);
		internal static long insObject_Registration(
			string login_in,
			string password_in,
			int idApplication_in,

			bool selectIdentity_in, 
			ref List<int> errorlist_in,
			DBConnection con_in
		) {
			long _output = -1L;

			// user registering
			// 

			if (!Sessionuser.checkLogin(login_in, ref errorlist_in)) {
				return _output;
			}

			bool _constraint;
			_output = DO_CRD_User.insObject(
				new SO_CRD_User(
					-1L,
					login_in,

// ToDos: here! encrypt before sending...
password_in,

					idApplication_in
				),

				selectIdentity_in,
				out _constraint, 

				con_in
			);
			if (_constraint) {
				errorlist_in.Add(ErrorType.data__constraint_violation);
			} else {
				if (con_in == null) {
					// assuming NO other (internal) operations are going on
					errorlist_in.Add(ErrorType.user__successfully_created__WARNING);
				}
			}

			return _output;
		}
		#endregion

		[BOMethodAttribute("insObject_Registration", true, false, -1)]
		public static void insObject_Registration(
			string login_in, 
			string password_in, 
			int idApplication_in, 

			out int[] errors_out
		) {
			List<int> _errorlist = new List<int>();

			// user registering
			// 

			insObject_Registration(
				login_in,
				password_in,
				idApplication_in, 

				false, 
				ref _errorlist,
				null
			);

			errors_out = _errorlist.ToArray();
		}
		#endregion
	}
}