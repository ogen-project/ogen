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
using System.Reflection;
using System.Xml;

namespace OGen.lib.collections {
	public interface iClaSSe {
		object Property_new(string name_in);

		void SaveState_toFile(string fileName_in, string objectName_in);
		XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in);

		void LoadState_fromFile(string fileName_in, string objectName_in);
		void LoadState_fromFile(XmlNode node_in);

		iClaSSe InheritLoopback_ref { get; }
		iClaSSe AggregateLoopback_ref { get; }

		PropertyInfo[] Properties { get; }
		ClaSSPropertyAttribute[] Attributes { get; }

		int PropertyIndex_find(string name_in);
		int PropertyIndex_find(string name_in, ClaSSPropertyAttribute.eType type_in);
		PropertyInfo Property_find(string name_in);
		PropertyInfo Property_find(string name_in, ClaSSPropertyAttribute.eType type_in);

		iClaSSe root();
		string Read_fromRoot(string what_in);
		string Read_fromHere(string what_in);

//		string XMLName { get; set; }
//		string XMLPath { get; }
		string Path { get; }
		void IterateThrough_fromRoot(string iteration_in, cClaSSe.dIteration_found iteration_found_in);
		void IterateThrough_fromHere(string iteration_in, string path_in, cClaSSe.dIteration_found iteration_found_in);
	}
}