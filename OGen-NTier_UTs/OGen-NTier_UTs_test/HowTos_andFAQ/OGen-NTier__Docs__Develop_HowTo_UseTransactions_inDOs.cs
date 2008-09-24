// Copyright (C) 2002 Francisco Monteiro
using System;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.howtos {
	public class HowTo_UseTransactions_inDOs {
		public HowTo_UseTransactions_inDOs() {
			string _testid = DateTime.Now.Ticks.ToString();
			bool _constraint;
			long _iduser;
			long _idgroup;

			DO_User _user = new DO_User();

			// before beginning a transaction we need to open the connection
			_user.Connection.Open();

			try {
				// beginning transaction
				_user.Connection.Transaction.Begin();

				// performing some operations on User Data Object
				_user.Fields.Login = _testid;
				_user.Fields.Password = _testid;
				_iduser = _user.insObject(true, out _constraint);
				// handling constraint code should be added here

				// commit transaction
				_user.Connection.Transaction.Commit();
			} catch (Exception _ex) {
				// rollback transaction
				_user.Connection.Transaction.Rollback();
			} finally {
				// terminate transaction
				_user.Connection.Transaction.Terminate();
			}

			// closing connection
			_user.Connection.Close();

			_user.Dispose(); _user = null;
		}
	}
}