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
string _arg_OGenPath = System.Web.HttpUtility.UrlDecode(Request.QueryString["OGenPath"]);
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
%>@ECHO OFF
IF "<%=_arg_OGenPath%>" == "" GOTO error1
IF NOT EXIST "<%=_arg_OGenPath%>\OGen.NTier.presentationlayer.console-2.0.exe" GOTO error2
IF NOT EXIST "%~d0%~p0OGen-metadatas\MD_<%=_aux_ex_metadata.ApplicationName%>.OGen-metadata.xml" GOTO error3


"<%=_arg_OGenPath%>\OGen.NTier.presentationlayer.console-2.0.exe" "%~d0%~p0OGen-metadatas\MD_<%=_aux_ex_metadata.ApplicationName%>.OGen-metadata.xml"
PAUSE
GOTO eof


:error1
	ECHO Can't find OGen (badly generated config file)
	PAUSE
GOTO eof
:error2
	ECHO Can't find: "<%=_arg_OGenPath%>\OGen.NTier.presentationlayer.console-2.0.exe", 
	ECHO %~n0%~x0 needs some tweaking
	PAUSE
GOTO eof
:error3
	ECHO Can't find: "%~d0%~p0OGen-metadatas\MD_<%=_aux_ex_metadata.ApplicationName%>.OGen-metadata.xml"
	ECHO %~n0%~x0 needs some tweaking
	PAUSE
GOTO eof


:eof
