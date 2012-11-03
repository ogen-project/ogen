#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	using System;
	using System.Collections.Generic;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.structures;
	using OGen.NTier.Kick.lib.datalayer.shared;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;
	using OGen.NTier.Kick.lib.presentationlayer.weblayer;

	using BusinessInstances = OGen.NTier.Kick.lib.businesslayer.shared.instances;

	public partial class DIC_Language_list : AdminPage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}
		#endregion

		#region protected void BTN_Delete_Click(object sender, EventArgs e);
		protected void BTN_Delete_Click(object sender, EventArgs e) {
			int _idLanguage = int.Parse(
				((IButtonControl)sender).CommandArgument,
				System.Globalization.NumberStyles.Integer,
				System.Globalization.CultureInfo.CurrentCulture
			);

			int[] _errors;
			BusinessInstances.DIC_Dic.InstanceClient.delLanguage(
			    utils.User.SessionGuid,
			    utils.ClientIPAddress,
			    _idLanguage,
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

			SO_vDIC_Language[] _languages
				= BusinessInstances.DIC_Dic.InstanceClient.getRecord_byLanguage(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					utils.IDLanguage__default,
					0, 0, 0, out _count, 
					out _errors
				);
			if (!this.Master__base.Error_add(_errors)) {
				if (_languages.Length > 0) {
					Array.Sort(
						_languages,
						delegate(
							SO_vDIC_Language arg1_in,
							SO_vDIC_Language arg2_in
						) {
							return string.Compare(
								arg1_in.Language,
								arg2_in.Language,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.REP_Languages.DataSource = _languages;
					this.REP_Languages.DataBind();

					this.REP_Languages.Visible = true;
				} else {
					this.REP_Languages.Visible = false;

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