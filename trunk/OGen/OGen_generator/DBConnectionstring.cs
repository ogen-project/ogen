#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.lib.generator {
	using System;

	using OGen.lib.datalayer;

	public class DBConnectionstring : DBSimpleConnectionstring, IDisposable {
		#region public DBConnectionstring(...);
		public DBConnectionstring(
			DBServerTypes dbServerType_in, 
			string connectionstring_in
		) : base (
			dbServerType_in, 
			connectionstring_in
		) {
			this.connection_ = null;
		}
		~DBConnectionstring() {
			this.Dispose(false);
		}
		/// <summary>
		/// Closes Connection if it was left open.
		/// </summary>
		public void Dispose() {
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing_in) {
			this.Connection_clearInstance();
		}
		#endregion

		#region internal DBConnection Connection { get; set; }
		private DBConnection connection_;

		internal DBConnection Connection {
			get { return this.connection_; }
			set { this.connection_ = value; }
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

		#region internal void Connection_createInstance();
		internal void Connection_createInstance() {
			this.connection_ = DBConnectionsupport.CreateInstance(
				this.dbservertype_,
				this.connectionstring_
			);
		}
		#endregion
		#region internal void Connection_clearInstance();
		internal void Connection_clearInstance() {
			if (this.connection_ == null) return;
			this.connection_.Dispose(); this.connection_ = null;
		}
		#endregion
	}
}
