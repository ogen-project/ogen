// Copyright (C) 2002 Francisco Monteiro

using System;
using System.Data;
using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_Execute_SQLQuery_returnDataTable {
		public HowTo_Execute_SQLQuery_returnDataTable() {
			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// you now have a DataTable populated
			// with results from your sql query
			DataTable _datatable 
				= _con.Execute_SQLQuery_returnDataTable(
					"select * from \"User\""
				);

			_con.Dispose(); _con = null;
		}
	}
}