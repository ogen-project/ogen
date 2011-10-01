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
using System.Reflection;
using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cTables_e_aggregate : iClaSSe, iTables {
		#region public cTables_e_aggregate(...);
		public cTables_e_aggregate() {
			classstateapi_ = new cClaSS_(
				null, 
				this
			);
			//---
			tables_ = new ArrayList();
		}
		#endregion

		#region implementing iClaSSe_R...
		private class cClaSS_ : cClaSSe {
			#region public cField_e_aggregate_(...);
//			public cClaSS_(
//			) : base(
//			) {
//			}
			public cClaSS_(
				iClaSSe aggregateloopback_ref_in, 
				iClaSSe inheritloopback_ref_in
			) : base (
				aggregateloopback_ref_in, 
				inheritloopback_ref_in
			) {
			}
			#endregion

			public override object Property_new(string name_in) {
				switch (name_in) {
					case "table":
						return new cTable_e_aggregate(this);
					default:
						throw new Exception(string.Format(
							"{0}.{1}.Property_new(): - invalid Name: {2}", 
							this.GetType().Namespace,
							this.GetType().Name,
							name_in
						));
				}
			}
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
		}

		private cClaSS_ classstateapi_;

		#region public PropertyInfo[] Properties { get; }
		public PropertyInfo[] Properties {
			get { return classstateapi_.Properties; }
		}
		#endregion
		#region public ClaSSPropertyAttribute[] Attributes { get; }
		public ClaSSPropertyAttribute[] Attributes {
			get { return classstateapi_.Attributes; }
		}
		#endregion
		#region public int PropertyIndex_find(string name_in);
		public int PropertyIndex_find(string name_in) {
			return classstateapi_.PropertyIndex_find(name_in);
		}
		#endregion
		#region public int PropertyIndex_find(string name_in, ClaSSPropertyAttribute.eType type_in);
		public int PropertyIndex_find(string name_in, ClaSSPropertyAttribute.eType type_in) {
			return classstateapi_.PropertyIndex_find(name_in, type_in);
		}
		#endregion
		#region public PropertyInfo Property_find(string name_in);
		public PropertyInfo Property_find(string name_in) {
			return classstateapi_.Property_find(name_in);
		}
		#endregion
		#region public PropertyInfo Property_find(string name_in, ClaSSPropertyAttribute.eType type_in);
		public PropertyInfo Property_find(string name_in, ClaSSPropertyAttribute.eType type_in) {
			return classstateapi_.Property_find(name_in, type_in);
		}
		#endregion
		#region public string Read_fromRoot(string what_in)
		public string Read_fromRoot(string what_in) {
			return classstateapi_.Read_fromRoot(what_in);
		}
		#endregion
		#region public string Read_fromHere(string what_in);
		public string Read_fromHere(string what_in) {
			return classstateapi_.Read_fromHere(what_in);
		}
		#endregion
		#region public void IterateThrough_fromRoot(string iteration_in, cClaSSe.dIteration_found iteration_found_in);
		public void IterateThrough_fromRoot(string iteration_in, cClaSSe.dIteration_found iteration_found_in) {
			classstateapi_.IterateThrough_fromRoot(iteration_in, iteration_found_in);
		}
		#endregion
		#region public void IterateThrough_fromHere(string iteration_in, string path_in, cClaSSe.dIteration_found iteration_found_in);
		public void IterateThrough_fromHere(string iteration_in, string path_in, cClaSSe.dIteration_found iteration_found_in) {
			classstateapi_.IterateThrough_fromHere(iteration_in, path_in, iteration_found_in);
		}
		#endregion
		#region public iClaSSe AggregateLoopback_ref { get; }
		public iClaSSe AggregateLoopback_ref {
			get { return classstateapi_.AggregateLoopback_ref; }
		}
		#endregion
		#region public iClaSSe InheritLoopback_ref { get; }
		public iClaSSe InheritLoopback_ref {
			get { return classstateapi_.InheritLoopback_ref; }
		}
		#endregion
		#region public string Path { get; }
		public string Path {
			get { return classstateapi_.Path; }
		}
		#endregion
		#region	public iClaSSe root();
		public iClaSSe root() {
			return classstateapi_.root();
		}
		#endregion

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
				new cTable_e_aggregate(this, name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int t = 0; t < tables_.Count; t++) {
				if (((cTable_e_aggregate)tables_[t]).Name == name_in) {
					return t;
				}
			}
			return -1;
		}
		#endregion
	}
}