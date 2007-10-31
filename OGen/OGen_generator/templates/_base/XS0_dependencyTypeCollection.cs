#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;

namespace OGen.lib.templates {
	#region public class XS_dependencyTypeCollection { ... }
	public class XS_dependencyTypeCollection {
		public XS_dependencyTypeCollection() {
			cols_ = new ArrayList();
		}


		#region internal XS_dependencyType[] cols__ { get; set; }
		private ArrayList cols_;

		internal XS_dependencyType[] cols__ {
			get {
				XS_dependencyType[] _output = new XS_dependencyType[cols_.Count];
				cols_.CopyTo(_output);
				return _output;
			}
			set {
				cols_.Clear();
				if (value != null) {
					for (int i = 0; i < value.Length; i++) {
						cols_.Add(value[i]);
					}
				}
			}
		}
		#endregion

		#region public int Count { get; }
		public int Count {
			get {
				return cols_.Count;
			}
		}
		#endregion

		#region public XS_dependencyType this[int index_in] { get; }
		public XS_dependencyType this[int index_in] {
			get {
				return (XS_dependencyType)cols_[index_in];
			}
		}
		#endregion
		#region public XS_dependencyType this[string name_in] { get; }
		public XS_dependencyType this[string name_in] {
			get {
				int _index = Search(name_in);
				return (_index == -1)
					? null
					: (XS_dependencyType)cols_[_index];
			}
		}
		#endregion
		#region public int Search(...);
		public int Search(string name_in, bool caseSensitive_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (
					(
						caseSensitive_in
						&&
						(
							name_in.ToLower() 
							== 
							((XS_dependencyType)cols_[i]).Name.ToLower()
						)
					)
					||
					(
						!caseSensitive_in
						&&
						(
							name_in
							==
							((XS_dependencyType)cols_[i]).Name
						)
					)
				) {
					return i;
				}
			}

			return -1;
		}
		public int Search(string name_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (name_in.Equals(((XS_dependencyType)cols_[i]).Name)) {
					return i;
				}
			}

			return -1;
		}
		#endregion

		#region public int Add(params XS_dependencyType[] col_in);
		public int Add(params XS_dependencyType[] col_in) {
			int _output = -1;

			for (int i = 0; i < col_in.Length; i++) {
				_output = cols_.Add(col_in[i]);
			}

			return _output;
		}
		#endregion
	}
	#endregion
}