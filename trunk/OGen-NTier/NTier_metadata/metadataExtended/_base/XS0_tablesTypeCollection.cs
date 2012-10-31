#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataExtended {
	using System;
	using System.Collections;
	#if !NET_1_1
	using System.Collections.Generic;
	#endif
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tablesTypeCollection {
	#else
	public partial class XS_tablesTypeCollection {
	#endif
		#if NET_1_1
		public XS0_tablesTypeCollection() {
		#else
		public XS_tablesTypeCollection() {
		#endif
			this.cols_ = new
				#if NET_1_1
				ArrayList()
				#else
				List<XS_tablesType>()
				#endif
			;
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		public object parent_ref {
			get {
				return this.parent_ref_;
			}
			set {
				this.parent_ref_ = value;
				for (int i = 0; i < this.cols_.Count; i++) {
					#if NET_1_1
					((XS_tablesType)this.cols_[i])
					#else
					this.cols_[i]
					#endif
						.parent_ref = this;
				}
			}
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		private XS__RootMetadata root_ref_;

		public XS__RootMetadata root_ref {
			get {
				return this.root_ref_;
			}
			set {
				this.root_ref_ = value;
				for (int i = 0; i < this.cols_.Count; i++) {
					#if NET_1_1
					((XS_tablesType)this.cols_[i])
					#else
					this.cols_[i]
					#endif
						.root_ref = value;
				}
			}
		}
		#endregion
		#region private void refresh_refs(params XS_tablesType[] col_in);
		private void refresh_refs(params XS_tablesType[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				col_in[i].parent_ref = this;
				col_in[i].root_ref = this.root_ref;
			}
		}
		#endregion

		#region internal XS_tablesType[] cols__ { get; set; }
		#if NET_1_1
		protected ArrayList
		#else
		private List<XS_tablesType>
		#endif
		cols_;

		internal XS_tablesType[] cols__ {
			get {
				XS_tablesType[] _output = new XS_tablesType[this.cols_.Count];
				this.cols_.CopyTo(_output);
				return _output;
			}
			set {
				lock (this.cols_) {
					this.cols_.Clear();
					if (value != null) {
						for (int i = 0; i < value.Length; i++) {
							this.cols_.Add(value[i]);
						}
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

		#region public XS_tablesType this[int index_in] { get; }
		public XS_tablesType this[int index_in] {
			get {
				return 
					#if NET_1_1
					(XS_tablesType)
					#endif
					this.cols_[index_in]
				;
			}
		}
		#endregion
		#region public void Clear();
		public void Clear() {
			this.cols_.Clear();
		}
		#endregion
		#region public void RemoveAt(int index_in);
		public void RemoveAt(int index_in) {
			this.cols_.RemoveAt(index_in);
		}
		#endregion
		#region public void Add(...);
		public void Add(params XS_tablesType[] col_in) {
			int _index = -1;
			this.Add(out _index, col_in);
		}
		public void Add(out int returnIndex_out, params XS_tablesType[] col_in) {
			this.refresh_refs(col_in);

			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length - 1; i++) {
				this.cols_.Add(col_in[i]);
			}

			int j = col_in.Length - 1;
			if (j >= 0) {
				#if NET_1_1
				returnIndex_out = this.cols_.Add(col_in[j]);
				#else
				lock (this.cols_) {
					this.cols_.Add(col_in[j]);
					returnIndex_out = this.cols_.Count - 1;
				}
				#endif
			}
		}
		#endregion
	}
}