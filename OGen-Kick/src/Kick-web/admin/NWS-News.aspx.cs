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
	public partial class NWS_News : AdminPage {
		#region public long IDContent { get; }
		private long idcontent__ = -2L;

		public long IDContent {
			get {
				if (
					(idcontent__ == -2L)
					&&
					(
						!long.TryParse(
							Request.QueryString["IDContent"],
							out idcontent__
						)
					)
				) {
					idcontent__ = -1L;
				}

				return idcontent__;
			}
		}
		#endregion
		public const string PUBLIC_UPLOADS = "public-uploads";
		#region public string SERVER_MAPPATH_PUBLIC_UPLOADS { get; }
		private static string server_mappath_public_uploads__ = "";

		public string SERVER_MAPPATH_PUBLIC_UPLOADS {
			get {
				if (server_mappath_public_uploads__ == "") {
					server_mappath_public_uploads__ = Server.MapPath("~/" + PUBLIC_UPLOADS);
				}
				return server_mappath_public_uploads__;
			}
		}
		#endregion

		#region protected void Page_Load(object sender, EventArgs e);
		protected void Page_Load(object sender, EventArgs e) {
			Master__base.Error_clear();

			if (!Page.IsPostBack) {
				int[] _errors;

				#region Tags . . .
				SO_vNWS_Tag[] _so_tags
					= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byLang(
						utils.User.SessionGuid,
						utils.ClientIPAddress, 
						utils.IDLanguage__default,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_so_tags,
						delegate(
							SO_vNWS_Tag arg1_in,
							SO_vNWS_Tag arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_Tags.Kick.Bind__arrayOf<long, string>(
						"",
						_so_tags
					);
				}
				#endregion
				#region Source . . .
				SO_vNWS_Source[] _so_sources
					= BusinessInstances.NWS_Source.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_so_sources,
						delegate(
							SO_vNWS_Source arg1_in,
							SO_vNWS_Source arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_Source.Kick.Bind__arrayOf<long, string>(
						"",
						_so_sources
					);
				}
				#endregion
				#region Author . . .
				SO_vNWS_Author[] _so_authors
					= BusinessInstances.NWS_Author.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_so_authors,
						delegate(
							SO_vNWS_Author arg1_in,
							SO_vNWS_Author arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_Author.Kick.Bind__arrayOf<long, string>(
						"",
						_so_authors
					);
				}
				#endregion
				#region Highlight . . .
				SO_vNWS_Highlight[] _so_highlights
					= BusinessInstances.NWS_Highlight.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_so_highlights,
						delegate(
							SO_vNWS_Highlight arg1_in,
							SO_vNWS_Highlight arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_Highlight.Kick.Bind__arrayOf<long, string>(
						"",
						_so_highlights
					);
				}
				#endregion
				#region Profile . . .
				SO_vNWS_Profile[] _so_profiles
					= BusinessInstances.NWS_Profile.InstanceClient.getRecord_all(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						0, 0,
						out _errors
					);
				if (!Master__base.Error_show(_errors)) {
					Array.Sort(
						_so_profiles,
						delegate(
							SO_vNWS_Profile arg1_in,
							SO_vNWS_Profile arg2_in
						) {
							return arg1_in.Name.CompareTo(arg2_in.Name);
						}
					);
					cbl_Profiles.Kick.Bind__arrayOf<long, string>(
						"",
						_so_profiles
					);
				}
				#endregion

				if (IDContent > 0) {
					Bind();
				} else {
					Bind_empty();
				}
			}
		}
		#endregion
		//protected void tc_News_ActiveTabChanged(object sender, EventArgs e) {
		//}
		#region protected void btn_News_Click(object sender, EventArgs e);
		protected void btn_News_Click(object sender, EventArgs e) {
			int[] _errors = null;
			if (IDContent > 0L) {
				BusinessInstances.NWS_News.InstanceClient.updObject_Content(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					new SO_NWS_Content(
						IDContent,
						utils.IDApplication,
						-1L,
						DateTime.Now,
						-1,
						DateTime.MinValue,
						DateTime.MinValue,
						DateTime.MinValue,
						-1,
						-1,
						-1,
						-1,
						DateTime.MinValue,
						true
					),
					dic_Title.Texts,
					dic_News.Texts,
					dic_subtitle.Texts,
					dic_summary.Texts,
					out _errors
				);

				Master__base.Error_show(_errors);
			} else {
				long _idcontent = BusinessInstances.NWS_News.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					new SO_NWS_Content(
						-1L,
						utils.IDApplication,
						-1L,
						DateTime.Now,
						-1,
						DateTime.MinValue,
						DateTime.MinValue,
						DateTime.MinValue,
						-1,
						-1,
						-1,
						-1,
						DateTime.MinValue,
						true
					),
					dic_Title.Texts,
					dic_News.Texts,
					dic_subtitle.Texts,
					dic_summary.Texts,
					new long[] { },
					new long[] { },
					new long[] { },
					new long[] { },
					new long[] { },
					out _errors
				);

				if (!Master__base.Error_show(_errors)) {
					Response.Redirect(string.Format(
						"NWS-News.aspx?IDContent={0}",
						_idcontent
					));
				}
			}
		} 
		#endregion
		#region protected void btn_Tags_Click(object sender, EventArgs e);
		protected void btn_Tags_Click(object sender, EventArgs e) {
			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.updObject_Tags(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDContent,
				cbl_Tags.Kick.SelectedValue__get<long>(),
				out _errors
			);
			Master__base.Error_show(_errors);
		} 
		#endregion
		#region protected void btn_Authors_Click(object sender, EventArgs e);
		protected void btn_Authors_Click(object sender, EventArgs e) {
			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.updObject_Authors(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDContent,
				cbl_Author.Kick.SelectedValue__get<long>(),
				out _errors
			);
			Master__base.Error_show(_errors);
		}
		#endregion
		#region protected void btn_Sources_Click(object sender, EventArgs e);
		protected void btn_Sources_Click(object sender, EventArgs e) {
			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.updObject_Sources(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDContent,
				cbl_Source.Kick.SelectedValue__get<long>(),
				out _errors
			);
			Master__base.Error_show(_errors);
		}
		#endregion
		#region protected void btn_Highlights_Click(object sender, EventArgs e);
		protected void btn_Highlights_Click(object sender, EventArgs e) {
			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.updObject_Highlights(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDContent,
				cbl_Highlight.Kick.SelectedValue__get<long>(),
				out _errors
			);
			Master__base.Error_show(_errors);
		}
		#endregion
		#region protected void btn_Profiles_Click(object sender, EventArgs e);
		protected void btn_Profiles_Click(object sender, EventArgs e) {
			int[] _errors;
			BusinessInstances.NWS_News.InstanceClient.updObject_Profiles(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				IDContent,
				cbl_Profiles.Kick.SelectedValue__get<long>(),
				out _errors
			);
			Master__base.Error_show(_errors);
		}
		#endregion

		#region protected void btn_AttachmentUpload_Click(object sender, EventArgs e);
		protected void btn_AttachmentUpload_Click(object sender, EventArgs e) {
			if (fup_Attachment.HasFile) {
				#region bool _isImage = ...;
				bool _isImage;
				switch (fup_Attachment.PostedFile.ContentType.ToLower()) {
					case "image/png":
					case "image/jpeg":
					case "image/gif":
						//case "image/tiff":
						//case "image/bmp":
						_isImage = true;
						break;
					default:
						_isImage = false;
						break;
				}
				#endregion

				SO_NWS_Attachment _attachment = new SO_NWS_Attachment();
				int[] _errors;
				string _guid;
				long _idattachment = BusinessInstances.NWS_Attachment.InstanceClient.insObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					new SO_NWS_Attachment(
						-1L,
						IDContent,
						"", // Guid.NewGuid().ToString("N"),
						-1L, // DateTime.Now.Ticks,
						_isImage,
						-1L,
						-1L,
						fup_Attachment.FileName
					),
					null,
					null,
					true,
					out _guid,
					out _errors
				);
				if (!Master__base.Error_show(_errors)) {
					#region string _uploadPath = ...;
					string _uploadPath
						= System.IO.Path.Combine(
							System.IO.Path.Combine(
								System.IO.Path.Combine(
									SERVER_MAPPATH_PUBLIC_UPLOADS,
									"news"
								),
								IDContent.ToString()
							),
							string.Format(
								"{0}-{1}",
								_idattachment,
								_guid
							)
						);
					#endregion
					#region System.IO.Directory.CreateDirectory(_uploadPath);
					if (
						!System.IO.Directory.Exists(
							_uploadPath
						)
					) {
						System.IO.Directory.CreateDirectory(
							_uploadPath
						);
					}
					#endregion
#if DEBUG
					string _filePath;
#endif
					fup_Attachment.SaveAs(
#if DEBUG
						_filePath = 
#endif
						System.IO.Path.Combine(
							_uploadPath,
							fup_Attachment.FileName
						)
					);
#if DEBUG
					Master__base.Error_show(
						false, 
						_filePath
					);
#endif


					Bind();
				}
			} else {
				Master__base.Error_show(true, "no file!");
			}
		} 
		#endregion
		#region protected void btn_AttachmentDelete_Click(object sender, EventArgs e);
		protected void btn_AttachmentDelete_Click(object sender, EventArgs e) {
			long _idattachment = long.Parse(((IButtonControl)sender).CommandArgument);
			int[] _errors;
			BusinessInstances.NWS_Attachment.InstanceClient.delObject(
				utils.User.SessionGuid,
				utils.ClientIPAddress,
				_idattachment,
				out _errors
			);
			if (!Master__base.Error_show(_errors)) {
				Bind();
			}
		}
		#endregion
		#region protected void btn_AttachmentSave_Click(object sender, EventArgs e);
		protected void btn_AttachmentSave_Click(object sender, EventArgs e) {
			long _idattachment = long.Parse(((IButtonControl)sender).CommandArgument);

			wuc_txt_Dic _dic_name = null;
			wuc_txt_Dic _dic_description = null;
			foreach (RepeaterItem _item in rep_Attachments.Items) {
				if (_item.FindControl(((Button)sender).ID) == sender) {
					_dic_name = (wuc_txt_Dic)_item.FindControl("dic_Name");
					_dic_description = (wuc_txt_Dic)_item.FindControl("dic_Description");
					break;
				}
			}

			if (
				(_dic_name != null)
				&&
				(_dic_description != null)
			) {
				int[] _errors;
				BusinessInstances.NWS_Attachment.InstanceClient.updObject(
					utils.User.SessionGuid,
					utils.ClientIPAddress,
					new SO_NWS_Attachment(
						_idattachment,
						IDContent,
						"",
						-1L,
						true,
						-1L,
						-1L,
						""
					),
					_dic_name.Texts,
					_dic_description.Texts,
					out _errors
				);
				if (!Master__base.Error_show(_errors)) {
				}
			}
		}
		#endregion

		#region public void Bind(...);
		public void Bind(
		) {
			int[] _errors;

			if (IDContent > 0) {
				SO_vNWS_Content[] _contents 
					= BusinessInstances.NWS_News.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDContent,
						out _errors
					);
				if (
					!Master__base.Error_show(_errors)
					&&
					(_contents != null)
					&&
					(_contents.Length != 0)
				) {
					#region Bind . . .

#if !DEBUG
div_Attachments.Visible = true;
div_Tags.Visible = true;
div_Authors.Visible = true;
div_Sources.Visible = true;
div_Highlights.Visible = true;
div_Profiles.Visible = true;
#endif

					#region Content . . .
					List<SO_DIC__TextLanguage> _title
						= new List<SO_DIC__TextLanguage>(
							_contents.Length
						);
					List<SO_DIC__TextLanguage> _subtitle
						= new List<SO_DIC__TextLanguage>(
							_contents.Length
						);
					List<SO_DIC__TextLanguage> _news
						= new List<SO_DIC__TextLanguage>(
							_contents.Length
						);
					List<SO_DIC__TextLanguage> _summary
						= new List<SO_DIC__TextLanguage>(
							_contents.Length
						);

					foreach (SO_vNWS_Content _content in _contents) {
						_title.Add(new SO_DIC__TextLanguage(
							_content.IDLanguage,
							_content.Title
						));
						_subtitle.Add(new SO_DIC__TextLanguage(
							_content.IDLanguage,
							_content.subtitle
						));
						_news.Add(new SO_DIC__TextLanguage(
							_content.IDLanguage,
							_content.Content
						));
						_summary.Add(new SO_DIC__TextLanguage(
							_content.IDLanguage,
							_content.summary
						));
					}

					dic_Title.Texts = _title.ToArray();
					dic_subtitle.Texts = _subtitle.ToArray();
					dic_News.Texts = _news.ToArray();
					dic_summary.Texts = _summary.ToArray();
					#endregion

					#region cbl_Tags.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentTag>(...);
					SO_NWS_ContentTag[] _tags 
						= BusinessInstances.NWS_Tag.InstanceClient.getRecord_byContent(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							IDContent,
							0, 0,
							out _errors
						);
					if (!Master__base.Error_show(_errors)) {
						cbl_Tags.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentTag>(
							_tags,
							delegate(
								SO_NWS_ContentTag arg1_in
							) {
								return arg1_in.IFTag.ToString();
							}
						);
					} 
					#endregion
					#region cbl_Author.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentAuthor>(...);
					SO_NWS_ContentAuthor[] _authors = BusinessInstances.NWS_Author.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDContent,
						0, 0,
						out _errors
					);
					if (!Master__base.Error_show(_errors)) {
						cbl_Author.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentAuthor>(
							_authors,
							delegate(
								SO_NWS_ContentAuthor arg1_in
							) {
								return arg1_in.IFAuthor.ToString();
							}
						);
					}
					#endregion
					#region cbl_Source.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentSource>(...);
					SO_NWS_ContentSource[] _sources = BusinessInstances.NWS_Source.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDContent,
						0, 0,
						out _errors
					);
					if (!Master__base.Error_show(_errors)) {
						cbl_Source.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentSource>(
							_sources,
							delegate(
								SO_NWS_ContentSource arg1_in
							) {
								return arg1_in.IFSource.ToString();
							}
						);
					}
					#endregion
					#region cbl_Profile.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentProfile>(...);
					SO_NWS_ContentProfile[] _profiles = BusinessInstances.NWS_Profile.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDContent,
						0, 0,
						out _errors
					);
					if (!Master__base.Error_show(_errors)) {
						cbl_Profiles.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentProfile>(
							_profiles,
							delegate(
								SO_NWS_ContentProfile arg1_in
							) {
								return arg1_in.IFProfile.ToString();
							}
						);
					}
					#endregion
					#region cbl_Highlight.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentHighlight>(...);
					SO_NWS_ContentHighlight[] _highlights = BusinessInstances.NWS_Highlight.InstanceClient.getRecord_byContent(
						utils.User.SessionGuid,
						utils.ClientIPAddress,
						IDContent,
						0, 0,
						out _errors
					);
					if (!Master__base.Error_show(_errors)) {
						cbl_Highlight.Kick.SelectedValues__set_arrayOf<SO_NWS_ContentHighlight>(
							_highlights,
							delegate(
								SO_NWS_ContentHighlight arg1_in
							) {
								return arg1_in.IFHighlight.ToString();
							}
						);
					}
					#endregion

					#region Attachments . . .
					SO_vNWS_Attachment[] _attachments
						= BusinessInstances.NWS_Attachment.InstanceClient.getRecord_byContent(
							utils.User.SessionGuid,
							utils.ClientIPAddress,
							IDContent,
							0, 0,
							out _errors
						);
					if (!Master__base.Error_show(_errors)) {
						#region Array.Sort(_attachments);
						Array.Sort(
							_attachments,
							delegate(
								SO_vNWS_Attachment arg1_in,
								SO_vNWS_Attachment arg2_in
							) {
								if (arg1_in.OrderNum_isNull && !arg2_in.OrderNum_isNull) {
									return 1;
								}
								if (!arg1_in.OrderNum_isNull && arg2_in.OrderNum_isNull) {
									return -1;
								}
								if (
									arg1_in.OrderNum_isNull || arg2_in.OrderNum_isNull
								) {
									return arg1_in.Name.CompareTo(arg2_in.Name);
								} else {
									return arg1_in.OrderNum.CompareTo(arg2_in.OrderNum);
								}
							}
						);
						#endregion


						Dictionary<long, SO_vNWS_Attachment> _dic_attachments_only
							= new Dictionary<long, SO_vNWS_Attachment>(
								_attachments.Length
							);
						foreach (SO_vNWS_Attachment _attachment in _attachments) {
							if (!_dic_attachments_only.ContainsKey(_attachment.IDAttachment)) {
								_dic_attachments_only.Add(
									_attachment.IDAttachment,
									_attachment
								);
							}
						}
						#region SO_vNWS_Attachment[] _attachments_only; _dic_attachments_only.Values.CopyTo(_attachments_only);
						SO_vNWS_Attachment[] _attachments_only
							= new SO_vNWS_Attachment[
								_dic_attachments_only.Keys.Count
							];
						_dic_attachments_only.Values.CopyTo(
							_attachments_only,
							0
						); 
						#endregion
						rep_Attachments.DataSource = _attachments_only;
						rep_Attachments.DataBind();


						System.Web.UI.HtmlControls.HtmlAnchor _a_attachment;
						System.Web.UI.HtmlControls.HtmlImage _img_attachment;
						wuc_txt_Dic _dic_name;
						wuc_txt_Dic _dic_description;
						List<SO_DIC__TextLanguage> _attachment_name;
						List<SO_DIC__TextLanguage> _attachment_description;
						for (int i = 0; i < rep_Attachments.Items.Count; i++ ) {
							_dic_name = (wuc_txt_Dic)rep_Attachments.Items[i].FindControl("dic_Name");
							_dic_description = (wuc_txt_Dic)rep_Attachments.Items[i].FindControl("dic_Description");
							_a_attachment = (System.Web.UI.HtmlControls.HtmlAnchor)rep_Attachments.Items[i].FindControl("a_Attachment");
							_img_attachment = (System.Web.UI.HtmlControls.HtmlImage)rep_Attachments.Items[i].FindControl("img_Attachment");

							_img_attachment.Src 
								= _a_attachment.HRef 
								= string.Format(
									"~/{0}/news/{1}/{2}-{3}/{4}",
									PUBLIC_UPLOADS, 
									_attachments_only[i].IFContent,
									_attachments_only[i].IDAttachment,
									_attachments_only[i].GUID, 
									_attachments_only[i].FileName
								);

							#region _dic_???.Texts = ...;
							_attachment_name
								= new List<SO_DIC__TextLanguage>(
									_attachments.Length
								);
							_attachment_description
								= new List<SO_DIC__TextLanguage>(
									_attachments.Length
								);
							foreach (SO_vNWS_Attachment _attachment in _attachments) {
								if (_attachment.IDAttachment == _attachments_only[i].IDAttachment) {
									_attachment_name.Add(new SO_DIC__TextLanguage(
										_attachment.IDLanguage,
										_attachment.Name
									));
									_attachment_description.Add(new SO_DIC__TextLanguage(
										_attachment.IDLanguage,
										_attachment.Description
									));
								}
							}

							_dic_name.Texts = _attachment_name.ToArray();
							_dic_description.Texts = _attachment_description.ToArray();
							#endregion
						}
					}
					#endregion
					#endregion

					return;
				}
			}
				
			Bind_empty();
		}
		#endregion
		#region public void Bind_empty(...);
		public void Bind_empty(
		) {
			dic_Title.Texts = null;
			dic_subtitle.Texts = null;
			dic_News.Texts = null;
			dic_summary.Texts = null;

#if !DEBUG
div_Attachments.Visible = false;
div_Tags.Visible = false;
div_Authors.Visible = false;
div_Sources.Visible = false;
div_Highlights.Visible = false;
div_Profiles.Visible = false;
#endif
		}
		#endregion
	}
}