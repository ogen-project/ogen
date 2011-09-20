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
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using OGen.NTier.Kick.lib.datalayer.shared;
using OGen.NTier.Kick.lib.datalayer.shared.structures;
using OGen.NTier.Kick.lib.businesslayer.shared;
using OGen.NTier.Kick.lib.businesslayer.shared.structures;
using BusinessInstances = OGen.NTier.Kick.lib.businesslayer.shared.instances;

using OGen.NTier.Kick.lib.presentationlayer.weblayer;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class CRD_User : AdminPage {
		#region public long IDUser { get; }
		private long iduser__ = -2L;

		public long IDUser {
			get {
				if (
					(iduser__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDUser"],
							out iduser__
						)
					)
				) {
					iduser__ = -1L;
				}

				return iduser__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				Bind();
			}
		}
		#endregion

		#region protected void btn_Profile_Click(object sender, EventArgs e);
		protected void btn_Profile_Click(object sender, EventArgs e) {
			int[] _errors;

			BusinessInstances.CRD_Profile.InstanceClient.setUserProfiles(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDUser, 
				cbl_Profiles.Kick.SelectedValue__get<long>(), 
				out _errors
			);
			if (!Master__base.Error_show(_errors)) {
				Bind();
			}
		} 
		#endregion

		#region public void Bind(...);
		public void Bind() {
			int[] _errors;

			SO_vNET_User _user 
				= BusinessInstances.WEB_User.InstanceClient.getObject_details(
					utils.User.SessionGuid, 
					utils.ClientIPAddress, 
					IDUser,
					out _errors
				);
			if (!Master__base.Error_show(_errors)) {
				if (_user == null) {
					Response.Redirect(
						"CRD_User-list.aspx", 
						true
					);

					return;
				}

				txt_Name.Text = _user.Name;
				txt_Login.Text = _user.Login;
				txt_EMail.Text = _user.EMail;
			}

			SO_vCRD_UserProfile[] _profiles
				= BusinessInstances.CRD_Profile.InstanceClient.getRecord_ofUserProfile_byUser(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					IDUser,
					0, 0,
					out _errors
				);
			if (!Master__base.Error_show(_errors)) {
				Array.Sort(
					_profiles,
					delegate(
						SO_vCRD_UserProfile arg1_in,
						SO_vCRD_UserProfile arg2_in
					) {
						return arg1_in.ProfileName.CompareTo(arg2_in.ProfileName);
					}
				);
				cbl_Profiles.Kick.Bind__arrayOf<long, string>(
					"",
					false,
					_profiles
				);

				cbl_Profiles.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_UserProfile>(
					_profiles, 
					delegate(
						SO_vCRD_UserProfile item_in
					) {
						return item_in.hasProfile;
					}
				);
			}
		}
		#endregion
	}
}