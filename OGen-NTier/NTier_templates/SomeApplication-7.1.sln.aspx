<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
cDBMetadata _aux_metadata;
if (cDBMetadata.Metacache.Contains(_arg_MetadataFilepath)) {
	_aux_metadata = (cDBMetadata)cDBMetadata.Metacache[_arg_MetadataFilepath];
} else {
	_aux_metadata = new cDBMetadata();
	_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);
	cDBMetadata.Metacache.Add(_arg_MetadataFilepath, _aux_metadata);
}

//cDBMetadata_Table _aux_table;
//cDBMetadata_Table_Field _aux_field;
//int _aux_table_hasidentitykey;
//string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%>Microsoft Visual Studio Solution File, Format Version 8.00
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_metadata.ApplicationName%>_datalayer", "<%=_aux_metadata.ApplicationName%>_datalayer\<%=_aux_metadata.ApplicationName%>_datalayer-7.1.csproj", "{<%=_aux_metadata.GUIDDatalayer%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_metadata.ApplicationName%>_datalayer_UTs", "<%=_aux_metadata.ApplicationName%>_datalayer_UTs\<%=_aux_metadata.ApplicationName%>_datalayer_UTs-7.1.csproj", "{<%=_aux_metadata.GUIDDatalayer_UTs%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_metadata.ApplicationName%>_businesslayer", "<%=_aux_metadata.ApplicationName%>_businesslayer\<%=_aux_metadata.ApplicationName%>_businesslayer-7.1.csproj", "{<%=_aux_metadata.GUIDBusinesslayer%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_metadata.ApplicationName%>_businesslayer_UTs", "<%=_aux_metadata.ApplicationName%>_businesslayer_UTs\<%=_aux_metadata.ApplicationName%>_businesslayer_UTs-7.1.csproj", "{<%=_aux_metadata.GUIDBusinesslayer_UTs%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_metadata.ApplicationName%>_test", "<%=_aux_metadata.ApplicationName%>_test\<%=_aux_metadata.ApplicationName%>_test-7.1.csproj", "{<%=_aux_metadata.GUIDTest%>}"
	ProjectSection(ProjectDependencies) = postProject
	EndProjectSection
EndProject
Global
	GlobalSection(SolutionConfiguration) = preSolution
		Debug = Debug
		Release = Release
	EndGlobalSection
	GlobalSection(ProjectConfiguration) = postSolution
		{<%=_aux_metadata.GUIDDatalayer%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_metadata.GUIDDatalayer%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_metadata.GUIDDatalayer%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_metadata.GUIDDatalayer%>}.Release.Build.0 = Release|.NET
		{<%=_aux_metadata.GUIDDatalayer_UTs%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_metadata.GUIDDatalayer_UTs%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_metadata.GUIDDatalayer_UTs%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_metadata.GUIDDatalayer_UTs%>}.Release.Build.0 = Release|.NET
		{<%=_aux_metadata.GUIDBusinesslayer%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_metadata.GUIDBusinesslayer%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_metadata.GUIDBusinesslayer%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_metadata.GUIDBusinesslayer%>}.Release.Build.0 = Release|.NET
		{<%=_aux_metadata.GUIDBusinesslayer_UTs%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_metadata.GUIDBusinesslayer_UTs%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_metadata.GUIDBusinesslayer_UTs%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_metadata.GUIDBusinesslayer_UTs%>}.Release.Build.0 = Release|.NET
		{<%=_aux_metadata.GUIDTest%>}.Debug.ActiveCfg = Debug|.NET
		{<%=_aux_metadata.GUIDTest%>}.Debug.Build.0 = Debug|.NET
		{<%=_aux_metadata.GUIDTest%>}.Release.ActiveCfg = Release|.NET
		{<%=_aux_metadata.GUIDTest%>}.Release.Build.0 = Release|.NET
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
	EndGlobalSection
	GlobalSection(ExtensibilityAddIns) = postSolution
	EndGlobalSection
EndGlobal
