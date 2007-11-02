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
using System.Collections;

using OGen.lib.collections;

namespace OGen.lib.templates {
	public class XS0_argumentsType
#if !NET_1_1
#endif
	{
		public XS0_argumentsType (
		) {
			argumentcollection_ = new 
#if !NET_1_1
				OGenCollection<XS_argumentType, string>()
#else
				XS_argumentTypeCollection()
#endif
			;
		}
		#region public ... ArgumentCollection { get; }
		private 
#if !NET_1_1
			OGenCollection<XS_argumentType, string>
#else
			XS_argumentTypeCollection
#endif
			argumentcollection_;

		[XmlElement("argument")]
		public XS_argumentType[] argumentcollection__xml {
			get { return argumentcollection_.cols__; }
			set { argumentcollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public
#if !NET_1_1
			OGenCollection<XS_argumentType, string>
#else
			XS_argumentTypeCollection
#endif
		ArgumentCollection
		{
			get { return argumentcollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_argumentsType argumentsType_in) {
			int _index = -1;

			argumentcollection_.Clear();
			for (int d = 0; d < argumentsType_in.argumentcollection_.Count; d++) {
				argumentcollection_.Add(
					out _index,
					new XS_argumentType()
				);
				argumentcollection_[_index].CopyFrom(
					argumentsType_in.argumentcollection_[d]
				);
			}
		}
		#endregion
	}
}