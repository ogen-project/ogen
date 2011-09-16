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

using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.businesslayer {
	public class BO_CRD_Profile :
		IBO_CRD_Profile
	{
		#region public void delObject(...);
		public void delObject(
			string credentials_in, 
			int idProfile_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.delObject(
				credentials_in, 
				idProfile_in, 
				idApplication_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile getObject(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile getObject(
			string credentials_in, 
			int idProfile_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getObject(
				credentials_in, 
				idProfile_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[] getRecord_all(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile[] getRecord_all(
			string credentials_in, 
			int idApplication_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getRecord_all(
				credentials_in, 
				idApplication_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vCRD_UserProfile[] getRecord_ofUserProfile_byUser(
			string credentials_in, 
			long IDUser_search_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.getRecord_ofUserProfile_byUser(
				credentials_in, 
				IDUser_search_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public int insObject(...);
		public int insObject(
			string credentials_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile profile_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.insObject(
				credentials_in, 
				profile_in, 
				out errors_out
			);
		}
		#endregion
		#region public void setUserProfiles(...);
		public void setUserProfiles(
			string credentials_in, 
			long idUser_in, 
			System.Int64[] idProfiles_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.setUserProfiles(
				credentials_in, 
				idUser_in, 
				idProfiles_in, 
				idApplication_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject(...);
		public void updObject(
			string credentials_in, 
			OGen.NTier.Kick.lib.datalayer.shared.structures.SO_CRD_Profile profile_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Profile.updObject(
				credentials_in, 
				profile_in, 
				out errors_out
			);
		}
		#endregion
	}
}