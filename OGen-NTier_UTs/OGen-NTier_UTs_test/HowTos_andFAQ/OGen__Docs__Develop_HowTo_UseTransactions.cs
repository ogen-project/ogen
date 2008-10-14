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

namespace OGen.UTs.howtos {
	public class HowTo_UseTransactions {
		public HowTo_UseTransactions() {
//<document>
long _iduser = 0L;

OGen.lib.datalayer.DBConnection _con
	= OGen.lib.datalayer.DBConnectionsupport.CreateInstance(
		// set your db server type here
		OGen.lib.datalayer.DBServerTypes.PostgreSQL,
		// and connectionstring
		"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
	);

// before beginning a transaction we need to open the connection
_con.Open();
try {
	// beginning transaction
	_con.Transaction.Begin();

	// performing some operations on db
	_con.Execute_SQLQuery(
		string.Format(
			"delete from \"User\" where \"IDUser\" = {0}",
			_iduser.ToString()
		)
	);

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