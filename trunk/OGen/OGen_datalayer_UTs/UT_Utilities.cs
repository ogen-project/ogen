#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

#if PostgreSQL
namespace OGen.Libraries.DataLayer.UnitTests {
	using System;
	using System.Data;
	using System.Collections;

#if NUnit
	using NUnit.Framework;
#else
	using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
	using OGen.Libraries.DataLayer;


#if NUnit
	[TestFixture]
#else
	[TestClass]
#endif
	public class UT_Utilities {
		public UT_Utilities() {}

		#region public void TestFixtureSetUp();
#if NUnit
		[TestFixtureSetUp]
#endif
		public void TestFixtureSetUp() {
			// ...
		}
		#endregion
		#region public void TestFixtureTearDown();
#if NUnit
		[TestFixtureTearDown]
#endif
		public void TestFixtureTearDown() {
			// ...
		}
		#endregion

//		#region public void UT_Connectionstring_ParseParameter();
//		#region private void UT_Connectionstring_ParseParameter_auxiliar(Hashtable hash_in);
//		private void UT_Connectionstring_ParseParameter_auxiliar(Hashtable hash_in) {
//			string _constring;
//			IDictionaryEnumerator _enumerator;

//			DBServerTypes[] _dbtypes = (DBServerTypes[])Enum.GetValues(typeof(DBServerTypes));
//			for (int i = 0; i < _dbtypes.Length; i++) {
//				_constring = DBUtilities_connectionString.Buildwith.Parameters(
//					(string)hash_in[DBUtilities_connectionString.ParameterName.Server],
//					(string)hash_in[DBUtilities_connectionString.ParameterName.User], 
//					"somepassword",
//					(string)hash_in[DBUtilities_connectionString.ParameterName.DBName], 
//					(DBServerTypes)i
//				);

//				_enumerator = hash_in.GetEnumerator();
//				while (_enumerator.MoveNext()) {
//					Assert.AreEqual(
////						Console.WriteLine(
////"'{0}'\n'{1}'\n{2}\n",
//						(string)_enumerator.Value, 
//						DBUtilities_connectionString.ParseParameter(
//							_constring,
//							(DBServerTypes)i,
//							(DBUtilities_connectionString.ParameterName)_enumerator.Key
//						)
////, _constring
//					);
//				}
//			}
//		}
//		#endregion

//#if NUnit
//		[Test]
//#else
//		[TestMethod]
//#endif
//		public void UT_Connectionstring_ParseParameter_ItTriggersAKnownBUG() {
//			Hashtable _hash;

//			_hash  = new Hashtable();
//			_hash.Add(DBUtilities_connectionString.ParameterName.DBName, "somedb");
//			_hash.Add(DBUtilities_connectionString.ParameterName.Server, "someserver");
//			_hash.Add(DBUtilities_connectionString.ParameterName.User, "someuser");
//			UT_Connectionstring_ParseParameter_auxiliar(_hash);

//			_hash = new Hashtable();
//			_hash.Add(DBUtilities_connectionString.ParameterName.DBName, "database");
//			_hash.Add(DBUtilities_connectionString.ParameterName.Server, "server");
//			_hash.Add(DBUtilities_connectionString.ParameterName.User, "uid");
//			UT_Connectionstring_ParseParameter_auxiliar(_hash);

//			Assert.AreEqual(
//				"somedatabase", 
//				DBUtilities_connectionString.ParseParameter(
//					"Server=someserver;User ID=someuser;Password=somepassword;Database=somedatabase",
//					DBServerTypes.PostgreSQL,
//					DBUtilities_connectionString.ParameterName.DBName
//				)
//			);
//			Assert.AreEqual(
//				"somedatabase",
//				DBUtilities_connectionString.ParseParameter(
//					"Database=somedatabase;Server=someserver;User ID=someuser;Password=somepassword",
//					DBServerTypes.PostgreSQL,
//					DBUtilities_connectionString.ParameterName.DBName
//				)
//			);
//			Assert.AreEqual(
//				"somedatabase",
//				DBUtilities_connectionString.ParseParameter(
//					"Database=somedatabase",
//					DBServerTypes.PostgreSQL,
//					DBUtilities_connectionString.ParameterName.DBName
//				)
//			);
//			Assert.AreEqual(
//				"somedatabase",
//				DBUtilities_connectionString.ParseParameter(
//					"Database=somedatabase;",
//					DBServerTypes.PostgreSQL,
//					DBUtilities_connectionString.ParameterName.DBName
//				)
//			);
//		}
//		#endregion

		#region public void UT_DBType2NUnitTestValue();
#if NUnit
		[Test]
#else
		[TestMethod]
#endif
		public void UT_DBType2NUnitTestValue() {

			// ToDos: here!
			// SQLServer
			// between 1/1/1753 12:00:00 AM and 12/31/9999 11:59:59 PM

			Assert.AreEqual(
				"new DateTime(2341, 12, 12)", 
					OGen.Libraries.DataLayer.DBUtilities_convert.DBType2NUnitTestValue(
					DbType.DateTime
				)
			);
		}
		#endregion
	}
}
#endif