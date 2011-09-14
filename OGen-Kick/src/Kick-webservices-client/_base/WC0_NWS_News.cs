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
	/// NWS_News web service client.
	/// </summary>
	/// <remarks/>
	//[System.Diagnostics.DebuggerStepThroughAttribute()]
	//[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_NWS_NewsSoap",
		Namespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server"
	)]
	public class WC_NWS_News : 
		SoapHttpClientProtocol, 
		IBO_NWS_News
	{
		public WC_NWS_News() {
			ReConfig();
		}

		#region public void ReConfig();
		public void ReConfig() {
			this.Url = string.Format(
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
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/delObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void delObject(
			string credentials_in, 
			long idContent_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"delObject", 
				new object[] {
					credentials_in,
					idContent_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getObject",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(
			string credentials_in, 
			long idContent_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getObject", 
				new object[] {
					credentials_in,
					idContent_in,
					idLanguage_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content)results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_byContent",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(
			string credentials_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_byContent", 
				new object[] {
					credentials_in,
					idContent_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[])results[0];
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_generic(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/getRecord_generic",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_generic(
			string credentials_in, 
			int IDApplication_search_in, 
			long IDUser__Publisher_search_in, 
			long IDUser__Aproved_search_in, 
			System.DateTime Begin_date_search_in, 
			System.DateTime End_date_search_in, 
			System.Int64[] idTags_search_in, 
			System.Int64[] idAuthors_search_in, 
			System.Int64[] idSources_search_in, 
			System.Int64[] idHighlights_search_in, 
			System.Int64[] idProfiles_search_in, 
			string charVar8000_search_in, 
			int IDLanguage_search_in, 
			bool isAND_notOR_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"getRecord_generic", 
				new object[] {
					credentials_in,
					IDApplication_search_in,
					IDUser__Publisher_search_in,
					IDUser__Aproved_search_in,
					Begin_date_search_in,
					End_date_search_in,
					idTags_search_in,
					idAuthors_search_in,
					idSources_search_in,
					idHighlights_search_in,
					idProfiles_search_in,
					charVar8000_search_in,
					IDLanguage_search_in,
					isAND_notOR_search_in,
					page_in,
					page_numRecords_in
				}
			);
			errors_out = (System.Int32[])results[1];
			return (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[])results[0];
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
			string credentials_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			System.Int64[] idTags_in, 
			System.Int64[] idAuthors_in, 
			System.Int64[] idSources_in, 
			System.Int64[] idHighlights_in, 
			System.Int64[] idProfiles_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"insObject", 
				new object[] {
					credentials_in,
					content_in,
					tx_Title_in,
					tx_Content_in,
					tx_subtitle_in,
					tx_summary_in,
					idTags_in,
					idAuthors_in,
					idSources_in,
					idHighlights_in,
					idProfiles_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[1];
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
			string credentials_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			System.Int64[] idTags_in, 
			System.Int64[] idAuthors_in, 
			System.Int64[] idSources_in, 
			System.Int64[] idHighlights_in, 
			System.Int64[] idProfiles_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject", 
				new object[] {
					credentials_in,
					content_in,
					tx_Title_in,
					tx_Content_in,
					tx_subtitle_in,
					tx_summary_in,
					idTags_in,
					idAuthors_in,
					idSources_in,
					idHighlights_in,
					idProfiles_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Approve(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Approve",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Approve(
			string credentials_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Approve", 
				new object[] {
					credentials_in,
					idContent_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Authors(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Authors",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Authors(
			string credentials_in, 
			long idContent_in, 
			System.Int64[] idAuthors_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Authors", 
				new object[] {
					credentials_in,
					idContent_in,
					idAuthors_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Content(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Content",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Content(
			string credentials_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Content", 
				new object[] {
					credentials_in,
					content_in,
					tx_Title_in,
					tx_Content_in,
					tx_subtitle_in,
					tx_summary_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Highlights(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Highlights",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Highlights(
			string credentials_in, 
			long idContent_in, 
			System.Int64[] idHighlights_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Highlights", 
				new object[] {
					credentials_in,
					idContent_in,
					idHighlights_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Profiles(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Profiles",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Profiles(
			string credentials_in, 
			long idContent_in, 
			System.Int64[] idProfiles_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Profiles", 
				new object[] {
					credentials_in,
					idContent_in,
					idProfiles_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Sources(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Sources",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Sources(
			string credentials_in, 
			long idContent_in, 
			System.Int64[] idSources_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Sources", 
				new object[] {
					credentials_in,
					idContent_in,
					idSources_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
		#region public void updObject_Tags(...);
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://OGen.NTier.Kick.distributedlayer.webservices.server/updObject_Tags",
			RequestNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			ResponseNamespace = "http://OGen.NTier.Kick.distributedlayer.webservices.server",
			Use = System.Web.Services.Description.SoapBindingUse.Literal,
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public void updObject_Tags(
			string credentials_in, 
			long idContent_in, 
			System.Int64[] idTags_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			object[] results = this.Invoke(
				"updObject_Tags", 
				new object[] {
					credentials_in,
					idContent_in,
					idTags_in,
					idApplication_in
				}
			);
			errors_out = (System.Int32[])results[0];
		}
		#endregion
	}
}