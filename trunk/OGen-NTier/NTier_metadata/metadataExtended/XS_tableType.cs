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

		#region public XS_tableFieldType ListItemValue { get; }
		public XS_tableFieldType ListItemValue {
			get {
				for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++) {
					if (this.TableFields.TableFieldCollection[f].isListItemValue) {
						return this.TableFields.TableFieldCollection[f];
					}
				}
				return null;
			}
		}
		#endregion
		#region public XS_tableFieldType ListItemText { get; }
		public XS_tableFieldType ListItemText {
			get {
				for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++) {
					if (this.TableFields.TableFieldCollection[f].isListItemText) {
						return this.TableFields.TableFieldCollection[f];
					}
				}
				return null;
			}
		}
		#endregion

		#region public bool hasPK { get; }
		[XmlIgnore()]
		[XmlAttribute("hasPK")]
		public bool hasPK {
			get {
				return this.parallel_ref.hasPK;
			}
		}
		#endregion

		#region public metadataDB.XS_tableType parallel_ref { get; }
		private bool parallel_ref__exists = true;
		private OGen.NTier.lib.metadata.metadataDB.XS_tableType parallel_ref__ = null;
		private object parallel_ref__locker = new object();

		[XmlIgnore()]
//		[XmlElement("parallel_ref")]
		public OGen.NTier.lib.metadata.metadataDB.XS_tableType parallel_ref {
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
								= this.root_ref.MetadataDBCollection[0].Tables.TableCollection.Search(
									this.Name
								);
							if (t < 0) {
								// ...attribution (last thing before unlock)
								this.parallel_ref__exists = false;
								return null;
							}

							// ...attribution (last thing before unlock)
							this.parallel_ref__
								= this.root_ref.MetadataDBCollection[0].Tables.TableCollection[
									t
								];
						}
					}
				}

				return this.parallel_ref__;
			}
		}
		#endregion
		#region public bool isListItem(...);
		public bool isListItem() {
			for (int f = 0; f < this.TableFields.TableFieldCollection.Count; f++) {
				if (
					(this.TableFields.TableFieldCollection[f].isListItemText)
					||
					(this.TableFields.TableFieldCollection[f].isListItemValue)
				) {
					return true;
				}
			}
			return false;
		}
		#endregion
	}
}
