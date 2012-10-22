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
using System.Collections;
#if !NET_1_1
using System.Collections.Generic;
#endif

namespace OGen.NTier.lib.metadata.metadataDB {
	#if NET_1_1
	public class XS_tableFieldTypeCollection : XS0_tableFieldTypeCollection {
	#else
	public partial class XS_tableFieldTypeCollection {
	#endif

		#region public int Count_onlyPK { get; }
		private int count_onlypk__ = -2;
		private object count_onlypk__locker = new object();

		public int Count_onlyPK {
			get {

				// check before lock
				if (count_onlypk__ == -2) {

					lock (count_onlypk__locker) {

						// double check, thread safer!
						if (count_onlypk__ == -2) {

							// initialization...
							int _count = 0;
							for (int f = 0; f < this.Count; f++) {
								if (this[f].isPK) _count++;
							}

							// ...attribution (last thing before unlock)
							count_onlypk__ = _count;
						}
					}
				}

				return count_onlypk__;
			}
		}
		#endregion
	}
}