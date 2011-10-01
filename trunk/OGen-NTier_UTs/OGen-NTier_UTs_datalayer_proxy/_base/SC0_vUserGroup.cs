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
using System.Runtime.Serialization;

namespace OGen.NTier.UTs.lib.datalayer.proxy {
	[XmlRoot("collectionOf_vUserGroup")]
	[Serializable()]
	public class SC_vUserGroup {
		#region public SC_vUserGroup(...);
		public SC_vUserGroup() {
		}
		public SC_vUserGroup(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			vusergroup_ = (SO_vUserGroup[])info_in.GetValue("oneItemOf_vUserGroup", typeof(SO_vUserGroup[]));
		}
		#endregion

		#region public SO_vUserGroup[] SO_vUserGroup { get; set; }
		private SO_vUserGroup[] vusergroup_;

		[XmlElement("oneItemOf_vUserGroup")]
		[SoapElement("oneItemOf_vUserGroup")]
		public SO_vUserGroup[] SO_vUserGroup {
			get { return vusergroup_; }
			set { vusergroup_ = value; }
		}
		#endregion

		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("oneItemOf_vUserGroup", vusergroup_);
		}
		#endregion
	}
}