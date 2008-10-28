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

namespace OGen.NTier.lib.datalayer {
	/// <summary>
	/// DataObject interface.
	/// </summary>
	public interface IRecordObject {
		/// <summary>
		/// Represents current iteration at the Record.
		/// </summary>
		int Current { get; }

		/// <summary>
		/// Indicates if Record is open, True if is open, False if not.
		/// </summary>
		bool isOpened { get; }

		/// <summary>
		/// Represents number of items in the Record.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// Exposes Record DataTable.
		/// </summary>
		DataTable Record { get; }

		/// <summary>
		/// Reads values from Record, assigns them to the appropriate DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		bool Read();

		/// <summary>
		/// Points current iteration to the Beginning of the Record.
		/// </summary>
		void Reset();

		/// <summary>
		/// Indicates if current iteration is at the End Of Record.
		/// </summary>
		/// <returns>True if iteration has reached the End Of Record, False if not.</returns>
		bool EOR();

		/// <summary>
		/// Closes Record.
		/// </summary>
		void Close();

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
		void Open(DataTable dataTable_in);

		///// <summary>
		///// Opens Record, based on some SQL Query.
		///// </summary>
		///// <param name="query_in">SQL Query</param>
		///// <exception cref="InvalidRecordStateException_alreadyOpened">
		///// Thrown when the Record is already opened
		///// </exception>
		//void Open(string query_in);

		///// <summary>
		///// Opens Record, based on some SQL Function.
		///// </summary>
		///// <param name="function_in">SQL Function name</param>
		///// <param name="dataParameters_in">SQL Function parameters</param>
		///// <exception cref="InvalidRecordStateException_alreadyOpened">
		///// Thrown when the Record is already opened
		///// </exception>
		//void Open(string function_in, IDbDataParameter[] dataParameters_in);
	}
}