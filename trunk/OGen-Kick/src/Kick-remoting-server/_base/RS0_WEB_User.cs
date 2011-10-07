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
	/// WEB_User remoting server.
	/// </summary>
	public class RS_WEB_User : 
		MarshalByRefObject, 
		IBO_WEB_User 
	{
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User getObject(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_NET_User getObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.getObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idUser_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User getObject_details(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User getObject_details(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.getObject_details(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idUser_in, 
				out errors_out
			);
		}
		#endregion
		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[] getRecord_generic(...);
		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_vNET_User[] getRecord_generic(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string login_in, 
			string email_in, 
			string name_in, 
			long idProfile__in_in, 
			long idProfile__out_in, 
			int page_orderBy_in, 
			int page_in, 
			int page_numRecords_in, 
			out long page_itemsCount_out, 
			out System.Int32[] errors_out
		) {
			return OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.getRecord_generic(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				login_in, 
				email_in, 
				name_in, 
				idProfile__in_in, 
				idProfile__out_in, 
				page_orderBy_in, 
				page_in, 
				page_numRecords_in, 
				out page_itemsCount_out, 
				out errors_out
			);
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
		#region public void Login(...);
		public void Login(
			string email_in, 
			string password_in, 
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			int idApplication_in, 
			out long idUser_out, 
			out string login_out, 
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.Login(
				email_in, 
				password_in, 
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idApplication_in, 
				out idUser_out, 
				out login_out, 
				out idPermitions_out, 
				out errors_out
			);
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
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.Login_throughLink(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				email_verify_in, 
				idApplication_in, 
				out idUser_out, 
				out login_out, 
				out name_out, 
				out idPermitions_out, 
				out errors_out
			);
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
			out System.Int64[] idPermitions_out, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.Login_throughLink_andChangePassword(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				email_verify_in, 
				idApplication_in, 
				password_in, 
				out idUser_out, 
				out login_out, 
				out name_out, 
				out idPermitions_out, 
				out errors_out
			);
		}
		#endregion
		#region public void LostPassword_Recover(...);
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
		public void setObject(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			long idUser_in, 
			bool updateName_in, 
			string name_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.setObject(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				idUser_in, 
				updateName_in, 
				name_in, 
				out errors_out
			);
		}
		#endregion
		#region public void updObject_EMail(...);
		public void updObject_EMail(
			string sessionGuid_in, 
			string ip_forLogPurposes_in, 
			string EMail_verify_in, 
			string companyName_in, 
			string verifyMailURL_in, 
			out System.Int32[] errors_out
		) {
			OGen.NTier.Kick.lib.businesslayer.SBO_WEB_User.updObject_EMail(
				sessionGuid_in, 
				(utils.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: ip_forLogPurposes_in, 
				EMail_verify_in, 
				companyName_in, 
				verifyMailURL_in, 
				out errors_out
			);
		}
		#endregion
	}
}