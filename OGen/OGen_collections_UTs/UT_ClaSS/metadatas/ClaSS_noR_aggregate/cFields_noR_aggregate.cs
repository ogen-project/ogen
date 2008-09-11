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

using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cFields_noR_aggregate : cClaSS_noR, iClaSS_noR, iFields {
		#region public cFields_noR_aggregate(...);
		public cFields_noR_aggregate() {
			field_ = new ArrayList();
		}
		#endregion

		#region implementing iClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "Field":
					return new cField_noR_aggregate();
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

		#region private ArrayList field_ { get; set; }
		private ArrayList field_ {
			get { return Property_aggregate_collection["Field"]; }
			set { Property_aggregate_collection["Field"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return field_.Count; }
		}
		#endregion
		#region public iField this[int field_in] { get; }
		public iField this[int field_in] {
			get {
				return (iField)field_[field_in];
			}
		}
		#endregion
		#region public iField this[string name_in] { get; }
		public iField this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (iField)field_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return field_.Add(
				new cField_noR_aggregate(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < field_.Count; f++) {
				if (((cField_noR_aggregate)field_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}