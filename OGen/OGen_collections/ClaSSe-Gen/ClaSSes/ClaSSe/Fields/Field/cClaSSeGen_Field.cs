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

namespace OGen.lib.collections {
	public class cClaSSeGen_Field : cClaSS_noR {
		#region public cClaSSeGen_Field(...);
		public cClaSSeGen_Field() : this (string.Empty) { }
		public cClaSSeGen_Field(string name_in) {
			Name = name_in;
			XMLName = string.Empty;
			Type = eFieldTypes.invalid;
		}
		#endregion

		#region implementing cClaSS_noR...
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
		#endregion

		public enum eFieldTypes {
			StringField = 0, 
			EnumField = 1,  
			IntField = 2, 

			invalid = 3
		}

		#region public string Name { get; set; }
//		private string name_;
//
//		[ClaSSPropertyAttribute("name", ClaSSPropertyAttribute.eType.standard)]
//		public string Name {
//			get { return name_; }
//			set { name_ = value; }
//		}
		public string Name {
			get { return base.Property_standard["name"]; }
			set { base.Property_standard["name"] = value; }
		}
		#endregion
		#region public string XMLName { get; set; }
//		private string xmlname_;
//
//		[ClaSSPropertyAttribute("xmlName", ClaSSPropertyAttribute.eType.standard)]
//		public string XMLName {
//			get { return xmlname_; }
//			set { xmlname_ = value; }
//		}
		public string XMLName {
			get { return base.Property_standard["xmlName"]; }
			set { base.Property_standard["xmlName"] = value; }
		}
		#endregion
		#region public FieldTypes Type { get; set; }
//		private eFieldTypes type_;
//		public eFieldTypes Type {
//			get { return type_; }
//			set { type_ = value; }
//		}
//
//		[ClaSSPropertyAttribute("type", ClaSSPropertyAttribute.eType.standard)]
//		private string type__ {
//			get { return type_.ToString(); }
//			set { type_ = utils.ClaSSeGen.Field.FieldTypes.convert.FromName(value); }
//		}
		public eFieldTypes Type {
			get { return utils.ClaSSeGen.Field.FieldTypes.convert.FromName(base.Property_standard["type"]); }
			set { base.Property_standard["type"] = value.ToString(); }
		}
		#endregion
	}
}