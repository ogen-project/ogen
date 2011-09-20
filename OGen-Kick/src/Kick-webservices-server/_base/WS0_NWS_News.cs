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
using System.Web;
using System.Web.Services;

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.distributedlayer.webservices.server {
	/// <summary>
	/// NWS_News web service.
	/// </summary>
	public class WS0_NWS_News :
		WebService,
		IBO_NWS_News
	{
		#region public void delObject(...);
		[WebMethod]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.delObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.getObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idLanguage_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.getRecord_byContent(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_generic(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
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
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.getRecord_generic(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
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
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public long insObject(...);
		[WebMethod]
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
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
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.insObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
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
				out errors_out
			);
		}
		#endregion
		#region public void updObject(...);
		[WebMethod]
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
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
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
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
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Approve(...);
		[WebMethod]
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Approve(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Authors(...);
		[WebMethod]
		public void updObject_Authors(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idAuthors_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Authors(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idAuthors_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Content(...);
		[WebMethod]
		public void updObject_Content(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Content(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				content_in, 
				tx_Title_in, 
				tx_Content_in, 
				tx_subtitle_in, 
				tx_summary_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Highlights(...);
		[WebMethod]
		public void updObject_Highlights(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idHighlights_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Highlights(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idHighlights_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Profiles(...);
		[WebMethod]
		public void updObject_Profiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idProfiles_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Profiles(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idProfiles_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Sources(...);
		[WebMethod]
		public void updObject_Sources(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idSources_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Sources(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idSources_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Tags(...);
		[WebMethod]
		public void updObject_Tags(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idTags_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_News.updObject_Tags(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idTags_in, 
				out errors_out
			);
		}
		#endregion
	}
}