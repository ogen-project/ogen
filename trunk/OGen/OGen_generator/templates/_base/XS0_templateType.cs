#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion


namespace OGen.Libraries.Templates {
	using System;
	using System.Collections;
	using System.Xml.Serialization;

	#if NET_1_1
	public class XS0_templateType {
	#else
	public partial class XS_templateType {
	#endif
		#region public string ID { get; set; }
		internal string id_;

		[XmlAttribute("id")]
		public string ID {
			get {
				return this.id_;
			}
			set {
				this.id_ = value;
			}
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
		#region public string TemplateType { get; set; }
		internal string templatetype_;

		[XmlAttribute("templateType")]
		public string TemplateType {
			get {
				return this.templatetype_;
			}
			set {
				this.templatetype_ = value;
			}
		}
		#endregion
		#region public XS_ParserEnumeration ParserType { get; set; }
		internal XS_ParserEnumeration parsertype_;

		[XmlAttribute("parserType")]
		public XS_ParserEnumeration ParserType {
			get {
				return this.parsertype_;
			}
			set {
				this.parsertype_ = value;
			}
		}
		#endregion
		#region public string IterationType { get; set; }
		internal string iterationtype_;

		[XmlAttribute("iterationType")]
		public string IterationType {
			get {
				return this.iterationtype_;
			}
			set {
				this.iterationtype_ = value;
			}
		}
		#endregion
		#region public XS_argumentsType Arguments { get; set; }
		internal XS_argumentsType arguments__;
		internal object arguments__locker = new object();

		[XmlIgnore()]
		public XS_argumentsType Arguments {
			get {

				// check before lock
				if (this.arguments__ == null) {

					lock (this.arguments__locker) {

						// double check, thread safer!
						if (this.arguments__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.arguments__ = new XS_argumentsType();
						}
					}
				}

				return this.arguments__;
			}
			set {
				this.arguments__ = value;
			}
		}

		[XmlElement("arguments")]
		public XS_argumentsType arguments__xml {
			get { return this.arguments__; }
			set { this.arguments__ = value; }
		}
		#endregion
		#region public XS_conditionsType Conditions { get; set; }
		internal XS_conditionsType conditions__;
		internal object conditions__locker = new object();

		[XmlIgnore()]
		public XS_conditionsType Conditions {
			get {

				// check before lock
				if (this.conditions__ == null) {

					lock (this.conditions__locker) {

						// double check, thread safer!
						if (this.conditions__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.conditions__ = new XS_conditionsType();
						}
					}
				}

				return this.conditions__;
			}
			set {
				this.conditions__ = value;
			}
		}

		[XmlElement("conditions")]
		public XS_conditionsType conditions__xml {
			get { return this.conditions__; }
			set { this.conditions__ = value; }
		}
		#endregion
		#region public XS_outputsType Outputs { get; set; }
		internal XS_outputsType outputs__;
		internal object outputs__locker = new object();

		[XmlIgnore()]
		public XS_outputsType Outputs {
			get {

				// check before lock
				if (this.outputs__ == null) {

					lock (this.outputs__locker) {

						// double check, thread safer!
						if (this.outputs__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.outputs__ = new XS_outputsType();
						}
					}
				}

				return this.outputs__;
			}
			set {
				this.outputs__ = value;
			}
		}

		[XmlElement("outputs")]
		public XS_outputsType outputs__xml {
			get { return this.outputs__; }
			set { this.outputs__ = value; }
		}
		#endregion
		#region public XS_dependenciesType Dependencies { get; set; }
		internal XS_dependenciesType dependencies__;
		internal object dependencies__locker = new object();

		[XmlIgnore()]
		public XS_dependenciesType Dependencies {
			get {

				// check before lock
				if (this.dependencies__ == null) {

					lock (this.dependencies__locker) {

						// double check, thread safer!
						if (this.dependencies__ == null) {

							// initialization...
							// ...attribution (last thing before unlock)
							this.dependencies__ = new XS_dependenciesType();
						}
					}
				}

				return this.dependencies__;
			}
			set {
				this.dependencies__ = value;
			}
		}

		[XmlElement("dependencies")]
		public XS_dependenciesType dependencies__xml {
			get { return this.dependencies__; }
			set { this.dependencies__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_templateType templateType_in) {
			this.id_ = templateType_in.id_;
			this.name_ = templateType_in.name_;
			this.templatetype_ = templateType_in.templatetype_;
			this.parsertype_ = templateType_in.parsertype_;
			this.iterationtype_ = templateType_in.iterationtype_;
			if (templateType_in.arguments__ != null) this.arguments__.CopyFrom(templateType_in.arguments__);
			if (templateType_in.conditions__ != null) this.conditions__.CopyFrom(templateType_in.conditions__);
			if (templateType_in.outputs__ != null) this.outputs__.CopyFrom(templateType_in.outputs__);
			if (templateType_in.dependencies__ != null) this.dependencies__.CopyFrom(templateType_in.dependencies__);
		}
		#endregion
	}
}