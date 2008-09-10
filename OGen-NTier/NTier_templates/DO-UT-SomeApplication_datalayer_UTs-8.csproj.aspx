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

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table;
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

//string[] _aux_configmodes = _aux_ex_metadata.DBs.ConfigModes();

#endregion
//-----------------------------------------------------------------------------------------
%><Project DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <ProjectType>Local</ProjectType>
    <ProductVersion>8.0.50727</ProductVersion>
    <SchemaVersion>2.0</SchemaVersion>
    <ProjectGuid>{<%=_aux_ex_metadata.GUIDDatalayer_UTs%>}</ProjectGuid>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ApplicationIcon>
    </ApplicationIcon>
    <AssemblyKeyContainerName>
    </AssemblyKeyContainerName>
    <AssemblyName><%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.UTs-2.0</AssemblyName>
    <AssemblyOriginatorKeyFile>
    </AssemblyOriginatorKeyFile>
    <DefaultClientScript>JScript</DefaultClientScript>
    <DefaultHTMLPageLayout>Grid</DefaultHTMLPageLayout>
    <DefaultTargetSchema>IE50</DefaultTargetSchema>
    <DelaySign>false</DelaySign>
    <OutputType>Library</OutputType>
    <RootNamespace><%=_aux_ex_metadata.ApplicationNamespace%>.lib.datalayer.UTs</RootNamespace>
    <RunPostBuildEvent>OnBuildSuccess</RunPostBuildEvent>
    <StartupObject>
    </StartupObject>
    <FileUpgradeFlags>
    </FileUpgradeFlags>
    <UpgradeBackupLocation>
    </UpgradeBackupLocation>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <OutputPath>bin\Debug\</OutputPath>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
    <BaseAddress>285212672</BaseAddress>
    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
    <ConfigurationOverrideFile>
    </ConfigurationOverrideFile>
    <DefineConstants>TRACE;DEBUG;NET_2_0</DefineConstants>
    <DocumentationFile>
    </DocumentationFile>
    <DebugSymbols>true</DebugSymbols>
    <FileAlignment>4096</FileAlignment>
    <NoStdLib>false</NoStdLib>
    <NoWarn>
    </NoWarn>
    <Optimize>false</Optimize>
    <RegisterForComInterop>false</RegisterForComInterop>
    <RemoveIntegerChecks>false</RemoveIntegerChecks>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <WarningLevel>4</WarningLevel>
    <DebugType>full</DebugType>
    <ErrorReport>prompt</ErrorReport>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <OutputPath>bin\Release\</OutputPath>
    <AllowUnsafeBlocks>false</AllowUnsafeBlocks>
    <BaseAddress>285212672</BaseAddress>
    <CheckForOverflowUnderflow>false</CheckForOverflowUnderflow>
    <ConfigurationOverrideFile>
    </ConfigurationOverrideFile>
    <DefineConstants>TRACE;NET_2_0</DefineConstants>
    <DocumentationFile>
    </DocumentationFile>
    <DebugSymbols>false</DebugSymbols>
    <FileAlignment>4096</FileAlignment>
    <NoStdLib>false</NoStdLib>
    <NoWarn>
    </NoWarn>
    <Optimize>true</Optimize>
    <RegisterForComInterop>false</RegisterForComInterop>
    <RemoveIntegerChecks>false</RemoveIntegerChecks>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
    <WarningLevel>4</WarningLevel>
    <DebugType>none</DebugType>
    <ErrorReport>prompt</ErrorReport>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="nunit.framework">
      <Name>nunit.framework</Name>
      <HintPath>C:\Program Files\NUnit 2.2\bin\nunit.framework.dll</HintPath>
      <AssemblyFolderKey>hklm\dn\nunit.framework</AssemblyFolderKey>
    </Reference>
    <Reference Include="OGen.lib.datalayer-2.0">
      <Name>OGen.lib.datalayer-2.0</Name>
      <AssemblyFolderKey>hklm\dn\ogen</AssemblyFolderKey>
    </Reference><%
    for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {%>
    <Reference Include="OGen.lib.datalayer.<%=_aux_ex_metadata.DBs.DBCollection[d].DBServerType.ToString()%>-2.0">
      <Name>OGen.lib.datalayer.<%=_aux_ex_metadata.DBs.DBCollection[d].DBServerType.ToString()%>-2.0</Name>
      <AssemblyFolderKey>hklm\dn\ogen</AssemblyFolderKey>
    </Reference><%
    }%>
    <Reference Include="OGen.NTier.lib.datalayer-2.0">
      <Name>OGen.NTier.lib.datalayer-2.0</Name>
      <AssemblyFolderKey>hklm\dn\ogen</AssemblyFolderKey>
    </Reference>
    <Reference Include="System">
      <Name>System</Name>
    </Reference>
    <Reference Include="System.Data">
      <Name>System.Data</Name>
    </Reference>
    <Reference Include="System.Xml">
      <Name>System.XML</Name>
    </Reference>
    <ProjectReference Include="..\<%=_aux_ex_metadata.ApplicationName%>_datalayer\<%=_aux_ex_metadata.ApplicationName%>_datalayer-8.csproj">
      <Name><%=_aux_ex_metadata.ApplicationName%>_datalayer</Name>
      <Project>{<%=_aux_ex_metadata.GUIDDatalayer%>}</Project>
      <Package>{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</Package>
    </ProjectReference>
  </ItemGroup>
  <ItemGroup>
    <None Include="app.config" />
    <Compile Include="AssemblyInfo.cs">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="_base\UT0__utils.cs">
      <SubType>Code</SubType>
    </Compile><%
		for (int t = 0; t < _aux_db_metadata.Tables.TableCollection.Count; t++) {
			_aux_db_table = _aux_db_metadata.Tables.TableCollection[t];%>
    <Compile Include="UT_<%=_aux_db_table.Name%>.cs">
      <SubType>Code</SubType>
    </Compile>
    <Compile Include="_base\UT0_<%=_aux_db_table.Name%>.cs">
      <SubType>Code</SubType>
    </Compile><%
		}%>
  </ItemGroup>
  <Import Project="$(MSBuildBinPath)\Microsoft.CSharp.targets" />
  <PropertyGroup>
    <PreBuildEvent>
    </PreBuildEvent>
    <PostBuildEvent>
    </PostBuildEvent>
  </PropertyGroup>
</Project>