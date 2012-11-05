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

	public partial class FE_News : SitePage {
		#region public long IDNews { get; }
		private long idnews__ = -2;

		public long IDNews {
			get {
				if (
					(this.idnews__ == -2)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDNews"],
							out this.idnews__
						)
					)
				) {
					this.idnews__ = -1;
				}

				return this.idnews__;
			}
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e) {
			if (!this.Page.IsPostBack) {
				this.Bind();
			}
		}

		public void Bind() {
			this.REP_Tags.Visible = false;
			this.REP_Sources.Visible = false;
			this.REP_Attachments.Visible = false;
			this.TR_Attachments1.Visible = false;
			this.TR_Details.Visible = false;
			this.TBL_News.Visible = false;

			if (this.IDNews <= 0) {
				return;
			}

			bool _showDetails = false;
			int[] _errors;
			long _count;

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
				this.IDNews, 
				utils.IDLanguage__default, 
				out _errors
			);
			if (!this.Master__base.Error_add(_errors)) {
				if (_content != null) {
					#region REP_Attachments.DataSource = ...; REP_Attachments.DataBind();
					_attachments = BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent_andLanguage(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDNews,
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

						#region _attachment = ...; _attachments_final = ...;
						_attachments_final = (_attachments.Length > 0) ? new List<SO_vNWS_Attachment>(_attachments.Length) : null;

						_attachment = null;
						int _image_count = 0;
						foreach (SO_vNWS_Attachment _attachment2 in _attachments) {
							if (_attachment2.IsImage) {
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
								!_attachment2.IsImage
								||
								(_image_count > 2)
							) {
								// NOT image OR [ image BUT beyond the ones used for display ]
								_attachments_final.Add(_attachment2);
							}
						}
						#endregion

						#region this.IMG_News.ImageUrl = ...;
						if (_attachment != null) {
							this.IMG_News.ImageUrl = string.Format(
								System.Globalization.CultureInfo.CurrentCulture,
								"~/public-uploads/news/{0}/{1}-{2}/{3}",
								_attachment.IFContent,
								_attachment.IDAttachment,
								_attachment.GUID,
								_attachment.FileName
							);

							if (
								!_attachment.Name_isNull
								&&
								(!string.IsNullOrEmpty(_attachment.Name))
							) {
								this.LBL_Image_Name.Text = _attachment.Name;
							}
							if (
								!_attachment.Description_isNull
								&&
								(!string.IsNullOrEmpty(_attachment.Description))
							) {
								this.LBL_Image_Description.Text = string.Format(
									System.Globalization.CultureInfo.CurrentCulture,
									"({0})",
									_attachment.Description
								);
							}
						}
						#endregion
						#region REP_Attachments...
						if (
							(_attachments_final != null)
							&&
							(_attachments_final.Count > 0)
						) {
							this.REP_Attachments.DataSource = _attachments_final;
							this.REP_Attachments.DataBind();
							this.REP_Attachments.Visible = true;

							this.TR_Attachments1.Visible = true;
						}
						#endregion
					}
					#endregion

					#region REP_Sources.DataSource = ...; REP_Sources.DataBind();
					_contentsources = BusinessInstances.NWS_Source.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDNews,
						0, 0, 0, out _count, 
						out _errors
					);
					if (
						!this.Master__base.Error_add(_errors)
						&&
						(_contentsources != null)
						&&
						(_contentsources.Length > 0)
					) {
						_sources
							= BusinessInstances.NWS_Source.InstanceClient.getRecord_Approved(
								utils.User.SessionGuid,
								utils.ClientIPAddress,
								0, 0, 0, out _count, 
								out _errors
							);
						if (!this.Master__base.Error_add(_errors)) {
							SO_vNWS_Source[] _sources2 = new SO_vNWS_Source[_contentsources.Length];
							for (int s1 = 0; s1 < _contentsources.Length; s1++) {
								for (int s2 = 0; s2 < _sources.Length; s2++) {
									if (_contentsources[s1].IFSource == _sources[s2].IDSource) {
										_sources2[s1] = _sources[s2];
										break;
									}
								}
							}

							this.REP_Sources.DataSource = _sources2;
							this.REP_Sources.DataBind();

							this.REP_Sources.Visible = true;
							_showDetails = true;
						}
					}
					#endregion
					#region REP_Tags.DataSource = ...; REP_Tags.DataBind();
					_contenttags = BusinessInstances.NWS_Tag.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						this.IDNews,
						0, 0, 0, out _count, 
						out _errors
					);
					if (
						!this.Master__base.Error_add(_errors)
						&&
						(_contenttags != null)
						&&
						(_contenttags.Length > 0)
					) {
						_tags
							= BusinessInstances.NWS_Tag.InstanceClient.getRecord_Approved_byLang(
								utils.User.SessionGuid,
								utils.ClientIPAddress,
								utils.IDLanguage__default,
								0, 0, 0, out _count, 
								out _errors
							);
						if (!this.Master__base.Error_add(_errors)) {
							SO_vNWS_Tag[] _tags2 = new SO_vNWS_Tag[_contenttags.Length];
							for (int t1 = 0; t1 < _contenttags.Length; t1++) {
								for (int t2 = 0; t2 < _tags.Length; t2++) {
									if (_contenttags[t1].IFTag == _tags[t2].IDTag) {
										_tags2[t1] = _tags[t2];
										break;
									}
								}
							}

							this.REP_Tags.DataSource = _tags2;
							this.REP_Tags.DataBind();

							this.REP_Tags.Visible = true;
							_showDetails = true;
						}
					}
					#endregion
					this.TR_Details.Visible = _showDetails;

					this.LBL_Publish_date.Text = string.Format(
						System.Globalization.CultureInfo.CurrentCulture,
						"{0}.{1}.{2} | {3}h{4}",
						_content.Publish_date.Day.ToString(System.Globalization.CultureInfo.CurrentCulture).PadLeft(2, '0'),
						_content.Publish_date.Month.ToString(System.Globalization.CultureInfo.CurrentCulture).PadLeft(2, '0'),
						_content.Publish_date.Year,
						_content.Publish_date.Hour.ToString(System.Globalization.CultureInfo.CurrentCulture).PadLeft(2, '0'),
						_content.Publish_date.Minute.ToString(System.Globalization.CultureInfo.CurrentCulture).PadLeft(2, '0')
					);
					this.LBL_Title.Text = _content.Title;
					this.LBL_Content.Text = OGen.Libraries.PresentationLayer.WebForms.utils.Replace_RN_BR(_content.Content);

					this.TBL_News.Visible = true;
				} else {
					this.Master__base.Error_add(false, "no data");
				}
			}
		}
	}
}