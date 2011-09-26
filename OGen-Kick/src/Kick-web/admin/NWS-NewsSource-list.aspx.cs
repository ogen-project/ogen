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
	public partial class NWS_NewsSource_list : AdminPage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				Bind();
			}
		} 
		#endregion

		#region protected void btn_Delete_Click(object sender, EventArgs e);
		protected void btn_Delete_Click(object sender, EventArgs e) {
			long _idSource = long.Parse(((IButtonControl)sender).CommandArgument);
			int[] _errors;
			BusinessInstances.NWS_Source.InstanceClient.delObject(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				_idSource,
				out _errors
			);
			if (!Master__base.Error_show(_errors)) {
				Bind();
			}
		}
		#endregion
		#region protected void btn_Approve_Click(object sender, EventArgs e);
		protected void btn_Approve_Click(object sender, EventArgs e) {
			long _idSource = long.Parse(((IButtonControl)sender).CommandArgument);
			int[] _errors;
			BusinessInstances.NWS_Source.InstanceClient.updObject_Approve(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				_idSource,
				out _errors
			);
			if (!Master__base.Error_show(_errors)) {
				Bind();
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			SO_vNWS_Source[] _sources
				= BusinessInstances.NWS_Source.InstanceClient.getRecord_all(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					0, 0,
					out _errors
				);
			if (!Master__base.Error_show(_errors)) {
				if (_sources.Length > 0) {
					Array.Sort(
						_sources,
						delegate(
							SO_vNWS_Source arg1_in,
							SO_vNWS_Source arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					rep_Sources.DataSource = _sources;
					rep_Sources.DataBind();

					rep_Sources.Visible = true;
				} else {
					rep_Sources.Visible = false;

					Master__base.Error_show(
						false,
						"returned no results"
					);
				}
			}
		}
		#endregion
	}
}