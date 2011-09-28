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
	public partial class FE_News_list : SitePage {
		#region public long IDTag { get; set; }
		private long idtag__ = -2L;

		public long IDTag {
			get {
				if (
					(idtag__ == -2L)
					||
					!long.TryParse(hfi_IDTag.Value, out idtag__)
				) {
					idtag__ = -1L;
				}

				return idtag__;
			}
			set {
				idtag__ = value;
				hfi_IDTag.Value = value.ToString();
			}
		}
		#endregion
		#region public long IDSource { get; set; }
		private long idsource__ = -2L;

		public long IDSource {
			get {
				if (
					(idsource__ == -2L)
					||
					!long.TryParse(hfi_Source.Value, out idsource__)
				) {
					idsource__ = -1L;
				}

				return idsource__;
			}
			set {
				idsource__ = value;
				hfi_Source.Value = value.ToString();
			}
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				Bind();
			}
		}

		#region protected void Tag_Click(object sender, EventArgs e);
		protected void Tag_Click(object sender, EventArgs e) {
			#region IDTag = ...;
			string _idtag = ((LinkButton)sender).CommandArgument;
			if (_idtag == "") {
				IDTag = 0L;
			} else {
				IDTag = long.Parse(_idtag);
			}
			#endregion
			IDSource = 0L;
			Bind();
		}
		#endregion
		#region protected void Source_Click(object sender, EventArgs e);
		protected void Source_Click(object sender, EventArgs e) {
			string _idsource = ((LinkButton)sender).CommandArgument;
			if (_idsource == "") {
				IDSource = 0L;
			} else {
				IDSource = long.Parse(_idsource);
			}
			Bind();
		}
		#endregion

		#region public void Bind();
		public void Bind() {
			int[] _errors;
			tbl_News.Visible = false;

			#region rep_News.DataSource = ...; rep_News.DataBind();
			SO_vNWS_Content[] _news
				= BusinessInstances.NWS_News.InstanceClient.getRecord_generic(
					utils.User.SessionGuid,
					utils.ClientIPAddress, 
					-1L,
					0L, // 0: Approved; -1: NOT approved; < -1: ignore; >0: ...
					DateTime.MinValue,
					DateTime.MinValue,
					(IDTag <= 0) ? new long[] { } : new long[] { IDTag },
					new long[] { },
					(IDSource <= 0) ? new long[] { } : new long[] { IDSource },
					new long[] { },

// ToDos: here!
new long[] { }, 

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
			) {
				if (_news.Length <= 0) {
					Master__base.Error_show(false, "no data");
//					rep_News.Visible = false;
					return;
				}

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
//				rep_News.Visible = true;
				tbl_News.Visible = true;
			} else {
				return;
			}
			#endregion

			#region rep_Tags.DataSource = ...; rep_Tags.DataBind();
			SO_vNWS_Tag[] _tags
				= BusinessInstances.NWS_Tag.InstanceClient.getRecord_Approved_byLang(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					utils.IDLanguage__default,
					0, 0,
					out _errors
				);
			if (
				!Master__base.Error_show(_errors)
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
						return arg1_in.Name.CompareTo(arg2_in.Name);
					}
				);

				rep_Tags.DataSource = _tags;
				rep_Tags.DataBind();
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

//			System.Web.UI.HtmlControls.HtmlTableRow _tr_ImageNews;
			Anthem.Image _img_News;
			Anthem.Repeater _rep_News_Tags;
			Anthem.Repeater _rep_News_Sources;
			for (int n = 0; n < _news.Length; n++) {
				#region _rep_News_Tags.DataSource = ...; _rep_News_Tags.DataBind();
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
				}
				#endregion
				#region _rep_News_Sources.DataSource = ...; _rep_News_Sources.DataBind();
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
				}
				#endregion
				#region _img_News = ...;
				#region SO_vNWS_Attachment _attachment = ...;
				SO_vNWS_Attachment _attachment = null;
				SO_vNWS_Attachment[] _attachments
					= BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent_andLanguage(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						_news[n].IDContent,
						utils.IDLanguage__default,
						out _errors
					);
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
					foreach (SO_vNWS_Attachment _attachment2 in _attachments) {
						if (_attachment2.isImage) {
							_attachment = _attachment2;
							break;
						}
					}
				}
				#endregion
				_img_News = (Anthem.Image)rep_News.Items[n].FindControl("img_News");
//				_tr_ImageNews = (System.Web.UI.HtmlControls.HtmlTableRow)rep_News.Items[n].FindControl("tr_ImageNews");
				if (_attachment != null) {
					_img_News.ImageUrl = string.Format(
						"~/public-uploads/news/{0}/{1}-{2}/{3}",
						_attachment.IFContent,
						_attachment.IDAttachment,
						_attachment.GUID,
						_attachment.FileName
					);
					_img_News.Visible = true;
//					_tr_ImageNews.Visible = true;
				} else {
					_img_News.Visible = false;
//					_tr_ImageNews.Visible = false;
				}
				#endregion
			}
		}
		#endregion
	}
}