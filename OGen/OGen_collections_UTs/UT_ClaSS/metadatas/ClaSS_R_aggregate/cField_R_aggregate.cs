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
	public class cField_R_aggregate : iClaSS, iField {
		#region public cField_R_aggregate(...);
		public cField_R_aggregate() : this (string.Empty) { }
		public cField_R_aggregate(string name_in) {
			classstateapi_ = new cClaSS_(this);
			//---
			name_ = name_in;
			ispk_ = false;
			dbtype_indb_ = (int)SqlDbType.Variant;
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

		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region public bool isPK { get; set; }
		private bool ispk_;
		public bool isPK {
			get { return ispk_; }
			set { ispk_ = value; }
		}

		[ClaSSPropertyAttribute("isPK", ClaSSPropertyAttribute.eType.standard, true)]
		private string ispk__ {
			get { return ispk_.ToString(); }
			set { ispk_ = bool.Parse(value); }
		}
		#endregion
		#region public object DBType_inDB { get; set; }
		private object dbtype_indb_;
		public object DBType_inDB {
			get { return dbtype_indb_; }
			set { dbtype_indb_ = value; }
		}

		[ClaSSPropertyAttribute("dbType_inDB", ClaSSPropertyAttribute.eType.standard, true)]
		private string dbtype_indb__ {
			get { return dbtype_indb_.ToString(); }
			set { dbtype_indb_ = int.Parse(value); }
		}
		#endregion
	}
}