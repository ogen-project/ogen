// Copyright (C) 2002 Francisco Monteiro
using System;
using System.Data;

using OGen.lib.datalayer;

namespace OGen.UTs.howtos {
	class HowTo_Execute_SQLFunction_returnSomevalue {
		public HowTo_Execute_SQLFunction_returnSomevalue() {
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

			// call you function and get returning value
			bool _result = (bool)_con.Execute_SQLFunction(
				"fnc0_User_isObject", 
				_dataparameters, 
				DbType.Boolean, // returning value db type
				0 // returning value size, if applicable
			);

			_con.Dispose(); _con = null;
		}
	}
}