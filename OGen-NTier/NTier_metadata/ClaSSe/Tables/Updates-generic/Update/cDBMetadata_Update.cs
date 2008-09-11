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
		public override string root4xml {
			get {
				return cDBMetadata.ROOT;
			}
		}
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
