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
using System.Runtime.Remoting;

using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;

namespace OGen.NTier.Kick.lib.distributedlayer.remoting.client {
	/// <summary>
	/// WEB_User remoting client.
	/// </summary>
	public class RC_WEB_User : 
		IBO_WEB_User 
	{
		static RC_WEB_User() {
			ReConfig();
		}

		#region private Fields...
		private static IBO_WEB_User bo_;
		#endregion
		#region public static void ReConfig();
		public static void ReConfig() {
			utils.Config.ReConfig();

			bo_ = new OGen.NTier.Kick.lib.distributedlayer.remoting.server.RS_WEB_User();
		}
		#endregion

		#region public void Login(...);
		public void Login(
			string email_in, 
			string password_in, 
			string sessionGuid_in, 
			string whoAmI_forLogPurposes_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			bo_.Login(
				email_in, 
				password_in, 
				sessionGuid_in, 
				whoAmI_forLogPurposes_in, 
				idApplication_in, 
				out idUser_out, 
				out login_out, 
				out idPermitions_out, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_EMail(...);
		public void updObject_EMail(
			string sessionGuid_in, 
			string EMail_verify_in, 
			string companyName_in, 
			string verifyMailURL_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			bo_.updObject_EMail(
				sessionGuid_in, 
				EMail_verify_in, 
				companyName_in, 
				verifyMailURL_in, 
				idApplication_in, 
				out errors_out
			);
		}
		#endregion
	}
}