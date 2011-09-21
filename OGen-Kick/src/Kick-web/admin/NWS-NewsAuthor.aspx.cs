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
	public partial class NWS_NewsAuthor : AdminPage {
		#region public long IDAuthor { get; }
		private long idauthor__ = -2L;

		public long IDAuthor {
			get {
				if (
					(idauthor__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDAuthor"],
							out idauthor__
						)
					)
				) {
					idauthor__ = -1L;
				}

				return idauthor__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		public void btn_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Author _author;
			if (
				#region ((_author = ...) != null)
				(IDAuthor > 0)
				&&
				(
					(_author = BusinessInstances.NWS_Author.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDAuthor,
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_show(_errors)
				#endregion
			) {
				_author.Name = txt_Name.Text;

				BusinessInstances.NWS_Author.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_author,
					out _errors
				);
			} else {
				_author = new SO_NWS_Author();

				_author.Name = txt_Name.Text;
				_author.Approved_date_isNull = true;
				_author.IFUser__Approved_isNull = true;
				//_author.IFApplication = utils.IDApplication;
				BusinessInstances.NWS_Author.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_author,
					false,
					out _errors
				);
			}
			if (!Master__base.Error_show(_errors)) {
				Response.Redirect(
					"NWS-NewsAuthor-list.aspx",
					true
				);
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			SO_NWS_Author _author;
			if (
				#region ((_author = ...) != null)
				(IDAuthor > 0)
				&&
				(
					(_author = BusinessInstances.NWS_Author.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDAuthor,
						out _errors
					))
					!=
					null
				)
				&&
				!Master__base.Error_show(_errors)
				#endregion
			) {
				txt_Name.Text = _author.Name;
			} else {
				txt_Name.Text = "";
			}
		} 
		#endregion
	}
}