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

	public partial class ServerVariables : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
#if DEBUG
			System.Text.StringBuilder _sb = new System.Text.StringBuilder();

			_sb.Append("<br />" + Server.MapPath("ServerVariables.aspx") + "<br />");

			foreach (string _key in Request.ServerVariables.AllKeys) {
				_sb.Append( string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"--- <b>{0}</b><br />{1}<br /><br />",
					_key, 
					Request.ServerVariables[_key]
				));
			}

			foreach (string _key in Request.Params.AllKeys) {
				_sb.Append( string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"--- <b>{0}</b><br />{1}<br /><br />",
					_key,
					Request.Params[_key]
				));
			}

			this.LIT_Dump.Text = _sb.ToString();
#endif
		}
	}
}