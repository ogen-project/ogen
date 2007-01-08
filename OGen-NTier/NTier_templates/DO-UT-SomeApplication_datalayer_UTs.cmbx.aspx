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
%><Combine fileversion="1.0" name="<%=_aux_metadata.ApplicationName%>_datalayer_UTs" description="">
  <StartMode startupentry="<%=_aux_metadata.ApplicationName%>_datalayer_UTs" single="True">
    <Execute entry="<%=_aux_metadata.ApplicationName%>_datalayer_UTs" type="None" />
  </StartMode>
  <Entries>
    <Entry filename=".\<%=_aux_metadata.ApplicationName%>_datalayer_UTs.prjx" />
  </Entries>
  <Configurations active="Debug">
    <Configuration name="Release">
      <Entry name="<%=_aux_metadata.ApplicationName%>_datalayer_UTs" configurationname="Debug" build="False" />
    </Configuration>
    <Configuration name="Debug">
      <Entry name="<%=_aux_metadata.ApplicationName%>_datalayer_UTs" configurationname="Debug" build="False" />
    </Configuration>
  </Configurations>
</Combine>