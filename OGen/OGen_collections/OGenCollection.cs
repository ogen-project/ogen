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
	public class OGenRootrefCollection<C, R, K> : OGenCollection<C, K>
		where C : 
			class,
			OGenCollectionInterface<C, K>, 
			OGenRootrefCollectionInterface<R>
		where R : class
		where K : struct
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
					cols_[i].parent_ref = this;
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
					cols_[i].root_ref = value;
				}
			}
		}
		#endregion
		#region private void refresh_refs(params C[] col_in);
		private void refresh_refs(params C[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				col_in[i].parent_ref = this;
				col_in[i].root_ref = root_ref;
			}
		}
		#endregion

		#region public override void Add(...);
		public override void Add(bool ifNotExists_in, params C[] col_in) {
			refresh_refs(col_in);
			base.Add(ifNotExists_in, col_in);
		}
		public override void Add(out int returnIndex_out, bool ifNotExists_in, params C[] col_in) {
			refresh_refs(col_in);
			base.Add(out returnIndex_out, ifNotExists_in, col_in);
		}
		public override void Add(out int returnIndex_out, params C[] col_in) {
			refresh_refs(col_in);
			base.Add(out returnIndex_out, col_in);
		}
		public override void Add(params C[] col_in) {
			refresh_refs(col_in);
			base.Add(col_in);
		}
		#endregion
	}
	public class OGenRootrefSimpleCollection<C, R> : OGenSimpleCollection<C>
		where C :
			class,
			OGenRootrefCollectionInterface<R> 
		where R : class
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
		#region private void refresh_refs(params C[] col_in);
		private void refresh_refs(params C[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				col_in[i].parent_ref = this;
				col_in[i].root_ref = root_ref;
			}
		}
		#endregion

		#region public override void Add(...);
		public override void Add(out int returnIndex_out, params C[] col_in) {
			refresh_refs(col_in);
			base.Add(out returnIndex_out, col_in);
		}
		public override void Add(params C[] col_in) {
			refresh_refs(col_in);
			base.Add(col_in);
		}
		#endregion
	}

	// -------------------------------------------------------------------------
	// -------------------------------------------------------------------------
	// -------------------------------------------------------------------------

	public class OGenCollection<C, K> : OGenSimpleCollection<C>
		where C : class, OGenCollectionInterface<C, K>
		where K : struct
	{
		#region public C this[...] { get; }
		public C this[C collectionItem_in] {
			get {
				int _index = Search(collectionItem_in);
				return (_index == -1)
					? null
					: cols_[_index];
			}
		}
		public C this[params K[] keys_in] {
			get {
				int _index = Search(keys_in);
				return (_index == -1)
					? null
					: cols_[_index];
			}
		}
		#endregion

		#region public int Search(...);
		public int Search(C collectionItem_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (cols_[i].Equals_compareKeysOnly(collectionItem_in)) {
					return i;
				}
			}

			return -1;
		}
		public int Search(params K[] keys_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (cols_[i].Keys_compare(keys_in)) {
					return i;
				}
			}

			return -1;
		}
		#endregion
		#region public virtual void Add(...);
		public virtual void Add(bool ifNotExists_in, params C[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					if (Search(col_in[i]) == -1) {
						Add(col_in[i]);
					}
				}
			}
		}
		public virtual void Add(out int returnIndex_out, bool ifNotExists_in, params C[] col_in) {
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
		#region public void Remove(params K[] keys_in);
		public void Remove(params K[] keys_in) {
			RemoveAt(
				Search(keys_in)
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
		#region public virtual void Add(...);
		/// <summary>
		/// adds one or more items to the collection
		/// </summary>
		/// <param name="returnIndex_out">index position for last added item in the collection </param>
		/// <param name="col_in">item(s) to be added to the collection</param>
		public virtual void Add(out int returnIndex_out, params C[] col_in) {
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
		public virtual void Add(params C[] col_in) {
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
