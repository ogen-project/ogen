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
	public partial class wuc_txt_Dic : System.Web.UI.UserControl {
		#region public int Rows { set; }
		private int rows_ = 1;

		public int Rows {
			set {
				rows_ = value;
			}
		} 
		#endregion
		#region public string Text_CssClass { set; }
		private string text_cssclass_ = "";

		public string Text_CssClass {
			set {
				text_cssclass_ = value;
			}
		}
		#endregion
		#region public string Label_CssClass { set; }
		private string label_cssclass_ = "";

		public string Label_CssClass {
			set {
				label_cssclass_ = value;
			}
		}
		#endregion
		#region public bool isHorizontal_notVertial { set; }
		private bool ishorizontal_notvertial_ = true;

		public bool isHorizontal_notVertial {
			set {
				ishorizontal_notvertial_ = value;
			}
		} 
		#endregion

		#region private void properties_set(...);
		private void properties_set(
		) {
			properties_set(
				rows_,
				text_cssclass_, 
				label_cssclass_
			);
		}
		private void properties_set(
			int rows_in,
			string text_cssClass_in, 
			string label_cssClass_in
		) {
			Label _lbl_language;
			TextBox _txt_field;
			foreach (RepeaterItem _item in rep_Field.Items) {
				_txt_field = (TextBox)_item.FindControl("txt_Field");
				_lbl_language = (Label)_item.FindControl("lbl_Language");

				_txt_field.CssClass = text_cssclass_;
				_txt_field.Rows = rows_in;
				_txt_field.TextMode = (rows_in > 1) ? TextBoxMode.MultiLine : TextBoxMode.SingleLine;

				_lbl_language.CssClass = label_cssClass_in;

				_item.FindControl("lit_Vertial").Visible = !ishorizontal_notvertial_;
				_item.FindControl("lit_Horizontal").Visible = ishorizontal_notvertial_;
			}
		}
		#endregion

		#region public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] Texts { get; set; }
		private OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] texts_ = null;

		public OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] Texts {
			set {
				texts_ = value;

				bind();
			}
			get {
				if (texts_ != null) {
					// to avoid strange behaviour
					return texts_;
				} else {
					OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[] _output
						= new OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage[rep_Field.Items.Count];

					TextBox _txt_field;
					HiddenField _hfi_idlanguage;
					for (int i = 0; i < rep_Field.Items.Count; i++) {
						_hfi_idlanguage = (HiddenField)rep_Field.Items[i].FindControl("hfi_IDLanguage");
						_txt_field = (TextBox)rep_Field.Items[i].FindControl("txt_Field");

						_output[i] 
							= new OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage(
								int.Parse(_hfi_idlanguage.Value), 
								_txt_field.Text
							);
					}

					return _output;
				}
			}
		}
		#endregion

		#region private void bind(...);
		private void bind(
		) {

//Response.Write("<table border=1>");
//Response.Write(string.Format("<tr><td>binding</td><td>{0}</td><td>{1}</td></tr>", this.ClientID, this.ID));
//Response.Write("</table>");

			// 1st: bind languages
			rep_Field.DataSource = utils.Dic.Languages;
			rep_Field.DataBind();

			// 2nd: assign properties to each language control
			properties_set();

			// 3rd: finally, bind contents, if any
			if (texts_ == null) return;

			TextBox _txt_field;
			HiddenField _hfi_idlanguage;
			foreach (RepeaterItem _item in rep_Field.Items) {
				_hfi_idlanguage = (HiddenField)_item.FindControl("hfi_IDLanguage");
				foreach (OGen.NTier.Kick.lib.datalayer.shared.structures.SO_DIC__TextLanguage _text in texts_) {
					if (
						_hfi_idlanguage.Value == _text.IFLanguage.ToString()
					) {
						_txt_field = (TextBox)_item.FindControl("txt_Field");

						_txt_field.Text = _text.Text;

						break;
					}
				}
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				//bind();
			}
		}
		#endregion
	}
}