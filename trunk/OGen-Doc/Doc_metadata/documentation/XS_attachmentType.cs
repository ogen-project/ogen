#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Doc.Libraries.Metadata.Documentation {
	using System;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS_attachmentType : XS0_attachmentType {
	#else
	public partial class XS_attachmentType {
	#endif

		#region private int NumberOf(XS_SourceContentTypeEnumeration sourceContentType_in);
		private int NumberOf(XS_SourceContentTypeEnumeration sourceContentType_in) {
			int _counter = 0;
			XS_attachmentTypeCollection _parent = (XS_attachmentTypeCollection)this.parent_ref;
			for (int a = 0; a < _parent.Count; a++) {
				if (_parent[a].SourceContentType == sourceContentType_in)
					_counter++;

				if (_parent[a].Title == this.Title) {
					return _counter;
				}
			}

			return -1;
		}
		#endregion

		#region public int ImageNumber { get; }
		private int imagenumber__ = -2;
		private object imagenumber__locker = new object();

		public int ImageNumber {
			get {

				// check before lock
				if (this.imagenumber__ == -2) {

					lock (this.imagenumber__locker) {

						// double check, thread safer!
						if (this.imagenumber__ == -2) {

							this.imagenumber__ = this.NumberOf(XS_SourceContentTypeEnumeration.image);
						}
					}
				}
				return this.imagenumber__;
			}
		}
		#endregion
		#region public int TableNumber { get; }
		private int tablenumber__ = -2;
		private object tablenumber__locker = new object();

		public int TableNumber {
			get {

				// check before lock
				if (this.tablenumber__ == -2) {

					lock (this.tablenumber__locker) {

						// double check, thread safer!
						if (this.tablenumber__ == -2) {

							this.tablenumber__ = this.NumberOf(XS_SourceContentTypeEnumeration.table);
						}
					}
				}

				return this.tablenumber__;
			}
		}
		#endregion
		#region public int CodeNumber { get; }
		private int codenumber__ = -2;
		private object codenumber__locker = new object();

		public int CodeNumber {
			get {

				// check before lock
				if (this.codenumber__ == -2) {

					lock (this.codenumber__locker) {

						// double check, thread safer!
						if (this.codenumber__ == -2) {

							this.codenumber__ = this.NumberOf(XS_SourceContentTypeEnumeration.code);
						}
					}
				}
				return this.codenumber__;
			}
		}
		#endregion
	}
}