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

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.server {
	/// <summary>
	/// NWS_Tag remoting server.
	/// </summary>
	public class RS_NWS_Tag : 
		MarshalByRefObject, 
		IBO_NWS_Tag 
	{
		#region public void delObject(...);
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Tag getObject(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Tag getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag getObject_byTag_andLanguage(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag getObject_byTag_andLanguage(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			int idLanguage_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag[] getRecord_Approved_byLang(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag[] getRecord_Approved_byLang(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_search_in, 
			int idLanguage_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_ContentTag[] getRecord_byContent(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_ContentTag[] getRecord_byContent(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idContent_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag[] getRecord_byLang(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag[] getRecord_byLang(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_search_in, 
			int idLanguage_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag[] getRecord_byTag(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNWS_Tag[] getRecord_byTag(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public long insObject(...);
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Tag tag_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in, 
			int idApplication_in, 
			bool selectIdentity_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject(...);
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NWS_Tag tag_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] tx_Name_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Approve(...);
		public void updObject_Approve(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idTag_in, 
			out System.Int32[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
	}
}