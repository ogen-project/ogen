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
	/// DIC_Dic web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_DIC_DicSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_DIC_Dic : 
		SoapHttpClientProtocol, 
		IBO_DIC_Dic
	{
		public WC_DIC_Dic() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				"{0}:{1}/WS_DIC_Dic.asmx",
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

		#region public void delLanguage(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/delLanguage",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void delLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"delLanguage", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguage_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] getRecord_byApplication(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_byApplication",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byApplication", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_ApplicationLanguage[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[] getRecord_byLanguage(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_byLanguage",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[] getRecord_byLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byLanguage", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguage_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[] getRecord_Language(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_Language",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[] getRecord_Language(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_Language", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguage_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vDIC_Language[])results[0];
		}
		#endregion
		#region public void insLanguage(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/insLanguage",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void insLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] languageName_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] existingLanguagesInNewLanguage_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"insLanguage", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					languageName_in,
					existingLanguagesInNewLanguage_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void setSupportedLanguages(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/setSupportedLanguages",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void setSupportedLanguages(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			System.Int32[] idLanguages_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"setSupportedLanguages", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguages_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updLanguage(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updLanguage",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] textLanguage_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updLanguage", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguage_in,
					textLanguage_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}