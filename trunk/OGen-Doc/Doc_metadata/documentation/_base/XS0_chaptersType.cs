#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Doc.Libraries.Metadata.Documentation {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_chaptersType {
	#else
	public partial class XS_chaptersType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				this.parent_ref_ = value;
				this.chaptercollection_.parent_ref = this;
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
				this.chaptercollection_.root_ref = value;
			}
			get { return this.root_ref_; }
		}
		#endregion
		#region public XS_chapterTypeCollection ChapterCollection { get; }
		internal XS_chapterTypeCollection chaptercollection_ 
			= new XS_chapterTypeCollection();

		[XmlElement("chapter")]
		public XS_chapterType[] chaptercollection__xml {
			get { return this.chaptercollection_.cols__; }
			set { this.chaptercollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_chapterTypeCollection ChapterCollection {
			get { return this.chaptercollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_chaptersType chaptersType_in) {
			int _index = -1;

			this.chaptercollection_.Clear();
			for (int d = 0; d < chaptersType_in.chaptercollection_.Count; d++) {
				this.chaptercollection_.Add(
					out _index,
					new XS_chapterType()
				);
				this.chaptercollection_[_index].CopyFrom(
					chaptersType_in.chaptercollection_[d]
				);
			}
		}
		#endregion
	}
}