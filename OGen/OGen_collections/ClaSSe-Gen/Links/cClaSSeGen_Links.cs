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
	public class cClaSSeGen_Links : cClaSS_noR {
		#region public cClaSSeGen_Links(...);
		public cClaSSeGen_Links() : base() {
			links_ = new ArrayList();
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "link":
					return new cClaSSeGen_Link();
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

		#region private ArrayList links_;
//		private ArrayList links_;
//
//		[ClaSSPropertyAttribute("link", ClaSSPropertyAttribute.eType.aggregate_collection)]
//		private ArrayList links__ {
//			get { return links_; }
//			set { links_ = value; }
//		}
		private ArrayList links_ {
			get { return base.Property_aggregate_collection["link"]; }
			set { base.Property_aggregate_collection["link"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return links_.Count; }
		}
		#endregion
		#region public cClaSSeGen_Link this[int index_in] { get; }
		public cClaSSeGen_Link this[int index_in] {
			get {
				return (cClaSSeGen_Link)links_[index_in];
			}
		}
		#endregion
		#region public cClaSSeGen_Link this[string from_in, string to_in] { get; }
		public cClaSSeGen_Link this[string from_in, string to_in] {
			get {
				int t = Search(from_in, to_in);
				return (t != -1) ? (cClaSSeGen_Link)links_[t] : null;
			}
		}
		#endregion

		#region public int Add(string from_in, string to_in);
		public int Add(string from_in, string to_in) {
			int s = Search(from_in, to_in);
			if (s != -1) return s;

			return links_.Add(
				new cClaSSeGen_Link(from_in, to_in)
			);
		}
		#endregion
		#region public int Search(string from_in, string to_in);
		public int Search(string from_in, string to_in) {
			for (int f = 0; f < links_.Count; f++) {
				if (
					(((cClaSSeGen_Link)links_[f]).From == from_in)
					&&
					(((cClaSSeGen_Link)links_[f]).To == to_in)
				) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}