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
	public class XS_tablesType : XS0_tablesType
	#else
	public partial class XS_tablesType {
	#endif
		public XS_tablesType (
		) {
			tablecollection_ = new XS_tableTypeCollection();
		}

		#region public bool hasVirtualTable_withUndefinedKeys { get; }
		private bool hasvirtualtable_withundefinedkeys_DONE__ = false;
		private bool hasvirtualtable_withundefinedkeys__;

		public bool hasVirtualTable_withUndefinedKeys {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (!hasvirtualtable_withundefinedkeys_DONE__) {
					hasvirtualtable_withundefinedkeys__ = false;
					for (int t = 0; t < TableCollection.Count; t++)
						if (TableCollection[t].isVirtualTable)
							if (
								TableCollection[t].parallel_ref
									.TableFields_onlyPK.TableFieldCollection
										.Count == 0
							) {
								hasvirtualtable_withundefinedkeys__ = true;
								break;
							}

					hasvirtualtable_withundefinedkeys_DONE__ = true;
				}

				return hasvirtualtable_withundefinedkeys__;
			}
		}
		#endregion
		#region public bool hasConfigTable { get; }
		private bool hasconfigtable__;
		private bool hasconfigtable_DONE__ = false;

		public bool hasConfigTable {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (!hasconfigtable_DONE__) {
					hasconfigtable__ = false;
					for (int t = 0; t < TableCollection.Count; t++)
						if (TableCollection[t].isConfig) {
							hasconfigtable__ = true;
							break;
						}

					hasconfigtable_DONE__ = true;
				}

				return hasconfigtable__;
			}
		}
		#endregion
	}
}
