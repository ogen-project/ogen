#region Copyright (C) 2002 Francisco Monteiro
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

	public partial class NWS_News_list : AdminPage {
		#region public enum ContentstateEnum { ... }
		public enum ContentstateEnum : int {
			approved = 1,
			pending = 2,
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				//DIC_Name.Texts = null;

				this.TXT_Begin_date.Attributes.Add("readonly", "readonly");
				this.TXT_End_date.Attributes.Add("readonly", "readonly");

				#region DDL_Approved . . .
				this.DDL_Approved.Kick.Bind__Enum(
					"",
					true,
					true,
					typeof(ContentstateEnum)
				);
				#endregion

				int[] _errors;
				long _count;

				#region Tags . . .
				SO_vNWS_Tag[] _so_tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byLang(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						Utilities.IDLanguage__default,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_so_tags,
						delegate(
							SO_vNWS_Tag arg1_in,
							SO_vNWS_Tag arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.CBL_Tags.Kick.Bind__arrayOf<long, string>(
						"",
						_so_tags
					);
				}
				#endregion
				#region Source . . .
				SO_vNWS_Source[] _so_sources
					= BusinessInstances.NWS_Source.InstanceClient.getRecord_all(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_so_sources,
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
					this.CBL_Source.Kick.Bind__arrayOf<long, string>(
						"",
						_so_sources
					);
				}
				#endregion
				#region Author . . .
				SO_vNWS_Author[] _so_authors
					= BusinessInstances.NWS_Author.InstanceClient.getRecord_all(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_so_authors,
						delegate(
							SO_vNWS_Author arg1_in,
							SO_vNWS_Author arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.CBL_Author.Kick.Bind__arrayOf<long, string>(
						"",
						_so_authors
					);
				}
				#endregion
				#region Highlight . . .
				SO_vNWS_Highlight[] _so_highlights
					= BusinessInstances.NWS_Highlight.InstanceClient.getRecord_all(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_so_highlights,
						delegate(
							SO_vNWS_Highlight arg1_in,
							SO_vNWS_Highlight arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.CBL_Highlight.Kick.Bind__arrayOf<long, string>(
						"",
						_so_highlights
					);
				}
				#endregion
				#region Profile . . .
				SO_vNWS_Profile[] _so_profiles
					= BusinessInstances.NWS_Profile.InstanceClient.getRecord_all(
						Utilities.User.SessionGuid,
						Utilities.ClientIPAddress,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
					Array.Sort(
						_so_profiles,
						delegate(
							SO_vNWS_Profile arg1_in,
							SO_vNWS_Profile arg2_in
						) {
							return string.Compare(
								arg1_in.Name,
								arg2_in.Name,
								false,
								System.Globalization.CultureInfo.CurrentCulture
							);
						}
					);
					this.CBL_Profile.Kick.Bind__arrayOf<long, string>(
						"",
						_so_profiles
					);
				}
				#endregion

				this.Bind();
			}
		}
		#endregion

		#region protected void BTN_Search_Click(object sender, EventArgs e);
		protected void BTN_Search_Click(object sender, EventArgs e) {
			this.Bind();
		}
		#endregion
		#region protected void BTN_Delete_Click(object sender, EventArgs e);
		protected void BTN_Delete_Click(object sender, EventArgs e) {
			long _idcontent = long.Parse(
				((Button)sender).CommandArgument,
				System.Globalization.NumberStyles.Integer,
				System.Globalization.CultureInfo.CurrentCulture
			);

			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.delObject(
				Utilities.User.SessionGuid,
				Utilities.ClientIPAddress, 

				_idcontent,
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				this.Bind();
			}
		}
		#endregion
		#region protected void BTN_Approve_Click(object sender, EventArgs e);
		protected void BTN_Approve_Click(object sender, EventArgs e) {
			int _idcontent = int.Parse(
				((Button)sender).CommandArgument,
				System.Globalization.NumberStyles.Integer,
				System.Globalization.CultureInfo.CurrentCulture
			);

			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.updObject_Approve(
				Utilities.User.SessionGuid,
				Utilities.ClientIPAddress,
				_idcontent, 
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				this.Bind();
			}
		}
		#endregion

		#region public void Bind();
		private static DateTime datetime_minvalue_ = new DateTime(1900, 1, 1);

		//private static bool DateTime_TryParse(
		//    string value_in, 
		//    out DateTime datetime_out
		//) {
		//    string[] _values;
		//    int _year;
		//    int _month;
		//    int _day;
		//    if (
		//        ((value_in = value_in.Trim()).Length == 0)
		//        ||
		//        ((_values = value_in.Split('-')).Length != 3)
		//        ||
		//        !int.TryParse(_values[2], out _year)
		//        ||
		//        !int.TryParse(_values[1], out _month)
		//        ||
		//        !int.TryParse(_values[0], out _day)
		//    ) {
		//        datetime_out = datetime_minvalue_;
		//        return false;
		//    } else {
		//        datetime_out = new DateTime(
		//            _year,
		//            _month,
		//            _day
		//        );
		//        return true;
		//    }
		//}
		public void Bind() {
			int[] _errors;
			long _count;
			#region SO_vNWS_Content[] _contents = ...(..., out out _errors);
			DateTime _begin_date;
			DateTime _end_date;

			SO_vNWS_Content[] _contents;
			_contents = BusinessInstances.NWS_News.InstanceClient.getRecord_generic(
				Utilities.User.SessionGuid,
				Utilities.ClientIPAddress,

-1L,

				(string.IsNullOrEmpty(this.DDL_Approved.SelectedValue))
					? -2L
					: (this.DDL_Approved.SelectedValue == ((int)ContentstateEnum.approved).ToString(System.Globalization.CultureInfo.CurrentCulture))
						? 0L
						: -1L,

				//// TODO: consider removing commented code
				//
				//(
				//    (this.TXT_Begin_date_CalendarExtender.SelectedDate == null)
				//    ||
				//    (!this.TXT_Begin_date_CalendarExtender.SelectedDate.HasValue)
				//) 
				//    ? this.datetime_minvalue_ 
				//    : this.TXT_Begin_date_CalendarExtender.SelectedDate.Value,
				//(
				//    (this.TXT_End_date_CalendarExtender.SelectedDate == null)
				//    ||
				//    (!this.TXT_End_date_CalendarExtender.SelectedDate.HasValue)
				//) 
				//    ? this.datetime_minvalue_ 
				//    : this.TXT_End_date_CalendarExtender.SelectedDate.Value,
				//
				//DateTime_TryParse(this.TXT_Begin_date.Text, out _begin_date) ? _begin_date : this.datetime_minvalue_,
				//DateTime_TryParse(this.TXT_End_date.Text, out _end_date) ? _end_date : this.datetime_minvalue_, 
				//
				DateTime.TryParseExact(
					this.TXT_Begin_date.Text,
					"dd-MM-yyyy",
					null,
					System.Globalization.DateTimeStyles.None,
					out _begin_date
				) ? _begin_date : datetime_minvalue_,
				DateTime.TryParseExact(
					this.TXT_End_date.Text,
					"dd-MM-yyyy",
					null,
					System.Globalization.DateTimeStyles.None,
					out _end_date
				) ? _end_date : datetime_minvalue_,

				this.CBL_Tags.Kick.SelectedValue__get<long>(),
				this.CBL_Author.Kick.SelectedValue__get<long>(),
				this.CBL_Source.Kick.SelectedValue__get<long>(),
				this.CBL_Highlight.Kick.SelectedValue__get<long>(),
				this.CBL_Profile.Kick.SelectedValue__get<long>(),

				this.TXT_Text.Text,
				Utilities.IDLanguage__default,
				true,
				0, 0, 0, out _count, 

				out _errors
			);
			#endregion
			if (!this.Master__base.Error_add(_errors)) {
				if (_contents.Length > 0) {
					this.REP_SearchResults.Visible = true;

					this.REP_SearchResults.DataSource = _contents;
					this.REP_SearchResults.DataBind();
				} else {
					this.REP_SearchResults.Visible = false;

					this.Master__base.Error_add(
						false,
						"returned no results"
					);
				}
			}

		}
		#endregion
	}
}