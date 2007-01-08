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