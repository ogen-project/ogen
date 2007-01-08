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
<%@ import namespace="System.Reflection" %>
<%@ import namespace="OGen.lib.config" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.businesslayer" %>
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

//cDBMetadata_Table _aux_table;
//cDBMetadata_Table_Field _aux_field;
//int _aux_table_hasidentitykey;
//string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><project SchemaVersion="1.3">
    <assemblies>
        <assembly location="<%=Assembly.Load("OGen.lib.config").Location%>" documentation="<%=Assembly.Load("OGen.lib.config").Location.Substring(0, Assembly.Load("OGen.lib.config").Location.Length - 4)%>.xml" />
        <assembly location="<%=Assembly.Load("OGen.lib.datalayer").Location%>" documentation="<%=Assembly.Load("OGen.lib.datalayer").Location.Substring(0, Assembly.Load("OGen.lib.datalayer").Location.Length - 4)%>.xml" />
        <assembly location="<%=Assembly.Load("OGen.NTier.lib.datalayer").Location%>" documentation="<%=Assembly.Load("OGen.NTier.lib.datalayer").Location.Substring(0, Assembly.Load("OGen.NTier.lib.datalayer").Location.Length - 4)%>.xml" />
        <assembly location="<%=Assembly.Load("OGen.NTier.lib.businesslayer").Location%>" documentation="<%=Assembly.Load("OGen.NTier.lib.businesslayer").Location.Substring(0, Assembly.Load("OGen.NTier.lib.businesslayer").Location.Length - 4)%>.xml" />
        <assembly location=".\<%=_aux_metadata.ApplicationName%>_datalayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.datalayer.dll" documentation=".\<%=_aux_metadata.ApplicationName%>_datalayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.datalayer.xml" />
        <assembly location=".\<%=_aux_metadata.ApplicationName%>_businesslayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.businesslayer.dll" documentation=".\<%=_aux_metadata.ApplicationName%>_businesslayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.businesslayer.xml" />
    </assemblies>
    <documenters>
        <documenter name="JavaDoc">
            <property name="OutputDirectory" value=".\doc\" />
        </documenter>
        <documenter name="LaTeX">
            <property name="OutputDirectory" value=".\doc\" />
            <property name="TextFileFullName" value="Documentation.tex" />
            <property name="TexFileBaseName" value="Documentation" />
            <property name="LatexCompiler" value="latex" />
            <property name="TexFileFullPath" value=".\doc\Documentation.tex" />
        </documenter>
        <documenter name="LinearHtml">
            <property name="OutputDirectory" value=".\doc\" />
            <property name="Title" value="An NDoc Documented Class Library" />
        </documenter>
        <documenter name="MSDN">
            <property name="OutputDirectory" value=".\<%=_aux_metadata.ApplicationName%>-NDoc\" />
            <property name="HtmlHelpName" value="<%=_aux_metadata.ApplicationName%>" />
            <property name="Title" value="<%=_aux_metadata.ApplicationName%> Programmer's Reference" />
            <property name="OutputTarget" value="Web" />
            <property name="CopyrightText" value="<%=_aux_metadata.CopyrightText%>" />
            <property name="FeedbackEmailAddress" value="<%=_aux_metadata.FeedbackEmailAddress%>" />
        </documenter>
        <documenter name="MSDN 2003">
            <property name="OutputDirectory" value=".\doc\" />
            <property name="Title" value="An NDoc Documented Class Library" />
        </documenter>
        <documenter name="VS.NET 2003">
            <property name="OutputDirectory" value=".\doc\" />
            <property name="HtmlHelpName" value="Documentation" />
            <property name="Title" value="An NDoc documented library" />
        </documenter>
        <documenter name="XML">
            <property name="OutputFile" value=".\doc\doc.xml" />
        </documenter>
    </documenters>
</project>