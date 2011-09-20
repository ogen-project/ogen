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
	/// NWS_Highlight web service.
	/// </summary>
	public class WS0_NWS_Highlight :
		WebService,
		IBO_NWS_Highlight
	{
		#region public void delObject(...);
		[WebMethod]
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idHighlight_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.delObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idHighlight_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Highlight getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Highlight getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idHighlight_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.getObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idHighlight_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Highlight[] getRecord_all(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Highlight[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.getRecord_all(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Highlight[] getRecord_Approved(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Highlight[] getRecord_Approved(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.getRecord_Approved(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idApplication_search_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_ContentHighlight[] getRecord_byContent(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_ContentHighlight[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.getRecord_byContent(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idContent_search_in, 
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
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Highlight highlight_in, 
			bool selectIdentity_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.insObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				highlight_in, 
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
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Highlight highlight_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.updObject(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				highlight_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_Approve(...);
		[WebMethod]
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idHighlight_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_NWS_Highlight.updObject_Approve(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idHighlight_in, 
				out errors_out
			);
		}
		#endregion
	}
}