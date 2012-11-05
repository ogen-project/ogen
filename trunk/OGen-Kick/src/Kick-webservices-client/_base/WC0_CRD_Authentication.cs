#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.DistributedLayer.WebServices.Client {
	using System;
	using System.Web.Services;
	using System.Web.Services.Protocols;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;

	/// <summary>
	/// CRD_Authentication web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_CRD_AuthenticationSoap",
		Namespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server"
	)]
	public class WC_CRD_Authentication : 
		SoapHttpClientProtocol, 
		IBO_CRD_Authentication
	{
		public WC_CRD_Authentication() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"{0}:{1}/WS_CRD_Authentication.asmx",
				#if NET_1_1
				System.Configuration.ConfigurationSettings.AppSettings["Webservices_ServerURI"], 
				System.Configuration.ConfigurationSettings.AppSettings["Webservices_ServerPort"]
				#else
				System.Configuration.ConfigurationManager.AppSettings["Webservices_ServerURI"], 
				System.Configuration.ConfigurationManager.AppSettings["Webservices_ServerPort"]
				#endif
			);
		}
		#endregion

		#region public void ChangePassword(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/ChangePassword",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void ChangePassword(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string password_old_in, 
			string password_new_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"ChangePassword", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					password_old_in,
					password_new_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public bool CheckCredentials(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/CheckCredentials",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public bool CheckCredentials(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"CheckCredentials", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in
				}
			);
			errors_out = (int[])results[1];
			return (bool)results[0];
		}
		#endregion
		#region public void Login(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/Login",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Login(
			string login_in, 
			string password_in, 
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_in, 
			out long idUser_out, 
			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"Login", 
				new object[] {
					login_in,
					password_in,
					sessionGuid_in,
					ip_forLogPurposes_in,
					idApplication_in
				}
			);
			idUser_out = (long)results[0];
			idPermissions_out = (long[])results[1];
			errors_out = (int[])results[2];
		}
		#endregion
		#region public void Logout(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/Logout",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Logout(
			string sessionGuid_in
		) {
			object[] results = this.Invoke(
				"Logout", 
				new object[] {
					sessionGuid_in
				}
			);
		}
		#endregion
	}
}