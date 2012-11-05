#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.PresentationLayer.WebLayer {
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Instances;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.PresentationLayer.WebLayer;

	public partial class Registration : SitePage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (Utilities.User.IsLoggedIn) {
				Response.Redirect(
					"~/Registration-update.aspx",
					true
				);
			}
		}
		#endregion
		#region protected void BTN_Registration_Click(object sender, EventArgs e);
		protected void BTN_Registration_Click(object sender, EventArgs e) {
			this.LBL_Error.Text = "";
			this.LBL_Email.Text = "";
			this.LBL_Email_Confirmation.Text = "";
			this.LBL_LogOn.Text = "";
			this.LBL_Name.Text = "";
			//// TODO: consider removing commented code
			//this.LBL_Password.Text = "";
			//this.LBL_Password_Confirmation.Text = "";

			#region bool _invalid_email = ...;
			bool _invalid_email
				= !OGen.Libraries.Mail.Utilities.isEmail_valid(
					(this.TXT_Email.Text = this.TXT_Email.Text.Trim())
				);
			#endregion
			#region bool _invalid_email_missmatch = ...;
			bool _invalid_email_missmatch
				= (
					(this.TXT_Email.Text != (this.TXT_Email_Confirmation.Text = this.TXT_Email_Confirmation.Text.Trim()))
				);
			#endregion
			#region //bool _invalid_password = ...;
			//// TODO: consider removing commented code
			//bool _invalid_password 
			//    = (
			//        (this.TXT_Password.Text.Length == 0)
			//    );
			#endregion
			#region //bool _invalid_password_missmatch = ...;
			//// TODO: consider removing commented code
			//bool _invalid_password_missmatch
			//    = (
			//        (this.TXT_Password.Text != this.TXT_Password_Confirmation.Text)
			//    );
			#endregion
			#region bool _invalid_name = ...;
			bool _invalid_name
				= (
					((this.TXT_Name.Text = this.TXT_Name.Text.Trim()).Length == 0)
				);
			#endregion
			#region bool _invalid_login = ...;
			bool _invalid_login
				= (
					((this.TXT_LogOn.Text = this.TXT_LogOn.Text.Trim()).Length < 3)
					||
					(this.TXT_LogOn.Text.IndexOf('@') >= 0)
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
					this.TXT_LogOn.Text,
					this.TXT_Email.Text,
					this.TXT_Name.Text, 
					ConfigurationManager.AppSettings[
						"Registration_changePassword"
					],
					ConfigurationManager.AppSettings[
						"CompanyName"
					],
					Utilities.IDApplication,
					out _errors
				);

				//bool _isError;
				foreach (int _error in _errors) {
					switch (_error) {
						case OGen.NTier.Kick.Libraries.BusinessLayer.Shared.ErrorType.web__user__constraint_violation:
							this.LBL_Email.Text = "unavailable";
							this.LBL_Error.Text += "<li>you can recover this account on the form below</li>";
							this.TXT_LostPassword_Email.Text = this.TXT_Email.Text;
							this.TXT_LostPassword_Email_Confirmation.Text = this.TXT_Email_Confirmation.Text;

							break;
						case OGen.NTier.Kick.Libraries.BusinessLayer.Shared.ErrorType.data__constraint_violation:
							this.LBL_LogOn.Text = "unavailable";
							break;
						case OGen.NTier.Kick.Libraries.BusinessLayer.Shared.ErrorType.user__successfully_created__WARNING:
							this.LBL_Error.Text += string.Format(
								System.Globalization.CultureInfo.CurrentCulture, 
								"<li>welcome {0}! please check your email</li>",
								this.TXT_LogOn.Text
							);

							this.TXT_Name.Enabled = false;
							this.TXT_Name.ReadOnly = true;

							this.TXT_LogOn.Enabled = false;
							this.TXT_LogOn.ReadOnly = true;

							this.TXT_Email.Enabled = false;
							this.TXT_Email.ReadOnly = true;

							this.TXT_Email_Confirmation.Enabled = false;
							this.TXT_Email_Confirmation.ReadOnly = true;

							this.BTN_Registration.Enabled = false;

							break;
						default:
							this.Master__base.Error_add(_error);
							break;
					}
				}
			} else {
				if (_invalid_email) {
					this.LBL_Email.Text = "invalid";
				}
				if (_invalid_email_missmatch) {
					this.LBL_Email_Confirmation.Text = "emails differ";
				}

				//// TODO: consider removing commented code
				//if (_invalid_password) {
				//    this.LBL_Password.Text = "invalid password";
				//}
				//if (_invalid_password_missmatch) {
				//    this.LBL_Password_Confirmation.Text = "passwords differ";
				//}

				if (_invalid_login) {
					this.LBL_LogOn.Text = "invalid";
				}

				if (_invalid_name) {
					this.LBL_Name.Text = "invalid";
				}
			}
		}
		#endregion
		#region protected void BTN_LostPassword_Click(object sender, EventArgs e);
		protected void BTN_LostPassword_Click(object sender, EventArgs e) {
			this.LBL_LostPassword_Error.Text = "";
			this.LBL_LostPassword_Email.Text = "";
			this.LBL_LostPassword_Email_Confirmation.Text = "";

			#region bool _invalid_email = ...;
			bool _invalid_email 
				= !OGen.Libraries.Mail.Utilities.isEmail_valid(
					(this.TXT_LostPassword_Email.Text = this.TXT_LostPassword_Email.Text.Trim())
				);
			#endregion
			#region bool _invalid_email_missmatch = ...;
			bool _invalid_email_missmatch
				= (
					(
						(this.TXT_LostPassword_Email_Confirmation.Text
							= this.TXT_LostPassword_Email_Confirmation.Text.Trim(
							)
						) != this.TXT_LostPassword_Email.Text
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
					this.TXT_LostPassword_Email.Text, 
				    ConfigurationManager.AppSettings[
				        "CompanyName"
				    ], 
				    ConfigurationManager.AppSettings[
				        "Registration_changePassword"
				    ], 
				    Utilities.IDApplication,

				    out _errors
				);
				if (!this.Master__base.Error_add(_errors)) {
					this.LBL_LostPassword_Error.Text
						+= "<li>Please check your email to recover your account</li>";

					this.TXT_LostPassword_Email.Enabled = false;
					this.TXT_LostPassword_Email.ReadOnly = true;

					this.TXT_LostPassword_Email_Confirmation.Enabled = false;
					this.TXT_LostPassword_Email_Confirmation.ReadOnly = true;

					this.BTN_LostPassword.Enabled = false;
				}
			} else {
				if (_invalid_email) {
					this.LBL_LostPassword_Email.Text = "invalid";
				}
				if (_invalid_email_missmatch) {
					this.LBL_LostPassword_Email_Confirmation.Text = "emails differ";
				}
			}
		}
		#endregion
	}
}