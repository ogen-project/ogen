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

namespace OGen.lib.datalayer.newStuff {
	#region /// <summary>...</summary>
	/// <summary>
	///	Provides Transaction support to <see cref="DBConnection">DBConnection</see>.
	///	</summary>
	/// <threadsafety static="true" instance="false"/>
	#endregion
	public sealed class DBTransaction {
		#region internal DBTransaction(...);
		internal DBTransaction(cDBConnection parent_in) {
			parent_ = parent_in;
			intransaction_ = false;
		}

		~DBTransaction() {
			if (intransaction_) Terminate();
		}
		#endregion

		#region private Fields...
		private cDBConnection parent_;
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
		//#endregion
	}
}