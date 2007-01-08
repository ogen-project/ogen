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

namespace OGen.NTier.lib.datalayer {
	/// <summary>
	/// DataObject interface.
	/// </summary>
	public interface iRecordObject {
		/// <summary>
		/// Represents current iteration at the Record.
		/// </summary>
		int Current { get; }

		/// <summary>
		/// Indicates if Record is open, True if is open, False if not.
		/// </summary>
		bool isOpened { get; }

		/// <summary>
		/// Indicates Record mode, True if in Fullmode, False if not.
		/// </summary>
		bool Fullmode { get; }

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
		/// Reads values from Record, assigns them to the appropriate DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <param name="doNOTgetObject_in">do NOT get object: - if set to true, only PKs will be available for reading, you should be carefull (updates aren't advisable, other issues may occur)</param>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		bool Read(bool doNOTgetObject_in);

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
		/// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		/// <param name="dataTable_in">DataTable based on which Record will be opened</param>
		/// <exception cref="InvalidRecordStateException_alreadyOpened">
		/// Thrown when the Record is already opened
		/// </exception>
		/// <remarks>
		/// - Why 'set' for Record_exposeDataTable? - This way I can instantiate DO, get datatable by exposion, de-instantiate DO, save datatable wherever... re-instantiate DO at a later time, set datatable by exposion.
		/// - Why does it allow this if not fullmode? - at a later time, if not already done, it should allow to 'navigate' a non fullmode record, without fireing event getObject, something like DO.Record_read(false /*force fullmode*/); - besides when set is done it re-sets fullmode based on re-setted datatable.
		/// </remarks>
		void Open(bool fullmode_in, DataTable dataTable_in);

		///// <summary>
		///// Opens Record, based on some SQL Query.
		///// </summary>
		///// <param name="query_in">SQL Query</param>
		///// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		///// <exception cref="InvalidRecordStateException_alreadyOpened">
		///// Thrown when the Record is already opened
		///// </exception>
		//void Open(string query_in, bool fullmode_in);

		///// <summary>
		///// Opens Record, based on some SQL Function.
		///// </summary>
		///// <param name="function_in">SQL Function name</param>
		///// <param name="dataParameters_in">SQL Function parameters</param>
		///// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		///// <exception cref="InvalidRecordStateException_alreadyOpened">
		///// Thrown when the Record is already opened
		///// </exception>
		//void Open(string function_in, IDbDataParameter[] dataParameters_in, bool fullmode_in);
	}
}