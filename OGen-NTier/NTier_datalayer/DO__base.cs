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
using System.Data;

using OGen.lib.datalayer;

namespace OGen.NTier.lib.datalayer {
	/// <summary>
	/// base implementation class for DataObject classes.
	/// </summary>
	public abstract class DO__base : IDisposable {
//		#region public DO__base(...);
		/// <param name="connection_in">DB Connection</param>
		public DO__base(
			cDBConnection	connection_in
		) : this (
			connection_in, 
			eDBServerTypes.invalid, 
			string.Empty, 
			false, // connection_insideInstance_in
			null
		) {}
		/// <param name="dbServerType_in">DB Server Type</param>
		/// <param name="connectionstring_in">Connection String</param>
		public DO__base(
			eDBServerTypes	dbServerType_in, 
			string			connectionstring_in
		) : this (
			null, 
			dbServerType_in, 
			connectionstring_in, 
			true, // connection_insideInstance_in
			null
		) {}
		public DO__base(
			eDBServerTypes		dbServerType_in, 
			string				connectionstring_in, 
			string				logfile_in
		) : this (
			null, 
			dbServerType_in, 
			connectionstring_in, 
			true, // connection_insideInstance_in
			logfile_in
		) {}
		private DO__base(
			cDBConnection		connection_in, 
			eDBServerTypes		dbServerType_in, 
			string				connectionstring_in, 
			bool				connection_insideInstance_in,
			string				logfile_in
		) {
			connection_ = connection_in;
			connection_dbservertype_ = dbServerType_in;
			connection_connectionstring_ = connectionstring_in;
			connection_insideinstance_ = connection_insideInstance_in;

			if (logfile_in == null) {
				logenabled_ = false;
				logfile_ = null;
			} else {
				logenabled_ = true;
				logfile_ = logfile_in;
			}
		}
		///
		~DO__base() {
			cleanUp();
		}
		/// <summary>
		/// Disposes any instantiated Connection.
		/// </summary>
		public void Dispose() {
			System.GC.SuppressFinalize(this);
			cleanUp();
		}
		private void cleanUp() {
			if (connection_insideinstance_) {
				if (connection_ != null) {
					connection_.Dispose(); connection_ = null;
				}
			}
		}
//		#endregion

		//#region Properties...
//		#region public cDBConnection Connection { get; }
		private bool			connection_insideinstance_;
		private eDBServerTypes	connection_dbservertype_;
		private string			connection_connectionstring_;
		private cDBConnection	connection_;
		private bool			logenabled_;
		private string			logfile_;
		/// <summary>
		/// DB Connection.
		/// </summary>
		public cDBConnection Connection {
			get {
				if (
					connection_insideinstance_
					&&
					(connection_ == null)
				) {
					// instantiating for the first time and
					// only because it became needed, otherwise
					// never instantiated...

					if (logenabled_) {
						connection_ = new cDBConnection(
							connection_dbservertype_,
							connection_connectionstring_,
							logfile_
						);
					} else {
						connection_ = new cDBConnection(
							connection_dbservertype_,
							connection_connectionstring_
						);
					}
				}
				return connection_;
			}
		}
//		#endregion
		//#endregion
	}
}