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
	public class cClaSSeGen_Link : cClaSS_noR {
		#region public cClaSSeGen_Link(...);
		public cClaSSeGen_Link() : this (string.Empty, string.Empty) { }
		public cClaSSeGen_Link(string from_in, string to_in) {
			From = from_in;
			To = to_in;
			Type = ClaSSPropertyAttribute.eType.standard;
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				//case "Fields":
				//	return new cFields_R_inherit();
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

		#region public string From { get; set; }
//		private string from_;
//
//		[ClaSSPropertyAttribute("from", ClaSSPropertyAttribute.eType.standard)]
//		public string From {
//			get { return from_; }
//			set { from_ = value; }
//		}
		public string From {
			get { return base.Property_standard["from"]; }
			set { base.Property_standard["from"] = value; }
		}
		#endregion
		#region public string To { get; set; }
//		private string to_;
//
//		[ClaSSPropertyAttribute("to", ClaSSPropertyAttribute.eType.standard)]
//		public string To {
//			get { return to_; }
//			set { to_ = value; }
//		}
		public string To {
			get { return base.Property_standard["to"]; }
			set { base.Property_standard["to"] = value; }
		}
		#endregion
		#region public ClaSSPropertyAttribute.eType Type { get; set; }
//		private ClaSSPropertyAttribute.eType type_;
//		public ClaSSPropertyAttribute.eType Type {
//			get { return type_; }
//			set { type_ = value; }
//		}
//
//		[ClaSSPropertyAttribute("type", ClaSSPropertyAttribute.eType.standard)]
//		private string type__ {
//			get { return type_.ToString(); }
//			set { type_ = utils.ClaSS.PropertyTypes.convert.FromName(value); }
//		}
		public ClaSSPropertyAttribute.eType Type {
			get { return utils.ClaSS.PropertyTypes.convert.FromName(base.Property_standard["type"]); }
			set { base.Property_standard["type"] = value.ToString(); }
		}
		#endregion
	}
}