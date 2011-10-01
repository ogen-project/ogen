<%/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/%><%@ Page language="c#" contenttype="text/html" %>
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
	</appSettings>
</configuration><%
//-----------------------------------------------------------------------------------------
%>