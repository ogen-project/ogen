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

namespace OGen.NTier.lib.metadata.metadataExtended {
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

		#region public XS_tableFieldType ListItemValue { get; }
		public XS_tableFieldType ListItemValue {
			get {
				for (int f = 0; f < TableFields.TableFieldCollection.Count; f++) {
					if (TableFields.TableFieldCollection[f].isListItemValue) {
						return TableFields.TableFieldCollection[f];
					}
				}
				return null;
			}
		}
		#endregion
		#region public XS_tableFieldType ListItemText { get; }
		public XS_tableFieldType ListItemText {
			get {
				for (int f = 0; f < TableFields.TableFieldCollection.Count; f++) {
					if (TableFields.TableFieldCollection[f].isListItemText) {
						return TableFields.TableFieldCollection[f];
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
				return parallel_ref.hasPK;
			}
		}
		#endregion

		#region public metadataDB.XS_tableType parallel_ref { get; }
		private bool parallel_ref__exists = true;
		private OGen.NTier.lib.metadata.metadataDB.XS_tableType parallel_ref__ = null;

		[XmlIgnore()]
//		[XmlElement("parallel_ref")]
		public OGen.NTier.lib.metadata.metadataDB.XS_tableType parallel_ref {
			get {
				if (
					parallel_ref__exists
					&&
					(parallel_ref__ == null)
				) {
					int t
						= root_ref.MetadataDBCollection[0].Tables.TableCollection.Search(
							Name
						);
					if (t < 0) {
						parallel_ref__exists = false;
						return null;
					}

					parallel_ref__
						= root_ref.MetadataDBCollection[0].Tables.TableCollection[
							t
						];
				}
				return parallel_ref__;
			}
		}
		#endregion
		#region public bool isListItem(...);
		public bool isListItem() {
			for (int f = 0; f < TableFields.TableFieldCollection.Count; f++) {
				if (
					(TableFields.TableFieldCollection[f].isListItemText)
					||
					(TableFields.TableFieldCollection[f].isListItemValue)
				) {
					return true;
				}
			}
			return false;
		}
		#endregion
	}
}
