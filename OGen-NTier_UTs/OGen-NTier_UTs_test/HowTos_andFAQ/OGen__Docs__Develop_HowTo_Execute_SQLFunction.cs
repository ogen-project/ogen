// Copyright (C) 2002 Francisco Monteiro

using System;
using System.Data;
using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_Execute_SQLFunction {
		public HowTo_Execute_SQLFunction() {
			long _iduser = 0L;

			DBConnection _con = DBConnectionsupport.CreateInstance(
				// set your db server type here
				DBServerTypes.PostgreSQL, 
				// and connectionstring
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;"
			);

			// set your function parameters
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				_con.newDBDataParameter(
					"IDUser_", 
					DbType.Int64, 
					ParameterDirection.Input, 
					_iduser, 
					0
				)
			};

			// call you function
			_con.Execute_SQLFunction(
				"sp0_User_delObject", 
				_dataparameters
			);

			_con.Dispose(); _con = null;
		}
	}
}