// Copyright (C) 2002 Francisco Monteiro

using System;
using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_List_DBs {
		public HowTo_List_DBs() {
			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// you now have a string array populated with all
			// databases (except system ones) at you db server
			string[] _dbs = _con.getDBs();

			_con.Dispose(); _con = null;
		}
	}
}