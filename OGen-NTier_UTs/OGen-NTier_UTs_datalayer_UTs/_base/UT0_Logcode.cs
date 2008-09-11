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
	public class UT0_Logcode { public UT0_Logcode() {}

		#region protected Properties...
		#endregion

		[Test]
		public void UT_InsGetDelSequence() {
			DO_Logcode _logcode;
			try {
				_logcode = new DO_Logcode();
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to instantiate DO_Logcode\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			_logcode.Connection.Open();
			_logcode.Connection.Transaction.Begin();



			_logcode.Fields.Warning = true;
			_logcode.Fields.Error = true;
			_logcode.Fields.Code = "123";
			_logcode.Fields.Description = "123";
			long _idlogcode;
			try {
				_idlogcode = _logcode.insObject(true);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error running insObject\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			Assert.IsTrue(_idlogcode > 0L, "failed to retrieve identity seed (insObject)");
			_logcode.clrObject();
			bool _exists;
			try {
				_exists = _logcode.getObject(_idlogcode);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error running getObject\n---\n{0}\n---", e.Message);
				return; // no need...
			}
			Assert.IsTrue(_exists, "can't read inserted item (getObject)");
			Assert.AreEqual(true, _logcode.Fields.Warning, "inserted values difer those just read (insObject/getObject)");
			Assert.AreEqual(true, _logcode.Fields.Error, "inserted values difer those just read (insObject/getObject)");
			Assert.AreEqual("123", _logcode.Fields.Code, "inserted values difer those just read (insObject/getObject)");
			Assert.AreEqual("123", _logcode.Fields.Description, "inserted values difer those just read (insObject/getObject)");
			try {
				_logcode.delObject(_idlogcode);
			} catch (Exception e) {
				Assert.IsTrue(false, "some error trying to delete (delObject)\n---\n{0}\n---", e.Message);
				return; // no need...
			}



			_logcode.Connection.Transaction.Rollback();
			_logcode.Connection.Transaction.Terminate();
			_logcode.Connection.Close();
			_logcode.Dispose(); _logcode = null;
		}
	}
}