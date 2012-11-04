#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.client {
	using System;
	using System.Runtime.Remoting;

	using OGen.NTier.Kick.lib.businesslayer;
	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.structures;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;

	/// <summary>
	/// CRD_Authentication remoting client.
	/// </summary>
	public class RC_CRD_Authentication : 
		IBO_CRD_Authentication 
	{
		static RC_CRD_Authentication() {
			ReConfig();
		}

		#region private Fields...
		private static IBO_CRD_Authentication bo_;
		#endregion
		#region public static void ReConfig();
		public static void ReConfig() {
			utils.Config.ReConfig();

			bo_ = new OGen.NTier.Kick.lib.distributedlayer.remoting.server.RS_CRD_Authentication();
		}
		#endregion

		#region public void ChangePassword(...);
		public void ChangePassword(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string password_old_in, 
			string password_new_in, 
			out int[] errors_out
		) {
			bo_.ChangePassword(
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
			return bo_.CheckCredentials(
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
			bo_.Login(
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
			bo_.Logout(
				sessionGuid_in
			);
		}
		#endregion
	}
}