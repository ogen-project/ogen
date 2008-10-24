<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
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
if ((_aux_ex_metadata.CopyrightText != string.Empty) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using OGen.NTier.lib.distributedlayer.webservices.client;
using OGen.NTier.UTs.lib.businesslayer.proxy;

using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.webservices.client;
using <%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.proxy;

namespace <%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.webservices.client.WC_<%=_aux_class.Name%> {
	/// <summary>
	/// <%=_aux_class.Name%> web service client.
	/// </summary>
	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Web.Services.WebServiceBindingAttribute(
		Name = "WS_<%=_aux_class.Name%>Soap", 
		Namespace = "http://<%=_aux_ex_metadata.ApplicationNamespace%>.distributedlayer.webservices.server"
	)]
	public abstract class WC0_<%=_aux_class.Name%> : WC__base, IBO_<%=_aux_class.Name%> {
		#region public WC0_<%=_aux_class.Name%>(...);
		public WC0_<%=_aux_class.Name%>(
			string url_in
		) : base(
			url_in
		) {
		}
		#endregion
<%
		for (int m = 0; m < _aux_class.Methods.MethodCollection.Count; m++) {
			_aux_method = _aux_class.Methods.MethodCollection[m];%>

		#region public <%=_aux_method.OutputType%> <%=_aux_method.Name%>(...);
		#if !NET_1_1
		private System.Threading.SendOrPostCallback <%=_aux_method.Name%>OperationCompleted;
		/// <remarks/>
		public event <%=_aux_method.Name%>CompletedEventHandler <%=_aux_method.Name%>Completed;
		#endif

		/// <remarks/>
		[System.Web.Services.Protocols.SoapDocumentMethodAttribute(
			"http://<%=_aux_ex_metadata.ApplicationNamespace%>.distributedlayer.webservices.server/<%=_aux_method.Name%>", 
			RequestNamespace = "http://<%=_aux_ex_metadata.ApplicationNamespace%>.distributedlayer.webservices.server", 
			ResponseNamespace = "http://<%=_aux_ex_metadata.ApplicationNamespace%>.distributedlayer.webservices.server", 
			Use = System.Web.Services.Description.SoapBindingUse.Literal, 
			ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped
		)]
		public <%=_aux_method.OutputType%> <%=_aux_method.Name%>(<%
			for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
				_aux_parameter = _aux_method.Parameters.ParameterCollection[p];%><%=""%>
			<%=_aux_parameter.isOut ? "out " : ""%><%=_aux_parameter.isRef ? "ref " : ""%><%=_aux_parameter.isParams ? "params " : ""%><%=_aux_parameter.Type%><%=_aux_parameter.isParams ? "[]" : ""%> <%=_aux_parameter.Name%><%=(p == _aux_method.Parameters.ParameterCollection.Count - 1) ? "" : ", "%><%
			}%>
		) {
			<%=(_aux_method.OutputType == "void") ? "" : "object[] results = "%>this.Invoke(
				"<%=_aux_method.Name%>", 
				new object[] {<%
					for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
						_aux_parameter = _aux_method.Parameters.ParameterCollection[p];
						if (_aux_parameter.isOut) 
							continue;%><%=(p != 0) ? "," : ""%>
					<%=_aux_parameter.Name%><%
					}%>
				}
			);<%
			int _aux_outputparameter = 0;
			for (int p = 0; p < _aux_method.Parameters.ParameterCollection.Count; p++) {
				_aux_parameter = _aux_method.Parameters.ParameterCollection[p];
				if (!_aux_parameter.isOut)
					continue;
				_aux_outputparameter++;%><%=""%>
			<%=_aux_parameter.Name%> = (<%=_aux_parameter.Type%><%=_aux_parameter.isParams ? "[]" : ""%>)results[<%=_aux_outputparameter.ToString()%>];<%
			}
			if (_aux_method.OutputType != "void") {%>

			return (<%=_aux_method.OutputType%>)results[0];<%
			}%>
		}

// ...

		#endregion<%
		}%>
	}
	#if !NET_1_1<%
for (int m = 0; m < _aux_class.Methods.MethodCollection.Count; m++) {
	_aux_method = _aux_class.Methods.MethodCollection[m];%><%=""%>
	#region ...<%=_aux_method.Name%>...
	/// <remarks/>
	public delegate void <%=_aux_method.Name%>CompletedEventHandler(
		object sender, 
		<%=(_aux_method.OutputType == "void") ? "System.ComponentModel.Async" : _aux_method.Name%>CompletedEventArgs e
	);<%
	if (_aux_method.OutputType != "void") {%>

	/// <remarks/>
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	public partial class <%=_aux_method.Name%>CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
		private object[] results;

		internal <%=_aux_method.Name%>CompletedEventArgs(
			object[] results, 
			System.Exception exception, 
			bool cancelled, 
			object userState
		) : base(
			exception, 
			cancelled, 
			userState
		) {
			this.results = results;
		}

		/// <remarks/>
		public <%=_aux_method.OutputType%> Result {
			get {
				this.RaiseExceptionIfNecessary();
				return (<%=_aux_method.OutputType%>)this.results[0];
			}
		}
	}
	#endregion<%
	}
}%>
	#endif
}<%
//-----------------------------------------------------------------------------------------
%>