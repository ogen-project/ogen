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
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

//OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update;
//OGen.NTier.lib.metadata.metadataExtended.XS_tableSearchType _aux_ex_search;
//OGen.NTier.lib.metadata.metadataExtended.XS_tableSearchUpdateType _aux_ex_search_update;
//_aux_ex_metadata.ApplicationName
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_ex_metadata.CopyrightText != string.Empty) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%><!--

<%=_aux_ex_metadata.CopyrightTextLong%>

--><%
}%><metadataExtended 
	applicationName="<%=_aux_ex_metadata.ApplicationName%>" 
	applicationNamespace="<%=_aux_ex_metadata.ApplicationName%>" 
	subAppName="" 
	pseudoReflectionable="false" 
	sqlScriptOption="RunImmediately" 
	guidDatalayer="<%=_aux_ex_metadata.GUIDDatalayer%>" 
	guidDatalayer_UTs="<%=_aux_ex_metadata.GUIDDatalayer_UTs%>" 
	guidBusinesslayer="<%=_aux_ex_metadata.GUIDBusinesslayer%>" 
	guidBusinesslayer_UTs="<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>" 
	guidTest="<%=_aux_ex_metadata.GUIDTest%>" 
	feedbackEmailAddress="fmonteiro@users.berlios.de" 
	copyrightText="<%=_aux_ex_metadata.CopyrightText%>">
	<copyrightTextLong><%=_aux_ex_metadata.CopyrightTextLong%></copyrightTextLong>
	<dbs
		nameCase_defaultProvider="PostgreSQL"
		description_defaultProvider="PostgreSQL">
		<db dbServerType="PostgreSQL">
			<dbConnections>
				<dbConnection configMode="DEBUG" isDefault="true" generateSQL="true" isIndexed_andReadOnly="false" connectionstring="Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;" />
				<dbConnection configMode="!DEBUG" isDefault="true" generateSQL="false" isIndexed_andReadOnly="false" connectionstring="Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;" />
			</dbConnections>
		</db>
		<!--
		<db dbServerType="SQLServer">
			<dbConnections>
				<dbConnection configMode="DEBUG" isDefault="false" generateSQL="true" isIndexed_andReadOnly="false" connectionstring="server=127.0.0.1;uid=sa;pwd=passpub;database=OGen-NTier_UTs;" />
				<dbConnection configMode="!DEBUG" isDefault="false" generateSQL="false" isIndexed_andReadOnly="false" connectionstring="server=127.0.0.1;uid=sa;pwd=passpub;database=OGen-NTier_UTs;" />
			</dbConnections>
		</db>
		-->
	</dbs>
	<tables>

<!--
		<table name="IHaveAStyle" isConfig="false" configName="" configConfig="" configDatatype="" >
			<dbs>
				<db dbServerType="PostgreSQL" tableName="IHaveAStyle" />
				<db dbServerType="SQLServer" tableName="i_Have_MyOwn_style" />
				<db dbServerType="MySQL" tableName="i_have_a_lower_style" />
			</dbs>
			<tableFields>
				<tableField name="IDIHaveAStyle" isListItemValue="false" isListItemText="false" isConfig_Name="false" isConfig_Config="false" isConfig_Datatype="false" fkTableName="" fkFieldName="" isNullable="false" size="0">
					<dbs>
						<db dbServerType="PostgreSQL" dbType="bigint" fieldName="IDIHaveAStyle" />
						<db dbServerType="SQLServer" dbType="bigint" fieldName="ID_i_Have_MyOwn_style" />
						<db dbServerType="MySQL" dbType="bigint" fieldName="ID_i_have_a_lower_style" />
					</dbs>
				</tableField>
			</tableFields>
		</table>
-->
<%
//for (int t = 0; t < _aux
%>
		<table name="Config" friendlyName="" extendedDescription="" isConfig="true" configName="Name" configConfig="Config" configDatatype="DataType" >
			<tableFields>
				<tableField name="Name" defaultValue="" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Config" defaultValue="" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Type" defaultValue="" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Description" defaultValue="" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches>
				<tableSearch name="all" isRange="true" isExplicitUniqueIndex="false">
					<tableSearchParameters />
					<tableSearchUpdates />
				</tableSearch>
			</tableSearches>
			<tableUpdates />
		</table>
		<table name="Group" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDGroup" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Name" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="GroupPermition" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDGroup" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDPermition" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="Language" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDLanguage" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDWord_name" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="Log" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDLog" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDLogcode" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDUser_posted" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Date_posted" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Logdata" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="Logcode" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDLogcode" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Warning" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Error" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Code" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Description" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="Permition" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDPermition" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Name" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="User" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDUser" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Login" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Password" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="SomeNullValue" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches>
				<tableSearch name="all" isRange="true" isExplicitUniqueIndex="false">
					<tableSearchParameters />
					<tableSearchUpdates />
				</tableSearch>
				<tableSearch name="byLogin" isRange="false" isExplicitUniqueIndex="true">
					<tableSearchParameters>
						<tableFieldRef tableName="User" fieldName="Login" paramName="Login" />
					</tableSearchParameters>
					<tableSearchUpdates />
				</tableSearch>
				<tableSearch name="byGroup" isRange="true" isExplicitUniqueIndex="false">
					<tableSearchParameters>
						<tableFieldRef tableName="UserGroup" fieldName="IDGroup" paramName="IDGroup" />
					</tableSearchParameters>
					<tableSearchUpdates>
						<tableSearchUpdate name="SomeUpdateTest">
							<tableSearchUpdateParameters>
								<tableFieldRef tableName="User" fieldName="Password" paramName="Password" />
							</tableSearchUpdateParameters>
						</tableSearchUpdate>
					</tableSearchUpdates>
				</tableSearch>
			</tableSearches>
			<tableUpdates>
				<tableUpdate name="SomeUpdateTest">
					<tableUpdateParameters>
						<tableFieldRef tableName="User" fieldName="Password" paramName="Password" />
					</tableUpdateParameters>
				</tableUpdate>
			</tableUpdates>
		</table>
		<table name="UserGroup" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDUser" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDGroup" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Relationdate" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Defaultrelation" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches>
				<tableSearch name="byUser_Defaultrelation" isRange="true" isExplicitUniqueIndex="false">
					<tableSearchParameters>
						<tableFieldRef tableName="UserGroup" fieldName="IDUser" paramName="IDUser" />
						<tableFieldRef tableName="UserGroup" fieldName="Relationdate" paramName="Relationdate" />
					</tableSearchParameters>
					<tableSearchUpdates>
						<tableSearchUpdate name="SomeUpdateTest">
							<tableSearchUpdateParameters>
								<tableFieldRef tableName="UserGroup" fieldName="Relationdate" paramName="Relationdate" />
							</tableSearchUpdateParameters>
						</tableSearchUpdate>
					</tableSearchUpdates>
				</tableSearch>
			</tableSearches>
			<tableUpdates />
		</table>
		<table name="Word" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDWord" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="DeleteThisTestField" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="WordLanguage" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDWord" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDLanguage" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Translation" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
		<table name="vUserDefaultGroup" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDUser" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Login" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDGroup" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Name" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Relationdate" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches>
				<tableSearch name="all" isRange="true" isExplicitUniqueIndex="false">
					<tableSearchParameters />
					<tableSearchUpdates />
				</tableSearch>
			</tableSearches>
			<tableUpdates />
		</table>
		<table name="vUserGroup" friendlyName="" extendedDescription="" isConfig="false" configName="" configConfig="" configDatatype="" >
			<tableFields>
				<tableField name="IDUser" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Login" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="IDGroup" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Name" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
				<tableField name="Relationdate" friendlyName="" extendedDescription="" isListItemValue="false" isListItemText="false" />
			</tableFields>
			<tableSearches />
			<tableUpdates />
		</table>
	</tables>
</metadataExtended><%
//-----------------------------------------------------------------------------------------
%>