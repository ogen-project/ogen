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

cDBMetadata_Table _aux_table;
cDBMetadata_Table_Field _aux_field;
int _aux_table_hasidentitykey;
//string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><VisualStudioProject>
    <CSHARP
        ProjectType = "Local"
        ProductVersion = "7.10.3077"
        SchemaVersion = "2.0"
        ProjectGuid = "{<%=_aux_metadata.GUIDDatalayer_UTs%>}"
    >
        <Build>
            <Settings
                ApplicationIcon = ""
                AssemblyKeyContainerName = ""
                AssemblyName = "<%=_aux_metadata.Namespace%>.lib.datalayer.UTs-1.1"
                AssemblyOriginatorKeyFile = ""
                DefaultClientScript = "JScript"
                DefaultHTMLPageLayout = "Grid"
                DefaultTargetSchema = "IE50"
                DelaySign = "false"
                OutputType = "Library"
                PreBuildEvent = ""
                PostBuildEvent = ""
                RootNamespace = "<%=_aux_metadata.Namespace%>.lib.datalayer.UTs"
                RunPostBuildEvent = "OnBuildSuccess"
                StartupObject = ""
            >
                <Config
                    Name = "Debug"
                    AllowUnsafeBlocks = "false"
                    BaseAddress = "285212672"
                    CheckForOverflowUnderflow = "false"
                    ConfigurationOverrideFile = ""
                    DefineConstants = "DEBUG;TRACE;NET_1_1"
                    DocumentationFile = ""
                    DebugSymbols = "true"
                    FileAlignment = "4096"
                    IncrementalBuild = "false"
                    NoStdLib = "false"
                    NoWarn = ""
                    Optimize = "false"
                    OutputPath = "bin\Debug\"
                    RegisterForComInterop = "false"
                    RemoveIntegerChecks = "false"
                    TreatWarningsAsErrors = "false"
                    WarningLevel = "4"
                />
                <Config
                    Name = "Release"
                    AllowUnsafeBlocks = "false"
                    BaseAddress = "285212672"
                    CheckForOverflowUnderflow = "false"
                    ConfigurationOverrideFile = ""
                    DefineConstants = "TRACE;NET_1_1"
                    DocumentationFile = ""
                    DebugSymbols = "false"
                    FileAlignment = "4096"
                    IncrementalBuild = "false"
                    NoStdLib = "false"
                    NoWarn = ""
                    Optimize = "true"
                    OutputPath = "bin\Release\"
                    RegisterForComInterop = "false"
                    RemoveIntegerChecks = "false"
                    TreatWarningsAsErrors = "false"
                    WarningLevel = "4"
                />
            </Settings>
            <References>
                <Reference
                    Name = "System"
                    AssemblyName = "System"
                    HintPath = "C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\System.dll"
                />
                <Reference
                    Name = "System.Data"
                    AssemblyName = "System.Data"
                    HintPath = "C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\System.Data.dll"
                />
                <Reference
                    Name = "System.XML"
                    AssemblyName = "System.Xml"
                    HintPath = "C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\System.XML.dll"
                />
                <Reference
                    Name = "nunit.framework"
                    AssemblyName = "nunit.framework"
                    HintPath = "C:\Program Files\NUnit 2.2\bin\nunit.framework.dll"
                    AssemblyFolderKey = "hklm\dn\nunit.framework"
                />
                <Reference
                    Name = "OGen.lib.datalayer-1.1"
                    AssemblyName = "OGen.lib.datalayer-1.1"
                    AssemblyFolderKey = "hklm\dn\ogen"
                /><%
                for (int d = 0; d < _aux_metadata.DBs.Count; d++) {%>
                <Reference
                    Name = "OGen.lib.datalayer.<%=_aux_metadata.DBs[d].DBServerType.ToString()%>-1.1"
                    AssemblyName = "OGen.lib.datalayer.<%=_aux_metadata.DBs[d].DBServerType.ToString()%>-1.1"
                    AssemblyFolderKey = "hklm\dn\ogen"
                /><%
                }%>
                <Reference
                    Name = "OGen.NTier.lib.datalayer-1.1"
                    AssemblyName = "OGen.NTier.lib.datalayer-1.1"
                    AssemblyFolderKey = "hklm\dn\ogen"
                />
                <Reference
                    Name = "<%=_aux_metadata.ApplicationName%>_datalayer-1.1"
                    Project = "{<%=_aux_metadata.GUIDDatalayer%>}"
                    Package = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
                />
            </References>
        </Build>
        <Files>
            <Include>
                <File
                    RelPath = "app.config"
                    BuildAction = "None"
                />
                <File
                    RelPath = "AssemblyInfo.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                />
                <File
                    RelPath = "_base\UT0__utils.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                /><%
                for (int t = 0; t < _aux_metadata.Tables.Count; t++) {
					_aux_table = _aux_metadata.Tables[t];%>
                <File
                    RelPath = "UT_<%=_aux_table.Name%>.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                />
                <File
                    RelPath = "_base\UT0_<%=_aux_table.Name%>.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                /><%
                }%>
            </Include>
        </Files>
    </CSHARP>
</VisualStudioProject>
