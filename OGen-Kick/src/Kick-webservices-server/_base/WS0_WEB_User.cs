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
	/// WEB_User web service.
	/// </summary>
	public class WS0_WEB_User :
		WebService,
		IBO_WEB_User
	{
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User getObject(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User getObject(
			string credentials_in, 
			long idUser_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.getObject(
				credentials_in, 
				idUser_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User getObject_details(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User getObject_details(
			string credentials_in, 
			long idUser_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.getObject_details(
				credentials_in, 
				idUser_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[] getRecord_generic(...);
		[WebMethod]
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[] getRecord_generic(
			string credentials_in, 
			string login_in, 
			string email_in, 
			string name_in, 
			long idProfile__in_in, 
			long idProfile__out_in, 
			int idApplication_in, 
			int page_in, 
			int page_numRecords_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.getRecord_generic(
				credentials_in, 
				login_in, 
				email_in, 
				name_in, 
				idProfile__in_in, 
				idProfile__out_in, 
				idApplication_in, 
				page_in, 
				page_numRecords_in, 
				out errors_out
			);
		}
		#endregion
		#region public void insObject_Registration(...);
		[WebMethod]
		public void insObject_Registration(
			string login_in, 
			string email_in, 
			string name_in, 
			string verifyMailURL_in, 
			string companyName_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.insObject_Registration(
				login_in, 
				email_in, 
				name_in, 
				verifyMailURL_in, 
				companyName_in, 
				idApplication_in, 
				out errors_out
			);
		}
		#endregion
		#region public string Login(...);
		[WebMethod]
		public string Login(
			string email_in, 
			string password_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.Login(
				email_in, 
				password_in, 
				idApplication_in, 
				out idUser_out, 
				out login_out, 
				out errors_out
			);
		}
		#endregion
		#region public string Login_throughLink(...);
		[WebMethod]
		public string Login_throughLink(
			string email_verify_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out string name_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.Login_throughLink(
				email_verify_in, 
				idApplication_in, 
				out idUser_out, 
				out login_out, 
				out name_out, 
				out errors_out
			);
		}
		#endregion
		#region public string Login_throughLink_andChangePassword(...);
		[WebMethod]
		public string Login_throughLink_andChangePassword(
			string email_verify_in, 
			int idApplication_in, 
			string password_in, 
			out long idUser_out, 
			out string login_out, 
			out string name_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.Login_throughLink_andChangePassword(
				email_verify_in, 
				idApplication_in, 
				password_in, 
				out idUser_out, 
				out login_out, 
				out name_out, 
				out errors_out
			);
		}
		#endregion
		#region public void LostPassword_Recover(...);
		[WebMethod]
		public void LostPassword_Recover(
			string EMail_in, 
			string companyName_in, 
			string recoverLostPasswordURL_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.LostPassword_Recover(
				EMail_in, 
				companyName_in, 
				recoverLostPasswordURL_in, 
				idApplication_in, 
				out errors_out
			);
		}
		#endregion
		#region public void setObject(...);
		[WebMethod]
		public void setObject(
			string credentials_in, 
			long idUser_in, 
			bool updateName_in, 
			string name_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.setObject(
				credentials_in, 
				idUser_in, 
				updateName_in, 
				name_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_EMail(...);
		[WebMethod]
		public void updObject_EMail(
			string credentials_in, 
			string EMail_verify_in, 
			string companyName_in, 
			string verifyMailURL_in, 
			int idApplication_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.updObject_EMail(
				credentials_in, 
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