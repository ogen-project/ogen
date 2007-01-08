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
string _arg_ApplicationName = System.Web.HttpUtility.UrlDecode(Request.QueryString["ApplicationName"]);
string _arg_Namespace = System.Web.HttpUtility.UrlDecode(Request.QueryString["Namespace"]);
#endregion

#region varaux...
//cDBMetadata _aux_metadata = new cDBMetadata();
//_aux_metadata.LoadState_fromFile(_arg_MetadataFilepath);

//cDBMetadata_Table _aux_table;
//cDBMetadata_Table_Field _aux_field;
//int _aux_table_hasidentitykey;
////string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><NUnitProject>
  <Settings activeconfig="Default" />
  <Config name="Default" binpathtype="Auto">
    <assembly path="<%=_arg_ApplicationName%>_businesslayer_UTs\bin\Debug\<%=_arg_Namespace%>.lib.businesslayer.UTs.dll" />
  </Config>
</NUnitProject>