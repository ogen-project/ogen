<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataBusiness" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_projectVersion = System.Web.HttpUtility.UrlDecode(Request.QueryString["projectVersion"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];
XS__metadataBusiness _aux_business_metadata = _aux_root_metadata.MetadataBusinessCollection[0];

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table;
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

OGen.NTier.lib.metadata.metadataBusiness.XS_classType _aux_class;

//string[] _aux_configmodes = _aux_ex_metadata.DBs.ConfigModes();

#endregion
//-----------------------------------------------------------------------------------------
%><Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003"<%=(_arg_projectVersion == "9") ? " ToolsVersion=\"3.5\"" : ""%>>
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProductVersion>8.0.50727</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{<%=_aux_ex_metadata.GUIDBusiness_client%>}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace><%=_aux_ex_metadata.ApplicationNamespace%>.lib.business.client</RootNamespace>
    <AssemblyName><%=_aux_ex_metadata.ApplicationNamespace%>.lib.business.client-2.0</AssemblyName>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>TRACE;DEBUG;NET_2_0</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <DocumentationFile>bin\Debug\<%=_aux_ex_metadata.ApplicationNamespace%>.lib.business.client-2.0.xml</DocumentationFile>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE;NET_2_0</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
    <DocumentationFile>bin\Debug\<%=_aux_ex_metadata.ApplicationNamespace%>.lib.business.client-2.0.xml</DocumentationFile>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="System.Data" />
    <Reference Include="System.Xml" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="utils.cs">
      <SubType>Code</SubType>
    </Compile><%
    for (int c = 0; c < _aux_business_metadata.Classes.ClassCollection.Count; c++) {
        _aux_class = _aux_business_metadata.Classes.ClassCollection[c];%>
    <Compile Include="BC_<%=_aux_class.Name%>.cs">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="_base\BC0_<%=_aux_class.Name%>.cs">
      <SubType>Code</SubType>
    </Compile><%
    }%>
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>_businesslayer\<%=_aux_ex_metadata.ApplicationName%>_businesslayer-<%=_arg_projectVersion%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUIDBusinesslayer%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>_businesslayer-<%=_arg_projectVersion%></Name>
    </ProjectReference>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy\<%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy-<%=_arg_projectVersion%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy-<%=_arg_projectVersion%></Name>
    </ProjectReference>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy\<%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy-<%=_arg_projectVersion%>.csproj">
      <Project>{<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>}</Project>
      <Name><%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy-<%=_arg_projectVersion%></Name>
    </ProjectReference>
  </ItemGroup>
  <Import Project="$(MSBuildBinPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>
