﻿#region Copyright (C) 2002 Francisco Monteiro
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
using System.Web;

using System.Text;
using System.IO;

using OGen.NTier.Kick.lib.datalayer.shared;
using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;
using BusinessInstances = OGen.NTier.Kick.lib.businesslayer.shared.instances;

namespace OGen.NTier.Kick.lib.presentationlayer.weblayer {
	public static class utils {
		#region public static int IDApplication { get; }
		private static int idapplication__ = -2;

		public static int IDApplication {
			get {
				if (idapplication__ == -2) {
					if (
						!int.TryParse(
							System.Configuration.ConfigurationManager.AppSettings["IDApplication"],
							out idapplication__
						)
					) {
						idapplication__ = -1;
					}
				}
				return idapplication__;
			}
		} 
		#endregion
		#region public static int IDLanguage__default { get; }
		private static int idlanguage__default__ = -2;

		public static int IDLanguage__default {
			get {
				if (idlanguage__default__ == -2) {
					if (
						!int.TryParse(
							System.Configuration.ConfigurationManager.AppSettings["IDLanguage__default"],
							out idlanguage__default__
						)
					) {
						idlanguage__default__ = -1;
					}
				}
				return idlanguage__default__;
			}
		} 
		#endregion
		#region public static long News_Highlight_for_Default { get; }
		private static long news_highlight_for_default__ = -2;

		public static long News_Highlight_for_Default {
			get {
				if (news_highlight_for_default__ == -2) {
					if (
						!long.TryParse(
							System.Configuration.ConfigurationManager.AppSettings["News_Highlight_for_Default"],
							out news_highlight_for_default__
						)
					) {
						news_highlight_for_default__ = 0;
					}
				}
				return news_highlight_for_default__;
			}
		}
		#endregion
		#region public static string ClientIPAddress { get; }
		public static string ClientIPAddress {
			get {
				return HttpContext.Current.Request.UserHostAddress;
			}
		}
		#endregion

		#region public static class User { ... }
		public static class User {
			private const string SESSION_GUID = "OGen_Kick_Guid";
			private const string SESSION_IDUSER = "OGen_Kick_IDUser";
			private const string SESSION_IDPERMITIONS = "OGen_Kick_IDPermitions";
			private const string SESSION_LOGIN = "OGen_Kick_Login";

			#region public static void Logout();
			public static void Logout(
			) {
				BusinessInstances.CRD_Authentication.InstanceClient.Logout(SessionGuid);

				HttpContext.Current.Session.Remove(SESSION_GUID);
				HttpContext.Current.Session.Remove(SESSION_IDUSER);
				HttpContext.Current.Session.Remove(SESSION_IDPERMITIONS);
				HttpContext.Current.Session.Remove(SESSION_LOGIN);
			}
			public static void Logout(
				string path_in, 
				bool withReturnParams_in
			) {
				Logout();

				if (path_in != "") {
					HttpContext.Current.Response.Redirect(
						string.Format(
							"{0}{1}",
							path_in,
							withReturnParams_in 
								? string.Format(
									"?url={0}&args={1}",
									HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Params["PATH_INFO"]),
									HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.QueryString.ToString())
								) 
								: ""
						),
						true
					);
				}
			}
			#endregion

			#region public static bool HttpContext_Current_Session_Keys_Contains(...);
			public static bool HttpContext_Current_Session_Keys_Contains(
				string key_in
			) {
				try {
					for (int k = 0; k < HttpContext.Current.Session.Keys.Count; k++) {
						if (HttpContext.Current.Session.Keys[k] == key_in) {
							return true;
						}
					}
				} catch {
					// THIS IS NO MISTAKE, leave it empty, it will return false...
				}

				return false;
			}
			#endregion

			#region public static string SessionGuid { get; set; }
			public static string SessionGuid {
				get {
					if (
						(!HttpContext_Current_Session_Keys_Contains(SESSION_GUID))
						||
						(HttpContext.Current.Session[SESSION_GUID] == null)
						||
						(((string)HttpContext.Current.Session[SESSION_GUID]).Trim() == "")
					) {
						return Anonymous.SessionGuid;
					} else {
						return (string)HttpContext.Current.Session[SESSION_GUID];
					}
				}
				set {
					Guid _guid;
					if (Sessionuser.Guid_TryParse(value, out _guid)) {
						if (
							(!HttpContext_Current_Session_Keys_Contains(SESSION_GUID))
							//||
							//(HttpContext.Current.Session[SESSION_GUID] == null)
						) {
							HttpContext.Current.Session.Remove(SESSION_GUID);
							HttpContext.Current.Session.Add(SESSION_GUID, value);
						} else {
							HttpContext.Current.Session[SESSION_GUID] = value;
						}
					} else {
						HttpContext.Current.Session.Remove(SESSION_GUID);
					}
				}
			}
			#endregion
			#region public static long IDUser{ get; set; }
			public static long IDUser {
				get {
					if (
						(!HttpContext_Current_Session_Keys_Contains(SESSION_IDUSER))
						||
						(HttpContext.Current.Session[SESSION_IDUSER] == null)
						||
						((long)HttpContext.Current.Session[SESSION_IDUSER] <= 0L)
					) {
						return -1L;
					} else {
						return (long)HttpContext.Current.Session[SESSION_IDUSER];
					}
				}
				set {
					if (value > 0L) {
						if (
							(!HttpContext_Current_Session_Keys_Contains(SESSION_IDUSER))
							//||
							//(HttpContext.Current.Session[SESSION_IDUSER] == null)
						) {
							HttpContext.Current.Session.Remove(SESSION_IDUSER);
							HttpContext.Current.Session.Add(SESSION_IDUSER, value);
						} else {
							HttpContext.Current.Session[SESSION_IDUSER] = value;
						}
					} else {
						HttpContext.Current.Session.Remove(SESSION_IDUSER);
					}
				}
			}
			#endregion
			#region public static long[] IDPermitions { get; set; }
			public static long[] IDPermitions {
				get {
					if (
						(!HttpContext_Current_Session_Keys_Contains(SESSION_IDPERMITIONS))
						||
						(HttpContext.Current.Session[SESSION_IDPERMITIONS] == null)
						||
						(((long[])HttpContext.Current.Session[SESSION_IDPERMITIONS]).Length == 0)
					) {
						return null;
					} else {
						return (long[])HttpContext.Current.Session[SESSION_IDPERMITIONS];
					}
				}
				set {
					if (
						(value != null)
						&&
						(value.Length > 0)
					) {
						if (
							(!HttpContext_Current_Session_Keys_Contains(SESSION_IDPERMITIONS))
							//||
							//(HttpContext.Current.Session[SESSION_IDPERMITIONS] == null)
						) {
							HttpContext.Current.Session.Remove(SESSION_IDPERMITIONS);
							HttpContext.Current.Session.Add(SESSION_IDPERMITIONS, value);
						} else {
							HttpContext.Current.Session[SESSION_IDPERMITIONS] = value;
						}
					} else {
						HttpContext.Current.Session.Remove(SESSION_IDPERMITIONS);
					}
				}
			}
			#endregion
			#region public static string Login { get; set; }
			public static string Login {
				get {
					if (
						(!HttpContext_Current_Session_Keys_Contains(SESSION_LOGIN))
						||
						(HttpContext.Current.Session[SESSION_LOGIN] == null)
						||
						((string)HttpContext.Current.Session[SESSION_LOGIN] == "")
					) {
						return "";
					} else {
						return (string)HttpContext.Current.Session[SESSION_LOGIN];
					}
				}
				set {
					if (value != "") {
						if (
							(!HttpContext_Current_Session_Keys_Contains(SESSION_LOGIN))
							//||
							//(HttpContext.Current.Session[SESSION_IDCOWORKER] == null)
						) {
							HttpContext.Current.Session.Remove(SESSION_LOGIN);
							HttpContext.Current.Session.Add(SESSION_LOGIN, value);
						} else {
							HttpContext.Current.Session[SESSION_LOGIN] = value;
						}
					} else {
						HttpContext.Current.Session.Remove(SESSION_LOGIN);
					}
				}
			}
			#endregion

			#region public static bool isLoggedIn { get; }
			public static bool isLoggedIn {
				get {
					int[] _errors;
					return (
						(SessionGuid != null)
						&&
						(SessionGuid != Anonymous.SessionGuid)
						&&

						// session may have expired on server side, hence:
						BusinessInstances.CRD_Authentication.InstanceClient.CheckCredentials(
							SessionGuid,
							ClientIPAddress,
							out _errors
						)
					);
				}
			}
			#endregion

			#region public static void DoLogin(...);
			private static bool dologin(
				string login_in, 
				string password_in,
				ErrorType.hasErrors_errorFound errorFound_in, 
				out int[] errors_out
			) {
				long _iduser;
				long[] _idpermitions;
				string _login = login_in;
				string _sessionguid = Guid.NewGuid().ToString("N");

				if (login_in.IndexOf('@') >= 0) {
					BusinessInstances.WEB_User.InstanceClient.Login(
						login_in,
						password_in,

						_sessionguid,
						ClientIPAddress,

						utils.IDApplication,

						out _iduser,
						out _login,
						out _idpermitions,
						out errors_out
					);
				} else {
					BusinessInstances.CRD_Authentication.InstanceClient.Login(
						login_in,
						password_in,

						_sessionguid,
						ClientIPAddress,

						utils.IDApplication,

						out _iduser,
						out _idpermitions,
						out errors_out
					);
				}

				if (OGen.NTier.Kick.lib.businesslayer.shared.ErrorType.hasErrors(
					errors_out,
					errorFound_in
				)) {
					Logout();

					return false;
				} else {
					SessionGuid = _sessionguid;
					IDUser = _iduser;
					IDPermitions = _idpermitions;
					Login = login_in;

					return true;
				}
			}
			public static bool DoLogin(
				string login_in,
				string password_in,
				out int[] errors_out
			) {
				return dologin(
					login_in,
					password_in,
					null,
					out errors_out
				);
			}
			public static bool DoLogin(
				string login_in,
				string password_in,
				ErrorType.hasErrors_errorFound errorFound_in
			) {
				int[] _errors;
				return dologin(
					login_in,
					password_in,
					errorFound_in,
					out _errors
				);
			}
			public static bool DoLogin_throughLink(
				out int[] _errors_out
			) {
				string _email = HttpContext.Current.Request.QueryString["param"];
				if (
					(_email == null)
					||
					((_email = _email.Trim()) == "")
				) {
					_errors_out = new int[] {
						ErrorType.authentication__invalid_email, 
						ErrorType.encryption__failled_to_decrypt
					};
					return false;
				}


				long _iduser;
				long[] _idpermitions;
				string _login;
				string _name;

				string _sessionguid = Guid.NewGuid().ToString("N");

				BusinessInstances.WEB_User.InstanceClient.Login_throughLink(
					_sessionguid,
					utils.ClientIPAddress,

					_email,

					utils.IDApplication,
					out _iduser,
					out _login,
					out _name,
					out _idpermitions,
					out _errors_out
				);

				if (!ErrorType.hasErrors(_errors_out)) {
					utils.User.SessionGuid = _sessionguid;
					utils.User.IDPermitions = _idpermitions;
					utils.User.IDUser = _iduser;
					utils.User.Login = _login;

					return true;
				} else {
					return false;
				}
			}

			public static bool DoLogin_throughLink_andChangePassword(
				string newpassword_in, 
				out int[] _errors_out
			) {
				string _email = HttpContext.Current.Request.QueryString["param"];
				if (
					(_email == null)
					||
					((_email = _email.Trim()) == "")
				) {
					_errors_out = new int[] {
						ErrorType.authentication__invalid_email, 
						ErrorType.encryption__failled_to_decrypt
					};
					return false;
				}


				long _iduser;
				long[] _idpermitions;
				string _login;
				string _name;

				string _sessionguid = Guid.NewGuid().ToString("N");

				BusinessInstances.WEB_User.InstanceClient.Login_throughLink_andChangePassword(
					_sessionguid,
					utils.ClientIPAddress,

					_email,

					utils.IDApplication,
					newpassword_in, 
					out _iduser,
					out _login,
					out _name,
					out _idpermitions,
					out _errors_out
				);

				if (!ErrorType.hasErrors(_errors_out)) {
					utils.User.SessionGuid = _sessionguid;
					utils.User.IDPermitions = _idpermitions;
					utils.User.IDUser = _iduser;
					utils.User.Login = _login;

					return true;
				} else {
					return false;
				}
			}
			#endregion

			private static class Anonymous {
				//static Anonymous() { }

				#region public static string Login { get; }
				private static string login__ = null;

				public static string Login {
					get {
						if (login__ == null) {
							login__ = System.Configuration.ConfigurationManager.AppSettings["Anonymos_login"];
						}
						return login__;
					}
				}
				#endregion
				#region public static string Password { get; }
				private static string password__ = null;

				private static string Password {
					get {
						if (password__ == null) {
							password__ = System.Configuration.ConfigurationManager.AppSettings["Anonymos_password"];
						}
						return password__;
					}
				}
				#endregion
				#region public static long IDUser { get; }
				private static long iduser_;

				public static long IDUser {
					get {
						return iduser_;
					}
				}
				#endregion
				#region public static long[] IDPermitions { get; }
				private static long[] idpermitions_;

				public static long[] IDPermitions {
					get {
						return idpermitions_;
					}
				}
				#endregion

				#region public static string Credentials_ENC { get; }
				public static long sessionguid__timeout = -1L;
				private static string sessionguid__ = "";

				public static string SessionGuid {
					get {
						int[] _errors;

						if (
							(sessionguid__ == "")
							||
							(DateTime.Now.Ticks >= sessionguid__timeout)
							||
							!BusinessInstances.CRD_Authentication.InstanceClient.CheckCredentials(
								sessionguid__,
								utils.ClientIPAddress,
								out _errors
							)
						) {
							BusinessInstances.CRD_Authentication.InstanceClient.Login(
								Login,
								Password,
								sessionguid__ = Guid.NewGuid().ToString("N"), 
								utils.ClientIPAddress, 

								utils.IDApplication, 

								out iduser_,
								out idpermitions_, 
								out _errors
							);

							if (ErrorType.hasErrors(_errors)) {
								BusinessInstances.LOG_Log.InstanceClient.Log(
									"",
									utils.ClientIPAddress,
									LogType.error,
									ErrorType.authentication,
									-1L,
									utils.IDApplication,
									"anonymous login error: {0}", 
									new string[] {
										ErrorType.ErrorMessage("|", _errors)
									}
								);
							} else {
								sessionguid__timeout = DateTime.Now.AddMinutes(1D).Ticks;
							}
						}

						return sessionguid__;
					}
				}
				#endregion
			}
		}
		#endregion

		#region public static class Dic { ... }
		public static class Dic {
			#region public static OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] Languages { get; }
			private static OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] languages__ = null;

			public static OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] Languages {
				get {
//					if (languages__ == null) {
						int[] _errors;
						OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] _languages;
						_languages = BusinessInstances.DIC_Dic.InstanceClient.getRecord_byApplication(
							utils.User.SessionGuid,
							utils.ClientIPAddress,

							out _errors
						);
						if (
							(_errors == null)
							||
							(_errors.Length <= 0)
						) {
							languages__ = _languages;
						}
//					}
					return languages__;
				}
			}
			#endregion
		}
		#endregion
	}
}