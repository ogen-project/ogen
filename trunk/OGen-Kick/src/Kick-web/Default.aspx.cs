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

	public partial class Default : SitePage {
		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}

		public void Bind() {
			int[] _errors;
			long _count;

			//// TODO: consider removing commented code
			//if (!Master_Site.Master__base.Creds.hasPermission(
			//    true,
			//    PermissionType.Forum__Forum__read,
			//    PermissionType.Forum__Thread__read,
			//    PermissionType.Forum__Reply__read
			//)) {
			//    this.spn_Forum.Visible = false;
			//    this.REP_Threads.Visible = false;
			//} else {
			//    this.spn_Forum.Visible = true;
			//    this.REP_Threads.Visible = true;

			//    #region this.REP_Threads.DataSource = ...; this.REP_Threads.DataBind();
			//    long _count;
			//    long _idmessage__forum;
			//    SO_vFOR_Message[] _messages;

			//    _messages
			//        = FOR_Forum.InstanceClient.getRecord_Forum(
			//            utils.User.Credentials_ENC,

			//            utils.IDApplication,
			//            out _idmessage__forum,

			//            1,
			//            3,
			//            out _count,

			//            out _errors
			//        );

			//    if (_messages != null) {
			//        Array.Sort(
			//            _messages,
			//            delegate(
			//                SO_vFOR_Message arg1_in,
			//                SO_vFOR_Message arg2_in
			//            ) {
			//                return arg2_in.IDMessage.CompareTo(arg1_in.IDMessage);
			//            }
			//        );
			//        this.REP_Threads.DataSource = _messages;
			//        this.REP_Threads.DataBind();
			//    }
			//    #endregion
			//}

			SO_vNWS_Content[] _news
				= BusinessInstances.NWS_News.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					-1L,
					0L, // 0: Approved; -1: NOT approved; < -1: ignore; >0: ...
					DateTime.MinValue,
					DateTime.MinValue,
					new long[] { },
					new long[] { },
					new long[] { },
					(utils.News_Highlight_for_Default <= 0) ? new long[] { } : new long[] { utils.News_Highlight_for_Default },

new long[] { }, // ToDos: here!

					"",
					utils.IDLanguage__default,
					true,
					0, 0, 0, out _count, 
					out _errors
				);
			if (
				!this.Master__base.Error_add(_errors)
				&&
				(_news != null)
				&&
				(_news.Length > 0)
			) {
				#region this.REP_News.DataSource = ...; this.REP_News.DataBind();
				Array.Sort(
					_news,
					delegate(
						SO_vNWS_Content arg1_in,
						SO_vNWS_Content arg2_in
					) {
						return arg2_in.Publish_date.CompareTo(arg1_in.Publish_date);
					}
				);

				foreach (SO_vNWS_Content _content in _news) {
					_content.summary = OGen.lib.presentationlayer.webforms.utils.Replace_RN_BR(_content.summary);
					_content.Content = OGen.lib.presentationlayer.webforms.utils.Replace_RN_BR(_content.Content);
				}

				this.REP_News.DataSource = _news;
				this.REP_News.DataBind();
				#endregion

				#region SO_vNWS_Tag[] _tags = ...;
				SO_vNWS_Tag[] _tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_Approved_byLang(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						utils.IDLanguage__default,
						0, 0, 0, out _count, 
						out _errors
					);
				if (!this.Master__base.Error_add(_errors)) {
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

					//REP_Tags.DataSource = _tags;
					//REP_Tags.DataBind();
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

				bool _show_Details;
				Anthem.Image _img_news;
				Anthem.Repeater _rep_news_tags;
				Anthem.Repeater _rep_news_sources;
				System.Web.UI.HtmlControls.HtmlTableRow _tr_details;
				for (int n = 0; n < _news.Length; n++) {
					_show_Details = false;

					#region _rep_news_tags.DataSource = ...; _rep_news_tags.DataBind();
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
						_rep_news_tags.Visible = true;

						_show_Details = true;
					}
					#endregion
					#region _rep_news_sources.DataSource = ...; _rep_news_sources.DataBind();
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

						_show_Details = true;
					}
					#endregion
					#region _img_news = ...;
					#region SO_vNWS_Attachment _attachment = ...;
					SO_vNWS_Attachment _attachment;
					SO_vNWS_Attachment[] _attachments
						= BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent_andLanguage(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							_news[n].IDContent,
							utils.IDLanguage__default,
							0, 0, 0, out _count, 
							out _errors
						);
					#endregion
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


						_attachment = null;
						foreach (SO_vNWS_Attachment _attachment2 in _attachments) {
							if (_attachment2.IsImage) {
								_attachment = _attachment2;
								break;
							}
						}
						if (_attachment != null) {
							_img_news = (Anthem.Image)this.REP_News.Items[n].FindControl("IMG_News");

							_img_news.ImageUrl = string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"~/public-uploads/news/{0}/{1}-{2}/{3}",
								_attachment.IFContent,
								_attachment.IDAttachment,
								_attachment.GUID,
								_attachment.FileName
							);
							_img_news.Visible = true;
						}
					}
					#endregion

					_tr_details = (System.Web.UI.HtmlControls.HtmlTableRow)this.REP_News.Items[n].FindControl("TR_Details");
					_tr_details.Visible = _show_Details;
				}
			}
		}
	}
}