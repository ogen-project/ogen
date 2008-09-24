// Copyright (C) 2002 Francisco Monteiro
using System;
using System.Data;

using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_Execute_SQLFunction_returnDataTable {
		public HowTo_Execute_SQLFunction_returnDataTable() {
			long _idgroup_search = 1L;

			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// set your function parameters
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_con.newDBDataParameter(
					"IDGroup_search_", 
					DbType.Int64, 
					ParameterDirection.Input, 
					_idgroup_search, 
					0
				)
			};

			// you now have a DataTable populated
			// with results from your sql function
			DataTable _datatable 
				= _con.Execute_SQLFunction_returnDataTable(
					"sp0_User_Record_open_byGroup_fullmode", 
					_dataparameters
				);

			_con.Dispose(); _con = null;
		}
	}
}