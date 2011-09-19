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
	public partial class CRD_ProfilePermition : AdminPage {
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				int[] _errors;
				SO_CRD_Profile[] _profiles
					= BusinessInstances.CRD_Profile.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						false, 
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_profiles,
						delegate(
							SO_CRD_Profile arg1_in,
							SO_CRD_Profile arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					ddl_Profile.Kick.Bind__arrayOf<long, string>(
						"",
						false,
						_profiles
					);
					if (ddl_Profile.Items.Count > 0) {
						ddl_Profile.SelectedIndex = 0;
					}

					Bind();
				}
			}
		}

		protected void ddl_Profile_SelectedIndexChanged(object sender, EventArgs e) {
			Bind();
		}
		#region protected void btn_Profile_Click(object sender, EventArgs e);
		protected void btn_Profile_Click(object sender, EventArgs e) {
			int[] _errors;

			BusinessInstances.CRD_Permition.InstanceClient.setProfilePermitions(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				long.Parse(ddl_Profile.SelectedValue),
				cbl_Permitions.Kick.SelectedValue__get<long>(), 
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
			SO_CRD_Permition[] _permitions
				= BusinessInstances.CRD_Permition.InstanceClient.getRecord_all(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					false, 
					0, 0,
					out _errors
				);
			if (!Master__base.Error_show(_errors)) {
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

				cbl_Permitions.Kick.SelectedValues__set_arrayOf<long, string, SO_vCRD_ProfilePermition>(
					BusinessInstances.CRD_Permition.InstanceClient.getRecord_ofProfilePermition_byProfile(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						long.Parse(ddl_Profile.SelectedValue),
						0, 0,
						out _errors
					),
					delegate(
						SO_vCRD_ProfilePermition item_in
					) {
						return item_in.hasPermition;
					}
				);
				if (!Master__base.Error_show(_errors)) {
					// ToDos: here!
				}
			}
		}
		#endregion
	}
}