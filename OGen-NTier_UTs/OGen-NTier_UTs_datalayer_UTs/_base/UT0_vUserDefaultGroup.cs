#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;
using NUnit.Framework;

using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.UTs {
	public class UT0_vUserDefaultGroup { public UT0_vUserDefaultGroup() {}

		#region protected Properties...
		#endregion

		[Test]
		public void UT_SetGetDelSequence() {
			DO_vUserDefaultGroup _vuserdefaultgroup;
			try {
				_vuserdefaultgroup = new DO_vUserDefaultGroup();
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to instantiate DO_vUserDefaultGroup\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			_vuserdefaultgroup.Connection.Open();
			_vuserdefaultgroup.Connection.Transaction.Begin();



			_vuserdefaultgroup.Fields.IDUser = 123L;
			_vuserdefaultgroup.Fields.Login = "123";
			_vuserdefaultgroup.Fields.IDGroup = 123L;
			_vuserdefaultgroup.Fields.Name = "123";
			_vuserdefaultgroup.Fields.Relationdate = new DateTime(2341, 12, 12);
			// setObject(); // ToDos: here!



			_vuserdefaultgroup.Connection.Transaction.Rollback();
			_vuserdefaultgroup.Connection.Transaction.Terminate();
			_vuserdefaultgroup.Connection.Close();
			_vuserdefaultgroup.Dispose(); _vuserdefaultgroup = null;
		}
	}
}