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

	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.instances;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;
	using OGen.NTier.Kick.lib.presentationlayer.weblayer;

	public partial class Registration_update : SitePage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!utils.User.IsLoggedIn) {
				Response.Redirect(
					"~/Registration.aspx",
					true
				);

				return;
			}



			this.LBL_Password.Text = "";        this.LBL_Password.Visible = false;
			this.LBL_PasswordNew.Text = "";     this.LBL_PasswordNew.Visible = false;
			this.LBL_PasswordConfirm.Text = ""; this.LBL_PasswordConfirm.Visible = false;
			//---
			this.LBL_Email.Text = "";           this.LBL_Email.Visible = false;
			//---
			this.LBL_Name.Text = "";            this.LBL_Name.Visible = false;



			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}
		#endregion

		#region protected void LBT_RegistrationDataShow_Click(object sender, EventArgs e);
		protected void LBT_RegistrationDataShow_Click(object sender, EventArgs e) {
			this.TBL_RegistrationData.Visible = true;
			this.LBT_RegistrationDataHide.Visible = true;
			this.LBT_RegistrationDataShow.Enabled = false;

			this.BTN_RegistrationEmailCancel_Click(null, null);
			this.BTN_RegistrationPasswordCancel_Click(null, null);
		}
		#endregion
		#region protected void LBT_RegistrationDataHide_Click(object sender, EventArgs e);
		protected void LBT_RegistrationDataHide_Click(object sender, EventArgs e) {
			this.TXT_Name.Text = this.HFI_Name.Value;
			//this.TXT_LogOn.Text = this.HFI_LogOn.Value;

			this.TBL_RegistrationData.Visible = false;
			this.LBT_RegistrationDataHide.Visible = false;
			this.LBT_RegistrationDataShow.Enabled = true;
		}
		#endregion
		#region protected void BTN_RegistrationDataCancel_Click(object sender, EventArgs e);
		protected void BTN_RegistrationDataCancel_Click(object sender, EventArgs e) {
			this.LBT_RegistrationDataHide_Click(null, null);
		}
		#endregion
		#region protected void BTN_RegistrationDataUpdate_Click(object sender, EventArgs e);
		protected void BTN_RegistrationDataUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;

			this.TXT_Name.Text = this.TXT_Name.Text.Trim();

			if (string.IsNullOrEmpty(this.TXT_Name.Text)) {
				this.LBL_Name.Text = "invalid";
				this.LBL_Name.Visible = true;
				_foundErrors = true;
			} else if (
				this.TXT_Name.Text == this.HFI_Name.Value
			) {
				this.LBL_Name.Text = "no changes";
				this.LBL_Name.Visible = true;
				_foundErrors = true;
			} 
			#endregion

			if (!_foundErrors) {
				int[] _errors;
				WEB_User.InstanceClient.setObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					utils.User.IDUser, 

					true,
					this.TXT_Name.Text, 

					out _errors
				);

				if (!this.Master__base.Error_add(_errors)) {
					this.HFI_Name.Value = this.TXT_Name.Text;
					this.LBT_RegistrationDataHide_Click(null, null);
				}
			}
		}
		#endregion

		#region protected void LBT_RegistrationEmailShow_Click(object sender, EventArgs e);
		protected void LBT_RegistrationEmailShow_Click(object sender, EventArgs e) {
			this.TBL_RegistrationEmail.Visible = true;
			this.LBT_RegistrationEmailHide.Visible = true;
			this.LBT_RegistrationEmailShow.Enabled = false;
			//this.LBT_RegistrationEmailShow.CssClass = "vermais";

			this.BTN_RegistrationDataCancel_Click(null, null);
			this.BTN_RegistrationPasswordCancel_Click(null, null);
		}
		#endregion
		#region protected void LBT_RegistrationEmailHide_Click(object sender, EventArgs e);
		protected void LBT_RegistrationEmailHide_Click(object sender, EventArgs e) {
			this.TXT_Email.Text = this.HFI_Email.Value;

			this.TBL_RegistrationEmail.Visible = false;
			this.LBT_RegistrationEmailHide.Visible = false;
			this.LBT_RegistrationEmailShow.Enabled = true;
			//this.LBT_RegistrationEmailShow.CssClass = "titulo_branco";
		}
		#endregion
		#region protected void BTN_RegistrationEmailCancel_Click(object sender, EventArgs e);
		protected void BTN_RegistrationEmailCancel_Click(object sender, EventArgs e) {
			this.LBT_RegistrationEmailHide_Click(null, null);
		}
		#endregion
		#region protected void BTN_RegistrationEmailUpdate_Click(object sender, EventArgs e);
		protected void BTN_RegistrationEmailUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;

			this.TXT_Email.Text = this.TXT_Email.Text.Trim();

			if (
				!OGen.lib.mail.utils.isEmail_valid(
					this.TXT_Email.Text
				)
			) {
				this.LBL_Email.Text = "invalid";
				this.LBL_Email.Visible = true;
				_foundErrors = true;
			} else if (
				this.TXT_Email.Text == this.HFI_Email.Value
			) {
				this.LBL_Email.Text = "no changes";
				this.LBL_Email.Visible = true;
				_foundErrors = true;
			} 
			#endregion

			if (!_foundErrors) {
				int[] _errors;
				WEB_User.InstanceClient.updObject_Email(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					this.TXT_Email.Text,
					ConfigurationManager.AppSettings[
						"CompanyName"
					],
					ConfigurationManager.AppSettings[
						"Registration_confirmEmail"
					],

					out _errors
				);
				if (!this.Master__base.Error_add(_errors)) {

// ToDos: here! // mail hasn't been changed yet, waiting user confirmation, hence comment:
//this.HFI_Email.Value = TXT_Email.Text;

					this.LBT_RegistrationEmailHide_Click(null, null);
				}
			}
		}
		#endregion

		#region protected void LBT_RegistrationPasswordShow_Click(object sender, EventArgs e);
		protected void LBT_RegistrationPasswordShow_Click(object sender, EventArgs e) {
			this.TBL_RegistrationPassword.Visible = true;
			this.LBT_RegistrationPasswordHide.Visible = true;
			this.LBT_RegistrationPasswordShow.Enabled = false;

			this.BTN_RegistrationDataCancel_Click(null, null);
			this.BTN_RegistrationEmailCancel_Click(null, null);
		}
		#endregion
		#region protected void LBT_RegistrationPasswordHide_Click(object sender, EventArgs e);
		protected void LBT_RegistrationPasswordHide_Click(object sender, EventArgs e) {
			this.TXT_Password.Text = ""; // this.HFI_Password.Value;

			this.TBL_RegistrationPassword.Visible = false;
			this.LBT_RegistrationPasswordHide.Visible = false;
			this.LBT_RegistrationPasswordShow.Enabled = true;
		}
		#endregion
		#region protected void BTN_RegistrationPasswordCancel_Click(object sender, EventArgs e);
		protected void BTN_RegistrationPasswordCancel_Click(object sender, EventArgs e) {
			this.LBT_RegistrationPasswordHide_Click(null, null);
		}
		#endregion
		#region protected void BTN_RegistrationPasswordUpdate_Click(object sender, EventArgs e);
		protected void BTN_RegistrationPasswordUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;
			if ((this.TXT_Password.Text = this.TXT_Password.Text.Trim()).Length == 0) {
				this.LBL_Password.Text = "invalid";
				this.LBL_Password.Visible = true;

				_foundErrors = true;
			}
			if ((this.TXT_PasswordNew.Text = this.TXT_PasswordNew.Text.Trim()).Length == 0) {
				this.LBL_PasswordNew.Text = "invalid";
				this.LBL_PasswordNew.Visible = true;

				_foundErrors = true;
			} else if (this.TXT_Password.Text == this.TXT_PasswordNew.Text) {
				this.LBL_PasswordNew.Text = "no changes";
				this.LBL_PasswordNew.Visible = true;

				_foundErrors = true;
			}
			if (this.TXT_PasswordNew.Text != this.TXT_PasswordConfirm.Text) {
				this.LBL_PasswordConfirm.Text = "passwords differ";
				this.LBL_PasswordConfirm.Visible = true;

				_foundErrors = true;
			}
			#endregion
			if (!_foundErrors) {
				int[] _errors;
				CRD_Authentication.InstanceClient.ChangePassword(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					this.TXT_Password.Text,
					this.TXT_PasswordNew.Text,
					out _errors
				);

				if (
					ErrorType.hasError(
						ErrorType.authentication__change_password__wrong_password, 
						_errors
					)
				) {
					this.LBL_Password.Text = "wrong password";
					this.LBL_Password.Visible = true;
				} else {
					if (!this.Master__base.Error_add(_errors)) {
						this.LBT_RegistrationPasswordHide_Click(null, null);
					}
				}
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			if (!utils.User.IsLoggedIn) {
				Response.Redirect(
					"~/Registration.aspx",
					true
				);

				return;
			}

			int[] _errors;
			SO_NET_User _user
				= WEB_User.InstanceClient.getObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					utils.User.IDUser, 

					out _errors
				);
			if (!this.Master__base.Error_add(_errors)) {
				this.TXT_Name.Text
					= this.HFI_Name.Value
					= _user.Name;
				this.TXT_LogOn.Text
					= this.HFI_LogOn.Value
					= utils.User.Login;

				this.TXT_Email.Text
					= this.HFI_Email.Value
					= _user.Email;
			} else {
				this.TXT_Name.Text
					= this.HFI_Name.Value
					= "";
				this.TXT_LogOn.Text
					= this.HFI_LogOn.Value
					= "";

				this.TXT_Email.Text
					= this.HFI_Email.Value
					= "";
			}
		}
		#endregion
	}
}