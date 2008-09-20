<%/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/%><%@ Page language="c#" contenttype="text/html" %>
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

int _aux_chapter_index = _aux_doc.Chapters.ChapterCollection.Search(_arg_ChapterTitle);
XS_chapterType _aux_chapter = _aux_doc.Chapters.ChapterCollection[_aux_chapter_index];
#endregion
//-----------------------------------------------------------------------------------------
%><html>
	<head>
		<title>
			<%=_aux_doc.DocumentationName%> - <%=_aux_chapter.Title%><%=(_aux_chapter.Subtitle != string.Empty) ? " - " + _aux_chapter.Subtitle : ""%>
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
<!-- head -->
			<tr>
				<td colspan="4" bgcolor="#99CCFF">
					<table cellpadding="5" cellspacing="5" width="100%" class="menu" border="0">
						<tr>
							<td align="left">
								<a href="<%=_aux_doc.ProjectURL%>">
									<%=_aux_doc.DocumentationName%></a>
								&gt;
								<a href="index.html">
									Documentation</a>
...
							</td>
							<td align="right">
								<%=_aux_doc.Version%></td>
						</tr>
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
						<%=_aux_chapter_index + 1%>.
						<%=_aux_chapter.Title%>
					</span><%
					if (_aux_chapter.Subtitle != string.Empty) {%>
						<br />
						<span class="subtitle">
							<%=_aux_chapter.Subtitle%>
						</span><%
					}%>

					<br />
				</td>
				<td width="10"></td>
			</tr>
<!-- /chapter --><%
			for (int i = 0; i < _aux_chapter.Items.ItemCollection.Count; i++) {%>
<!-- chapter:items -->
				<tr>
					<td width="10"></td>
					<td colspan="2">
						<br />

						<span class="title">
							<%=_aux_chapter_index + 1%>.<%=i + 1%>. 
							<%=_aux_chapter.Items.ItemCollection[i].Title%>
						</span>
						<br /><%
						if (_aux_chapter.Items.ItemCollection[i].SubTitle != string.Empty) {%>
							<span class="subtitle">
								<%=_aux_chapter.Items.ItemCollection[i].SubTitle%>
							</span>
							<br /><%
						}%>
					</td>
					<td width="10"></td>
				</tr>

				<tr>
					<td width="10"></td>
					<td width="20"></td>
					<td>
						<br /><%
						for (int a = 0; a < _aux_chapter.Items.ItemCollection[i].Attachments.AttachmentCollection.Count; a++) {%>
							<span class="text"><%
								if (_aux_chapter.Items.ItemCollection[i].Attachments.AttachmentCollection[a].ShowTitle) {%>
								<span class="subsubtitle">
									<%=_aux_chapter.Items.ItemCollection[i].Attachments.AttachmentCollection[a].Title%>
								</span>
								<br /><%
								}
								switch (_aux_chapter.Items.ItemCollection[i].Attachments.AttachmentCollection[a].SourceContentType) {
									case XS_SourceContentTypeEnumeration.html:
										break;
									case XS_SourceContentTypeEnumeration.code:
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
								%>

								<%=_aux_chapter.Items.ItemCollection[i].Attachments.AttachmentCollection[a].Source%>
							</span>
							<br />
							<br /><%
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
				<td colspan="4">
					<table cellpadding="5" cellspacing="5" width="100%" border="0">
						<tr>
							<td align="left" valign="top">
								<a href="mailto:<%=_aux_doc.FeedbackEmailAddress%>?subject=[<%=_aux_doc.DocumentationName%>] <%=_aux_chapter_index + 1%>. <%=_aux_chapter.Title%><%=(_aux_chapter.Subtitle != string.Empty) ? " - " + _aux_chapter.Subtitle : ""%>">Send comments on this topic.</a>
								<br />
								<a href="LICENSE.FDL.txt"><%=_aux_doc.CopyrightText%></a>
							</td>
							<td align="right" valign="top"><%--
								if (_subject_next != null) {%>
									&gt; <a href="Help-<%=_subject_next.IDSubject%>.html">
										<%=_subject_next.Name%></a><%
								}--%>
							</td>
						</tr>
					</table>
				</td>
			</tr>
<!-- /bottom -->
		</table>
	</body>
</html>