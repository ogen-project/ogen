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