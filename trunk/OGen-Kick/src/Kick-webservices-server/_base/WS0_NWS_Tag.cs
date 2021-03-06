#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.DistributedLayer.WebServices.Server {
	using System;
	using System.Web;
	using System.Web.Services;

	using OGen.NTier.Kick.Libraries.BusinessLayer;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;

	/// <summary>
	/// NWS_Tag web service.
	/// </summary>
	public class WS0_NWS_Tag :
		WebService,
		IBO_NWS_Tag
	{
		#region public void delObject(...);
		[WebMethod]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.delObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idTag_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.getObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idTag_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag getObject_byTag_andLanguage(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag getObject_byTag_andLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			int idLanguage_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.getObject_byTag_andLanguage(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idTag_in, 
				idLanguage_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_Approved_byLang(...);
		[WebMethod]
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.getRecord_Approved_byLang(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguage_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_ContentTag[] getRecord_byContent(...);
		[WebMethod]
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.getRecord_byContent(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idContent_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_byLang(...);
		[WebMethod]
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.getRecord_byLang(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguage_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Tag[] getRecord_byTag(...);
		[WebMethod]
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
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.getRecord_byTag(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idTag_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public long insObject(...);
		[WebMethod]
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag tag_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Name_in, 
			bool selectIdentity_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.insObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				tag_in, 
				tx_Name_in, 
				selectIdentity_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject(...);
		[WebMethod]
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Tag tag_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] tx_Name_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.updObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				tag_in, 
				tx_Name_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Approve(...);
		[WebMethod]
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Tag.updObject_Approve(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idTag_in, 
				out errors_out
			);
		}
		#endregion
	}
}