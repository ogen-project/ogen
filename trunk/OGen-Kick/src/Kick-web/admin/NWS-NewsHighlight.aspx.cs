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

	public partial class NWS_NewsHighlight : AdminPage {
		#region public long IDHighlight { get; }
		private long idhighlight__ = -2L;

		public long IDHighlight {
			get {
				if (
					(this.idhighlight__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDHighlight"],
							out this.idhighlight__
						)
					)
				) {
					this.idhighlight__ = -1L;
				}

				return this.idhighlight__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				int[] _errors;
				long _count;
				SO_vNWS_Highlight[] _highlights
					= BusinessInstances.NWS_Highlight.InstanceClient.getRecord_all(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_highlights,
						delegate(
							SO_vNWS_Highlight arg1_in,
							SO_vNWS_Highlight arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.DDL_Highlight_parent.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_highlights
					);
				}


				this.Bind();
			}
		} 
		#endregion

		#region public void BTN_Save_Click(object sender, EventArgs e);
		private void btn_save_click(
			ref SO_NWS_Highlight highlight_ref
		) {
			highlight_ref.Name = this.TXT_Name.Text;
			#region highlight_ref.IFHighlight__parent = long.Parse(DDL_Highlight_parent.SelectedValue);
			if (string.IsNullOrEmpty(this.DDL_Highlight_parent.SelectedValue)) {
				highlight_ref.IFHighlight__parent_isNull = true;
			} else {
				//highlight_ref.IFHighlight__parent = DDL_Highlight_parent.Kick.SelectedValue__get<long>();
				highlight_ref.IFHighlight__parent = long.Parse(
					this.DDL_Highlight_parent.SelectedValue,
					System.Globalization.NumberStyles.Integer,
					System.Globalization.CultureInfo.CurrentCulture
				);
			}
			#endregion
		}

		public void BTN_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Highlight _highlight;
			if (
				#region ((_highlight = ...) != null)
				(this.IDHighlight > 0)
				&&
				(
					(_highlight = BusinessInstances.NWS_Highlight.InstanceClient.getObject(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						this.IDHighlight,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {

				this.btn_save_click(
					ref _highlight
				);

				BusinessInstances.NWS_Highlight.InstanceClient.updObject(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_highlight,
					out _errors
				);
			} else {
				_highlight = new SO_NWS_Highlight();

				this.btn_save_click(
					ref _highlight
				);

				_highlight.Approved_date_isNull = true;
				_highlight.IFUser__Approved_isNull = true;
				_highlight.IFApplication = Utilities.IDApplication;
				BusinessInstances.NWS_Highlight.InstanceClient.insObject(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_highlight,
					false,
					out _errors
				);
			}
			if (!this.Master__base.Error_add(_errors)) {
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
				(this.IDHighlight > 0)
				&&
				(
					(_highlight = BusinessInstances.NWS_Highlight.InstanceClient.getObject(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						this.IDHighlight,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				this.TXT_Name.Text = _highlight.Name;
				#region this.DDL_Highlight_parent.SelectedValue = _highlight.IFHighlight__parent.ToString();
				if (_highlight.IFHighlight__parent_isNull) {
					this.DDL_Highlight_parent.SelectedValue = "";
				} else {
					this.DDL_Highlight_parent.SelectedValue = _highlight.IFHighlight__parent.ToString(System.Globalization.CultureInfo.CurrentCulture);
				}
				#endregion
			} else {
				this.TXT_Name.Text = "";
			}
		} 
		#endregion
	}
}