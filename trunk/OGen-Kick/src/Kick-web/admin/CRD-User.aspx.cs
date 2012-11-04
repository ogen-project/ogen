﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	using System;
	using System.Collections.Generic;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.structures;
	using OGen.NTier.Kick.lib.datalayer.shared;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;
	using OGen.NTier.Kick.lib.presentationlayer.weblayer;

	using BusinessInstances = OGen.NTier.Kick.lib.businesslayer.shared.instances;

	public partial class CRD_User : AdminPage {
		#region public long IDUser { get; }
		private long iduser__ = -2L;

		public long IDUser {
			get {
				if (
					(this.iduser__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDUser"],
							out this.iduser__
						)
					)
				) {
					this.iduser__ = -1L;
				}

				return this.iduser__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}
		#endregion

		#region protected void BTN_Profile_Click(object sender, EventArgs e);
		protected void BTN_Profile_Click(object sender, EventArgs e) {
			int[] _errors;

			BusinessInstances.CRD_Profile.InstanceClient.setUserProfiles(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				this.IDUser,
				this.CBL_Profiles.Kick.SelectedValue__get<long>(), 
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				this.Bind();
			}
		} 
		#endregion

		#region public void Bind(...);
		public void Bind() {
			int[] _errors;
			long _count;

			SO_vNET_User _user 
				= BusinessInstances.WEB_User.InstanceClient.getObject_details(
					utils.User.SessionGuid, 
					utils.ClientIPAddress,
					this.IDUser,
					out _errors
				);
			if (!this.Master__base.Error_add(_errors)) {
				if (_user == null) {
					Response.Redirect(
						"CRD_User-list.aspx", 
						true
					);

					return;
				}

				this.TXT_Name.Text = _user.Name;
				this.TXT_LogOn.Text = _user.Login;
				this.TXT_Email.Text = _user.Email;
			}

			SO_vCRD_UserProfile[] _profiles
				= BusinessInstances.CRD_Profile.InstanceClient.getRecord_ofUserProfile_byUser(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					this.IDUser,
					0, 0, 0, out _count, 
					out _errors
				);
			if (!this.Master__base.Error_add(_errors)) {
				Array.Sort(
					_profiles,
					delegate(
						SO_vCRD_UserProfile arg1_in,
						SO_vCRD_UserProfile arg2_in
					) {
						return string.Compare(
							arg1_in.ProfileName,
							arg2_in.ProfileName,
							false,
							System.Globalization.CultureInfo.CurrentCulture
						);
					}
				);
				this.CBL_Profiles.Kick.Bind__arrayOf<long, string>(
					"",
					false,
					_profiles
				);

				this.CBL_Profiles.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_UserProfile>(
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