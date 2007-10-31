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

using OGen.lib.collections;

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Search : cClaSSe {
		#region public cDBMetadata_Table_Search(...);
		public cDBMetadata_Table_Search(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Table_Searches parent_ref_, 
			string name_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref = parent_ref_;

			//#region ClaSSe...
			Name = name_in;
			isRange = false;
			isExplicitUniqueIndex = false;
			//---
			searchparameters_ = new cDBMetadata_Field_refs(
				this, 
				this.Parent_ref.Parent_ref.Parent_ref
			);
			updates_ = new cDBMetadata_Updates(
				this, 
				/*this*/this.Parent_ref.Parent_ref.Parent_ref
			);
			//#endregion
		}
		#endregion

		#region Implementing - iClaSSe...
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
		public override object Property_new(string Name_) {
			switch (Name_) {
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}", 
						this.GetType().Namespace,
						this.GetType().Name,
						Name_
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
		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region public bool isRange { get; set; }
		private bool isrange_;
		public bool isRange {
			get { return isrange_; }
			set { isrange_ = value; }
		}

		[ClaSSPropertyAttribute("isRange", ClaSSPropertyAttribute.eType.standard, true)]
		private string isrange_reflection {
			get { return isrange_.ToString(); }
			set { isrange_ = bool.Parse(value); }
		}
		#endregion
		#region public bool isExplicitUniqueIndex { get; set; }
		private bool isexplicituniqueindex_;
		public bool isExplicitUniqueIndex {
			get { return isexplicituniqueindex_; }
			set { isexplicituniqueindex_ = value; }
		}

		[ClaSSPropertyAttribute("isExplicitUniqueIndex", ClaSSPropertyAttribute.eType.standard, true)]
		private string isexplicituniqueindex_reflection {
			get { return isexplicituniqueindex_.ToString(); }
			set { isexplicituniqueindex_ = bool.Parse(value); }
		}
		#endregion
		#region public iDBMetadata_Field_refs_SearchParameters SearchParameters { get; }
		private iDBMetadata_Field_refs_SearchParameters searchparameters_;
		public iDBMetadata_Field_refs_SearchParameters SearchParameters {
			get { return searchparameters_; }
		}

		[ClaSSPropertyAttribute("searchParameters", ClaSSPropertyAttribute.eType.aggregate, true)]
		private iDBMetadata_Field_refs_SearchParameters searchparameters_reflection {
			get { return searchparameters_; }
			//set { searchparameters_ = value; }
		}
		#endregion
		#region public cDBMetadata_Updates Updates { get; }
		private cDBMetadata_Updates updates_;
		public cDBMetadata_Updates Updates {
			get { return updates_; }
		}

		[ClaSSPropertyAttribute("updates", ClaSSPropertyAttribute.eType.aggregate, true)]
		private cDBMetadata_Updates updates_reflection {
			get { return updates_; }
			//set { updates_ = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public cDBMetadata_Table_Searches Parent_ref;
		private cDBMetadata_Table_Searches parent_ref;
		public cDBMetadata_Table_Searches Parent_ref {
			get { return parent_ref; }
		}
		#endregion
		#endregion

		#region Methods...
		#region public override string ToString();
		public override string ToString() {
			return Name;
		}
		#endregion
		#endregion
	}
}
