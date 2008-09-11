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
using System.Data;
using System.Collections;
using NUnit.Framework;

using OGen.lib.datalayer;

#if PostgreSQL
namespace OGen.lib.datalayer.UTs {
	[TestFixture]
	public class UT_utils { public UT_utils() {}
		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			// ...
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			// ...
		}
		#endregion

		#region public void UT_Connectionstring_ParseParameter();
		#region private void UT_Connectionstring_ParseParameter_auxiliar(Hashtable hash_in);
		private void UT_Connectionstring_ParseParameter_auxiliar(Hashtable hash_in) {
			string _constring;
			IDictionaryEnumerator _enumerator;

			for (int i = 0; ; i++) {
				if (((eDBServerTypes_supportedForGeneration)i).ToString() == "invalid") {
					break;
				} else if (((eDBServerTypes_supportedForGeneration)i).ToString() == i.ToString()) {
					continue;
				} else {
					_constring = utils.Connectionstring.Buildwith.Parameters(
						(string)hash_in[utils.Connectionstring.eParameter.Server],
						(string)hash_in[utils.Connectionstring.eParameter.User], 
						"somepassword",
						(string)hash_in[utils.Connectionstring.eParameter.Database], 
						(eDBServerTypes)i
					);

					_enumerator = hash_in.GetEnumerator();
					while (_enumerator.MoveNext()) {
						Assert.AreEqual(
//						Console.WriteLine(
//"'{0}'\n'{1}'\n{2}\n",
							(string)_enumerator.Value, 
							utils.Connectionstring.ParseParameter(
								_constring,
								(eDBServerTypes)i,
								(utils.Connectionstring.eParameter)_enumerator.Key
							)
//, _constring
						);
					}
				}
			}
		}
		#endregion

		[Test]
		public void UT_Connectionstring_ParseParameter_ItTriggersAKnownBUG() {
			Hashtable _hash;

			_hash  = new Hashtable();
			_hash.Add(utils.Connectionstring.eParameter.Database, "somedb");
			_hash.Add(utils.Connectionstring.eParameter.Server, "someserver");
			_hash.Add(utils.Connectionstring.eParameter.User, "someuser");
			UT_Connectionstring_ParseParameter_auxiliar(_hash);

			_hash = new Hashtable();
			_hash.Add(utils.Connectionstring.eParameter.Database, "database");
			_hash.Add(utils.Connectionstring.eParameter.Server, "server");
			_hash.Add(utils.Connectionstring.eParameter.User, "uid");
			UT_Connectionstring_ParseParameter_auxiliar(_hash);

			Assert.AreEqual(
				"somedatabase", 
				utils.Connectionstring.ParseParameter(
					"Server=someserver;User ID=someuser;Password=somepassword;Database=somedatabase",
					eDBServerTypes.PostgreSQL,
					utils.Connectionstring.eParameter.Database
				)
			);
			Assert.AreEqual(
				"somedatabase",
				utils.Connectionstring.ParseParameter(
					"Database=somedatabase;Server=someserver;User ID=someuser;Password=somepassword",
					eDBServerTypes.PostgreSQL,
					utils.Connectionstring.eParameter.Database
				)
			);
			Assert.AreEqual(
				"somedatabase",
				utils.Connectionstring.ParseParameter(
					"Database=somedatabase",
					eDBServerTypes.PostgreSQL,
					utils.Connectionstring.eParameter.Database
				)
			);
			Assert.AreEqual(
				"somedatabase",
				utils.Connectionstring.ParseParameter(
					"Database=somedatabase;",
					eDBServerTypes.PostgreSQL,
					utils.Connectionstring.eParameter.Database
				)
			);
		}
		#endregion

		#region public void UT_DBType2NUnitTestValue();
		[Test]
		public void UT_DBType2NUnitTestValue() {

			// ToDos: here!
			// SQLServer
			// between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM

			Assert.AreEqual(
				"new DateTime(2341, 12, 12)", 
					OGen.lib.datalayer.utils.convert.DBType2NUnitTestValue(
					DbType.DateTime
				)
			);
		}
		#endregion
	}
}
#endif