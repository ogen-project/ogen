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
using System.Web.Services;
using System.Web.Services.Protocols;

namespace OGen.NTier.UTs.lib.distributed.webservices.consumer {
	/// <remarks/>
	public delegate void LoginCompletedEventHandler(object sender, LoginCompletedEventArgs e);

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		internal LoginCompletedEventArgs(
			object[] results,
			System.Exception exception,
			bool cancelled,
			object userState
		) :
			base(exception, cancelled, userState) {
			this.results = results;
		}

		private object[] results;

		/// <remarks/>
		public string Result {
			get {
				this.RaiseExceptionIfNecessary();
				return ((string)(this.results[0]));
			}
		}
	}

	/// <remarks/>
	public delegate void LogoutCompletedEventHandler(object sender, LogoutCompletedEventArgs e);

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public class LogoutCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		internal LogoutCompletedEventArgs(
			object[] results,
			System.Exception exception,
			bool cancelled,
			object userState
		) :
			base(exception, cancelled, userState) {
			this.results = results;
		}

		private object[] results;
	}

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(Name = "WS_AuthenticationSoap", Namespace = "http://OGen.NTier.UTs.distributed.webservices")]
	public class WS_Authentication : SoapHttpClientProtocol {
		public WS_Authentication() {
			if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			} else {
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		private bool useDefaultCredentialsSetExplicitly;

		#region public new string Url { get; set; }
		public new string Url {
			get {
				return base.Url;
			}
			set {
				if (
					(this.IsLocalFileSystemWebService(base.Url) == true)
					&&
					(this.useDefaultCredentialsSetExplicitly == false)
					&&
					(this.IsLocalFileSystemWebService(value) == false)
				) {
					base.UseDefaultCredentials = false;
				}
				base.Url = value;
			}
		}
		#endregion
		#region public new bool UseDefaultCredentials { get; set; }
		public new bool UseDefaultCredentials {
			get {
				return base.UseDefaultCredentials;
			}
			set {
				base.UseDefaultCredentials = value;
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}
		#endregion




		private System.Threading.SendOrPostCallback LoginOperationCompleted;
		public event LoginCompletedEventHandler LoginCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://OGen.NTier.UTs.distributed.webservices/Login", RequestNamespace = "http://OGen.NTier.UTs.distributed.webservices", ResponseNamespace = "http://OGen.NTier.UTs.distributed.webservices", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public string Login(
			string login_in,
			string password_in
		) {
			object[] results = this.Invoke(
				"Login", new object[] {
					login_in, 
					password_in
				}
			);
			return ((string)(results[0]));
		}

		private void OnLoginOperationCompleted(object arg) {
			if (this.LoginCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs
					= ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.LoginCompleted(
					this,
					new LoginCompletedEventArgs(
						invokeArgs.Results,
						invokeArgs.Error,
						invokeArgs.Cancelled,
						invokeArgs.UserState
					)
				);
			}
		}




		private System.Threading.SendOrPostCallback LogoutOperationCompleted;
		public event LogoutCompletedEventHandler LogoutCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://OGen.NTier.UTs.distributed.webservices/Logout", RequestNamespace = "http://OGen.NTier.UTs.distributed.webservices", ResponseNamespace = "http://OGen.NTier.UTs.distributed.webservices", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public void Logout() {
			object[] results = this.Invoke(
				"Logout", new object[] {}
			);
		}

		private void OnLogoutOperationCompleted(object arg) {
			if (this.LogoutCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs
					= ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
				this.LogoutCompleted(
					this,
					new LogoutCompletedEventArgs(
						invokeArgs.Results,
						invokeArgs.Error,
						invokeArgs.Cancelled,
						invokeArgs.UserState
					)
				);
			}
		}

		/// <remarks/>
		public new void CancelAsync(object userState) {
			base.CancelAsync(userState);
		}

		private bool IsLocalFileSystemWebService(string url) {
			if (
				(url == null)
				||
				(url == string.Empty)
			) {
				return false;
			}
			System.Uri wsUri = new System.Uri(url);
			if (
				(wsUri.Port >= 1024)
				&&
				(
					string.Compare(
						wsUri.Host,
						"localHost",
						System.StringComparison.OrdinalIgnoreCase
					) == 0
				)
			) {
				return true;
			}
			return false;
		}
	}
}