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
using OGen.lib.datalayer;

namespace OGen.lib.generator {
	public class DBConnectionstrings {
		#region public DBConnectionstrings();
		public DBConnectionstrings() {
			dbconnectionstrings_ = new ArrayList();
		}
		#endregion

		private ArrayList dbconnectionstrings_;

		#region public DBConnectionstring this[int index_in] { get; }
		public DBConnectionstring this[int index_in] {
			get { return (DBConnectionstring)dbconnectionstrings_[index_in]; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return dbconnectionstrings_.Count; }
		}
		#endregion

		#region internal bool Contains_disableIfNot(DBServerTypes dbServerTypes_in);
		internal bool Contains_disableIfNot(DBServerTypes dbServerTypes_in) {
			bool contains_disableifnot_out = false;
			for (int d = 0; d < dbconnectionstrings_.Count; d++) {
				if (((DBConnectionstring)dbconnectionstrings_[d]).DBServerType == dbServerTypes_in) {
					((DBConnectionstring)dbconnectionstrings_[d]).enabled_aux__ = true;
					contains_disableifnot_out = true;
				} else {
					((DBConnectionstring)dbconnectionstrings_[d]).enabled_aux__ = false;
				}
			}
			return contains_disableifnot_out;
		}
		#endregion

		#region public bool Contains(DBServerTypes dbServerTypes_in);
		public bool Contains(DBServerTypes dbServerTypes_in) {
			for (int d = 0; d < dbconnectionstrings_.Count; d++) {
				if (((DBConnectionstring)dbconnectionstrings_[d]).DBServerType == dbServerTypes_in) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#region public void Clear();
		public void Clear() {
			dbconnectionstrings_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(
			DBServerTypes dbServerType_in, 
			string connectionstring_in
		) {
			return dbconnectionstrings_.Add(
				new DBConnectionstring(
					dbServerType_in, 
					connectionstring_in
				)
			);
		}
		#endregion

		#region public DBConnectionstring[] Convert_toArray();
		public DBConnectionstring[] Convert_toArray() {
			DBConnectionstring[] _output 
				= new DBConnectionstring[dbconnectionstrings_.Count];
			dbconnectionstrings_.CopyTo(_output);
			return _output;
		}
		#endregion
	}
}
