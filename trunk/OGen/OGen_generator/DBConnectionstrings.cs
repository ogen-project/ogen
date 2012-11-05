#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.Generator {
	using System;
	using System.Collections;
	using OGen.Libraries.DataLayer;

	public class DBConnectionstrings {
		#region public DBConnectionstrings();
		public DBConnectionstrings() {
			this.dbconnectionstrings_ = new ArrayList();
		}
		#endregion

		private ArrayList dbconnectionstrings_;

		#region public DBConnectionstring this[int index_in] { get; }
		public DBConnectionstring this[int index_in] {
			get { return (DBConnectionstring)this.dbconnectionstrings_[index_in]; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return this.dbconnectionstrings_.Count; }
		}
		#endregion

		#region internal bool Contains_disableIfNot(DBServerTypes dbServerTypes_in);
		internal bool Contains_disableIfNot(DBServerTypes dbServerTypes_in) {
			bool _output = false;
			for (int d = 0; d < this.dbconnectionstrings_.Count; d++) {
				if (((DBConnectionstring)this.dbconnectionstrings_[d]).DBServerType == dbServerTypes_in) {
					((DBConnectionstring)this.dbconnectionstrings_[d]).enabled_aux__ = true;
					_output = true;
				} else {
					((DBConnectionstring)this.dbconnectionstrings_[d]).enabled_aux__ = false;
				}
			}
			return _output;
		}
		#endregion

		#region public bool Contains(DBServerTypes dbServerTypes_in);
		public bool Contains(DBServerTypes dbServerTypes_in) {
			for (int d = 0; d < this.dbconnectionstrings_.Count; d++) {
				if (((DBConnectionstring)this.dbconnectionstrings_[d]).DBServerType == dbServerTypes_in) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#region public void Clear();
		public void Clear() {
			this.dbconnectionstrings_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(
			DBServerTypes dbServerType_in, 
			string connectionstring_in
		) {
			return this.dbconnectionstrings_.Add(
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
				= new DBConnectionstring[this.dbconnectionstrings_.Count];
			this.dbconnectionstrings_.CopyTo(_output);
			return _output;
		}
		#endregion
	}
}
