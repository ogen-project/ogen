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
	[BOClassAttribute("BO_CRD_User", "")]
	public static class SBO_CRD_User {

		// ToDos: here! this method could be shared!
		#region public static bool checkLogin(string login_in, List<int> errors_in);
		public static bool checkLogin(
			string login_in,
			ref List<int> errors_in
		) {
			if ((login_in = login_in.Trim()).Length < 3) {
				errors_in.Add(ErrorType.user__invalid_login);
				return false;
			}

			return true;
		}
		#endregion

		#region public static void insObject_CreateUser(string credentials_in, string login_in, ...);
		#region internal static long insObject_CreateUser(ServerCredentials credentials_in, string login_in, ...);
		internal static long insObject_CreateUser(
			utils.Sessionuser sessionUser_in,

			string login_in,
			int idApplication_in,

			bool selectIdentity_in, 
			ref List<int> errorlist_in, 

			DBConnection con_in
		) {
			long _output = -1L;

			// ToDos: here! must have permition to create user
			if (!sessionUser_in.hasPermition(
				PermitionType.User__insert
			)) {
				errorlist_in.Add(ErrorType.user__lack_of_permitions_to_write);
				return _output;
			}

			if (!checkLogin(login_in, ref errorlist_in)) {
				return _output;
			}

			bool _constraint;
			_output = DO_CRD_User.insObject(
				new SO_CRD_User(
					-1L,
					login_in,

// ToDos: here! encrypt before sending...
					login_in, // default: password = login

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

		[BOMethodAttribute("insObject_CreateUser", true, false, 1)]
		public static void insObject_CreateUser(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			string login_in,
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

			// must have permition to create user
			// ...
			// password = login

			insObject_CreateUser(
				_sessionuser,

				login_in,

				idApplication_in,

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

			if (!checkLogin(login_in, ref errorlist_in)) {
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

		[BOMethodAttribute("insObject_Registration", true)]
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