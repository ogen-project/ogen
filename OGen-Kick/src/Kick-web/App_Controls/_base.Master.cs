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
using System.Text;

using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.presentationlayer.weblayer;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class _base : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {
			Anthem.Manager.Register(this);

			if (!Page.IsPostBack) {
				Bind();
			}
		}
		protected override void OnPreRender(EventArgs e) {
			error_show();

			base.OnPreRender(e);
		}

		#region private void error_show();
		#region private StringBuilder errors { get; }
		private StringBuilder errors__ = null;

		private StringBuilder errors {
			get {
				if (errors__ == null) {
					errors__ = new StringBuilder();
				}
				return errors__;
			}
		}
		#endregion
		#region private StringBuilder warnings { get; }
		private StringBuilder warnings__ = null;

		private StringBuilder warnings {
			get {
				if (warnings__ == null) {
					warnings__ = new StringBuilder();
				}
				return warnings__;
			}
		}
		#endregion

		private void error_show() {
			if (
				(errors__ == null)
				&&
				(warnings__ == null)
			) {
				return;
			}

			string _clientscript = string.Format(
				"alert('{0}{1}');",
				(errors__ != null) ? string.Format(
					"--- Errors:\\n{0}\\n",
					errors__.ToString()
				) : "", 
				(warnings__ != null) ? string.Format(
					"--- Warnings:\\n{0}",
					warnings__.ToString()
				) : ""
			);
			if (Anthem.Manager.IsCallBack) {
				Anthem.Manager.AddScriptForClientSideEval(_clientscript);
			} else {
				lit_ClientScript.Text = _clientscript;
			}
		}
		#endregion

		#region public bool Error_add(...);
		#region private string error_formatmessage(...);
		private string error_formatmessage(
			string format_in,
			params object[] args_in
		) {
			return string.Format(
				"- {0}\\n",
				string.Format(
					format_in,
					args_in
				)
			);
		}
		#endregion

		public bool Error_add(
			params int[] errors_in
		) {
			if (
				(errors_in == null)
				||
				(errors_in.Length == 0)
			) {
				return false;
			}

			bool _output = ErrorType.hasErrors(
				errors_in,
				delegate(
					string message_in,
					bool isError_in
				) {
					if (isError_in) {
						errors.Append(error_formatmessage(
							message_in
						));
					} else {
						warnings.Append(error_formatmessage(
							message_in
						));
					}
				}
			);

			return _output;
		}

		public void Error_add(
			bool isError_in,
			string format_in,
			params object[] args_in
		) {
			if (isError_in) {
				errors.Append(error_formatmessage(
					format_in,
					args_in
				));
			} else {
				warnings.Append(error_formatmessage(
					format_in,
					args_in
				));
			}
		}
		#endregion

		#region protected void btn_Logout_Click(object sender, EventArgs e);
		protected void btn_Logout_Click(object sender, EventArgs e) {
			txt_EMail.Text = "";
			txt_Password.Text = "";

			utils.User.Logout("~/Default.aspx", false);

			Bind();
		}
		#endregion
		#region protected void btn_Login_Click(object sender, EventArgs e);
		protected void btn_Login_Click(object sender, EventArgs e) {
			int[] _errors;
			utils.User.DoLogin(
				txt_EMail.Text,
				txt_Password.Text,
				out _errors
			);

			if (!Error_add(_errors)) {
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
		#endregion
		#region public void Bind();
		public void Bind() {
			bool _isloggedin = utils.User.isLoggedIn;

			lbt_Registration.Text = (_isloggedin) ? utils.User.Login : "anonynous";
			lbt_Registration.PostBackUrl = (_isloggedin) ? "~/Registration-update.aspx" : "~/Registration.aspx";

			lbl_EMail.Visible = !_isloggedin;
			txt_EMail.Visible = !_isloggedin;
			lbl_Password.Visible = !_isloggedin;
			txt_Password.Visible = !_isloggedin;
			btn_Login.Visible = !_isloggedin;

			btn_Logout.Visible = _isloggedin;
		}
		#endregion
	}
}