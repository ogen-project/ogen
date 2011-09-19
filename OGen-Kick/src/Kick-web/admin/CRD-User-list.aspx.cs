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
	public partial class CRD_User_list : AdminPage {
		#region protected void Page_Load(object sender, EventArgs e);
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

					ddl_Profile__in.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_profiles
					);
					//if (ddl_Profile__in.Items.Count > 0) {
					ddl_Profile__in.SelectedIndex = 0;
					//}

					ddl_Profile__out.Kick.Bind__Copy(
						ddl_Profile__in,
						"",
						true
					);
					//if (ddl_Profile__out.Items.Count > 0) {
					ddl_Profile__out.SelectedIndex = 0;
					//}

					Bind();
				}
			}
		}
		#endregion
		#region protected void btn_Search_Click(object sender, EventArgs e);
		protected void btn_Search_Click(object sender, EventArgs e) {
			Bind();
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			SO_vNET_User[] _users
				= BusinessInstances.WEB_User.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					txt_Login.Text.Trim(),
					txt_EMail.Text.Trim(),
					txt_Name.Text.Trim(),
					(ddl_Profile__in.SelectedValue == "") ? 0L : long.Parse(ddl_Profile__in.SelectedValue),
					(ddl_Profile__out.SelectedValue == "") ? 0L : long.Parse(ddl_Profile__out.SelectedValue),
					0, 0,

					out _errors
				);
			if (!Master__base.Error_show(_errors)) {
				Array.Sort(
					_users, 
					delegate(
						SO_vNET_User arg1_in, 
						SO_vNET_User arg2_in
					) {
						return arg2_in.IDUser.CompareTo(arg1_in.IDUser);
					}
				);

				rep_SearchResults.DataSource = _users;
				rep_SearchResults.DataBind();
			}
		} 
		#endregion
	}
}