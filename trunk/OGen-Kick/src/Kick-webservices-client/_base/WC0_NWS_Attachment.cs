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
	/// NWS_Attachment web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_NWS_AttachmentSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_NWS_Attachment : 
		SoapHttpClientProtocol, 
		IBO_NWS_Attachment
	{
		public WC_NWS_Attachment() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				"{0}:{1}/WS_NWS_Attachment.asmx",
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
			long idAttachment_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"delObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idAttachment_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment getObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idAttachment_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idAttachment_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_byContent",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_search_in, 
			int page_orderBy_in, 
			int page_in, 
			int page_numRecords_in, 
			out int page_itemsCount_out, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byContent", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_search_in,
					page_orderBy_in,
					page_in,
					page_numRecords_in
				}
			);
			page_itemsCount_out = (int)results[1];
			errors_out = (System.Int32[])results[2];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent_andLanguage(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_byContent_andLanguage",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent_andLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDContent_search_in, 
			int IDLanguage_search_in, 
			int page_orderBy_in, 
			int page_in, 
			int page_numRecords_in, 
			out int page_itemsCount_out, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byContent_andLanguage", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					IDContent_search_in,
					IDLanguage_search_in,
					page_orderBy_in,
					page_in,
					page_numRecords_in
				}
			);
			page_itemsCount_out = (int)results[1];
			errors_out = (System.Int32[])results[2];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[])results[0];
		}
		#endregion
		#region public long insObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/insObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment attachment_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Description_in, 
			bool selectIdentity_in, 
			out string guid_out, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					attachment_in,
					tx_Name_in,
					tx_Description_in,
					selectIdentity_in
				}
			);
			guid_out = (string)results[1];
			errors_out = (System.Int32[])results[2];
			return (long)results[0];
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
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment attachment_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Description_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					attachment_in,
					tx_Name_in,
					tx_Description_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}