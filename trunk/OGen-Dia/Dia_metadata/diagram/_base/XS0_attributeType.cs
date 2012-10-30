#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Dia.lib.metadata.diagram {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_attributeType {
	#else
	public partial class XS_attributeType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				compositecollection_.parent_ref = this;
				if (boolean__ != null) boolean__.parent_ref = this;
				if (enum__ != null) enum__.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				this.root_ref_ = value;
				compositecollection_.root_ref = value;
				if (boolean__ != null) boolean__.root_ref = value;
				if (enum__ != null) enum__.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Name { get; set; }
		internal string name_;

		[XmlAttribute("name")]
		public string Name {
			get {
				return this.name_;
			}
			set {
				this.name_ = value;
			}
		}
		#endregion
		#region public XS_compositeTypeCollection CompositeCollection { get; }
		internal XS_compositeTypeCollection compositecollection_ 
			= new XS_compositeTypeCollection();

		[XmlElement("composite")]
		public XS_compositeType[] compositecollection__xml {
			get { return this.compositecollection_.cols__; }
			set { this.compositecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_compositeTypeCollection CompositeCollection {
			get { return this.compositecollection_; }
		}
		#endregion
		#region public string String { get; set; }
		internal string string_;

		[XmlElement("string")]
		public string String {
			get {
// ToDos: here!
				return (this.string_.IndexOf("\r\n") >= 0)
					? this.string_
					: this.string_.Replace("\n", "\r\n");
			}
			set { this.string_ = value; }
		}
		#endregion
		#region public XS_booleanType Boolean { get; set; }
		internal XS_booleanType boolean__;
		internal object boolean__locker = new object();

		[XmlIgnore()]
		public XS_booleanType Boolean {
			get {

				// check before lock
				if (this.boolean__ == null) {

					lock (this.boolean__locker) {

						// double check, thread safer!
						if (this.boolean__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.boolean__ = new XS_booleanType();
						}
					}
				}

				return this.boolean__;
			}
			set {
				this.boolean__ = value;
			}
		}

		[XmlElement("boolean")]
		public XS_booleanType boolean__xml {
			get { return this.boolean__; }
			set { this.boolean__ = value; }
		}
		#endregion
		#region public XS_enumType Enum { get; set; }
		internal XS_enumType enum__;
		internal object enum__locker = new object();

		[XmlIgnore()]
		public XS_enumType Enum {
			get {

				// check before lock
				if (this.enum__ == null) {

					lock (this.enum__locker) {

						// double check, thread safer!
						if (this.enum__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.enum__ = new XS_enumType();
						}
					}
				}

				return this.enum__;
			}
			set {
				this.enum__ = value;
			}
		}

		[XmlElement("enum")]
		public XS_enumType enum__xml {
			get { return this.enum__; }
			set { this.enum__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_attributeType attributeType_in) {
			int _index = -1;

			this.name_ = attributeType_in.name_;
			this.compositecollection_.Clear();
			for (int d = 0; d < attributeType_in.compositecollection_.Count; d++) {
				this.compositecollection_.Add(
					out _index,
					new XS_compositeType()
				);
				this.compositecollection_[_index].CopyFrom(
					attributeType_in.compositecollection_[d]
				);
			}
			this.string_ = attributeType_in.string_;
			if (attributeType_in.boolean__ != null) this.boolean__.CopyFrom(attributeType_in.boolean__);
			if (attributeType_in.enum__ != null) this.enum__.CopyFrom(attributeType_in.enum__);
		}
		#endregion
	}
}