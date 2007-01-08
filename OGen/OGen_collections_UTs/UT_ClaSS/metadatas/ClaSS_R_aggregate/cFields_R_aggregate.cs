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
using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cFields_R_aggregate : iFields {
		#region public cFields_R_aggregate(...);
		public cFields_R_aggregate() {
			classstateapi_ = new cClaSS_(this);
			//---
			fields_ = new ArrayList();
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
					case "field":
						return new cField_R_aggregate();
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
				new cField_R_aggregate(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < fields_.Count; f++) {
				if (((cField_R_aggregate)fields_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}