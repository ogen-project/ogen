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
	public class XS_subjectType : XS0_subjectType {
		#region public XS_subjectType(...);
		public XS_subjectType(
		) : base (
		) {
		}
		public XS_subjectType(
			string idSubject_in
		) : base (
			idSubject_in
		) {
		}
		#endregion

		#region public ... parent_ref_subjectTypeCollection { get; }
		public
#if !NET_1_1
			OGenRootrefCollection<XS_subjectType, XS__RootMetadata, string>
#else
			XS_subjectTypeCollection
#endif
			parent_ref_subjectTypeCollection {

			get {
					return (
#if !NET_1_1
						OGenRootrefCollection<XS_subjectType, XS__RootMetadata, string>
#else
						XS_subjectTypeCollection
#endif
					)parent_ref;
			}
		}
		#endregion

		#region public Subject[] HowToGetHere_fromRoot();
		public XS_subjectType[] HowToGetHere_fromRoot() {
			XS_subjectType[] HowToGetHere_fromRoot_out;

			int c;
			XS_subjectType _subject_parent;
			#region HowToGetHere_fromRoot_out = new XS_subjectType[...];
			_subject_parent = this;
			c = 0;

			do {
				//_arraylist.Add(_subject_parent.IDSubject);
				c++;
			} while ((_subject_parent = parent_ref_subjectTypeCollection[_subject_parent.IDSubject_parent]) != null);

			HowToGetHere_fromRoot_out = new XS_subjectType[c];
			#endregion
			#region HowToGetHere_fromRoot_out[...] = ...;
			_subject_parent = this;
			c = HowToGetHere_fromRoot_out.Length;

			do {
				c--;
				HowToGetHere_fromRoot_out[c] = _subject_parent;
			} while ((_subject_parent = parent_ref_subjectTypeCollection[_subject_parent.IDSubject_parent]) != null);
			#endregion

			return HowToGetHere_fromRoot_out;
		}
		#endregion
		#region public bool hasDescendants();
		public bool hasDescendants() {
			for (int i = 0; i < parent_ref_subjectTypeCollection.Count; i++) {
				if (parent_ref_subjectTypeCollection[i].IDSubject_parent == IDSubject) {
					return true;
				}
			}

			return false;
		}
		#endregion
		#region public XS_subjectType NextSubject();
		/***************************************************
		 *                                                 *
		 *	1 ............... >> 1.1 (SITUATION 1)         *
		 *                                                 *
		 *		1.1 ......... >> 1.2 (SITUATION 2)         *
		 *		1.2 ......... >> 1.3 (situation 2 again)   *
		 *		1.3 ......... >> 1.3.1 (situation 1 again) *
		 *                                                 *
		 *			1.3.1 ... >> 1.3.2 (situation 2 again) *
		 *			1.3.2 ... >> 2 (SITUATION 3)           *
		 *                                                 *
		 *	2 ............... >> null                      *
		 *                                                 *
		 ***************************************************/
		private XS_subjectType nextsubject() {
			if (parent_ref == null) return null;

			// situation 2:
			for (int i = parent_ref_subjectTypeCollection.Search(IDSubject) + 1; i < parent_ref_subjectTypeCollection.Count; i++) {
				if (parent_ref_subjectTypeCollection[i].IDSubject_parent == IDSubject_parent) {
					return parent_ref_subjectTypeCollection[i];
				}
			}

			// situation 3:
			for (int i = 0; i < parent_ref_subjectTypeCollection.Count; i++) {
				if (parent_ref_subjectTypeCollection[i].IDSubject == IDSubject_parent) {
					return parent_ref_subjectTypeCollection[i].nextsubject();
				}
			}

			return null;
		}
		public XS_subjectType NextSubject() {
			// situation 1:
			for (int i = 0; i < parent_ref_subjectTypeCollection.Count; i++) {
				if (parent_ref_subjectTypeCollection[i].IDSubject_parent == IDSubject) {
					return parent_ref_subjectTypeCollection[i];
				}
			}

			//// situation 2:
			//for (int i = parent_ref_subjectTypeCollection.Search(IDSubject) + 1; i < parent_ref_subjectTypeCollection.Count; i++) {
			//    if (parent_ref_subjectTypeCollection[i].IDSubject_parent == IDSubject_parent) {
			//        return parent_ref_subjectTypeCollection[i];
			//    }
			//}

			// situation 3:
			return nextsubject();
		}
		#endregion
	}
}
