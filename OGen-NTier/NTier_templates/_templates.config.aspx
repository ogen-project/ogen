<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataExtended" %>
<%@ import namespace="OGen.NTier.lib.metadata.metadataDB" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table;
OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;

OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update;
OGen.NTier.lib.metadata.metadataExtended.XS_tableSearchType _aux_ex_search;
OGen.NTier.lib.metadata.metadataExtended.XS_tableSearchUpdateType _aux_ex_update;

bool _supports_PostgreSQL = false;
bool _supports_SQLServer = false;
bool _supports_MySQL = false;

for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {
	switch (_aux_ex_metadata.DBs.DBCollection[d].DBServerType) {
#if PostgreSQL
		case DBServerTypes.PostgreSQL.ToString():
			_supports_PostgreSQL = true;
			break;
#endif
		case DBServerTypes.SQLServer.ToString():
			_supports_SQLServer = true;
			break;
#if MySQL
		case DBServerTypes.MySQL.ToString():
			_supports_MySQL = true;
			break;
#endif
	}
}
#endregion
//-----------------------------------------------------------------------------------------%>
<templates>
	<!--template name="__XSLT-TEST.txt.xslt" 
			parserType="xslt"
			iterationType="ROOT.metadataDB[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[n].tables.table[n]}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/__XSLT-TEST-${ROOT.metadataDB[n].tables.table[n]}.txt" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template-->
	<template name="emptyfile.txt" 
			parserType="none">
		<arguments />
		<outputs><%
		if (_supports_PostgreSQL) {%>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Replace" /><%
		}%>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Replace" /><%
		if (_supports_MySQL) {%>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Replace" /><%
		}%>
		</outputs>
		<dependencies />
	</template><%
if (_supports_PostgreSQL) {
	for (int t = 0; t < _aux_db_metadata.Tables.TableCollection.Count; t++) {%>
	<template name="DO-DB-v0_SomeTable__onlyKeys-PostgreSQL.sql.aspx" 
			parserType="aspx">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="<%=_aux_db_metadata.Tables.TableCollection[t].Name%>" />
		</arguments>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
			<output to="v0_<%=_aux_db_metadata.Tables.TableCollection[t].Name%>__onlyKeys"
				type="PostgreSQL_View" mode="Replace" />
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template><%
	}
}%>
	<template name="app0.config.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_test/app.config"
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/app0.config"
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication_AssemblyInfo.cs.txt" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/AssemblyInfo.cs" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/AssemblyInfo.cs" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer/AssemblyInfo.cs" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/AssemblyInfo.cs" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_test/AssemblyInfo.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication.OGen-NTier-1.1.bat.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="OGenPath" value="${CONFIG.ogenPath}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>.OGen-NTier-1.1.bat" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication.OGen-NTier-2.0.bat.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="OGenPath" value="${CONFIG.ogenPath}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>.OGen-NTier-2.0.bat" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication_test_MainClass.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_test/MainClass.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication-1.1.ndoc.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="OGenPath" value="${CONFIG.ogenPath}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-1.1.ndoc" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication-2.0.ndoc.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="OGenPath" value="${CONFIG.ogenPath}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-2.0.ndoc" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication-7.1.sln.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-7.1.sln" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication-8.sln.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-8.sln" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication-9.sln.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-9.sln" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-SomeApplication_datalayer-7.1.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/<%=_aux_db_metadata.ApplicationName%>_datalayer-7.1.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-SomeApplication_datalayer-8.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/<%=_aux_db_metadata.ApplicationName%>_datalayer-8.csproj" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/<%=_aux_db_metadata.ApplicationName%>_datalayer-9.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-SomeApplication_datalayer_UTs-7.1.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs-7.1.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-SomeApplication_datalayer_UTs-8.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs-8.csproj" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs-9.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-SomeApplication_businesslayer-7.1.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer/<%=_aux_db_metadata.ApplicationName%>_businesslayer-7.1.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-SomeApplication_businesslayer-8.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer/<%=_aux_db_metadata.ApplicationName%>_businesslayer-8.csproj" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer/<%=_aux_db_metadata.ApplicationName%>_businesslayer-9.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication_test-7.1.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_test/<%=_aux_db_metadata.ApplicationName%>_test-7.1.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="SomeApplication_test-8.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_test/<%=_aux_db_metadata.ApplicationName%>_test-8.csproj" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_test/<%=_aux_db_metadata.ApplicationName%>_test-9.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-UT0__utils.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/_base/UT0__utils.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-UT0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/_base/UT0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-UT_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/UT_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-UT_app.config.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer_UTs/app.config" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.datalayer.UTs-1.1.config" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.datalayer.UTs-2.0.config" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-SomeNamespace.lib.datalayer.UTs-1.1.nunit.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<!-- XXX:NO_NEED 
				<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD0_<%=_aux_db_metadata.ApplicationName%>-${ROOT.metadata.default_DBServerType}.OGen-metadata.xml" />
			XXX:NOT_NEED -->
			<argument name="ApplicationName" value="<%=_aux_db_metadata.ApplicationName%>" />
			<argument name="Namespace" value="${ROOT.metadataExtended[n].applicationNamespace}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.datalayer.UTs-1.1.nunit" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-UT-SomeNamespace.lib.datalayer.UTs-2.0.nunit.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<!-- XXX:NO_NEED
				<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD0_<%=_aux_db_metadata.ApplicationName%>-${ROOT.metadata.default_DBServerType}.OGen-metadata.xml" />
			XXX:NO_NEED -->
			<argument name="ApplicationName" value="<%=_aux_db_metadata.ApplicationName%>" />
			<argument name="Namespace" value="${ROOT.metadataExtended[n].applicationNamespace}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.datalayer.UTs-2.0.nunit" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-SomeApplication_businesslayer_UTs-7.1.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs-7.1.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-SomeApplication_businesslayer_UTs-8.csproj.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs-8.csproj" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs-9.csproj" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-UT0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/_base/UT0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-UT_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/UT_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-UT_app.config.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer_UTs/app.config" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.businesslayer.UTs-1.1.config" 
				type="File" mode="Create_doNotReplace" />
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.businesslayer.UTs-2.0.config" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-SomeNamespace.lib.businesslayer.UTs-1.1.nunit.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<!-- XXX:NO_NEED
				<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD0_<%=_aux_db_metadata.ApplicationName%>-${ROOT.metadata.default_DBServerType}.OGen-metadata.xml" />
			XXX:NO_NEED -->
			<argument name="ApplicationName" value="<%=_aux_db_metadata.ApplicationName%>" />
			<argument name="Namespace" value="${ROOT.metadataExtended[n].applicationNamespace}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.businesslayer.UTs-1.1.nunit" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-UT-SomeNamespace.lib.businesslayer.UTs-2.0.nunit.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<!-- XXX:NO_NEED
				<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD0_<%=_aux_db_metadata.ApplicationName%>-${ROOT.metadata.default_DBServerType}.OGen-metadata.xml" />
			XXX:NO_NEED -->
			<argument name="ApplicationName" value="<%=_aux_db_metadata.ApplicationName%>" />
			<argument name="Namespace" value="${ROOT.metadataExtended[n].applicationNamespace}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/${ROOT.metadataExtended[n].applicationNamespace}.lib.businesslayer.UTs-2.0.nunit" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DO0__utils.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/_base/DO0__utils.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DO__utils.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/DO__utils.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-RO0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/_base/RO0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DO0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/_base/DO0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-SO0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/_base/SO0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-SC0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/_base/SC0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DO_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_datalayer/DO_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-BO0_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer/_base/BO0_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="BO-BO_SomeTable.cs.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataExtended[n].tables.table[n].name}" />
		</arguments>
		<conditions />
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>_businesslayer/BO_${ROOT.metadataExtended[n].tables.table[n].name}.cs" 
				type="File" mode="Create_doNotReplace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-fnc0_SomeTable__ConstraintExist-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />

<!-- XXX:TO_DOS
	ROOT.metadata.tables.table[n].name
	ROOT.metadataDB[0].tables.table[n].name
	ROOT.metadataDB[0].tables.table[n].tableDBs.tableDB[???].dbTableName
XXX:TO_DOS -->

			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.hasExplicitUniqueIndex" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}__ConstraintExist" 
				type="MySQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable__ConstraintExist-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.hasExplicitUniqueIndex" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}__ConstraintExist" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable__ConstraintExist-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.hasExplicitUniqueIndex" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}__ConstraintExist"
				type="SQLServer_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n].searches.search[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[0].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_isObject_${ROOT.metadataExtended[0].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_isObject_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_isObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_isObject_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_isObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}"
				type="SQLServer_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_isObject-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_isObject"
				type="MySQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-fnc0_SomeTable_isObject-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_isObject" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_isObject-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_isObject"
				type="SQLServer_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-fnc0_SomeTable_Record_count_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_Record_count_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_Record_count_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_Record_count_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_Record_count_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_Record_count_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_Record_hasObject_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_Record_hasObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_Record_hasObject_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_Record_hasObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc0_SomeTable_Record_hasObject_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc0_${ROOT.metadataDB[0].tables.table[n].name}_Record_hasObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_insObject-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_insObject" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_insObject-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_insObject" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_insObject-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_insObject" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_updObject-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_updObject" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_updObject-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_updObject" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_updObject-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_updObject" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_setObject-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="False" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_setObject" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp0_SomeTable_setObject-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="False" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_setObject" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_setObject-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.tables.table[n].hasIdentityKey" to="False" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_setObject" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp0_SomeTable_delObject-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<!-- condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.hasExplicitUniqueIndex" to="False" / -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_delObject" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp0_SomeTable_delObject-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<!-- condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.hasExplicitUniqueIndex" to="False" / -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_delObject" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_delObject-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<!-- condition eval="ROOT.metadataExtended[0].tables.table[n].tableSearches.hasExplicitUniqueIndex" to="False" / -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_delObject" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp0_SomeTable_delObject_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_delObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_delObject_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_delObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_delObject_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_delObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_delete_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_delete_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_delete_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_delete_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-v0_SomeTable__onlyKeys-PostgreSQL.sql.aspx" />
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_delete_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataDB[0].tables.table[n].isVirtualTable" to="False" />
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_delete_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc_${ROOT.metadataDB[0].tables.table[n].name}_isObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc_${ROOT.metadataDB[0].tables.table[n].name}_isObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc_${ROOT.metadataDB[0].tables.table[n].name}_isObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-v0_SomeTable__onlyKeys-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="fnc_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_StoredProcedure" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-v0_SomeTable__onlyKeys-PostgreSQL.sql.aspx" />
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_StoredProcedure" mode="Create_doNotReplace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_getObject-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_getObject" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp0_SomeTable_getObject-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_getObject" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_getObject-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataDB[0].tables.table[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_getObject" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-sp0_SomeTable_getObject_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_getObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_getObject_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_getObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_getObject_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="False" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_getObject_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_isObject_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_fullmode-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_fullmode" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_fullmode-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_fullmode" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_fullmode-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_fullmode" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_page-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_page" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_page-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_page" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-v0_SomeTable__onlyKeys-PostgreSQL.sql.aspx" />
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_page-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_page" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_page_fullmode-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_page_fullmode" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_page_fullmode-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_page_fullmode" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_open_bySomeCriteria_page_fullmode-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
			<condition eval="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].isRange" to="True" />
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_open_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}_page_fullmode" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-sp_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_update_SomeUpdate_bySomeCriteria-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
			<argument name="UpdateName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_update_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n].name}_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_update_SomeUpdate_bySomeCriteria-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
			<argument name="UpdateName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_update_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n].name}_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-PostgreSQL.sql.aspx" />
			<dependency name="emptyfile.txt" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_Record_update_SomeUpdate_bySomeCriteria-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="SearchName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" />
			<argument name="UpdateName" value="${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_Record_update_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].updates.update[n].name}_${ROOT.metadataExtended[n].tables.table[n].tableSearches.tableSearche[n].name}" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc_SomeTable_Record_open_bySomeCriteria-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_updObject_SomeUpdate-MySQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="UpdateName" value="${ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_MySQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-MySQL/sql0-<%=_aux_db_metadata.ApplicationName%>.MySQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_updObject_${ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n].name}" 
				type="MySQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-MySQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_updObject_SomeUpdate-PostgreSQL.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="UpdateName" value="${ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_updObject_${ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n].name}" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="emptyfile.txt" />
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-PostgreSQL.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-sp0_SomeTable_updObject_SomeUpdate-SQLServer.sql.aspx" 
			parserType="aspx" 
			iterationType="ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n]">
		<arguments>
			<argument name="MetadataFilepath" value="<%=CONFIG.outputPath%>/OGen-metadatas/MD_<%=_aux_db_metadata.ApplicationName%>.OGenXSD-metadata.xml" />
			<argument name="TableName" value="${ROOT.metadataDB[0].tables.table[n].name}" />
			<argument name="UpdateName" value="${ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n].name}" />
		</arguments>
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
<!-- XXX:TO_DOS
			<output to="sp0_${ROOT.metadataDB[0].tables.table[n].name}_updObject_${ROOT.metadataExtended[n].tables.table[n].tableUpdates.tableUpdate[n].name}" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-fnc0_SomeTable__ConstraintExist-SQLServer.sql.aspx" />
		</dependencies>
	</template>
	<template name="DO-DB-OGen_fnc0__Split-PostgreSQL.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
-->
<!-- XXX:TO_DOS
			<output to="OGen_fnc0__Split" 
				type="PostgreSQL_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-OGen_fnc0__Split-SQLServer.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
-->
<!-- XXX:TO_DOS
			<output to="OGen_fnc0__Split" 
				type="SQLServer_Function" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-OGen_v0__getTables-PostgreSQL.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
-->
			<output to="v0__getTables" 
				type="PostgreSQL_View" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-OGen_sp0__getTables-PostgreSQL.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
-->
<!-- XXX:TO_DOS
			<output to="OGen_sp0__getTables" 
				type="PostgreSQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-OGen_fnc0__Split-PostgreSQL.sql" />
			<dependency name="DO-DB-OGen_v0__getTables-PostgreSQL.sql" />
		</dependencies>
	</template>
	<template name="DO-DB-OGen_sp0__getTables-SQLServer.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
-->
<!-- XXX:TO_DOS
			<output to="OGen_sp0__getTables" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-OGen_fnc0__Split-SQLServer.sql" />
		</dependencies>
	</template>
	<template name="DO-DB-OGen_v0__getTableFields-PostgreSQL.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
-->
			<output to="v0__getTables" 
				type="PostgreSQL_View" mode="Replace" />
		</outputs>
		<dependencies />
	</template>
	<template name="DO-DB-OGen_sp0__getTableFields-PostgreSQL.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_PostgreSQL" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-PostgreSQL/sql0-<%=_aux_db_metadata.ApplicationName%>.PostgreSQL.backup.sql"
				type="File" mode="Append" />
-->
<!-- XXX:TO_DOS
			<output to="OGen_sp0__getTableFields" 
				type="PostgreSQL_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies>
			<dependency name="DO-DB-OGen_v0__getTableFields-PostgreSQL.sql" />
		</dependencies>
	</template>
	<template name="DO-DB-OGen_sp0__getTableFields-SQLServer.sql" 
			parserType="none" 
			iterationType="ROOT.metadataExtended[0]">
		<arguments />
		<conditions>
<!-- XXX:TO_DOS
			<condition eval="ROOT.metadata.dbs.supports_SQLServer" to="True" />
XXX:TO_DOS -->
		</conditions>
		<outputs>
<!--
			<output to="<%=CONFIG.outputPath%>/<%=_aux_db_metadata.ApplicationName%>-SQLServer/sql0-<%=_aux_db_metadata.ApplicationName%>.SQLServer.backup.sql"
				type="File" mode="Append" />
-->
<!-- XXX:TO_DOS
			<output to="OGen_sp0__getTableFields" 
				type="SQLServer_StoredProcedure" mode="Replace" />
XXX:TO_DOS -->
		</outputs>
		<dependencies />
	</template>
</templates><%
//-----------------------------------------------------------------------------------------
%>