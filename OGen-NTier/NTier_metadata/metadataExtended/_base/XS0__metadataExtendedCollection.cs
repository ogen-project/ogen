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

namespace OGen.NTier.lib.metadata.metadataExtended {
	#if NET_1_1
	public class XS0__metadataExtendedCollection {
	#else
	public partial class XS__metadataExtendedCollection {
	#endif
		#if NET_1_1
		public XS0__metadataExtendedCollection(
		#else
		public XS__metadataExtendedCollection(
		#endif
			XS__metadataExtended[] metadataextendedcollection_in
		) {
			metadataextendedcollection_ = metadataextendedcollection_in;
		}

		#region public XS__metadataExtended this[...] { get; }
		private XS__metadataExtended[] metadataextendedcollection_;

		public XS__metadataExtended this[int index_in] {
			get {
				return metadataextendedcollection_[index_in];
			}
		}
		public XS__metadataExtended this[string name_in] {
			get {
				// ToDos: later! performance

				for (int i = 0; i < metadataextendedcollection_.Length; i++) {
					if (metadataextendedcollection_[i].ApplicationName == name_in) {
						return metadataextendedcollection_[i];
					}
				}
				throw new Exception(string.Format(
					"{0}.{1}[string name_in]: can't find: {2}",
					typeof(XS__metadataExtendedCollection).Namespace, 
					typeof(XS__metadataExtendedCollection).Name, 
					name_in
				));
			}
		}
		#endregion
		public int Count { get {
			return metadataextendedcollection_.Length;
		} }
	}
}