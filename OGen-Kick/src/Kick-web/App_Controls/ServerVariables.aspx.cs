using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class ServerVariables : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
#if DEBUG
			System.Text.StringBuilder _sb = new System.Text.StringBuilder();

			_sb.Append("<br />" + Server.MapPath("ServerVariables.aspx") + "<br />");

			foreach (string _key in Request.ServerVariables.AllKeys) {
				_sb.Append( string.Format(
					"--- <b>{0}</b><br />{1}<br /><br />",
					_key, 
					Request.ServerVariables[_key]
				));
			}

			foreach (string _key in Request.Params.AllKeys) {
				_sb.Append( string.Format(
					"--- <b>{0}</b><br />{1}<br /><br />",
					_key,
					Request.Params[_key]
				));
			}

			lit_dump.Text = _sb.ToString();
#endif
		}
	}
}