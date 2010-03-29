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

namespace OGen.lib.templates {
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
				return id_;
			}
			set {
				id_ = value;
			}
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
		#region public string TemplateType { get; set; }
		internal string templatetype_;

		[XmlAttribute("templateType")]
		public string TemplateType {
			get {
				return templatetype_;
			}
			set {
				templatetype_ = value;
			}
		}
		#endregion
		#region public XS_ParserEnumeration ParserType { get; set; }
		internal XS_ParserEnumeration parsertype_;

		[XmlAttribute("parserType")]
		public XS_ParserEnumeration ParserType {
			get {
				return parsertype_;
			}
			set {
				parsertype_ = value;
			}
		}
		#endregion
		#region public string IterationType { get; set; }
		internal string iterationtype_;

		[XmlAttribute("iterationType")]
		public string IterationType {
			get {
				return iterationtype_;
			}
			set {
				iterationtype_ = value;
			}
		}
		#endregion
		#region public XS_argumentsType Arguments { get; set; }
		internal XS_argumentsType arguments__;

		[XmlIgnore()]
		public XS_argumentsType Arguments {
			get {
				if (arguments__ == null) {
					arguments__ = new XS_argumentsType();
				}
				return arguments__;
			}
			set {
				arguments__ = value;
			}
		}

		[XmlElement("arguments")]
		public XS_argumentsType arguments__xml {
			get { return arguments__; }
			set { arguments__ = value; }
		}
		#endregion
		#region public XS_conditionsType Conditions { get; set; }
		internal XS_conditionsType conditions__;

		[XmlIgnore()]
		public XS_conditionsType Conditions {
			get {
				if (conditions__ == null) {
					conditions__ = new XS_conditionsType();
				}
				return conditions__;
			}
			set {
				conditions__ = value;
			}
		}

		[XmlElement("conditions")]
		public XS_conditionsType conditions__xml {
			get { return conditions__; }
			set { conditions__ = value; }
		}
		#endregion
		#region public XS_outputsType Outputs { get; set; }
		internal XS_outputsType outputs__;

		[XmlIgnore()]
		public XS_outputsType Outputs {
			get {
				if (outputs__ == null) {
					outputs__ = new XS_outputsType();
				}
				return outputs__;
			}
			set {
				outputs__ = value;
			}
		}

		[XmlElement("outputs")]
		public XS_outputsType outputs__xml {
			get { return outputs__; }
			set { outputs__ = value; }
		}
		#endregion
		#region public XS_dependenciesType Dependencies { get; set; }
		internal XS_dependenciesType dependencies__;

		[XmlIgnore()]
		public XS_dependenciesType Dependencies {
			get {
				if (dependencies__ == null) {
					dependencies__ = new XS_dependenciesType();
				}
				return dependencies__;
			}
			set {
				dependencies__ = value;
			}
		}

		[XmlElement("dependencies")]
		public XS_dependenciesType dependencies__xml {
			get { return dependencies__; }
			set { dependencies__ = value; }
		}
		#endregion

		#region public void CopyFrom(...);
		public void CopyFrom(XS_templateType templateType_in) {
			int _index = -1;

			id_ = templateType_in.id_;
			name_ = templateType_in.name_;
			templatetype_ = templateType_in.templatetype_;
			parsertype_ = templateType_in.parsertype_;
			iterationtype_ = templateType_in.iterationtype_;
			if (templateType_in.arguments__ != null) arguments__.CopyFrom(templateType_in.arguments__);
			if (templateType_in.conditions__ != null) conditions__.CopyFrom(templateType_in.conditions__);
			if (templateType_in.outputs__ != null) outputs__.CopyFrom(templateType_in.outputs__);
			if (templateType_in.dependencies__ != null) dependencies__.CopyFrom(templateType_in.dependencies__);
		}
		#endregion
	}
}