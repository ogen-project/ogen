﻿#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.presentationlayer.weblayer {
	using System;
	using System.Collections.Generic;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;

	using OGen.NTier.Kick.lib.businesslayer.shared;
	using OGen.NTier.Kick.lib.businesslayer.shared.structures;
	using OGen.NTier.Kick.lib.datalayer.shared;
	using OGen.NTier.Kick.lib.datalayer.shared.structures;
	using OGen.NTier.Kick.lib.presentationlayer.weblayer;

	using BusinessInstances = OGen.NTier.Kick.lib.businesslayer.shared.instances;

	public partial class NWS_NewsSource : AdminPage {
		#region public long IDSource { get; }
		private long idsource__ = -2L;

		public long IDSource {
			get {
				if (
					(this.idsource__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDSource"],
							out this.idsource__
						)
					)
				) {
					this.idsource__ = -1L;
				}

				return this.idsource__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				int[] _errors;
				long _count;
				SO_vNWS_Source[] _sources
					= BusinessInstances.NWS_Source.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_sources,
						delegate(
							SO_vNWS_Source arg1_in,
							SO_vNWS_Source arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.ddl_Source_parent.Kick.Bind__arrayOf<long, string>(
						"",
						true,
						_sources
					);
				}


				this.Bind();
			}
		} 
		#endregion

		#region public void btn_Save_Click(object sender, EventArgs e);
		private void btn_save_click(
			ref SO_NWS_Source source_ref
		) {
			source_ref.Name = this.txt_Name.Text;
			#region source_ref.IFSource__parent = long.Parse(this.ddl_Source_parent.SelectedValue);
			if (string.IsNullOrEmpty(this.ddl_Source_parent.SelectedValue)) {
				source_ref.IFSource__parent_isNull = true;
			} else {
				//source_ref.IFSource__parent = ddl_Source_parent.Kick.SelectedValue__get<long>();
				source_ref.IFSource__parent = long.Parse(
					this.ddl_Source_parent.SelectedValue,
					System.Globalization.NumberStyles.Integer,
					System.Globalization.CultureInfo.CurrentCulture
				);
			}
			#endregion
		}

		public void btn_Save_Click(object sender, EventArgs e) {
			int[] _errors;
			SO_NWS_Source _source;
			if (
				#region ((_source = ...) != null)
				(this.IDSource > 0)
				&&
				(
					(_source = BusinessInstances.NWS_Source.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDSource,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {

				this.btn_save_click(
					ref _source
				);

				BusinessInstances.NWS_Source.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_source,
					out _errors
				);
			} else {
				_source = new SO_NWS_Source();

				this.btn_save_click(
					ref _source
				);

				_source.Approved_date_isNull = true;
				_source.IFUser__Approved_isNull = true;
				_source.IFApplication = utils.IDApplication;
				BusinessInstances.NWS_Source.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					_source,
					false,
					out _errors
				);
			}
			if (!this.Master__base.Error_add(_errors)) {
				Response.Redirect(
					"NWS-NewsSource-list.aspx",
					true
				);
			}
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			SO_NWS_Source _source;
			if (
				#region ((_source = ...) != null)
				(this.IDSource > 0)
				&&
				(
					(_source = BusinessInstances.NWS_Source.InstanceClient.getObject(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDSource,
						out _errors
					))
					!=
					null
				)
				&&
				!this.Master__base.Error_add(_errors)
				#endregion
			) {
				this.txt_Name.Text = _source.Name;
				#region this.ddl_Source_parent.SelectedValue = _source.IFSource__parent.ToString();
				if (_source.IFSource__parent_isNull) {
					this.ddl_Source_parent.SelectedValue = "";
				} else {
					this.ddl_Source_parent.SelectedValue = _source.IFSource__parent.ToString(System.Globalization.CultureInfo.CurrentCulture);
				}
				#endregion
			} else {
				this.txt_Name.Text = "";
			}
		} 
		#endregion
	}
}