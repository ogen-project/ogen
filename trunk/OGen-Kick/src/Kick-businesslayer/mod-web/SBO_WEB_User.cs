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

	[BOClassAttribute("BO_WEB_User", "")]
	public static class SBO_WEB_User {
		#region public static void Login(...);
		[BOMethodAttribute("Login", true, false, 3)]
		public static void Login(
			string email_in,
			string password_in,
			string sessionGuid_in,

			string ip_forLogPurposes_in, 

			int idApplication_in,

			out long idUser_out,
			out string login_out, 
			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			idPermissions_out = null;
			idUser_out = -1L;
			login_out = "";
			Guid _guid;

			List<int> _errors = new List<int>();
			#region check...
			if (!OGen.Libraries.Mail.Utilities.isEmail_valid(email_in)) {
				_errors.Add(ErrorType.authentication__invalid_email);

				errors_out = _errors.ToArray();
				return;
			}

			if (!Sessionuser.Guid_TryParse(sessionGuid_in, out _guid)) {
				_errors.Add(ErrorType.authentication__invalid_guid);

				errors_out = _errors.ToArray();
				return;
			}
			#endregion

			SO_NET_User _user;
			if (
				((_user = DO_NET_User.getObject_byEmail(
					email_in,
					idApplication_in
				)) != null)
			) {
				SBO_CRD_Authentication.login(
					_user.IFUser, 
					_guid,

					email_in, 
					ip_forLogPurposes_in, 

					true, 
					password_in, 

					out idUser_out,
					out login_out, 
					out idPermissions_out, 
					ref _errors
				);
			} else {
				_errors.Add(ErrorType.authentication__invalid_login);
				#region //SBO_LOG_Log.log(...);
				//SBO_LOG_Log.log(
				//    null,
				//    LogType.error,
				//    ErrorType.authentication, 
				//    -1L, 
				//    idApplication_in,
				//    "Email:{0};password:{1}**********;whoAmI:{2};",
				//    new string[] { 
				//        email_in, 
				//        password_in.Length > 0 ? password_in.Substring(0, 1) : "", 
				//        ip_forLogPurposes_in
				//    }
				//);
				#endregion
			}

			errors_out = _errors.ToArray();
		}
		#endregion

		#region public static void updObject_Email(...);
		[BOMethodAttribute("updObject_Email", true, false, 1)]
		public static void updObject_Email(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			string Email_verify_in,

			string companyName_in,
			string verifyMailURL_in,

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

			if (
				!OGen.Libraries.Mail.Utilities.isEmail_valid(Email_verify_in = Email_verify_in.Trim())
			) {
				_errorlist.Add(ErrorType.web__user__invalid_email);
				errors_out = _errorlist.ToArray();
				return;
			}

			if (
				DO_NET_User.isObject_byEmail(
					Email_verify_in,
					_sessionuser.IDApplication
				)
			) {
				_errorlist.Add(ErrorType.data__constraint_violation);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			#region string _message = ...;
			string _message = encrypt_mail(
				_sessionuser.IDApplication,
				_errorlist, 

				Email_verify_in, 
				"1" // Verify Email
			);
			if (string.IsNullOrEmpty(_message)) {
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
				//_con.Open();
				//_con.Transaction.Begin(); 

				//// NOTE: NO NEED TO USE TRANSACTION here, mail sending can delay and lock db table, 
				//// BESIDES, it's NO PROBLEM if db gets changed and no mail is sent, 
				//// the logic allows that (check db model graph).
				//// AND MORE, user is informed there was an error, he'll just repeat mail update

				SO_NET_User _user
					= DO_NET_User.getObject(
						_sessionuser.IDUser,

						_con
					);

				bool _constraintExist;
				_user.Email_verify = Email_verify_in;
				DO_NET_User.setObject(
					_user,
					false,
					out _constraintExist,

					_con
				);
				if (!_constraintExist) {
					#region MyMail.Send(Email_verify_in, ...);
					try {
						OGen.Libraries.Mail.Utilities.MailSend(
							new System.Net.Mail.MailAddress[] {
								new System.Net.Mail.MailAddress(
									Email_verify_in, 
									_user.Name
								)
							},
							null,
							null,
							"Confirmação da Alteração de Contacto",
							string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								@"
Para associar à sua conta o novo contacto de email, por favor, clique no link que se segue:

{0}{1}

Atentamente,
 
A equipa {2}

",
								//System.Configuration.ConfigurationSettings.AppSettings["URL__base"],
								verifyMailURL_in,
								_message,
								companyName_in
							)
						);
					} catch (Exception _ex) {
						_exception = _ex;
					}
					#endregion
					if (_exception == null) {
						_errorlist.Add(ErrorType.web__user__updating_email__WARNING);
					} else {
						_errorlist.Add(ErrorType.web__user__can_not_send_mail);
					}
				} else {
					_errorlist.Add(ErrorType.data__constraint_violation);
				}

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
		}
		#endregion

		#region public static SO_vNET_User[] getRecord_generic(...);
		[BOMethodAttribute("getRecord_generic", true, false, 1)]
		public static SO_vNET_User[] getRecord_generic(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			string login_in, 
			string email_in, 
			string name_in, 
			long idProfile__in_in, 
			long idProfile__out_in,

			int page_orderBy_in,
			long page_in,
			int page_itemsPerPage_in,
			out long page_itemsCount_out,

			out int[] errors_out
		) {
			page_itemsCount_out = -1L;
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

				return null;
			}
			#endregion
			#region check Permissions . . .
			if (
				!_sessionuser.hasPermission(
					PermissionType.User__select
				)
			) {
				_errorlist.Add(ErrorType.user__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return null;
			}
			#endregion

			SO_vNET_User[] _output
				= DO_vNET_User.getRecord_generic(
					login_in, 
					name_in, 
					email_in,
					_sessionuser.IDApplication, 
					idProfile__in_in, 
					idProfile__out_in,

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

		#region public static SO_vNET_User getObject_details(...);
		[BOMethodAttribute("getObject_details", true, false, 1)]
		public static SO_vNET_User getObject_details(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idUser_in,

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

				return null;
			}
			#endregion
			#region check Permissions...
			if (
				(_sessionuser.IDUser != idUser_in)
				&&
				!_sessionuser.hasPermission(
					PermissionType.User__select
				)
			) {
				_errorlist.Add(ErrorType.user__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return null;
			}
			#endregion

			SO_vNET_User _output
				= DO_vNET_User.getObject_byUser(
					idUser_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion

		#region public static SO_NET_User getObject(...);
		[BOMethodAttribute("getObject", true, false, 1)]
		public static SO_NET_User getObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idUser_in,

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

				return null;
			}
			#endregion
			#region check Permissions . . .
			if (
				(_sessionuser.IDUser != idUser_in)
				&&
				!_sessionuser.hasPermission(
					PermissionType.User__select
				)
			) {
				_errorlist.Add(ErrorType.user__lack_of_permissions_to_read);
				errors_out = _errorlist.ToArray();
				return null;
			}
			#endregion

			SO_NET_User _output
				= DO_NET_User.getObject(
					idUser_in,

					null
				);

			errors_out = _errorlist.ToArray();
			return _output;
		}
		#endregion
		#region public static void setObject(...);
		[BOMethodAttribute("setObject", true, false, 1)]
		public static void setObject(
			string sessionGuid_in,
			string ip_forLogPurposes_in, 

			long idUser_in,

			bool updateName_in, 
			string name_in,

			//// add any other needed fields
			// updateWHATEVER_in, 
			// whatever_in

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
			#region ckeck Fields . . .
			if (
				updateName_in
				&&
				((name_in 
					= name_in.Trim()
				).Length == 0)
			) {
				_errorlist.Add(ErrorType.web__user__invalid_name);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion
			#region check Permissions . . .
			if (_sessionuser.IDUser != idUser_in) {
				_errorlist.Add(ErrorType.user__lack_of_permissions_to_write);
				errors_out = _errorlist.ToArray();
				return;
			}

			//bool _forum__forum__select 
			//    = _credentials.hasPermission(
			//        PermissionType.Forum__Forum__read
			//    );
			//bool _forum__thread__select
			//    = _credentials.hasPermission(
			//        PermissionType.Forum__Thread__read
			//    );
			//bool _forum__reply__select
			//    = _credentials.hasPermission(
			//        PermissionType.Forum__Reply__read
			//    );

			//if (
			//    !(
			//        _forum__forum__select 
			//        ||
			//        _forum__thread__select
			//        ||
			//        _forum__reply__select
			//    )
			//) {
			//    _errors.Add(ErrorType.forum__lack_of_permissions_to_read);
			//    errors_out = _errors.ToArray();
			//    return null;
			//}
			#endregion
			#region check Existence . . . SO_NET_User _user = ...;
			SO_NET_User _user;
			if (
				(_user
					= DO_NET_User.getObject(
						idUser_in
					)
				) == null
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion


			if (updateName_in) { _user.Name = name_in; }


			bool _constraint;
			DO_NET_User.setObject(
				_user, 
				false, 
				out _constraint, 

				null
			);
			if (_constraint) {
				_errorlist.Add(ErrorType.data__constraint_violation);
			} else {
				_errorlist.Add(ErrorType.web__user__successfully_updated__WARNING);
			}

			errors_out = _errorlist.ToArray();
			return;
		}
		#endregion

		////public void updPassword_checkMail(
		//// VERIFICAR QUE O MAIL EXISTE
		//public void updPassword_checkMail(
		//    string credentials_in,

		//    string email_check_in,
		//    string Password_new_in,

		//    out int[] errors_out
		//) {
		//    if (IDUser_loggedIn <= 0) {
		//        throw BusinessExceptions.NoPermissionException;
		//    }

		//    string _email 
		//        = OGen.Libraries.Crypt.Utilities.Server.RSA_Server_private_Decrypt64(
		//            email_check_in
		//        );
		//    if (
		//        mainAggregate.getObject_byEmail(_email)
		//        &&
		//        (mainAggregate.Fields.IDUser == IDUser_loggedIn)
		//    ) {
		//        bool _constraint;

		//        mainAggregate.Fields.Password = SimpleHash.ComputeHash(
		//            Password_new_in,
		//            SimpleHash.HashAlgotithm.SHA256,
		//            null // random salt generated in place
		//        );
		//        mainAggregate.updObject(false, out _constraint);

		//        error_out = updPassword_checkMail_Error.noError;
		//    } else {
		//        error_out = updPassword_checkMail_Error.invalidMail;
		//        mainAggregate.clrObject();
		//    }

		//}

		#region internal static void login_throughlink(...);
		internal static void login_throughlink(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			string email_verify_in, 
			int idApplication_in, 

//			bool andVerifyEmail_in, 
			bool andChangePassword_in, 
			string password_in, 

			out long idUser_out, 
			out string login_out,
			out string name_out,

			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			// this method will eventually be fallowed by any of the fallowing:
			// - insObject_Registration (WILL change password AND verify email)
			// - updObject_Email (will NOT change password AND verify email)
			// - LostPassword_Recover (WILL change password and NOT verify email)

			idPermissions_out = null;
			idUser_out = -1L;
			login_out = "";
			name_out = "";
			Exception _exception;
			Guid _guid;

			List<int> _errorlist;
			#region check...
			if (!SBO_CRD_Authentication.isSessionGuid_valid(
				sessionGuid_in,
				out _guid,
				out _errorlist,
				out errors_out
			)) {
				//// no need!
				//errors_out = _errors.ToArray();

				return;
			}
			#endregion

			#region string _email_verify = ...; bool _andVerifyEmail = ...;
			string[] _params = decrypt_mail(
				email_verify_in,
				_errorlist
			);
			if (
				(_params == null)
				||
				(_params.Length == 0)
			) {
				errors_out = _errorlist.ToArray();
				return;
			}

			string _email_verify = _params[0];
			bool _andVerifyEmail = (
				(_params.Length > 1) 
				&& 
				(_params[1] == "1")
			);
			#endregion
			if (!andChangePassword_in && !_andVerifyEmail) {
#if DEBUG
				throw new Exception("(nothing to do) what are you doing?");
#else
				_errorlist.Add(ErrorType.business__this_should_never_happen);
#endif
			}

			bool _constraint;
			SO_NET_User _user = null;
			if (
				(_user
					= (_andVerifyEmail) 
						? DO_NET_User.getObject_byEmail_verify(
							_email_verify,
							idApplication_in, 
							null
						)
						: DO_NET_User.getObject_byEmail(
							_email_verify,
							idApplication_in,
							null
						)
				) == null
			) {
				_errorlist.Add(ErrorType.data__not_found);
				errors_out = _errorlist.ToArray();
				return;
			} else {
				bool _commit = false;

				#region DBConnection _con = DO__Utilities.DBConnection_createInstance(...);
				DBConnection _con = DO__Utilities.DBConnection_createInstance(
					DO__Utilities.DBServerType,
					DO__Utilities.DBConnectionstring,
					DO__Utilities.DBLogfile
				); 
				#endregion
				_exception = null;
				try {

					if (andChangePassword_in && _andVerifyEmail) {
						_con.Open();
						_con.Transaction.Begin();
					}

					if (andChangePassword_in) {
						#region DO_CRD_User.updObject(...);
						SO_CRD_User _crd_user 
							= DO_CRD_User.getObject(
								_user.IFUser, 
								_con
							);
						_crd_user.Password
							= SimpleHash.ComputeHash(
								password_in,
								SimpleHash.HashAlgotithm.SHA256,
								null
							);

						DO_CRD_User.updObject(
							_crd_user,
							false,
							out _constraint, // no constraint from changing password, hence not used...
							_con
						);
						#endregion
					}
					if (_andVerifyEmail) {
						#region DO_NET_User.setObject(...); _commit = ...;
						_user.Email = _user.Email_verify;
						_user.Email_verify_isNull = true;
						DO_NET_User.setObject(
							_user,
							true,
							out _constraint,
							_con
						);
						if (!_constraint) {
							_commit = true;
						} else {
							_errorlist.Add(ErrorType.data__constraint_violation);

							_commit = false;
						}
						#endregion
					} else {
						_commit = true;
					}

					if (_commit) {
						#region _con.Transaction.Commit();
						if (
							_con.isOpen
							&&
							_con.Transaction.inTransaction
						) {
							_con.Transaction.Commit();
						}
						#endregion
					} else {
						#region _con.Transaction.Rollback();
						if (
							_con.isOpen
							&&
							_con.Transaction.inTransaction
						) {
							_con.Transaction.Rollback();
						}
						#endregion
					}
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
						null,
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

				if (_commit) {
					#region SO_CRD_User _crd_user = ...;
					SO_CRD_User
						_crd_user = DO_CRD_User.getObject(
							_user.IFUser
						); 
					#endregion

					#region SBO_CRD_Authentication.login(..., out idUser_out, ...);
					SBO_CRD_Authentication.login(
						_crd_user,
						_guid, 
						_crd_user.Login,

						ip_forLogPurposes_in, 

						false,
						"",

						out idUser_out,
						out login_out,
						out idPermissions_out, 
						ref _errorlist
					);
					#endregion
					//login_out = _crd_user.Login;
					name_out = _user.Name;

					//_errors.Add(ErrorType.web__user__successfully_updated__WARNING);
				} else {
					idUser_out = -1L;
					login_out = "";
					name_out = "";
				}
			}

			errors_out = _errorlist.ToArray();
		}
		#endregion

		#region public static void Login_throughLink(...);
		[BOMethodAttribute("Login_throughLink", true, false, 1)]
		public static void Login_throughLink(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			string email_verify_in,
			int idApplication_in,

			out long idUser_out,
			out string login_out,
			out string name_out,

			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			login_throughlink(
				sessionGuid_in,
				ip_forLogPurposes_in,

				email_verify_in,
				idApplication_in,
				false,
				"",

				out idUser_out, 
				out login_out,
				out name_out, 

				out idPermissions_out, 
				out errors_out
			);
		}
		#endregion
		#region public static void Login_throughLink_andChangePassword(...);
		[BOMethodAttribute("Login_throughLink_andChangePassword", true, false, 1)]
		public static void Login_throughLink_andChangePassword(
			string sessionGuid_in,
			string ip_forLogPurposes_in,

			string email_verify_in,
			int idApplication_in,
			string password_in,

			out long idUser_out,
			out string login_out,
			out string name_out,

			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			login_throughlink(
				sessionGuid_in,
				ip_forLogPurposes_in,

				email_verify_in,
				idApplication_in,
				true,
				password_in,

				out idUser_out, 
				out login_out,
				out name_out,

				out idPermissions_out,
				out errors_out
			);
		}
		#endregion

		////public static int Login(
		////    string email_in,
		////    string password_in
		////) {
		////    int _iduser_out = -1;

		////    DO_TML_GC_User _user = new DO_TML_GC_User();
		////    if (
		////        _user.getObject_byEmail(
		////            email_in
		////        )
		////        && 
		////        SimpleHash.VerifyHash(
		////            password_in,
		////            SimpleHash.HashAlgotithm.SHA256,
		////            _user.Fields.Password
		////        )
		////    ) {
		////        _iduser_out = _user.Fields.IDUser;
		////    }
		////    _user.Dispose(); _user = null;
			
		////    return _iduser_out;
		////}

		////public static int LoginXPTO(
		////    string email_in
		////) {
		////    int _iduser_out = -1;
		////    string _email
		////        = OGen.Libraries.Crypt.Utilities.Server.RSA_Server_private_Decrypt64(
		////            email_in
		////        );


		////    DO_TML_GC_User _user = new DO_TML_GC_User();
		////    if (_user.getObject_byEmail(
		////        _email
		////    )) {
		////        _iduser_out = _user.Fields.IDUser;
		////    }

		////    return _iduser_out;
		////}
		////#endregion

		#region public static void LostPassword_Recover(...);
		[BOMethodAttribute("LostPassword_Recover", true, false, -1)]
		public static void LostPassword_Recover(
			//string credentials_in,

			string Email_in,

			string companyName_in,
			string recoverLostPasswordURL_in,

			int idApplication_in,

			out int[] errors_out
		) {
			List<int> _errors = new List<int>();
			#region check . . .
			if (!OGen.Libraries.Mail.Utilities.isEmail_valid(Email_in = Email_in.Trim())) {
				_errors.Add(ErrorType.web__user__invalid_email);
				errors_out = _errors.ToArray();
				return;
			}
			#endregion
			#region check Existence . . . SO_NET_User _user = ...;
			SO_NET_User _user;
			if (
				((_user = DO_NET_User.getObject_byEmail(
					Email_in,
					idApplication_in
				)) == null)
			) {
				_errors.Add(ErrorType.data__not_found);
				errors_out = _errors.ToArray();
				return;
			}
			#endregion

			#region string _message = ...;
			string _message = encrypt_mail(
				idApplication_in,
				_errors, 

				_user.Email,
				"0" // NOT Verify Email
			);
			if (string.IsNullOrEmpty(_message)) {
				errors_out = _errors.ToArray();
				return;
			}
			#endregion

			try {
				#region OGen.Libraries.Mail.Utilities.MailSend(...);
				OGen.Libraries.Mail.Utilities.MailSend(
					new System.Net.Mail.MailAddress[] {
						new System.Net.Mail.MailAddress(
							_user.Email, 
							_user.Name
						)
					},
					null,
					null,
					"Recuperar Registo",
					string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						@"
Para recuperar o seu registo, por favor, clique no link que se segue:

{0}{1}

Atentamente,
 
A equipa {2}",
						//System.Configuration.ConfigurationSettings.AppSettings["URL__base"],
						recoverLostPasswordURL_in,
						_message,
						companyName_in
					)
				);
				#endregion
			} catch (Exception _ex) {
				#region SBO_LOG_Log.log(ErrorType.data);
				OGen.NTier.Kick.Libraries.BusinessLayer.SBO_LOG_Log.log(
					null, 
					LogType.error,
					ErrorType.web__user__can_not_send_mail,
					-1L, 
					idApplication_in,
					"{0}",
					new string[] {
						_ex.Message
					}
				);
				#endregion
				_errors.Add(ErrorType.web__user__can_not_send_mail);
			}

			errors_out = _errors.ToArray();
		}
		#endregion

		#region public static void insObject_Registration(...);
		#region private static string randompassword { get; }
		private static string randompassword__ = "";

		private static string randompassword {
			get {
				if (string.IsNullOrEmpty(randompassword__)) {
					randompassword__ = 
						SimpleHash.ComputeHash(
						Utilities.RandomText(20),
						SimpleHash.HashAlgotithm.SHA256,
						null
					);
				}
				return randompassword__;
			}
		}
		#endregion

		[BOMethodAttribute("insObject_Registration", true, false, -1)]
		public static void insObject_Registration(
			string login_in, 
			string email_in,
			string name_in, 

			string verifyMailURL_in, 
			string companyName_in, 
			int idApplication_in, 

			out int[] errors_out
		) {
			List<int> _errorlist = new List<int>();

			#region check . . . (trying to accumulate errors for user)
			bool _hasErrors = false;

			if (!OGen.Libraries.Mail.Utilities.isEmail_valid(email_in)) {
				_errorlist.Add(ErrorType.web__user__invalid_email);
				_hasErrors = true;
			}

			if (
				DO_NET_User.getObject_byEmail(
					email_in,
					idApplication_in
				) != null
			) {
				_errorlist.Add(ErrorType.web__user__constraint_violation);
				_hasErrors = true;
			}

			if (
				!Sessionuser.checkLogin(
					login_in,
					ref _errorlist
				)
			) {
				//_errors.Add(ErrorType.user__invalid_login);
				_hasErrors = true;
			} else if (
				DO_CRD_User.getObject_byLogin(
					login_in,
					idApplication_in
				) != null
			) {
				_errorlist.Add(ErrorType.data__constraint_violation);
				_hasErrors = true;
			}

			if (_hasErrors) {
				errors_out = _errorlist.ToArray();
				return;
			}
			#endregion

			#region string _message = ...;
			string _message = encrypt_mail(
				idApplication_in,
				_errorlist, 

				email_in,
				"1" // Verify Email
			);
			if (string.IsNullOrEmpty(_message)) {
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
				bool _commit;
				_con.Open();
				_con.Transaction.Begin();

				#region // STEP 1: SBO_CRD_User.insObject_Registration(...);
				long _iduser 
					= SBO_CRD_User.insObject_Registration(
						login_in,
						randompassword, 
						idApplication_in,
						true,
						ref _errorlist,
						_con
					);
				#endregion

				if (_iduser > 0L) {
					bool _constraint;

					#region // STEP 2: DO_NET_User.setObject(...);
					DO_NET_User.setObject(
						new SO_NET_User(
							_iduser,
							name_in,

							// avoiding constraint errors
							Guid.NewGuid().ToString("N"),
							// LATER MAYBE...
							//email_in, 

							email_in,
							idApplication_in
						),
						true,
						out _constraint,
						_con
					);
					#endregion

					if (_constraint) {
						_errorlist.Add(ErrorType.web__user__constraint_violation);
						_commit = false;
					} else {
						#region // STEP 3: DO_CRD_UserProfile.setObject(...);
						long _count;
						SO_NET_Profile__default[] _profiles
							= DO_NET_Profile__default.getRecord_all(
								idApplication_in,
								0, 0, 0, out _count, 
								_con
							);
						for (int p = 0; p < _profiles.Length; p++) {
							DO_CRD_UserProfile.setObject(
								new SO_CRD_UserProfile(
									_iduser,
									_profiles[p].IFProfile
								),
								true,
								_con
							);
						}
						#endregion

						#region // STEP 4: MyMail.Send(...); _commit = ...;
						try {

// ToDos: here! very wrong sending an email while the transaction is open on db, smtp server can delay sending,
// this needs to be changed!

// ToDos: here! more, these messages should go somewhere like an XML file, 
// and multi language support must be implemented

							#region MyMail.Send(email_in, ...);
							OGen.Libraries.Mail.Utilities.MailSend(
								new System.Net.Mail.MailAddress[] {
									new System.Net.Mail.MailAddress(
										email_in, 
										name_in
									)
								},
								null,
								null,
								"Confirmação de Registo",
								string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									@"
Bem vindo ao {2}
 
Recebemos o seu pedido de registo, para activar a sua conta, por favor, clique no link que se segue:

{0}{1}

Atentamente,
 
A equipa {2}",
									//System.Configuration.ConfigurationSettings.AppSettings["URL__base"],
									verifyMailURL_in,
									_message,
									companyName_in
								)
							);
							#endregion

							_errorlist.Add(ErrorType.user__successfully_created__WARNING);
							_commit = true;
						} catch (Exception _ex) {
							#region SBO_LOG_Log.log(ErrorType.web__user__can_not_send_mail);
							OGen.NTier.Kick.Libraries.BusinessLayer.SBO_LOG_Log.log(
								null,
								LogType.error,
								ErrorType.web__user__can_not_send_mail,
								-1L, 
								idApplication_in,
								"{0}",
								new string[] {
									_ex.Message
								}
							);
							#endregion

							_errorlist.Add(ErrorType.web__user__can_not_send_mail);
							_commit = false;
						}
						#endregion
					}
				} else {
					_commit = false;
				}

				if (_commit) {
					#region _con.Transaction.Commit();
					if (
						_con.isOpen
						&&
						_con.Transaction.inTransaction
					) {
						_con.Transaction.Commit();
					}
					#endregion
				} else {
					#region _con.Transaction.Rollback();
					if (
						_con.isOpen
						&&
						_con.Transaction.inTransaction
					) {
						_con.Transaction.Rollback();
					}
					#endregion
				}
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
					null, 
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

		#region private static string encrypt_mail(...);
		private static string encrypt_mail(
			int idApplication_in,

			List<int> errors_in, 

			params string[] words_in
		) {
			try {
				return System.Web.HttpUtility.UrlEncode(
					OGen.Libraries.Crypt.Utilities.Server.RSA_Server_public_Encrypt64(
						string.Format(
							System.Globalization.CultureInfo.CurrentCulture,
							"{0}|{1}",

							// valid for 2 days
							DateTime.Now.AddDays(2).Ticks.ToString(System.Globalization.CultureInfo.CurrentCulture),
							string.Join("|", words_in)
						)
					)
				);
			} catch (Exception _ex) {
				#region SBO_LOG_Log.Log(ErrorType.data);
				SBO_LOG_Log.log(
					null,
					LogType.error,
					ErrorType.encryption__failled_to_encrypt,
					-1L, 
					idApplication_in,
					"{0}",
					new string[] {
						_ex.Message
					}
				);
				#endregion
				errors_in.Add(ErrorType.encryption__failled_to_encrypt);

				return "";
			}
		} 
		#endregion
		#region private static string[] decrypt_mail(...);
		private static string[] decrypt_mail(
			string enc_message_in,
			//int idApplication_in,

			List<int> errors_in
		) {
			string[] _output = null;
			string _message;
			string[] _params;
			long _ticks;

			if (string.IsNullOrEmpty(enc_message_in)) {
				errors_in.Add(ErrorType.encryption__failled_to_decrypt);
				return _output;
			}

			Exception _exception = null;
			try {
				_message
					= OGen.Libraries.Crypt.Utilities.Server.RSA_Server_private_Decrypt64(
						enc_message_in
					);
			} catch (Exception _ex) {
				_exception = _ex;
				_message = "";
			}

			if (
				(_exception != null)
				||
				(_message.IndexOf('|') < 0)
				||
				(!long.TryParse(
					(
						_params = _message.Split('|')
					)[0],
					out _ticks
				))
			) {
				errors_in.Add(ErrorType.encryption__failled_to_decrypt);
				return _output;
			} else if (
				DateTime.Now > new DateTime(_ticks)
			) {
				errors_in.Add(ErrorType.encryption__failled_to_decrypt__expired);
				return _output;
			} else {
				_output = new string[_params.Length - 1];
				for (int i = 0; i < _output.Length; i++) {
					_output[i] = _params[i + 1];
				}
			}

			return _output;
		}
		#endregion
	}
}