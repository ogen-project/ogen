#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.DistributedLayer.Remoting.Server {
	using System;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;

	/// <summary>
	/// WEB_User remoting server.
	/// </summary>
	public class RS_WEB_User : 
		MarshalByRefObject, 
		IBO_WEB_User 
	{
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NET_User getObject(...);
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_NET_User getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNET_User getObject_details(...);
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNET_User getObject_details(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNET_User[] getRecord_generic(...);
		public OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_vNET_User[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string login_in, 
			string email_in, 
			string name_in, 
			long idProfile__in_in, 
			long idProfile__out_in, 
			int page_orderBy_in, 
			long page_in, 
			int page_itemsPerPage_in, 
			out long page_itemsCount_out, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void insObject_Registration(...);
		public void insObject_Registration(
			string login_in, 
			string email_in, 
			string name_in, 
			string verifyMailURL_in, 
			string companyName_in, 
			int idApplication_in, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void Login(...);
		public void Login(
			string email_in, 
			string password_in, 
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void Login_throughLink(...);
		public void Login_throughLink(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string email_verify_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out string name_out, 
			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void Login_throughLink_andChangePassword(...);
		public void Login_throughLink_andChangePassword(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string email_verify_in, 
			int idApplication_in, 
			string password_in, 
			out long idUser_out, 
			out string login_out, 
			out string name_out, 
			out long[] idPermissions_out, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void LostPassword_Recover(...);
		public void LostPassword_Recover(
			string Email_in, 
			string companyName_in, 
			string recoverLostPasswordURL_in, 
			int idApplication_in, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void setObject(...);
		public void setObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			bool updateName_in, 
			string name_in, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
		#region public void updObject_Email(...);
		public void updObject_Email(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string Email_verify_in, 
			string companyName_in, 
			string verifyMailURL_in, 
			out int[] errors_out
		) {
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");
		}
		#endregion
	}
}