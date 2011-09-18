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

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.webservices.client {
	/// <summary>
	/// WEB_User web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_WEB_UserSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_WEB_User : 
		SoapHttpClientProtocol, 
		IBO_WEB_User
	{
		public WC_WEB_User() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				"{0}:{1}/WS_WEB_User.asmx",
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

		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User getObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idUser_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User getObject_details(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getObject_details",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User getObject_details(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject_details", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idUser_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[] getRecord_generic(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_generic",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string login_in, 
			string email_in, 
			string name_in, 
			long idProfile__in_in, 
			long idProfile__out_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_generic", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					login_in,
					email_in,
					name_in,
					idProfile__in_in,
					idProfile__out_in,
					page_in,
					page_numRecords_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[])results[0];
		}
		#endregion
		#region public void insObject_Registration(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/insObject_Registration",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void insObject_Registration(
			string login_in, 
			string email_in, 
			string name_in, 
			string verifyMailURL_in, 
			string companyName_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"insObject_Registration", 
				new object[] {
					login_in,
					email_in,
					name_in,
					verifyMailURL_in,
					companyName_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void Login(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/Login",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Login(
			string email_in, 
			string password_in, 
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"Login", 
				new object[] {
					email_in,
					password_in,
					sessionGuid_in,
					ip_forLogPurposes_in,
					idApplication_in
				}
			);
			idUser_out = (long)results[0];
			login_out = (string)results[1];
			idPermitions_out = (System.Int64[])results[2];
			errors_out = (System.Int32[])results[3];
		}
		#endregion
		#region public void Login_throughLink(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/Login_throughLink",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Login_throughLink(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string email_verify_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out string name_out, 
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"Login_throughLink", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					email_verify_in,
					idApplication_in
				}
			);
			idUser_out = (long)results[0];
			login_out = (string)results[1];
			name_out = (string)results[2];
			idPermitions_out = (System.Int64[])results[3];
			errors_out = (System.Int32[])results[4];
		}
		#endregion
		#region public void Login_throughLink_andChangePassword(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/Login_throughLink_andChangePassword",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void Login_throughLink_andChangePassword(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string email_verify_in, 
			int idApplication_in, 
			string password_in, 
			out long idUser_out, 
			out string login_out, 
			out string name_out, 
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"Login_throughLink_andChangePassword", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					email_verify_in,
					idApplication_in,
					password_in
				}
			);
			idUser_out = (long)results[0];
			login_out = (string)results[1];
			name_out = (string)results[2];
			idPermitions_out = (System.Int64[])results[3];
			errors_out = (System.Int32[])results[4];
		}
		#endregion
		#region public void LostPassword_Recover(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/LostPassword_Recover",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void LostPassword_Recover(
			string EMail_in, 
			string companyName_in, 
			string recoverLostPasswordURL_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"LostPassword_Recover", 
				new object[] {
					EMail_in,
					companyName_in,
					recoverLostPasswordURL_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void setObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/setObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void setObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			bool updateName_in, 
			string name_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"setObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idUser_in,
					updateName_in,
					name_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_EMail(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_EMail",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_EMail(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string EMail_verify_in, 
			string companyName_in, 
			string verifyMailURL_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_EMail", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					EMail_verify_in,
					companyName_in,
					verifyMailURL_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}