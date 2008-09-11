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

namespace OGen.lib.collections {
	public class cClaSSeGen : cClaSS_noR {
		#region public cClaSSeGen(...);
		public cClaSSeGen() : base() {
			classes_ = new cClaSSeGen_cClaSSes();
			links_ = new cClaSSeGen_Links();
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
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

		#region public cClaSSeGen_cClaSSes ClaSSes { get; }
//		private cClaSSeGen_cClaSSes classes_;
//
//		[ClaSSPropertyAttribute("claSSes", ClaSSPropertyAttribute.eType.aggregate, true)]
//		public cClaSSeGen_cClaSSes ClaSSes {
//			get { return classes_; }
//		}
		private cClaSSeGen_cClaSSes classes_ {
			get { return (cClaSSeGen_cClaSSes)base.Property_aggregate["claSSes"]; }
			set { base.Property_aggregate["claSSes"] = value; }
		}
		public cClaSSeGen_cClaSSes ClaSSes {
			get { return classes_; }
		}
		#endregion
		#region public cClaSSeGen_Links Links { get; }
//		private cClaSSeGen_Links links_;
//
//		[ClaSSPropertyAttribute("links", ClaSSPropertyAttribute.eType.aggregate)]
//		public cClaSSeGen_Links Links {
//			get { return links_; }
//		}
		private cClaSSeGen_Links links_ {
			get { return (cClaSSeGen_Links)base.Property_aggregate["links"]; }
			set { base.Property_aggregate["links"] = value; }
		}
		public cClaSSeGen_Links Links {
			get { return links_; }
		}
		#endregion

		#region public string Root { get; set; }
//		private string root_;
//
//		[ClaSSPropertyAttribute("root", ClaSSPropertyAttribute.eType.standard)]
//		public string Root {
//			get { return root_; }
//			set { root_ = value; }
//		}
		public string Root {
			get { return base.Property_standard["root"]; }
			set { base.Property_standard["root"] = value; }
		}
		#endregion
	}
}