#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace OGen.lib.presentationlayer.webforms {
	public class ogen_CheckBox : Anthem.CheckBox {
		[Category("OGen")]
		[DefaultValue("")]
		public string CommandArgument {
			get {
				string _text = (string)ViewState["CommandArgument"];
				return ((_text == null) ? "" : _text);
			}
			set {
				ViewState["CommandArgument"] = value;
			}
		}

		[Category("AddSolutions")]
		[DefaultValue("")]
		public string CommandName {
			get {
				string _text = (string)ViewState["CommandName"];
				return ((_text == null) ? "" : _text);
			}
			set {
				ViewState["CommandName"] = value;
			}
		}
	}
}