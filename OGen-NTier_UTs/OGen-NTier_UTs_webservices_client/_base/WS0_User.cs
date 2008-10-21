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
using OGen.NTier.UTs.lib.distributedlayer.webservices.client;
using OGen.NTier.UTs.lib.businesslayer.proxy;

namespace OGen.NTier.UTs.lib.distributedlayer.webservices.client.WS_User {
	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_UserSoap", 
		Namespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server"
	)]
	public abstract class WS0_User : WS__base, IBO_User {
		#region public WS0_User(...);
		public WS0_User(
			string url_in
		) : base(
			url_in
		) {
		}
		#endregion

		#region public long insObject(...);
		private System.Threading.SendOrPostCallback insObjectOperationCompleted;
		/// <remarks/>
		public event insObjectCompletedEventHandler insObjectCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributedlayer.webservices.server/insObject", 
			RequestNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in,
			string login_in, 
			out bool constraintExist_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					user_in, 
					selectIdentity_in, 
					login_in
				}
			);
			constraintExist_out = (bool)results[1];
			return (long)results[0];
		}

		/// <remarks/>
		public void insObjectAsync(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in, 
			string login_in
		) {
			this.insObjectAsync(
				user_in,
				selectIdentity_in,
				login_in, 
				null
			);
		}

		/// <remarks/>
		public void insObjectAsync(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in, 
			string login_in,
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
					selectIdentity_in, 
					login_in
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
		#endregion
		#region public OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(...);
		private System.Threading.SendOrPostCallback getObjectOperationCompleted;
		/// <remarks/>
		public event getObjectCompletedEventHandler getObjectCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributedlayer.webservices.server/getObject", 
			RequestNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(
			long idUser_in, 
			string login_in, 
			out bool exists_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					idUser_in, 
					login_in
				}
			);
			exists_out = (bool)results[1];
			return (OGen.NTier.UTs.lib.datalayer.proxy.SO_User)results[0];
		}

		/// <remarks/>
		public void getObjectAsync(
			long idUser_in, 
			string login_in
		) {
			this.getObjectAsync(
				idUser_in, 
				login_in, 
				null
			);
		}

		/// <remarks/>
		public void getObjectAsync(
			long idUser_in, 
			string login_in, 
			object userState
		) {
			if (this.getObjectOperationCompleted == null) {
				this.getObjectOperationCompleted 
					= new System.Threading.SendOrPostCallback(
						this.OngetObjectOperationCompleted
					);
			}
			this.InvokeAsync(
				"getObject", 
				new object[] { 
					idUser_in, 
					login_in
				}, 
				this.getObjectOperationCompleted, 
				userState
			);
		}

		private void OngetObjectOperationCompleted(object arg) {
			if (this.getObjectCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs 
					= (System.Web.Services.Protocols.InvokeCompletedEventArgs)arg;
				this.getObjectCompleted(
					this, 
					new getObjectCompletedEventArgs(
						invokeArgs.Results, 
						invokeArgs.Error, 
						invokeArgs.Cancelled, 
						invokeArgs.UserState
					)
				);
			}
		}
		#endregion
		#region public OGen.NTier.UTs.lib.datalayer.proxy.SO_User[] Record_Open_byGroup(...);
		private System.Threading.SendOrPostCallback Record_Open_byGroupOperationCompleted;
		/// <remarks/>
		public event Record_Open_byGroupCompletedEventHandler Record_Open_byGroupCompleted;

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.UTs.distributedlayer.webservices.server/Record_Open_byGroup", 
			RequestNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			ResponseNamespace = "http://OGen.NTier.UTs.distributedlayer.webservices.server", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User[] Record_Open_byGroup(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in, 
			string login_in
		) {
			object[] results = this.Invoke(
				"Record_Open_byGroup", 
				new object[] {
					IDGroup_search_in,
					page_in,
					page_numRecords_in,
					login_in
				}
			);
			return (OGen.NTier.UTs.lib.datalayer.proxy.SO_User[])results[0];
		}

		/// <remarks/>
		public void Record_Open_byGroupAsync(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in, 
			string login_in
		) {
			this.Record_Open_byGroupAsync(
				IDGroup_search_in, 
				page_in, 
				page_numRecords_in, 
				login_in, 
				null
			);
		}

		/// <remarks/>
		public void Record_Open_byGroupAsync(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in, 
			string login_in, 
			object userState
		) {
			if (this.Record_Open_byGroupOperationCompleted == null) {
				this.Record_Open_byGroupOperationCompleted 
					= new System.Threading.SendOrPostCallback(
						this.OnRecord_Open_byGroupOperationCompleted
					);
			}
			this.InvokeAsync(
				"Record_Open_byGroup", 
				new object[] {
					IDGroup_search_in,
					page_in,
					page_numRecords_in,
					login_in
				}, 
				this.Record_Open_byGroupOperationCompleted, 
				userState
			);
		}

		private void OnRecord_Open_byGroupOperationCompleted(object arg) {
			if (this.Record_Open_byGroupCompleted != null) {
				System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs 
					= (System.Web.Services.Protocols.InvokeCompletedEventArgs)arg;
				this.Record_Open_byGroupCompleted(
					this, 
					new Record_Open_byGroupCompletedEventArgs(
						invokeArgs.Results, 
						invokeArgs.Error, 
						invokeArgs.Cancelled, 
						invokeArgs.UserState
					)
				);
			}
		}
		#endregion
	}

	#region ...insObject...
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
	#endregion
	#region ...getObject...
	/// <remarks/>
	public delegate void getObjectCompletedEventHandler(
		object sender, 
		getObjectCompletedEventArgs e
	);

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class getObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		private object[] results;

		internal getObjectCompletedEventArgs(
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
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User Result {
			get {
				this.RaiseExceptionIfNecessary();
				return (OGen.NTier.UTs.lib.datalayer.proxy.SO_User)this.results[0];
			}
		}

		/// <remarks/>
		public bool exists_out {
			get {
				this.RaiseExceptionIfNecessary();
				return (bool)this.results[1];
			}
		}
	}
	#endregion
	#region ...Record_Open_byGroup...
	/// <remarks/>
	public delegate void Record_Open_byGroupCompletedEventHandler(
		object sender, 
		Record_Open_byGroupCompletedEventArgs e
	);

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class Record_Open_byGroupCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		private object[] results;

		internal Record_Open_byGroupCompletedEventArgs(
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
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User[] Result {
			get {
				this.RaiseExceptionIfNecessary();
				return (OGen.NTier.UTs.lib.datalayer.proxy.SO_User[])this.results[0];
			}
		}
	}
	#endregion
}