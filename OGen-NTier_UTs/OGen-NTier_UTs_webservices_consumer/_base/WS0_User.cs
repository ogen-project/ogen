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
using OGen.NTier.UTs.lib.distributed.webservices.consumer;

namespace OGen.NTier.UTs.lib.distributed.webservices.consumer.WS_User {
	/// <remarks/>
	public delegate void insObjectCompletedEventHandler(
		object sender, 
		insObjectCompletedEventArgs e
	);

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public class insObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		internal insObjectCompletedEventArgs(
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
		public long Result {
			get {
				this.RaiseExceptionIfNecessary();
				return (long)this.results[0];
			}
		}

		/// <remarks/>
		public bool constraintExist_out {
			get {
				this.RaiseExceptionIfNecessary();
				return (bool)this.results[1];
			}
		}
	}

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_UserSoap", 
		Namespace = "http://OGen.NTier.UTs.distributed.webservices"
	)]
	public class WS0_User : WS__base {
		public WS0_User(
			string url_in
		) {
			this.Url = url_in;

			if (this.IsLocalFileSystemWebService(this.Url)) {
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			} else {
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		private System.Threading.SendOrPostCallback insObjectOperationCompleted;
		public event insObjectCompletedEventHandler insObjectCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributed.webservices/insObject", 
			RequestNamespace = "http://OGen.NTier.UTs.distributed.webservices", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributed.webservices", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in,
			out bool constraintExist_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					user_in, 
					selectIdentity_in
				}
			);
			constraintExist_out = (bool)results[1];
			return (long)results[0];
		}

		/// <remarks/>
		public void insObjectAsync(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in
		) {
			this.insObjectAsync(
				user_in,
				selectIdentity_in,
				null
			);
		}

		/// <remarks/>
		public void insObjectAsync(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in,
			object userState
		) {
			if (this.insObjectOperationCompleted == null) {
				this.insObjectOperationCompleted
					= new System.Threading.SendOrPostCallback(
						this.OninsObjectOperationCompleted
					);
			}
			this.InvokeAsync(
				"insObject",
				new object[] {
		            user_in,
		            selectIdentity_in
		        },
				this.insObjectOperationCompleted,
				userState
			);
		}

		private void OninsObjectOperationCompleted(object arg) {
			if (this.insObjectCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs
					= (System.Web.Services.Protocols.InvokeCompletedEventArgs)arg;
				this.insObjectCompleted(
					this,
					new insObjectCompletedEventArgs(
						invokeArgs.Results,
						invokeArgs.Error,
						invokeArgs.Cancelled,
						invokeArgs.UserState
					)
				);
			}
		}
	}
}