#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.Metadata {
	using System;
	using System.Collections;
	using System.IO;
	using System.Xml.Serialization;

	using OGen.Libraries.Collections;

	public class Metadata {
		#region public string XMLFilename { get; set; }
		private string xmlfilename_;

		[XmlAttribute("xmlFilename")]
		public string XMLFilename {
			get {
				return this.xmlfilename_;
			}
			set {
				this.xmlfilename_ = value;
			}
		}
		#endregion
		#region public string XMLFileType { get; set; }
		private string xmlfiletype_;

		[XmlAttribute("xmlFileType")]
		public string XMLFileType {
			get {
				return this.xmlfiletype_;
			}
			set {
				this.xmlfiletype_ = value;
			}
		}
		#endregion
	}
}
