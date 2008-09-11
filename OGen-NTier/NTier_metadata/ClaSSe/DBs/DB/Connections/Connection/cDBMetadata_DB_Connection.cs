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
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
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
