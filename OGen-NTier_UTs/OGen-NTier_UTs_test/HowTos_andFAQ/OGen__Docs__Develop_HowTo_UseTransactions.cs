// Copyright (C) 2002 Francisco Monteiro
using System;

using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	public class HowTo_UseTransactions {
		public HowTo_UseTransactions() {
			long _iduser = 0L;

			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// before beginning a transaction we need to open the connection
			_con.Open();

			try {
				// beginning transaction
				_con.Transaction.Begin();

				// performing some operations on db
				_con.Execute_SQLQuery(
					string.Format(
						"delete from \"User\" where \"IDUser\" = {0}",
						_iduser.ToString()
					)
				);

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