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
	/// NWS_Tag web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_NWS_TagSoap",
		Namespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server"
	)]
	public class WC_NWS_Tag : 
		SoapHttpClientProtocol, 
		IBO_NWS_Tag
	{
		public WC_NWS_Tag() {
			this.ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"{0}:{1}/WS_NWS_Tag.asmx",
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
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/delObject",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"delObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idTag_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag getObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getObject",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idTag_in
				}
			);
			errors_out = (int[])results[1];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag getObject_byTag_andLanguage(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getObject_byTag_andLanguage",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag getObject_byTag_andLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			int idLanguage_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject_byTag_andLanguage", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idTag_in,
					idLanguage_in
				}
			);
			errors_out = (int[])results[1];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_Approved_byLang(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getRecord_Approved_byLang",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_Approved_byLang(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_Approved_byLang", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguage_search_in,
					page_orderBy_in,
					page_in,
					page_itemsPerPage_in
				}
			);
			page_itemsCount_out = (long)results[1];
			errors_out = (int[])results[2];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_ContentTag[] getRecord_byContent(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getRecord_byContent",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_ContentTag[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byContent", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_search_in,
					page_orderBy_in,
					page_in,
					page_itemsPerPage_in
				}
			);
			page_itemsCount_out = (long)results[1];
			errors_out = (int[])results[2];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_ContentTag[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_byLang(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getRecord_byLang",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_byLang(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byLang", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idLanguage_search_in,
					page_orderBy_in,
					page_in,
					page_itemsPerPage_in
				}
			);
			page_itemsCount_out = (long)results[1];
			errors_out = (int[])results[2];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_byTag(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getRecord_byTag",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_byTag(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byTag", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idTag_in,
					page_orderBy_in,
					page_in,
					page_itemsPerPage_in
				}
			);
			page_itemsCount_out = (long)results[1];
			errors_out = (int[])results[2];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[])results[0];
		}
		#endregion
		#region public long insObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/insObject",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag tag_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Name_in, 
			bool selectIdentity_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					tag_in,
					tx_Name_in,
					selectIdentity_in
				}
			);
			errors_out = (int[])results[1];
			return (long)results[0];
		}
		#endregion
		#region public void updObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag tag_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Name_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					tag_in,
					tx_Name_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Approve(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Approve",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Approve", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idTag_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
	}
}