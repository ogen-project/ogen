﻿#region Copyright (C) 2002 Francisco Monteiro
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

	public partial class NWS_NewsTag_list : AdminPage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		} 
		#endregion

		#region protected void BTN_Delete_Click(object sender, EventArgs e);
		protected void BTN_Delete_Click(object sender, EventArgs e) {
			long _idTag = long.Parse(
				((IButtonControl)sender).CommandArgument, 
				System.Globalization.NumberStyles.Integer, 
				System.Globalization.CultureInfo.CurrentCulture
			);
			int[] _errors;
			BusinessInstances.NWS_Tag.InstanceClient.delObject(
				Utilities.User.SessionGuid,
				Utilities.ClientIPAddress,
				_idTag,
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				this.Bind();
			}
		}
		#endregion
		#region protected void BTN_Approve_Click(object sender, EventArgs e);
		protected void BTN_Approve_Click(object sender, EventArgs e) {
			long _idTag = long.Parse(
				((IButtonControl)sender).CommandArgument, 
				System.Globalization.NumberStyles.Integer, 
				System.Globalization.CultureInfo.CurrentCulture
			);
			int[] _errors;
			BusinessInstances.NWS_Tag.InstanceClient.updObject_Approve(
				Utilities.User.SessionGuid,
				Utilities.ClientIPAddress,
				_idTag,
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				this.Bind();
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
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
				if (_tags.Length > 0) {
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
					this.REP_Tags.DataSource = _tags;
					this.REP_Tags.DataBind();

					this.REP_Tags.Visible = true;
				} else {
					this.REP_Tags.Visible = false;

					this.Master__base.Error_add(
						false,
						"returned no results"
					);
				}
			}
		}
		#endregion
	}
}