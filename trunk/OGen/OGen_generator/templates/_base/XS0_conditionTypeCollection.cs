#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Libraries.Templates {
	using System;
	using System.Collections;
	#if !NET_1_1
	using System.Collections.Generic;
	#endif
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_conditionTypeCollection {
	#else
	public partial class XS_conditionTypeCollection {
	#endif
		#if NET_1_1
		public XS0_conditionTypeCollection() {
		#else
		public XS_conditionTypeCollection() {
		#endif
			this.cols_ = new
				#if NET_1_1
				ArrayList()
				#else
				List<XS_conditionType>()
				#endif
			;
		}


		#region internal XS_conditionType[] cols__ { get; set; }
		#if NET_1_1
		protected ArrayList
		#else
		private List<XS_conditionType>
		#endif
		cols_;

		internal XS_conditionType[] cols__ {
			get {
				XS_conditionType[] _output = new XS_conditionType[this.cols_.Count];
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

		#region public XS_conditionType this[int index_in] { get; }
		public XS_conditionType this[int index_in] {
			get {
				return 
					#if NET_1_1
					(XS_conditionType)
					#endif
					this.cols_[index_in]
				;
			}
		}
		#endregion
		#region public XS_conditionType this[...] { get; }
		public XS_conditionType this[
			string eval_in
		] {
			get {
				int _index = this.Search(
					eval_in
				);
				return (_index == -1)
					? null
					: 
						#if NET_1_1
						(XS_conditionType)
						#endif
						this.cols_[_index]
				;
			}
		}
		#endregion

		#region public void Remove(...);
		public void Remove(
			string eval_in
		) {
			this.RemoveAt(
				this.Search(
					eval_in
				)
			);
		}
		#endregion
		#region public int Search(...);
		public int Search(
			string eval_in
		) {
			return this.Search(
				eval_in, 
				true
			);
		}

		public int Search(
			string eval_in, 
			bool eval_caseSensitive_in
		) {
			for (int i = 0; i < this.cols_.Count; i++) {
				if (
					(
						(
							eval_caseSensitive_in
							&&
							(
								#if NET_1_1
								((XS_conditionType)this.cols_[i])
								#else
								this.cols_[i]
								#endif
									.Eval
								==
								eval_in 
							)
						)
						||
						(
							!eval_caseSensitive_in
							&&
							(
								#if NET_1_1
								((XS_conditionType)this.cols_[i])
								#else
								this.cols_[i]
								#endif
									.Eval.Equals(
										eval_in,
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
		public int Search(XS_conditionType collectionItem_in) {
			for (int i = 0; i < this.cols_.Count; i++) {
				if (
					(
						#if NET_1_1
						((XS_conditionType)this.cols_[i])
						#else
						this.cols_[i]
						#endif
							.Eval.Equals(
								collectionItem_in.Eval,
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
			string eval_in
		) {

			// ToDos: here! this is not thread safe!

			if (
				// even if exists
				!onlyIfNotExists_in
				||
				// doesn't exist
				(this.Search(
					eval_in
				) == -1)
			) {
				this.Add(
					eval_in
				);
			}
		}
		public virtual void Add(
			out int returnIndex_out, 
			bool onlyIfNotExists_in, 
			string eval_in
		) {

			// ToDos: here! this is not thread safe!

			if (
				// even if exists
				!onlyIfNotExists_in
				||
				// doesn't exist
				((returnIndex_out = this.Search(
					eval_in
				)) == -1)
			) {
				this.Add(
					out returnIndex_out,
					eval_in
				);
			}
		}
		public void Add(
			string eval_in
		) {
			this.Add(new XS_conditionType(
				eval_in
			));
		}
		public void Add(
			out int returnIndex_out,
			string eval_in
		) {
			this.Add(
				out returnIndex_out, 
				new XS_conditionType(
					eval_in
				)
			);
		}
		public virtual void Add(bool onlyIfNotExists_in, params XS_conditionType[] col_in) {

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
		public virtual void Add(out int returnIndex_out, bool onlyIfNotExists_in, params XS_conditionType[] col_in) {

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
		public void Add(params XS_conditionType[] col_in) {
			int _index = -1;
			this.Add(out _index, col_in);
		}
		public void Add(out int returnIndex_out, params XS_conditionType[] col_in) {
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