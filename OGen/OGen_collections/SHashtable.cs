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