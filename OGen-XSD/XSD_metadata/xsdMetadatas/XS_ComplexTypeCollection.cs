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
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;

namespace OGen.XSD.lib.metadata {
	#region public class XS_ComplexTypeCollection { ... }
	public class XS_ComplexTypeCollection {
		public XS_ComplexTypeCollection () {
			cols_ = new ArrayList();
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return parent_ref_;
			}
			set {
				parent_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((XS_ComplexType)cols_[i]).parent_ref = this;
				}
			}
		}
		#endregion
		#region public RootMetadata root_ref { get; }
		private RootMetadata root_ref_;

		public RootMetadata root_ref {
			get {
				return root_ref_;
			}
			set {
				root_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((XS_ComplexType)cols_[i]).root_ref = value;
				}
			}
		}
		#endregion

		#region internal XS_ComplexType[] cols__ { get; set; }
		private ArrayList cols_;

		internal XS_ComplexType[] cols__ {
			get {
				XS_ComplexType[] _output = new XS_ComplexType[cols_.Count];
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

		#region public XS_ComplexType this[int index_in] { get; }
		public XS_ComplexType this[int index_in] {
			get {
				return (XS_ComplexType)cols_[index_in];
			}
		}
		#endregion
		#region public XS_ComplexType this[string name_in] { get; }
		public XS_ComplexType this[string name_in] {
			get {
				for (int i = 0; i < cols_.Count; i++) {
					if (((XS_ComplexType)cols_[i]).Name == name_in) {
						return (XS_ComplexType)cols_[i];
					}
				}

				return null;
			}
		}
		#endregion

		#region public int Add(params XS_ComplexType[] col_in);
		public int Add(params XS_ComplexType[] col_in) {
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
