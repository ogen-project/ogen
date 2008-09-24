// Copyright (C) 2002 Francisco Monteiro

using System;
using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_Execute_SQLQuery {
		public HowTo_Execute_SQLQuery() {
			long _iduser = 0L;

			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// executing your sql query
			_con.Execute_SQLQuery(
				string.Format(
					"delete from \"User\" where \"IDUser\" = {0}", 
					_iduser.ToString()
				)
			);

			_con.Dispose(); _con = null;
		}
	}
}