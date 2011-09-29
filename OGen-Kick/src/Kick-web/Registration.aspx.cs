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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared.instances;
using OGen.NTier.Kick.lib.presentationlayer.weblayer;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class Registration : SitePage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (utils.User.isLoggedIn) {
				Response.Redirect(
					"~/Registration-update.aspx",
					true
				);
			}
		}
		#endregion
		#region protected void btn_Registration_Click(object sender, EventArgs e);
		protected void btn_Registration_Click(object sender, EventArgs e) {
			lbl_Error.Text = "";
			lbl_EMail.Text = "";
			lbl_EMail_Confirmation.Text = "";
			lbl_Login.Text = "";
			lbl_Name.Text = "";
			//lbl_Password.Text = "";
			//lbl_Password_Confirmation.Text = "";

			#region bool _invalid_email = ...;
			bool _invalid_email
				= !OGen.lib.mail.utils.isEMail_valid(
					(txt_EMail.Text = txt_EMail.Text.Trim())
				);
			#endregion
			#region bool _invalid_email_missmatch = ...;
			bool _invalid_email_missmatch
				= (
					(txt_EMail.Text != (txt_EMail_Confirmation.Text = txt_EMail_Confirmation.Text.Trim()))
				);
			#endregion
			#region //bool _invalid_password = ...;
			//bool _invalid_password 
			//    = (
			//        (txt_Password.Text.Length == 0)
			//    );
			#endregion
			#region //bool _invalid_password_missmatch = ...;
			//bool _invalid_password_missmatch
			//    = (
			//        (txt_Password.Text != txt_Password_Confirmation.Text)
			//    );
			#endregion
			#region bool _invalid_name = ...;
			bool _invalid_name
				= (
					((txt_Name.Text = txt_Name.Text.Trim()) == "")
				);
			#endregion
			#region bool _invalid_login = ...;
			bool _invalid_login
				= (
					((txt_Login.Text = txt_Login.Text.Trim()).Length < 3)
					||
					(txt_Login.Text.IndexOf('@') >= 0)
				);
			#endregion

			if (
				!_invalid_email
				&&
				!_invalid_email_missmatch
				&&
				//!_invalid_password
				//&&
				//!_invalid_password_missmatch
				//&&
				!_invalid_login
				&&
				!_invalid_name
			) {
				int[] _errors;

				WEB_User.InstanceClient.insObject_Registration(
					txt_Login.Text,
					txt_EMail.Text,
					txt_Name.Text, 
					ConfigurationManager.AppSettings[
						"Registration_changePassword"
					],
					ConfigurationManager.AppSettings[
						"CompanyName"
					],
					utils.IDApplication,
					out _errors
				);

				//bool _isError;
				foreach (int _error in _errors) {
					switch (_error) {
						case OGen.NTier.Kick.lib.businesslayer.shared.ErrorType.web__user__constraint_violation:
							lbl_EMail.Text = "unavailable";
							lbl_Error.Text += "<li>you can recover this account on the form below</li>";
							txt_LostPassword_EMail.Text = txt_EMail.Text;
							txt_LostPassword_EMail_Confirmation.Text = txt_EMail_Confirmation.Text;

							break;
						case OGen.NTier.Kick.lib.businesslayer.shared.ErrorType.data__constraint_violation:
							lbl_Login.Text = "unavailable";
							break;
						case OGen.NTier.Kick.lib.businesslayer.shared.ErrorType.user__successfully_created__WARNING:
							lbl_Error.Text += string.Format("<li>welcome {0}! please check your email</li>", txt_Login.Text);

							txt_Name.Enabled = false;
							txt_Name.ReadOnly = true;

							txt_Login.Enabled = false;
							txt_Login.ReadOnly = true;

							txt_EMail.Enabled = false;
							txt_EMail.ReadOnly = true;

							txt_EMail_Confirmation.Enabled = false;
							txt_EMail_Confirmation.ReadOnly = true;

							btn_Registration.Enabled = false;

							break;
						default:
							Master__base.Error_show(_error);
							break;
					}
				}
			} else {
				if (_invalid_email) {
					lbl_EMail.Text = "invalid";
				}
				if (_invalid_email_missmatch) {
					lbl_EMail_Confirmation.Text = "emails differ";
				}

				//if (_invalid_password) {
				//    lbl_Password.Text = "invalid password";
				//}
				//if (_invalid_password_missmatch) {
				//    lbl_Password_Confirmation.Text = "passwords differ";
				//}

				if (_invalid_login) {
					lbl_Login.Text = "invalid";
				}

				if (_invalid_name) {
					lbl_Name.Text = "invalid";
				}
			}
		}
		#endregion
		#region protected void btn_LostPassword_Click(object sender, EventArgs e);
		protected void btn_LostPassword_Click(object sender, EventArgs e) {
			lbl_LostPassword_Error.Text = "";
			lbl_LostPassword_EMail.Text = "";
			lbl_LostPassword_EMail_Confirmation.Text = "";

			#region bool _invalid_email = ...;
			bool _invalid_email 
				= !OGen.lib.mail.utils.isEMail_valid(
					(txt_LostPassword_EMail.Text = txt_LostPassword_EMail.Text.Trim())
				);
			#endregion
			#region bool _invalid_email_missmatch = ...;
			bool _invalid_email_missmatch
				= (
					(
						(txt_LostPassword_EMail_Confirmation.Text 
							= txt_LostPassword_EMail_Confirmation.Text.Trim(
							)
						) != txt_LostPassword_EMail.Text
					)
				);
			#endregion
			if (
				!_invalid_email
				&&
				!_invalid_email_missmatch
			) {
				int[] _errors;

				WEB_User.InstanceClient.LostPassword_Recover(
					txt_LostPassword_EMail.Text, 
				    ConfigurationManager.AppSettings[
				        "CompanyName"
				    ], 
				    ConfigurationManager.AppSettings[
				        "Registration_changePassword"
				    ], 
				    utils.IDApplication,

				    out _errors
				);
				if (!Master__base.Error_show(_errors)) {
					lbl_LostPassword_Error.Text
						+= "<li>Please check your email to recover your account</li>";

					txt_LostPassword_EMail.Enabled = false;
					txt_LostPassword_EMail.ReadOnly = true;

					txt_LostPassword_EMail_Confirmation.Enabled = false;
					txt_LostPassword_EMail_Confirmation.ReadOnly = true;

					btn_LostPassword.Enabled = false;
				}
			} else {
				if (_invalid_email) {
					lbl_LostPassword_EMail.Text = "invalid";
				}
				if (_invalid_email_missmatch) {
					lbl_LostPassword_EMail_Confirmation.Text = "emails differ";
				}
			}
		}
		#endregion
	}
}