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
#if !NET_1_1
using System.Collections.Generic;
#endif

namespace OGen.lib.templates {
	public class XS_argumentTypeCollection {
		public XS_argumentTypeCollection() {
			cols_ = new
				#if NET_1_1
				ArrayList()
				#else
				List<XS_argumentType>()
				#endif
			;
		}


		#region internal XS_argumentType[] cols__ { get; set; }
		private 
			#if NET_1_1
			ArrayList
			#else
			List<XS_argumentType>
			#endif
		cols_;

		internal XS_argumentType[] cols__ {
			get {
				XS_argumentType[] _output = new XS_argumentType[cols_.Count];
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

		#region public XS_argumentType this[int index_in] { get; }
		public XS_argumentType this[int index_in] {
			get {
				return 
					#if NET_1_1
					(XS_argumentType)
					#endif
					cols_[index_in]
				;
			}
		}
		#endregion
		#region public XS_argumentType this[...] { get; }
		public XS_argumentType this[
			string name_in
		] {
			get {
				int _index = Search(
					name_in
				);
				return (_index == -1)
					? null
					: 
						#if NET_1_1
						(XS_argumentType)
						#endif
						cols_[_index]
				;
			}
		}
		#endregion

		#region public void Remove(...);
		public void Remove(
			string name_in
		) {
			RemoveAt(
				Search(
					name_in
				)
			);
		}
		#endregion
		#region public int Search(...);
		public int Search(
			string name_in
		) {
			for (int i = 0; i < cols_.Count; i++) {
				if (
					(
						#if NET_1_1
						((XS_argumentType)cols_[i])
						#else
						cols_[i]
						#endif
							.Name
						==
						name_in 
					)
					
				) {
					return i;
				}
			}

			return -1;
		}
		public int Search(XS_argumentType collectionItem_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (
					(
						#if NET_1_1
						((XS_argumentType)cols_[i])
						#else
						cols_[i]
						#endif
							.Name
						==
						collectionItem_in.Name
					)
					
				) {
					return i;
				}
			}

			return -1;
		}
		#endregion
		#region public void Add(...);
		public virtual void Add(bool ifNotExists_in, params XS_argumentType[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					if (Search(col_in[i]) == -1) {
						Add(col_in[i]);
					}
				}
			}
		}
		public virtual void Add(out int returnIndex_out, bool ifNotExists_in, params XS_argumentType[] col_in) {
			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					returnIndex_out = Search(col_in[i]);
					if (returnIndex_out == -1) {
						Add(out returnIndex_out, col_in[i]);
					}
				}
			}
		}
		#endregion
		#region public void Clear();
		public void Clear() {
			cols_.Clear();
		}
		#endregion
		#region public void RemoveAt(int index_in);
		public void RemoveAt(int index_in) {
			cols_.RemoveAt(index_in);
		}
		#endregion
		#region public void Add(...);
		public void Add(params XS_argumentType[] col_in) {
			int _index = -1;
			Add(out _index, col_in);
		}
		public void Add(out int returnIndex_out, params XS_argumentType[] col_in) {
			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length - 1; i++) {
				cols_.Add(col_in[i]);
			}

			int j = col_in.Length - 1;
			if (j >= 0) {
				lock (cols_) {
					#if NET_1_1
					returnIndex_out = cols_.Add(col_in[j]);
					#else
					cols_.Add(col_in[j]);
					returnIndex_out = cols_.Count - 1;
					#endif
				}
			}
		}
		#endregion
	}
}