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
using System.IO;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;
using OGen.lib.generator;

namespace OGen.XSD.lib.metadata {
	#region public class XS_SchemaCollection { ... }
	public class XS_SchemaCollection {
		public XS_SchemaCollection(
			XS_Schema[] schemas_in
		) {
			schemas_ = schemas_in;
		}

		#region public XS_Schema this[...] { get; }
		private XS_Schema[] schemas_;

		public XS_Schema this[int index_in] {
			get {
				return schemas_[index_in];
			}
		}
		public XS_Schema this[string name_in] {
			get {
				// ToDos: later! performance

				for (int i = 0; i < schemas_.Length; i++) {
					if (schemas_[i].Element.Name == name_in) {
						return schemas_[i];
					}
				}
				throw new Exception(string.Format(
					"{0}.{1}[string name_in]: can't find: {2}",
					typeof(XS_SchemaCollection).Namespace,
					typeof(XS_SchemaCollection).Name,
					name_in
				));
			}
		}
		#endregion
		public int Count {
			get {
				return schemas_.Length;
			}
		}
	}
	#endregion
}
