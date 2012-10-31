#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataDB {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_tablesType {
	#else
	public partial class XS_tablesType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				this.tablecollection_.parent_ref = this;
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
				this.tablecollection_.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public XS_tableTypeCollection TableCollection { get; }
		internal XS_tableTypeCollection tablecollection_ 
			= new XS_tableTypeCollection();

		[XmlElement("table")]
		public XS_tableType[] tablecollection__xml {
			get { return this.tablecollection_.cols__; }
			set { this.tablecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_tableTypeCollection TableCollection {
			get { return this.tablecollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tablesType tablesType_in) {
			int _index = -1;

			this.tablecollection_.Clear();
			for (int d = 0; d < tablesType_in.tablecollection_.Count; d++) {
				this.tablecollection_.Add(
					out _index,
					new XS_tableType()
				);
				this.tablecollection_[_index].CopyFrom(
					tablesType_in.tablecollection_[d]
				);
			}
		}
		#endregion
	}
}