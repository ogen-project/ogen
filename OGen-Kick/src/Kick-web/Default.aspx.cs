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
	public partial class Default : SitePage {
		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				Bind();
			}
		}

		public void Bind() {
			int[] _errors;

			//if (!Master_Site.Master__base.Creds.hasPermition(
			//    true,
			//    PermitionType.Forum__Forum__read,
			//    PermitionType.Forum__Thread__read,
			//    PermitionType.Forum__Reply__read
			//)) {
			//    spn_Forum.Visible = false;
			//    rep_Threads.Visible = false;
			//} else {
			//    spn_Forum.Visible = true;
			//    rep_Threads.Visible = true;

			//    #region rep_Threads.DataSource = ...; rep_Threads.DataBind();
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
			//        rep_Threads.DataSource = _messages;
			//        rep_Threads.DataBind();
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
					0, 0,
					out _errors
				);
			if (
				!Master__base.Error_show(_errors)
				&&
				(_news != null)
				&&
				(_news.Length > 0)
			) {
				#region rep_News.DataSource = ...; rep_News.DataBind();
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

				rep_News.DataSource = _news;
				rep_News.DataBind();
				#endregion

				#region SO_vNWS_Tag[] _tags = ...;
				SO_vNWS_Tag[] _tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_Approved_byLang(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						utils.IDLanguage__default,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_tags,
						delegate(
							SO_vNWS_Tag arg1_in,
							SO_vNWS_Tag arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);

					//rep_Tags.DataSource = _tags;
					//rep_Tags.DataBind();
				}
				#endregion
				#region SO_vNWS_Source[] _sources = ...;
				SO_vNWS_Source[] _sources
					= BusinessInstances.NWS_Source.InstanceClient.getRecord_Approved(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				Master__base.Error_show(_errors);
				#endregion

				Anthem.Image _img_News;
				Anthem.Repeater _rep_News_Tags;
				Anthem.Repeater _rep_News_Sources;
				for (int n = 0; n < _news.Length; n++) {
					#region _rep_News_Tags.DataSource = ...; _rep_News_Tags.DataBind();
					SO_NWS_ContentTag[] _content_tags
						= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byContent(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							_news[n].IDContent,
							0, 0,
							out _errors
						);
					if (
						!Master__base.Error_show(_errors)
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

						_rep_News_Tags = (Anthem.Repeater)rep_News.Items[n].FindControl("rep_News_Tags");
						_rep_News_Tags.DataSource = _tags2;
						_rep_News_Tags.DataBind();
					}
					#endregion
					#region _rep_News_Sources.DataSource = ...; _rep_News_Sources.DataBind();
					SO_NWS_ContentSource[] _content_sources
						= BusinessInstances.NWS_Source.InstanceClient.getRecord_byContent(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							_news[n].IDContent,
							0, 0,
							out _errors
						);
					if (
						!Master__base.Error_show(_errors)
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

						_rep_News_Sources = (Anthem.Repeater)rep_News.Items[n].FindControl("rep_News_Sources");
						_rep_News_Sources.DataSource = _sources2;
						_rep_News_Sources.DataBind();

						_rep_News_Sources.Visible = true;
					}
					#endregion
					#region _img_News = ...;
					#region SO_vNWS_Attachment _attachment = ...;
					SO_vNWS_Attachment _attachment;
					SO_vNWS_Attachment[] _attachments
						= BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent_andLanguage(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							_news[n].IDContent,
							utils.IDLanguage__default,
							out _errors
						);
					#endregion
					if (
						!Master__base.Error_show(_errors)
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
							if (_attachment2.isImage) {
								_attachment = _attachment2;
								break;
							}
						}
						if (_attachment != null) {
							_img_News = (Anthem.Image)rep_News.Items[n].FindControl("img_News");

							_img_News.ImageUrl = string.Format(
								"~/public-uploads/news/{0}/{1}-{2}/{3}",
								_attachment.IFContent,
								_attachment.IDAttachment,
								_attachment.GUID,
								_attachment.FileName
							);
							_img_News.Visible = true;
						}
					}
					#endregion
				}
			}
		}
	}
}