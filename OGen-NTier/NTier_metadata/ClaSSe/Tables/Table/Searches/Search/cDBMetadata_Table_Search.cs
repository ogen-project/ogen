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