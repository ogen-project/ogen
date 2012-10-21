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
		private bool parallel_ref__exists = true;
		private OGen.NTier.lib.metadata.metadataExtended.XS_tableType parallel_ref__ = null;
		private object parallel_ref__locker = new object();

		[XmlIgnore()]
//		[XmlElement("parallel_ref")]
		public OGen.NTier.lib.metadata.metadataExtended.XS_tableType parallel_ref {
			get {

				// check before lock
				if (
					parallel_ref__exists
					&&
					(parallel_ref__ == null)
				) {

					lock (parallel_ref__locker) {

						// double check, thread safer!
						if (
							parallel_ref__exists
							&&
							(parallel_ref__ == null)
						) {

							int t
								= root_ref.MetadataExtendedCollection[0].Tables.TableCollection.Search(
									Name
								);
							if (t < 0) {
								parallel_ref__exists = false;
								return null;
							}

							parallel_ref__
								= root_ref.MetadataExtendedCollection[0].Tables.TableCollection[
									t
								];
						}
					}
				}

				return parallel_ref__;
			}
		}
		#endregion

		#region public XS_tableFieldsType TableFields_onlyPK { get; }
		private XS_tableFieldsType tablefields_onlypk__ = null;
		private object tablefields_onlypk__locker = new object();

		public XS_tableFieldsType TableFields_onlyPK {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (tablefields_onlypk__ == null) {

					lock (tablefields_onlypk__locker) {

						// double check, thread safer!
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
					}
				}

				return tablefields_onlypk__;
			}
		}
		#endregion
		#region public XS_tableFieldsType TableFields_noPK { get; }
		private XS_tableFieldsType tablefields_nopk__ = null;
		private object tablefields_nopk__locker = new object();

		public XS_tableFieldsType TableFields_nopk {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (tablefields_nopk__ == null) {

					lock (tablefields_nopk__locker) {

						// double check, thread safer!
						if (tablefields_nopk__ == null) {

							tablefields_nopk__ = new XS_tableFieldsType();
							tablefields_nopk__.parent_ref = this;
							tablefields_nopk__.root_ref = root_ref;

							for (int f = 0; f < TableFields.TableFieldCollection.Count; f++)
								if (!TableFields.TableFieldCollection[f].isPK)
									tablefields_nopk__.TableFieldCollection.Add(
										TableFields.TableFieldCollection[f]
									);
						}
					}
				}

				return tablefields_nopk__;
			}
		}
		#endregion
		#region public bool hasPK { get; }
		private bool haspk__beenread = false;
		private object haspk__locker = new object();
		private bool haspk__;

		[XmlIgnore()]
		[XmlAttribute("hasPK")]
		public bool hasPK {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (!haspk__beenread) {

					lock (haspk__locker) {

						// double check, thread safer!
						if (!haspk__beenread) {

							haspk__ = false;
							for (int f = 0; f < TableFields.TableFieldCollection.Count; f++)
								if (TableFields.TableFieldCollection[f].isPK) {
									haspk__ = true;
									break;
								}

							haspk__beenread = true;
						}
					}
				}

				return haspk__;
			}
		}
		#endregion
		#region public bool hasIdentityKey { get; }
		private bool hasidentitykey__beenread = false;
		private object hasidentitykey__locker = new object();
		private bool hasidentitykey__;

		[XmlIgnore()]
		[XmlAttribute("hasIdentityKey")]
		public bool hasIdentityKey {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (!hasidentitykey__beenread) {

					lock (hasidentitykey__locker) {

						// double check, thread safer!
						if (!hasidentitykey__beenread) {

							hasidentitykey__ = false;
							for (int f = 0; f < TableFields.TableFieldCollection.Count; f++)
								if (TableFields.TableFieldCollection[f].isIdentity) {
									hasidentitykey__ = true;
									break;
								}

							hasidentitykey__beenread = true;
						}
					}
				}

				return hasidentitykey__;
			}
		}
		#endregion
		#region public int IdentityKey { get; }
		private object identitykey__locker = new object();
		private int identitykey__ = -2;

//		[XmlIgnore()]
//		[XmlAttribute("identityKey")]
		public int IdentityKey {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (identitykey__ == -2) {

					lock (identitykey__locker) {

						// double check, thread safer!
						if (identitykey__ == -2) {

							identitykey__ = -1;
							for (int f = 0; f < TableFields.TableFieldCollection.Count; f++)
								if (TableFields.TableFieldCollection[f].isIdentity) {
									identitykey__ = f;
									break;
								}
						}
					}
				}

				return identitykey__;
			}
		}
		#endregion
		#region public int firstKey { get; }
		private object firstkey__locker = new object();
		private int firstkey__ = -2;

		public int firstKey {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (firstkey__ == -2) {

					lock (firstkey__locker) {

						// double check, thread safer!
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
					}
				}

				return firstkey__;
			}
		}
		#endregion
		#region public bool canBeConfig { get; }
		private bool canbeconfig__beenread = false;
		private object canbeconfig__locker = new object();
		private bool canbeconfig__;

		public bool canBeConfig {
			get {
				// caching isn't safe, there's no way to assure that items won't be
				// added or removed, however by the time this method is called
				// there won't be any more adding or removing

				// check before lock
				if (!canbeconfig__beenread) {

					lock (canbeconfig__locker) {

						// double check, thread safer!
						if (!canbeconfig__beenread) {

							if (
								canbeconfig__ = (
									!parallel_ref.isConfig
									&&
									!hasIdentityKey
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

							canbeconfig__beenread = true;
						}
					}
				}

				return canbeconfig__;
			}
		}
		#endregion
		#region public bool tableSearches_hasExplicitUniqueIndex { get; }
		[XmlIgnore()]
		[XmlAttribute("tableSearches_hasExplicitUniqueIndex")]
		public bool tableSearches_hasExplicitUniqueIndex {
			get {
				return parallel_ref.TableSearches.hasExplicitUniqueIndex;
			}
		}
		#endregion
	}
}
