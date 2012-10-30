#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.NTier.lib.metadata.metadataBusiness {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

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
				this.parent_ref_ = value;
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
				this.root_ref_ = value;
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
				return this.name_;
			}
			set {
				this.name_ = value;
			}
		}
		#endregion
		#region public string OutputType { get; set; }
		internal string outputtype_;

		[XmlAttribute("outputType")]
		public string OutputType {
			get {
				return this.outputtype_;
			}
			set {
				this.outputtype_ = value;
			}
		}
		#endregion
		#region public bool Distribute { get; set; }
		internal bool distribute_;

		[XmlAttribute("distribute")]
		public bool Distribute {
			get {
				return this.distribute_;
			}
			set {
				this.distribute_ = value;
			}
		}
		#endregion
		#region public bool isSearch { get; set; }
		internal bool issearch_;

		[XmlAttribute("isSearch")]
		public bool isSearch {
			get {
				return this.issearch_;
			}
			set {
				this.issearch_ = value;
			}
		}
		#endregion
		#region public int IPParamNum { get; set; }
		internal int ipparamnum_;

		[XmlAttribute("ipParamNum")]
		public int IPParamNum {
			get {
				return this.ipparamnum_;
			}
			set {
				this.ipparamnum_ = value;
			}
		}
		#endregion
		#region public XS_parametersType Parameters { get; set; }
		internal XS_parametersType parameters__;
		internal object parameters__locker = new object();

		[XmlIgnore()]
		public XS_parametersType Parameters {
			get {

				// check before lock
				if (this.parameters__ == null) {

					lock (this.parameters__locker) {

						// double check, thread safer!
						if (this.parameters__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.parameters__ = new XS_parametersType();
						}
					}
				}

				return this.parameters__;
			}
			set {
				this.parameters__ = value;
			}
		}

		[XmlElement("parameters")]
		public XS_parametersType parameters__xml {
			get { return this.parameters__; }
			set { this.parameters__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_methodType methodType_in) {
			this.name_ = methodType_in.name_;
			this.outputtype_ = methodType_in.outputtype_;
			this.distribute_ = methodType_in.distribute_;
			this.issearch_ = methodType_in.issearch_;
			this.ipparamnum_ = methodType_in.ipparamnum_;
			if (methodType_in.parameters__ != null) this.parameters__.CopyFrom(methodType_in.parameters__);
		}
		#endregion
	}
}