﻿<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataExtended" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataDB" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataBusiness" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

OGen.NTier.Libraries.Metadata.MetadataBusiness.XS_classType _aux_class;

XS_methodType _aux_method;
XS_parameterType _aux_parameter;
#endregion
//-----------------------------------------------------------------------------------------
if (_aux_ex_metadata.CopyrightTextLong != string.Empty) {
%><%="<%--"%>

<%=_aux_ex_metadata.CopyrightTextLong%>

<%="--%" + ">"%><%
} else if (_aux_ex_metadata.CopyrightText != string.Empty) {
%><%="<%--"%>

<%=_aux_ex_metadata.CopyrightText%>

<%="--%" + ">"%><%
}%><%="<%" + "@"%> 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="Default.aspx.cs" 
	Inherits="<%=_aux_ex_metadata.ApplicationNamespace%>.DistributedLayer.WebServices.Server.Default" <%="%" + ">"%>
<%="<!"%>DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%="<"%>html xmlns="http://www.w3.org/1999/xhtml">
	<%="<"%>head <%="runat=\"server\""%>>
		<title></title>
	<%="</"%>head>
	<body>
		<%="<"%>form id="form1" <%="runat=\"server\""%>>
			<div>

			</div>
		<%="</"%>form>
	</body>
<%="</"%>html>