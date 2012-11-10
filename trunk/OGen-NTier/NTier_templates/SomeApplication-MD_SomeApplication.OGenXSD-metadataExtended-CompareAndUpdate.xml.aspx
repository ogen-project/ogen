<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.Libraries.DataLayer" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataExtended" %>
<%@ import namespace="OGen.NTier.Libraries.Metadata.MetadataDB" %><%
#region arguments...
string _arg_MetadataFilePath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilePath"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilePath,
	true,
	false
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableType _aux_db_table;
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableType _aux_ex_table;

OGen.NTier.Libraries.Metadata.MetadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType _aux_ex_field;

XS_tableSearchType _aux_ex_search;
XS_tableSearchUpdateType _aux_ex_search_update;
XS_tableUpdateType _aux_ex_update;

XS_tableFieldRefType _aux_ex_field_ref;
#endregion
//-----------------------------------------------------------------------------------------
if ((!string.IsNullOrEmpty(_aux_ex_metadata.CopyrightText)) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%><!--

<%=_aux_ex_metadata.CopyrightTextLong%>

-->
<%
}%><metadataExtended 
	applicationName="<%=_aux_ex_metadata.ApplicationName%>" 
	applicationNamespace="<%=_aux_ex_metadata.ApplicationNamespace%>" 
	subAppName="<%=_aux_ex_metadata.SubAppName%>" 
	pseudoReflectionable="<%=_aux_ex_metadata.PseudoReflectionable%>" 
	sqlScriptOption="<%=_aux_ex_metadata.SQLScriptOption%>" 
	guidDatalayer="<%=_aux_ex_metadata.GUIDDatalayer%>" 
	guidDatalayer_proxy="<%=_aux_ex_metadata.GUIDDatalayer_proxy%>" 
	guidDatalayer_UTs="<%=_aux_ex_metadata.GUIDDatalayer_UTs%>" 
	guidBusinesslayer="<%=_aux_ex_metadata.GUIDBusinesslayer%>" 
	guidBusinesslayer_proxy="<%=_aux_ex_metadata.GUIDBusinesslayer_proxy%>" 
	guidBusinesslayer_UTs="<%=_aux_ex_metadata.GUIDBusinesslayer_UTs%>" 
	guidBusiness_client="<%=_aux_ex_metadata.GUIDBusiness_client%>" 
	guidDistributedlayer_webservices_server="<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_server%>" 
	guidDistributedlayer_webservices_client="<%=_aux_ex_metadata.GUIDDistributedlayer_webservices_client%>" 
	guidDistributedlayer_remoting_server="<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_server%>" 
	guidDistributedlayer_remoting_client="<%=_aux_ex_metadata.GUIDDistributedlayer_remoting_client%>" 
	guidTest="<%=_aux_ex_metadata.GUIDTest%>" 


	guid_datalayer="<%=_aux_ex_metadata.GUID_datalayer%>"
	guid_datalayer_structures="<%=_aux_ex_metadata.GUID_datalayer_structures%>"
	guid_datalayer_uts="<%=_aux_ex_metadata.GUID_datalayer_uts%>"

	guid_businesslayer="<%=_aux_ex_metadata.GUID_businesslayer%>"
	guid_businesslayer_structures="<%=_aux_ex_metadata.GUID_businesslayer_structures%>"
	guid_businesslayer_shared="<%=_aux_ex_metadata.GUID_businesslayer_shared%>"
	guid_businesslayer_instances="<%=_aux_ex_metadata.GUID_businesslayer_instances%>"
	guid_businesslayer_instances_remotingclient="<%=_aux_ex_metadata.GUID_businesslayer_instances_remotingclient%>"
	guid_businesslayer_instances_webservicesclient="<%=_aux_ex_metadata.GUID_businesslayer_instances_webservicesclient%>"
	guid_businesslayer_instances_businessobject="<%=_aux_ex_metadata.GUID_businesslayer_instances_businessobject%>"
	guid_businesslayer_uts="<%=_aux_ex_metadata.GUID_businesslayer_uts%>"

	guid_remoting_server="<%=_aux_ex_metadata.GUID_remoting_server%>"
	guid_remoting_simpleserver="<%=_aux_ex_metadata.GUID_remoting_simpleserver%>"
	guid_remoting_client="<%=_aux_ex_metadata.GUID_remoting_client%>"

	guid_webservices_server="<%=_aux_ex_metadata.GUID_webservices_server%>"
	guid_webservices_client="<%=_aux_ex_metadata.GUID_webservices_client%>"

	guid_test="<%=_aux_ex_metadata.GUID_test%>"

	remotingServer_ServerURI="<%=_aux_ex_metadata.RemotingServer_ServerURI%>"
	remotingServer_ServerPort="<%=_aux_ex_metadata.RemotingServer_ServerPort%>"

	webservices_ServerURI="<%=_aux_ex_metadata.Webservices_ServerURI%>"
	webservices_ServerPort="<%=_aux_ex_metadata.Webservices_ServerPort%>"

	feedbackEmailAddress="<%=_aux_ex_metadata.FeedbackEmailAddress%>" 
	copyrightText="<%=_aux_ex_metadata.CopyrightText%>">
	<copyrightTextLong><%=_aux_ex_metadata.CopyrightTextLong%></copyrightTextLong>
	<dbs
		nameCase_defaultProvider="<%=_aux_ex_metadata.DBs.NameCase_defaultProvider%>"
		description_defaultProvider="<%=_aux_ex_metadata.DBs.Description_defaultProvider%>"><%
	for (int d = 0; d < _aux_ex_metadata.DBs.DBCollection.Count; d++) {%>
		<db dbServerType="<%=_aux_ex_metadata.DBs.DBCollection[d].DBServerType%>" generateSQL="<%=_aux_ex_metadata.DBs.DBCollection[d].GenerateSQL.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>" connectionString="<%=_aux_ex_metadata.DBs.DBCollection[d].ConnectionString%>" /><%
	}%>
	</dbs>
	<tables>
<!--
		<table name="IHaveAStyle" isConfig="false" configName="" configConfig="" configDatatype="">
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
--><%
	for (int t = 0; t < _aux_db_metadata.Tables.TableCollection.Count; t++) {
		_aux_db_table = _aux_db_metadata.Tables.TableCollection[t];
		_aux_ex_table = _aux_db_table.parallel_ref;%>
		<table name="<%=_aux_db_table.Name
			%>" friendlyName="<%=(_aux_ex_table != null) ? _aux_ex_table.FriendlyName : ""
			%>" extendedDescription="<%=(_aux_ex_table != null) ? _aux_ex_table.ExtendedDescription : ""
			%>" isConfig="<%=(_aux_ex_table != null) ? _aux_ex_table.IsConfig.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture) : "false"
			%>" configName="<%=(_aux_ex_table != null) ? _aux_ex_table.ConfigName : ""
			%>" configConfig="<%=(_aux_ex_table != null) ? _aux_ex_table.ConfigConfig : ""
			%>" configDatatype="<%=(_aux_ex_table != null) ? _aux_ex_table.ConfigDatatype : ""%>">
			<tableFields><%
			for (int f = 0; f < _aux_db_table.TableFields.TableFieldCollection.Count; f++) {
				_aux_db_field = _aux_db_table.TableFields.TableFieldCollection[f];
				_aux_ex_field = _aux_db_field.parallel_ref;%>
				<tableField name="<%=_aux_db_field.Name
					%>" isViewPK="<%=(_aux_ex_field != null) ? (_aux_ex_field.IsViewPK.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)) : "false"
					%>" defaultValue="<%=(_aux_ex_field != null) ? _aux_ex_field.DefaultValue : ""
					%>" friendlyName="<%=(_aux_ex_field != null) ? _aux_ex_field.FriendlyName : ""
					%>" extendedDescription="<%=(_aux_ex_field != null) ? _aux_ex_field.ExtendedDescription : ""
					%>" isListItemValue="<%=(_aux_ex_field != null) ? (_aux_ex_field.IsListItemValue.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)) : "false"
					%>" isListItemText="<%=(_aux_ex_field != null) ? (_aux_ex_field.IsListItemText.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)) : "false"%>" /><%
			}%>
			</tableFields>
			<tableSearches><%
			if (_aux_ex_table != null) {
				for (int s = 0; s < _aux_ex_table.TableSearches.TableSearchCollection.Count; s++) {
					_aux_ex_search = _aux_ex_table.TableSearches.TableSearchCollection[s];%>
				<tableSearch name="<%=_aux_ex_search.Name
					%>" isRange="<%=_aux_ex_search.IsRange.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)
					%>" isExplicitUniqueIndex="<%=_aux_ex_search.IsExplicitUniqueIndex.ToString().ToLower(System.Globalization.CultureInfo.CurrentCulture)%>"<%=
						(
							(_aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count != 0)
							||
							(_aux_ex_search.TableSearchUpdates.TableSearchUpdateCollection.Count != 0)
						) ? "" : " /" %>><%


					if (_aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count != 0) {%>
					<tableSearchParameters><%
						for (int p = 0; p < _aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count; p++) {
							_aux_ex_field_ref = _aux_ex_search.TableSearchParameters.TableFieldRefCollection[p];%>
						<tableFieldRef tableName="<%=_aux_ex_field_ref.TableName
								%>" tableFieldName="<%=_aux_ex_field_ref.TableFieldName
								%>" paramName="<%=_aux_ex_field_ref.ParamName%>" /><%
						}%>
					</tableSearchParameters><%
					}


					if (_aux_ex_search.TableSearchUpdates.TableSearchUpdateCollection.Count != 0) {%>
					<tableSearchUpdates><%
						for (int u = 0; u < _aux_ex_search.TableSearchUpdates.TableSearchUpdateCollection.Count; u++) {
							_aux_ex_search_update = _aux_ex_search.TableSearchUpdates.TableSearchUpdateCollection[u];%>
						<tableSearchUpdate name="<%=_aux_ex_search_update.Name%>">
							<tableSearchUpdateParameters><%
								for (int p = 0; p < _aux_ex_search_update.TableSearchUpdateParameters.TableFieldRefCollection.Count; p++) {
									_aux_ex_field_ref = _aux_ex_search_update.TableSearchUpdateParameters.TableFieldRefCollection[p];%>
								<tableFieldRef tableName="<%=_aux_ex_field_ref.TableName
									%>" tableFieldName="<%=_aux_ex_field_ref.TableFieldName
									%>" paramName="<%=_aux_ex_field_ref.ParamName
									%>" /><%
									}%>
							</tableSearchUpdateParameters>
						</tableSearchUpdate><%
						}%>
					</tableSearchUpdates><%
					}


					if (
						(_aux_ex_search.TableSearchParameters.TableFieldRefCollection.Count != 0)
						||
						(_aux_ex_search.TableSearchUpdates.TableSearchUpdateCollection.Count != 0)
					) {%>
				</tableSearch><%
					}
				}
			}%>
<!--
				<tableSearch name="bySomeCriteria" isRange="true" isExplicitUniqueIndex="false">
					<tableSearchParameters>
						<tableFieldRef tableName="<%=_aux_db_table.Name%>" tableFieldName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" paramName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" />
						<tableFieldRef tableName="<%=_aux_db_table.Name%>" tableFieldName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" paramName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" />
					</tableSearchParameters>
					<tableSearchUpdates>
						<tableSearchUpdate name="SomeUpdateTest">
							<tableSearchUpdateParameters>
								<tableFieldRef tableName="<%=_aux_db_table.Name%>" tableFieldName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" paramName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" />
								<tableFieldRef tableName="<%=_aux_db_table.Name%>" tableFieldName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" paramName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" />
							</tableSearchUpdateParameters>
						</tableSearchUpdate>
					</tableSearchUpdates>
				</tableSearch>
-->
			</tableSearches>
			<tableUpdates><%
		if (
			(_aux_ex_table != null)
			&&
			(_aux_ex_table.TableUpdates.TableUpdateCollection.Count != 0)
		) {
			for (int u = 0; u < _aux_ex_table.TableUpdates.TableUpdateCollection.Count; u++) {
				_aux_ex_update = _aux_ex_table.TableUpdates.TableUpdateCollection[u];%>
				<tableUpdate name="<%=_aux_ex_update.Name%>">
					<tableUpdateParameters><%
						for (int p = 0; p < _aux_ex_update.TableUpdateParameters.TableFieldRefCollection.Count; p++) {
							_aux_ex_field_ref = _aux_ex_update.TableUpdateParameters.TableFieldRefCollection[p];%>
						<tableFieldRef tableName="<%=_aux_ex_field_ref.TableName
							%>" tableFieldName="<%=_aux_ex_field_ref.TableFieldName
							%>" paramName="<%=_aux_ex_field_ref.ParamName%>" /><%
						}%>
					</tableUpdateParameters>
				</tableUpdate><%
			}
		}%>
<!--
				<tableUpdate name="SomeUpdateTest">
					<tableUpdateParameters>
						<tableFieldRef tableName="<%=_aux_db_table.Name%>" tableFieldName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" paramName="<%=_aux_db_table.TableFields.TableFieldCollection[0].Name%>" />
					</tableUpdateParameters>
				</tableUpdate>
-->
			</tableUpdates>
		</table><%
	}
%>
	</tables>
</metadataExtended><%
//-----------------------------------------------------------------------------------------
%>