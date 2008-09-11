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