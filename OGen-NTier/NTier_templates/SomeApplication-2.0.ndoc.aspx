<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="System.Reflection" %>
<%@ import namespace="OGen.lib.config" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.businesslayer" %>
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

//cDBMetadata_Table _aux_table;
//cDBMetadata_Table_Field _aux_field;
//int _aux_table_hasidentitykey;
//string[] _aux_configmodes = _aux_metadata.ConfigModes();
#endregion
//-----------------------------------------------------------------------------------------
%><project SchemaVersion="1.3">
    <assemblies>
        <assembly location="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.lib.config-2.0.dll")%>" documentation="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.lib.config-2.0.xml")%>" />
        <assembly location="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.lib.datalayer-2.0.dll")%>" documentation="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.lib.datalayer-2.0.xml")%>" />
        <assembly location="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.NTier.lib.datalayer-2.0.dll")%>" documentation="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.NTier.lib.datalayer-2.0.xml")%>" />
        <assembly location="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.NTier.lib.businesslayer-2.0.dll")%>" documentation="<%=System.IO.Path.Combine(_arg_OGenPath, "OGen.NTier.lib.businesslayer-2.0.xml")%>" />
        <assembly location=".\<%=_aux_metadata.ApplicationName%>_datalayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.datalayer-2.0.dll" documentation=".\<%=_aux_metadata.ApplicationName%>_datalayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.datalayer-2.0.xml" />
        <assembly location=".\<%=_aux_metadata.ApplicationName%>_businesslayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.businesslayer-2.0.dll" documentation=".\<%=_aux_metadata.ApplicationName%>_businesslayer\bin\Debug\<%=_aux_metadata.Namespace%>.lib.businesslayer-2.0.xml" />
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