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

using OGen.lib.collections;

namespace OGen.Doc.lib.metadata.documentation {
	public class XS_faqSubjectType : XS0_faqSubjectType {
		#region public XS_faqSubjectType(...);
		public XS_faqSubjectType(
		) : base (
		) {
		}
		public XS_faqSubjectType(
			string idFAQSubject_in
		) : base (
			idFAQSubject_in
		) {
		}
		#endregion

		#region public ... parent_ref_faqSubjectTypeCollection { get; }
		[XmlIgnore()]
		public XS_faqSubjectTypeCollection parent_ref_faqSubjectTypeCollection {
			get {
				return (XS_faqSubjectTypeCollection)parent_ref;
			}
		}
		#endregion

		#region public Subject[] HowToGetHere_fromRoot();
		public XS_faqSubjectType[] HowToGetHere_fromRoot() {
			XS_faqSubjectType[] HowToGetHere_fromRoot_out;

			int c;
			XS_faqSubjectType _faqsubject_parent;
			#region HowToGetHere_fromRoot_out = new XS_faqSubjectType[...];
			_faqsubject_parent = this;
			c = 0;

			do {
				//_arraylist.Add(_faqsubject_parent.IDSubject);
				c++;
			} while ((_faqsubject_parent = parent_ref_faqSubjectTypeCollection[_faqsubject_parent.IDFAQSubject_parent]) != null);

			HowToGetHere_fromRoot_out = new XS_faqSubjectType[c];
			#endregion
			#region HowToGetHere_fromRoot_out[...] = ...;
			_faqsubject_parent = this;
			c = HowToGetHere_fromRoot_out.Length;

			do {
				c--;
				HowToGetHere_fromRoot_out[c] = _faqsubject_parent;
			} while ((_faqsubject_parent = parent_ref_faqSubjectTypeCollection[_faqsubject_parent.IDFAQSubject_parent]) != null);
			#endregion

			return HowToGetHere_fromRoot_out;
		}
		#endregion
		#region public bool hasDescendants();
		public bool hasDescendants() {
			for (int i = 0; i < parent_ref_faqSubjectTypeCollection.Count; i++) {
				if (parent_ref_faqSubjectTypeCollection[i].IDFAQSubject_parent == IDFAQSubject) {
					return true;
				}
			}

			return false;
		}
		#endregion
	}
}
