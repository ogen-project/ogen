#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Data;
using System.Collections;
using System.Xml;
using System.Reflection;
using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cFields_e_aggregate : iClaSSe, iFields {
		#region public cFields_e_aggregate(...);
		public cFields_e_aggregate(
			iClaSSe aggregateloopback_ref_in
		) {
			classstateapi_ = new cClaSS_(
				aggregateloopback_ref_in, 
				this
			);
			//---
			fields_ = new ArrayList();
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
					case "field":
						return new cField_e_aggregate(this);
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

		#region private ArrayList fields_;
		private ArrayList fields_;

		[ClaSSPropertyAttribute("field", ClaSSPropertyAttribute.eType.aggregate_collection, true)]
		private ArrayList fields__ {
			get { return fields_; }
			set { fields_ = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return fields_.Count; }
		}
		#endregion
		#region public iField this[int field_in] { get; }
		public iField this[int field_in] {
			get {
				return (iField)fields_[field_in];
			}
		}
		#endregion
		#region public iField this[string name_in] { get; }
		public iField this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (iField)fields_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return fields_.Add(
				new cField_e_aggregate(this, name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < fields_.Count; f++) {
				if (((cField_e_aggregate)fields_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}