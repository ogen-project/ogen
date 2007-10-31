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
using System.Reflection;
using System.Xml;

namespace OGen.lib.collections {
	public interface iClaSSe_metadata {
		string Read_fromRoot(string what_in);

		void IterateThrough_fromRoot(
			string iteration_in, 
			cClaSSe.dIteration_found iteration_found_in
		);
	}

	public interface iClaSSe : iClaSSe_metadata {
		object Property_new(string name_in);

		void SaveState_toFile(string fileName_in, string objectName_in);
		XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in);

		void LoadState_fromFile(
			string fileName_in, 
			string objectName_in
		);
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
//		string Read_fromRoot(string what_in);
		string Read_fromHere(string what_in);

////		string XMLName { get; set; }
////		string XMLPath { get; }
		string Path { get; }
//		void IterateThrough_fromRoot(string iteration_in, cClaSSe.dIteration_found iteration_found_in);
		void IterateThrough_fromHere(string iteration_in, string path_in, cClaSSe.dIteration_found iteration_found_in);
	}
}
