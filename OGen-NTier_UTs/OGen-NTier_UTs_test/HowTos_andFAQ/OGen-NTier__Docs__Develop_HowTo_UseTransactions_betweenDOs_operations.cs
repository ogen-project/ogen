// Copyright (C) 2002 Francisco Monteiro

using System;
using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.howtos {
	public class HowTo_UseTransactions_betweenDOs_operations {
		public HowTo_UseTransactions_betweenDOs_operations() {
			string _testid = DateTime.Now.Ticks.ToString();
			bool _constraint;
			long _iduser;
			long _idgroup;

			// we need a shared connection between Data Objects
			DBConnection _con = DO__utils.DBConnection_createInstance(
				DO__utils.DBServerType, 
				DO__utils.DBConnectionstring, 
				string.Empty
			);

			// before beginning a transaction we need to open the connection
			_con.Open();
			try {
				// beginning transaction
				_con.Transaction.Begin();

				// sharing connection with User Data Object
				DO_User _user = new DO_User(_con);
				// performing some operations on User Data Object
				_user.Fields.Login = _testid;
				_user.Fields.Password = _testid;
				_iduser = _user.insObject(true, out _constraint);
				// handling constraint code should be added here
				_user.Dispose(); _user = null;

				// sharing connection with Group Data Object
				DO_Group _group = new DO_Group(_con);
				// performing some operations on User Data Object
				_group.Fields.Name = _testid;
				_idgroup = _group.insObject(true);
				_group.Dispose(); _group = null;

				// sharing connection with Group Data Object
				DO_UserGroup _usergroup = new DO_UserGroup(_con);
				// performing some operations on User Data Object
				_usergroup.Fields.IDGroup = _idgroup;
				_usergroup.Fields.IDUser = _iduser;
				_usergroup.Fields.Relationdate = DateTime.Now;
				_usergroup.Fields.Defaultrelation = false;
				_usergroup.setObject(false);
				_usergroup.Dispose(); _usergroup = null;

				// commit transaction
				_con.Transaction.Commit();
			} catch (Exception _ex) {
				// rollback transaction
				_con.Transaction.Rollback();
			} finally {
				// terminate transaction
				_con.Transaction.Terminate();
			}
			// closing connection
			_con.Close();
			_con.Dispose(); _con = null;
		}
	}
}