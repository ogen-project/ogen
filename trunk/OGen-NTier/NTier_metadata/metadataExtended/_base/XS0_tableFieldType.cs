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
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tableFieldType {
	#else
	public partial class XS_tableFieldType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
			}
			get { return this.parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				this.root_ref_ = value;
			}
			get { return this.root_ref_; }
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
		#region public bool isViewPK { get; set; }
		internal bool isviewpk_;

		[XmlAttribute("isViewPK")]
		public bool isViewPK {
			get {
				return this.isviewpk_;
			}
			set {
				this.isviewpk_ = value;
			}
		}
		#endregion
		#region public string DefaultValue { get; set; }
		internal string defaultvalue_;

		[XmlAttribute("defaultValue")]
		public string DefaultValue {
			get {
				return this.defaultvalue_;
			}
			set {
				this.defaultvalue_ = value;
			}
		}
		#endregion
		#region public string FriendlyName { get; set; }
		internal string friendlyname_;

		[XmlAttribute("friendlyName")]
		public string FriendlyName {
			get {
				return this.friendlyname_;
			}
			set {
				this.friendlyname_ = value;
			}
		}
		#endregion
		#region public string ExtendedDescription { get; set; }
		internal string extendeddescription_;

		[XmlAttribute("extendedDescription")]
		public string ExtendedDescription {
			get {
				return this.extendeddescription_;
			}
			set {
				this.extendeddescription_ = value;
			}
		}
		#endregion
		#region public bool isListItemValue { get; set; }
		internal bool islistitemvalue_;

		[XmlAttribute("isListItemValue")]
		public bool isListItemValue {
			get {
				return this.islistitemvalue_;
			}
			set {
				this.islistitemvalue_ = value;
			}
		}
		#endregion
		#region public bool isListItemText { get; set; }
		internal bool islistitemtext_;

		[XmlAttribute("isListItemText")]
		public bool isListItemText {
			get {
				return this.islistitemtext_;
			}
			set {
				this.islistitemtext_ = value;
			}
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableFieldType tableFieldType_in) {
			this.name_ = tableFieldType_in.name_;
			this.isviewpk_ = tableFieldType_in.isviewpk_;
			this.defaultvalue_ = tableFieldType_in.defaultvalue_;
			this.friendlyname_ = tableFieldType_in.friendlyname_;
			this.extendeddescription_ = tableFieldType_in.extendeddescription_;
			this.islistitemvalue_ = tableFieldType_in.islistitemvalue_;
			this.islistitemtext_ = tableFieldType_in.islistitemtext_;
		}
		#endregion
	}
}