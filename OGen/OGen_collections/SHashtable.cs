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
	#region public class SHashtableItem;
	public class SHashtableItem {
		public SHashtableItem(
			string name_in,
			object value_in
		) {
			Name = name_in;
			Value = value_in;
		}
		public string Name;
		public object Value;
	}
	#endregion

	/// <summary>
	/// implements similar Hashtable's interface, it difers in that it keeps it's table sorted
	/// </summary>
	/// <example>
	///SHashtable sh = new SHashtable();
	///sh["um"] = 1;
	///sh["dois"] = 2;
	///sh["tres"] = 3;
	///Console.WriteLine(sh["um"]);
	///for (int i = 0; i &lt; sh.Count; i++) {
	///	Console.WriteLine(sh[i]);
	///}
	///for (int k = 0; k &lt; sh.Keys.Count; k++) {
	///	Console.WriteLine(
	///		"{0}:{1}", 
	///		sh.Keys[k], 
	///		sh[sh.Keys[k]]
	///	);
	///}
	/// </example>
	public class SHashtable /*: ISHashtable*/ {
		#region public SHashtable(...);
		public SHashtable() {
			arraylist_ = new ArrayList();
			keys_ = new SHashtableKeys(this);
		}
		#endregion

		#region public interface ISHashtableKeys;
		public interface ISHashtableKeys {
			int Count { get; }
			string this[int index_in] { get; }
		}
		#endregion

		#region private Properties...
		private ArrayList arraylist_;
		#region private class SHashtableKeys;
		private class SHashtableKeys : ISHashtableKeys {
			#region public SHashtableKeys(...);
			private SHashtableKeys() {}
			public SHashtableKeys(SHashtable parent_ref_in) {
				parent_ref_ = parent_ref_in;
			}
			#endregion

			private SHashtable parent_ref_;

			#region public int Count { get; }
			public int Count {
				get { return parent_ref_.Count; }
			}
			#endregion
			#region public string this[int index_in] { get; }
			public string this[int index_in] {
				get {
					return ((SHashtableItem)parent_ref_.arraylist_[index_in]).Name;
				}
			}
			#endregion
		}
		#endregion
		#endregion
		#region public Properties...
		#region public SHashtableKeys Keys { get; }
		private SHashtableKeys keys_;
		public ISHashtableKeys Keys {
			get { return keys_; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return arraylist_.Count; }
		}
		#endregion
		#region public object this[...] { get; }
		public object this[int index_in] {
			get {
				return (index_in >= 0) 
					? ((SHashtableItem)arraylist_[index_in]).Value 
					: null;
			}
			set {
				((SHashtableItem)arraylist_[index_in]).Value = value;
			}
		}
		public object this[string name_in] {
			get {
				return this[Search(name_in)];
			}
			set {
				int _i = Search(name_in);
				if (_i >= 0)
					((SHashtableItem)arraylist_[_i]).Value = value;
				else
					Add(name_in, value);
			}
		}
		#endregion
		#endregion

		#region public Methods...
		#region public int Search(...);
		public int Search(string name_in) {
			for (int i = 0; i < arraylist_.Count; i++) {
				if (((SHashtableItem)arraylist_[i]).Name == name_in) {
					return i;
				}
			}
			return -1;
		}
		#endregion
		#region public int Add(...);
		public int Add(SHashtableItem item_in) {
			return arraylist_.Add(item_in);
		}
		public int Add(string name_in, object value_in) {
			return Add(new SHashtableItem(name_in, value_in));
		}
		#endregion
		#endregion
	}

//	public interface ISHashtable {
//		SHashtable.ISHashtableKeys Keys { get; }
//		int Count { get; }
//		object this[int index_in] { get; set; }
//		object this[string name_in] { get; set; }
//
//		int Search(string name_in);
//		int Add(SHashtableItem item_in);
//		int Add(string name_in, object value_in);
//	}
}