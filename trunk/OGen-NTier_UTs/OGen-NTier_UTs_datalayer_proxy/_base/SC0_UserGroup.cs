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
	[XmlRoot("collectionOf_UserGroup")]
	[Serializable()]
	public class SC_UserGroup {
		#region public SC_UserGroup(...);
		public SC_UserGroup() {
		}
		public SC_UserGroup(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			usergroup_ = (SO_UserGroup[])info_in.GetValue("oneItemOf_UserGroup", typeof(SO_UserGroup[]));
		}
		#endregion

		#region public SO_UserGroup[] SO_UserGroup { get; set; }
		private SO_UserGroup[] usergroup_;

		[XmlElement("oneItemOf_UserGroup")]
		[SoapElement("oneItemOf_UserGroup")]
		public SO_UserGroup[] SO_UserGroup {
			get { return usergroup_; }
			set { usergroup_ = value; }
		}
		#endregion

		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("oneItemOf_UserGroup", usergroup_);
		}
		#endregion
	}
}