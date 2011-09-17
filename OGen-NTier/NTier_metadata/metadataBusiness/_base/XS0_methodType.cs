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
	public class XS0_methodType {
	#else
	public partial class XS_methodType {
	#endif

		#region public object parent_ref { get; }
		internal object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;
				if (parameters__ != null) parameters__.parent_ref = this;
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
				if (parameters__ != null) parameters__.root_ref = value;
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
		#region public string OutputType { get; set; }
		internal string outputtype_;

		[XmlAttribute("outputType")]
		public string OutputType {
			get {
				return outputtype_;
			}
			set {
				outputtype_ = value;
			}
		}
		#endregion
		#region public bool Distribute { get; set; }
		internal bool distribute_;

		[XmlAttribute("distribute")]
		public bool Distribute {
			get {
				return distribute_;
			}
			set {
				distribute_ = value;
			}
		}
		#endregion
		#region public bool isSearch { get; set; }
		internal bool issearch_;

		[XmlAttribute("isSearch")]
		public bool isSearch {
			get {
				return issearch_;
			}
			set {
				issearch_ = value;
			}
		}
		#endregion
		#region public int IPParamNum { get; set; }
		internal int ipparamnum_;

		[XmlAttribute("ipParamNum")]
		public int IPParamNum {
			get {
				return ipparamnum_;
			}
			set {
				ipparamnum_ = value;
			}
		}
		#endregion
		#region public XS_parametersType Parameters { get; set; }
		internal XS_parametersType parameters__;

		[XmlIgnore()]
		public XS_parametersType Parameters {
			get {
				if (parameters__ == null) {
					parameters__ = new XS_parametersType();
				}
				return parameters__;
			}
			set {
				parameters__ = value;
			}
		}

		[XmlElement("parameters")]
		public XS_parametersType parameters__xml {
			get { return parameters__; }
			set { parameters__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_methodType methodType_in) {
			int _index = -1;

			name_ = methodType_in.name_;
			outputtype_ = methodType_in.outputtype_;
			distribute_ = methodType_in.distribute_;
			issearch_ = methodType_in.issearch_;
			ipparamnum_ = methodType_in.ipparamnum_;
			if (methodType_in.parameters__ != null) parameters__.CopyFrom(methodType_in.parameters__);
		}
		#endregion
	}
}