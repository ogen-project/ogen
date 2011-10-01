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
	public class XS0_conditionType
#if !NET_1_1
		: OGenCollectionInterface<string>
#endif
	{
		public XS0_conditionType (
		) {
		}
		public XS0_conditionType (
			string eval_in
		) : this (
		) {
			eval_ = eval_in;
		}

#if !NET_1_1
		#region public string CollectionName { get; }
		[XmlIgnore()]
		public string CollectionName {
			get {
				return Eval;
			}
		}
		#endregion
#endif
		#region public string Eval { get; set; }
		private string eval_;

		[XmlAttribute("eval")]
		public string Eval {
			get {
				return eval_;
			}
			set {
				eval_ = value;
			}
		}
		#endregion
		#region public string To { get; set; }
		private string to_;

		[XmlAttribute("to")]
		public string To {
			get {
				return to_;
			}
			set {
				to_ = value;
			}
		}
		#endregion
	}
}