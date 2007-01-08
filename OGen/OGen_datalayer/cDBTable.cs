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