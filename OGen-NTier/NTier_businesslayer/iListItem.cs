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

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.lib.businesslayer {
	/// <summary>
	/// ListItem Interface.
	/// </summary>
	public interface iListItem {
		/// <summary>
		/// List Item Text.
		/// </summary>
		string ListItemText { get; }

		/// <summary>
		/// List Item Value.
		/// </summary>
		string ListItemValue { get; }

		//void Record_open(int Search, params object SearchParameters);
		//void Record_close();
		//bool Record_read();

		/// <summary>
		/// Exposes RecordObject.
		/// </summary>
		iRecordObject Record { get; }
	}
}