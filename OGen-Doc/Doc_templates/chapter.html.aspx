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

XS_chapterType _chapter = _aux_doc.Chapters.ChapterCollection[_arg_ChapterTitle];
#endregion
//-----------------------------------------------------------------------------------------
%><html>
	<head>
		<title>
			<%=_aux_doc.DocumentationName%> - <%=_chapter.Title%><%=(_chapter.Subtitle != string.Empty) ? " - " + _chapter.Subtitle : ""%>
		</title>
		<link rel="stylesheet" href="_include/doc.css" type="text/css" /><%--
		<script language="JavaScript" src="_include/lib_doc.js"></script>--%>
	</head>
	<body
		bottommargin="0"
		topmargin="0"
		leftmargin="0"
		rightmargin="0">

		<table cellpadding="0" cellspacing="0" width="100%" border="0">
			<tr>
				<td colspan="3" bgcolor="#99CCFF">
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
			<tr valign="top">
				<td colspan="3" bgcolor="#000000" height="1"></td>
			</tr>


<%--
			<%
			if (_subject.IDSubject != "0") {%>
			<tr>
				<td width="10"></td>
				<td>
					<br>

					<span class="title"><%=_subject.Name%></span>
					<br>
					<span class="text"><%=_subject.Description%></span>

					<br>
				</td>
				<td width="10"></td>
			</tr><%
			}%>
			<tr>
				<td width="10"></td>
				<td>
					<br><%

					for (int d = 0; d < _subject.Documents.DocumentCollection.Count; d++) {%>
					<span class="text">
						<span class="subtitle"><%=_subject.Documents.DocumentCollection[d].Name%></span>
						<br>
						<%=utils.translate(_subject.Documents.DocumentCollection[d].Document, _aux_doc)%>
					</span>
					<br>
					<br><%
					}%>
				</td>
				<td width="10"></td>
			</tr>
			<tr>
				<td width="10"></td>
				<td><%
					if (
						(_subject.IDSubject != "0")
						&&
						(_subject.hasDescendants())
					) {%>
					<!--tr valign="top">
						<td></td>
						<td colspan="1" bgcolor="#000000" height="1"></td>
						<td></td>
					</tr-->
					<hr size="1"><%
						_isFirst = true;
					} else {
						_isFirst = false;
					}

					for (int s = 0; s < _aux_doc.Subjects.SubjectCollection.Count; s++) {
						if (_aux_doc.Subjects.SubjectCollection[s].IDSubject_parent == _subject.IDSubject) {
							if (_isFirst) {
								%><br><%
								_isFirst = false;
							}%>
					<span class="text">
						&gt; <a href="Help-<%=_aux_doc.Subjects.SubjectCollection[s].IDSubject%>.html"><%=_aux_doc.Subjects.SubjectCollection[s].Name%></a><br>
						<%=_aux_doc.Subjects.SubjectCollection[s].Description%>.<br>
					</span>
					<br><%
						}
					}%>
				</td>
				<td width="10"></td>
			</tr>
--%>





			<tr>
				<td colspan="3" bgcolor="#000000" height="1"></td>
			</tr>
			<tr>
				<td colspan="3">
					<table cellpadding="5" cellspacing="5" width="100%" border="0">
						<tr>
							<td align="left" valign="top">
								<a href="mailto:<%=_aux_doc.FeedbackEmailAddress%>?subject=[<%=_aux_doc.DocumentationName%>] <%=_chapter.Title%><%=(_chapter.Subtitle != string.Empty) ? " - " + _chapter.Subtitle : ""%>">Send comments on this topic.</a>
								<br>
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
		</table>
	</body>
</html>