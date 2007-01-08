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
	public class cDBMetadata_Update : cClaSSe {
		#region public cDBMetadata_Update(...);
		public cDBMetadata_Update(
			iClaSSe aggregateloopback_ref_in, 
			cDBMetadata_Updates parent_ref_in, 
			string name_in
		) : base (
			aggregateloopback_ref_in
		) {
			parent_ref_ = parent_ref_in;

			//#region ClaSSe...
			Name = name_in;
			//---
			updateparameters_ = new cDBMetadata_Field_refs(
				this, 
				parent_ref_.Parent_ref
			);
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
		#region public string Name { get; set; }
		private string name_;

		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard, true)]
		public string Name {
			get { return name_; }
			set { name_ = value; }
		}
		#endregion
		#region private iDBMetadata_Field_refs_UpdateParameters updateparameters_ { get; set; }
		private iDBMetadata_Field_refs_UpdateParameters updateparameters_;

		[ClaSSPropertyAttribute("updateParameters", ClaSSPropertyAttribute.eType.aggregate, true)]
		private iDBMetadata_Field_refs_UpdateParameters updateparameters_reflection {
			get { return updateparameters_; }
			//set { updateparameters_ = value; }
		}
		#endregion
		#endregion
		#region Properties..
		#region public cDBMetadata_Updates Parent_ref { get; }
		private cDBMetadata_Updates parent_ref_;
		public cDBMetadata_Updates Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public iDBMetadata_Field_refs_UpdateParameters UpdateParameters { get; }
		public iDBMetadata_Field_refs_UpdateParameters UpdateParameters {
			get { return updateparameters_; }
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