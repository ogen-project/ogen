<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataBusiness" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_ClassName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ClassName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

OGen.NTier.lib.metadata.metadataBusiness.XS_classType _aux_class
	= _aux_business_metadata.Classes.ClassCollection[
		_arg_ClassName
	];

XS_methodType _aux_method;
XS_parameterType _aux_parameter;
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
}%>using System;
using System.Collections.Generic;
using System.Text;

using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.remoting.client;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.webservices.client;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.instances {
	public class <%=_aux_class.Name%> {
		private <%=_aux_class.Name%>() { }

		static <%=_aux_class.Name%>() {
		}

		public static readonly IBO_<%=_aux_class.Name%> BusinessObject = new BO_<%=_aux_class.Name%>();
		public static readonly IBO_<%=_aux_class.Name%> RemotingClient = new RC_<%=_aux_class.Name%>();
		public static readonly IBO_<%=_aux_class.Name%> WebserviceClient = new WC_<%=_aux_class.Name%>();
	}
}