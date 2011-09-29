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
	public partial class Registration_changePassword : SitePage {
		protected void Page_Load(object sender, EventArgs e) {
			lbl_PasswordNew.Text = "";					lbl_PasswordNew.Visible = false;
			lbl_PasswordConfirm.Text = "";				lbl_PasswordConfirm.Visible = false;
		}
		protected void lbt_RegistrationPasswordUpdate_Click(object sender, EventArgs e) {
			int[] _errors;

			#region bool _foundErrors = ...;
			bool _foundErrors = false;
			if ((txt_PasswordNew.Text = txt_PasswordNew.Text.Trim()) == "") {
				lbl_PasswordNew.Text = "invalid";
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
				if (utils.User.DoLogin_throughLink_andChangePassword(
					txt_PasswordNew.Text,
					out _errors
				)) {
					Response.Redirect("~/Default.aspx");
				} else {
					Master__base.Error_show(_errors);
				}
			}
		}
	}
}