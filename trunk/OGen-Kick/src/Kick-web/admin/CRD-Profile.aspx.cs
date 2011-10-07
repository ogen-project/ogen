﻿#region Copyright (C) 2002 Francisco Monteiro
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
	public partial class CRD_Profile : AdminPage {
		#region public long IDProfile { get; }
		private long idprofile__ = -2L;

		public long IDProfile {
			get {
				if (
					(idprofile__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDProfile"],
							out idprofile__
						)
					)
				) {
					idprofile__ = -1L;
				}

				return idprofile__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				int[] _errors;
				long _count;

				#region cbl_Permitions.Kick.Bind__arrayOf<long, string>(...);
				SO_CRD_Permition[] _permitions
					= BusinessInstances.CRD_Permition.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						false,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!Master__base.Error_add(_errors)) {
					Array.Sort(
						_permitions,
						delegate(
							SO_CRD_Permition arg1_in,
							SO_CRD_Permition arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_Permitions.Kick.Bind__arrayOf<long, string>(
						"",
						false,
						_permitions
					);
				}
				#endregion
				#region cbl_Permitions.Kick.Bind__arrayOf<long, string>(...);
				SO_CRD_Profile[] _profiles
					= BusinessInstances.CRD_Profile.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						false,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!Master__base.Error_add(_errors)) {
					Array.Sort(
						_profiles,
						delegate(
							SO_CRD_Profile arg1_in,
							SO_CRD_Profile arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_ParentProfiles.Kick.Bind__arrayOf<long, string>(
						"",
						false,
						_profiles
					);
				}
				#endregion

				Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		public void btn_Save_Click(object sender, EventArgs e) {
			bool _isInsert_notUpdate;
			int[] _errors;
			SO_CRD_Profile _profile;
			if (
				#region ((_profile = ...) != null)
				(IDProfile > 0)
				&&
				(
					(_profile = BusinessInstances.CRD_Profile.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDProfile,
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_add(_errors)
				#endregion
			) {
				_profile.Name = txt_Name.Text;

				BusinessInstances.CRD_Profile.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_profile,

					cbl_ParentProfiles.Kick.SelectedValue__get<long>(),
					cbl_Permitions.Kick.SelectedValue__get<long>(),

					out _errors
				);

				_isInsert_notUpdate = false;
			} else {
				_profile = new SO_CRD_Profile();
				_profile.Name = txt_Name.Text;
				_profile.IFApplication = utils.IDApplication;
				BusinessInstances.CRD_Profile.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_profile,

					cbl_ParentProfiles.Kick.SelectedValue__get<long>(),
					cbl_Permitions.Kick.SelectedValue__get<long>(),

					out _errors
				);

				_isInsert_notUpdate = true;
			}
			if (!Master__base.Error_add(_errors) && _isInsert_notUpdate) {
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
				(IDProfile > 0)
				&&
				(
					(_profile = BusinessInstances.CRD_Profile.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDProfile,
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_add(_errors)
				#endregion
			) {
				txt_Name.Text = _profile.Name;

				#region cbl_Permitions.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_ProfilePermition>(...);
				cbl_Permitions.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_ProfilePermition>(
					BusinessInstances.CRD_Profile.InstanceClient.getRecord_ofProfilePermition_byProfile(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDProfile,
						0, 0, 0, out _count, 
						out _errors
					),
					delegate(
						SO_vCRD_ProfilePermition item_in
					) {
						return item_in.hasPermition;
					}
				);
				Master__base.Error_add(_errors);
				#endregion
				#region cbl_ParentProfiles.Kick.SelectedValues__set_arrayOf<SO_CRD_ProfileProfile>(...);
				if (!Master__base.Error_add(_errors)) {
					cbl_ParentProfiles.Kick.SelectedValues__set_arrayOf<SO_CRD_ProfileProfile>(
						BusinessInstances.CRD_Profile.InstanceClient.getRecord_byProfile(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							IDProfile,
							0, 0, 0, out _count, 
							out _errors
						), 
						delegate(
							SO_CRD_ProfileProfile item_in
						) {
							return item_in.IFProfile_parent.ToString();
						}
					);
				}
				Master__base.Error_add(_errors);
				#endregion
			} else {
				txt_Name.Text = "";
			}
		} 
		#endregion
	}
}