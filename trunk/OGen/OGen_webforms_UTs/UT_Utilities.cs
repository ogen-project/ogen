#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.PresentationLayer.WebForms.UnitTests {
	using System;
	using System.Collections;
	using System.IO;
	using NUnit.Framework;

	using OGen.Libraries.PresentationLayer.WebForms;

	[TestFixture]
	public class UT_Utilities { public UT_Utilities() {}
		private Hashtable _hash;

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			this._hash = new Hashtable(3);
			this._hash.Add("um", "one$");
			this._hash.Add("dois", 2);
			this._hash.Add("tr�s", "three&");
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			this._hash = null;
		}
		#endregion

		[Test]
		public void UT_CheckParamValue() {
			string _urlparam = Utilities.ConcatenateURLParams(this._hash, false);
			string[] _paramvalue = _urlparam.Split('&');
			string[] _params;

			for (int i = 0; i < _paramvalue.Length; i++) {
				_params = _paramvalue[i].Split('=');
				Assert.IsTrue(
					(
						System.Web.HttpUtility.UrlDecode(this._hash[_params[0]].ToString()) 
						== 
						System.Web.HttpUtility.UrlDecode(_params[1].ToString())
					), 
					"{0} != UrlDecode({1})",
					this._hash[_params[0]].ToString(), 
					_params[1].ToString()
				);
			}
		}

		[Test]
		public void UT_CheckQuestionMark() {
			string _urlparam1 = Utilities.ConcatenateURLParams(this._hash, true);
			string _urlparam2 = Utilities.ConcatenateURLParams(this._hash, false);
			Assert.IsTrue(
				(
					_urlparam1 
					== 
					string.Format("?{0}", _urlparam2)
				), 
				"{0} != ?{1}", 
				_urlparam1, 
				_urlparam2
			);
		}
	}
}