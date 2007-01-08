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
using System.Data;
using NUnit.Framework;

using <%=_aux_metadata.Namespace%>.lib.datalayer;

namespace <%=_aux_metadata.Namespace%>.lib.datalayer.UTs {
	public class UT0_<%=_aux_table.Name%> { public UT0_<%=_aux_table.Name%>() {}

		#region protected Properties...
		#endregion

		[Test]
		public void UT_<%=(_aux_table_hasidentitykey != -1) ? "Ins" : "Set"%>GetDelSequence() {
			DO_<%=_aux_table.Name%> _<%=_aux_table.Name.ToLower()%>;
			try {
				_<%=_aux_table.Name.ToLower()%> = new DO_<%=_aux_table.Name%>();
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to instantiate DO_<%=_aux_table.Name%>\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			_<%=_aux_table.Name.ToLower()%>.Connection.Open();
			_<%=_aux_table.Name.ToLower()%>.Connection.Transaction.Begin();


<%



			for (int f = 0; f < _aux_table.Fields.Count; f++) {
				if (f == _aux_table_hasidentitykey) continue;
				_aux_field = _aux_table.Fields[f];%><%=""%>
			_<%=_aux_table.Name.ToLower()%>.Fields.<%=_aux_field.Name%> = <%=_aux_field.DBType_generic.FWUnitTestValue%>;<%
			}



			if (_aux_table_hasidentitykey != -1) {
				if (!_aux_table_searches_hasexplicituniqueindex) {
					_aux_field = _aux_table.Fields[_aux_table_hasidentitykey];%><%=""%>
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
						if (f == _aux_table_hasidentitykey) continue;
						_aux_field = _aux_table.Fields[f];%><%=""%>
			Assert.AreEqual(<%=_aux_field.DBType_generic.FWUnitTestValue%>, _<%=_aux_table.Name.ToLower()%>.Fields.<%=_aux_field.Name%>, "inserted values difer those just read (insObject/getObject)");<%
					}
					_aux_field = _aux_table.Fields[_aux_table_hasidentitykey];%>
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