// Copyright (C) 2002 Francisco Monteiro

using System;
using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_List_DB_Tables {
		public HowTo_List_DB_Tables() {
			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// you now have a cDBTable array populated with all
			// table names and other properties for your database
			DBTable[] _tables = _con.getTables();

			for (int t = 0; t < _tables.Length; t++)
				Console.WriteLine(
					"table name: {0}\nis this a view and not a table: {1}", 
					_tables[t].Name, 
					_tables[t].isVirtualTable
				);

			_con.Dispose(); _con = null;
		}
	}
}