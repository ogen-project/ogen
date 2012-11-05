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

	public class OGenRootrefCollection<TCollectionItem, TRootRef, TKey> : OGenCollection<TCollectionItem, TKey>
		where TCollectionItem : 
			class,
			OGenCollectionInterface<TCollectionItem, TKey>, 
			OGenRootrefCollectionInterface<TRootRef>
		where TRootRef : class
		where TKey : struct
	{
		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return this.parent_ref_;
			}
			set {
				this.parent_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					this.cols_[i].parent_ref = this;
				}
			}
		}
		#endregion
		#region public R root_ref { get; }
		private TRootRef root_ref_;

		public TRootRef root_ref {
			get {
				return this.root_ref_;
			}
			set {
				this.root_ref_ = value;
				for (int i = 0; i < cols_.Count; i++) {
					cols_[i].root_ref = value;
				}
			}
		}
		#endregion
		#region private void refresh_refs(params C[] col_in);
		private void refresh_refs(params TCollectionItem[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				col_in[i].parent_ref = this;
				col_in[i].root_ref = this.root_ref;
			}
		}
		#endregion

		#region public override void Add(...);
		public override void Add(bool ifNotExists_in, params TCollectionItem[] col_in) {
			this.refresh_refs(col_in);
			base.Add(ifNotExists_in, col_in);
		}
		public override void Add(out int returnIndex_out, bool ifNotExists_in, params TCollectionItem[] col_in) {
			this.refresh_refs(col_in);
			base.Add(out returnIndex_out, ifNotExists_in, col_in);
		}
		public override void Add(out int returnIndex_out, params TCollectionItem[] col_in) {
			this.refresh_refs(col_in);
			base.Add(out returnIndex_out, col_in);
		}
		public override void Add(params TCollectionItem[] col_in) {
			this.refresh_refs(col_in);
			base.Add(col_in);
		}
		#endregion
	}
}
#endif