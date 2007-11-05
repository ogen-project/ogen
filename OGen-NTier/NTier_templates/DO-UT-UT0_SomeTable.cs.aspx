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

string _aux_xx_field_name;

OGen.NTier.lib.metadata.metadataExtended.XS_tableUpdateType _aux_ex_update;

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
using NUnit.Framework;

using <%=_aux_ex_metadata.Namespace%>.lib.datalayer;

namespace <%=_aux_ex_metadata.Namespace%>.lib.datalayer.UTs {
	public class UT0_<%=_aux_db_table.Name%> { public UT0_<%=_aux_db_table.Name%>() {}

		#region protected Properties...
		#endregion

		[Test]
		public void UT_<%=(_aux_db_table.hasIdentityKey != -1) ? "Ins" : "Set"%>GetDelSequence() {
			DO_<%=_aux_db_table.Name%> _<%=_aux_table.Name.ToLower()%>;
			try {
				_<%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_db_table.Name%>();
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to instantiate DO_<%=_aux_db_table.Name%>\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			_<%=_aux_table.Name.ToLower()%>.Connection.Open();
			_<%=_aux_table.Name.ToLower()%>.Connection.Transaction.Begin();


<%



			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				if (f == _aux_db_table.hasIdentityKey) continue;
				_aux_field = _aux_table.Fields[f];%><%=""%>
			_<%=_aux_table.Name.ToLower()%>.Fields.<%=_aux_field.Name%> = <%=_aux_field.DBType_generic.FWUnitTestValue%>;<%
			}



			if (_aux_db_table.hasIdentityKey != -1) {
				if (!_aux_ex_table.TableSearches.hasExplicitUniqueIndex) {
					_aux_field = _aux_table.Fields[_aux_db_table.hasIdentityKey];%><%=""%>
			<%=_aux_field.DBType_generic.FWType%> _<%=_aux_field.Name.ToLower()%>;
			try {
				_<%=_aux_field.Name.ToLower()%> = _<%=_aux_table.Name.ToLower()%>.insObject(true);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error running insObject\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			Assert.IsTrue(_<%=_aux_field.Name.ToLower()%> > 0L, "failed to retrieve identity seed (insObject)");
			_<%=_aux_table.Name.ToLower()%>.clrObject();
			bool _exists;
			try {
				_exists = _<%=_aux_table.Name.ToLower()%>.getObject(_<%=_aux_field.Name.ToLower()%>);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error running getObject\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			Assert.IsTrue(_exists, "can't read inserted item (getObject)");<%
					for (int f = 0; f < _aux_table.Fields.Count; f++) {
						if (f == _aux_db_table.hasIdentityKey) continue;
						_aux_field = _aux_table.Fields[f];%><%=""%>
			Assert.AreEqual(<%=_aux_field.DBType_generic.FWUnitTestValue%>, _<%=_aux_table.Name.ToLower()%>.Fields.<%=_aux_field.Name%>, "inserted values difer those just read (insObject/getObject)");<%
					}
					_aux_field = _aux_table.Fields[_aux_db_table.hasIdentityKey];%>
			try {
				_<%=_aux_table.Name.ToLower()%>.delObject(_<%=_aux_field.Name.ToLower()%>);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to delete (delObject)\n---\n{0}\n---", e.Message);
				return; // no need...
			}<%



				} else {%>
			// handle Constraints // ToDos: here!<%
				}
			} else {%>
			// setObject(); // ToDos: here!<%
			}



			%>



			_<%=_aux_table.Name.ToLower()%>.Connection.Transaction.Rollback();
			_<%=_aux_table.Name.ToLower()%>.Connection.Transaction.Terminate();
			_<%=_aux_table.Name.ToLower()%>.Connection.Close();
			_<%=_aux_table.Name.ToLower()%>.Dispose(); _<%=_aux_table.Name.ToLower()%> = null;
		}
	}
}<%
//-----------------------------------------------------------------------------------------
%>