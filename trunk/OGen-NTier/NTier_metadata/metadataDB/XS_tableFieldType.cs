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
	using OGen.Libraries.DataLayer;

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
			this.name_ = name_in;
		}

		#region public XS_tableType parent_table_ref { get; }
		private XS_tableType parent_table_ref__ = null;
		private object parent_table_ref__locker = new object();

		[XmlIgnore()]
//		[XmlElement("parallel_ref")]
		public XS_tableType parent_table_ref {
			get {

				// check before lock
				if (this.parent_table_ref__ == null) {

					lock (this.parent_table_ref__locker) {

						// double check, thread safer!
						if (this.parent_table_ref__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.parent_table_ref__
								= (XS_tableType)(
									(XS_tableFieldsType)(
										(XS_tableFieldTypeCollection)this.parent_ref
									).parent_ref
								).parent_ref;
						}
					}
				}

				return this.parent_table_ref__;
			}
		}
		#endregion
		#region public metadataExtended.XS_tableFieldType parallel_ref { get; }
		private bool parallel_ref__exists = true;
		private OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType parallel_ref__ = null;
		private object parallel_ref__locker = new object();

		public OGen.NTier.Libraries.Metadata.MetadataExtended.XS_tableFieldType parallel_ref {
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
									this.parent_table_ref.Name
								);
							if (t < 0) {
								// ...attribution (last thing before unlock)
								this.parallel_ref__exists = false;
								return null;
							}

							int f
								= this.root_ref.MetadataExtendedCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection.Search(
									this.Name
								);
							if (f < 0) {
								// ...attribution (last thing before unlock)
								this.parallel_ref__exists = false;
								return null;
							}

							// ...attribution (last thing before unlock)
							this.parallel_ref__
								= this.root_ref.MetadataExtendedCollection[0].Tables.TableCollection[t].TableFields.TableFieldCollection[
									f
								];
						}
					}
				}

				return this.parallel_ref__;
			}
		}
		#endregion

		#region public bool IsBoolean { get; }
		[XmlIgnore()]
		public bool IsBoolean {
			get { return this.TableFieldDBs.TableFieldDBCollection[0].IsBoolean; }
		}
		#endregion
		#region public bool IsDateTime { get; }
		[XmlIgnore()]
		public bool IsDateTime {
			get {
				return this.TableFieldDBs.TableFieldDBCollection[0].IsDateTime;
			}
		}
		#endregion
		#region public bool IsInteger { get; }
		[XmlIgnore()]
		public bool IsInteger {
			get {
				return this.TableFieldDBs.TableFieldDBCollection[0].IsInteger;
			}
		}
		#endregion
		#region public bool IsDecimal { get; }
		[XmlIgnore()]
		public bool IsDecimal {
			get {
				return this.TableFieldDBs.TableFieldDBCollection[0].IsDecimal;
			}
		}
		#endregion
		#region public bool IsText { get; }
		[XmlIgnore()]
		public bool IsText {
			get {
				return this.TableFieldDBs.TableFieldDBCollection[0].IsText;
			}
		}
		#endregion

		#region public cDBType DBType_generic { get; }
		public cDBType DBType_generic {
			get {
				return this.TableFieldDBs.TableFieldDBCollection[0].DBType_generic;
			}
		}
		#endregion

		#region public bool canBeConfig_... { get; }
		[XmlIgnore()]
		public bool canBeConfig_Name {
			get { return this.IsText && this.IsPK; }
		}

		[XmlIgnore()]
		public bool canBeConfig_Config {
			get { return this.IsText && !this.IsPK; }
		}

		[XmlIgnore()]
		public bool canBeConfig_Type {
			get { return this.IsInteger && !this.IsPK; }
		}
		#endregion
	}
}
