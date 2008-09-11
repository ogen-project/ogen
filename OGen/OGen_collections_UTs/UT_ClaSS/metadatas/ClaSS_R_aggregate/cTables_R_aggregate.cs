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
using System.Xml;
using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cTables_R_aggregate : iClaSS, iTables {
		#region public cTables_R_aggregate(...);
		public cTables_R_aggregate() {
			classstateapi_ = new cClaSS_(this);
			//---
			tables_ = new ArrayList();
		}
		#endregion

		#region implementing iClaSS_R...
		private class cClaSS_ : cClaSS_R {
			#region public cField_R_aggregate_(...);
//			public cClaSS_(
//			) : base(
//			) {
//			}
			public cClaSS_(
				iClaSS derived_ref_in
			) : base (
				derived_ref_in
			) {
			}
			#endregion

			public override object Property_new(string name_in) {
				switch (name_in) {
					case "table":
						return new cTable_R_aggregate();
					default:
						throw new Exception(string.Format(
							"{0}.{1}.Property_new(): - invalid Name: {2}", 
							this.GetType().Namespace,
							this.GetType().Name,
							name_in
						));
				}
			}
		}

		private cClaSS_ classstateapi_;

		public void SaveState_toFile(string fileName_in, string objectName_in) {
			classstateapi_.SaveState_toFile(fileName_in, objectName_in);
		}
		public XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in) {
			return classstateapi_.SaveState_toFile(xmlDoc_in, name_in);
		}

		public void LoadState_fromFile(string fileName_in, string objectName_in) {
			classstateapi_.LoadState_fromFile(fileName_in, objectName_in);
		}
		public void LoadState_fromFile(XmlNode node_in) {
			classstateapi_.LoadState_fromFile(node_in);
		}

		public object Property_new(string name_in) {
			return classstateapi_.Property_new(name_in);
		}
		#endregion

		#region private ArrayList tables_;
		private ArrayList tables_;

		[ClaSSPropertyAttribute("table", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList tables__ {
			get { return tables_; }
			set { tables_ = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return tables_.Count; }
		}
		#endregion
		#region public iTable this[int table_in] { get; }
		public iTable this[int table_in] {
			get {
				return (iTable)tables_[table_in];
			}
		}
		#endregion
		#region public iTable this[string name_in] { get; }
		public iTable this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (iTable)tables_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return tables_.Add(
				new cTable_R_aggregate(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int t = 0; t < tables_.Count; t++) {
				if (((cTable_R_aggregate)tables_[t]).Name == name_in) {
					return t;
				}
			}
			return -1;
		}
		#endregion
	}
}