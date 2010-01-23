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
bool _arg_gac = bool.Parse(System.Web.HttpUtility.UrlDecode(Request.QueryString["GAC"]));
string _arg_ogenpath = System.Web.HttpUtility.UrlDecode(Request.QueryString["OGenPath"]);

bool _arg_businessobject;
if (!bool.TryParse(
	System.Web.HttpUtility.UrlDecode(Request.QueryString["BusinessObject"]),
	out _arg_businessobject
)) {
	_arg_businessobject = false;
}
bool _arg_remotingclient;
if (!bool.TryParse(
	System.Web.HttpUtility.UrlDecode(Request.QueryString["RemotingClient"]),
	out _arg_remotingclient
)) {
	_arg_remotingclient = false;
}
bool _arg_webservicesclient;
if (!bool.TryParse(
	System.Web.HttpUtility.UrlDecode(Request.QueryString["WebservicesClient"]),
	out _arg_webservicesclient
)) {
	_arg_webservicesclient = false;
}
if (!_arg_businessobject && !_arg_remotingclient && !_arg_webservicesclient) {
	_arg_businessobject = true;
	_arg_remotingclient = true;
	_arg_webservicesclient = true;
}
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

OGen.NTier.lib.metadata.metadataBusiness.XS_classType _aux_class;

//string _aux_path = _arg_ogenpath + @"\..\..";
string _aux_no_gac = (_arg_gac) ? "" : "-no-gac";
#endregion
//-----------------------------------------------------------------------------------------
%><?xml version="1.0" encoding="utf-8" ?><%
if (_aux_ex_metadata.CopyrightTextLong != string.Empty) {%>
<!--

<%=_aux_ex_metadata.CopyrightTextLong%>

--><%
} else if (_aux_ex_metadata.CopyrightText != string.Empty) {%>
<!--

<%=_aux_ex_metadata.CopyrightText%>

--><%
}%>
<Project ToolsVersion="3.5" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>9.0.30729</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{<%=_aux_ex_metadata.GUID_businesslayer_instances%>}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace><%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.instances</RootNamespace>
    <AssemblyName><%=_aux_ex_metadata.ApplicationNamespace%>.lib.businesslayer.shared.instances-2.0</AssemblyName>
    <TargetFrameworkVersion>v2.0</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>TRACE;DEBUG;NET_2_0;BUSINESSOBJECT;REMOTINGCLIENT;WEBSERVICESCLIENT</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE;NET_2_0;BUSINESSOBJECT;REMOTINGCLIENT;WEBSERVICESCLIENT</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Web.Services" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="_base\-Config0.cs" /><%
for (int i = 0; i < _aux_business_metadata.Classes.ClassCollection.Count; i++) {
	_aux_class = _aux_business_metadata.Classes.ClassCollection[i];%>
    <Compile Include="_base\<%=_aux_class.Name%>0.cs" /><%
}%>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>-businesslayer\<%=_aux_ex_metadata.ApplicationName%>-businesslayer-9<%=_aux_no_gac%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUID_businesslayer%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>-businesslayer</Name>
    </ProjectReference>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>-businesslayer-shared\<%=_aux_ex_metadata.ApplicationName%>-businesslayer-shared-9<%=_aux_no_gac%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUID_businesslayer_shared%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>-businesslayer-shared</Name>
    </ProjectReference>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>-remoting-client\<%=_aux_ex_metadata.ApplicationName%>-remoting-client-9<%=_aux_no_gac%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUID_remoting_client%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>-remoting_client</Name>
    </ProjectReference>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>-webservices-client\<%=_aux_ex_metadata.ApplicationName%>-webservices-client-9<%=_aux_no_gac%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUID_webservices_client%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>-webservices-client</Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>