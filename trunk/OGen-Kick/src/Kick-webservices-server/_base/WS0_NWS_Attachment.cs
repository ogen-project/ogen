#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.distributedlayer.webservices.server {
	using System;
	using System.Web;
	using System.Web.Services;

	using OGen.NTier.Kick.lib.businesslayer;
	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.structures;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;

	/// <summary>
	/// NWS_Attachment web service.
	/// </summary>
	public class WS0_NWS_Attachment :
		WebService,
		IBO_NWS_Attachment
	{
		#region public void delObject(...);
		[WebMethod]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idAttachment_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Attachment.delObject(
				sessionGuid_in, 
				(utils.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idAttachment_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idAttachment_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Attachment.getObject(
				sessionGuid_in, 
				(utils.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idAttachment_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Attachment.getRecord_byContent(
				sessionGuid_in, 
				(utils.ResetClientIP) 
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
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent_andLanguage(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Attachment[] getRecord_byContent_andLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDContent_search_in, 
			int IDLanguage_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Attachment.getRecord_byContent_andLanguage(
				sessionGuid_in, 
				(utils.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				IDContent_search_in, 
				IDLanguage_search_in, 
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
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment attachment_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Description_in, 
			bool selectIdentity_in, 
			out string guid_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Attachment.insObject(
				sessionGuid_in, 
				(utils.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				attachment_in, 
				tx_Name_in, 
				tx_Description_in, 
				selectIdentity_in, 
				out guid_out, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject(...);
		[WebMethod]
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Attachment attachment_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Description_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Attachment.updObject(
				sessionGuid_in, 
				(utils.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				attachment_in, 
				tx_Name_in, 
				tx_Description_in, 
				out errors_out
			);
		}
		#endregion
	}
}