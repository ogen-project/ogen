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
	/// WEB_DefaultProfile web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_WEB_DefaultProfileSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_WEB_DefaultProfile : 
		SoapHttpClientProtocol, 
		IBO_WEB_DefaultProfile
	{
		public WC_WEB_DefaultProfile() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				"{0}:{1}/WS_WEB_DefaultProfile.asmx",
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

		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_Profile[] getRecord_all(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_all",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_Profile[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_all", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					page_in,
					page_numRecords_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_Profile[])results[0];
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
			System.Int64[] idProfile_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"setObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idProfile_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}