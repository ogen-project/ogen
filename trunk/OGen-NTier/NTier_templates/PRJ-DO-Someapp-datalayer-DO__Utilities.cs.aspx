<%--

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
#endregion
//-----------------------------------------------------------------------------------------
if (_aux_ex_metadata.CopyrightText != string.Empty) {
	if (_aux_ex_metadata.CopyrightTextLong == string.Empty) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
#endregion
<%
	} else {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
	}
}%>
namespace <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.DataLayer {
	using System;

	using OGen.Libraries.DataLayer;<%
	for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {
		string _dbservertype = _aux_ex_metadata.DBs.DBCollection[d].DBServerType.ToString();%>
	#if <%=_dbservertype%>
	using OGen.Libraries.DataLayer.<%=_dbservertype%>;
	#endif
	<%
	}%>
	using OGen.NTier.Libraries.DataLayer;

	/// <summary>
	/// Utilities DataObject which works as a repository of useful Properties and Methods for DataObjects at <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.DataLayer namespace.
	/// </summary>
	public sealed 
#if USE_PARTIAL_CLASSES && !NET_1_1
		partial 
#endif
		class DO__Utilities 
#if !USE_PARTIAL_CLASSES || NET_1_1
		: DO0__Utilities
#endif
	{

		// add your code here!

	}
}