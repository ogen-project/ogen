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

	public partial class NWS_NewsTag : AdminPage {
		#region public long IDTag { get; }
		private long idtag__ = -2L;

		public long IDTag {
			get {
				if (
					(this.idtag__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDTag"],
							out this.idtag__
						)
					)
				) {
					this.idtag__ = -1L;
				}

				return this.idtag__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				int[] _errors;
				long _count;
				SO_vNWS_Tag[] _tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byLang(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						Utilities.IDLanguage__default,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_tags,
						delegate(
							SO_vNWS_Tag arg1_in,
							SO_vNWS_Tag arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.DDL_Tag_parent.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_tags
					);
				}


				this.Bind();
			}
		} 
		#endregion

		#region public void BTN_Save_Click(object sender, EventArgs e);
		private void btn_save_click(
			ref SO_NWS_Tag tag_ref
		) {
			#region tag_ref.IFTag__parent = long.Parse(this.DDL_Tag_parent.SelectedValue);
			if (string.IsNullOrEmpty(this.DDL_Tag_parent.SelectedValue)) {
				tag_ref.IFTag__parent_isNull = true;
			} else {
				//tag_ref.IFTag__parent = DDL_Tag_parent.Kick.SelectedValue__get<long>();
				tag_ref.IFTag__parent = long.Parse(
					this.DDL_Tag_parent.SelectedValue, 
					System.Globalization.NumberStyles.Integer, 
					System.Globalization.CultureInfo.CurrentCulture
				);
			}
			#endregion
		}

		public void BTN_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Tag _tag;
			if (
				#region ((_tag = ...) != null)
				(this.IDTag > 0)
				&&
				(
					(_tag = BusinessInstances.NWS_Tag.InstanceClient.getObject(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						this.IDTag, 
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				#region _tag.IFTag__parent = long.Parse(this.DDL_Tag_parent.SelectedValue);
				this.btn_save_click(
					ref _tag
				);
				#endregion
				BusinessInstances.NWS_Tag.InstanceClient.updObject(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_tag,
					this.DIC_Name.Texts, 
					out _errors
				);
			} else {
				_tag = new SO_NWS_Tag();
				#region _tag.IFTag__parent = long.Parse(this.DDL_Tag_parent.SelectedValue);
				this.btn_save_click(
					ref _tag
				);
				#endregion
				_tag.Approved_date_isNull = true;
				_tag.IFUser__Approved_isNull = true;
				_tag.IFApplication = Utilities.IDApplication;
				BusinessInstances.NWS_Tag.InstanceClient.insObject(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_tag,
					this.DIC_Name.Texts, 
					false,
					out _errors
				);
			}
			if (!this.Master__base.Error_add(_errors)) {
				Response.Redirect(
					"NWS-NewsTag-list.aspx",
					true
				);
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			long _count;
			SO_vNWS_Tag[] _tags;
			if (
				#region ((_tags = ...) != null)
				(this.IDTag > 0)
				&&
				(
					(_tags = BusinessInstances.NWS_Tag.InstanceClient.getRecord_byTag(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						this.IDTag,
						0, 0, 0, out _count, 
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				&&
				(_tags.Length != 0)
				#endregion
			) {
				#region this.DIC_Name.Texts = ...;
				List<OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage> _name
					= new List<OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage>(
						_tags.Length
					);

				foreach (SO_vNWS_Tag _tag in _tags) {
					_name.Add(new SO_DIC__TextLanguage(
						_tag.IDLanguage,
						_tag.ShortName
					));
				}
				this.DIC_Name.Texts = _name.ToArray();
				#endregion
				#region this.DDL_Tag_parent.SelectedValue = _tags[0].IFTag__parent.ToString();
				if (_tags[0].IFTag__parent_isNull) {
					this.DDL_Tag_parent.SelectedValue = "";
				} else {
					this.DDL_Tag_parent.SelectedValue = _tags[0].IFTag__parent.ToString(System.Globalization.CultureInfo.CurrentCulture);
				}
				#endregion
			} else {
				this.DIC_Name.Texts = null;
				this.DDL_Tag_parent.SelectedValue = "";
			}
		} 
		#endregion
	}
}