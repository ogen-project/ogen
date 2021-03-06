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

	public partial class DIC_Language : AdminPage {
		#region public int IDLanguage { get; }
		private int idlanguage__ = -2;

		public int IDLanguage {
			get {
				if (
					(this.idlanguage__ == -2)
					&&
					(
						!int.TryParse(
							Request.QueryString["IDLanguage"],
							out this.idlanguage__
						)
					)
				) {
					this.idlanguage__ = -1;
				}

				return this.idlanguage__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				//int[] _errors;

				this.Bind();
			}
		} 
		#endregion

		#region public void BTN_Save_Click(object sender, EventArgs e);
		public void BTN_Save_Click(object sender, EventArgs e) {
			int[] _errors;

			if (this.IDLanguage > 0) {
				BusinessInstances.DIC_Dic.InstanceClient.updLanguage(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					this.IDLanguage,
					this.DIC_LanguageNameIn.Texts, 
					out _errors
				);
			} else {
				SO_DIC__TextLanguage[] _texts = this.DIC_LanguageNameIn.Texts;
				SO_DIC__TextLanguage[] _texts_withnew = new SO_DIC__TextLanguage[_texts.Length + 1];
				for (int i = 0; i < _texts.Length; i++) {
					_texts_withnew[i] = _texts[i];
				}
				_texts_withnew[_texts.Length] = new SO_DIC__TextLanguage(
					-1,
					this.TXT_Name.Text
				);

				BusinessInstances.DIC_Dic.InstanceClient.insLanguage(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_texts_withnew,
					this.DIC_LanguagesInNewLanguage.Texts,
					out _errors
				);
			}
			if (!this.Master__base.Error_add(_errors)) {
				Utilities.Dic.Languages_reset();

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

			if (this.IDLanguage > 0) {
				_language = BusinessInstances.DIC_Dic.InstanceClient.getRecord_Language(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					this.IDLanguage,
					0, 0, 0, out _count, 
					out _errors
				);
				if (
					!this.Master__base.Error_add(_errors)
					&&
					(_language.Length > 0)
				) {
					#region this.DIC_LanguageNameIn.Texts = ...;
					List<OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage> _languagename
						= new List<OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_DIC__TextLanguage>(
							_language.Length
						);

					for (int i = 0; i < _language.Length; i++) {
						_languagename.Add(new SO_DIC__TextLanguage(
							_language[i].IDLanguage_translation,
							_language[i].Language
						));
					}
					this.DIC_LanguageNameIn.Texts = _languagename.ToArray();
					#endregion
					this.TBL_NewLanguage.Visible = false;
					this.DIC_LanguagesInNewLanguage.Visible = false;
					this.TR_New1.Visible = false;
					this.TR_New2.Visible = false;
					this.TR_New3.Visible = false;

					_isNew = false;
				}
			}

			if (_isNew) {
				this.DIC_LanguageNameIn.Texts = null;
				this.DIC_LanguagesInNewLanguage.Texts = null;

				this.TR_New1.Visible = true;
				this.TR_New2.Visible = true;
				this.TR_New3.Visible = true;

				this.DIC_LanguagesInNewLanguage.Visible = true;
				this.TBL_NewLanguage.Visible = true;
			}
		} 
		#endregion
	}
}