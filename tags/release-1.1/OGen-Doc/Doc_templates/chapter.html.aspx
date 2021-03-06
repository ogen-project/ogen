<%/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="System.IO" %>
<%@ import namespace="OGen.Doc.lib.metadata" %>
<%@ import namespace="OGen.Doc.lib.metadata.documentation" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_DocumentationName = System.Web.HttpUtility.UrlDecode(Request.QueryString["DocumentationName"]);
string _arg_ChapterTitle = System.Web.HttpUtility.UrlDecode(Request.QueryString["ChapterTitle"]);
bool _arg_all = (_arg_ChapterTitle == string.Empty);
#endregion

#region varaux...
XS__RootMetadata _aux_rootmetadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath,
	true
);
XS__documentation _aux_doc
	= _aux_rootmetadata.DocumentationCollection[
		_arg_DocumentationName
	];

string _aux_documentation_index = string.Format(
	"{0}-index{1}.html",
	_aux_doc.DocumentationName,
	_arg_all ? "-all" : ""
);

int _aux_chapter_index
	= (!_arg_all)
		? _aux_doc.Chapters.ChapterCollection.Search(_arg_ChapterTitle)
		: -1;
XS_chapterType _aux_chapter 
	= (_aux_chapter_index >= 0) 
		? _aux_doc.Chapters.ChapterCollection[_aux_chapter_index]
		: null;

int _aux_chapter_index_previous = _aux_chapter_index - 1;
int _aux_chapter_index_next
	= (
		(_aux_chapter_index < 0)
		||
		(_aux_chapter_index == (_aux_doc.Chapters.ChapterCollection.Count - 1)) 
	)
		? -1 
		: (_aux_chapter_index + 1);
XS_chapterType _aux_chapter_previous
	= (_aux_chapter_index_previous >= 0)
		? _aux_doc.Chapters.ChapterCollection[_aux_chapter_index_previous]
		: null;
XS_chapterType _aux_chapter_next
	= (_aux_chapter_index_next >= 0)
		? _aux_doc.Chapters.ChapterCollection[_aux_chapter_index_next]
		: null;
string _aux_chapter_link_previous = 
	(_aux_chapter_previous != null)
		? string.Format(
			"{0}-chapter-{1}-{2}.html", 
			_aux_doc.DocumentationName, 
			_aux_chapter_previous.Number, 
			_aux_chapter_previous.FileName
		)
		: _aux_documentation_index;
string _aux_chapter_link_next = 
	(_aux_chapter_next != null)
		? string.Format(
			"{0}-chapter-{1}-{2}.html",
			_aux_doc.DocumentationName,
			_aux_chapter_next.Number, 
			_aux_chapter_next.FileName
		)
		: "";
	
string _aux_path = Path.GetDirectoryName(_arg_MetadataFilepath);
string _aux_path_directoryname = Path.GetFileName(_aux_path);

bool _aux_showtitle = false;

XS_itemType _aux_item;
XS_attachmentType _aux_attachment;

int _attchementIncrement = 0;

string _aux_attachment_source;

#endregion
//-----------------------------------------------------------------------------------------
%><html>
	<head>
		<title>
			<%=_aux_doc.DocumentationName%> - <%=_aux_doc.DocumentationTitle%><%
			if (!_arg_all) {%>
				- <%=_aux_chapter.Title%><%=(_aux_chapter.Subtitle != string.Empty) ? " - " + _aux_chapter.Subtitle : ""%><%
			}%>
		</title>
		<link rel="stylesheet" href="_include/doc.css" type="text/css" /><%--
		<script language="JavaScript" src="_include/lib_doc.js"></script>--%>
	</head>
	<body
		style="background-color:White;bottom:0;top:0;left:0;right:0"
		bottommargin="0"
		topmargin="0"
		leftmargin="0"
		rightmargin="0">

		<table cellpadding="0" cellspacing="0" width="100%" border="0">
<!-- menu -->
			<tr>
				<td colspan="4" bgcolor="#C0C0C0">
					<table cellpadding="5" cellspacing="5" width="100%" class="menu" border="0">
						<tr>
							<td align="left">
								<a href="<%=_aux_doc.ProjectURL%>">
									home</a>
								&nbsp;&nbsp;|&nbsp;&nbsp;
								<a href="<%=_aux_documentation_index%>">
									Documentation</a>
								&nbsp;&nbsp;|&nbsp;&nbsp;
								<a href="http://developer.berlios.de/projects/ogen/">
									BerliOS project page</a>
							</td>
						</tr>
					</table>
				</td>
			</tr>
<!-- /menu -->
<!-- separator -->
			<tr valign="top">
				<td colspan="4" bgcolor="#000000" height="1"></td>
			</tr>
<!-- /separator -->
<!-- head -->
			<tr>
				<td colspan="4" bgcolor="#99CCFF">
					<table cellpadding="5" cellspacing="5" width="100%" class="menu" border="0">
						<tr>
							<td align="left" colspan="2">
								<%=_aux_doc.DocumentationTitle%>
							</td>
							<td align="right">
								<%=_aux_doc.Version%></td>
						</tr>


<!-- head:paging -->
						<tr>
							<td align="left" valign="top" style="width:33%;"><%
								if (_aux_chapter_previous != null) {%>
									<a href="<%=_aux_chapter_link_previous%>">
										previous</a>
									<br />
									<span class="text">
										<%=_aux_chapter_previous.Title%>
									</span><%
								}%>
							</td>
							<td align="center" valign="top" style="width:34%;">
								<span class="text">
									<a href="<%=_aux_documentation_index%>">
										index</a>
								</span>
							</td>
							<td align="right" valign="top" style="width:33%;"><%
								if (_aux_chapter_link_next != string.Empty) {%>
									<a href="<%=_aux_chapter_link_next%>">
										next</a>
									<br />
									<span class="text">
										<%=_aux_chapter_next.Title%>
									</span><%
								}%>
							</td>
						</tr>
<!-- /head:paging -->


					</table>
				</td>
			</tr>
<!-- /head -->
<!-- separator -->
			<tr valign="top">
				<td colspan="4" bgcolor="#000000" height="1"></td>
			</tr>
<!-- /separator --><%


// <!-- CHAPTERS -->
for (int c = 0; c < _aux_doc.Chapters.ChapterCollection.Count; c++) {
	if (_arg_all) {
		_aux_chapter = _aux_doc.Chapters.ChapterCollection[c];
	} else {
		// needed for index pointer
		c = _aux_chapter.Number - 1;
	}
%>
<!-- chapter -->
			<tr>
				<td width="10"></td>
				<td colspan="2">
					<a name="ch<%=c + 1%>"></a>
					<br />

					<span class="title">
						<%=_aux_chapter.Number%>.
						<%=_aux_chapter.Title%><%
					if (_aux_chapter.Subtitle.Trim() != string.Empty) {%>
						- <%=_aux_chapter.Subtitle%><%
					}%>
					</span>
					<br />
					<br />
				</td>
				<td width="10"></td>
			</tr>
<!-- /chapter --><%
			for (int i = 0; i < _aux_chapter.Items.ItemCollection.Count; i++) {
				_aux_item = _aux_chapter.Items.ItemCollection[i];%>
<!-- chapter:items -->
				<tr>
					<td width="10"></td>
					<td colspan="2">
						<a name="ch<%=c + 1%>.it<%=i + 1%>"></a>
						<span class="title">
							<%=_aux_chapter.Number%>.<%=i + 1%>. 
							<%=_aux_item.Title%><%
							if (_aux_item.SubTitle != string.Empty) {%>
								- <%=_aux_item.SubTitle%><%
							}%>
						</span>
						<br />
						<br />
					</td>
					<td width="10"></td>
				</tr>

				<tr>
					<td width="10"></td>
					<td width="20"></td>
					<td><%
						_attchementIncrement = 0;
						for (int a = 0; a < _aux_item.Attachments.AttachmentCollection.Count; a++) {
							_aux_attachment = _aux_item.Attachments.AttachmentCollection[a];
							if (_aux_attachment.IncrementLevel)
								_attchementIncrement++;

							if (
								_aux_showtitle
									= (
										_aux_attachment.ShowTitle
										&&
										(_aux_attachment.Title.Trim() != string.Empty)
									)
							) {%>
								<a name="ch<%=c + 1%>.it<%=i + 1%>.at<%=a + 1%>"></a><%
								if (_aux_attachment.IncrementLevel) {%>
									<span class="title">
										<%=_aux_chapter.Number%>.<%=i + 1%>.<%=_attchementIncrement%>.
										<%=_aux_attachment.Title%>
									</span><%
								} else {%>
									<span class="subsubtitle">
										<%=_aux_attachment.Title%>
									</span><%
								}%>
								<br />
								<br /><%
							}

							switch (_aux_attachment.SourceContentType) {
								case XS_SourceContentTypeEnumeration.html:
								case XS_SourceContentTypeEnumeration.code:
								case XS_SourceContentTypeEnumeration.table:
								case XS_SourceContentTypeEnumeration.comment:
								case XS_SourceContentTypeEnumeration.tip:
								case XS_SourceContentTypeEnumeration.warning:
									_aux_attachment_source
										= utils.ReadFile(
											_aux_path,
											_aux_attachment.Source
										);
									break;
								case XS_SourceContentTypeEnumeration.image:
// ToDos: here!
								default:
									_aux_attachment_source = string.Empty;
									break;
							}
							switch (_aux_attachment.SourceContentType) {
// <html> //////////////////////////////////////////////////////////////////////////////
								case XS_SourceContentTypeEnumeration.html:%>
									<span class="text">
										<%=_aux_attachment_source%>
									</span><%
									break;
// </html> /////////////////////////////////////////////////////////////////////////////
// <code> //////////////////////////////////////////////////////////////////////////////
								case XS_SourceContentTypeEnumeration.code:
									_aux_attachment_source = utils.ReadDocument_part(
										_aux_attachment_source
									);%>
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td align="center">
												<table cellpadding="0" cellspacing="0" border="0" width="100%">
													<tr>
														<td 
															align="left"><pre
																id="<%=_aux_chapter.Number%>.<%=i + 1%>.<%=_aux_attachment.CodeNumber%>"
																class="code"
														><%=_aux_attachment_source%></pre></td>
													</tr>
													<tr>
														<td 
															align="center">
															<span class="text">
																code <%=_aux_chapter.Number%>.<%=i + 1%>.<%=_aux_attachment.CodeNumber%><%
																if (
																	(_aux_attachment.Description = _aux_attachment.Description.Trim())
																	!=
																	string.Empty
																) {
																	%>: <%=_aux_attachment.Description%><%
																}%>
															</span>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<br /><%
									break;
// </code> /////////////////////////////////////////////////////////////////////////////
// <image> /////////////////////////////////////////////////////////////////////////////
								case XS_SourceContentTypeEnumeration.image:%>
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td align="center">
												<img 
													src="<%=_aux_path_directoryname%>/<%=_aux_attachment.Source%>" /></td>
										</tr>
										<tr>
											<td align="center">
												<span class="text">
													figure <%=_aux_chapter.Number%>.<%=i + 1%>.<%=_aux_attachment.ImageNumber%><%
													if (
														(_aux_attachment.Description = _aux_attachment.Description.Trim())
														!=
														string.Empty
													) {
														%>: <%=_aux_attachment.Description%><%
													}%>
												</span>
											</td>
										</tr>
									</table>
									<br /><%
									break;
// </image> ////////////////////////////////////////////////////////////////////////////
// <table> /////////////////////////////////////////////////////////////////////////////
								case XS_SourceContentTypeEnumeration.table:%>
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td align="center">
												<div class="anex">
													<table 
														cellpadding="4" 
														cellspacing="0" 
														border="0" 
														width="100%">
														<%=_aux_attachment_source%>
													</table>
												</div>
											</td>
										</tr>
										<tr>
											<td align="center">
												<span class="text">
													table <%=_aux_chapter.Number%>.<%=i + 1%>.<%=_aux_attachment.TableNumber%><%
													if (
														(_aux_attachment.Description = _aux_attachment.Description.Trim())
														!=
														string.Empty
													) {
														%>: <%=_aux_attachment.Description%><%
													}%>
												</span>
											</td>
										</tr>
									</table>
									<br /><%
									break;
// </table> ////////////////////////////////////////////////////////////////////////////
// <comments> //////////////////////////////////////////////////////////////////////////
								case XS_SourceContentTypeEnumeration.comment:
								case XS_SourceContentTypeEnumeration.tip:
								case XS_SourceContentTypeEnumeration.warning:%>
									<div class="anex">
										<table cellpadding="4" cellspacing="0" border="0" width="100%">
											<tr>
												<td valign="top" align="right" style="width:10%;">
													<span 
														class="text"><%
														switch (_aux_attachment.SourceContentType) {
															case XS_SourceContentTypeEnumeration.comment:%>
																<span class="comment">
																	Comment
																</span><%
																break;
															case XS_SourceContentTypeEnumeration.tip:%>
																<span class="tip">
																	Tip
																</span><%
																break;
															case XS_SourceContentTypeEnumeration.warning:%>
																<span class="warning">
																	Warning
																</span><%
																break;
														}%>
													</span>
												</td>
												<td>&nbsp;&nbsp;</td>
												<td valign="top" align="left" style="width:90%;">
													<span class="text">
														<%=_aux_attachment_source%>
													</span>
												</td>
											</tr>
										</table>
									</div>
									<br /><%
									break;
// </comments> /////////////////////////////////////////////////////////////////////////
							}
						}%>
					</td>
					<td width="10"></td>
				</tr>
<!-- /chapter:items --><%
			}

	if (!_arg_all) {
		break;
	}
}
// <!-- /CHAPTERS -->


%>
<!-- separator -->
			<tr valign="top">
				<td colspan="4" bgcolor="#000000" height="1"></td>
			</tr>
<!-- /separator -->
<!-- bottom -->
			<tr>
				<td colspan="4" bgcolor="#99CCFF" valign="top">
					<table cellpadding="5" cellspacing="5" width="100%" class="menu" border="0">


<!-- bottom:paging -->
						<tr>
							<td align="left" valign="top" style="width:33%;"><%
								if (_aux_chapter_previous != null) {%>
									<a href="<%=_aux_chapter_link_previous%>">
										previous</a>
									<br />
									<span class="text">
										<%=_aux_chapter_previous.Title%>
									</span><%
								}%>
							</td>
							<td align="center" valign="top" style="width:34%;">
								<span class="text">
									<a href="<%=_aux_documentation_index%>">
										index</a>
								</span>
							</td>
							<td align="right" valign="top" style="width:33%;"><%
								if (_aux_chapter_link_next != string.Empty) {%>
									<a href="<%=_aux_chapter_link_next%>">
										next</a>
									<br />
									<span class="text">
										<%=_aux_chapter_next.Title%>
									</span><%
								}%>
							</td>
						</tr>
<!-- /bottom:paging -->


						<tr>
							<td align="left" valign="top" colspan="3">
								<a href="mailto:<%=_aux_doc.FeedbackEmailAddress%>?subject=[<%=_aux_doc.DocumentationName%>] <%=_aux_chapter.Number%>. <%=_aux_chapter.Title%><%=(_aux_chapter.Subtitle != string.Empty) ? " - " + _aux_chapter.Subtitle : ""%>">Send comments on this topic.</a>
								<br />
								<a href="LICENSE.FDL.txt"><%=_aux_doc.CopyrightText%></a>
							</td>
						</tr>
					</table>
				</td>
			</tr>
<!-- /bottom -->
		</table>
	</body>
</html>
