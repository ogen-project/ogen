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

	public partial class NWS_NewsAuthor : AdminPage {
		#region public long IDAuthor { get; }
		private long idauthor__ = -2L;

		public long IDAuthor {
			get {
				if (
					(this.idauthor__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDAuthor"],
							out this.idauthor__
						)
					)
				) {
					this.idauthor__ = -1L;
				}

				return this.idauthor__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		} 
		#endregion

		#region public void BTN_Save_Click(object sender, EventArgs e);
		public void BTN_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Author _author;
			if (
				#region ((_author = ...) != null)
				(this.IDAuthor > 0)
				&&
				(
					(_author = BusinessInstances.NWS_Author.InstanceClient.getObject(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						this.IDAuthor,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				_author.Name = this.TXT_Name.Text;

				BusinessInstances.NWS_Author.InstanceClient.updObject(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_author,
					out _errors
				);
			} else {
				_author = new SO_NWS_Author();

				_author.Name = this.TXT_Name.Text;
				_author.Approved_date_isNull = true;
				_author.IFUser__Approved_isNull = true;
				//_author.IFApplication = Utilities.IDApplication;
				BusinessInstances.NWS_Author.InstanceClient.insObject(
					Utilities.User.SessionGuid,
					Utilities.ClientIPAddress,
					_author,
					false,
					out _errors
				);
			}
			if (!this.Master__base.Error_add(_errors)) {
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
				(this.IDAuthor > 0)
				&&
				(
					(_author = BusinessInstances.NWS_Author.InstanceClient.getObject(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						this.IDAuthor,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				this.TXT_Name.Text = _author.Name;
			} else {
				this.TXT_Name.Text = "";
			}
		} 
		#endregion
	}
}