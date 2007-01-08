<%--

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

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
%><Project name="<%=_aux_metadata.ApplicationName%>_test" standardNamespace="<%=_aux_metadata.Namespace%>.test" description="" newfilesearch="None" enableviewstate="True" version="1.1" projecttype="C#">
  <Contents>
    <File name=".\AssemblyInfo.cs" subtype="Code" buildaction="Compile" dependson="" data="" />
    <File name=".\app.config" subtype="Code" buildaction="Nothing" dependson="" data="" />
    <File name=".\MainClass.cs" subtype="Code" buildaction="Compile" dependson="" data="" />
  </Contents>
  <References>
    <Reference type="Project" refto="<%=_aux_metadata.ApplicationName%>_datalayer" localcopy="True" />
    <Reference type="Project" refto="<%=_aux_metadata.ApplicationName%>_businesslayer" localcopy="True" />
    <Reference type="Gac" refto="OGen.lib.datalayer, Culture=neutral, PublicKeyToken=3fdbdf93aae6f6cf" localcopy="True" />
    <Reference type="Gac" refto="OGen.NTier.lib.datalayer, Culture=neutral, PublicKeyToken=5809687291b9bca7" localcopy="True" />
    <Reference type="Gac" refto="OGen.NTier.lib.businesslayer, Culture=neutral, PublicKeyToken=f59bd33a9a7a2f84" localcopy="True" />
  </References>
  <DeploymentInformation target="" script="" strategy="File" />
  <Configuration runwithwarnings="True" name="Debug">
    <CodeGeneration runtime="MsNet" compiler="Csc" compilerversion="" warninglevel="4" nowarn="" includedebuginformation="True" optimize="False" unsafecodeallowed="False" generateoverflowchecks="True" mainclass="" target="Exe" definesymbols="" generatexmldocumentation="False" win32Icon="" noconfig="False" nostdlib="False" />
    <Execution commandlineparameters="" consolepause="True" />
    <Output directory=".\bin\Debug" assembly="<%=_aux_metadata.Namespace%>.test" executeScript="" executeBeforeBuild="" executeAfterBuild="" executeBeforeBuildArguments="" executeAfterBuildArguments="" />
  </Configuration>
  <Configurations active="Debug">
    <Configuration runwithwarnings="True" name="Debug">
      <CodeGeneration runtime="MsNet" compiler="Csc" compilerversion="" warninglevel="4" nowarn="" includedebuginformation="True" optimize="False" unsafecodeallowed="False" generateoverflowchecks="True" mainclass="" target="Exe" definesymbols="" generatexmldocumentation="False" win32Icon="" noconfig="False" nostdlib="False" />
      <Execution commandlineparameters="" consolepause="True" />
      <Output directory=".\bin\Debug" assembly="<%=_aux_metadata.Namespace%>.test" executeScript="" executeBeforeBuild="" executeAfterBuild="" executeBeforeBuildArguments="" executeAfterBuildArguments="" />
    </Configuration>
    <Configuration runwithwarnings="True" name="Release">
      <CodeGeneration runtime="MsNet" compiler="Csc" compilerversion="" warninglevel="4" nowarn="" includedebuginformation="False" optimize="True" unsafecodeallowed="False" generateoverflowchecks="False" mainclass="" target="Exe" definesymbols="" generatexmldocumentation="False" win32Icon="" noconfig="False" nostdlib="False" />
      <Execution commandlineparameters="" consolepause="True" />
      <Output directory=".\bin\Release" assembly="<%=_aux_metadata.Namespace%>.test" executeScript="" executeBeforeBuild="" executeAfterBuild="" executeBeforeBuildArguments="" executeAfterBuildArguments="" />
    </Configuration>
  </Configurations>
</Project>