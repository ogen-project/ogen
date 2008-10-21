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
using OGen.NTier.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.NTier.UTs.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer.proxy;
using OGen.NTier.UTs.lib.datalayer.UTs;
using OGen.NTier.UTs.lib.businesslayer;
using WS_Authentication = OGen.NTier.UTs.lib.distributed.webservices.client.WS_Authentication;
using WS_User = OGen.NTier.UTs.lib.distributed.webservices.client.WS_User;

using OGen.NTier.UTs.lib.businesslayer.proxy;
using OGen.NTier.UTs.lib.distributed.remoting.client;

namespace OGen.NTier.UTs.test {
	class MainClass {
		[STAThread]
		static void Main(string[] args) {
			IBO_Authentication _authentication = null;
			IBO_User _user = null;
			string _login;

			for (int _provider = 0; _provider < 3; _provider++) {
				switch (_provider) {
					case 0:
						Console.WriteLine("--- remoting...");
						_authentication
							= new RC_Authentication(
								"tcp://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_Authentication.remoting"
								//"http://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_Authentication.soap"
							);
						_user
							= new RC_User(
								"tcp://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_User.remoting"
								//"http://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_User.soap"
							);
						break;
					case 1:
						Console.WriteLine("--- webservices...");
						_authentication
							= new WS_Authentication.WS_Authentication(
								"http://localhost:2937/WS_Authentication.asmx"
							);

						_user
							= new WS_User.WS_User(
								"http://localhost:2937/WS_User.asmx"
							);
						break;
					case 2:
						Console.WriteLine("--- assembly...");
						_authentication
							= new BO_Authentication(
							);

						_user
							= new BDO_User(
							);
						break;
				}

				Console.WriteLine(
					"authentication string: {0}\n", 
					_login = _authentication.Login(
						"fmonteiro", 
						"passpub"
					)
				);

				OGen.NTier.UTs.lib.datalayer.proxy.ISO_User _so_user 
					= new OGen.NTier.UTs.lib.datalayer.proxy.SO_User(
						0L,
						string.Format(
							"login-{0}", 
							Guid.NewGuid().ToString()
						),
						"password",
						0
					);
				_so_user.SomeNullValue_isNull = true;
				Console.WriteLine(
					"IDUser: {0}\nLogin: {1}\nPassword: {2}\nSomeNullValue: {3} (is null: {4})\n",
					_so_user.IDUser,
					_so_user.Login,
					_so_user.Password,
					_so_user.SomeNullValue, 
					_so_user.SomeNullValue_isNull
				);

				long _iduser;
				bool _constraintExists;
				Console.WriteLine(
					"IDUser: {0}\nConstraint Exists: {1}\n",
					_iduser =_user.insObject(
						(SO_User)_so_user,
						true, 
						_login, 
						out _constraintExists
					),
					_constraintExists
				);

				bool _exists;
				_so_user = _user.getObject(
					_iduser, 
					_login, 
					out _exists
				);
				Console.WriteLine(
					"IDUser: {0}\nLogin: {1}\nPassword: {2}\nSomeNullValue: {3} (is null: {4})\n",
					_so_user.IDUser,
					_so_user.Login,
					_so_user.Password,
					_so_user.SomeNullValue,
					_so_user.SomeNullValue_isNull
				);

				_authentication.Logout();
			}
			return;
















			//OGen.NTier.UTs.lib.businesslayer-2.0
			Assembly _assembly = Assembly.Load(
				#if NET_1_1
				"OGen.NTier.UTs.lib.businesslayer-1.1"
				#elif NET_2_0
				"OGen.NTier.UTs.lib.businesslayer-2.0"
				#endif
			);
			if (_assembly != null) {
				Type[] _types = _assembly.GetTypes();
				for (int t = 0; t < _types.Length; t++) {
					Type _type = (Type)_types[t];

					object[] _attibutes = _type.GetCustomAttributes(
						typeof(BOClassAttribute),
						true//false
					);
					if (
						(_attibutes.Length > 0)
						&&
						(_type.Name.IndexOf("BO0_") != 0)
						&&
						(_type.Name.IndexOf("BBO0_") != 0)
					) {
						Console.Write("{0};  ", _type.Name);

						for (int c = 0; c < _attibutes.Length; c++) {
							BOClassAttribute _attribute 
								= (BOClassAttribute)_attibutes[c];
Console.WriteLine(
	"name:{0};",
	_attribute.Name
);

							MethodInfo[] _methods = _type.GetMethods(
								BindingFlags.Public |
								BindingFlags.Instance
							);
							for (int m = 0; m < _methods.Length; m++) {
								if (Attribute.IsDefined(
									_methods[m],
									typeof(BOMethodAttribute)
								)) {
									Attribute[] _attributes = Attribute.GetCustomAttributes(
										_methods[m],
										typeof(BOMethodAttribute),
										true
									);

									for (int a = 0; a < _attributes.Length; a++) {
										//if (_attributes[a].GetType() == typeof(BOMethodAttribute)) {
										BOMethodAttribute _propertyattribute
											= (BOMethodAttribute)_attributes[a];
Console.WriteLine(
	"\tname:{0}; distribute:{1};",
	_propertyattribute.Name,
	_propertyattribute.Distribute
);
										//}
									}
									Console.WriteLine(
										"\t.{0}:{1}.{2}(",
										_methods[m].Name, 
										_methods[m].ReturnType.Namespace,
										_methods[m].ReturnType.Name
									);
									ParameterInfo[] _parameterinfo = _methods[m].GetParameters();
									for (int p = 0; p < _parameterinfo.Length; p++) {
Console.WriteLine(
	"\t\tname:{0}; type:{1}; isOut:{2}; isByRef:{3}; isEnum:{4}; isClass:{5}; isValueType:{6}", 
	_parameterinfo[p].Name, 
	_parameterinfo[p].ParameterType, 
	_parameterinfo[p].IsOut,
	_parameterinfo[p].ParameterType.IsByRef,
	_parameterinfo[p].ParameterType.IsEnum, 
	_parameterinfo[p].ParameterType.IsClass, 
	_parameterinfo[p].ParameterType.IsValueType
);
									}
									Console.WriteLine("\t)");
								}
							}
							Console.WriteLine();
						}
					}
				}
			}
			return;

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
				//#region new DBConnection(DBServerTypes.MySQL, ...)
				//, DBConnectionsupport.CreateInstance(
				//    DBServerTypes.MySQL,
				//    DBUtilssupport.GetInstance(DBServerTypes.MySQL).ConnectionString.Build(
				//        "127.0.0.1", 
				//        "root", 
				//        "passpub", 
				//        "OGen-NTier_UTs"
				//    )
				//)
				//#endregion
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

						_config.Record.Open_all();
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

						_config.Record.Open_all();
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
						DO_User _do_user = new DO_User(_cons[_con]);

						#region _do_user.insObject();
						_conter = DateTime.Now.Ticks;

						for (int c = 0; c < _cycles; c++) {
							bool _constraint;
							_do_user.Fields.Login = c.ToString();
							_do_user.Fields.Password = "DELETE THIS, IT IS A TEST";
							_do_user.insObject(true, out _constraint);
						}

						_do_user.Record.Open_all();
						while (_do_user.Record.Read()) {
							if (_do_user.Fields.Password == "DELETE THIS, IT IS A TEST") {
								_do_user.delObject();
							}
						}
						_do_user.Record.Close();

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
							if (!_do_user.isObject_byLogin("fmonteiro")) {
								bool _constraint;
								_do_user.Fields.Login = "fmonteiro";
								_do_user.Fields.Password = "passpub";
								_do_user.insObject(true, out _constraint);
							}
							_do_user.getObject_byLogin("fmonteiro");
						}
						Console.WriteLine(
							"getObject_by()   \t{0}\tcached:{1}\tcompiled:{2}\t{3}",
							DBConnectionsupport.GetDBServerType(_cons[_con]),
							(_cached == 1),
							(_compiled == 1),
							(DateTime.Now.Ticks - _conter).ToString()
						);

						_do_user.Dispose(); _do_user = null;
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