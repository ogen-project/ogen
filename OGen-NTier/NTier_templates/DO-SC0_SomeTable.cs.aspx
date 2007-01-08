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