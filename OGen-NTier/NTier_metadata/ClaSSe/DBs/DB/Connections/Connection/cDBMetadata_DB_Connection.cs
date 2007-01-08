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
using System.Reflection;
using System.Collections;
using OGen.lib.collections;
using OGen.lib.datalayer;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_DB_Connection : cClaSSe {
		#region public cDBMetadata_DB_Connection(...);
		public cDBMetadata_DB_Connection(
			iClaSSe aggregateloopback_ref_in,
			bool generateSQL_in, 
			string configMode_in
		) : base (
			aggregateloopback_ref_in
		) {
			//#region ClaSSe...
			ConfigMode = configMode_in;
			isDefault = false;
			GenerateSQL = generateSQL_in;
			isIndexed_andReadOnly = false;
			Connectionstring = string.Empty;
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
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

		#region Properties - ClaSSe...
		#region public string ConfigMode { get; set; }
		private string configmode_;

		[ClaSSPropertyAttribute("configMode", ClaSSPropertyAttribute.eType.standard, true)]
		public string ConfigMode {
			get { return configmode_; }
			set { configmode_ = value; }
		}
		#endregion
		#region public bool isDefault { get; set; }
		private bool isdefault_;
		public bool isDefault {
			get { return isdefault_; }
			set { isdefault_ = value; }
		}

		[ClaSSPropertyAttribute("isDefault", ClaSSPropertyAttribute.eType.standard, true)]
		private string isdefault_reflection {
			get { return isdefault_.ToString(); }
			set { isdefault_ = bool.Parse(value); }
		}
		#endregion
		#region public bool GenerateSQL { get; set; }
		private bool generatesql_;
		public bool GenerateSQL {
			get { return generatesql_; }
			set { generatesql_ = value; }
		}

		[ClaSSPropertyAttribute("generateSQL", ClaSSPropertyAttribute.eType.standard, true)]
		private string generatesql_reflection {
			get { return generatesql_.ToString(); }
			set { generatesql_ = bool.Parse(value); }
		}
		#endregion
		#region public bool isIndexed_andReadOnly { get; set; }
		private bool isindexed_andreadonly_;
		public bool isIndexed_andReadOnly {
			get { return isindexed_andreadonly_; }
			set { isindexed_andreadonly_ = value; }
		}

		[ClaSSPropertyAttribute("isIndexed_andReadOnly", ClaSSPropertyAttribute.eType.standard, true)]
		private string isindexed_andreadonly_reflection {
			get { return isindexed_andreadonly_.ToString(); }
			set { isindexed_andreadonly_ = bool.Parse(value); }
		}
		#endregion
		#region public string Connectionstring { get; set; }
		private string connectionstring_;

		[ClaSSPropertyAttribute("connectionstring", ClaSSPropertyAttribute.eType.standard, true)]
		public string Connectionstring {
			get { return connectionstring_; }
			set { connectionstring_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#endregion

		#region public Methods...
		#region public void CopyFrom(cDBMetadata_DB_Connection dbMetadata_DB_Connection_in);
		public void CopyFrom(cDBMetadata_DB_Connection dbMetadata_DB_Connection_in) {
			isdefault_ = dbMetadata_DB_Connection_in.isdefault_;
			generatesql_ = dbMetadata_DB_Connection_in.generatesql_;
			configmode_ = dbMetadata_DB_Connection_in.configmode_;
			connectionstring_ = dbMetadata_DB_Connection_in.connectionstring_;
		}
		#endregion
		#endregion
	}
}
#region //oldstuff...
//#region public override string ToString();
//public override string ToString() {
//    return string.Format("{0}-{1}", DBServerType.ToString(), ConfigMode);
//}
//#endregion
#endregion