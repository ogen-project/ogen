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
	public partial class _base : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {
			//Error_clear();

			if (!Page.IsPostBack) {
				Bind();
			}
		}

		protected void btn_Logout_Click(object sender, EventArgs e) {
			txt_EMail.Text = "";
			txt_Password.Text = "";

			utils.User.Logout("~/Default.aspx", false);

			Bind();
		}
		protected void btn_Login_Click(object sender, EventArgs e) {
			System.Text.StringBuilder _sb = null;

			bool _hasErrors = false;

			utils.User.DoLogin(
				txt_EMail.Text,
				txt_Password.Text,
				delegate(
					string message_in,
					bool isError_in
				) {
					if (_sb == null) _sb = new System.Text.StringBuilder();

					_sb.Append(string.Format(
						"<div class='label_{0}'>&bull; {1}</div>",
						isError_in ? "error" : "warning",
						message_in
					));

					if (isError_in) _hasErrors = true;
				}
			);

			if (_sb != null) {
				lbl_Log.Text = _sb.ToString();
			}

			if (!_hasErrors) {
				string _query = HttpContext.Current.Request.QueryString.ToString();
				Response.Redirect(string.Format(
					"{0}{1}{2}", 
					HttpContext.Current.Request.Params["PATH_INFO"],
					(_query != "") ? "?" : "", 
					_query
				));
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
		#region public void Error_clear();
		public void Error_clear() {
			lbl_Log.Text = "";
		}
		#endregion
		#region public bool Error_show(...);
		public bool Error_show(
			params int[] errors_in
		) {
			if (
				(errors_in == null)
				||
				(errors_in.Length == 0)
			) {
				return false;
			}

			System.Text.StringBuilder _sb = null;

			bool _output = ErrorType.hasErrors(
				errors_in,
				delegate(
					string message_in,
					bool isError_in
				) {
					if (_sb == null)
						_sb = new System.Text.StringBuilder();

					_sb.Append(string.Format(
						"<div class='label_{0}'>&bull; {1}</div>",
						isError_in ? "error" : "warning",
						message_in
					));
				}
			);
			if (_sb != null) { lbl_Log.Text += _sb.ToString(); }

			return _output;
		}
		public void Error_show(
			bool isError_in,
			string format_in,
			params object[] args_in
		) {
			lbl_Log.Text += string.Format(
				"<div class='label_{0}'>&bull; {1}</div>",
				isError_in ? "error" : "warning",
				string.Format(
					format_in,
					args_in
				)
			);
		}
		#endregion
	}
}