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
	public class cClaSSeGen_ClaSS : cClaSS_noR {
		#region public cClaSSeGen_ClaSS(...);
		public cClaSSeGen_ClaSS() : this (string.Empty) { }
		public cClaSSeGen_ClaSS(string name_in) {
			fields_ = new cClaSSeGen_Fields();

			Name = name_in;
			XMLName = string.Empty;
			Path = string.Empty;
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

		#region public cClaSSeGen_Fields Fields { get; }
//		private cClaSSeGen_Fields fields_;
//
//		[ClaSSPropertyAttribute("fields", ClaSSPropertyAttribute.eType.aggregate)]
//		public cClaSSeGen_Fields Fields {
//			get { return fields_; }
//		}
		private cClaSSeGen_Fields fields_ {
			get { return (cClaSSeGen_Fields)base.Property_aggregate["fields"]; }
			set { base.Property_aggregate["fields"] = value; }
		}
		public cClaSSeGen_Fields Fields {
			get { return fields_; }
		}
		#endregion

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
		#region public string Path { get; set; }
//		private string path_;
//
//		[ClaSSPropertyAttribute("path", ClaSSPropertyAttribute.eType.standard)]
//		public string Path {
//			get { return path_; }
//			set { path_ = value; }
//		}
		public string Path {
			get { return base.Property_standard["path"]; }
			set { base.Property_standard["path"] = value; }
		}
		#endregion
	}
}