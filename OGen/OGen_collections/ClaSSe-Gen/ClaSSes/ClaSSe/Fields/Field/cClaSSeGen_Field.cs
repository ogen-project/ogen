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
