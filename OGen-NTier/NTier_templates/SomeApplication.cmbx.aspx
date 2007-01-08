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
<%//@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
//string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
//string _arg_OGenPath = System.Web.HttpUtility.UrlDecode(Request.QueryString["OGenPath"]);
string _arg_ApplicationName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ApplicationName"]);
#endregion

#region varaux...
//cDBMetadata _aux_metadata = new cDBMetadata();
//_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);

//cDBMetadata_Table _aux_table;
//cDBMetadata_Table_Field _aux_field;
//int _aux_table_hasidentitykey;
//string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><Combine fileversion="1.0" name="<%=_arg_ApplicationName%>" description="">
  <StartMode startupentry="<%=_arg_ApplicationName%>_test" single="True">
    <Execute entry="<%=_arg_ApplicationName%>_datalayer" type="None" />
    <Execute entry="<%=_arg_ApplicationName%>_businesslayer" type="None" />
    <Execute entry="<%=_arg_ApplicationName%>_datalayer_UTs" type="None" />
    <Execute entry="<%=_arg_ApplicationName%>_businesslayer_UTs" type="None" />
    <Execute entry="<%=_arg_ApplicationName%>_test" type="None" />
  </StartMode>
  <Entries>
    <Entry filename=".\<%=_arg_ApplicationName%>_datalayer\<%=_arg_ApplicationName%>_datalayer.prjx" />
    <Entry filename=".\<%=_arg_ApplicationName%>_businesslayer\<%=_arg_ApplicationName%>_businesslayer.prjx" />
    <Entry filename=".\<%=_arg_ApplicationName%>_datalayer_UTs\<%=_arg_ApplicationName%>_datalayer_UTs.prjx" />
    <Entry filename=".\<%=_arg_ApplicationName%>_businesslayer_UTs\<%=_arg_ApplicationName%>_businesslayer_UTs.prjx" />
    <Entry filename=".\<%=_arg_ApplicationName%>_test\<%=_arg_ApplicationName%>_test.prjx" />
  </Entries>
  <Configurations active="Debug">
    <Configuration name="Release">
      <Entry name="<%=_arg_ApplicationName%>_datalayer" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_businesslayer" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_datalayer_UTs" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_businesslayer_UTs" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_test" configurationname="Debug" build="False" />
    </Configuration>
    <Configuration name="Debug">
      <Entry name="<%=_arg_ApplicationName%>_datalayer" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_businesslayer" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_datalayer_UTs" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_businesslayer_UTs" configurationname="Debug" build="False" />
      <Entry name="<%=_arg_ApplicationName%>_test" configurationname="Debug" build="False" />
    </Configuration>
  </Configurations>
</Combine>