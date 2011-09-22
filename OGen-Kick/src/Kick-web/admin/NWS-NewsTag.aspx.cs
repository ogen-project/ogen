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
	public partial class NWS_NewsTag : AdminPage {
		#region public long IDTag { get; }
		private long idtag__ = -2L;

		public long IDTag {
			get {
				if (
					(idtag__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDTag"],
							out idtag__
						)
					)
				) {
					idtag__ = -1L;
				}

				return idtag__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				int[] _errors;
				SO_vNWS_Tag[] _tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byLang(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						utils.IDLanguage__default, 
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_tags,
						delegate(
							SO_vNWS_Tag arg1_in,
							SO_vNWS_Tag arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					ddl_Tag_parent.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_tags
					);
				}


				Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		private void btn_save_click(
			ref SO_NWS_Tag tag_ref
		) {
			#region tag_ref.IFTag__parent = long.Parse(ddl_Tag_parent.SelectedValue);
			if (ddl_Tag_parent.SelectedValue == "") {
				tag_ref.IFTag__parent_isNull = true;
			} else {
				//tag_ref.IFTag__parent = ddl_Tag_parent.Kick.SelectedValue__get<long>();
				tag_ref.IFTag__parent = long.Parse(ddl_Tag_parent.SelectedValue);
			}
			#endregion
		}

		public void btn_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Tag _tag;
			if (
				#region ((_tag = ...) != null)
				(IDTag > 0)
				&&
				(
					(_tag = BusinessInstances.NWS_Tag.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDTag, 
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_show(_errors)
				#endregion
			) {
				#region _tag.IFTag__parent = long.Parse(ddl_Tag_parent.SelectedValue);
				btn_save_click(
					ref _tag
				);
				#endregion
				BusinessInstances.NWS_Tag.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_tag,
					dic_Name.Texts, 
					out _errors
				);
			} else {
				_tag = new SO_NWS_Tag();
				#region _tag.IFTag__parent = long.Parse(ddl_Tag_parent.SelectedValue);
				btn_save_click(
					ref _tag
				);
				#endregion
				_tag.Approved_date_isNull = true;
				_tag.IFUser__Approved_isNull = true;
				_tag.IFApplication = utils.IDApplication;
				BusinessInstances.NWS_Tag.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_tag, 
					dic_Name.Texts, 
					false,
					out _errors
				);
			}
			if (!Master__base.Error_show(_errors)) {
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
			SO_vNWS_Tag[] _tags;
			if (
				#region ((_tags = ...) != null)
				(IDTag > 0)
				&&
				(
					(_tags = BusinessInstances.NWS_Tag.InstanceClient.getRecord_byTag(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDTag,
						0, 0, 
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_show(_errors)
				&&
				(_tags.Length != 0)
				#endregion
			) {
				#region dic_Name.Texts = ...;
				List<OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage> _name
					= new List<OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage>(
						_tags.Length
					);

				SO_DIC__TextLanguage[] _texts = new SO_DIC__TextLanguage[_tags.Length];
				foreach (SO_vNWS_Tag _tag in _tags) {
					_name.Add(new SO_DIC__TextLanguage(
						_tag.IDLanguage,
						_tag.ShortName
					));
				}
				dic_Name.Texts = _name.ToArray();
				#endregion
				#region ddl_Tag_parent.SelectedValue = _tags[0].IFTag__parent.ToString();
				if (_tags[0].IFTag__parent_isNull) {
					ddl_Tag_parent.SelectedValue = "";
				} else {
					ddl_Tag_parent.SelectedValue = _tags[0].IFTag__parent.ToString();
				}
				#endregion
			} else {
				dic_Name.Texts = null;
				ddl_Tag_parent.SelectedValue = "";
			}
		} 
		#endregion
	}
}