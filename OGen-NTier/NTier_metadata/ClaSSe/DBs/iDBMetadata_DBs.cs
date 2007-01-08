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
using System.Collections;
using OGen.lib.collections;
using OGen.lib.datalayer;

namespace OGen.NTier.lib.metadata {
	public interface iDBMetadata_DBs : iClaSSe {
		cDBMetadata Root_ref { get; }

		cDBMetadata_DB this[int index_in] { get; }
		cDBMetadata_DB this[eDBServerTypes dbservertype_in] { get; }
		int Count { get; }

		eDBServerTypes FirstDefaultAvailable_DBServerType();
		string FirstDefaultAvailable_Connectionstring();

		int Add(eDBServerTypes dbservertype_in, bool verifyExistenz_in);
		int Search(eDBServerTypes dbservertype_in);
		void Clear();

		void CopyFrom(iDBMetadata_DBs dbMetadata_DBs_in);
	}
}
