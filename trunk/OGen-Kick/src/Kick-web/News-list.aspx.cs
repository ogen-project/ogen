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

	public partial class FE_News_list : SitePage {
		#region public long IDTag { get; set; }
		private long idtag__ = -2L;

		public long IDTag {
			get {
				if (
					(this.idtag__ == -2L)
					||
					!long.TryParse(this.HFI_IDTag.Value, out this.idtag__)
				) {
					this.idtag__ = -1L;
				}

				return this.idtag__;
			}
			set {
				this.idtag__ = value;
				this.HFI_IDTag.Value = value.ToString(System.Globalization.CultureInfo.CurrentCulture);
			}
		}
		#endregion
		#region public long IDSource { get; set; }
		private long idsource__ = -2L;

		public long IDSource {
			get {
				if (
					(this.idsource__ == -2L)
					||
					!long.TryParse(this.HFI_Source.Value, out this.idsource__)
				) {
					this.idsource__ = -1L;
				}

				return this.idsource__;
			}
			set {
				this.idsource__ = value;
				this.HFI_Source.Value = value.ToString(System.Globalization.CultureInfo.CurrentCulture);
			}
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}

		#region protected void Tag_Click(object sender, EventArgs e);
		protected void Tag_Click(object sender, EventArgs e) {
			#region IDTag = ...;
			string _idtag = ((LinkButton)sender).CommandArgument;
			if (string.IsNullOrEmpty(_idtag)) {
				this.IDTag = 0L;
			} else {
				this.IDTag = long.Parse(
					_idtag,
					System.Globalization.NumberStyles.Integer,
					System.Globalization.CultureInfo.CurrentCulture
				);
			}
			#endregion
			this.IDSource = 0L;
			this.Bind();
		}
		#endregion
		#region protected void Source_Click(object sender, EventArgs e);
		protected void Source_Click(object sender, EventArgs e) {
			string _idsource = ((LinkButton)sender).CommandArgument;
			if (string.IsNullOrEmpty(_idsource)) {
				this.IDSource = 0L;
			} else {
				this.IDSource = long.Parse(
					_idsource,
					System.Globalization.NumberStyles.Integer,
					System.Globalization.CultureInfo.CurrentCulture
				);
			}
			this.Bind();
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			long _count;
			this.TBL_News.Visible = false;

			#region REP_News.DataSource = ...; REP_News.DataBind();
			SO_vNWS_Content[] _news
				= BusinessInstances.NWS_News.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress, 
					-1L,
					0L, // 0: Approved; -1: NOT approved; < -1: ignore; >0: ...
					DateTime.MinValue,
					DateTime.MinValue,
					(this.IDTag <= 0) ? new long[] { } : new long[] { this.IDTag },
					new long[] { },
					(this.IDSource <= 0) ? new long[] { } : new long[] { this.IDSource },
					new long[] { },

// ToDos: here!
new long[] { }, 

					"",
					utils.IDLanguage__default,
					true,

1,
					OGen.Libraries.PresentationLayer.WebForms.utils.Pager.PageNum,
					OGen.Libraries.PresentationLayer.WebForms.utils.Pager.ITEMSPERPAGE_DEFAULT, 
					out _count, 

					out _errors
				);
			if (
				!this.Master__base.Error_add(_errors)
				&&
				(_news != null)
			) {
				if (_news.Length <= 0) {
					this.Master__base.Error_add(false, "no data");
//					this.REP_News.Visible = false;
					return;
				}

				foreach (SO_vNWS_Content _content in _news) {
					_content.summary = OGen.Libraries.PresentationLayer.WebForms.utils.Replace_RN_BR(_content.summary);
					_content.Content = OGen.Libraries.PresentationLayer.WebForms.utils.Replace_RN_BR(_content.Content);
				}

				this.REP_News.DataSource = _news;
				this.REP_News.DataBind();
//				this.REP_News.Visible = true;
				this.TBL_News.Visible = true;


				OGen.Libraries.PresentationLayer.WebForms.utils.Pager.Bind(
					_count,
					this.LBL_PageSeparator_left,
					this.LBL_PageSeparator_2,
					this.LBL_PageSeparator_3,
					this.LBL_PageSeparator_4,
					this.LBL_PageSeparator_right,
					this.LBL_PageSeparator_5,
					this.A_Page_1,
					this.A_Page_2,
					this.A_Page_3,
					this.A_Page_4,
					this.A_Page_5
				);
			} else {
				return;
			}
			#endregion

			#region REP_Tags.DataSource = ...; REP_Tags.DataBind();
			SO_vNWS_Tag[] _tags
				= BusinessInstances.NWS_Tag.InstanceClient.getRecord_Approved_byLang(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					utils.IDLanguage__default,
					0, 0, 0, out _count, 
					out _errors
				);
			if (
				!this.Master__base.Error_add(_errors)
				&&
				(_tags != null)
				&&
				(_tags.Length > 0)
			) {

				Array.Sort(
					_tags,
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

				this.REP_Tags.DataSource = _tags;
				this.REP_Tags.DataBind();
			}
			#endregion
			#region SO_vNWS_Source[] _sources = ...;
			SO_vNWS_Source[] _sources
				= BusinessInstances.NWS_Source.InstanceClient.getRecord_Approved(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					0, 0, 0, out _count, 
					out _errors
				);

			this.Master__base.Error_add(_errors);
			#endregion

//			System.Web.UI.HtmlControls.HtmlTableRow _tr_ImageNews;
			Anthem.Image _img_news;
			Anthem.Repeater _rep_news_tags;
			Anthem.Repeater _rep_news_sources;
			for (int n = 0; n < _news.Length; n++) {
				#region _rep_news_tags.DataSource = ...; _rep_news_tags.DataBind();
				if (
					(_tags != null)
					&&
					(_tags.Length > 0)
				) {
					SO_NWS_ContentTag[] _content_tags 
						= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byContent(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							_news[n].IDContent,
							0, 0, 0, out _count, 
							out _errors
						);
					if (
						!this.Master__base.Error_add(_errors)
						&&
						(_content_tags != null)
						&&
						(_content_tags.Length > 0)
					) {
						SO_vNWS_Tag[] _tags2 = new SO_vNWS_Tag[_content_tags.Length];
						for (int t1 = 0; t1 < _content_tags.Length; t1++) {
							for (int t2 = 0; t2 < _tags.Length; t2++) {
								if (_content_tags[t1].IFTag == _tags[t2].IDTag) {
									_tags2[t1] = _tags[t2];
									break;
								}
							}
						}

						_rep_news_tags = (Anthem.Repeater)this.REP_News.Items[n].FindControl("REP_News_Tags");
						_rep_news_tags.DataSource = _tags2;
						_rep_news_tags.DataBind();
					}
				}
				#endregion
				#region _rep_news_sources.DataSource = ...; _rep_news_sources.DataBind();
				if (
					(_sources != null)
					&&
					(_sources.Length > 0)
				) {
					SO_NWS_ContentSource[] _content_sources 
						= BusinessInstances.NWS_Source.InstanceClient.getRecord_byContent(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							_news[n].IDContent,
							0, 0, 0, out _count, 
							out _errors
						);
					if (
						!this.Master__base.Error_add(_errors)
						&&
						(_content_sources != null)
						&&
						(_content_sources.Length > 0)
					) {
						SO_vNWS_Source[] _sources2 = new SO_vNWS_Source[_content_sources.Length];
						for (int s1 = 0; s1 < _content_sources.Length; s1++) {
							for (int s2 = 0; s2 < _sources.Length; s2++) {
								if (_content_sources[s1].IFSource == _sources[s2].IDSource) {
									_sources2[s1] = _sources[s2];
									break;
								}
							}
						}

						_rep_news_sources = (Anthem.Repeater)this.REP_News.Items[n].FindControl("REP_News_Sources");
						_rep_news_sources.DataSource = _sources2;
						_rep_news_sources.DataBind();

						_rep_news_sources.Visible = true;
					}
				}
				#endregion
				#region _img_news = ...;
				#region SO_vNWS_Attachment _attachment = ...;
				SO_vNWS_Attachment _attachment = null;
				SO_vNWS_Attachment[] _attachments
					= BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent_andLanguage(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						_news[n].IDContent,
						utils.IDLanguage__default,
						0, 0, 0, out _count, 
						out _errors
					);
				if (
					!this.Master__base.Error_add(_errors)
					&&
					(_attachments != null)
					&&
					(_attachments.Length > 0)
				) {
					Array.Sort(
						_attachments,
						delegate(
							SO_vNWS_Attachment arg1_in,
							SO_vNWS_Attachment arg2_in
						) {
							return arg1_in.IDAttachment.CompareTo(arg2_in.IDAttachment);
						}
					);
					foreach (SO_vNWS_Attachment _attachment2 in _attachments) {
						if (_attachment2.IsImage) {
							_attachment = _attachment2;
							break;
						}
					}
				}
				#endregion
				_img_news = (Anthem.Image)this.REP_News.Items[n].FindControl("IMG_News");
//				_tr_ImageNews = (System.Web.UI.HtmlControls.HtmlTableRow)REP_News.Items[n].FindControl("tr_ImageNews");
				if (_attachment != null) {
					_img_news.ImageUrl = string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"~/public-uploads/news/{0}/{1}-{2}/{3}",
						_attachment.IFContent,
						_attachment.IDAttachment,
						_attachment.GUID,
						_attachment.FileName
					);
					_img_news.Visible = true;
//					_tr_ImageNews.Visible = true;
				} else {
					_img_news.Visible = false;
//					_tr_ImageNews.Visible = false;
				}
				#endregion
			}
		}
		#endregion
	}
}