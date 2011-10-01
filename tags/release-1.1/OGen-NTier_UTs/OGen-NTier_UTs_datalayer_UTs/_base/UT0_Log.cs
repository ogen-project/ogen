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
	public class UT0_Log { public UT0_Log() {}

		#region protected Properties...
		#endregion

		[Test]
		public void UT_InsGetDelSequence() {
			DO_Log _log;
			try {
				_log = new DO_Log();
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to instantiate DO_Log\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			_log.Connection.Open();
			_log.Connection.Transaction.Begin();



			_log.Fields.IDLogcode = 123L;
			_log.Fields.IDUser_posted = 123L;
			_log.Fields.Date_posted = new DateTime(2341, 12, 12);
			_log.Fields.Logdata = "123";
			long _idlog;
			try {
				_idlog = _log.insObject(true);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error running insObject\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			Assert.IsTrue(_idlog > 0L, "failed to retrieve identity seed (insObject)");
			_log.clrObject();
			bool _exists;
			try {
				_exists = _log.getObject(_idlog);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error running getObject\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			Assert.IsTrue(_exists, "can't read inserted item (getObject)");
			Assert.AreEqual(123L, _log.Fields.IDLogcode, "inserted values difer those just read (insObject/getObject)");
			Assert.AreEqual(123L, _log.Fields.IDUser_posted, "inserted values difer those just read (insObject/getObject)");
			Assert.AreEqual(new DateTime(2341, 12, 12), _log.Fields.Date_posted, "inserted values difer those just read (insObject/getObject)");
			Assert.AreEqual("123", _log.Fields.Logdata, "inserted values difer those just read (insObject/getObject)");
			try {
				_log.delObject(_idlog);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to delete (delObject)\n---\n{0}\n---", e.Message);
				return; // no need...
			}



			_log.Connection.Transaction.Rollback();
			_log.Connection.Transaction.Terminate();
			_log.Connection.Close();
			_log.Dispose(); _log = null;
		}
	}
}