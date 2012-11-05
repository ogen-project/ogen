#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.BusinessLayer {
	using System;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;

	public class BO_NWS_News :
		IBO_NWS_News
	{
		#region public void delObject(...);
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.delObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content getObject(...);
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int idLanguage_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.getObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idLanguage_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[] getRecord_byContent(...);
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.getRecord_byContent(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Content[] getRecord_generic(...);
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.getRecord_generic(
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
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public long insObject(...);
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.insObject(
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
				idProfiles_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject(...);
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
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject(
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
				idProfiles_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Approve(...);
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Approve(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Authors(...);
		public void updObject_Authors(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idAuthors_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Authors(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idAuthors_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Content(...);
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
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Content(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				content_in, 
				tx_Title_in, 
				tx_Content_in, 
				tx_Subtitle_in, 
				tx_Summary_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Highlights(...);
		public void updObject_Highlights(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idHighlights_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Highlights(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idHighlights_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Profiles(...);
		public void updObject_Profiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Profiles(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idProfiles_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Sources(...);
		public void updObject_Sources(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idSources_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Sources(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_in, 
				idSources_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Tags(...);
		public void updObject_Tags(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idTags_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_News.updObject_Tags(
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