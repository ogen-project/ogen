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
	/// NWS_News web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_NWS_NewsSoap",
		Namespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server"
	)]
	public class WC_NWS_News : 
		SoapHttpClientProtocol, 
		IBO_NWS_News
	{
		public WC_NWS_News() {
			this.ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
				System.Globalization.CultureInfo.CurrentCulture,
				"{0}:{1}/WS_NWS_News.asmx",
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
			long idContent_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"delObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content getObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getObject",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int idLanguage_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in,
					idLanguage_in
				}
			);
			errors_out = (int[])results[1];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[] getRecord_byContent(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getRecord_byContent",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
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
					idContent_in,
					page_orderBy_in,
					page_in,
					page_itemsPerPage_in
				}
			);
			page_itemsCount_out = (long)results[1];
			errors_out = (int[])results[2];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[] getRecord_generic(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/getRecord_generic",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDUser__Publisher_search_in, 
			long IDUser__Approved_search_in, 
			System.DateTime Begin_date_search_in, 
			System.DateTime End_date_search_in, 
			long[] idTags_search_in, 
			long[] idAuthors_search_in, 
			long[] idSources_search_in, 
			long[] idHighlights_search_in, 
			long[] idProfiles_search_in, 
			string text__small_search_in, 
			int IDLanguage_search_in, 
			bool isAND_notOR_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_generic", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					IDUser__Publisher_search_in,
					IDUser__Approved_search_in,
					Begin_date_search_in,
					End_date_search_in,
					idTags_search_in,
					idAuthors_search_in,
					idSources_search_in,
					idHighlights_search_in,
					idProfiles_search_in,
					text__small_search_in,
					IDLanguage_search_in,
					isAND_notOR_search_in,
					page_orderBy_in,
					page_in,
					page_itemsPerPage_in
				}
			);
			page_itemsCount_out = (long)results[1];
			errors_out = (int[])results[2];
			return (OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[])results[0];
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
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in, 
			long[] idTags_in, 
			long[] idAuthors_in, 
			long[] idSources_in, 
			long[] idHighlights_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					content_in,
					tx_Title_in,
					tx_Content_in,
					tx_Subtitle_in,
					tx_Summary_in,
					idTags_in,
					idAuthors_in,
					idSources_in,
					idHighlights_in,
					idProfiles_in
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
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in, 
			long[] idTags_in, 
			long[] idAuthors_in, 
			long[] idSources_in, 
			long[] idHighlights_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					content_in,
					tx_Title_in,
					tx_Content_in,
					tx_Subtitle_in,
					tx_Summary_in,
					idTags_in,
					idAuthors_in,
					idSources_in,
					idHighlights_in,
					idProfiles_in
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
			long idContent_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Approve", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Authors(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Authors",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Authors(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idAuthors_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Authors", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in,
					idAuthors_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Content(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Content",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Content(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Subtitle_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Summary_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Content", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					content_in,
					tx_Title_in,
					tx_Content_in,
					tx_Subtitle_in,
					tx_Summary_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Highlights(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Highlights",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Highlights(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idHighlights_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Highlights", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in,
					idHighlights_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Profiles(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Profiles",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Profiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Profiles", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in,
					idProfiles_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Sources(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Sources",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Sources(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idSources_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Sources", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in,
					idSources_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
		#region public void updObject_Tags(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.DistributedLayer.WebServices.Server/updObject_Tags",
			RequestNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			ResponseNamespace = "http://OGen.NTier.Kick.DistributedLayer.WebServices.Server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Tags(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idTags_in, 
			out int[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Tags", 
				new object[] {
					sessionGuid_in,
					ip_forLogPurposes_in,
					idContent_in,
					idTags_in
				}
			);
			errors_out = (int[])results[0];
		}
		#endregion
	}
}