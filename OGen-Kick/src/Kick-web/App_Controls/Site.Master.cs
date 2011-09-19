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

using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.presentationlayer.weblayer;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class Site : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				Bind();
			}
		}

		protected void btn_Logout_Click(object sender, EventArgs e) {
			utils.User.Logout(false);

			Bind();
		}
		protected void btn_Login_Click(object sender, EventArgs e) {
			System.Text.StringBuilder _sb = null;

			utils.User.DoLogin(
				txt_EMail.Text,
				txt_Password.Text,
				delegate(
					string message_in,
					bool isError_in
				) {
					if (_sb == null) _sb = new System.Text.StringBuilder();
					_sb.Append(string.Format(
						"<div class='{0}'>{1}</div>",
						isError_in ? "label_error" : "label_warning", 
						message_in
					));
				}
			);

			if (_sb != null) {
				lbl_Log.Text = _sb.ToString();
			}

			Bind();
		}

		public void Bind() {
			bool _isloggedin = utils.User.isLoggedIn;

			lbl_Welcome.Text = (_isloggedin) ? utils.User.Login : "anonynous";

			lbl_EMail.Visible = !_isloggedin;
			txt_EMail.Visible = !_isloggedin;
			lbl_Password.Visible = !_isloggedin;
			txt_Password.Visible = !_isloggedin;
			btn_Login.Visible = !_isloggedin;

			btn_Logout.Visible = _isloggedin;
		}
	}
}