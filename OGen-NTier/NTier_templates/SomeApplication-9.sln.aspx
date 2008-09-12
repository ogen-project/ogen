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
//string[] _aux_configmodes = _aux_metadata.ConfigModes();

#endregion
//-----------------------------------------------------------------------------------------
%>Microsoft Visual Studio Solution File, Format Version 10.00
# Visual Studio 2008
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_datalayer-9", "<%=_aux_ex_metadata.ApplicationName%>_datalayer\<%=_aux_ex_metadata.ApplicationName%>_datalayer-9.csproj", "{<%=_aux_ex_metadata.GUIDDatalayer%>}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_datalayer_UTs-9", "<%=_aux_ex_metadata.ApplicationName%>_datalayer_UTs\<%=_aux_ex_metadata.ApplicationName%>_datalayer_UTs-9.csproj", "{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_businesslayer-9", "<%=_aux_ex_metadata.ApplicationName%>_businesslayer\<%=_aux_ex_metadata.ApplicationName%>_businesslayer-9.csproj", "{<%=_aux_ex_metadata.GUIDBusinesslayer%>}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_UTs-9", "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_UTs\<%=_aux_ex_metadata.ApplicationName%>_businesslayer_UTs-9.csproj", "{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "<%=_aux_ex_metadata.ApplicationName%>_test-9", "<%=_aux_ex_metadata.ApplicationName%>_test\<%=_aux_ex_metadata.ApplicationName%>_test-9.csproj", "{<%=_aux_ex_metadata.GUIDTest%>}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer%>}.Release|Any CPU.Build.0 = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}.Release|Any CPU.Build.0 = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer%>}.Release|Any CPU.Build.0 = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>}.Release|Any CPU.Build.0 = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDTest%>}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDTest%>}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{<%=_aux_ex_metadata.GUIDTest%>}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{<%=_aux_ex_metadata.GUIDTest%>}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
