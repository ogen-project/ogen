#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.server {
	using System;

	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.structures;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;

	/// <summary>
	/// NWS_News remoting server.
	/// </summary>
	public class RS_NWS_News : 
		MarshalByRefObject, 
		IBO_NWS_News 
	{
		#region public void delObject(...);
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Content[] getRecord_generic(...);
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
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public long insObject(...);
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
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject(...);
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
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Approve(...);
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Authors(...);
		public void updObject_Authors(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idAuthors_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Content(...);
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
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Highlights(...);
		public void updObject_Highlights(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idHighlights_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Profiles(...);
		public void updObject_Profiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idProfiles_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Sources(...);
		public void updObject_Sources(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idSources_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Tags(...);
		public void updObject_Tags(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_in, 
			System.Int64[] idTags_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
	}
}