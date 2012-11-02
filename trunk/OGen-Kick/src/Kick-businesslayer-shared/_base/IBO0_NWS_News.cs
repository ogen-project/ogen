#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.businesslayer.shared {
	using System;

	using OGen.NTier.Kick.lib.businesslayer.shared.structures;

#if NET_1_1
	public interface IBO0_NWS_News {
#else
	public partial interface IBO_NWS_News {
#endif
		void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out int[] errors_out
		);
		OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int idLanguage_in, 
			out int[] errors_out
		);
		OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		);
		OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDUser__Publisher_search_in, 
			long IDUser__Aproved_search_in, 
			System.DateTime Begin_date_search_in, 
			System.DateTime End_date_search_in, 
			long[] idTags_search_in, 
			long[] idAuthors_search_in, 
			long[] idSources_search_in, 
			long[] idHighlights_search_in, 
			long[] idProfiles_search_in, 
			string charVar8000_search_in, 
			int IDLanguage_search_in, 
			bool isAND_notOR_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		);
		long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			long[] idTags_in, 
			long[] idAuthors_in, 
			long[] idSources_in, 
			long[] idHighlights_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		);
		void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			long[] idTags_in, 
			long[] idAuthors_in, 
			long[] idSources_in, 
			long[] idHighlights_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		);
		void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out int[] errors_out
		);
		void updObject_Authors(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idAuthors_in, 
			out int[] errors_out
		);
		void updObject_Content(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Content content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Title_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Content_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_subtitle_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_summary_in, 
			out int[] errors_out
		);
		void updObject_Highlights(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idHighlights_in, 
			out int[] errors_out
		);
		void updObject_Profiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		);
		void updObject_Sources(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idSources_in, 
			out int[] errors_out
		);
		void updObject_Tags(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			long[] idTags_in, 
			out int[] errors_out
		);
	}
}