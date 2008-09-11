<%--

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

--%><%@ Page language="c#" contenttype="text/html" %>
<%@ import namespace="OGen.lib.datalayer" %>
<%@ import namespace="OGen.NTier.lib.metadata" %><%
#region arguments...
string _arg_MetadataFilepath = System.Web.HttpUtility.UrlDecode(Request.QueryString["MetadataFilepath"]);
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
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
cDBMetadata_Table _aux_table = _aux_metadata.Tables[_arg_TableName];
int _aux_table_hasidentitykey = _aux_table.hasIdentityKey();
bool _aux_table_searches_hasexplicituniqueindex = _aux_table.Searches.hasExplicitUniqueIndex();

cDBMetadata_Table_Field _aux_field;
string _aux_field_name;
cDBMetadata_Update _aux_update;
int firstKey = _aux_table.firstKey();
#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_metadata.CopyrightText != string.Empty) && (_aux_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_metadata.CopyrightText%>
/*

<%=_aux_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Xml.Serialization;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer {
	[XmlRoot("collectionOf_<%=_aux_table.Name%>")]
	public class SC0_<%=_aux_table.Name%> {
		#region public SC0_<%=_aux_table.Name%>(...);
		public SC0_<%=_aux_table.Name%>() {
		}
		#endregion

		#region public SO0_<%=_aux_table.Name%>[] SO0_<%=_aux_table.Name%> { get; set; }
		private SO0_<%=_aux_table.Name%>[] <%=_aux_table.Name.ToLower()%>_;

		[XmlElement("oneItemOf_<%=_aux_table.Name%>")]
		public SO0_<%=_aux_table.Name%>[] SO0_<%=_aux_table.Name%> {
			get { return <%=_aux_table.Name.ToLower()%>_; }
			set { <%=_aux_table.Name.ToLower()%>_ = value; }
		}
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>