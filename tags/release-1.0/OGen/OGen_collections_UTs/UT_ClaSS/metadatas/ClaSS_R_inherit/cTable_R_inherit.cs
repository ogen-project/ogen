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
	public class cTable_R_inherit : cClaSS_R, iTable {
		#region public cTable_R_inherit(...);
		public cTable_R_inherit() : this (string.Empty) { }
		public cTable_R_inherit(string name_in) {
			fields_ = new cFields_R_inherit();
			name_ = name_in;
		}
		#endregion

		#region implementing cClaSS_R...
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

		#region public iFields Fields { get; }
		private iFields fields_;

		[ClaSSPropertyAttribute("fields", ClaSSPropertyAttribute.eType.aggregate, true)]
		public iFields Fields {
			get { return fields_; }
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
	}
}