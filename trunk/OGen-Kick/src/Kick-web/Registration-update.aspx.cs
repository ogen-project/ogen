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
			if (!utils.User.isLoggedIn) {
				Response.Redirect(
					"~/Registration.aspx",
					true
				);

				return;
			}



			this.lbl_Password.Text = "";        this.lbl_Password.Visible = false;
			this.lbl_PasswordNew.Text = "";     this.lbl_PasswordNew.Visible = false;
			this.lbl_PasswordConfirm.Text = ""; this.lbl_PasswordConfirm.Visible = false;
			//---
			this.lbl_EMail.Text = "";           this.lbl_EMail.Visible = false;
			//---
			this.lbl_Name.Text = "";            this.lbl_Name.Visible = false;



			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}
		#endregion

		#region protected void lbt_RegistrationDataShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationDataShow_Click(object sender, EventArgs e) {
			this.tbl_RegistrationData.Visible = true;
			this.lbt_RegistrationDataHide.Visible = true;
			this.lbt_RegistrationDataShow.Enabled = false;

			this.btn_RegistrationEMailCancel_Click(null, null);
			this.btn_RegistrationPasswordCancel_Click(null, null);
		}
		#endregion
		#region protected void lbt_RegistrationDataHide_Click(object sender, EventArgs e);
		protected void lbt_RegistrationDataHide_Click(object sender, EventArgs e) {
			this.txt_Name.Text = this.hfi_Name.Value;
			//this.txt_Login.Text = this.hfi_Login.Value;

			this.tbl_RegistrationData.Visible = false;
			this.lbt_RegistrationDataHide.Visible = false;
			this.lbt_RegistrationDataShow.Enabled = true;
		}
		#endregion
		#region protected void btn_RegistrationDataCancel_Click(object sender, EventArgs e);
		protected void btn_RegistrationDataCancel_Click(object sender, EventArgs e) {
			this.lbt_RegistrationDataHide_Click(null, null);
		}
		#endregion
		#region protected void btn_RegistrationDataUpdate_Click(object sender, EventArgs e);
		protected void btn_RegistrationDataUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;

			this.txt_Name.Text = this.txt_Name.Text.Trim();

			if (string.IsNullOrEmpty(this.txt_Name.Text)) {
				this.lbl_Name.Text = "invalid";
				this.lbl_Name.Visible = true;
				_foundErrors = true;
			} else if (
				this.txt_Name.Text == this.hfi_Name.Value
			) {
				this.lbl_Name.Text = "no changes";
				this.lbl_Name.Visible = true;
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
					this.txt_Name.Text, 

					out _errors
				);

				if (!this.Master__base.Error_add(_errors)) {
					this.hfi_Name.Value = this.txt_Name.Text;
					this.lbt_RegistrationDataHide_Click(null, null);
				}
			}
		}
		#endregion

		#region protected void lbt_RegistrationEMailShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationEMailShow_Click(object sender, EventArgs e) {
			this.tbl_RegistrationEMail.Visible = true;
			this.lbt_RegistrationEMailHide.Visible = true;
			this.lbt_RegistrationEMailShow.Enabled = false;
			//this.lbt_RegistrationEMailShow.CssClass = "vermais";

			this.btn_RegistrationDataCancel_Click(null, null);
			this.btn_RegistrationPasswordCancel_Click(null, null);
		}
		#endregion
		#region protected void lbt_RegistrationEMailHide_Click(object sender, EventArgs e);
		protected void lbt_RegistrationEMailHide_Click(object sender, EventArgs e) {
			this.txt_EMail.Text = this.hfi_EMail.Value;

			this.tbl_RegistrationEMail.Visible = false;
			this.lbt_RegistrationEMailHide.Visible = false;
			this.lbt_RegistrationEMailShow.Enabled = true;
			//this.lbt_RegistrationEMailShow.CssClass = "titulo_branco";
		}
		#endregion
		#region protected void btn_RegistrationEMailCancel_Click(object sender, EventArgs e);
		protected void btn_RegistrationEMailCancel_Click(object sender, EventArgs e) {
			this.lbt_RegistrationEMailHide_Click(null, null);
		}
		#endregion
		#region protected void btn_RegistrationEMailUpdate_Click(object sender, EventArgs e);
		protected void btn_RegistrationEMailUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;

			this.txt_EMail.Text = this.txt_EMail.Text.Trim();

			if (
				!OGen.lib.mail.utils.isEMail_valid(
					this.txt_EMail.Text
				)
			) {
				this.lbl_EMail.Text = "invalid";
				this.lbl_EMail.Visible = true;
				_foundErrors = true;
			} else if (
				this.txt_EMail.Text == this.hfi_EMail.Value
			) {
				this.lbl_EMail.Text = "no changes";
				this.lbl_EMail.Visible = true;
				_foundErrors = true;
			} 
			#endregion

			if (!_foundErrors) {
				int[] _errors;
				WEB_User.InstanceClient.updObject_EMail(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					this.txt_EMail.Text,
					ConfigurationManager.AppSettings[
						"CompanyName"
					],
					ConfigurationManager.AppSettings[
						"Registration_confirmEMail"
					],

					out _errors
				);
				if (!this.Master__base.Error_add(_errors)) {

// ToDos: here! // mail hasn't been changed yet, waiting user confirmation, hence comment:
//this.hfi_EMail.Value = txt_EMail.Text;

					this.lbt_RegistrationEMailHide_Click(null, null);
				}
			}
		}
		#endregion

		#region protected void lbt_RegistrationPasswordShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationPasswordShow_Click(object sender, EventArgs e) {
			this.tbl_RegistrationPassword.Visible = true;
			this.lbt_RegistrationPasswordHide.Visible = true;
			this.lbt_RegistrationPasswordShow.Enabled = false;

			this.btn_RegistrationDataCancel_Click(null, null);
			this.btn_RegistrationEMailCancel_Click(null, null);
		}
		#endregion
		#region protected void lbt_RegistrationPasswordHide_Click(object sender, EventArgs e);
		protected void lbt_RegistrationPasswordHide_Click(object sender, EventArgs e) {
			this.txt_Password.Text = ""; // this.hfi_Password.Value;

			this.tbl_RegistrationPassword.Visible = false;
			this.lbt_RegistrationPasswordHide.Visible = false;
			this.lbt_RegistrationPasswordShow.Enabled = true;
		}
		#endregion
		#region protected void btn_RegistrationPasswordCancel_Click(object sender, EventArgs e);
		protected void btn_RegistrationPasswordCancel_Click(object sender, EventArgs e) {
			this.lbt_RegistrationPasswordHide_Click(null, null);
		}
		#endregion
		#region protected void btn_RegistrationPasswordUpdate_Click(object sender, EventArgs e);
		protected void btn_RegistrationPasswordUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;
			if ((this.txt_Password.Text = this.txt_Password.Text.Trim()).Length == 0) {
				this.lbl_Password.Text = "invalid";
				this.lbl_Password.Visible = true;

				_foundErrors = true;
			}
			if ((this.txt_PasswordNew.Text = this.txt_PasswordNew.Text.Trim()).Length == 0) {
				this.lbl_PasswordNew.Text = "invalid";
				this.lbl_PasswordNew.Visible = true;

				_foundErrors = true;
			} else if (this.txt_Password.Text == this.txt_PasswordNew.Text) {
				this.lbl_PasswordNew.Text = "no changes";
				this.lbl_PasswordNew.Visible = true;

				_foundErrors = true;
			}
			if (this.txt_PasswordNew.Text != this.txt_PasswordConfirm.Text) {
				this.lbl_PasswordConfirm.Text = "passwords differ";
				this.lbl_PasswordConfirm.Visible = true;

				_foundErrors = true;
			}
			#endregion
			if (!_foundErrors) {
				int[] _errors;
				CRD_Authentication.InstanceClient.ChangePassword(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					this.txt_Password.Text,
					this.txt_PasswordNew.Text,
					out _errors
				);

				if (
					ErrorType.hasError(
						ErrorType.authentication__change_password__wrong_password, 
						_errors
					)
				) {
					this.lbl_Password.Text = "wrong password";
					this.lbl_Password.Visible = true;
				} else {
					if (!this.Master__base.Error_add(_errors)) {
						this.lbt_RegistrationPasswordHide_Click(null, null);
					}
				}
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			if (!utils.User.isLoggedIn) {
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
				this.txt_Name.Text
					= this.hfi_Name.Value
					= _user.Name;
				this.txt_Login.Text
					= this.hfi_Login.Value
					= utils.User.Login;

				this.txt_EMail.Text
					= this.hfi_EMail.Value
					= _user.EMail;
			} else {
				this.txt_Name.Text
					= this.hfi_Name.Value
					= "";
				this.txt_Login.Text
					= this.hfi_Login.Value
					= "";

				this.txt_EMail.Text
					= this.hfi_EMail.Value
					= "";
			}
		}
		#endregion
	}
}