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
	public class FAQSubject : cClaSSe {
		public FAQSubject(
			FAQSubjects aggregateloopback_ref_in, 
			string idfaqsubject_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			idfaqsubject_ = idfaqsubject_in;
			idfaqsubject_parent_ = string.Empty;
			name_ = string.Empty;
			description_ = string.Empty;
			//---
			faq_ = new ArrayList();
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
				case "faq":
					return new FAQ(
						this
						//, string.Empty
					);
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
		#region public string IDFAQSubject { get; set; }
		private string idfaqsubject_;

		[ClaSSPropertyAttribute("idFAQSubject", ClaSSPropertyAttribute.eType.standard, true)]
		public string IDFAQSubject {
			get { return idfaqsubject_; }
			set { idfaqsubject_ = value; }
		}
		#endregion
		#region public string IDFAQSubject_parent { get; set; }
		private string idfaqsubject_parent_;

		[ClaSSPropertyAttribute("idFAQSubject_parent", ClaSSPropertyAttribute.eType.standard, true)]
		public string IDFAQSubject_parent {
			get { return idfaqsubject_parent_; }
			set { idfaqsubject_parent_ = value; }
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
		#region private ArrayList faq_ { get; set; }
		private ArrayList faq_;

		[ClaSSPropertyAttribute("faq", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList faq__reflection {
			get { return faq_; }
			set { faq_ = value; }
		}
		#endregion
		#endregion
		#region public Properties...
		#region public FAQSubjects Parent_ref { get; }
		public FAQSubjects Parent_ref {
			get {
				return (FAQSubjects)base.AggregateLoopback_ref;
			}
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get { return faq_.Count; }
		}
		#endregion
		#region public FAQ this[...] { get; set; }
		public FAQ this[int index_in] {
			get {
				return (FAQ)faq_[index_in];
			}
		}
		//public FAQ this[string name_in] {
		//	get {
		//		int _ti = Search(name_in);
		//		return (_ti >= 0) ?
		//			(FAQ)faq_[_ti] :
		//			null;
		//	}
		//}
		#endregion
		#endregion

		#region public Methods...
		#region public void Clear(...);
		public void Clear() {
			faq_.Clear();
		}
		#endregion
		#region public int Add(...)
		public int Add(/*string name_in, bool verifyExistenz_in*/) {
			int _ti;

			//if (verifyExistenz_in) {
			//	_ti = Search(name_in);
			//	if (_ti != -1)
			//		return _ti;
			//}

			_ti = faq_.Add(
				new FAQ(
					this
					// , name_in
				)
			);
			return _ti; // returns it's position
		}
		#endregion
		#region //public int Search(...)
		//public int Search(string name_in) {
		//	for (int t = 0; t < faq_.Count; t++)
		//		if (((FAQ)faq_[t]).Name == name_in) // already exists!
		//			return t; // returns it's position
		//
		//	return -1;
		//}
		#endregion
		//---
		#region public Subject[] HowToGetHere_fromRoot();
		public FAQSubject[] HowToGetHere_fromRoot() {
			FAQSubject[] HowToGetHere_fromRoot_out;

			int c;
			FAQSubject _faqsubject_parent;
			#region HowToGetHere_fromRoot_out = new Subject[...];
			_faqsubject_parent = this;
			c = 0;

			do {
				//_arraylist.Add(_faqsubject_parent.IDSubject);
				c++;
			} while ((_faqsubject_parent = Parent_ref[_faqsubject_parent.IDFAQSubject_parent]) != null);

			HowToGetHere_fromRoot_out = new FAQSubject[c];
			#endregion
			#region HowToGetHere_fromRoot_out[...] = ...;
			_faqsubject_parent = this;
			c = HowToGetHere_fromRoot_out.Length;

			do {
				c--;
				HowToGetHere_fromRoot_out[c] = _faqsubject_parent;
			} while ((_faqsubject_parent = Parent_ref[_faqsubject_parent.IDFAQSubject_parent]) != null);
			#endregion

			return HowToGetHere_fromRoot_out;
		}
		#endregion
		#region public bool hasDescendants();
		public bool hasDescendants() {
			for (int i = 0; i < Parent_ref.Count; i++) {
				if (Parent_ref[i].IDFAQSubject_parent == IDFAQSubject) {
					return true;
				}
			}

			return false;
		}
		#endregion
		#endregion
	}
}
