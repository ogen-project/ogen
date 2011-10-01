#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

using System;

namespace OGen.NTier.UTs.howtos {
	public class HowTo_UseTransactions_betweenDOs_operations {
		public HowTo_UseTransactions_betweenDOs_operations() {
//<document>
string _testid = DateTime.Now.Ticks.ToString();
bool _constraint;
long _iduser;
long _idgroup;

// we need a shared connection between Data Objects
OGen.lib.datalayer.DBConnection _con = OGen.NTier.UTs.lib.datalayer.DO__utils.DBConnection_createInstance(
	OGen.NTier.UTs.lib.datalayer.DO__utils.DBServerType,
	OGen.NTier.UTs.lib.datalayer.DO__utils.DBConnectionstring, 
	string.Empty
);

// before beginning a transaction we need to open the connection
_con.Open();
try {
	// beginning transaction
	_con.Transaction.Begin();

	// sharing connection with User Data Object
	OGen.NTier.UTs.lib.datalayer.DO_User _user 
		= new OGen.NTier.UTs.lib.datalayer.DO_User(_con);
	// performing some operations on User Data Object
	_user.Fields.Login = _testid;
	_user.Fields.Password = _testid;
	_iduser = _user.insObject(true, out _constraint);
	// handling constraint code should be added here
	_user.Dispose(); _user = null;

	// sharing connection with Group Data Object
	OGen.NTier.UTs.lib.datalayer.DO_Group _group 
		= new OGen.NTier.UTs.lib.datalayer.DO_Group(_con);
	// performing some operations on User Data Object
	_group.Fields.Name = _testid;
	_idgroup = _group.insObject(true);
	_group.Dispose(); _group = null;

	// sharing connection with Group Data Object
	OGen.NTier.UTs.lib.datalayer.DO_UserGroup _usergroup
		= new OGen.NTier.UTs.lib.datalayer.DO_UserGroup(_con);
	// performing some operations on User Data Object
	_usergroup.Fields.IDGroup = _idgroup;
	_usergroup.Fields.IDUser = _iduser;
	_usergroup.Fields.Relationdate = DateTime.Now;
	_usergroup.Fields.Defaultrelation = false;
	_usergroup.setObject(false);
	_usergroup.Dispose(); _usergroup = null;

	// commit transaction
	_con.Transaction.Commit();
} catch (Exception _ex) {
	// rollback transaction
	_con.Transaction.Rollback();
} finally {
	// terminate transaction
	_con.Transaction.Terminate();
}
// closing connection
_con.Close();
_con.Dispose(); _con = null;
//</document>
		}
	}
}