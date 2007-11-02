#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

#if !NET_1_1
using System;
using System.Collections.Generic;

namespace OGen.lib.collections {
	public class OGenRootrefCollection<C, R> : OGenCollection<C>
		where R : class
		where C : 
			class,
			OGenCollectionInterface<string>, 
			OGenRootrefCollectionInterface<R>
	{
		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return parent_ref_;
			}
			set {
				parent_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((C)cols_[i]).parent_ref = this;
				}
			}
		}
		#endregion
		#region public R root_ref { get; }
		private R root_ref_;

		public R root_ref {
			get {
				return root_ref_;
			}
			set {
				root_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((C)cols_[i]).root_ref = value;
				}
			}
		}
		#endregion
	}
	public class OGenRootrefCollection<C, R, T> : OGenCollection<C, T>
		where R : class
		where C : 
			class,
			OGenCollectionInterface<T>, 
			OGenRootrefCollectionInterface<R>
	{
		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return parent_ref_;
			}
			set {
				parent_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((C)cols_[i]).parent_ref = this;
				}
			}
		}
		#endregion
		#region public R root_ref { get; }
		private R root_ref_;

		public R root_ref {
			get {
				return root_ref_;
			}
			set {
				root_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((C)cols_[i]).root_ref = value;
				}
			}
		}
		#endregion
	}
	public class OGenRootrefSimpleCollection<C, R> : OGenSimpleCollection<C>
		where R : class
		where C :
			class,
			OGenRootrefCollectionInterface<R> 
	{
		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return parent_ref_;
			}
			set {
				parent_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((C)cols_[i]).parent_ref = this;
				}
			}
		}
		#endregion
		#region public R root_ref { get; }
		private R root_ref_;

		public R root_ref {
			get {
				return root_ref_;
			}
			set {
				root_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					((C)cols_[i]).root_ref = value;
				}
			}
		}
		#endregion
	}

	public class OGenCollection<C> : OGenCollection<C, string>
		where C : class, OGenCollectionInterface<string>
	{
		#region public int Search(string memberName_in, bool caseSensitive_in);
		public int Search(string memberName_in, bool caseSensitive_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (
					(
						caseSensitive_in
						&&
						(
							memberName_in.ToLower() 
							== 
							cols_[i].CollectionName.ToLower()
						)
					)
					||
					(
						!caseSensitive_in
						&&
						(
							memberName_in
							==
							cols_[i].CollectionName
						)
					)
				) {
					return i;
				}
			}

			return -1;
		}
		#endregion
	}
	public class OGenCollection<C, T> : OGenSimpleCollection<C>
		where C : class, OGenCollectionInterface<T>
	{
		#region public C this[T memberName_in] { get; }
		public C this[T memberName_in] {
			get {
				int _index = Search(memberName_in);
				return (_index == -1)
					? null
					: cols_[_index];
			}
		}
		#endregion

		#region public int Search(T memberName_in);
		public int Search(T memberName_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (memberName_in.Equals(
					cols_[i].CollectionName
				)) {
					return i;
				}
			}

			return -1;
		}
		#endregion
		#region public void Add(...);
		public void Add(bool ifNotExists_in, params C[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					if (Search(col_in[i].CollectionName) == -1) {
						Add(col_in[i]);
					}
				}
			}
		}
		public void Add(out int returnIndex_out, bool ifNotExists_in, params C[] col_in) {
			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					returnIndex_out = Search(col_in[i].CollectionName);
					if (returnIndex_out == -1) {
						Add(out returnIndex_out, col_in[i]);
					}
				}
			}
		}
		#endregion
		#region public void Remove(T memberName_in);
		public void Remove(T memberName_in) {
			RemoveAt(
				Search(memberName_in)
			);
		}
		#endregion
	}
	public class OGenSimpleCollection<C>
		where C : class 
	{
		public OGenSimpleCollection(
		) {
			cols_ = new List<C>();
		}

		#region public C[] cols__ { get; set; }
		protected List<C> cols_;

		public C[] cols__ {
			get {
				C[] _output = new C[cols_.Count];
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

		#region public C this[int index_in] { get; }
		public C this[int index_in] {
			get {
				return cols_[index_in];
			}
		}
		#endregion

		#region public void Clear();
		public void Clear() {
			cols_.Clear();
		}
		#endregion
		#region public void Add(...);
		/// <summary>
		/// adds one or more items to the collection
		/// </summary>
		/// <param name="returnIndex_out">index position for last added item in the collection </param>
		/// <param name="col_in">item(s) to be added to the collection</param>
		public void Add(out int returnIndex_out, params C[] col_in) {
			returnIndex_out = -1;

			for (int i = 0; i < col_in.Length - 1; i++) {
				cols_.Add(col_in[i]);
			}

			int j = col_in.Length - 1;
			if (j >= 0) {
				lock (cols_) {
					cols_.Add(col_in[j]);
					returnIndex_out = cols_.Count - 1;
				}
			}
		}

		/// <summary>
		/// adds one or more items to the collection
		/// </summary>
		/// <param name="col_in">item(s) to be added to the collection</param>
		public void Add(params C[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				cols_.Add(col_in[i]);
			}
		}
		#endregion
		#region public void RemoveAt(int index_in);
		public void RemoveAt(int index_in) {
			cols_.RemoveAt(index_in);
		}
		#endregion
	}
}
#endif
