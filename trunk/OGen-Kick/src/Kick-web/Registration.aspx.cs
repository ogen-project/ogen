#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.lib.businesslayer.shared.instances;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;
	using OGen.NTier.Kick.lib.presentationlayer.weblayer;

	public partial class Registration : SitePage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
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
			this.lbl_Error.Text = "";
			this.lbl_EMail.Text = "";
			this.lbl_EMail_Confirmation.Text = "";
			this.lbl_Login.Text = "";
			this.lbl_Name.Text = "";
			//// TODO: consider removing commented code
			//this.lbl_Password.Text = "";
			//this.lbl_Password_Confirmation.Text = "";

			#region bool _invalid_email = ...;
			bool _invalid_email
				= !OGen.lib.mail.utils.isEMail_valid(
					(this.txt_EMail.Text = this.txt_EMail.Text.Trim())
				);
			#endregion
			#region bool _invalid_email_missmatch = ...;
			bool _invalid_email_missmatch
				= (
					(this.txt_EMail.Text != (this.txt_EMail_Confirmation.Text = this.txt_EMail_Confirmation.Text.Trim()))
				);
			#endregion
			#region //bool _invalid_password = ...;
			//// TODO: consider removing commented code
			//bool _invalid_password 
			//    = (
			//        (this.txt_Password.Text.Length == 0)
			//    );
			#endregion
			#region //bool _invalid_password_missmatch = ...;
			//// TODO: consider removing commented code
			//bool _invalid_password_missmatch
			//    = (
			//        (this.txt_Password.Text != this.txt_Password_Confirmation.Text)
			//    );
			#endregion
			#region bool _invalid_name = ...;
			bool _invalid_name
				= (
					((this.txt_Name.Text = this.txt_Name.Text.Trim()).Length == 0)
				);
			#endregion
			#region bool _invalid_login = ...;
			bool _invalid_login
				= (
					((this.txt_Login.Text = this.txt_Login.Text.Trim()).Length < 3)
					||
					(this.txt_Login.Text.IndexOf('@') >= 0)
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
					this.txt_Login.Text,
					this.txt_EMail.Text,
					this.txt_Name.Text, 
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
							this.lbl_EMail.Text = "unavailable";
							this.lbl_Error.Text += "<li>you can recover this account on the form below</li>";
							this.txt_LostPassword_EMail.Text = this.txt_EMail.Text;
							this.txt_LostPassword_EMail_Confirmation.Text = this.txt_EMail_Confirmation.Text;

							break;
						case OGen.NTier.Kick.lib.businesslayer.shared.ErrorType.data__constraint_violation:
							this.lbl_Login.Text = "unavailable";
							break;
						case OGen.NTier.Kick.lib.businesslayer.shared.ErrorType.user__successfully_created__WARNING:
							this.lbl_Error.Text += string.Format(
								System.Globalization.CultureInfo.CurrentCulture, 
								"<li>welcome {0}! please check your email</li>",
								this.txt_Login.Text
							);

							this.txt_Name.Enabled = false;
							this.txt_Name.ReadOnly = true;

							this.txt_Login.Enabled = false;
							this.txt_Login.ReadOnly = true;

							this.txt_EMail.Enabled = false;
							this.txt_EMail.ReadOnly = true;

							this.txt_EMail_Confirmation.Enabled = false;
							this.txt_EMail_Confirmation.ReadOnly = true;

							this.btn_Registration.Enabled = false;

							break;
						default:
							this.Master__base.Error_add(_error);
							break;
					}
				}
			} else {
				if (_invalid_email) {
					this.lbl_EMail.Text = "invalid";
				}
				if (_invalid_email_missmatch) {
					this.lbl_EMail_Confirmation.Text = "emails differ";
				}

				//// TODO: consider removing commented code
				//if (_invalid_password) {
				//    this.lbl_Password.Text = "invalid password";
				//}
				//if (_invalid_password_missmatch) {
				//    this.lbl_Password_Confirmation.Text = "passwords differ";
				//}

				if (_invalid_login) {
					this.lbl_Login.Text = "invalid";
				}

				if (_invalid_name) {
					this.lbl_Name.Text = "invalid";
				}
			}
		}
		#endregion
		#region protected void btn_LostPassword_Click(object sender, EventArgs e);
		protected void btn_LostPassword_Click(object sender, EventArgs e) {
			this.lbl_LostPassword_Error.Text = "";
			this.lbl_LostPassword_EMail.Text = "";
			this.lbl_LostPassword_EMail_Confirmation.Text = "";

			#region bool _invalid_email = ...;
			bool _invalid_email 
				= !OGen.lib.mail.utils.isEMail_valid(
					(this.txt_LostPassword_EMail.Text = this.txt_LostPassword_EMail.Text.Trim())
				);
			#endregion
			#region bool _invalid_email_missmatch = ...;
			bool _invalid_email_missmatch
				= (
					(
						(this.txt_LostPassword_EMail_Confirmation.Text
							= this.txt_LostPassword_EMail_Confirmation.Text.Trim(
							)
						) != this.txt_LostPassword_EMail.Text
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
					this.txt_LostPassword_EMail.Text, 
				    ConfigurationManager.AppSettings[
				        "CompanyName"
				    ], 
				    ConfigurationManager.AppSettings[
				        "Registration_changePassword"
				    ], 
				    utils.IDApplication,

				    out _errors
				);
				if (!this.Master__base.Error_add(_errors)) {
					this.lbl_LostPassword_Error.Text
						+= "<li>Please check your email to recover your account</li>";

					this.txt_LostPassword_EMail.Enabled = false;
					this.txt_LostPassword_EMail.ReadOnly = true;

					this.txt_LostPassword_EMail_Confirmation.Enabled = false;
					this.txt_LostPassword_EMail_Confirmation.ReadOnly = true;

					this.btn_LostPassword.Enabled = false;
				}
			} else {
				if (_invalid_email) {
					this.lbl_LostPassword_EMail.Text = "invalid";
				}
				if (_invalid_email_missmatch) {
					this.lbl_LostPassword_EMail_Confirmation.Text = "emails differ";
				}
			}
		}
		#endregion
	}
}