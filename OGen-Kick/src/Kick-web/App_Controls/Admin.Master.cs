using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	public partial class AdminPage : System.Web.UI.Page {
		public Admin Master_Admin {
			get {
				return (Admin)Master;
			}
		}
		public _base Master__base {
			get {
				return (_base)((Admin)Master).Master;
			}
		}
	}

	public partial class Admin : System.Web.UI.MasterPage {
		#region //public _base Master__base { get; }
		//public _base Master__base {
		//    get {
		//        return (_base)Master;
		//    }
		//}
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			
		}
	}
}