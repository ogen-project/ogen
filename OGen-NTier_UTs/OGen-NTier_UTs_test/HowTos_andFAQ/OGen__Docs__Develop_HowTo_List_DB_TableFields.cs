// Copyright (C) 2002 Francisco Monteiro
using System;

using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_List_DB_TableFields {
		public HowTo_List_DB_TableFields() {
			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// you now have a cDBTableField array populated with all
			// field names and other properties for specified table
			DBTableField[] _fields = _con.getTableFields("User");

			for (int f = 0; f < _fields.Length; f++) {
				Console.WriteLine(
					"field name: {0}\nis PK: {1}\nis Identity: {2}\nis nullable: {3}", 
					_fields[f].Name, 
					_fields[f].isPK, 
					_fields[f].isIdentity, 
					_fields[f].isNullable
				);
			}

			_con.Dispose(); _con = null;
		}
	}
}