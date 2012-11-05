#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.PresentationLayer.WebLayer {
	using System;
	using System.Collections.Generic;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared;
	using OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared;
	using OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures;
	using OGen.NTier.Kick.Libraries.PresentationLayer.WebLayer;

	using BusinessInstances = OGen.NTier.Kick.Libraries.BusinessLayer.Shared.Instances;

	public partial class CRD_User_list : AdminPage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				int[] _errors;
				long _count;
				SO_CRD_Profile[] _profiles
					= BusinessInstances.CRD_Profile.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						false,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_profiles,
						delegate(
							SO_CRD_Profile arg1_in,
							SO_CRD_Profile arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);

					this.DDL_Profile__in.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_profiles
					);
					//if (this.DDL_Profile__in.Items.Count > 0) {
					this.DDL_Profile__in.SelectedIndex = 0;
					//}

					this.DDL_Profile__out.Kick.Bind__Copy(
						this.DDL_Profile__in,
						"",
						true
					);
					//if (this.DDL_Profile__out.Items.Count > 0) {
					this.DDL_Profile__out.SelectedIndex = 0;
					//}

					this.Bind();
				}
			}
		}
		#endregion
		#region protected void BTN_Search_Click(object sender, EventArgs e);
		protected void BTN_Search_Click(object sender, EventArgs e) {
			this.Bind();
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			long _count;
			SO_vNET_User[] _users
				= BusinessInstances.WEB_User.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					this.TXT_LogOn.Text.Trim(),
					this.TXT_Email.Text.Trim(),
					this.TXT_Name.Text.Trim(),
					(string.IsNullOrEmpty(this.DDL_Profile__in.SelectedValue)) ? 0L : long.Parse(
						this.DDL_Profile__in.SelectedValue,
						System.Globalization.NumberStyles.Integer,
						System.Globalization.CultureInfo.CurrentCulture
					),
					(string.IsNullOrEmpty(this.DDL_Profile__out.SelectedValue)) ? 0L : long.Parse(
						this.DDL_Profile__out.SelectedValue,
						System.Globalization.NumberStyles.Integer,
						System.Globalization.CultureInfo.CurrentCulture
					),

					0, 0, 0, out _count, 

					out _errors
				);
			if (!this.Master__base.Error_add(_errors)) {
				if (_users.Length > 0) {
					this.REP_SearchResults.Visible = true;

					Array.Sort(
						_users,
						delegate(
							SO_vNET_User arg1_in,
							SO_vNET_User arg2_in
						) {
							return arg2_in.IDUser.CompareTo(arg1_in.IDUser);
						}
					);

					this.REP_SearchResults.DataSource = _users;
					this.REP_SearchResults.DataBind();
				} else {
					this.REP_SearchResults.Visible = false;

					this.Master__base.Error_add(
						false,
						"returned no results"
					);
				}
			}
		} 
		#endregion
	}
}