#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Collections;
using System.Reflection;
using OGen.lib.collections;

namespace OGen.Doc.lib.metadata {
	public class Subject : cClaSSe {
		public Subject(
			Subjects aggregateloopback_ref_in, 
			string idSubject_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			idsubject_ = idSubject_in;
			idsubject_parent_ = string.Empty;
			name_ = string.Empty;
			description_ = string.Empty;
			//---
			documents_ = new Documents(this/*, this*/);
			//#endregion
		}
		public override string root4xml {
			get {
				return DocMetadata.ROOT;
			}
		}

		#region Implementing - iClaSSe...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"invalid Name: {0}", 
						name_in
					));
			}
		}
		#endregion
		#region public PropertyInfo[] Properties { get; }
		private static PropertyInfo[] properties__ = null;
		public override PropertyInfo[] Properties {
			get {
				if (properties__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return properties__;
			}
		}
		#endregion
		#region public ClaSSPropertyAttribute[] Attributes { get; }
		private static ClaSSPropertyAttribute[] attributes__ = null;
		public override ClaSSPropertyAttribute[] Attributes {
			get {
				if (attributes__ == null) {
					InitializeStaticFields(
						ref properties__, 
						ref attributes__
					);
				}
				return attributes__;
			}
		}
		#endregion
		#endregion

		#region public Properties - ClaSSe...
		#region public string IDSubject { get; set; }
		private string idsubject_;

		[ClaSSPropertyAttribute("idSubject", ClaSSPropertyAttribute.eType.standard, true)]
		public string IDSubject {
			get { return idsubject_; }
			set { idsubject_ = value; }
		}
		#endregion
		#region public string IDSubject_parent { get; set; }
		private string idsubject_parent_;

		[ClaSSPropertyAttribute("idSubject_parent", ClaSSPropertyAttribute.eType.standard, true)]
		public string IDSubject_parent {
			get { return idsubject_parent_; }
			set { idsubject_parent_ = value; }
		}
		#endregion
		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region public string Description { get; set; }
		private string description_;

		[ClaSSPropertyAttribute("description", ClaSSPropertyAttribute.eType.standard, true)]
		public string Description {
			get { return description_; }
			set { description_ = value; }
		}
		#endregion
		//---
		#region public Documents Documents { get; set; }
		private Documents documents_;

		[ClaSSPropertyAttribute("documents", ClaSSPropertyAttribute.eType.aggregate, true)]
		public Documents Documents {
			get { return documents_; }
		}
		#endregion
		#endregion
		#region public Properties...
		#region public Subjects Parent_ref { get; }
		public Subjects Parent_ref {
			get {
				return (Subjects)base.AggregateLoopback_ref;
			}
		}
		#endregion
		#endregion

		#region public Methdos...
		#region public Subject[] HowToGetHere_fromRoot();
		public Subject[] HowToGetHere_fromRoot() {
			Subject[] HowToGetHere_fromRoot_out;

			int c;
			Subject _subject_parent;
			#region HowToGetHere_fromRoot_out = new Subject[...];
			_subject_parent = this;
			c = 0;

			do {
				//_arraylist.Add(_subject_parent.IDSubject);
				c++;
			} while ((_subject_parent = Parent_ref[_subject_parent.IDSubject_parent]) != null);

			HowToGetHere_fromRoot_out = new Subject[c];
			#endregion
			#region HowToGetHere_fromRoot_out[...] = ...;
			_subject_parent = this;
			c = HowToGetHere_fromRoot_out.Length;

			do {
				c--;
				HowToGetHere_fromRoot_out[c] = _subject_parent;
			} while ((_subject_parent = Parent_ref[_subject_parent.IDSubject_parent]) != null);
			#endregion

			return HowToGetHere_fromRoot_out;
		}
		#endregion
		#region public bool hasDescendants();
		public bool hasDescendants() {
			for (int i = 0; i < Parent_ref.Count; i++) {
				if (Parent_ref[i].IDSubject_parent == IDSubject) {
					return true;
				}
			}

			return false;
		}
		#endregion
		#region public Subject NextSubject();
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
		private Subject nextsubject() {
			if (Parent_ref == null) return null;

			// situation 2:
			for (int i = Parent_ref.Search(IDSubject) + 1; i < Parent_ref.Count; i++) {
				if (Parent_ref[i].IDSubject_parent == IDSubject_parent) {
					return Parent_ref[i];
				}
			}

			// situation 3:
			for (int i = 0; i < Parent_ref.Count; i++) {
				if (Parent_ref[i].IDSubject == IDSubject_parent) {
					return Parent_ref[i].nextsubject();
				}
			}

			return null;
		}
		public Subject NextSubject() {
			// situation 1:
			for (int i = 0; i < Parent_ref.Count; i++) {
				if (Parent_ref[i].IDSubject_parent == IDSubject) {
					return Parent_ref[i];
				}
			}

			//// situation 2:
			//for (int i = Parent_ref.Search(IDSubject) + 1; i < Parent_ref.Count; i++) {
			//	if (Parent_ref[i].IDSubject_parent == IDSubject_parent) {
			//		return Parent_ref[i];
			//	}
			//}

			// situation 3:
			return nextsubject();
		}
		#endregion
		#endregion
	}
}
