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
using System.IO;
using System.Xml.Serialization;

namespace OGen.NTier.lib.metadata.metadataBusiness {
	#if NET_1_1
	public class XS0__metadataBusinessCollection {
	#else
	public partial class XS__metadataBusinessCollection {
	#endif
		#if NET_1_1
		public XS0__metadataBusinessCollection(
		#else
		public XS__metadataBusinessCollection(
		#endif
			XS__metadataBusiness[] metadatabusinesscollection_in
		) {
			metadatabusinesscollection_ = metadatabusinesscollection_in;
		}

		#region public XS__metadataBusiness this[...] { get; }
		private XS__metadataBusiness[] metadatabusinesscollection_;

		public XS__metadataBusiness this[int index_in] {
			get {
				return metadatabusinesscollection_[index_in];
			}
		}
		public XS__metadataBusiness this[string name_in] {
			get {
				// ToDos: later! performance

				for (int i = 0; i < metadatabusinesscollection_.Length; i++) {
					if (metadatabusinesscollection_[i].ApplicationName == name_in) {
						return metadatabusinesscollection_[i];
					}
				}
				throw new Exception(string.Format(
					"{0}.{1}[string name_in]: can't find: {2}",
					typeof(XS__metadataBusinessCollection).Namespace, 
					typeof(XS__metadataBusinessCollection).Name, 
					name_in
				));
			}
		}
		#endregion
		public int Count { get {
			return metadatabusinesscollection_.Length;
		} }
	}
}