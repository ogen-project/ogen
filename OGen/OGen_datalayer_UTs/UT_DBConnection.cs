//#region Copyright (C) 2002 Francisco Monteiro
///*

//OGen
//Copyright (C) 2002 Francisco Monteiro

//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

//*/
//#endregion
//using System;
//using System.Data;
//using System.Collections;
//using NUnit.Framework;

//using OGen.lib.datalayer;

//#if PostgreSQL
//namespace OGen.lib.datalayer.UTs {
//    [TestFixture]
//    public class UT_DBConnection { public UT_DBConnection() {}
//        private DBConnection[] dbconnections_;
//        private string dbname_;
//        private string testid_;
//        #region private void Execute_SQL__insert(DBConnection dbconnections_in);
//        private void Execute_SQL__insert(DBConnection dbconnections_in) {
//            switch ((DBServerTypes)Enum.Parse(typeof(DBServerTypes), dbconnections_in.DBServerType)) {
//                case DBServerTypes.SQLServer:
//                case DBServerTypes.PostgreSQL: {
//                    dbconnections_in.Execute_SQLQuery(string.Format(
//                        "insert into \"User\" (\"Login\", \"Password\") values ('test-{0}', 'password')",
//                        testid_
//                    ));
//                    break;
//                }
//                default: {
//                    throw new Exception(
//                        string.Format(
//                            "unsuported db type: {0}",
//                            dbconnections_in.DBServerType.ToString()
//                        )
//                    );
//                }
//            }
//        }
//        #endregion
//        #region private void Execute_SQL__delete(DBConnection dbconnections_in);
//        private void Execute_SQL__delete(DBConnection dbconnections_in) {
//            switch ((DBServerTypes)Enum.Parse(typeof(DBServerTypes), dbconnections_in.DBServerType)) {
//                case DBServerTypes.SQLServer:
//                case DBServerTypes.PostgreSQL: {
//                        dbconnections_in.Execute_SQLQuery(string.Format(
//                        "delete from \"User\" where \"Login\" = 'test-{0}'",
//                        testid_
//                    ));
//                    break;
//                }
//                default: {
//                    throw new Exception(
//                        string.Format(
//                            "unsuported db type: {0}",
//                            dbconnections_in.DBServerType.ToString()
//                        )
//                    );
//                }
//            }
//        }
//        #endregion
//        #region private DataTable Execute_SQL__select(DBConnection dbconnections_in);
//        private DataTable Execute_SQL__select(DBConnection dbconnections_in) {
//            switch ((DBServerTypes)Enum.Parse(typeof(DBServerTypes), dbconnections_in.DBServerType)) {
//                case DBServerTypes.SQLServer:
//                case DBServerTypes.PostgreSQL: {
//                    return dbconnections_in.Execute_SQLQuery_returnDataTable(string.Format(
//                        "select \"IDUser\", \"Login\", \"Password\" from \"User\" where \"Login\" = 'test-{0}'",
//                        testid_
//                    ));
//                }
//                default: {
//                    throw new Exception(
//                        string.Format(
//                            "unsuported db type: {0}",
//                            dbconnections_in.DBServerType.ToString()
//                        )
//                    );
//                }
//            }
//        }
//        #endregion

//        #region public void TestFixtureSetUp();
//        [TestFixtureSetUp]
//        public void TestFixtureSetUp() {
//            testid_ = DateTime.Now.Ticks.ToString();// Guid.NewGuid().ToString();
//            dbname_ = System.Configuration.ConfigurationSettings.AppSettings["DBName"];
//            //---
//            DBServerTypes _dbtype;
//            DBServerTypes[] _dbtypes = (DBServerTypes[])Enum.GetValues(typeof(DBServerTypes));
//            dbconnections_ = new DBConnection[_dbtypes.Length];
//            for (int d = 0; d < _dbtypes.Length; d++) {
//                _dbtype = _dbtypes[d];

//                dbconnections_[d] = DBConnectionsupport.CreateInstance(
//                    _dbtype,
//                    System.Configuration.ConfigurationSettings.AppSettings[
//                        string.Format("DBConnectionstring-{0}", _dbtypes[d])
//                    ]
//                );
//            }

//        }
//        #endregion
//        #region public void TestFixtureTearDown();
//        [TestFixtureTearDown]
//        public void TestFixtureTearDown() {
//            for (int d = 0; d < dbconnections_.Length; d++) {
//                dbconnections_[d].Dispose();
//                dbconnections_[d] = null;
//            }
//        }
//        #endregion

//        #region public void UT_getBDs();
//        [Test]
//        public void UT_getBDs() {
//            string[] _dbs;
//            bool _found;

//            for (int c = 0; c < dbconnections_.Length; c++) {
//                _dbs = dbconnections_[c].getDBs();
//                _found = false;
//                for (int d = 0; d < _dbs.Length; d++) {
//                    if (_dbs[d] == dbname_) {
//                        _found = true;
//                        break;
//                    }
//                }
//                Assert.IsTrue(_found, "can't find db name: {0}", dbname_);
//            }
//        }
//        #endregion
//        #region public void UT_getTables_getFields_andCheckMostThings();
//        [Test]
//        public void UT_getTables_getFields_andCheckMostThings() {
//            cDBTable[] _tables;
//            cDBTableField[] _fields;
//            int _tablesnum;
//            int _fieldsnum;

//            for (int c = 0; c < dbconnections_.Length; c++) {
//                #region dbconnections_[c].getTables("User%");
//                _tables = dbconnections_[c].getTables("User");
//                _tablesnum = 0;
//                for (int t = 0; t < _tables.Length; t++) {
//                    switch (_tables[t].Name) {
//                        case "User": {
//                                _tablesnum++;
//                                break;
//                            }
//                        case "UserGroup": {
//                                _tablesnum++;
//                                break;
//                            }
//                        default: {
//                                break;
//                            }
//                    }
//                }
//                Assert.IsTrue((_tablesnum >= 2), "at least 2 tables expected, could only find {0}", _tablesnum);
//                #endregion
//                #region dbconnections_[c].getTables();
//                _tables = dbconnections_[c].getTables();
//                _tablesnum = 0;
//                for (int t = 0; t < _tables.Length; t++) {
//                    switch (_tables[t].Name) {
//                        #region case "Config": { _tablesnum++; break; }
//                        case "Config": {
//                            _tablesnum++;

//                            _fields = dbconnections_[c].getTableFields(_tables[t].Name);
//                            _fieldsnum = 0;
//                            for (int f = 0; f < _fields.Length; f++) {
//                                switch (_fields[f].Name) {
//                                    #region case "Name": { _fieldsnum++; break; }
//                                    case "Name": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            _fields[f].isPK, 
//                                            "PK expected for table field: {0}.{1}", 
//                                            _tables[t].Name, 
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Config": { _fieldsnum++; break; }
//                                    case "Config": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Type": { _fieldsnum++; break; }
//                                    case "Type": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                }
//                            }
//                            Assert.AreEqual(3, _fieldsnum, "3 fields expected at table: '{0}', only {1} were found", _tables[t].Name, _fieldsnum);
//                            break;
//                        }
//                        #endregion
//                        #region case "Group": { _tablesnum++; break; }
//                        case "Group": {
//                            _tablesnum++;

//                            _fields = dbconnections_[c].getTableFields(_tables[t].Name);
//                            _fieldsnum = 0;
//                            for (int f = 0; f < _fields.Length; f++) {
//                                switch (_fields[f].Name) {
//                                    #region case "IDGroup": { _fieldsnum++; break; }
//                                    case "IDGroup": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            _fields[f].isPK && _fields[f].isIdentity, 
//                                            "PK and Identity expected for table field: {0}.{1}", 
//                                            _tables[t].Name, 
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Name": { _fieldsnum++; break; }
//                                    case "Name": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK && !_fields[f].isIdentity,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                }
//                            }
//                            Assert.AreEqual(2, _fieldsnum, "2 fields expected at table: '{0}', only {1} were found", _tables[t].Name, _fieldsnum);
//                            break;
//                        }
//                        #endregion
//                        #region case "User": { _tablesnum++; break; }
//                        case "User": {
//                            _tablesnum++;

//                            _fields = dbconnections_[c].getTableFields(_tables[t].Name);
//                            _fieldsnum = 0;
//                            for (int f = 0; f < _fields.Length; f++) {
//                                switch (_fields[f].Name) {
//                                    #region case "IDUser": { _fieldsnum++; break; }
//                                    case "IDUser": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            _fields[f].isPK && _fields[f].isIdentity, 
//                                            "PK and Identity expected for table field: {0}.{1}", 
//                                            _tables[t].Name, 
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Login": { _fieldsnum++; break; }
//                                    case "Login": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK && !_fields[f].isIdentity,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Password": { _fieldsnum++; break; }
//                                    case "Password": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK && !_fields[f].isIdentity,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                }
//                            }
//                            Assert.AreEqual(3, _fieldsnum, "3 fields expected at table: '{0}', only {1} were found", _tables[t].Name, _fieldsnum);
//                            break;
//                        }
//                        #endregion
//                        #region case "UserGroup": { _tablesnum++; break; }
//                        case "UserGroup": {
//                            _tablesnum++;

//                            _fields = dbconnections_[c].getTableFields(_tables[t].Name);
//                            _fieldsnum = 0;
//                            for (int f = 0; f < _fields.Length; f++) {
//                                switch (_fields[f].Name) {
//                                    #region case "IDUser": { _fieldsnum++; break; }
//                                    case "IDUser": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            _fields[f].isPK && !_fields[f].isIdentity, 
//                                            "PK and not Identity expected for table field: {0}.{1}", 
//                                            _tables[t].Name, 
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "IDGroup": { _fieldsnum++; break; }
//                                    case "IDGroup": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            _fields[f].isPK && !_fields[f].isIdentity,
//                                            "PK and not Identity expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Relationdate": { _fieldsnum++; break; }
//                                    case "Relationdate": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK && !_fields[f].isIdentity,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                    #region case "Defaultrelation": { _fieldsnum++; break; }
//                                    case "Defaultrelation": {
//                                        _fieldsnum++;

//                                        Assert.IsTrue(
//                                            !_fields[f].isPK && !_fields[f].isIdentity,
//                                            "PK / Identity not expected for table field: {0}.{1}",
//                                            _tables[t].Name,
//                                            _fields[f].Name
//                                        );
//                                        break;
//                                    }
//                                    #endregion
//                                }
//                            }
//                            Assert.AreEqual(4, _fieldsnum, "4 fields expected at table: '{0}', only {1} were found", _tables[t].Name, _fieldsnum);
//                            break;
//                        }
//                        #endregion
//                    }
//                }
//                Assert.AreEqual(4, _tablesnum, "4 tables expected, only {0} were found", _tablesnum);
//                #endregion
//            }
//        }
//        #endregion

//        #region public void UT_Execute_SQLQuery();
//        [Test]
//        public void UT_Execute_SQLQuery() {
//            string _login;
//            string _password;
//            long _iduser;
//            DataTable _datatable;

//            for (int c = 0; c < dbconnections_.Length; c++) {
//                Execute_SQL__insert(dbconnections_[c]);

//                _datatable = Execute_SQL__select(dbconnections_[c]);
//                Assert.AreEqual(1, _datatable.Rows.Count, "expected 1 row instead of {0}", _datatable.Rows.Count);

//                Assert.AreEqual(typeof(string), _datatable.Rows[0]["Login"].GetType(), "expected string type for Login field");
//                _login = (string)_datatable.Rows[0]["Login"];
//                Assert.AreEqual(typeof(string), _datatable.Rows[0]["Password"].GetType(), "expected string type for Password field");
//                _password = (string)_datatable.Rows[0]["Password"];
//                Assert.AreEqual(typeof(long), _datatable.Rows[0]["IDUser"].GetType(), "expected string type for IDUser field");
//                _iduser = (long)_datatable.Rows[0]["IDUser"];

//                Execute_SQL__delete(dbconnections_[c]);
//                _datatable = Execute_SQL__select(dbconnections_[c]);
//                Assert.AreEqual(0, _datatable.Rows.Count, "expected 0 rows instead of {0}", _datatable.Rows.Count);
//            }
//        }
//        #endregion
//        #region public void UT_Execute_SQLFunction_andCheckExistence();
//        [Test]
//        public void UT_Execute_SQLFunction_andCheckExistence() {
//            IDbDataParameter[] _dataparameters;

//            for (int c = 0; c < dbconnections_.Length; c++) {
//                Assert.IsTrue(dbconnections_[c].SQLFunction_exists("fnc0_User_isObject_byLogin"), "sql function: \"fnc0_User_isObject_byLogin\" doesn't exist");


//                Execute_SQL__insert(dbconnections_[c]);


//                _dataparameters = new IDbDataParameter[] {
//                    dbconnections_[c].newDBDataParameter(
//                        "Login_search_", 
//                        DbType.String, 
//                        ParameterDirection.Input, 
//                        string.Format("test-{0}", testid_), 
//                        50
//                    )
//                };
//                Assert.IsTrue(
//                    (bool)dbconnections_[c].Execute_SQLFunction(
//                        "fnc0_User_isObject_byLogin",
//                        _dataparameters,
//                        DbType.Boolean,
//                        0
//                    ), 
//                    "user: '{0}' should exist",
//                    (string)_dataparameters[0].Value
//                );


//                Execute_SQL__delete(dbconnections_[c]);


//                _dataparameters = new IDbDataParameter[] {
//                    dbconnections_[c].newDBDataParameter(
//                        "Login_search_", 
//                        DbType.String, 
//                        ParameterDirection.Input, 
//                        string.Format("test-{0}", testid_), 
//                        50
//                    )
//                };
//                Assert.IsFalse(
//                    (bool)dbconnections_[c].Execute_SQLFunction(
//                        "fnc0_User_isObject_byLogin",
//                        _dataparameters,
//                        DbType.Boolean,
//                        0
//                    ),
//                    "user: '{0}' should NOT exist",
//                    (string)_dataparameters[0].Value
//                );
//            }
//        }
//        #endregion
//        #region public void UT_Execute_SQLStoredProcedure_andCheckExistence();
//        [Test]
//        public void UT_Execute_SQLStoredProcedure_andCheckExistence() {
//            IDbDataParameter[] _dataparameters;

//            for (int c = 0; c < dbconnections_.Length; c++) {
//                switch ((DBServerTypes)Enum.Parse(typeof(DBServerTypes), dbconnections_[c].DBServerType)) {
//                    case DBServerTypes.SQLServer: {
//                        Assert.IsTrue(dbconnections_[c].SQLStoredProcedure_exists("sp0_User_getObject_byLogin"), "sql stored procedure: \"sp0_User_getObject_byLogin\" doesn't exist at {0}", dbconnections_[c].DBServerType.ToString());
//                        break;
//                    }
//                    case DBServerTypes.PostgreSQL: {
//                        Assert.IsTrue(dbconnections_[c].SQLFunction_exists("sp0_User_getObject_byLogin"), "sql function: \"sp0_User_getObject_byLogin\" doesn't exist at {0}", dbconnections_[c].DBServerType.ToString());
//                        break;
//                    }
//                }
				


//                Execute_SQL__insert(dbconnections_[c]);
//                _dataparameters = new IDbDataParameter[] {
//                    dbconnections_[c].newDBDataParameter("Login_search_", DbType.String, ParameterDirection.Input, string.Format("test-{0}", testid_), 50), 
//                    dbconnections_[c].newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Output, null, 0), 
//                    dbconnections_[c].newDBDataParameter("Login", DbType.String, ParameterDirection.Output, null, 50), 
//                    dbconnections_[c].newDBDataParameter("Password", DbType.String, ParameterDirection.Output, null, 50), 
//                    dbconnections_[c].newDBDataParameter("SomeNullValue", DbType.Int32, ParameterDirection.Output, null, 0)
//                };
//                dbconnections_[c].Execute_SQLFunction(
//                    "sp0_User_getObject_byLogin", 
//                    _dataparameters
//                );
//                Assert.IsTrue(
//                    (
//                        (_dataparameters[1].Value != DBNull.Value)
//                        &&
//                        (_dataparameters[2].Value != DBNull.Value)
//                        &&
//                        (_dataparameters[3].Value != DBNull.Value)
//                    ),
//                    "can't find or retrieve output values from \"sp0_User_getObject_byLogin\""
//                );
//                Assert.AreEqual(
//                    string.Format("test-{0}", testid_), 
//                    (string)_dataparameters[2].Value,
//                    "unexpected value for Login field: {0}",
//                    (string)_dataparameters[2].Value
//                );
//                Assert.AreEqual(
//                    "password",
//                    (string)_dataparameters[3].Value,
//                    "unexpected value for Password field: {0}",
//                    (string)_dataparameters[3].Value
//                );


//                Execute_SQL__delete(dbconnections_[c]);
//                _dataparameters = new IDbDataParameter[] {
//                    dbconnections_[c].newDBDataParameter("Login_search_", DbType.String, ParameterDirection.Input, string.Format("test-{0}", testid_), 50), 
//                    dbconnections_[c].newDBDataParameter("IDUser", DbType.Int64, ParameterDirection.Output, null, 0), 
//                    dbconnections_[c].newDBDataParameter("Login", DbType.String, ParameterDirection.Output, null, 50), 
//                    dbconnections_[c].newDBDataParameter("Password", DbType.String, ParameterDirection.Output, null, 50), 
//                    dbconnections_[c].newDBDataParameter("SomeNullValue", DbType.Int32, ParameterDirection.Output, null, 0)
//                };
//                dbconnections_[c].Execute_SQLFunction(
//                    "sp0_User_getObject_byLogin", 
//                    _dataparameters
//                );
//                Assert.IsTrue(
//                    (
//                        (_dataparameters[1].Value == DBNull.Value)
//                        &&
//                        (_dataparameters[2].Value == DBNull.Value)
//                        &&
//                        (_dataparameters[3].Value == DBNull.Value)
//                    ),
//                    "unexpectedly retrieved output values from \"sp0_User_getObject_byLogin\""
//                );
//            }
//        }
//        #endregion

//        #region public void UT_Transaction_Rollback();
//        [Test]
//        public void UT_Transaction_Rollback() {
//            for (int c = 0; c < dbconnections_.Length; c++) {
//                dbconnections_[c].Open();
//                dbconnections_[c].Transaction.Begin();

//                Execute_SQL__insert(dbconnections_[c]);

//                dbconnections_[c].Transaction.Rollback();
//                dbconnections_[c].Transaction.Terminate();

//                Assert.AreEqual(
//                    0, 
//                    Execute_SQL__select(dbconnections_[c]).Rows.Count, 
//                    "transaction rollback failed somehow, changes to db have been commited"
//                );

//                dbconnections_[c].Close();
//            }
//        }
//        #endregion
//        #region public void UT_Transaction_Commit();
//        [Test]
//        public void UT_Transaction_Commit() {
//            for (int c = 0; c < dbconnections_.Length; c++) {
//                dbconnections_[c].Open();
//                dbconnections_[c].Transaction.Begin();

//                Execute_SQL__insert(dbconnections_[c]);

//                dbconnections_[c].Transaction.Commit();
//                dbconnections_[c].Transaction.Terminate();

//                Assert.AreEqual(
//                    1, 
//                    Execute_SQL__select(dbconnections_[c]).Rows.Count, 
//                    "transaction commit failed somehow"
//                );

//                Execute_SQL__delete(dbconnections_[c]);

//                dbconnections_[c].Close();
//            }
//        }
//        #endregion
//        #region public void UT_Connection_Open_andClose();
//        [Test]
//        public void UT_Connection_Open_andClose() {
//            for (int c = 0; c < dbconnections_.Length; c++) {
//                dbconnections_[c].Open();
//                Assert.AreEqual(
//                    ConnectionState.Open, 
//                    dbconnections_[c].exposeConnection.State, 
//                    "connection expected to be opened, instead it's: {0}", 
//                    dbconnections_[c].exposeConnection.State.ToString()
//                );

//                dbconnections_[c].Close();
//                //Assert.AreEqual(
//                //	ConnectionState.Closed, 
//                //	dbconnections_[c].exposeConnection.State, 
//                //	"connection expected to be closed, instead it's: {0}", 
//                //	dbconnections_[c].exposeConnection.State.ToString()
//                //);
//            }
//        }
//        #endregion
////		#region public void UT_Connection_SQLFunction_exists_and_delete();
////		[Test]
////		public void UT_Connection_SQLFunction_exists_and_delete() {
////			for (int c = 0; c < dbconnections_.Length; c++) {
////				switch (dbconnections_[c].DBServerType) {
////					case DBServerTypes.PostgreSQL: {
////						break;
////					}
////					case DBServerTypes.SQLServer: {
////						break;
////					}
////					default: {
////						throw new Exception(string.Format("tests need to be made to support db server type: '{0}'", dbconnections_[c].DBServerType));
////					}
////				}
////			}
////		}
////		#endregion
//    }
//}
//#endif
