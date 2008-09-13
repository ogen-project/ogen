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
using NUnit.Framework;

using OGen.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.UTs {
	[TestFixture]
	public class UT_UserGroup : UT0_UserGroup {
		public UT_UserGroup() {}

		private string testid_;

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			testid_ = DateTime.Now.Ticks.ToString();// Guid.NewGuid().ToString();
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
		}
		#endregion

		#region public void UT_NullableFields();
		[Test]
		public void UT_NullableFields() {
			bool _contraint;
			long _iduser;
			long _idgroup;

			for (int c = 0; c < UT0__utils.DBConnections.Length; c++) {
//Console.WriteLine("UT_NullableFields: {0}", DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c]).ToString());

				UT0__utils.DBConnections[c].Open();
				UT0__utils.DBConnections[c].Transaction.Begin();

				#region _iduser = new DO_User(UT0__utils.DBConnections[c]).insObject(true);
				DO_User _user = new DO_User(UT0__utils.DBConnections[c]);
				_user.Fields.Login = testid_;
				_user.Fields.Password = testid_;
				_iduser = _user.insObject(true, out _contraint);
				_user.Dispose(); _user = null;
				#endregion
				#region _idgroup = new DO_Group(UT0__utils.DBConnections[c]).insObject(true);
				DO_Group _group = new DO_Group(UT0__utils.DBConnections[c]);
				_group.Fields.Name = testid_;
				_idgroup = _group.insObject(true);
				_group.Dispose(); _group = null;
				#endregion

				DO_UserGroup _usergroup = new DO_UserGroup(UT0__utils.DBConnections[c]);
				_usergroup.Fields.IDUser = _iduser;
				_usergroup.Fields.IDGroup = _idgroup;
				_usergroup.Fields.Relationdate_isNull = true;
				_usergroup.Fields.Defaultrelation_isNull = true;
				_usergroup.setObject(true);

				#region test1...
				_usergroup.clrObject();
				_usergroup.getObject(_iduser, _idgroup);
				Assert.IsTrue(_usergroup.Fields.Relationdate_isNull, "DO_UserGroup.Relationdate expected to be nullable ({0})", DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c]));
				Assert.IsTrue(_usergroup.Fields.Defaultrelation_isNull, "DO_UserGroup.Defaultrelation expected to be nullable ({0})", DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c]));
				#endregion
				#region test2...
				_usergroup.Record.Open_byUser_Defaultrelation(
					_iduser,
					null
				);
				while (_usergroup.Record.Read()) {
					Assert.IsTrue(_usergroup.Fields.Relationdate_isNull, "DO_UserGroup.Relationdate expected to be nullable ({0})", DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c]));
					Assert.IsTrue(_usergroup.Fields.Defaultrelation_isNull, "DO_UserGroup.Defaultrelation expected to be nullable ({0})", DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c]));
				}
				_usergroup.Record.Close();
				#endregion
				#region test3...
				Assert.IsTrue(
					_usergroup.Record.hasObject_byUser_Defaultrelation(
						_iduser,
						_idgroup,
						_iduser,
						null
					), 
					"test error: 1 ({0})", 
					DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c])
				);
				Assert.AreEqual(
					1L,
					_usergroup.Record.Count_byUser_Defaultrelation(
						_iduser,
						null
					), 
					"test error: 2 ({0})", 
					DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c])
				);
				#endregion
				#region test4...
				DateTime _now = DateTime.Now;
				_usergroup.Record.Update_SomeUpdateTest_byUser_Defaultrelation(
					_iduser,
					null,
					_now
				);

				Assert.IsTrue(
					_usergroup.Record.hasObject_byUser_Defaultrelation(
						_iduser,
						_idgroup,
						_iduser,
						_now
					), 
					"test error: 3 ({0})", 
					DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c])
				);
				Assert.AreEqual(
					1L,
					_usergroup.Record.Count_byUser_Defaultrelation(
						_iduser,
						_now
					), 
					"test error: 4 ({0})", 
					DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c])
				);
				#endregion

				_usergroup.Dispose(); _usergroup = null;

				UT0__utils.DBConnections[c].Transaction.Rollback();
				UT0__utils.DBConnections[c].Transaction.Terminate();
				UT0__utils.DBConnections[c].Close();
			}
		}
		#endregion
		#region public void UT_bugPostgreSQL_noFunctionMatchesTheGivenNameAndArgumentTypes();
		/// <summary>
		/// exception: Npgsql.NpgsqlException: function sp0_UserGroup_setObject(bigint, bigint, timestamp with time zone, boolean) does not exist
		/// Severity: ERROR 
		/// Code: 42883
		/// 
		/// Read OGen_DOC_ToDos__bugs.txtab about this bug
		/// </summary>
		[Test]
		public void UT_bugPostgreSQL_noFunctionMatchesTheGivenNameAndArgumentTypes() {
			bool _contraint;
			long _iduser;
			long _idgroup;

			for (int c = 0; c < UT0__utils.DBConnections.Length; c++) {
//Console.WriteLine("UT_NullableFields: {0}", DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c]).ToString());

				UT0__utils.DBConnections[c].Open();
				UT0__utils.DBConnections[c].Transaction.Begin();

				#region _iduser = new DO_User(UT0__utils.DBConnections[c]).insObject(true);
				DO_User _user = new DO_User(UT0__utils.DBConnections[c]);
				_user.Fields.Login = testid_;
				_user.Fields.Password = testid_;
				_iduser = _user.insObject(true, out _contraint);
				_user.Dispose(); _user = null;
				#endregion
				#region _idgroup = new DO_Group(UT0__utils.DBConnections[c]).insObject(true);
				DO_Group _group = new DO_Group(UT0__utils.DBConnections[c]);
				_group.Fields.Name = testid_;
				_idgroup = _group.insObject(true);
				_group.Dispose(); _group = null;
				#endregion

				DO_UserGroup _usergroup = new DO_UserGroup(UT0__utils.DBConnections[c]);
				_usergroup.Fields.IDUser = _iduser;
				_usergroup.Fields.IDGroup = _idgroup;
				_usergroup.Fields.Relationdate_isNull = true;
				_usergroup.Fields.Defaultrelation_isNull = true;
				try {
					_usergroup.setObject(true);
				} catch {
					Assert.Fail(
						"test error: 1 ({0})",
						DBConnectionsupport.GetDBServerType(UT0__utils.DBConnections[c])
					);
				}
				_usergroup.Dispose(); _usergroup = null;

				UT0__utils.DBConnections[c].Transaction.Rollback();
				UT0__utils.DBConnections[c].Transaction.Terminate();
				UT0__utils.DBConnections[c].Close();
			}
		}
		#endregion
	}
}
