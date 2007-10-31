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

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.howtos {
	public class HowTo_UseTransactions_inDOs {
		public HowTo_UseTransactions_inDOs() {
			string _testid = DateTime.Now.Ticks.ToString();
			bool _constraint;
			long _iduser;
			long _idgroup;


			DO_User _user = new DO_User();

			// before beginning a transaction we need to open the connection
			_user.Connection.Open();

			// beginning transaction
			_user.Connection.Transaction.Begin();

			// performing some operations on User Data Object
			_user.Fields.Login = _testid;
			_user.Fields.Password = _testid;
			_iduser = _user.insObject(true, out _constraint);
			// handling constraint code should be added here

			// rollback transaction, we don't need such data in db, this is just an how to sample
			_user.Connection.Transaction.Rollback();

			// terminate transaction
			_user.Connection.Transaction.Terminate();

			// closing connection
			_user.Connection.Close();

			_user.Dispose(); _user = null;
		}
	}
}