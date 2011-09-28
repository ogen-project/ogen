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
			if (!utils.User.isLoggedIn) {
				Response.Redirect(
					"~/Registration.aspx",
					true
				);

				return;
			}



			tcl_RegistrationPassword_Error.Text = "";		tbl_RegistrationPassword_Error.Visible = false;
			//---
			tcl_RegistrationEMail_Error.Text = "";			tbl_RegistrationEMail_Error.Visible = false;
			//---
			tcl_RegistrationData_Error.Text = "";			tbl_RegistrationData_Error.Visible = false;
			//===
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
			//lbt_RegistrationDataShow.CssClass = "vermais";

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
			//lbt_RegistrationDataShow.CssClass = "titulo_branco";
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

				tbl_RegistrationData_Error.Visible = (_errors.Length > 0);
				tcl_RegistrationData_Error.Text = (tbl_RegistrationData_Error.Visible) ? "<ul>" : "";
				if (!ErrorType.hasErrors(
					_errors,
					delegate(
						string message_in,
						bool isError_in
					) {
						tcl_RegistrationData_Error.Text += string.Format(
							"<li class='{0}'>{1}</li>",
							isError_in ? "error" : "no_error",
							message_in
						);
					}
				)) {
					hfi_Name.Value = txt_Name.Text;
					lbt_RegistrationDataHide_Click(null, null);
				}
				if (tbl_RegistrationData_Error.Visible) {
					tcl_RegistrationData_Error.Text += "</ul>";
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

				tbl_RegistrationEMail_Error.Visible = (_errors.Length > 0);
				tcl_RegistrationEMail_Error.Text = (tbl_RegistrationEMail_Error.Visible) ? "<ul>" : "";
				if (!ErrorType.hasErrors(
					_errors,
					delegate(
						string message_in,
						bool isError_in
					) {
						tcl_RegistrationEMail_Error.Text += string.Format(
							"<li class='{0}'>{1}</li>",
							isError_in ? "error" : "no_error",
							message_in
						);
					}
				)) {

// ToDos: here! // mail hasn't been changed yet, waiting user confirmation, hence comment:
//hfi_EMail.Value = txt_EMail.Text;

					lbt_RegistrationEMailHide_Click(null, null);
				}
				if (tbl_RegistrationEMail_Error.Visible) {
					tcl_RegistrationEMail_Error.Text += "</ul>";
				}
			}
		}
		#endregion

		#region protected void lbt_RegistrationPasswordShow_Click(object sender, EventArgs e);
		protected void lbt_RegistrationPasswordShow_Click(object sender, EventArgs e) {
			tbl_RegistrationPassword.Visible = true;
			lbt_RegistrationPasswordHide.Visible = true;
			lbt_RegistrationPasswordShow.Enabled = false;
			//lbt_RegistrationPasswordShow.CssClass = "vermais";

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
			//lbt_RegistrationPasswordShow.CssClass = "titulo_branco";
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

				tbl_RegistrationPassword_Error.Visible = (_errors.Length > 0);
				tcl_RegistrationPassword_Error.Text = (tbl_RegistrationPassword_Error.Visible) ? "<ul>" : "";
				if (!ErrorType.hasErrors(
					_errors,
					delegate(
						string message_in, 
						bool isError_in
					) {
						tcl_RegistrationPassword_Error.Text += string.Format(
							"<li class='{0}'>{1}</li>", 
							isError_in ? "error" : "no_error", 
							message_in
						);
					}
				)) {
					lbt_RegistrationPasswordHide_Click(null, null);
				}
				if (tbl_RegistrationPassword_Error.Visible) {
					tcl_RegistrationPassword_Error.Text += "</ul>";
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

			txt_Name.Text
				= hfi_Name.Value
				= _user.Name;
			txt_Login.Text
				= hfi_Login.Value
				= utils.User.Login;

			txt_EMail.Text
				= hfi_EMail.Value
				= _user.EMail;
		}
		#endregion
	}
}