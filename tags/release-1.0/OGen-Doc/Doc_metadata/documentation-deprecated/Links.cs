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
	public class Links : cClaSSe {
		public Links(
			DocMetadata aggregateloopback_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			links_ = new ArrayList();
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
				case "link":
					return new Link(
						this, 
						string.Empty
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

		#region private Properties - ClaSSe...
		#region private ArrayList links_ { get; set; }
		private ArrayList links_;

		[ClaSSPropertyAttribute("link", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList links__reflection {
			get { return links_; }
			set { links_ = value; }
		}
		#endregion
		#endregion
		#region public Properties...
		#region public DocMetadata Parent_ref;
		public DocMetadata Parent_ref {
			get { return (DocMetadata)base.AggregateLoopback_ref; }
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get { return links_.Count; }
		}
		#endregion
		#region public Link this[...] { get; set; }
		public Link this[int index_in] {
			get {
				return (Link)links_[index_in];
			}
		}
		public Link this[string idLink_in] {
			get {
				int _ti = Search(idLink_in);
				return (_ti >= 0) ?
					(Link)links_[_ti] :
					null;
			}
		}
		#endregion
		#endregion

		#region public Methods...
		#region public void Clear(...);
		public void Clear() {
			links_.Clear();
		}
		#endregion
		#region public int Add(...)
		public int Add(string idLink_in, bool verifyExistenz_in) {
			int _ti;

			if (verifyExistenz_in) {
				_ti = Search(idLink_in);
				if (_ti != -1)
					return _ti;
			}

			_ti = links_.Add(
				new Link(
					this, 
					idLink_in
				)
			);
			return _ti; // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string idLink_in) {
			for (int t = 0; t < links_.Count; t++)
				if (((Link)links_[t]).IDLink == idLink_in) // already exists!
					return t; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}
