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
using OGen.NTier.Kick.lib.businesslayer;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.server {
	/// <summary>
	/// CRD_Profile remoting server.
	/// </summary>
	public class RS_CRD_Profile : 
		MarshalByRefObject, 
		IBO_CRD_Profile 
	{
		#region public void delObject(...);
		public void delObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.delObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idProfile_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile getObject(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idProfile_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[] getRecord_all(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[] getRecord_all(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			bool allProfiles_notJustApplication_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getRecord_all(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				allProfiles_notJustApplication_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_ProfileProfile[] getRecord_byProfile(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_ProfileProfile[] getRecord_byProfile(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getRecord_byProfile(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idProfile_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_ProfilePermition[] getRecord_ofProfilePermition_byProfile(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_ProfilePermition[] getRecord_ofProfilePermition_byProfile(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDProfile_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getRecord_ofProfilePermition_byProfile(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				IDProfile_search_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long IDUser_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getRecord_ofUserProfile_byUser(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				IDUser_search_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public long insObject(...);
		public long insObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile profile_in, 
			System.Int64[] idProfile_parent_in, 
			System.Int64[] idPermition_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.insObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				profile_in, 
				idProfile_parent_in, 
				idPermition_in, 
				out errors_out
			);
		}
		#endregion
		#region public void setUserProfiles(...);
		public void setUserProfiles(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			System.Int64[] idProfiles_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.setUserProfiles(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idUser_in, 
				idProfiles_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject(...);
		public void updObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile profile_in, 
			System.Int64[] idProfile_parent_in, 
			System.Int64[] idPermition_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.updObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				profile_in, 
				idProfile_parent_in, 
				idPermition_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_relationsOnly(...);
		public void updObject_relationsOnly(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idProfile_in, 
			System.Int64[] idProfile_parent_in, 
			System.Int64[] idPermition_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.updObject_relationsOnly(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idProfile_in, 
				idProfile_parent_in, 
				idPermition_in, 
				out errors_out
			);
		}
		#endregion
	}
}