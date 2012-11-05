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

	public partial class CRD_Profile : AdminPage {
		#region public long IDProfile { get; }
		private long idprofile__ = -2L;

		public long IDProfile {
			get {
				if (
					(this.idprofile__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDProfile"],
							out this.idprofile__
						)
					)
				) {
					this.idprofile__ = -1L;
				}

				return this.idprofile__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				int[] _errors;
				long _count;

				#region this.CBL_Permissions.Kick.Bind__arrayOf<long, string>(...);
				SO_CRD_Permission[] _permissions
					= BusinessInstances.CRD_Permission.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						false,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_permissions,
						delegate(
							SO_CRD_Permission arg1_in,
							SO_CRD_Permission arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.CBL_Permissions.Kick.Bind__arrayOf<long, string>(
						"",
						false,
						_permissions
					);
				}
				#endregion
				#region this.CBL_Permissions.Kick.Bind__arrayOf<long, string>(...);
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
					this.CBL_ParentProfiles.Kick.Bind__arrayOf<long, string>(
						"",
						false,
						_profiles
					);
				}
				#endregion

				this.Bind();
			}
		} 
		#endregion

		#region public void BTN_Save_Click(object sender, EventArgs e);
		public void BTN_Save_Click(object sender, EventArgs e) {
			bool _isInsert_notUpdate;
			int[] _errors;
			SO_CRD_Profile _profile;
			if (
				#region ((_profile = ...) != null)
				(this.IDProfile > 0)
				&&
				(
					(_profile = BusinessInstances.CRD_Profile.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDProfile,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				_profile.Name = this.TXT_Name.Text;

				BusinessInstances.CRD_Profile.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_profile,

					this.CBL_ParentProfiles.Kick.SelectedValue__get<long>(),
					this.CBL_Permissions.Kick.SelectedValue__get<long>(),

					out _errors
				);

				_isInsert_notUpdate = false;
			} else {
				_profile = new SO_CRD_Profile();
				_profile.Name = this.TXT_Name.Text;
				_profile.IFApplication = utils.IDApplication;
				BusinessInstances.CRD_Profile.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_profile,

					this.CBL_ParentProfiles.Kick.SelectedValue__get<long>(),
					this.CBL_Permissions.Kick.SelectedValue__get<long>(),

					out _errors
				);

				_isInsert_notUpdate = true;
			}
			if (!this.Master__base.Error_add(_errors) && _isInsert_notUpdate) {
				Response.Redirect("~/admin/CRD-Profile-list.aspx");
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			long _count;
			SO_CRD_Profile _profile;
			if (
				#region ((_profile = ...) != null)
				(this.IDProfile > 0)
				&&
				(
					(_profile = BusinessInstances.CRD_Profile.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDProfile,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				this.TXT_Name.Text = _profile.Name;

				#region this.CBL_Permissions.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_ProfilePermission>(...);
				this.CBL_Permissions.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_ProfilePermission>(
					BusinessInstances.CRD_Profile.InstanceClient.getRecord_ofProfilePermission_byProfile(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDProfile,
						0, 0, 0, out _count, 
						out _errors
					),
					delegate(
						SO_vCRD_ProfilePermission item_in
					) {
						return item_in.hasPermission;
					}
				);
				this.Master__base.Error_add(_errors);
				#endregion
				#region this.CBL_ParentProfiles.Kick.SelectedValues__set_arrayOf<SO_CRD_ProfileProfile>(...);
				if (!this.Master__base.Error_add(_errors)) {
					this.CBL_ParentProfiles.Kick.SelectedValues__set_arrayOf<SO_CRD_ProfileProfile>(
						BusinessInstances.CRD_Profile.InstanceClient.getRecord_byProfile(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							this.IDProfile,
							0, 0, 0, out _count, 
							out _errors
						), 
						delegate(
							SO_CRD_ProfileProfile item_in
						) {
							return item_in.IFProfile_parent.ToString(System.Globalization.CultureInfo.CurrentCulture);
						}
					);
				}
				this.Master__base.Error_add(_errors);
				#endregion
			} else {
				this.TXT_Name.Text = "";
			}
		} 
		#endregion
	}
}