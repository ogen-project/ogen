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
	/// CRD_User remoting client.
	/// </summary>
	public class RC_CRD_User : 
		IBO_CRD_User 
	{
		static RC_CRD_User() {
			ReConfig();
		}

		#region private Fields...
		private static IBO_CRD_User bo_;
		#endregion
		#region public static void ReConfig();
		public static void ReConfig() {
			utils.Config.ReConfig();

			bo_ = new OGen.NTier.Kick.lib.distributedlayer.remoting.server.RS_CRD_User();
		}
		#endregion

		#region public void insObject_CreateUser(...);
		public void insObject_CreateUser(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string login_in, 
			out System.Int32[] errors_out
		) {
			bo_.insObject_CreateUser(
				sessionGuid_in, 
				ip_forLogPurposes_in, 
				login_in, 
				out errors_out
			);
		}
		#endregion
		#region public void insObject_Registration(...);
		public void insObject_Registration(
			string login_in, 
			string password_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			bo_.insObject_Registration(
				login_in, 
				password_in, 
				idApplication_in, 
				out errors_out
			);
		}
		#endregion
	}
}