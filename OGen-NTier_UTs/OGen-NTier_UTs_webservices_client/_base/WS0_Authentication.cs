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
using OGen.NTier.UTs.lib.distributed.webservices.client;

namespace OGen.NTier.UTs.lib.distributed.webservices.client.WS_Authentication {
	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_AuthenticationSoap", 
		Namespace = "http://OGen.NTier.UTs.distributed.webservices"
	)]
	public abstract class WS0_Authentication : WS__base {
		#region public WS0_Authentication(...);
		public WS0_Authentication(
			string url_in
		) : base(
			url_in
		) {
		}
		#endregion

		#region public string Login(...);
		private System.Threading.SendOrPostCallback LoginOperationCompleted;
		/// <remarks/>
		public event LoginCompletedEventHandler LoginCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributed.webservices/Login", 
			RequestNamespace = "http://OGen.NTier.UTs.distributed.webservices", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributed.webservices", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public string Login(
			string login_in,
			string password_in
		) {
			object[] results = this.Invoke(
				"Login", 
				new object[] {
					login_in, 
					password_in
				}
			);
			return (string)results[0];
		}

		/// <remarks/>
		public void LoginAsync(
			string login_in, 
			string password_in
		) {
			this.LoginAsync(
				login_in, 
				password_in, 
				null
			);
		}

		/// <remarks/>
		public void LoginAsync(
			string login_in, 
			string password_in, 
			object userState
		) {
			if (this.LoginOperationCompleted == null) {
				this.LoginOperationCompleted 
					= new System.Threading.SendOrPostCallback(
						this.OnLoginOperationCompleted
					);
			}
			this.InvokeAsync(
				"Login", 
				new object[] {
					login_in,
                    password_in
				}, 
				this.LoginOperationCompleted, 
				userState
			);
		}

		private void OnLoginOperationCompleted(object arg) {
			if (this.LoginCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs
					= (System.Web.Services.Protocols.InvokeCompletedEventArgs)arg;
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
		#endregion
		#region public void Logout(...);
		private System.Threading.SendOrPostCallback LogoutOperationCompleted;
		/// <remarks/>
		public event LogoutCompletedEventHandler LogoutCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributed.webservices/Logout", 
			RequestNamespace = "http://OGen.NTier.UTs.distributed.webservices", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributed.webservices", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Logout() {
			this.Invoke(
				"Logout", 
				new object[] {}
			);
		}

		/// <remarks/>
		public void LogoutAsync() {
			this.LogoutAsync(
				null
			);
		}

		/// <remarks/>
		public void LogoutAsync(
			object userState
		) {
			if (this.LogoutOperationCompleted == null) {
				this.LogoutOperationCompleted 
					= new System.Threading.SendOrPostCallback(
						this.OnLogoutOperationCompleted
					);
			}
			this.InvokeAsync(
				"Logout", 
				new object[0], 
				this.LogoutOperationCompleted, 
				userState
			);
		}

		private void OnLogoutOperationCompleted(object arg) {
			if (this.LogoutCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs
					= (System.Web.Services.Protocols.InvokeCompletedEventArgs)arg;
				this.LogoutCompleted(
					this,
					new System.ComponentModel.AsyncCompletedEventArgs(
						invokeArgs.Error,
						invokeArgs.Cancelled,
						invokeArgs.UserState
					)
				);
			}
		}
		#endregion
	}

	#region ...Login...
	/// <remarks/>
	public delegate void LoginCompletedEventHandler(
		object sender,
		LoginCompletedEventArgs e
	);

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public class LoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		internal LoginCompletedEventArgs(
			object[] results,
			System.Exception exception,
			bool cancelled,
			object userState
		) : base(
			exception,
			cancelled,
			userState
		) {
			this.results = results;
		}

		private object[] results;

		/// <remarks/>
		public string Result {
			get {
				this.RaiseExceptionIfNecessary();
				return (string)this.results[0];
			}
		}
	}
	#endregion
	#region ...Logout...
	/// <remarks/>
	public delegate void LogoutCompletedEventHandler(
		object sender,
		System.ComponentModel.AsyncCompletedEventArgs e
	);
	#endregion
}