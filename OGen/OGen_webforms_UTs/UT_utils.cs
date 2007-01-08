#region Copyright (C) 2002 Francisco Monteiro
/*

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

*/
#endregion
using System;
using System.IO;
using System.Collections;
using NUnit.Framework;

using OGen.lib.presentationlayer.webforms;

namespace OGen.lib.presentationlayer.webforms.UTs {
	[TestFixture]
	public class UT_utils { public UT_utils() {}
		Hashtable _hash;

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			_hash = new Hashtable(3);
			_hash.Add("um", "one$");
			_hash.Add("dois", 2);
			_hash.Add("três", "three&");
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			_hash = null;
		}
		#endregion

		[Test]
		public void UT_CheckParamValue() {
			string _urlparam = utils.ConcatenateURLParams(_hash, false);
			string[] _paramvalue = _urlparam.Split('&');
			string[] _params;

			for (int i = 0; i < _paramvalue.Length; i++) {
				_params = _paramvalue[i].Split('=');
				Assert.IsTrue(
					(
						System.Web.HttpUtility.UrlDecode(_hash[_params[0]].ToString()) 
						== 
						System.Web.HttpUtility.UrlDecode(_params[1].ToString())
					), 
					"{0} != UrlDecode({1})", 
					_hash[_params[0]].ToString(), 
					_params[1].ToString()
				);
			}
		}

		[Test]
		public void UT_CheckQuestionMark() {
			string _urlparam1 = utils.ConcatenateURLParams(_hash, true);
			string _urlparam2 = utils.ConcatenateURLParams(_hash, false);
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