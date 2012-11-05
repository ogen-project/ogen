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
	/// DIC_Dic web service.
	/// </summary>
	public class WS0_DIC_Dic :
		WebService,
		IBO_DIC_Dic
	{
		#region public void delLanguage(...);
		[WebMethod]
		public void delLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.delLanguage(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguage_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vDIC_ApplicationLanguage[] getRecord_byApplication(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vDIC_ApplicationLanguage[] getRecord_byApplication(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.getRecord_byApplication(
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
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vDIC_Language[] getRecord_byLanguage(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vDIC_Language[] getRecord_byLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.getRecord_byLanguage(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguage_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vDIC_Language[] getRecord_Language(...);
		[WebMethod]
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vDIC_Language[] getRecord_Language(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.getRecord_Language(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguage_in, 
				page_orderBy_in, 
				page_in, 
				page_itemsPerPage_in, 
				out page_itemsCount_out, 
				out errors_out
			);
		}
		#endregion
		#region public void insLanguage(...);
		[WebMethod]
		public void insLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] languageName_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] existingLanguagesInNewLanguage_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.insLanguage(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				languageName_in, 
				existingLanguagesInNewLanguage_in, 
				out errors_out
			);
		}
		#endregion
		#region public void setSupportedLanguages(...);
		[WebMethod]
		public void setSupportedLanguages(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int[] idLanguages_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.setSupportedLanguages(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguages_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updLanguage(...);
		[WebMethod]
		public void updLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idLanguage_in, 
			OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage[] textLanguage_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_DIC_Dic.updLanguage(
				sessionGuid_in, 
				(Utilities.ResetClientIP) 
					? HttpContext.Current.Request.UserHostAddress 
					: ip_forLogPurposes_in, 
				idLanguage_in, 
				textLanguage_in, 
				out errors_out
			);
		}
		#endregion
	}
}