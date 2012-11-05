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

namespace OGen.Libraries.Collections {
	using System;
	using System.Collections.Generic;

	public class OGenCollection<TCollectionItem, TKey> : OGenSimpleCollection<TCollectionItem>
		where TCollectionItem : class, OGenCollectionInterface<TCollectionItem, TKey>
		where TKey : struct
	{
		#region public C this[...] { get; }
		public TCollectionItem this[TCollectionItem collectionItem_in] {
			get {
				int _index = this.Search(collectionItem_in);
				return (_index == -1)
					? null
					: this.cols_[_index];
			}
		}
		public TCollectionItem this[params TKey[] keys_in] {
			get {
				int _index = this.Search(keys_in);
				return (_index == -1)
					? null
					: this.cols_[_index];
			}
		}
		#endregion

		#region public int Search(...);
		public int Search(TCollectionItem collectionItem_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (cols_[i].Equals_compareKeysOnly(collectionItem_in)) {
					return i;
				}
			}

			return -1;
		}
		public int Search(params TKey[] keys_in) {
			for (int i = 0; i < cols_.Count; i++) {
				if (cols_[i].Keys_compare(keys_in)) {
					return i;
				}
			}

			return -1;
		}
		#endregion
		#region public virtual void Add(...);
		public virtual void Add(bool ifNotExists_in, params TCollectionItem[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					if (this.Search(col_in[i]) == -1) {
						this.Add(col_in[i]);
					}
				}
			}
		}
		public virtual void Add(out int returnIndex_out, bool ifNotExists_in, params TCollectionItem[] col_in) {
			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length; i++) {
				if (ifNotExists_in) {
					returnIndex_out = this.Search(col_in[i]);
					if (returnIndex_out == -1) {
						this.Add(out returnIndex_out, col_in[i]);
					}
				}
			}
		}
		#endregion
		#region public void Remove(params K[] keys_in);
		public void Remove(params TKey[] keys_in) {
			this.RemoveAt(
				this.Search(keys_in)
			);
		}
		#endregion
	}
}
#endif