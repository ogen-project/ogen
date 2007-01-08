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
using System.Data;
using System.Collections;
using NUnit.Framework;

using OGen.lib.datalayer;

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