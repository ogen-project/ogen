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
string _arg_OGenPath = System.Web.HttpUtility.UrlDecode(Request.QueryString["OGenPath"]);
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
%>@ECHO OFF
IF "<%=_arg_OGenPath%>" == "" GOTO error1
IF NOT EXIST "<%=_arg_OGenPath%>\OGen.NTier.presentationlayer.console.exe" GOTO error2
IF NOT EXIST "%~d0%~p0OGen-metadatas\MD_<%=_aux_metadata.ApplicationName%>.OGen-metadata.xml" GOTO error3


"<%=_arg_OGenPath%>\OGen.NTier.presentationlayer.console.exe" "%~d0%~p0OGen-metadatas\MD_<%=_aux_metadata.ApplicationName%>.OGen-metadata.xml"
PAUSE
GOTO eof


:error1
	ECHO Can't find OGen (badly generated config file)
	PAUSE
GOTO eof
:error2
	ECHO Can't find: "<%=_arg_OGenPath%>\OGen.NTier.presentationlayer.console.exe", 
	ECHO %~n0%~x0 needs some tweaking
	PAUSE
GOTO eof
:error3
	ECHO Can't find: "%~d0%~p0OGen-metadatas\MD_<%=_aux_metadata.ApplicationName%>.OGen-metadata.xml"
	ECHO %~n0%~x0 needs some tweaking
	PAUSE
GOTO eof


:eof
