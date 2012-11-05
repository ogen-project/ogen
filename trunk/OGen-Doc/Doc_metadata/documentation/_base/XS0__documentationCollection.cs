#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Doc.Libraries.Metadata.Documentation {
	using System;
	using System.IO;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0__documentationCollection {
	#else
	public partial class XS__documentationCollection {
	#endif
		#if NET_1_1
		public XS0__documentationCollection(
		#else
		public XS__documentationCollection(
		#endif
			XS__documentation[] documentationcollection_in
		) {
			this.documentationcollection_ = documentationcollection_in;
		}

		#region public XS__documentation this[...] { get; }
		private XS__documentation[] documentationcollection_;

		public XS__documentation this[int index_in] {
			get {
				return this.documentationcollection_[index_in];
			}
		}
		public XS__documentation this[string name_in] {
			get {
				// ToDos: later! performance

				for (int i = 0; i < this.documentationcollection_.Length; i++) {
					if (this.documentationcollection_[i].DocumentationName == name_in) {
						return this.documentationcollection_[i];
					}
				}
				throw new Exception(string.Format(
					System.Globalization.CultureInfo.CurrentCulture,
					"{0}.{1}[string name_in]: can't find: {2}",
					typeof(XS__documentationCollection).Namespace, 
					typeof(XS__documentationCollection).Name, 
					name_in
				));
			}
		}
		#endregion
		public int Count { get {
			return this.documentationcollection_.Length;
		} }
	}
}