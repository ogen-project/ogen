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

	public class OGenSimpleCollection<TCollectionItem>
		where TCollectionItem : class 
	{
		public OGenSimpleCollection(
		) {
			this.cols_ = new List<TCollectionItem>();
		}

		#region public C[] cols__ { get; set; }
		protected List<TCollectionItem> cols_;

		public TCollectionItem[] cols__ {
			get {
				TCollectionItem[] _output = new TCollectionItem[this.cols_.Count];
				this.cols_.CopyTo(_output);
				return _output;
			}
			set {
				this.cols_.Clear();
				if (value != null) {
					for (int i = 0; i < value.Length; i++) {
						this.cols_.Add(value[i]);
					}
				}
			}
		}
		#endregion

		#region public int Count { get; }
		public int Count {
			get {
				return this.cols_.Count;
			}
		}
		#endregion

		#region public C this[int index_in] { get; }
		public TCollectionItem this[int index_in] {
			get {
				return this.cols_[index_in];
			}
		}
		#endregion

		#region public void Clear();
		public void Clear() {
			this.cols_.Clear();
		}
		#endregion
		#region public virtual void Add(...);
		/// <summary>
		/// adds one or more items to the collection
		/// </summary>
		/// <param name="returnIndex_out">index position for last added item in the collection </param>
		/// <param name="col_in">item(s) to be added to the collection</param>
		public virtual void Add(out int returnIndex_out, params TCollectionItem[] col_in) {
			returnIndex_out = -1;

			for (int i = 0; i < col_in.Length - 1; i++) {
				this.cols_.Add(col_in[i]);
			}

			int j = col_in.Length - 1;
			if (j >= 0) {
				lock (this.cols_) {
					this.cols_.Add(col_in[j]);
					returnIndex_out = this.cols_.Count - 1;
				}
			}
		}

		/// <summary>
		/// adds one or more items to the collection
		/// </summary>
		/// <param name="col_in">item(s) to be added to the collection</param>
		public virtual void Add(params TCollectionItem[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				this.cols_.Add(col_in[i]);
			}
		}
		#endregion
		#region public void RemoveAt(int index_in);
		public void RemoveAt(int index_in) {
			this.cols_.RemoveAt(index_in);
		}
		#endregion
	}
}
#endif