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
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.instances;
using OGen.NTier.Kick.lib.presentationlayer.weblayer;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class Registration_update : SitePage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!utils.User.isLoggedIn) {
				Response.Redirect(
					"~/Registration.aspx",
					true
				);

				return;
			}



			lbl_Password.Text = "";							lbl_Password.Visible = false;
			lbl_PasswordNew.Text = "";						lbl_PasswordNew.Visible = false;
			lbl_PasswordConfirm.Text = "";					lbl_PasswordConfirm.Visible = false;
			//---
			lbl_EMail.Text = "";							lbl_EMail.Visible = false;
			//---
			lbl_Name.Text = "";								lbl_Name.Visible = false;



			if (!Page.IsPostBack) {
				Bind();
			}
		}
		#endregion

		#region protected void lbt_RegistrationDataShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationDataShow_Click(object sender, EventArgs e) {
			tbl_RegistrationData.Visible = true;
			lbt_RegistrationDataHide.Visible = true;
			lbt_RegistrationDataShow.Enabled = false;

			btn_RegistrationEMailCancel_Click(null, null);
			btn_RegistrationPasswordCancel_Click(null, null);
		}
		#endregion
		#region protected void lbt_RegistrationDataHide_Click(object sender, EventArgs e);
		protected void lbt_RegistrationDataHide_Click(object sender, EventArgs e) {
			txt_Name.Text = hfi_Name.Value;
			//txt_Login.Text = hfi_Login.Value;

			tbl_RegistrationData.Visible = false;
			lbt_RegistrationDataHide.Visible = false;
			lbt_RegistrationDataShow.Enabled = true;
		}
		#endregion
		#region protected void btn_RegistrationDataCancel_Click(object sender, EventArgs e);
		protected void btn_RegistrationDataCancel_Click(object sender, EventArgs e) {
			lbt_RegistrationDataHide_Click(null, null);
		}
		#endregion
		#region protected void btn_RegistrationDataUpdate_Click(object sender, EventArgs e);
		protected void btn_RegistrationDataUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;

			txt_Name.Text = txt_Name.Text.Trim();

			if (txt_Name.Text == "") {
				lbl_Name.Text = "invalid";
				lbl_Name.Visible = true;
				_foundErrors = true;
			} else if (
				txt_Name.Text == hfi_Name.Value
			) {
				lbl_Name.Text = "no changes";
				lbl_Name.Visible = true;
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
					txt_Name.Text, 

					out _errors
				);

				if (!Master__base.Error_show(_errors)) {
					hfi_Name.Value = txt_Name.Text;
					lbt_RegistrationDataHide_Click(null, null);
				}
			}
		}
		#endregion

		#region protected void lbt_RegistrationEMailShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationEMailShow_Click(object sender, EventArgs e) {
			tbl_RegistrationEMail.Visible = true;
			lbt_RegistrationEMailHide.Visible = true;
			lbt_RegistrationEMailShow.Enabled = false;
			//lbt_RegistrationEMailShow.CssClass = "vermais";

			btn_RegistrationDataCancel_Click(null, null);
			btn_RegistrationPasswordCancel_Click(null, null);
		}
		#endregion
		#region protected void lbt_RegistrationEMailHide_Click(object sender, EventArgs e);
		protected void lbt_RegistrationEMailHide_Click(object sender, EventArgs e) {
			txt_EMail.Text = hfi_EMail.Value;

			tbl_RegistrationEMail.Visible = false;
			lbt_RegistrationEMailHide.Visible = false;
			lbt_RegistrationEMailShow.Enabled = true;
			//lbt_RegistrationEMailShow.CssClass = "titulo_branco";
		}
		#endregion
		#region protected void btn_RegistrationEMailCancel_Click(object sender, EventArgs e);
		protected void btn_RegistrationEMailCancel_Click(object sender, EventArgs e) {
			lbt_RegistrationEMailHide_Click(null, null);
		}
		#endregion
		#region protected void btn_RegistrationEMailUpdate_Click(object sender, EventArgs e);
		protected void btn_RegistrationEMailUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;

			txt_EMail.Text = txt_EMail.Text.Trim();

			if (
				!OGen.lib.mail.utils.isEMail_valid(
					txt_EMail.Text
				)
			) {
				lbl_EMail.Text = "invalid";
				lbl_EMail.Visible = true;
				_foundErrors = true;
			} else if (
				txt_EMail.Text == hfi_EMail.Value
			) {
				lbl_EMail.Text = "no changes";
				lbl_EMail.Visible = true;
				_foundErrors = true;
			} 
			#endregion

			if (!_foundErrors) {
				int[] _errors;
				WEB_User.InstanceClient.updObject_EMail(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					txt_EMail.Text,
					ConfigurationManager.AppSettings[
						"CompanyName"
					],
					ConfigurationManager.AppSettings[
						"Registration_confirmEMail"
					],

					out _errors
				);
				if (!Master__base.Error_show(_errors)) {

// ToDos: here! // mail hasn't been changed yet, waiting user confirmation, hence comment:
//hfi_EMail.Value = txt_EMail.Text;

					lbt_RegistrationEMailHide_Click(null, null);
				}
			}
		}
		#endregion

		#region protected void lbt_RegistrationPasswordShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationPasswordShow_Click(object sender, EventArgs e) {
			tbl_RegistrationPassword.Visible = true;
			lbt_RegistrationPasswordHide.Visible = true;
			lbt_RegistrationPasswordShow.Enabled = false;

			btn_RegistrationDataCancel_Click(null, null);
			btn_RegistrationEMailCancel_Click(null, null);
		}
		#endregion
		#region protected void lbt_RegistrationPasswordHide_Click(object sender, EventArgs e);
		protected void lbt_RegistrationPasswordHide_Click(object sender, EventArgs e) {
			txt_Password.Text = ""; // hfi_Password.Value;

			tbl_RegistrationPassword.Visible = false;
			lbt_RegistrationPasswordHide.Visible = false;
			lbt_RegistrationPasswordShow.Enabled = true;
		}
		#endregion
		#region protected void btn_RegistrationPasswordCancel_Click(object sender, EventArgs e);
		protected void btn_RegistrationPasswordCancel_Click(object sender, EventArgs e) {
			lbt_RegistrationPasswordHide_Click(null, null);
		}
		#endregion
		#region protected void btn_RegistrationPasswordUpdate_Click(object sender, EventArgs e);
		protected void btn_RegistrationPasswordUpdate_Click(object sender, EventArgs e) {
			#region bool _foundErrors = ...;
			bool _foundErrors = false;
			if ((txt_Password.Text = txt_Password.Text.Trim()) == "") {
				lbl_Password.Text = "invalid";
				lbl_Password.Visible = true;

				_foundErrors = true;
			}
			if ((txt_PasswordNew.Text = txt_PasswordNew.Text.Trim()) == "") {
				lbl_PasswordNew.Text = "invalid";
				lbl_PasswordNew.Visible = true;

				_foundErrors = true;
			} else if (txt_Password.Text == txt_PasswordNew.Text) {
				lbl_PasswordNew.Text = "no changes";
				lbl_PasswordNew.Visible = true;

				_foundErrors = true;
			}
			if (txt_PasswordNew.Text != txt_PasswordConfirm.Text) {
				lbl_PasswordConfirm.Text = "passwords differ";
				lbl_PasswordConfirm.Visible = true;

				_foundErrors = true;
			}
			#endregion
			if (!_foundErrors) {
				int[] _errors;
				CRD_Authentication.InstanceClient.ChangePassword(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					txt_Password.Text,
					txt_PasswordNew.Text,
					out _errors
				);

				if (
					ErrorType.hasError(
						ErrorType.authentication__change_password__wrong_password, 
						_errors
					)
				) {
					lbl_Password.Text = "wrong password";
					lbl_Password.Visible = true;
				} else {
					if (!Master__base.Error_show(_errors)) {
						lbt_RegistrationPasswordHide_Click(null, null);
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
			if (!Master__base.Error_show(_errors)) {
				txt_Name.Text
					= hfi_Name.Value
					= _user.Name;
				txt_Login.Text
					= hfi_Login.Value
					= utils.User.Login;

				txt_EMail.Text
					= hfi_EMail.Value
					= _user.EMail;
			} else {
				txt_Name.Text
					= hfi_Name.Value
					= "";
				txt_Login.Text
					= hfi_Login.Value
					= "";

				txt_EMail.Text
					= hfi_EMail.Value
					= "";
			}
		}
		#endregion
	}
}