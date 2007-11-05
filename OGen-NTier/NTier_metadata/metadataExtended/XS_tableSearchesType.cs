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

using OGen.lib.collections;

namespace OGen.NTier.lib.metadata.metadataExtended {
	#if NET_1_1
	public class XS_tableSearchesType : XS0_tableSearchesType {
	#else
	public partial class XS_tableSearchesType {
	#endif
		public XS_tableSearchesType (
		) {
			tablesearchcollection_ = new XS_tableSearchTypeCollection();
		}

		#region public bool hasExplicitUniqueIndex { get; }
		private bool hasexplicituniqueindex_DONE__ = false;
		private bool hasexplicituniqueindex__;

		public bool hasExplicitUniqueIndex {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (!hasexplicituniqueindex_DONE__) {
					hasexplicituniqueindex__ = false;
					for (int s = 0; s < TableSearchCollection.Count; s++) {
						if (TableSearchCollection[s].isExplicitUniqueIndex) {
							hasexplicituniqueindex__ = true;
							break;
						}
					}

					hasexplicituniqueindex_DONE__ = true;
				}

				return hasexplicituniqueindex__;
			}
		}
		#endregion
	}
}
