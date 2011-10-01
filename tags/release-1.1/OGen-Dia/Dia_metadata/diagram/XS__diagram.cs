#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Xml.Serialization;

namespace OGen.Dia.lib.metadata.diagram {
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.lysator.liu.se/~alla/dia/")]
	[System.Xml.Serialization.XmlRootAttribute(
		"diagram",
		Namespace = "http://www.lysator.liu.se/~alla/dia/",
		IsNullable = false
	)]
	#if NET_1_1
	public class XS__diagram : XS0__diagram {
	#else
	public partial class XS__diagram {
	#endif

		#region public string FilePath { get; }
		private string filepath_;

		[XmlIgnore()]
		[XmlAttribute("filePath")]
		public string FilePath {
			get {
				return filepath_;
			}
			set {
				filepath_ = value;
			}
		}
		#endregion
		#region public string FileName { get; }
		[XmlIgnore()]
		[XmlAttribute("fileName")]
		public string FileName {
			get {
				return System.IO.Path.GetFileNameWithoutExtension(filepath_);
			}
		}
		#endregion

		#region public XS_objectType Table_search(...);
		public XS_objectType Table_search(
			string id_in
		) {
			for (int l = 0; l < LayerCollection.Count; l++) {
				for (int o = 0; o < LayerCollection[l].ObjectCollection.Count; o++) {
					if (LayerCollection[l].ObjectCollection[o].Id == id_in) {
						return LayerCollection[l].ObjectCollection[o];
					}
				}
			}

			return null;
		}
		#endregion
	}
}