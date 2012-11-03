#region Copyright (C) 2002 Francisco Monteiro
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

	public partial class LOG_Log : AdminPage {

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				//int _error;

				this.txt_Date_begin.Text = "";
				this.txt_Date_end.Text = "";

				//// TODO: consider removing commented code
				//utils.KickListControl.Bind__PseudoEnum(
				//    this.ddl_Logtype.Kick, 
				//    LogType.error.ToString(),
				//    true,
				//    true,
				//    LogType.Items
				//);
				this.ddl_Logtype.Kick.Bind__Dictionary<int, PseudoEnumItem>(
					"",
					true,
					true,
					LogType.Items,
					delegate(
						KeyValuePair<int, PseudoEnumItem> arg_in
					) {
						return arg_in.Value.Name;
					}
				);

				//// TODO: consider removing commented code
				//utils.KickListControl.Bind__ErrorItem(
				//    this.ddl_Errortype.Kick,
				//    "",
				//    true,
				//    true,
				//    ErrorType.Items
				//);
				this.ddl_Errortype.Kick.Bind__Dictionary<int, ErrorItem>(
					"",
					true,
					true,
					ErrorType.Items,
					delegate(
						KeyValuePair<int, ErrorItem> arg_in
					) {
						return arg_in.Value.Name;
					}
				);

				//// TODO: consider removing commented code
				//this.ddl_Coworker.Kick.Bind_Coworker_all(
				//    "",
				//    true,
				//    out _error
				//);

				//// TODO: consider removing commented code
				//this.ddl_Coworker.Kick.Bind__arrayOf<long, string>(
				//    "",
				//    true,
				//    BusinessInstances.Coworker.InstanceClient.getRecord_all(
				//        utils.User.Credentials_ENC,
				//        0, 0,
				//        out _error
				//    )
				//);
				//this.Master__base.Error_add(_error);

				this.Bind();
			}
		} 
		#endregion

		#region protected void lbt_Date_Click(object sender, EventArgs e);
		protected void lbt_Date_Click(object sender, EventArgs e) {
			switch (((LinkButton)sender).CommandArgument) {
				case "0":
					this.txt_Date_begin.Text = "";
					this.txt_Date_end.Text = "";
					break;
				case "1":
					this.txt_Date_begin.Date = DateTime.Now.AddDays(-1);
					this.txt_Date_end.Date = DateTime.Now;
					break;
				case "2":
					this.txt_Date_begin.Date = DateTime.Now.AddDays(-7);
					this.txt_Date_end.Date = DateTime.Now;
					break;
			}
		} 
		#endregion

		#region protected void btn_Search_Click(object sender, EventArgs e);
		protected void btn_Search_Click(object sender, EventArgs e) {
			this.Bind();
		} 
		#endregion
		#region protected void btn_MarkRead_Click(object sender, EventArgs e);
		protected void btn_MarkRead_Click(object sender, EventArgs e) {
			int _idlog = int.Parse(
				((Button)sender).CommandArgument,
				System.Globalization.NumberStyles.Integer,
				System.Globalization.CultureInfo.CurrentCulture
			);
			int[] _errors;
			BusinessInstances.LOG_Log.InstanceClient.MarkRead(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				_idlog,
				out _errors
			);
			if (this.Master__base.Error_add(_errors)) {
				return;
			}

			this.Bind();
		} 
		#endregion

		#region private class LogDetails : SO_Log ...
		private class LogDetails : SO_LOG_Log {
			public LogDetails(
				long idLog_in, 
				int idLogtype_in, 
				DateTime stamp_in, 
				string message_in, 
				long idUser_in, 
				int idErrortype_in, 
				long idUser__read_in, 
				DateTime stamp__read_in, 
				int ifApplication_in, 
				long ifBrowser__OPT_in, 

				string logtype_in, 
				string errortype_in, 
				string date_in, 
				bool visible_in
			) : base (
				idLog_in, 
				idLogtype_in,
				idUser_in,
				idUser__read_in, 
				idErrortype_in,
				stamp_in,
				stamp__read_in,
				message_in,
				0L,
				ifApplication_in,
				ifBrowser__OPT_in
			) {
				this.logtype_ = logtype_in;
				this.errortype_ = errortype_in;
				this.date_ = date_in;
				this.visible_ = visible_in;
			}

			private string logtype_;
			public string Logtype {
				get { return this.logtype_; }
				set { this.logtype_ = value; }
			}

			private string errortype_;
			public string Errortype {
				get { return this.errortype_; }
				set { this.errortype_ = value; }
			}

			private string date_;
			public string Date {
				get { return this.date_; }
				set { this.date_ = value; }
			}

			private bool visible_;
			public bool Visible {
				get { return this.visible_; }
				set { this.visible_ = value; }
			}
		}
		#endregion
		#region private void Bind(...);
		//private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		private void Bind() {
			int[] _error;
			long _count;
			SO_LOG_Log[] _logs 
				= BusinessInstances.LOG_Log.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					(string.IsNullOrEmpty(this.ddl_Logtype.SelectedValue)) 
						? -1
						: int.Parse(
							this.ddl_Logtype.SelectedValue,
							System.Globalization.NumberStyles.Integer,
							System.Globalization.CultureInfo.CurrentCulture
						),
					-1L, // (ddl_Coworker.SelectedValue != "") ? long.Parse(ddl_Coworker.SelectedValue, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.CurrentCulture) : -1,
					(string.IsNullOrEmpty(this.ddl_Errortype.SelectedValue)) 
						? -1
						: int.Parse(
							this.ddl_Errortype.SelectedValue,
							System.Globalization.NumberStyles.Integer,
							System.Globalization.CultureInfo.CurrentCulture
						),
					//(this.wuc_Date_begin.SelectedDateTime > datetime_minvalue_) ? wuc_Date_begin.SelectedDateTime : datetime_minvalue_,
					//(this.wuc_Date_end.SelectedDateTime > datetime_minvalue_) ? wuc_Date_end.SelectedDateTime : datetime_minvalue_,
					this.txt_Date_begin.Date,
					this.txt_Date_end.Date,
this.cbx_Read.Checked, 
false, 
					utils.IDApplication,
					(utils.IDApplication <= 0),

					0, 0, 0, out _count, 

					out _error
				);
			if (this.Master__base.Error_add(_error)) {
				return;
			}

			if (_logs.Length > 0) {
				Array.Sort(
					_logs,
					delegate(
						SO_LOG_Log _log1,
						SO_LOG_Log _log2
					) {
						return (
							_log2.IDLog.CompareTo(_log1.IDLog)
						);
					}
				);

				List<LogDetails> _logdetails = new List<LogDetails>(_logs.Length);
				foreach (SO_LOG_Log _log in _logs) {
					_logdetails.Add(new LogDetails(
						_log.IDLog,
						_log.IFLogtype,
						_log.Stamp,
						_log.Message.Replace("\n", "<br />"),
						_log.IFUser,
						_log.IFErrortype,
						_log.IFUser__read, 
						_log.Stamp__read,
						_log.IFApplication, 
						_log.IFBrowser__OPT, 

						LogType.Items.ContainsKey(_log.IFLogtype) ? LogType.Items[_log.IFLogtype].Name.Replace(" - ", "<br />/") : "---",
						!ErrorType.Items.ContainsKey(_log.IFErrortype) ? "???" : (_log.IFErrortype_isNull ? "---" : ErrorType.Items[_log.IFErrortype].Name.Replace(" - ", "<br />/")),
						_log.Stamp.ToString("ddMMMyyyy<br />HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture),
						!this.cbx_Read.Checked
					));
				}

				this.rep_Log.DataSource = _logdetails;
				this.rep_Log.DataBind();

				//// TODO: consider removing commented code
				//if (this.cbx_Read.Checked) {
				//    for (int i = 0; i < rep_Log.Items.Count; i++) {
				//        ((Anthem.Button)rep_Log.Items[i].FindControl("btn_MarkRead")).Visible = false;
				//    }
				//}

				this.rep_Log.Visible = true;
			} else {
				this.rep_Log.Visible = false;

				this.Master__base.Error_add(
					false,
					"returned no results"
				);
			}
		}
		#endregion
	}
}