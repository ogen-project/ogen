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
using System.Xml;

namespace OGen.lib.collections {
	public interface iClaSS_noR : iClaSS {

//		string Property_standard_get(string name_in);
//		void Property_standard_set(string name_in, string value_in);
//
//		iClaSS Property_aggregate_get(string name_in);
//		void Property_aggregate_set(string name_in, iClaSS value_in);
//
//		ArrayList Property_aggregate_collection_get(string name_in);
//		void Property_aggregate_collection_set(string name_in, ArrayList value_in);


		cProperty_standard Property_standard { get; }
		cProperty_aggregate Property_aggregate { get; }
		cProperty_aggregate_collection Property_aggregate_collection { get; }
	}
}