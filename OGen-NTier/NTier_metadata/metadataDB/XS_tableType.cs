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

namespace OGen.NTier.lib.metadata.metadataDB {
	#if NET_1_1
	public class XS_tableType : XS0_tableType {
	#else
	public partial class XS_tableType {
	#endif
		public XS_tableType (
		) {
		}
		public XS_tableType (
			string name_in
		) {
			name_ = name_in;
		}

		#region public metadataExtended.XS_tableType parallel_ref { get; }
		private OGen.NTier.lib.metadata.metadataExtended.XS_tableType parallel_ref__ = null;

		public OGen.NTier.lib.metadata.metadataExtended.XS_tableType parallel_ref {
			get {
				if (parallel_ref__ == null) {
					parallel_ref__ 
						= root_ref.MetadataExtendedCollection[0].Tables.TableCollection[
							Name
						];
				}
				return parallel_ref__;
			}
		}
		#endregion

		#region public XS_tableFieldsType TableFields_onlyPK { get; }
		private XS_tableFieldsType tablefields_onlypk__ = null;

		public XS_tableFieldsType TableFields_onlyPK {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (tablefields_onlypk__ == null) {
					tablefields_onlypk__ = new XS_tableFieldsType();
					tablefields_onlypk__.parent_ref = this;
					tablefields_onlypk__.root_ref = root_ref;

					for (int f = 0; f < TableFields.TableFieldCollection.Count; f++)
						if (TableFields.TableFieldCollection[f].isPK)
							tablefields_onlypk__.TableFieldCollection.Add(
								TableFields.TableFieldCollection[f]
							);
				}
				return tablefields_onlypk__;
			}
		}
		#endregion
		#region public int hasIdentityKey { get; }
		private int hasidentitykey__ = -2;

		public int hasIdentityKey {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (hasidentitykey__ == -2) {
					hasidentitykey__ = -1;
					for (int f = 0; f < TableFields.TableFieldCollection.Count; f++)
						if (TableFields.TableFieldCollection[f].isIdentity) {
							hasidentitykey__ = f;
							break;
						}
				}
				return hasidentitykey__;
			}
		}
		#endregion
		#region public int firstKey { get; }
		private int firstkey__ = -2;

		public int firstKey {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (firstkey__ == -2) {
					firstkey__ = -1;
					for (int f = 0; f < TableFields.TableFieldCollection.Count; f++) {
						if (
							(TableFields.TableFieldCollection[f].isPK)
							//||
							//(TableFields.TableFieldCollection[f].isIdentity)
						) {
							firstkey__ = f;
							break;
						}
					}
				}
				return firstkey__;
			}
		}
		#endregion
		#region public bool canBeConfig { get; }
		private bool canbeconfig_DONE__ = false;
		private bool canbeconfig__;

		public bool canBeConfig {
			get {
				// this isn't very safe, there's no way to assure that PKs won't be
				// added or removed, but by the time this method is called
				// there won't be any more adding or removing

				if (!canbeconfig_DONE__) {
					if (
						canbeconfig__ = (
							!parallel_ref.isConfig
							&&
							(hasIdentityKey == -1)
							&&
							(TableFields_onlyPK.TableFieldCollection.Count == 1)
							&&
							(TableFields.TableFieldCollection.Count >= 3)
						)
					) {
						int _numFields_thatCanBeName = 0;
						int _numFields_thatCanBeConfig = 0;
						int _numFields_thatCanBeType = 0;
						for (int f = 0; f < TableFields.TableFieldCollection.Count; f++) {
							if (TableFields.TableFieldCollection[f].canBeConfig_Name) _numFields_thatCanBeName++;
							if (TableFields.TableFieldCollection[f].canBeConfig_Config) _numFields_thatCanBeConfig++;
							if (TableFields.TableFieldCollection[f].canBeConfig_Type) _numFields_thatCanBeType++;
						}
						canbeconfig__ = (
							(_numFields_thatCanBeName == 1)
							&&
							(_numFields_thatCanBeConfig >= 1)
							&&
							(_numFields_thatCanBeType >= 1)
						);
					}

					canbeconfig_DONE__ = true;
				}

				return canbeconfig__;
			}
		}
		#endregion
	}
}
