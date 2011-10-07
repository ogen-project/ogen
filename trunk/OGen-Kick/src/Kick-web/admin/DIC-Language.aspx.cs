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
	public partial class DIC_Language : AdminPage {
		#region public int IDLanguage { get; }
		private int idlanguage__ = -2;

		public int IDLanguage {
			get {
				if (
					(idlanguage__ == -2)
					&&
					(
						!int.TryParse(
							Request.QueryString["IDLanguage"],
							out idlanguage__
						)
					)
				) {
					idlanguage__ = -1;
				}

				return idlanguage__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				int[] _errors;

				Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		public void btn_Save_Click(object sender, EventArgs e) {
			int[] _errors;

			if (IDLanguage > 0) {
				BusinessInstances.DIC_Dic.InstanceClient.updLanguage(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					IDLanguage,
					dic_LanguageNameIn.Texts, 
					out _errors
				);
			} else {
				SO_DIC__TextLanguage[] _texts = dic_LanguageNameIn.Texts;
				SO_DIC__TextLanguage[] _texts_withnew = new SO_DIC__TextLanguage[_texts.Length + 1];
				for (int i = 0; i < _texts.Length; i++) {
					_texts_withnew[i] = _texts[i];
				}
				_texts_withnew[_texts.Length] = new SO_DIC__TextLanguage(
					-1,
					txt_Name.Text
				);

				BusinessInstances.DIC_Dic.InstanceClient.insLanguage(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_texts_withnew,
					dic_LanguagesInNewLanguage.Texts,
					out _errors
				);
			}
			if (!Master__base.Error_add(_errors)) {
				utils.Dic.Languages_reset();

				Response.Redirect("~/admin/DIC-Language-list.aspx");
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			bool _isNew = true;
			int[] _errors;
			long _count;
			SO_vDIC_Language[] _language;

			if (IDLanguage > 0) {
				_language = BusinessInstances.DIC_Dic.InstanceClient.getRecord_Language(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					IDLanguage,
					0, 0, 0, out _count, 
					out _errors
				);
				if (
					!Master__base.Error_add(_errors)
					&&
					(_language.Length > 0)
				) {
					#region dic_LanguageNameIn.Texts = ...;
					List<OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage> _languagename
						= new List<OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage>(
							_language.Length
						);

					for (int i = 0; i < _language.Length; i++) {
						_languagename.Add(new SO_DIC__TextLanguage(
							_language[i].IDLanguage_translation,
							_language[i].Language
						));
					}
					dic_LanguageNameIn.Texts = _languagename.ToArray();
					#endregion
					tbl_NewLanguage.Visible = false;
					dic_LanguagesInNewLanguage.Visible = false;
					tr_new1.Visible = false;
					tr_new2.Visible = false;
					tr_new3.Visible = false;

					_isNew = false;
				}
			}

			if (_isNew) {
				dic_LanguageNameIn.Texts = null;
				dic_LanguagesInNewLanguage.Texts = null;

				tr_new1.Visible = true;
				tr_new2.Visible = true;
				tr_new3.Visible = true;

				dic_LanguagesInNewLanguage.Visible = true;
				tbl_NewLanguage.Visible = true;
			}
		} 
		#endregion
	}
}