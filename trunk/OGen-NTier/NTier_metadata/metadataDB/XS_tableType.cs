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
	using System.Xml.Serialization;

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
			this.name_ = name_in;
		}

		#region public metadataExtended.XS_tableType parallel_ref { get; }
		private bool parallel_ref__exists = true;
		private OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableType parallel_ref__ = null;
		private object parallel_ref__locker = new object();

		[XmlIgnore()]
//		[XmlElement("parallel_ref")]
		public OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableType parallel_ref {
			get {

				// check before lock
				if (
					this.parallel_ref__exists
					&&
					(this.parallel_ref__ == null)
				) {

					lock (this.parallel_ref__locker) {

						// double check, thread safer!
						if (
							this.parallel_ref__exists
							&&
							(this.parallel_ref__ == null)
						) {

							// initialization...
							int t
								= this.root_ref.MetadataExtendedCollection[0].Tables.TableCollection.Search(
									this.Name
								);
							if (t < 0) {
								this.parallel_ref__exists = false;
								return null;
							}

							// ...attribution (last thing before unlock)
							this.parallel_ref__
								= this.root_ref.MetadataExtendedCollection[0].Tables.TableCollection[
									t
								];
						}
					}
				}

				return this.parallel_ref__;
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
				if (this.tablefields_onlypk__ == null) {

					lock (this.tablefields_onlypk__locker) {

						// double check, thread safer!
						if (this.tablefields_onlypk__ == null) {

							// initialization...
							XS_tableFieldsType _aux = new XS_tableFieldsType();
							_aux.parent_ref = this;
							_aux.root_ref = this.root_ref;

							for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++)
								if (this.TableFields.TableFieldCollection[f].isPK)
									_aux.TableFieldCollection.Add(
										this.TableFields.TableFieldCollection[f]
									);

							// ...attribution (last thing before unlock)
							this.tablefields_onlypk__ = _aux;
						}
					}
				}

				return this.tablefields_onlypk__;
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
				if (this.tablefields_nopk__ == null) {

					lock (this.tablefields_nopk__locker) {

						// double check, thread safer!
						if (this.tablefields_nopk__ == null) {

							// initialization...
							XS_tableFieldsType _aux = new XS_tableFieldsType();
							_aux.parent_ref = this;
							_aux.root_ref = this.root_ref;

							for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++)
								if (!this.TableFields.TableFieldCollection[f].isPK)
									_aux.TableFieldCollection.Add(
										this.TableFields.TableFieldCollection[f]
									);

							// ...attribution (last thing before unlock)
							this.tablefields_nopk__ = _aux;
						}
					}
				}

				return this.tablefields_nopk__;
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
				if (!this.haspk__beenread) {

					lock (this.haspk__locker) {

						// double check, thread safer!
						if (!this.haspk__beenread) {

							// initialization...
							this.haspk__ = false;
							for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++)
								if (this.TableFields.TableFieldCollection[f].isPK) {
									this.haspk__ = true;
									break;
								}

							// ...attribution (last thing before unlock)
							this.haspk__beenread = true;
						}
					}
				}

				return this.haspk__;
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
				if (!this.hasidentitykey__beenread) {

					lock (this.hasidentitykey__locker) {

						// double check, thread safer!
						if (!this.hasidentitykey__beenread) {

							// initialization...
							this.hasidentitykey__ = false;
							for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++)
								if (this.TableFields.TableFieldCollection[f].isIdentity) {
									this.hasidentitykey__ = true;
									break;
								}

							// ...attribution (last thing before unlock)
							this.hasidentitykey__beenread = true;
						}
					}
				}

				return this.hasidentitykey__;
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
				if (this.identitykey__ == -2) {

					lock (this.identitykey__locker) {

						// double check, thread safer!
						if (this.identitykey__ == -2) {

							// initialization...
							int _aux = -1;
							for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++)
								if (this.TableFields.TableFieldCollection[f].isIdentity) {
									_aux = f;
									break;
								}

							// ...attribution (last thing before unlock)
							this.identitykey__ = _aux;
						}
					}
				}

				return this.identitykey__;
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
				if (this.firstkey__ == -2) {

					lock (this.firstkey__locker) {

						// double check, thread safer!
						if (this.firstkey__ == -2) {

							// initialization...
							int _aux = -1;
							for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++) {
								if (
									(this.TableFields.TableFieldCollection[f].isPK)
									//||
									//(this.TableFields.TableFieldCollection[f].isIdentity)
								) {
									_aux = f;
									break;
								}
							}

							// ...attribution (last thing before unlock)
							this.firstkey__ = _aux;
						}
					}
				}

				return this.firstkey__;
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
				if (!this.canbeconfig__beenread) {

					lock (this.canbeconfig__locker) {

						// double check, thread safer!
						if (!this.canbeconfig__beenread) {

							// initialization...
							if (
								this.canbeconfig__ = (
									!this.parallel_ref.isConfig
									&&
									!this.hasIdentityKey
									&&
									(this.TableFields_onlyPK.TableFieldCollection.Count == 1)
									&&
									(this.TableFields.TableFieldCollection.Count >= 3)
								)
							) {
								int _numFields_thatCanBeName = 0;
								int _numFields_thatCanBeConfig = 0;
								int _numFields_thatCanBeType = 0;
								for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++) {
									if (this.TableFields.TableFieldCollection[f].canBeConfig_Name) _numFields_thatCanBeName++;
									if (this.TableFields.TableFieldCollection[f].canBeConfig_Config) _numFields_thatCanBeConfig++;
									if (this.TableFields.TableFieldCollection[f].canBeConfig_Type) _numFields_thatCanBeType++;
								}
								this.canbeconfig__ = (
									(_numFields_thatCanBeName == 1)
									&&
									(_numFields_thatCanBeConfig >= 1)
									&&
									(_numFields_thatCanBeType >= 1)
								);
							}

							// ...attribution (last thing before unlock)
							this.canbeconfig__beenread = true;
						}
					}
				}

				return this.canbeconfig__;
			}
		}
		#endregion
		#region public bool tableSearches_hasExplicitUniqueIndex { get; }
		[XmlIgnore()]
		[XmlAttribute("tableSearches_hasExplicitUniqueIndex")]
		public bool tableSearches_hasExplicitUniqueIndex {
			get {
				return this.parallel_ref.TableSearches.hasExplicitUniqueIndex;
			}
		}
		#endregion
	}
}
