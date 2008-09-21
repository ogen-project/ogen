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
	"{0}-index.html",
	_aux_doc.DocumentationName
);

int _aux_chapter_index = _aux_doc.Chapters.ChapterCollection.Search(_arg_ChapterTitle);
XS_chapterType _aux_chapter = _aux_doc.Chapters.ChapterCollection[_aux_chapter_index];

int _aux_chapter_index_previous = _aux_chapter_index - 1;
int _aux_chapter_index_next
	= (_aux_chapter_index == (_aux_doc.Chapters.ChapterCollection.Count - 1)) 
		? -1 
		: (_aux_chapter_index + 1);
XS_chapterType _aux_chapter_previous
	= (_aux_chapter_index_previous != -1)
		? _aux_doc.Chapters.ChapterCollection[_aux_chapter_index_previous]
		: null;
XS_chapterType _aux_chapter_next
	= (_aux_chapter_index_next != -1)
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

bool _aux_showtitle = false;

XS_itemType _aux_item;
XS_attachmentType _aux_attachment;

#endregion
//-----------------------------------------------------------------------------------------
%><html>
	<head>
		<title>
			<%=_aux_doc.DocumentationName%> - <%=_aux_doc.DocumentationTitle%> - <%=_aux_chapter.Title%><%=(_aux_chapter.Subtitle != string.Empty) ? " - " + _aux_chapter.Subtitle : ""%>
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
							<td align="left" valign="top" style="width:33%;">
								<a href="<%=_aux_chapter_link_previous%>">
									previous</a>
								<br />
								<span class="text"><%
									if (_aux_chapter_previous != null) {%>
										<%=_aux_chapter_previous.Title%><%
									} else {%>
										index<%
									}%>
								</span>
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
<!-- /separator -->
<!-- chapter -->
			<tr>
				<td width="10"></td>
				<td colspan="2">
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
						<a name="<%=i%>" />
						<span class="title">
							<%=_aux_chapter.Number%>.<%=i + 1%>. 
							<%=_aux_item.Title%>
						</span>
						<br /><%
						if (_aux_item.SubTitle != string.Empty) {%>
							<span class="subtitle">
								<%=_aux_item.SubTitle%>
							</span>
							<br /><%
						}%>

						<br />
					</td>
					<td width="10"></td>
				</tr>

				<tr>
					<td width="10"></td>
					<td width="20"></td>
					<td><%
						for (int a = 0; a < _aux_item.Attachments.AttachmentCollection.Count; a++) {
							_aux_attachment = _aux_item.Attachments.AttachmentCollection[a];
							if (
								_aux_showtitle
									= (
										_aux_attachment.ShowTitle
										&&
										(_aux_attachment.Title.Trim() != string.Empty)
									)
							) {%>
							<a name="<%=i%>.<%=a%>" />
							<span class="subsubtitle">
								<%=_aux_attachment.Title%>
							</span>
							<br /><%
							}
							switch (_aux_attachment.SourceContentType) {
								case XS_SourceContentTypeEnumeration.html:
									if (_aux_showtitle) {%>
										<br /><%
									}%>
									<span class="text">
										<%=utils.ReadFile(
											_aux_path,
											_aux_attachment.Source
										)%>
									</span>
									<br />
									<br /><%
									break;
								case XS_SourceContentTypeEnumeration.code:%>
									<div class="code">
										<pre><%=utils.ReadFile(
											_aux_path,
											_aux_attachment.Source
										)%></pre>
									</div><%
									break;
								case XS_SourceContentTypeEnumeration.image:
									break;
								case XS_SourceContentTypeEnumeration.table:
									break;

								case XS_SourceContentTypeEnumeration.comment:
									break;
								case XS_SourceContentTypeEnumeration.tip:
									break;
								case XS_SourceContentTypeEnumeration.warning:
									break;
							}
						}%>
					</td>
					<td width="10"></td>
				</tr>
<!-- /chapter:items --><%
			}%>
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
							<td align="left" valign="top" style="width:33%;">
								<a href="<%=_aux_chapter_link_previous%>">
									previous</a>
								<br />
								<span class="text"><%
									if (_aux_chapter_previous != null) {%>
										<%=_aux_chapter_previous.Title%><%
									} else {%>
										index<%
									}%>
								</span>
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