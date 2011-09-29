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
	public partial class LOG_Log : AdminPage {

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				//int _error;

				txt_Date_begin.Text = "";
				txt_Date_end.Text = "";

				//utils.KickListControl.Bind__PseudoEnum(
				//    ddl_Logtype.Kick, 
				//    LogType.error.ToString(),
				//    true,
				//    true,
				//    LogType.Items
				//);
				ddl_Logtype.Kick.Bind__Dictionary<int, PseudoEnumItem>(
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

				//utils.KickListControl.Bind__ErrorItem(
				//    ddl_Errortype.Kick,
				//    "",
				//    true,
				//    true,
				//    ErrorType.Items
				//);
				ddl_Errortype.Kick.Bind__Dictionary<int, ErrorItem>(
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

				//ddl_Coworker.Kick.Bind_Coworker_all(
				//    "",
				//    true,
				//    out _error
				//);

				//ddl_Coworker.Kick.Bind__arrayOf<long, string>(
				//    "",
				//    true,
				//    BusinessInstances.Coworker.InstanceClient.getRecord_all(
				//        utils.User.Credentials_ENC,
				//        0, 0,
				//        out _error
				//    )
				//);
				//Master__base.Error_add(_error);

				Bind();
			}
		} 
		#endregion

		#region protected void lbt_Date_Click(object sender, EventArgs e);
		protected void lbt_Date_Click(object sender, EventArgs e) {
			switch (((LinkButton)sender).CommandArgument) {
				case "0":
					txt_Date_begin.Text = "";
					txt_Date_end.Text = "";
					break;
				case "1":
					txt_Date_begin.Date = DateTime.Now.AddDays(-1);
					txt_Date_end.Date = DateTime.Now;
					break;
				case "2":
					txt_Date_begin.Date = DateTime.Now.AddDays(-7);
					txt_Date_end.Date = DateTime.Now;
					break;
			}
		} 
		#endregion

		#region protected void btn_Search_Click(object sender, EventArgs e);
		protected void btn_Search_Click(object sender, EventArgs e) {
			Bind();
		} 
		#endregion
		#region protected void btn_MarkRead_Click(object sender, EventArgs e);
		protected void btn_MarkRead_Click(object sender, EventArgs e) {
			int _idlog = int.Parse(
				((Button)sender).CommandArgument
			);
			int[] _errors;
			BusinessInstances.LOG_Log.InstanceClient.MarkRead(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				_idlog,
				out _errors
			);
			if (Master__base.Error_add(_errors)) {
				return;
			}

			Bind();
		} 
		#endregion

		#region private class LogDetails : SO_Log ...
		private class LogDetails : SO_LOG_Log {
			public LogDetails(
				long IDLog_in, 
				int IDLogtype_in, 
				DateTime Stamp_in, 
				string Message_in, 
				long IDUser_in, 
				int IDErrortype_in, 
				long IDUser__read_in, 
				DateTime Stamp__read_in, 
				int IFApplication_in, 
				long IFBrowser__OPT_in, 

				string logtype_in, 
				string errortype_in, 
				string date_in, 
				bool visible_in
			) : base (
				IDLog_in, 
				IDLogtype_in,
				IDUser_in,
				IDUser__read_in, 
				IDErrortype_in,
				Stamp_in,
				Stamp__read_in,
				Message_in,
				0L,
				IFApplication_in,
				IFBrowser__OPT_in
			) {
				logtype_ = logtype_in;
				errortype_ = errortype_in;
				date_ = date_in;
				visible_ = visible_in;
			}

			private string logtype_;
			public string Logtype {
				get { return logtype_; }
				set { logtype_ = value; }
			}

			private string errortype_;
			public string Errortype {
				get { return errortype_; }
				set { errortype_ = value; }
			}

			private string date_;
			public string Date {
				get { return date_; }
				set { date_ = value; }
			}

			private bool visible_;
			public bool Visible {
				get { return visible_; }
				set { visible_ = value; }
			}
		}
		#endregion
		#region private void Bind(...);
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		private void Bind() {
			int[] _error;
			SO_LOG_Log[] _logs 
				= BusinessInstances.LOG_Log.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					(ddl_Logtype.SelectedValue != "") ? int.Parse(ddl_Logtype.SelectedValue) : -1,
					-1L, // (ddl_Coworker.SelectedValue != "") ? long.Parse(ddl_Coworker.SelectedValue) : -1,
					(ddl_Errortype.SelectedValue != "") ? int.Parse(ddl_Errortype.SelectedValue) : -1,
					//(wuc_Date_begin.SelectedDateTime > datetime_minvalue_) ? wuc_Date_begin.SelectedDateTime : datetime_minvalue_,
					//(wuc_Date_end.SelectedDateTime > datetime_minvalue_) ? wuc_Date_end.SelectedDateTime : datetime_minvalue_,
					txt_Date_begin.Date,
					txt_Date_end.Date,
cbx_Read.Checked, 
false, 
					utils.IDApplication,
					(utils.IDApplication <= 0), 
					1,
					50,

					out _error
				);
			if (Master__base.Error_add(_error)) {
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
						_log.Stamp.ToString("ddMMMyyyy<br />HH:mm:ss"),
						!cbx_Read.Checked
					));
				}

				rep_Log.DataSource = _logdetails;
				rep_Log.DataBind();

				//if (cbx_Read.Checked) {
				//    for (int i = 0; i < rep_Log.Items.Count; i++) {
				//        ((Anthem.Button)rep_Log.Items[i].FindControl("btn_MarkRead")).Visible = false;
				//    }
				//}

				rep_Log.Visible = true;
			} else {
				rep_Log.Visible = false;

				Master__base.Error_add(
					false,
					"returned no results"
				);
			}
		}
		#endregion
	}
}