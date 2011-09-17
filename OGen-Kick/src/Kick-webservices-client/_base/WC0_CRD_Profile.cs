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
	/// CRD_Profile web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_CRD_ProfileSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_CRD_Profile : 
		SoapHttpClientProtocol, 
		IBO_CRD_Profile
	{
		public WC_CRD_Profile() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				"{0}:{1}/WS_CRD_Profile.asmx",
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

		#region public void delObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/delObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idProfile_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"delObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idProfile_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile getObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idProfile_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idProfile_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[] getRecord_all(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_all",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_all", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idApplication_in,
					page_in,
					page_numRecords_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_ofUserProfile_byUser",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDUser_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_ofUserProfile_byUser", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					IDUser_search_in,
					page_in,
					page_numRecords_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[])results[0];
		}
		#endregion
		#region public int insObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/insObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public int insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile profile_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					profile_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (int)results[0];
		}
		#endregion
		#region public void setUserProfiles(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/setUserProfiles",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void setUserProfiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			System.Int64[] idProfiles_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"setUserProfiles", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idUser_in,
					idProfiles_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile profile_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					profile_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}