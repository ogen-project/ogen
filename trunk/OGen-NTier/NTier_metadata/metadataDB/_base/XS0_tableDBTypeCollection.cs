#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.Libraries.Metadata.MetadataDB {
	using System;
	using System.Collections;
	#if !NET_1_1
	using System.Collections.Generic;
	#endif
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tableDBTypeCollection {
	#else
	public partial class XS_tableDBTypeCollection {
	#endif
		#if NET_1_1
		public XS0_tableDBTypeCollection() {
		#else
		public XS_tableDBTypeCollection() {
		#endif
			this.cols_ = new
				#if NET_1_1
				ArrayList()
				#else
				List<XS_tableDBType>()
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
					((XS_tableDBType)this.cols_[i])
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
					((XS_tableDBType)this.cols_[i])
					#else
					this.cols_[i]
					#endif
						.root_ref = value;
				}
			}
		}
		#endregion
		#region private void refresh_refs(params XS_tableDBType[] col_in);
		private void refresh_refs(params XS_tableDBType[] col_in) {
			for (int i = 0; i < col_in.Length; i++) {
				col_in[i].parent_ref = this;
				col_in[i].root_ref = this.root_ref;
			}
		}
		#endregion

		#region internal XS_tableDBType[] cols__ { get; set; }
		#if NET_1_1
		protected ArrayList
		#else
		private List<XS_tableDBType>
		#endif
		cols_;

		internal XS_tableDBType[] cols__ {
			get {
				XS_tableDBType[] _output = new XS_tableDBType[this.cols_.Count];
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

		#region public XS_tableDBType this[int index_in] { get; }
		public XS_tableDBType this[int index_in] {
			get {
				return 
					#if NET_1_1
					(XS_tableDBType)
					#endif
					this.cols_[index_in]
				;
			}
		}
		#endregion
		#region public XS_tableDBType this[...] { get; }
		public XS_tableDBType this[
			string dbServerType_in
		] {
			get {
				int _index = this.Search(
					dbServerType_in
				);
				return (_index == -1)
					? null
					: 
						#if NET_1_1
						(XS_tableDBType)
						#endif
						this.cols_[_index]
				;
			}
		}
		#endregion

		#region public void Remove(...);
		public void Remove(
			string dbServerType_in
		) {
			this.RemoveAt(
				this.Search(
					dbServerType_in
				)
			);
		}
		#endregion
		#region public int Search(...);
		public int Search(
			string dbServerType_in
		) {
			return this.Search(
				dbServerType_in, 
				true
			);
		}

		public int Search(
			string dbServerType_in, 
			bool dbServerType_caseSensitive_in
		) {
			for (int i = 0; i < this.cols_.Count; i++) {
				if (
					(
						(
							dbServerType_caseSensitive_in
							&&
							(
								#if NET_1_1
								((XS_tableDBType)this.cols_[i])
								#else
								this.cols_[i]
								#endif
									.DBServerType
								==
								dbServerType_in 
							)
						)
						||
						(
							!dbServerType_caseSensitive_in
							&&
							(
								#if NET_1_1
								((XS_tableDBType)this.cols_[i])
								#else
								this.cols_[i]
								#endif
									.DBServerType.Equals(
										dbServerType_in,
										StringComparison.CurrentCultureIgnoreCase
									)
							)
						)
					)
				) {
					return i;
				}
			}

			return -1;
		}
		public int Search(XS_tableDBType collectionItem_in) {
			for (int i = 0; i < this.cols_.Count; i++) {
				if (
					(
						#if NET_1_1
						((XS_tableDBType)this.cols_[i])
						#else
						this.cols_[i]
						#endif
							.DBServerType.Equals(
								collectionItem_in.DBServerType,
								StringComparison.CurrentCulture
							)
					)
					
				) {
					return i;
				}
			}

			return -1;
		}
		#endregion
		#region public void Add(...);
		public virtual void Add(
			bool onlyIfNotExists_in,
			string dbServerType_in
		) {

			// ToDos: here! this is not thread safe!

			if (
				// even if exists
				!onlyIfNotExists_in
				||
				// doesn't exist
				(this.Search(
					dbServerType_in
				) == -1)
			) {
				this.Add(
					dbServerType_in
				);
			}
		}
		public virtual void Add(
			out int returnIndex_out, 
			bool onlyIfNotExists_in, 
			string dbServerType_in
		) {

			// ToDos: here! this is not thread safe!

			if (
				// even if exists
				!onlyIfNotExists_in
				||
				// doesn't exist
				((returnIndex_out = this.Search(
					dbServerType_in
				)) == -1)
			) {
				this.Add(
					out returnIndex_out,
					dbServerType_in
				);
			}
		}
		public void Add(
			string dbServerType_in
		) {
			this.Add(new XS_tableDBType(
				dbServerType_in
			));
		}
		public void Add(
			out int returnIndex_out,
			string dbServerType_in
		) {
			this.Add(
				out returnIndex_out, 
				new XS_tableDBType(
					dbServerType_in
				)
			);
		}
		public virtual void Add(bool onlyIfNotExists_in, params XS_tableDBType[] col_in) {

			// ToDos: here! this is not thread safe!

			for (int i = 0; i < col_in.Length; i++) {
				if (
					// even if exists
					!onlyIfNotExists_in
					||
					// doesn't exist
					(this.Search(col_in[i]) == -1)
				) {
					this.Add(col_in[i]);
				}
			}
		}
		public virtual void Add(out int returnIndex_out, bool onlyIfNotExists_in, params XS_tableDBType[] col_in) {

			// ToDos: here! this is not thread safe!

			returnIndex_out = -1;
			for (int i = 0; i < col_in.Length; i++) {
				if (
					// even if exists
					!onlyIfNotExists_in
					||
					// doesn't exist
					((returnIndex_out = this.Search(col_in[i])) == -1)
				) {
					this.Add(out returnIndex_out, col_in[i]);
				}
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
		public void Add(params XS_tableDBType[] col_in) {
			int _index = -1;
			this.Add(out _index, col_in);
		}
		public void Add(out int returnIndex_out, params XS_tableDBType[] col_in) {
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