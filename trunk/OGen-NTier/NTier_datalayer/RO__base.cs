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

	/// <summary>
	/// base implementation class for RecordObject classes.
	/// </summary>
	public abstract class RO__base : IRecordObject {
		/// <summary>
		/// Initializes a new instance of <see cref="RO__base">RO__base</see>
		/// </summary>
		/// <param name="dataObject_in">a Reference to the DataObject (the one that's aggregating this RecordObject)</param>
		protected RO__base(
			DO__base dataObject_in
		) {
			this.dataobject_ = dataObject_in;
			this.isopened_ = false;
		}

		#region private Properties...
		private DO__base dataobject_;
		#endregion

		#region public Properties...
		#region public int Current { get; set; }
		private int current__;

		/// <summary>
		/// Represents current iteration at the Record.
		/// </summary>
		/// <exception cref="InvalidRecordStateException_Closed">
		/// Thrown when the Record is closed
		/// </exception>
		public int Current {
			get {
				#region Checking...
				if (!this.isopened_)
					throw new InvalidRecordStateException_Closed();
				#endregion

				return this.current__;
			}
			set {
				#region Checking...
				if (!this.isopened_)
					throw new InvalidRecordStateException_Closed();
				#endregion

				this.current__ = value;
			}
		}
		#endregion
		#region public bool IsOpened { get; }
		private bool isopened_;

		/// <summary>
		/// Indicates if Record is open, True if is open, False if not.
		/// </summary>
		public bool IsOpened {
			get { return this.isopened_; }
		}
		#endregion
		#region public int Count { get; }
		/// <summary>
		/// Represents number of items in the Record.
		/// </summary>
		public int Count {
			get { return this.Record.Rows.Count; }
		}
		#endregion
		#region public virtual DataTable Record { get; }
		protected DataTable record__;

		/// <summary>
		/// Exposes Record DataTable.
		/// </summary>
		/// <exception cref="InvalidRecordStateException_Closed">
		/// Thrown when the Record is closed
		/// </exception>
		public virtual DataTable Record {
			get {
				#region Checking...
				if (!this.isopened_)
					throw new InvalidRecordStateException_Closed();
				#endregion

				return this.record__;
			}
		}
		#endregion
		#endregion

		#region public Methods...
		#region public virtual void Open(...);
		/// <summary>
		/// Opens Record, based on some DataTable.
		/// </summary>
		/// <param name="dataTable_in">DataTable based on which Record will be opened</param>
		/// <exception cref="InvalidRecordStateException_alreadyOpened">
		/// Thrown when the Record is already opened
		/// </exception>
		/// <remarks>
		/// - Why 'set' for Record_exposeDataTable? - This way I can instantiate DO, get datatable by exposion, de-instantiate DO, save datatable wherever... re-instantiate DO at a later time, set datatable by exposion.
		/// - Why does it allow this if not fullmode? - at a later time, if not already done, it should allow to 'navigate' a non fullmode record, without fireing event getObject, something like DO.Record_read(false /*force fullmode*/); - besides when set is done it re-sets fullmode based on re-setted datatable.
		/// </remarks>
		public virtual void Open(DataTable dataTable_in) {
			#region Checking...
			if (this.isopened_)
				throw new InvalidRecordStateException_alreadyOpened();
			#endregion

			this.record__ = dataTable_in;
			this.current__ = -1;
			this.isopened_ = true;
		}

		public virtual void Open(
			DataTable dataTable_in,
			int page_in,
			int page_numRecords_in
		) {
			#region Checking...
			if (this.isopened_)
				throw new InvalidRecordStateException_alreadyOpened();
			#endregion

			#region DataTable _datatable[0..n] = dataTable_in[(page_in - 1) * page_numRecords_in .. page_in * page_numRecords_in];
			DataTable _datatable = new DataTable();
			for (int c = 0; c < dataTable_in.Columns.Count; c++) {
				_datatable.Columns.Add(
					dataTable_in.Columns[c].ColumnName,
					dataTable_in.Columns[c].DataType
				);
			}
			DataRow _datarow;
			int _begin;
			int _end;
			checked {
				_begin = (page_in - 1) * page_numRecords_in;
				_end = page_in * page_numRecords_in;
			}
			for (int r = _begin; r < _end; r++) {
				if (r == dataTable_in.Rows.Count) break;

				_datarow = _datatable.NewRow();
				for (int c = 0; c < dataTable_in.Columns.Count; c++) {
					_datarow[c] = dataTable_in.Rows[r][c];
				}
				_datatable.Rows.Add(_datarow);
			}
			#endregion

			this.record__ = _datatable;
			this.current__ = -1;
			this.isopened_ = true;
		}

		//public virtual void Open(string Query_) {
		//	Open(Query_, true);
		//}

		/// <summary>
		/// Opens Record, based on some SQL Query.
		/// </summary>
		/// <param name="query_in">SQL Query</param>
		/// <exception cref="InvalidRecordStateException_alreadyOpened">
		/// Thrown when the Record is already opened
		/// </exception>
		public virtual void Open(string query_in) {
			#region Checking...
			if (this.isopened_)
				throw new InvalidRecordStateException_alreadyOpened();
			#endregion

			this.record__ = this.dataobject_.Connection.Execute_SQLQuery_returnDataTable(query_in);
			this.current__ = -1;
			this.isopened_ = true;
		}

		/// <summary>
		/// Opens Record, based on some SQL Function.
		/// </summary>
		/// <param name="function_in">SQL Function name</param>
		/// <param name="dataParameters_in">SQL Function parameters</param>
		/// <exception cref="InvalidRecordStateException_alreadyOpened">
		/// Thrown when the Record is already opened
		/// </exception>
		public virtual void Open(string function_in, IDbDataParameter[] dataParameters_in) {
			#region Checking...
			if (this.isopened_)
				throw new InvalidRecordStateException_alreadyOpened();
			#endregion

			this.record__ = this.dataobject_.Connection.Execute_SQLFunction_returnDataTable(function_in, dataParameters_in);
			this.current__ = -1;
			this.isopened_ = true;
		}
		#endregion
		#region public virtual bool Read(...);
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public abstract bool Read();

		/// <summary>
		/// Reads values from Record, assigns them to the appropriate DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		/// <exception cref="InvalidRecordStateException_Closed">
		/// Thrown when the Record is closed
		/// </exception>
		protected bool read() {
			#region Checking...
			if (!this.isopened_)
				throw new InvalidRecordStateException_Closed();
			#endregion

			if (this.EOR())
				return false;
			else {

				this.current__++;
				return true;
			}
		}
		#endregion
		#region public virtual void Reset(...);
		/// <summary>
		/// Points current iteration to the Beginning of the Record.
		/// </summary>
		public virtual void Reset() {
			this.current__ = -1;
		}
		#endregion
		#region public virtual bool EOR(...);
		/// <summary>
		/// Indicates if current iteration is at the End Of Record.
		/// </summary>
		/// <returns>True if iteration has reached the End Of Record, False if not.</returns>
		/// <exception cref="InvalidRecordStateException_Closed">
		/// Thrown when the Record is closed
		/// </exception>
		public virtual bool EOR() {
			#region Checking...
			if (!this.isopened_)
				throw new InvalidRecordStateException_Closed();
			#endregion

			return (this.current__ == this.record__.Rows.Count - 1);
		}
		#endregion
		#region public virtual void Close(...);
		/// <summary>
		/// Closes Record.
		/// </summary>
		/// <exception cref="InvalidRecordStateException_Closed">
		/// Thrown when the Record is closed
		/// </exception>
		public virtual void Close() {
			#region Checking...
			if (!this.isopened_)
				throw new InvalidRecordStateException_Closed();
			#endregion

			this.record__.Dispose(); this.record__ = null;
			this.isopened_ = false;
		}
		#endregion
		#endregion
	}
}