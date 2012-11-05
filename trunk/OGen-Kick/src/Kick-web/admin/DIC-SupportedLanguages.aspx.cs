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

	public partial class DIC_SupportedLanguages : AdminPage {
		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			int[] _errors;
			long _count;

			if (!this.Page.IsPostBack) {
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

						this.CBL_Languages.Kick.Bind__arrayOf<int, string>(
							"",
							false,
							_languages
						);

						this.CBL_Languages.Visible = true;
					} else {
						this.CBL_Languages.Visible = false;

						this.Master__base.Error_add(
							false,
							"returned no results"
						);
					}
				}

				this.Bind();
			}
		}
		#endregion

		#region protected void BTN_Save_Click(object sender, EventArgs e);
		protected void BTN_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			BusinessInstances.DIC_Dic.InstanceClient.setSupportedLanguages(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				this.CBL_Languages.Kick.SelectedValue__get<int>(), 
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				utils.Dic.Languages_reset();
				this.Bind();
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			long _count;

			SO_vDIC_ApplicationLanguage[] _languages
				= BusinessInstances.DIC_Dic.InstanceClient.getRecord_byApplication(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					0, 0, 0, out _count, 
					out _errors
				);
			if (!this.Master__base.Error_add(_errors)) {
				if (_languages.Length > 0) {
					Array.Sort(
						_languages,
						delegate(
							SO_vDIC_ApplicationLanguage arg1_in,
							SO_vDIC_ApplicationLanguage arg2_in
						) {
							return string.Compare(
								arg1_in.Language,
								arg2_in.Language,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);

					this.CBL_Languages.Kick.SelectedValues__set_arrayOf<int, string>(
						_languages
					);
				}
			}
		}
		#endregion
	}
}