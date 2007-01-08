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

string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><configuration>
	<appSettings>
		<add key="applications" value="<%=_aux_metadata.ApplicationName%>" />

		<add key="<%=_aux_metadata.ApplicationName%>:ConfigModes" value="<%
		for (int _cm = 0; _cm < _aux_configmodes.Length; _cm++) {
			%><%=_aux_configmodes[_cm]%><%=(_cm == _aux_configmodes.Length - 1) ? "" : ":"%><%
		}%>" />
		<add key="<%=_aux_metadata.ApplicationName%>:DBServerTypes" value="<%
		for (int _db = 0; _db < _aux_metadata.DBs.Count; _db++) {
			%><%=_aux_metadata.DBs[_db].DBServerType.ToString()%><%=(_db == _aux_metadata.DBs.Count - 1) ? "" : ":"%><%
		}%>" />

		<!-- IsDefault::GeneratedSQL::IsIndexed_andReadOnly::Connectionstring --><%
		//<add key="OGen-NTier_UTs:DBServerType_default" value="< %=_aux_metadata.DBs.FirstDefaultAvailable_DBServerType().ToString()% >" />
		for (int d = 0; d < _aux_metadata.DBs.Count; d++) {
			for (int c = 0; c < _aux_metadata.DBs[d].Connections.Count; c++) {%>
		<add key="<%=_aux_metadata.ApplicationName%>:DBConnection:<%=_aux_metadata.DBs[d].Connections[c].ConfigMode%>:<%=_aux_metadata.DBs[d].DBServerType.ToString()%>" value="<%=_aux_metadata.DBs[d].Connections[c].isDefault%>::<%=_aux_metadata.DBs[d].Connections[c].GenerateSQL%>::<%=_aux_metadata.DBs[d].Connections[c].isIndexed_andReadOnly%>::<%=_aux_metadata.DBs[d].Connections[c].Connectionstring%>"/><%
			}
		}%>

		<add key="Some_UT_config" value="tweak it here" />
	</appSettings>
</configuration><%
//-----------------------------------------------------------------------------------------
%>