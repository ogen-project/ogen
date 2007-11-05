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
string _arg_TableName = System.Web.HttpUtility.UrlDecode(Request.QueryString["TableName"]);
#endregion

#region varaux...
XS__RootMetadata _aux_root_metadata = XS__RootMetadata.Load_fromFile(
	_arg_MetadataFilepath, 
	true
);
XS__metadataDB _aux_db_metadata = _aux_root_metadata.MetadataDBCollection[0];
XS__metadataExtended _aux_ex_metadata = _aux_root_metadata.MetadataExtendedCollection[0];

OGen.NTier.lib.metadata.metadataDB.XS_tableType _aux_db_table
	= _aux_db_metadata.Tables.TableCollection[
		_arg_TableName
	];
OGen.NTier.lib.metadata.metadataExtended.XS_tableType _aux_ex_table
	= _aux_db_table.parallel_ref;

OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType _aux_db_field;
OGen.NTier.lib.metadata.metadataExtended.XS_tableFieldType _aux_ex_field;

#endregion
//-----------------------------------------------------------------------------------------
if ((_aux_ex_metadata.CopyrightText != string.Empty) && (_aux_ex_metadata.CopyrightTextLong != string.Empty)) {
%>#region <%=_aux_ex_metadata.CopyrightText%>
/*

<%=_aux_ex_metadata.CopyrightTextLong%>

*/
#endregion
<%
}%>using System;
using System.Data;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace <%=_aux_ex_metadata.Namespace%>.lib.datalayer {
	/// <summary>
	/// <%=_aux_db_table.Name%> DataObject which provides access to <%=_aux_db_table.Name%> <%=(_aux_table.isVirtualTable) ? "view" : "table"%> at Database.
	/// </summary>
	public sealed 
#if !NET_1_1
		partial
#endif
		class DO_<%=_aux_db_table.Name%> : 
#if NET_1_1
		DO0_<%=_aux_db_table.Name%>, 
#endif
		IDisposable {
#if NET_1_1
		#region public DO_<%=_aux_db_table.Name%>();
		///
		public DO_<%=_aux_db_table.Name%>() : base() {
		}
		/// <summary>
		/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
		/// </summary>
		/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
		public DO_<%=_aux_db_table.Name%>(DBConnection connection_in) : base(connection_in) {
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