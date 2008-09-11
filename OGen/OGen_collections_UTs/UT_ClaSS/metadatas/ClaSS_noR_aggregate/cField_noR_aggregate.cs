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
	public class cField_noR_aggregate : cClaSS_noR, iClaSS_noR, iField {
		#region public cField_noR_aggregate(...);
		public cField_noR_aggregate() : this (string.Empty) { }
		public cField_noR_aggregate(string name_in) {
			Name = name_in;
			isPK = false;
			DBType_inDB = (int)SqlDbType.Variant;
		}
		#endregion

		#region implementing iClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name.", 
						this.GetType().Namespace,
						this.GetType().Name
					));
			}
		}
		#endregion
		#endregion

		#region public bool isPK { get; set; }
		public bool isPK {
			get { return bool.Parse(Property_standard["isPK"]); }
			set { Property_standard["isPK"] = value.ToString(); }
		}
		#endregion
		#region public object DBType_inDB { get; set; }
		public object DBType_inDB {
			get { return int.Parse(Property_standard["DBType_inDB"]); }
			set { Property_standard["DBType_inDB"] = value.ToString(); }
		}
		#endregion
		#region public string Name { get; set; }
		public string Name {
			get { return Property_standard["Name"]; }
			set { Property_standard["Name"] = value; }
		}
		#endregion
	}
}