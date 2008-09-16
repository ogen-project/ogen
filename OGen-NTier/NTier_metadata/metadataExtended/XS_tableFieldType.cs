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
	public class XS_tableFieldType : XS0_tableFieldType {
	#else
	public partial class XS_tableFieldType {
	#endif
		public XS_tableFieldType (
		) {
		}
		public XS_tableFieldType (
			string name_in
		) {
			name_ = name_in;
		}

		#region public XS_tableType parent_table_ref { get; }
		private XS_tableType parent_table_ref__ = null;

		public XS_tableType parent_table_ref {
			get {
				if (parent_table_ref__ == null) {
					parent_table_ref__ 
						= (XS_tableType)(
							(XS_tableFieldsType)(
								(XS_tableFieldTypeCollection)parent_ref
							).parent_ref
						).parent_ref;
				}
				return parent_table_ref__;
			}
		}
		#endregion
		#region public metadataDB.XS_tableFieldType parallel_ref { get; }
		private bool parallel_ref__exists = true;
		private OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType parallel_ref__ = null;

		[XmlIgnore()]
//		[XmlElement("parallel_ref")]
		public OGen.NTier.lib.metadata.metadataDB.XS_tableFieldType parallel_ref {
			get {
				if (
					parallel_ref__exists
					&&
					(parallel_ref__ == null)
				) {
					int t
						= root_ref.MetadataDBCollection[0].Tables.TableCollection.Search(
							parent_table_ref.Name
						);
					if (t < 0) {
						parallel_ref__exists = false;
						return null;
					}

					int f
						= root_ref.MetadataDBCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection.Search(
							Name
						);
					if (f < 0) {
						parallel_ref__exists = false;
						return null;
					}

					parallel_ref__
						= root_ref.MetadataDBCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection[
							f
						];
				}
				return parallel_ref__;
			}
		}
		#endregion

		#region public bool isConfig_Name { get; }
		[XmlIgnore()]
		public bool isConfig_Name {
			get {
				return (parent_table_ref.ConfigName == Name);
			}
		}
		#endregion
		#region public bool isConfig_Config { get; }
		[XmlIgnore()]
		public bool isConfig_Config {
			get {
				return (parent_table_ref.ConfigConfig == Name);
			}
		}
		#endregion
		#region public bool isConfig_Datatype { get; }
		[XmlIgnore()]
		public bool isConfig_Datatype {
			get {
				return (parent_table_ref.ConfigDatatype == Name);
			}
		}
		#endregion
	}
}
