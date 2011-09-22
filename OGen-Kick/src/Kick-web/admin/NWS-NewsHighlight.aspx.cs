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
	public partial class NWS_NewsHighlight : AdminPage {
		#region public long IDHighlight { get; }
		private long idhighlight__ = -2L;

		public long IDHighlight {
			get {
				if (
					(idhighlight__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDHighlight"],
							out idhighlight__
						)
					)
				) {
					idhighlight__ = -1L;
				}

				return idhighlight__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				int[] _errors;
				SO_vNWS_Highlight[] _highlights
					= BusinessInstances.NWS_Highlight.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_highlights,
						delegate(
							SO_vNWS_Highlight arg1_in,
							SO_vNWS_Highlight arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					ddl_Highlight_parent.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_highlights
					);
				}


				Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		private void btn_save_click(
			ref SO_NWS_Highlight highlight_ref
		) {
			highlight_ref.Name = txt_Name.Text;
			#region highlight_ref.IFHighlight__parent = long.Parse(ddl_Highlight_parent.SelectedValue);
			if (ddl_Highlight_parent.SelectedValue == "") {
				highlight_ref.IFHighlight__parent_isNull = true;
			} else {
				//highlight_ref.IFHighlight__parent = ddl_Highlight_parent.Kick.SelectedValue__get<long>();
				highlight_ref.IFHighlight__parent = long.Parse(ddl_Highlight_parent.SelectedValue);
			}
			#endregion
		}

		public void btn_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Highlight _highlight;
			if (
				#region ((_highlight = ...) != null)
				(IDHighlight > 0)
				&&
				(
					(_highlight = BusinessInstances.NWS_Highlight.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDHighlight,
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_show(_errors)
				#endregion
			) {

				btn_save_click(
					ref _highlight
				);

				BusinessInstances.NWS_Highlight.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_highlight,
					out _errors
				);
			} else {
				_highlight = new SO_NWS_Highlight();

				btn_save_click(
					ref _highlight
				);

				_highlight.Approved_date_isNull = true;
				_highlight.IFUser__Approved_isNull = true;
				_highlight.IFApplication = utils.IDApplication;
				BusinessInstances.NWS_Highlight.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_highlight,
					false,
					out _errors
				);
			}
			if (!Master__base.Error_show(_errors)) {
				Response.Redirect(
					"NWS-NewsHighlight-list.aspx",
					true
				);
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			SO_NWS_Highlight _highlight;
			if (
				#region ((_highlight = ...) != null)
				(IDHighlight > 0)
				&&
				(
					(_highlight = BusinessInstances.NWS_Highlight.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDHighlight,
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_show(_errors)
				#endregion
			) {
				txt_Name.Text = _highlight.Name;
				#region ddl_Highlight_parent.SelectedValue = _highlight.IFHighlight__parent.ToString();
				if (_highlight.IFHighlight__parent_isNull) {
					ddl_Highlight_parent.SelectedValue = "";
				} else {
					ddl_Highlight_parent.SelectedValue = _highlight.IFHighlight__parent.ToString();
				}
				#endregion
			} else {
				txt_Name.Text = "";
			}
		} 
		#endregion
	}
}