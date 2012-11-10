#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.Collections.UnitTests {
	using System;
	using System.IO;
	using NUnit.Framework;
	using OGen.Libraries.Collections;

	[TestFixture]
	public class UT_SHashtable { public UT_SHashtable() {}
		private SHashtable _hash;

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			this._hash = new SHashtable();
			this._hash.Add("três", 3);
			this._hash.Add("um", 1);
			this._hash.Add("dois", 2);
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			this._hash = null;
		}
		#endregion

		[Test]
		public void UT_SomeTest() {
			Assert.AreEqual(3, this._hash.Count);
			Assert.AreEqual(3, this._hash.Keys.Count);

			Assert.AreEqual("três", this._hash.Keys[0]);
			Assert.AreEqual("um", this._hash.Keys[1]);
			Assert.AreEqual("dois", this._hash.Keys[2]);

			Assert.AreEqual(3, (int)this._hash["três"]);
			Assert.AreEqual(1, (int)this._hash["um"]);
			Assert.AreEqual(2, (int)this._hash["dois"]);
		}
	}
}