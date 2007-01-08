#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;

using OGen.lib.datalayer;

namespace OGen.lib.generator {
	public class DBConnectionstring : IDisposable {
		#region public DBConnectionstring(...);
		public DBConnectionstring(
			eDBServerTypes dbServerType_in, 
			string connectionstring_in
		) {
			dbservertype_ = dbServerType_in;
			connectionstring_ = connectionstring_in;
			connection_ = null;
		}
		~DBConnectionstring() {
			cleanUp();
		}
		/// <summary>
		/// Closes Connection if it was left open.
		/// </summary>
		public void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();
		}
		private void cleanUp() {
			Connection_clearInstance();
		}
		#endregion

		#region internal cDBConnection Connection { get; set; }
		private cDBConnection connection_;
		internal cDBConnection Connection {
			get { return connection_; }
			set { connection_ = value; }
		}
		#endregion

		/// <summary>
		/// IMPORTANT NOTICE - VERY UNSTABLE AUXILIAR VARIABLE
		/// </summary>
		internal bool enabled_aux__;

		/// <summary>
		/// IMPORTANT NOTICE - VERY UNSTABLE AUXILIAR VARIABLE
		/// </summary>
		internal bool exists_aux__;

		#region public eDBServerTypes DBServerType { get; set; }
		private eDBServerTypes dbservertype_;
		public eDBServerTypes DBServerType {
			get { return dbservertype_; }
			set { dbservertype_ = value; }
		}
		#endregion
		#region public string Connectionstring { get; set; }
		private string connectionstring_;
		public string Connectionstring {
			get { return connectionstring_; }
			set { connectionstring_ = value; }
		}
		#endregion

		#region internal void Connection_createInstance();
		internal void Connection_createInstance() {
			connection_ = new cDBConnection(
				dbservertype_, 
				connectionstring_
			);
		}
		#endregion
		#region internal void Connection_clearInstance();
		internal void Connection_clearInstance() {
			if (connection_ == null) return;
			connection_.Dispose();
			connection_ = null;
		}
		#endregion
	}
}