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
	/// NWS_Author web service.
	/// </summary>
	public class WS0_NWS_Author :
		WebService,
		IBO_NWS_Author
	{
		#region public void delObject(...);
		[WebMethod]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idAuthor_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.delObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idAuthor_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Author getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Author getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idAuthor_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.getObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idAuthor_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Author[] getRecord_all(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Author[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.getRecord_all(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Author[] getRecord_Approved(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNWS_Author[] getRecord_Approved(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.getRecord_Approved(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_ContentAuthor[] getRecord_byContent(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_ContentAuthor[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.getRecord_byContent(
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
		#region public long insObject(...);
		[WebMethod]
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Author author_in, 
			bool selectIdentity_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.insObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				author_in, 
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
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NWS_Author author_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.updObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				author_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Approve(...);
		[WebMethod]
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idAuthor_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_NWS_Author.updObject_Approve(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idAuthor_in, 
				out errors_out
			);
		}
		#endregion
	}
}