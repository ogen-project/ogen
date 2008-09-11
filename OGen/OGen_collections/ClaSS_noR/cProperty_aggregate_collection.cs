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

namespace OGen.lib.collections {
	public class cProperty_aggregate_collection {
		public cProperty_aggregate_collection() {
			shashtable_ = new SHashtable();
		}

		private SHashtable shashtable_;

		public SHashtable.ISHashtableKeys Keys {
			get { return shashtable_.Keys; }
		}
		public int Count {
			get { return shashtable_.Count; }
		}
		public ArrayList this[int index_in] {
			get { return (ArrayList)shashtable_[index_in]; }
			set { shashtable_[index_in] = value; }
		}
		public ArrayList this[string name_in] {
			get { return (ArrayList)shashtable_[name_in]; }
			set { shashtable_[name_in] = value; }
		}

		public int Search(string name_in) {
			return shashtable_.Search(name_in);
		}
		public int Add(SHashtableItem item_in) {
			return shashtable_.Add(item_in);
		}
		public int Add(string name_in, ArrayList value_in) {
			return shashtable_.Add(name_in, value_in);
		}
	}
}