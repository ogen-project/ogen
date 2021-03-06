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
string _arg_where = System.Web.HttpUtility.UrlDecode(Request.QueryString["where"]);
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

string _aux_assemblytitle = "";
string _aux_assemblyproduct = "";
string _aux_guid = "";
string _aux_assemblycompany = "";

switch (_arg_where) {
	case "datalayer":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.DataLayer", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_datalayer;
		break;
	case "datalayer-structures":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.DataLayer.Shared.Structures", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_datalayer_structures;
		break;
	case "businesslayer":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.BusinessLayer", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_businesslayer;
		break;
	case "businesslayer-structures":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.BusinessLayer.Shared.Structures", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_businesslayer_structures;
		break;
	case "businesslayer-shared":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.BusinessLayer.Shared", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_businesslayer_shared;
		break;
	case "businesslayer-instances":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.BusinessLayer.Shared.Instances", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_businesslayer_instances;
		break;
	case "remoting-server":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.DistributedLayer.Remoting.Server", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_remoting_server;
		break;
	case "remoting-simpleserver":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.DistributedLayer.Remoting.SimpleServer", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_remoting_simpleserver;
		break;
	case "remoting-client":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.DistributedLayer.Remoting.Client", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_remoting_client;
		break;
	case "webservices-server":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.DistributedLayer.WebServices.Server", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_webservices_server;
		break;
	case "webservices-client":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.Libraries.DistributedLayer.WebServices.Client", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_webservices_client;
		break;
	case "test":
		_aux_assemblytitle = string.Format(
			System.Globalization.CultureInfo.CurrentCulture, 
			"{0}.PresentationLayer.ConsoleApplication", 
			_aux_ex_metadata.ApplicationNamespace
		);
		_aux_guid = _aux_ex_metadata.GUID_test;
		break;
}
_aux_assemblyproduct = _aux_ex_metadata.ApplicationName;
_aux_assemblycompany = _aux_ex_metadata.ApplicationNamespace.Split('.')[0];
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
}%>using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("<%=_aux_assemblytitle%>")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("<%=_aux_assemblycompany%>")]
[assembly: AssemblyProduct("<%=_aux_assemblyproduct%>")]
[assembly: AssemblyCopyright("<%=_aux_ex_metadata.CopyrightText%>")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
//[assembly: Guid("<%=_aux_guid%>")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

[assembly: System.CLSCompliant(true)]