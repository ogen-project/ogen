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
string _arg_ClassName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ClassName"]);
bool _arg_Client = bool.Parse(System.Web.HttpUtility.UrlDecode(Request.QueryString["Client"]));
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

OGen.NTier.Libraries.Metadata.MetadataBusiness.XS_classType _aux_class
	= _aux_business_metadata.Classes.ClassCollection[
		_arg_ClassName
	];

XS_methodType _aux_method;
XS_parameterType _aux_parameter;
#endregion
//-----------------------------------------------------------------------------------------
if (!string.IsNullOrEmpty(_aux_ex_metadata.CopyrightText)) {
	if (string.IsNullOrEmpty(_aux_ex_metadata.CopyrightTextLong)) {
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
namespace <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.DistributedLayer.Remoting.Server {
	using System;
<%
	if (!_arg_Client) {%>
	using <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.BusinessLayer;<%
	}%>
	using <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.BusinessLayer.Shared;
	using <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.BusinessLayer.Shared.Structures;
	using <%=_aux_ex_metadata.ApplicationNamespace%>.Libraries.DataLayer.Shared.Structures;

	/// <summary>
	/// <%=_aux_class.Name%> remoting server.
	/// </summary>
	public class RS_<%=_aux_class.Name%> : 
		MarshalByRefObject, 
		IBO_<%=_aux_class.Name%> 
	{<%
		for (int m = 0; m < _aux_class.Methods.MethodCollection.Count; m++) {
			_aux_method = _aux_class.Methods.MethodCollection[m];%>
		#region public <%=_aux_method.OutputType%> <%=_aux_method.Name%>(...);
		public <%=_aux_method.OutputType%> <%=_aux_method.Name%>(<%
			for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
				_aux_parameter = _aux_method.Parameters.ParameterCollection[p];%><%=""%>
			<%=_aux_parameter.IsOut ? "out " : ""%><%=_aux_parameter.IsRef ? "ref " : ""%><%=_aux_parameter.IsParams ? "params " : ""%><%=_aux_parameter.Type%><%=_aux_parameter.IsParams ? "[]" : ""%> <%=_aux_parameter.Name%><%=(p == _aux_method.Parameters.ParameterCollection.Count - 1) ? "" : ", "%><%
			}%>
		) {<%
			if (_arg_Client) {%><%=""%>
			throw new Exception("your not calling the remoting server, but the client's remoting server implementation");<%
			} else {%><%=""%>
			<%=(_aux_method.OutputType == "void") ? "" : "return "%><%=_aux_class.Namespace%>.SBO_<%=_aux_class.Name%>.<%=_aux_method.Name%>(<%
				for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
					_aux_parameter = _aux_method.Parameters.ParameterCollection[p];
					if (_aux_method.IPParamNum == p) {%><%=""%>
				<%=_aux_parameter.IsOut ? "out " : ""%><%=_aux_parameter.IsRef ? "ref " : ""%><%=_aux_parameter.IsParams ? "params " : ""%>(Utilities.ResetClientIP)
					? (string)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")
					: <%=_aux_parameter.Name%><%=(p == _aux_method.Parameters.ParameterCollection.Count - 1) ? "" : ", "%><%
					} else {%><%=""%>
				<%=_aux_parameter.IsOut ? "out " : ""%><%=_aux_parameter.IsRef ? "ref " : ""%><%=_aux_parameter.IsParams ? "params " : ""%><%=_aux_parameter.Name%><%=(p == _aux_method.Parameters.ParameterCollection.Count - 1) ? "" : ", "%><%
					}
				}%>
			);<%
			}%>
		}
		#endregion<%
		}%>
	}
}<%
//-----------------------------------------------------------------------------------------
%>