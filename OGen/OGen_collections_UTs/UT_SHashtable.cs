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
using NUnit.Framework;

using OGen.lib.collections;

namespace OGen.lib.collections.UTs {
	[TestFixture]
	public class UT_SHashtable { public UT_SHashtable() {}
		private SHashtable _hash;

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			_hash = new SHashtable();
			_hash.Add("três", 3);
			_hash.Add("um", 1);
			_hash.Add("dois", 2);
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			_hash = null;
		}
		#endregion

		[Test]
		public void UT_SomeTest() {
			Assert.AreEqual(3, _hash.Count);
			Assert.AreEqual(3, _hash.Keys.Count);

			Assert.AreEqual("três", _hash.Keys[0]);
			Assert.AreEqual("um", _hash.Keys[1]);
			Assert.AreEqual("dois", _hash.Keys[2]);

			Assert.AreEqual(3, (int)_hash["três"]);
			Assert.AreEqual(1, (int)_hash["um"]);
			Assert.AreEqual(2, (int)_hash["dois"]);
		}
	}
}