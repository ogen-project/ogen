#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.BusinessLayer {
	using System;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;

	public class BO_CRD_Authentication :
		IBO_CRD_Authentication
	{
		#region public void ChangePassword(...);
		public void ChangePassword(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string password_old_in, 
			string password_new_in, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Authentication.ChangePassword(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				password_old_in, 
				password_new_in, 
				out errors_out
			);
		}
		#endregion
		#region public bool CheckCredentials(...);
		public bool CheckCredentials(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			out int[] errors_out
		) {
			return OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Authentication.CheckCredentials(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				out errors_out
			);
		}
		#endregion
		#region public void Login(...);
		public void Login(
			string login_in, 
			string password_in, 
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_in, 
			out long idUser_out, 
			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Authentication.Login(
				login_in, 
				password_in, 
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				idApplication_in, 
				out idUser_out, 
				out idPermissions_out, 
				out errors_out
			);
		}
		#endregion
		#region public void Logout(...);
		public void Logout(
			string sessionGuid_in
		) {
			OGen.NTier.Kick.Libraries.BusinessLayer.SBO_CRD_Authentication.Logout(
				sessionGuid_in
			);
		}
		#endregion
	}
}