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
using System.IO;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

using OGen.lib.datalayer;

using OGen.NTier.UTs.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer.UTs;
using OGen.NTier.UTs.lib.businesslayer;

namespace OGen.NTier.UTs.test {
	class MainClass {
		[STAThread]
		static void Main(string[] args) {
			//DO_UserGroup _usergroup_test = new DO_UserGroup(
			//    //new DBConnection(
			//    //    DBServerTypes.SQLServer,
			//    //    "server=127.0.0.1;uid=sa;pwd=passpub;database=OGen-NTier_UTs;"
			//    //)
			//);
			//_usergroup_test.IDGroup = 1;
			//_usergroup_test.IDUser = 1;
			//_usergroup_test.Relationdate_isNull = true;
			//_usergroup_test.Defaultrelation_isNull = true;
			//_usergroup_test.setObject(true);

			//OGen.NTier.UTs.lib.datalayer.UTs.UT__utils _ut_utils
			//    = new OGen.NTier.UTs.lib.datalayer.UTs.UT__utils();
			//_ut_utils.TestFixtureSetUp();
			//_ut_utils.UT_Check_DataObjects_integrity();
			//return;

			//OGen.NTier.UTs.lib.datalayer.UTs.UT_User _ut_user 
			//    = new OGen.NTier.UTs.lib.datalayer.UTs.UT_User();
			//_ut_user.TestFixtureSetUp();
			//_ut_user.UT_hasChanges();
			//return;


			//OGen.NTier.UTs.lib.datalayer.UTs.UT_UserGroup
			//	_ut_usergroup = new OGen.NTier.UTs.lib.datalayer.UTs.UT_UserGroup();
			//_ut_usergroup.TestFixtureSetUp();
			//_ut_usergroup.UT_bugPostgreSQL_noFunctionMatchesTheGivenNameAndArgumentTypes();
			////_ut_usergroup.UT_NullableFields();
			//return;


			//DO_Config _config_test = new DO_Config();
			//_config_test.Connection.Open();
			//_config_test.Connection.Transaction.Begin();
			//_config_test.Fields.Name = "test";
			//_config_test.Fields.Description = "test";
			//_config_test.Fields.Config = "test";
			//_config_test.Fields.Type = 1;
			//try {
			//	_config_test.setObject(true);
			//	Console.WriteLine("ok");
			//} catch {
			//	Console.WriteLine("ko");
			//}
			//_config_test.Connection.Transaction.Rollback();
			//_config_test.Connection.Transaction.Terminate();
			//_config_test.Connection.Close();
			//_config_test.Dispose();
			//return;
			



			const int _cycles = 50;
			DBConnection[] _cons = new DBConnection[] {
				#region new DBConnection(DBServerTypes.SQLServer, ...), 
				DBConnectionsupport.CreateInstance(
					DBServerTypes.SQLServer,
					
					DBUtilssupport.GetInstance(DBServerTypes.SQLServer).ConnectionString.Build(
						"127.0.0.1", 
						"sa", 
						"passpub", 
						"OGen-NTier_UTs"
					)
				), 
				#endregion
				#region new DBConnection(DBServerTypes.PostgreSQL, ...)
				DBConnectionsupport.CreateInstance(
					DBServerTypes.PostgreSQL,
					DBUtilssupport.GetInstance(DBServerTypes.PostgreSQL).ConnectionString.Build(
						"127.0.0.1", 
						"postgres", 
						"passpub", 
						"OGen-NTier_UTs"
					)
				)
				#endregion
			};

			long _conter = 0L;
			for (int _compiled = 0; _compiled < 2; _compiled++) {
				for (int _con = 0; _con < _cons.Length; _con++) {
					_cons[_con].Open();
					_cons[_con].Transaction.Begin();
					for (int _cached = 0; _cached < 2; _cached++) {
						DO_Config _config = new DO_Config(_cons[_con]);
						#region _config.setObject();
						_conter = DateTime.Now.Ticks;

						for (int c = 0; c < _cycles; c++) {
							_config.Fields.Name = c.ToString();
							_config.Fields.Config = "DELETE THIS, IT IS A TEST";
							_config.Fields.Type = 2;
							_config.setObject(true);
						}

						Console.WriteLine(
							"setObject()      \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);
						#endregion
						#region _config.Record.Open_...(false);
						_conter = DateTime.Now.Ticks;

						_config.Record.Open_all(false);
						while (_config.Record.Read()) ;
						_config.Record.Close();

						Console.WriteLine(
							"Record.Open()    \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);
						#endregion
						#region _config.delObject();
						_conter = DateTime.Now.Ticks;

						_config.Record.Open_all(true);
						while (_config.Record.Read()) {
							if (_config.Fields.Config == "DELETE THIS, IT IS A TEST") {
								_config.delObject();
							}
						}
						_config.Record.Close();

						Console.WriteLine(
							"delObject()      \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);
						#endregion
						#region _config.getObject();
						_conter = DateTime.Now.Ticks;

						_config.Fields.Name = "SomeIntConfig";
						_config.Fields.Config = "1245";
						_config.Fields.Type = 4;
						_config.setObject(true);

						for (int c = 0; c < _cycles; c++) {
							_config.getObject("SomeIntConfig");
						}

						Console.WriteLine(
							"getObject()      \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);
						#endregion
						_config.Dispose(); _config = null;
						//---
						DO_User _user = new DO_User(_cons[_con]);

						#region _user.insObject();
						_conter = DateTime.Now.Ticks;

						for (int c = 0; c < _cycles; c++) {
							bool _constraint;
							_user.Fields.Login = c.ToString();
							_user.Fields.Password = "DELETE THIS, IT IS A TEST";
							_user.insObject(true, out _constraint);
						}

						_user.Record.Open_all(true);
						while (_user.Record.Read()) {
							if (_user.Fields.Password == "DELETE THIS, IT IS A TEST") {
								_user.delObject();
							}
						}
						_user.Record.Close();

						Console.WriteLine(
							"insObject()      \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);
						#endregion

						_conter = DateTime.Now.Ticks;
						for (int c = 0; c < _cycles; c++) {
							if (!_user.isObject_byLogin("fmonteiro")) {
								bool _constraint;
								_user.Fields.Login = "fmonteiro";
								_user.Fields.Password = "passpub";
								_user.insObject(true, out _constraint);
							}
							_user.getObject_byLogin("fmonteiro");
						}
						Console.WriteLine(
							"getObject_by()   \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);

						_user.Dispose(); _user = null;
					}
					_cons[_con].Transaction.Rollback();
					_cons[_con].Transaction.Terminate();
					_cons[_con].Close();
				}
			}
			Console.WriteLine("Press any key to continue...");
			Console.ReadLine();
		}
	}
}
