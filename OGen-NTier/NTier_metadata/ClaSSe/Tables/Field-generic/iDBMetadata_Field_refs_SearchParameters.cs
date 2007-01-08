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

namespace OGen.NTier.lib.metadata {
	public interface iDBMetadata_Field_refs_SearchParameters : iDBMetadata_Field_refs__base {
		int Add(int tableIndex_in, int fieldIndex_in, bool verifyExistenz_in, string paramName_in);
		int Add(string tableName_in, string fieldName_in, bool verifyExistenz_in, string paramName_in);
		int Search(int tableIndex_in, int fieldIndex_in, string paramName_in);
		int Search(string tableName_in, string fieldName_in, string paramName_in);
	}
}