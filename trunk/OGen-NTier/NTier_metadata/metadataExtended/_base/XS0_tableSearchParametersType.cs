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
	public class XS0_tableSearchParametersType {
	#else
	public partial class XS_tableSearchParametersType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				tablefieldrefcollection_.parent_ref = this;
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
				tablefieldrefcollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public XS_tableFieldRefTypeCollection TableFieldRefCollection { get; }
		internal XS_tableFieldRefTypeCollection tablefieldrefcollection_ 
			= new XS_tableFieldRefTypeCollection();

		[XmlElement("tableFieldRef")]
		public XS_tableFieldRefType[] tablefieldrefcollection__xml {
			get { return this.tablefieldrefcollection_.cols__; }
			set { this.tablefieldrefcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_tableFieldRefTypeCollection TableFieldRefCollection {
			get { return this.tablefieldrefcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_tableSearchParametersType tableSearchParametersType_in) {
			int _index = -1;

			this.tablefieldrefcollection_.Clear();
			for (int d = 0; d < tableSearchParametersType_in.tablefieldrefcollection_.Count; d++) {
				this.tablefieldrefcollection_.Add(
					out _index,
					new XS_tableFieldRefType()
				);
				this.tablefieldrefcollection_[_index].CopyFrom(
					tableSearchParametersType_in.tablefieldrefcollection_[d]
				);
			}
		}
		#endregion
	}
}