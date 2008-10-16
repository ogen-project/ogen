using System;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace OGen.NTier.UTs.lib.distributed.webservices.consumer {
	/// <remarks/>
	public delegate void insObjectCompletedEventHandler(object sender, insObjectCompletedEventArgs e);

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public class insObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		internal insObjectCompletedEventArgs(
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
		public long Result {
			get {
				this.RaiseExceptionIfNecessary();
				return ((long)(this.results[0]));
			}
		}

		/// <remarks/>
		public bool constraintExist_out {
			get {
				this.RaiseExceptionIfNecessary();
				return ((bool)(this.results[1]));
			}
		}
	}

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(Name = "WS_UserSoap", Namespace = "http://OGen.NTier.UTs.distributed.webservices")]
	public class WS_User : SoapHttpClientProtocol {
		public WS_User() {
			if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
				this.UseDefaultCredentials = true;
				this.useDefaultCredentialsSetExplicitly = false;
			} else {
				this.useDefaultCredentialsSetExplicitly = true;
			}
		}

		private System.Threading.SendOrPostCallback insObjectOperationCompleted;
		public event insObjectCompletedEventHandler insObjectCompleted;
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

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://OGen.NTier.UTs.distributed.webservices/insObject", RequestNamespace = "http://OGen.NTier.UTs.distributed.webservices", ResponseNamespace = "http://OGen.NTier.UTs.distributed.webservices", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
		public long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.ISO_User user_in,
			bool selectIdentity_in,
			out bool constraintExist_out
		) {
			object[] results = this.Invoke(
				"insObject", new object[] {
					user_in, 
					selectIdentity_in
				}
			);
			constraintExist_out = ((bool)(results[1]));
			return ((long)(results[0]));
		}

		/// <remarks/>
		public void insObjectAsync(
			OGen.NTier.UTs.lib.datalayer.proxy.ISO_User user_in,
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
			OGen.NTier.UTs.lib.datalayer.proxy.ISO_User user_in,
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
					= ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
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
