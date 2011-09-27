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
	public partial class FE_News : SitePage {
		#region public long IDNews { get; }
		private long idnews__ = -2;

		public long IDNews {
			get {
				if (
					(idnews__ == -2)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDNews"],
							out idnews__
						)
					)
				) {
					idnews__ = -1;
				}

				return idnews__;
			}
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			if (!Page.IsPostBack) {
				Bind();
			}
		}

		public void Bind() {
			if (IDNews <= 0) {
				return;
			}

			int[] _errors;

			SO_vNWS_Source[] _sources;
			SO_NWS_ContentSource[] _contentsources;

			SO_vNWS_Tag[] _tags;
			SO_NWS_ContentTag[] _contenttags;

			List<SO_vNWS_Attachment> _attachments_final;
			SO_vNWS_Attachment[] _attachments;
			SO_vNWS_Attachment _attachment;
			SO_vNWS_Content _content = BusinessInstances.NWS_News.InstanceClient.getObject(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDNews, 
				utils.IDLanguage__default, 
				out _errors
			);
			if (
				!Master__base.Error_show(_errors)
				&&
				(_content != null)
			) {
				#region attachments . . .
				_attachments = BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent_andLanguage(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					IDNews,
					utils.IDLanguage__default,
					out _errors
				);
				if (
					!Master__base.Error_show(_errors)
					&&
					(_attachments != null)
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

					#region _attachment = ...; _attachments_final = ...;
					_attachments_final = (_attachments.Length > 0) ? new List<SO_vNWS_Attachment>(_attachments.Length) : null;

					_attachment = null;
					int _image_count = 0;
					foreach (SO_vNWS_Attachment _attachment2 in _attachments) {
						if (_attachment2.isImage) {
							_image_count++;
							if (
								(_image_count != 0)
								&&
								(_image_count <= 2)
							) {
								_attachment = _attachment2;
							}
						}

						if (
							!_attachment2.isImage
							||
							(_image_count > 2)
						) {
							// NOT image OR [ image BUT beyond the ones used for display ]
							_attachments_final.Add(_attachment2);
						}
					} 
					#endregion

					#region img_News.ImageUrl = ...;
					if (_attachment != null) {
						img_News.ImageUrl = string.Format(
							"~/public-uploads/news/{0}/{1}-{2}/{3}",
							_attachment.IFContent,
							_attachment.IDAttachment,
							_attachment.GUID,
							_attachment.FileName
						);

						if (
							!_attachment.Name_isNull
							&&
							(_attachment.Name != "")
						) {
							lbl_Image_Name.Text = _attachment.Name;
						}
						if (
							!_attachment.Description_isNull
							&&
							(_attachment.Description != "")
						) {
							lbl_Image_Description.Text = string.Format(
								"({0})",
								_attachment.Description
							);
						}
					} else {
						td_image1.Visible = false;
					} 
					#endregion
					#region rep_Attachments...
					if (_attachments_final != null) {
						tr_Attachments1.Visible = true;

						rep_Attachments.DataSource = _attachments_final;
						rep_Attachments.DataBind();
					} else {
						tr_Attachments1.Visible = false;
					}
					#endregion
				}
				#endregion
				#region rep_Sources.DataSource = ...; rep_Sources.DataBind();
				_sources
					= BusinessInstances.NWS_Source.InstanceClient.getRecord_Approved(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				if (
					(_sources != null)
					&&
					((_contentsources = BusinessInstances.NWS_Source.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDNews, 
				        0, 0, 
				        out _errors
				    )) != null)
				) {
					SO_vNWS_Source[] _sources2 = new SO_vNWS_Source[_contentsources.Length];
					for (int s1 = 0; s1 < _contentsources.Length; s1++) {
						for (int s2 = 0; s2 < _sources.Length; s2++) {
							if (_contentsources[s1].IFSource == _sources[s2].IDSource) {
								_sources2[s1] = _sources[s2];
								break;
							}
						}
					}


					rep_Sources.DataSource = _sources2;
					rep_Sources.DataBind();
				}
				#endregion
				#region rep_Tags.DataSource = ...; rep_Tags.DataBind();
				_tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_Approved_byLang(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						utils.IDLanguage__default,
						0, 0,
						out _errors
					);
				if (
					(_tags != null)
					&&
					((_contenttags = BusinessInstances.NWS_Tag.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDNews, 
						0, 0, 
						out _errors
					)) != null)
				) {
					SO_vNWS_Tag[] _tags2 = new SO_vNWS_Tag[_contenttags.Length];
					for (int t1 = 0; t1 < _contenttags.Length; t1++) {
						for (int t2 = 0; t2 < _tags.Length; t2++) {
							if (_contenttags[t1].IFTag == _tags[t2].IDTag) {
								_tags2[t1] = _tags[t2];
								break;
							}
						}
					}


					rep_Tags.DataSource = _tags2;
					rep_Tags.DataBind();
				}
				#endregion

				lbl_Publish_date.Text = string.Format(
					"{0}.{1}.{2} | {3}h{4}", 
					_content.Publish_date.Day.ToString().PadLeft(2, '0'),
					_content.Publish_date.Month.ToString().PadLeft(2, '0'), 
					_content.Publish_date.Year,
					_content.Publish_date.Hour.ToString().PadLeft(2, '0'),
					_content.Publish_date.Minute.ToString().PadLeft(2, '0')
				);
				lbl_Title.Text = _content.Title;
				lbl_Content.Text = OGen.lib.presentationlayer.webforms.utils.Replace_RN_BR(_content.Content);
			}
		}
	}
}