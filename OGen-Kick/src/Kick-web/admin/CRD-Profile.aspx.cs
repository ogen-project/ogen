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
				Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		public void btn_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_CRD_Profile _profile;
			if (
				#region ((_author = ...) != null)
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

null,
null,

					out _errors
				);
			} else {
				_profile = new SO_CRD_Profile();
				_profile.Name = txt_Name.Text;
				_profile.IFApplication = utils.IDApplication;
				BusinessInstances.CRD_Profile.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_profile,

null,
null,

					out _errors
				);
			}
			if (!Master__base.Error_add(_errors)) {
				Response.Redirect(
					"NWS-NewsAuthor-list.aspx",
					true
				);
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			SO_CRD_Profile _profile;
			if (
				#region ((_author = ...) != null)
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
			} else {
				txt_Name.Text = "";
			}
		} 
		#endregion
	}
}