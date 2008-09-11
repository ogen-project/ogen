<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%//@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
//string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_ApplicationName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ApplicationName"]);
string _arg_Namespace = System.Web.HttpUtility.UrlDecode(Request.QueryString["Namespace"]);
#endregion

#region varaux...
//cDBMetadata _aux_metadata = new cDBMetadata();
//_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);

//cDBMetadata_Table _aux_table;
//cDBMetadata_Table_Field _aux_field;
//int _aux_table_hasidentitykey;
////string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><NUnitProject>
  <Settings activeconfig="Default" />
  <Config name="Default" binpathtype="Auto">
    <assembly path="<%=_arg_ApplicationName%>_businesslayer_UTs\bin\Debug\<%=_arg_Namespace%>.lib.businesslayer.UTs-2.0.dll" />
  </Config>
</NUnitProject>