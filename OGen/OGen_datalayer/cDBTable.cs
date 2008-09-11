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

namespace OGen.lib.datalayer {
	/// <summary>
	/// Provides a mean of storing the DataBase INFORMATION_SCHEMA for some Table.
	/// </summary>
	public class cDBTable {
		/// <param name="name_in">Table Name</param>
		/// <param name="isVirtualTable_in">Indicates if it represents a View or Table. True if it represents a View, False if it represents a Table</param>
		/// <param name="dbDescription_in">Description</param>
		public cDBTable(
			string name_in, 
			bool isVirtualTable_in, 
			string dbDescription_in
		) {
			Name = name_in;
			isVirtualTable = isVirtualTable_in;
			DBDescription = dbDescription_in;
		}

		/// <summary>
		/// Table Name.
		/// </summary>
		public string Name;

		/// <summary>
		/// Description.
		/// </summary>
		public string DBDescription;

		/// <summary>
		/// Indicates if it represents a View or Table. True if it represents a View, False if it represents a Table.
		/// </summary>
		public bool isVirtualTable;
	}
}