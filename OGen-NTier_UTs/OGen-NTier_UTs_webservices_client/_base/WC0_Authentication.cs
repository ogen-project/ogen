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
using OGen.NTier.lib.distributedlayer.webservices.client;

using OGen.NTier.UTs.lib.distributedlayer.webservices.client;
using OGen.NTier.UTs.lib.businesslayer.proxy;

namespace OGen.NTier.UTs.lib.distributedlayer.webservices.client.WC_Authentication {
	/// <summary>
	/// Authentication web service client.
	/// </summary>
	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_AuthenticationSoap", 
		Namespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server"
	)]
	public abstract class WC0_Authentication : WC__base {
		#region public WC0_Authentication(...);
		public WC0_Authentication(
			string url_in
		) : base(
			url_in
		) {
		}
		#endregion

		#region public string Login(...);
		#if !NET_1_1
		private System.Threading.SendOrPostCallback LoginOperationCompleted;
		/// <remarks/>
		public event LoginCompletedEventHandler LoginCompleted;
		#endif

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributedlayer.webservices.server/Login", 
			RequestNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
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

		#if !NET_1_1
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
		#else
		/// <remarks/>
		public System.IAsyncResult BeginLogin(
			string login_in, 
			string password_in, 
			System.AsyncCallback callback, 
			object asyncState
		) {
			return this.BeginInvoke(
				"Login", 
				new object[] {
					login_in,
					password_in
				}, 
				callback, 
				asyncState
			);
		}

		/// <remarks/>
		public string EndLogin(
			System.IAsyncResult asyncResult
		) {
			object[] results = this.EndInvoke(asyncResult);
			return (string)results[0];
		}
		#endif
		#endregion
		#region public void Logout(...);
		#if !NET_1_1
		private System.Threading.SendOrPostCallback LogoutOperationCompleted;
		/// <remarks/>
		public event LogoutCompletedEventHandler LogoutCompleted;
		#endif

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributedlayer.webservices.server/Logout", 
			RequestNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Logout() {
			this.Invoke(
				"Logout", 
				new object[] {}
			);
		}

		#if !NET_1_1
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
		#else
		/// <remarks/>
		public System.IAsyncResult BeginLogout(
			System.AsyncCallback callback, 
			object asyncState
		) {
			return this.BeginInvoke(
				"Logout", 
				new object[0], 
				callback, 
				asyncState
			);
		}

		/// <remarks/>
		public void EndLogout(
			System.IAsyncResult asyncResult
		) {
			this.EndInvoke(asyncResult);
		}
		#endif
		#endregion
	}

	#if !NET_1_1
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
		private object[] results;

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
	#endif
}
