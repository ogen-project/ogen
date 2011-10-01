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

namespace OGen.NTier.UTs.lib.datalayer {
	[XmlRoot("collectionOf_vUserGroup")]
	public class SC0_vUserGroup {
		#region public SC0_vUserGroup(...);
		public SC0_vUserGroup() {
		}
		#endregion

		#region public SO0_vUserGroup[] SO0_vUserGroup { get; set; }
		private SO0_vUserGroup[] vusergroup_;

		[XmlElement("oneItemOf_vUserGroup")]
		public SO0_vUserGroup[] SO0_vUserGroup {
			get { return vusergroup_; }
			set { vusergroup_ = value; }
		}
		#endregion
	}
}