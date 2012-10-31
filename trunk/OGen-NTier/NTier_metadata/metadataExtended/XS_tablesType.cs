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
	public class XS_tablesType : XS0_tablesType {
	#else
	public partial class XS_tablesType {
	#endif

		#region public bool hasVirtualTable_withUndefinedKeys { get; }
		private bool hasvirtualtable_withundefinedkeys_DONE__ = false;
		private bool hasvirtualtable_withundefinedkeys__;
		private object hasvirtualtable_withundefinedkeys__locker = new object();

		public bool hasVirtualTable_withUndefinedKeys {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (!this.hasvirtualtable_withundefinedkeys_DONE__) {

					lock (this.hasvirtualtable_withundefinedkeys__locker) {

						// double check, thread safer!
						if (!this.hasvirtualtable_withundefinedkeys_DONE__) {

							// initialization...
							this.hasvirtualtable_withundefinedkeys__ = false;
							for (int t = 0; t < this.TableCollection.Count; t++)
								if (this.TableCollection[t].isVirtualTable)
									if (
										this.TableCollection[t].parallel_ref
											.TableFields_onlyPK.TableFieldCollection
												.Count == 0
									) {
										this.hasvirtualtable_withundefinedkeys__ = true;
										break;
									}

							// ...attribution (last thing before unlock)
							this.hasvirtualtable_withundefinedkeys_DONE__ = true;
						}
					}
				}

				return this.hasvirtualtable_withundefinedkeys__;
			}
		}
		#endregion
		#region public bool hasConfigTable { get; }
		private bool hasconfigtable__;
		private bool hasconfigtable_DONE__ = false;
		private object hasconfigtable__locker = new object();

		public bool hasConfigTable {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (!this.hasconfigtable_DONE__) {

					lock (this.hasconfigtable__locker) {

						// double check, thread safer!
						if (!this.hasconfigtable_DONE__) {

							// initialization...
							this.hasconfigtable__ = false;
							for (int t = 0; t < this.TableCollection.Count; t++)
								if (this.TableCollection[t].isConfig) {
									this.hasconfigtable__ = true;
									break;
								}

							// ...attribution (last thing before unlock)
							this.hasconfigtable_DONE__ = true;
						}
					}
				}

				return this.hasconfigtable__;
			}
		}
		#endregion
	}
}
