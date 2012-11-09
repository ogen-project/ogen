#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.DataLayer {
	using System;
	using System.Data;

	using OGen.Libraries.DataLayer;

	/// <summary>
	/// base implementation class for DataObject classes.
	/// </summary>
	public abstract class DO__base : IDisposable {
//		#region public DO__base(...);
		/// <summary>
		/// Initializes a new instance of <see cref="DO__base">DO__base</see>
		/// </summary>
		/// <param name="connection_in">DB Connection</param>
		protected DO__base(
			DBConnection connection_in
		) : this (
			connection_in, 
			connection_in.DBServerType, 
			connection_in.Connectionstring, 
			false, // connection_insideInstance_in
			null
		) {}
		/// <param name="dbServerType_in">DB Server Type</param>
		/// <param name="connectionString_in">Connection String</param>
		protected DO__base(
			string dbServerType_in, 
			string connectionString_in
		) : this (
			null, 
			dbServerType_in, 
			connectionString_in, 
			true, // connection_insideInstance_in
			null
		) {}
		protected DO__base(
			string dbServerType_in, 
			string connectionString_in, 
			string logFile_in
		) : this (
			null, 
			dbServerType_in, 
			connectionString_in, 
			true, // connection_insideInstance_in
			logFile_in
		) {}
		private DO__base(
			DBConnection connection_in, 
			string dbServerType_in, 
			string connectionString_in, 
			bool connection_insideInstance_in,
			string logFile_in
		) {
			this.connection__ = connection_in;
			this.connection_dbservertype_ = dbServerType_in;
			this.connection_connectionstring_ = connectionString_in;
			this.connection_insideinstance_ = connection_insideInstance_in;

			if (logFile_in == null) {
				this.logenabled_ = false;
				this.logfile_ = null;
			} else {
				this.logenabled_ = true;
				this.logfile_ = logFile_in;
			}
		}
		///
		~DO__base() {
			this.Dispose(false);
		}
		/// <summary>
		/// Disposes any instantiated Connection.
		/// </summary>
		public void Dispose() {
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing_in) {
			if (this.connection_insideinstance_ && (this.connection__ != null)) {
				this.connection__.Dispose(); this.connection__ = null;
			}
		}
//		#endregion

		//#region Properties...
//		#region public DBConnection Connection { get; }
		private string connection_dbservertype_;
		private string connection_connectionstring_;
		private bool logenabled_;
		private string logfile_;

		private bool connection_insideinstance_;
		private DBConnection connection__;
		private object connection__locker = new object();

		/// <summary>
		/// DB Connection.
		/// </summary>
		public DBConnection Connection {
			get {

				// check before lock
				if (
					this.connection_insideinstance_
					&&
					(this.connection__ == null)
				) {

					lock (this.connection__locker) {

						// double check, thread safer!
						if (
							this.connection_insideinstance_
							&&
							(this.connection__ == null)
						) {

							// instantiating for the first time and
							// only because it became needed, otherwise
							// never instantiated...

							if (this.logenabled_) {
								// initialization...
								// ...attribution (last thing before unlock)
								this.connection__ = this.DBConnection_createInstance(
									this.connection_dbservertype_,
									this.connection_connectionstring_,
									this.logfile_
								);
							} else {
								// initialization...
								// ...attribution (last thing before unlock)
								this.connection__ = this.DBConnection_createInstance(
									this.connection_dbservertype_,
									this.connection_connectionstring_, 
									null
								);
							}
						}
					}
				}

				return this.connection__;
			}
		}
//		#endregion
		//#endregion

		#region Methods...
		public abstract DBConnection DBConnection_createInstance(
			string dbServerType_in, 
			string connectionString_in, 
			string logFile_in
		);
		#endregion
	}
}
