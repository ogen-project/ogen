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

namespace OGen.XSD.lib.metadata.schema {
	public class utils {
		private utils() { }

		#region public static string Convert_NType(...);
		public static string Convert_NType(
			XS__RootMetadata root_ref_in,
			string xsdType_in
		) {
			bool isStandardNType_out;
			return Convert_NType(
				root_ref_in,
				xsdType_in,
				out isStandardNType_out
			);
		}

		public static string Convert_NType(
			XS__RootMetadata root_ref_in, 
			string xsdType_in, 
			out bool isStandardNType_out
		) {
			isStandardNType_out = true;
			switch (xsdType_in) {
				case "xs:string":
					return "string";
				case "xs:decimal":
					return "decimal";
				case "xs:integer":
					return "int";
				case "xs:boolean":
					return "bool";
				case "xs:time":
				case "xs:date":
					return "DateTime";

				default:
					isStandardNType_out = false;
					return string.Format(
						"{0}{1}",
						root_ref_in.MetadataCollection[0].Prefix,
						(root_ref_in == null)
							? xsdType_in
							: root_ref_in.MetadataCollection[0].CaseTranslate(xsdType_in)
					);
			}
		}
		#endregion
	}
}
