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

cDBMetadata_Table_Field _aux_field;
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
using System.Data;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_table.Name%> DataObject which provides access to <%=_aux_table.Name%> <%=(_aux_table.isVirtualTable) ? "view" : "table"%> at Database.
	/// </summary>
	public sealed 
#if NET20
		partial
#endif
		class DO_<%=_aux_table.Name%> : 
#if !NET20
		DO0_<%=_aux_table.Name%>, 
#endif
		IDisposable {
#if !NET20
		#region public DO_<%=_aux_table.Name%>();
		///
		public DO_<%=_aux_table.Name%>() : base() {
		}
		/// <summary>
		/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
		/// </summary>
		/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
		public DO_<%=_aux_table.Name%>(cDBConnection connection_in) : base(connection_in) {
		}<%
		//~DO_< %=_aux_table.Name% >() {
		//	cleanUp();
		//}
		//public new void Dispose() {
		//	System.GC.SuppressFinalize(this);
		//	cleanUp();
		//}
		//private void cleanUp() {
		//	base.Dispose();
		//}%>
		#endregion
#endif

		#region public Properties...
		#endregion
		#region public Methods...
		#endregion
	}
}<%
//-----------------------------------------------------------------------------------------
%>