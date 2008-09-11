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
using System.Data;
using System.Collections;
using System.Reflection;

using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cFields_e_inherit : cClaSSe, iFields {
		#region public cFields_e_inherit(...);
		public cFields_e_inherit(
			iClaSSe aggregateloopback_ref_in
		) : base (
			aggregateloopback_ref_in
		) {
			fields_ = new ArrayList();
		}
		#endregion

		#region implementing cClaSSe...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "field":
					return new cField_e_inherit(this);
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}", 
						this.GetType().Namespace,
						this.GetType().Name,
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

		#region private ArrayList fields_;
		private ArrayList fields_;

		[ClaSSPropertyAttribute("field", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList fields__ {
			get { return fields_; }
			set { fields_ = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return fields_.Count; }
		}
		#endregion
		#region public iField this[int field_in] { get; }
		public iField this[int field_in] {
			get {
				return (cField_e_inherit)fields_[field_in];
			}
		}
		#endregion
		#region public iField this[string name_in] { get; }
		public iField this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (cField_e_inherit)fields_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return fields_.Add(
				new cField_e_inherit(this, name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < fields_.Count; f++) {
				if (((cField_e_inherit)fields_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}