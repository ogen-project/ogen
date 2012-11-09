#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DataLayer {
	using System;
	using System.Data;

	#region /// <summary>...</summary>
	/// <summary>
	///	Provides Transaction support to <see cref="DBConnection">DBConnection</see>.
	///	</summary>
	/// <threadsafety static="true" instance="false"/>
	#endregion
	public sealed class DBTransaction : IDisposable {

		#region internal DBTransaction(...);
		/// <summary>
		/// Initializes a new instance of <see cref="DBTransaction">DBTransaction</see>
		/// </summary>
		/// <param name="parent_in">parent reference</param>
		internal DBTransaction(DBConnection parent_in) {
			this.parent_ = parent_in;
			this.intransaction_ = false;
		}

		~DBTransaction() {
			this.Dispose(false);
		}

		#region public void Dispose(...);

		/// <summary>
		/// Releases all resources used by <see cref="DBTransaction">DBTransaction</see>.
		/// </summary>
		/// <param name="disposing_in"></param>
		private void Dispose(bool disposing_in) {
			if (this.intransaction_) this.Terminate();
			if (this.transaction_ != null) {
				this.transaction_.Dispose(); this.transaction_ = null;
			}
		}

		/// <summary>
		/// Releases all resources used by <see cref="DBTransaction">DBTransaction</see>.
		/// </summary>
		public void Dispose() {
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		#endregion
		#endregion

		#region private Fields...
		private DBConnection parent_;
		#endregion

		#region public Properties...
		#region public bool inTransaction { get; }
		private bool intransaction_;

		/// <summary>
		/// Indicates the Transaction state, True if initiated, False if uninitiated.
		/// </summary>
		public bool inTransaction {
			get { return this.intransaction_; }
		}
		#endregion
		#region public IDbTransaction exposeTransaction { get; }
		private IDbTransaction transaction_;

		/// <summary>
		/// Exposing real Database Transaction as read only, should it be needed.
		/// </summary>
		public IDbTransaction exposeTransaction {
			get {
				return this.transaction_;
			}
		}
		#endregion
		#endregion

		#region public Methods...
		#region public void Begin(...);
		/// <summary>
		/// Initiates Transaction.
		/// </summary>
		public void Begin() {
			this.Begin(IsolationLevel.Serializable);
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
			if (this.intransaction_) {
				throw new BeginException_alreadyInitiated();
			} else if (!this.parent_.isOpen) {
				throw new BeginException_closedConnection();
			} else {
				this.transaction_ = this.parent_.exposeConnection.BeginTransaction(isolationLevel_in);

				this.intransaction_ = true;
			}
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
			if (!this.intransaction_) {
				throw new InvalidTransactionStateException_uninitiated();
			}

			this.transaction_.Commit();
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
			if (!this.intransaction_) {
				throw new InvalidTransactionStateException_uninitiated();
			}

			this.transaction_.Rollback();
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
			if (!this.intransaction_) {
				throw new InvalidTransactionStateException_uninitiated();
			}

			this.transaction_.Dispose(); this.transaction_ = null;
			this.intransaction_ = false;
		}
		#endregion

		// ToDos: later!
		#region //public void Save(...);
		//public void Save(string savePointName_in) {
		//	#region Checking...
		//	if (!this.intransaction_)
		//		throw InvalidTransactionStateException_uninitiated;
		//	#endregion
		//
		//	this.transaction_.Save(savePointName_in);
		//}
		#endregion

		// ToDos: later!
		#region //public void Rollback(string savePointName_in);
		//public void Rollback(string savePointName_in) {
		//	#region Checking...
		//	if (!this.intransaction_)
		//		throw InvalidTransactionStateException_uninitiated;
		//	#endregion
		//
		//	if (savePointName_in == "")
		//		this.transaction_.Rollback();
		//	else
		//		this.transaction_.Rollback(savePointName_in);
		//}
		#endregion

		#endregion
	}
}
