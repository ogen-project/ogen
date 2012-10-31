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
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS_tableSearchesType : XS0_tableSearchesType {
	#else
	public partial class XS_tableSearchesType {
	#endif

		#region public bool hasExplicitUniqueIndex { get; }
		private bool hasexplicituniqueindex_DONE__ = false;
		private bool hasexplicituniqueindex__;
		private object hasexplicituniqueindex__locker = new object();

		public bool hasExplicitUniqueIndex {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (!this.hasexplicituniqueindex_DONE__) {

					lock (this.hasexplicituniqueindex__locker) {

						// double check, thread safer!
						if (!this.hasexplicituniqueindex_DONE__) {

							// initialization...
							this.hasexplicituniqueindex__ = false;
							for (int s = 0; s < this.TableSearchCollection.Count; s++) {
								if (this.TableSearchCollection[s].isExplicitUniqueIndex) {
									this.hasexplicituniqueindex__ = true;
									break;
								}
							}

							// ...attribution (last thing before unlock)
							this.hasexplicituniqueindex_DONE__ = true;
						}
					}
				}

				return this.hasexplicituniqueindex__;
			}
		}
		#endregion
	}
}
