#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;

namespace OGen.lib.datalayer {
	#region /// <summary>...</summary>
	/// <summary>
	///	Provides Transaction support to <see cref="DBConnection">DBConnection</see>.
	///	</summary>
	/// <threadsafety static="true" instance="false"/>
	#endregion
	public sealed class DBTransaction : IDisposable {
		#region internal DBTransaction(...);
		internal DBTransaction(DBConnection parent_in) {
			parent_ = parent_in;
			intransaction_ = false;
		}

		~DBTransaction() {
			cleanUp();
		}

		#region public void Dispose();
		public void Dispose() {
			cleanUp();
			System.GC.SuppressFinalize(this);
		}
		private void cleanUp() {
			if (intransaction_) Terminate();
			if (transaction_ != null) {
				transaction_.Dispose(); transaction_ = null;
			}
		}
		#endregion
		#endregion

		#region private Fields...
		private DBConnection parent_;
		#endregion

		#region Exceptions...
		#region public static readonly Exception InvalidTransactionStateException_uninitiated;
		/// <summary>
		/// Invalid Transaction state Exception (uninitiated).
		/// </summary>
		public static readonly Exception InvalidTransactionStateException_uninitiated
			= new Exception("invalid transaction state (uninitiated)");
		#endregion
		#region public static readonly Exception BeginException_alreadyInitiated;
		/// <summary>
		/// Can't Begin Transaction Exception, Transaction already initiated.
		/// </summary>
		public static readonly Exception BeginException_alreadyInitiated
			= new Exception("can't begin, transaction already initiated");
		#endregion
		#region public static readonly Exception BeginException_closedConnection;
		/// <summary>
		/// Can't Begin Transaction Exception, Connection is closed.
		/// </summary>
		public static readonly Exception BeginException_closedConnection
			= new Exception("can't begin, Connection is closed");
		#endregion
		#endregion

		//#region public Properties...
		#region public bool inTransaction { get; }
		private bool intransaction_;

		/// <summary>
		/// Indicates the Transaction state, True if initiated, False if uninitiated.
		/// </summary>
		public bool inTransaction {
			get { return intransaction_; }
		}
		#endregion
		#region public IDbTransaction exposeTransaction { get; }
		private IDbTransaction transaction_;

		/// <summary>
		/// Exposing real DataBase Transaction as read only, should it be needed.
		/// </summary>
		public IDbTransaction exposeTransaction {
			get {
				return transaction_;
			}
		}
		#endregion
		//#endregion

		//#region public Methods...
		#region public void Begin(...);
		/// <summary>
		/// Initiates Transaction.
		/// </summary>
		public void Begin() {
			Begin(IsolationLevel.Serializable);
		}

		/// <summary>
		/// Initiates Transaction.
		/// </summary>
		/// <exception cref="BeginException_alreadyInitiated">
		/// Thrown when the Transaction is already initiated
		/// </exception>
		/// <exception cref="BeginException_closedConnection">
		/// Thrown when the Connection is closed
		/// </exception>
		/// <param name="isolationLevel_in">One of the System.Data.IsolationLevel values</param>
		public void Begin(IsolationLevel isolationLevel_in) {
			//lock (intransaction_) {
			//	lock (parent_.isOpen) {
					if (intransaction_) {
						throw BeginException_alreadyInitiated;
					} else if (!parent_.isOpen) {
						throw BeginException_closedConnection;
					} else {
			//			lock (parent_.Connection) {
							transaction_ = parent_.exposeConnection.BeginTransaction(isolationLevel_in);

							intransaction_ = true;
			//			}
					}
			//	}
			//}
		}
		#endregion
		#region public void Commit(...);
		/// <summary>
		/// Commits the Transaction.
		/// </summary>
		/// <exception cref="InvalidTransactionStateException_uninitiated">
		/// Thrown when the Transaction is not initiated
		/// </exception>
		public void Commit() {
			//lock (intransaction_) {
				if (!intransaction_) {
					throw InvalidTransactionStateException_uninitiated;
				}

				transaction_.Commit();
			//}
		}
		#endregion
		#region public void Rollback(...);
		/// <summary>
		/// Rolls back the Transaction from a pending state.
		/// </summary>
		/// <exception cref="InvalidTransactionStateException_uninitiated">
		/// Thrown when the Transaction is not initiated
		/// </exception>
		public void Rollback() {
			//lock (intransaction_) {
				if (!intransaction_) {
					throw InvalidTransactionStateException_uninitiated;
				}

				transaction_.Rollback();
			//}
		}
		#endregion
		#region public void Terminate(...);
		/// <summary>
		/// Terminates Transaction.
		/// </summary>
		/// <exception cref="InvalidTransactionStateException_uninitiated">
		/// Thrown when the Transaction is not initiated
		/// </exception>
		public void Terminate() {
			//lock (intransaction_) {
				if (!intransaction_) {
					throw InvalidTransactionStateException_uninitiated;
				}

				transaction_.Dispose(); transaction_ = null;
				intransaction_ = false;
			//}
		}
		#endregion

// ToDos: later!
		#region //public void Save(...);
		//public void Save(string savePointName_in) {
		//	#region Checking...
		//	if (!intransaction_)
		//		throw InvalidTransactionStateException_uninitiated;
		//	#endregion
		//
		//	transaction_.Save(savePointName_in);
		//}
		#endregion
//		#region public void Rollback(...);
// ToDos: later!
		#region //public void Rollback(string savePointName_in);
		//public void Rollback(string savePointName_in) {
		//	#region Checking...
		//	if (!intransaction_)
		//		throw InvalidTransactionStateException_uninitiated;
		//	#endregion
		//
		//	if (savePointName_in == "")
		//		transaction_.Rollback();
		//	else
		//		transaction_.Rollback(savePointName_in);
		//}
		#endregion
		//#endregion
	}
}
