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
	using System.Text;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.PresentationLayer.WebLayer;

	public partial class _base : System.Web.UI.MasterPage {
		protected void Page_Load(object sender, EventArgs e) {
			Anthem.Manager.Register(this);

			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}
		protected override void OnPreRender(EventArgs e) {
			this.error_show();

			base.OnPreRender(e);
		}

		#region private void error_show();
		#region private StringBuilder errors { get; }
		private StringBuilder errors__ = null;

		private StringBuilder errors {
			get {
				if (this.errors__ == null) {
					this.errors__ = new StringBuilder();
				}
				return this.errors__;
			}
		}
		#endregion
		#region private StringBuilder warnings { get; }
		private StringBuilder warnings__ = null;

		private StringBuilder warnings {
			get {
				if (this.warnings__ == null) {
					this.warnings__ = new StringBuilder();
				}
				return this.warnings__;
			}
		}
		#endregion

		private void error_show() {
			if (
				(this.errors__ == null)
				&&
				(this.warnings__ == null)
			) {
				return;
			}

			string _clientscript = string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"alert('{0}{1}');",
				(this.errors__ != null) ? string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"--- Errors:\\n{0}\\n",
					this.errors__.ToString()
				) : "",
				(this.warnings__ != null) ? string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"--- Warnings:\\n{0}",
					this.warnings__.ToString()
				) : ""
			);
			if (Anthem.Manager.IsCallBack) {
				Anthem.Manager.AddScriptForClientSideEval(_clientscript);
			} else {
				this.LIT_ClientScript.Text = _clientscript;
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
				System.Globalization.CultureInfo.CurrentCulture,
				"- {0}\\n",
				string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
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
						this.errors.Append(this.error_formatmessage(
							message_in
						));
					} else {
						this.warnings.Append(this.error_formatmessage(
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
				this.errors.Append(this.error_formatmessage(
					format_in,
					args_in
				));
			} else {
				this.warnings.Append(this.error_formatmessage(
					format_in,
					args_in
				));
			}
		}
		#endregion

		#region protected void BTN_LogOff_Click(object sender, EventArgs e);
		protected void BTN_LogOff_Click(object sender, EventArgs e) {
			this.TXT_Email.Text = "";
			this.TXT_Password.Text = "";

			utils.User.LogOff("~/Default.aspx", false);

			this.Bind();
		}
		#endregion
		#region protected void BTN_LogOn_Click(object sender, EventArgs e);
		protected void BTN_LogOn_Click(object sender, EventArgs e) {
			int[] _errors;
			utils.User.LogOn(
				this.TXT_Email.Text,
				this.TXT_Password.Text,
				out _errors
			);

			if (!this.Error_add(_errors)) {
				string _query = HttpContext.Current.Request.QueryString.ToString();
				Response.Redirect(string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"{0}{1}{2}", 
					HttpContext.Current.Request.Params["PATH_INFO"],
					(string.IsNullOrEmpty(_query)) ? "" : "?", 
					_query
				));
			}

			this.Bind();
		}
		#endregion
		#region public void Bind();
		public void Bind() {
			bool _isloggedin = utils.User.IsLoggedIn;

			this.LBT_Registration.Text = (_isloggedin) ? utils.User.Login : "anonynous";
			this.LBT_Registration.PostBackUrl = (_isloggedin) ? "~/Registration-update.aspx" : "~/Registration.aspx";

			this.LBL_Email.Visible = !_isloggedin;
			this.TXT_Email.Visible = !_isloggedin;
			this.LBL_Password.Visible = !_isloggedin;
			this.TXT_Password.Visible = !_isloggedin;
			this.BTN_LogOn.Visible = !_isloggedin;

			this.BTN_LogOff.Visible = _isloggedin;
		}
		#endregion
	}
}