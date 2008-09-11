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

namespace OGen.lib.collections {
	public class cClaSSeGen_Fields : cClaSS_noR {
		#region public cClaSSeGen_Fields(...);
		public cClaSSeGen_Fields() : base() {
			fields_ = new ArrayList();
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "field":
					return new cClaSSeGen_Field();
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
		#endregion

		#region private ArrayList fields_;
//		private ArrayList fields_;
//
//		[ClaSSPropertyAttribute("field", ClaSSPropertyAttribute.eType.aggregate_collection)]
//		private ArrayList fields__ {
//			get { return fields_; }
//			set { fields_ = value; }
//		}
		private ArrayList fields_ {
			get { return base.Property_aggregate_collection["field"]; }
			set { base.Property_aggregate_collection["field"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return fields_.Count; }
		}
		#endregion
		#region public cClaSSeGen_Field this[int index_in] { get; }
		public cClaSSeGen_Field this[int index_in] {
			get {
				return (cClaSSeGen_Field)fields_[index_in];
			}
		}
		#endregion
		#region public cClaSSeGen_Field this[string name_in] { get; }
		public cClaSSeGen_Field this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (cClaSSeGen_Field)fields_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return fields_.Add(
				new cClaSSeGen_Field(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < fields_.Count; f++) {
				if (((cClaSSeGen_Field)fields_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}