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

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Instances;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.PresentationLayer.WebLayer;

	public partial class Registration_changePassword : SitePage {
		protected void Page_Load(object sender, EventArgs e) {
			this.LBL_PasswordNew.Text = "";     this.LBL_PasswordNew.Visible = false;
			this.LBL_PasswordConfirm.Text = ""; this.LBL_PasswordConfirm.Visible = false;
		}
		protected void LBT_RegistrationPasswordUpdate_Click(object sender, EventArgs e) {
			int[] _errors;

			#region bool _foundErrors = ...;
			bool _foundErrors = false;
			if ((this.TXT_PasswordNew.Text = this.TXT_PasswordNew.Text.Trim()).Length == 0) {
				this.LBL_PasswordNew.Text = "invalid";
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
				if (Utilities.User.LogOn_throughLink_andChangePassword(
					this.TXT_PasswordNew.Text,
					out _errors
				)) {
					Response.Redirect("~/Default.aspx");
				} else {
					this.Master__base.Error_add(_errors);
				}
			}
		}
	}
}