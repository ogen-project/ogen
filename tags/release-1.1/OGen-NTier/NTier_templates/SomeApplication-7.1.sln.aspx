<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

//OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table;
//OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table;
//
//OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
//OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;
//
//string[] _aux_configmodes = _aux_ex_metadata.DBs.ConfigModes();

#endregion
//-----------------------------------------------------------------------------------------
%>Microsoft Visual Studio Solution File, Format Version 8.00
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_datalayer-7.1", "<%=_aux_ex_metadata.ApplicationName%>_datalayer\<%=_aux_ex_metadata.ApplicationName%>_datalayer-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDatalayer%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy-7.1", "<%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy\<%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_datalayer_UTs-7.1", "<%=_aux_ex_metadata.ApplicationName%>_datalayer_UTs\<%=_aux_ex_metadata.ApplicationName%>_datalayer_UTs-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_businesslayer-7.1", "<%=_aux_ex_metadata.ApplicationName%>_businesslayer\<%=_aux_ex_metadata.ApplicationName%>_businesslayer-7.1.csproj", "{<%=_aux_ex_metadata.GUIDBusinesslayer%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy-7.1", "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy\<%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy-7.1.csproj", "{<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_UTs-7.1", "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_UTs\<%=_aux_ex_metadata.ApplicationName%>_businesslayer_UTs-7.1.csproj", "{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_remoting_client-7.1", "<%=_aux_ex_metadata.ApplicationName%>_remoting_client\<%=_aux_ex_metadata.ApplicationName%>_remoting_client-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_remoting_server-7.1", "<%=_aux_ex_metadata.ApplicationName%>_remoting_server\<%=_aux_ex_metadata.ApplicationName%>_remoting_server-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_server%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_webservices_client-7.1", "<%=_aux_ex_metadata.ApplicationName%>_webservices_client\<%=_aux_ex_metadata.ApplicationName%>_webservices_client-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_client%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_webservices_server-7.1", "<%=_aux_ex_metadata.ApplicationName%>_webservices_server\<%=_aux_ex_metadata.ApplicationName%>_webservices_server-7.1.csproj", "{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_server%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_test-7.1", "<%=_aux_ex_metadata.ApplicationName%>_test\<%=_aux_ex_metadata.ApplicationName%>_test-7.1.csproj", "{<%=_aux_ex_metadata.GUIDTest%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Global
	GlobalSection(SolutionConfiguration) = preSolution
		Debug = Debug
		Release = Release
	EndGlobalSection
	GlobalSection(ProjectConfiguration) = postSolution
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_server%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_server%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_server%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_server%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_client%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_client%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_client%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_client%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_server%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_server%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_server%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_server%>}.Release.Build.0 = Release|.NET
		{<%=_aux_ex_metadata.GUIDTest%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_ex_metadata.GUIDTest%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_ex_metadata.GUIDTest%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_ex_metadata.GUIDTest%>}.Release.Build.0 = Release|.NET
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
	EndGlobalSection
	GlobalSection(ExtensibilityAddIns) = postSolution
	EndGlobalSection
EndGlobal