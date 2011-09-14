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
	public class BO_CRD_Authentication :
		IBO_CRD_Authentication
	{
		#region public void ChangePassword(...);
		public void ChangePassword(
			string credentials_in, 
			string password_old_in, 
			string password_new_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Authentication.ChangePassword(
				credentials_in, 
				password_old_in, 
				password_new_in, 
				out errors_out
			);
		}
		#endregion
		#region public bool CheckCredentials(...);
		public bool CheckCredentials(
			string credentials_in
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Authentication.CheckCredentials(
				credentials_in
			);
		}
		#endregion
		#region public string Login(...);
		public string Login(
			string login_in, 
			string password_in, 
			int idApplication_in, 
			out long idUser_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_CRD_Authentication.Login(
				login_in, 
				password_in, 
				idApplication_in, 
				out idUser_out, 
				out errors_out
			);
		}
		#endregion
	}
}