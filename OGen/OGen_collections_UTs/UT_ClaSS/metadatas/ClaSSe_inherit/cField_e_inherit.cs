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
using System.Reflection;

using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cField_e_inherit : cClaSSe, iField {
		#region public cField_e_inherit(...);
		public cField_e_inherit(
			iClaSSe aggregateloopback_ref_in
		) : this (
			aggregateloopback_ref_in, 
			string.Empty
		) {}
		public cField_e_inherit(
			iClaSSe aggregateloopback_ref_in, 
			string name_in
		) : base (
			aggregateloopback_ref_in
		) {
			name_ = name_in;
			ispk_ = false;
			dbtype_indb_ = (int)SqlDbType.Variant;
		}
		#endregion

		#region implementing cClaSSe...
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
		#endregion

		#region public string Name { get; set; }
		public string name_;

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