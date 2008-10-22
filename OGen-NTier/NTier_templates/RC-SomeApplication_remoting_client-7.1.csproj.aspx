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
%><VisualStudioProject>
    <CSHARP
        ProjectType = "Local"
        ProductVersion = "7.10.3077"
        SchemaVersion = "2.0"
        ProjectGuid = "{<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>}"
    >
        <Build>
            <Settings
                ApplicationIcon = ""
                AssemblyKeyContainerName = ""
                AssemblyName = "<%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.remoting.client-1.1"
                AssemblyOriginatorKeyFile = ""
                DefaultClientScript = "JScript"
                DefaultHTMLPageLayout = "Grid"
                DefaultTargetSchema = "IE50"
                DelaySign = "false"
                OutputType = "Library"
                PreBuildEvent = ""
                PostBuildEvent = ""
                RootNamespace = "<%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.remoting.client"
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
                    DocumentationFile = "bin\Debug\<%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.remoting.client-1.1.xml"
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
                    DocumentationFile = "bin\Debug\<%=_aux_ex_metadata.ApplicationNamespace%>.lib.distributedlayer.remoting.client-1.1.xml"
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
                    AssemblyName = "System.XML"
                    HintPath = "C:\WINDOWS\Microsoft.NET\Framework\v1.1.4322\System.XML.dll"
                />
                <Reference
                    Name = "<%=_aux_ex_metadata.ApplicationName%>_datalayer_proxy-1.1"
                    Project = "{<%=_aux_ex_metadata.GUIDDatalayer_proxy%>}"
                    Package = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
                />
                <Reference
                    Name = "<%=_aux_ex_metadata.ApplicationName%>_businesslayer_proxy-1.1"
                    Project = "{<%=_aux_ex_metadata.GUIDBusinessyer_proxy%>}"
                    Package = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"
                />
            </References>
        </Build>
        <Files>
            <Include>
                <File
                    RelPath = "AssemblyInfo.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                /><%
				for (int c = 0; c < _aux_business_metadata.Classes.ClassCollection.Count; c++) {
					_aux_class = _aux_business_metadata.Classes.ClassCollection[c];%>
                <File
                    RelPath = "RC_<%=_aux_class.Name%>.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                />
                <File
                    RelPath = "_base\RC0_<%=_aux_class.Name%>.cs"
                    SubType = "Code"
                    BuildAction = "Compile"
                /><%
                }%>
            </Include>
        </Files>
    </CSHARP>
</VisualStudioProject>