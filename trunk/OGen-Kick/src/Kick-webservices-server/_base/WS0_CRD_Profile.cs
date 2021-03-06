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
	/// CRD_Profile web service.
	/// </summary>
	public class WS0_CRD_Profile :
		WebService,
		IBO_CRD_Profile
	{
		#region public void delObject(...);
		[WebMethod]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.delObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idProfile_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.getObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idProfile_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile[] getRecord_all(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			bool allProfiles_notJustApplication_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.getRecord_all(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				allProfiles_notJustApplication_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_ProfileProfile[] getRecord_byProfile(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_ProfileProfile[] getRecord_byProfile(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.getRecord_byProfile(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idProfile_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vCRD_ProfilePermission[] getRecord_ofProfilePermission_byProfile(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vCRD_ProfilePermission[] getRecord_ofProfilePermission_byProfile(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDProfile_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.getRecord_ofProfilePermission_byProfile(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				IDProfile_search_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDUser_search_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.getRecord_ofUserProfile_byUser(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				IDUser_search_in, 
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
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile profile_in, 
			long[] idProfile_parent_in, 
			long[] idPermission_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.insObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				profile_in, 
				idProfile_parent_in, 
				idPermission_in, 
				out errors_out
			);
		}
		#endregion
		#region public void setUserProfiles(...);
		[WebMethod]
		public void setUserProfiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			long[] idProfiles_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.setUserProfiles(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idUser_in, 
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
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile profile_in, 
			long[] idProfile_parent_in, 
			long[] idPermission_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.updObject(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				profile_in, 
				idProfile_parent_in, 
				idPermission_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_relationsOnly(...);
		[WebMethod]
		public void updObject_relationsOnly(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			long[] idProfile_parent_in, 
			long[] idPermission_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Profile.updObject_relationsOnly(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idProfile_in, 
				idProfile_parent_in, 
				idPermission_in, 
				out errors_out
			);
		}
		#endregion
	}
}