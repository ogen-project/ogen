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

namespace OGen.NTier.lib.metadata.metadataBusiness {
	#if NET_1_1
	public class XS0_parameterType {
	#else
	public partial class XS_parameterType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public XS__RootMetadata root_ref { get; }
		internal XS__RootMetadata root_ref_;

		[XmlIgnore()]
		public XS__RootMetadata root_ref {
			set {
				root_ref_ = value;
			}
			get { return root_ref_; }
		}
		#endregion
		#region public string Name { get; set; }
		internal string name_;

		[XmlAttribute("name")]
		public string Name {
			get {
				return name_;
			}
			set {
				name_ = value;
			}
		}
		#endregion
		#region public string Type { get; set; }
		internal string type_;

		[XmlAttribute("type")]
		public string Type {
			get {
				return type_;
			}
			set {
				type_ = value;
			}
		}
		#endregion
		#region public bool isParams { get; set; }
		internal bool isparams_;

		[XmlAttribute("isParams")]
		public bool isParams {
			get {
				return isparams_;
			}
			set {
				isparams_ = value;
			}
		}
		#endregion
		#region public bool isOut { get; set; }
		internal bool isout_;

		[XmlAttribute("isOut")]
		public bool isOut {
			get {
				return isout_;
			}
			set {
				isout_ = value;
			}
		}
		#endregion
		#region public bool isRef { get; set; }
		internal bool isref_;

		[XmlAttribute("isRef")]
		public bool isRef {
			get {
				return isref_;
			}
			set {
				isref_ = value;
			}
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_parameterType parameterType_in) {
			int _index = -1;

			name_ = parameterType_in.name_;
			type_ = parameterType_in.type_;
			isparams_ = parameterType_in.isparams_;
			isout_ = parameterType_in.isout_;
			isref_ = parameterType_in.isref_;
		}
		#endregion
	}
}