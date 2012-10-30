#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.lib.templates {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_conditionsType {
	#else
	public partial class XS_conditionsType {
	#endif
		#region public XS_conditionTypeCollection ConditionCollection { get; }
		internal XS_conditionTypeCollection conditioncollection_ 
			= new XS_conditionTypeCollection();

		[XmlElement("condition")]
		public XS_conditionType[] conditioncollection__xml {
			get { return this.conditioncollection_.cols__; }
			set { this.conditioncollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_conditionTypeCollection ConditionCollection {
			get { return this.conditioncollection_; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_conditionsType conditionsType_in) {
			int _index = -1;

			this.conditioncollection_.Clear();
			for (int d = 0; d < conditionsType_in.conditioncollection_.Count; d++) {
				this.conditioncollection_.Add(
					out _index,
					new XS_conditionType()
				);
				this.conditioncollection_[_index].CopyFrom(
					conditionsType_in.conditioncollection_[d]
				);
			}
		}
		#endregion
	}
}