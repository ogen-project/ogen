#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

using OGen.lib.collections;
using OGen.lib.generator;

namespace OGen.XSD.lib.metadata {
	//[XmlRoot("xs___schema")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.w3.org/2001/XMLSchema")]
	[System.Xml.Serialization.XmlRootAttribute("schema", Namespace="http://www.w3.org/2001/XMLSchema", IsNullable=false)]
	public class XS_Schema : MetadataInterface {
		public XS_Schema() {
		}

		#region public object parent_ref { get; }
		private object parent_ref_;

		[XmlIgnore()]
		public object parent_ref {
			set {
				parent_ref_ = value;

				if (element__ != null) element__.parent_ref = this;
				simpletypecollection_.parent_ref = this;
				complextypecollection_.parent_ref = this;
			}
			get { return parent_ref_; }
		}
		#endregion
		#region public RootMetadata root_ref { get; }
		private RootMetadata root_ref_;

		[XmlIgnore()]
		public RootMetadata root_ref {
			set {
				root_ref_ = value;

				if (element__ != null) element__.root_ref = value;
				simpletypecollection_.root_ref = value;
				complextypecollection_.root_ref = value;
			}
			get { return root_ref_; }
		}
		#endregion
		public const string SCHEMA = "schema";
		public const string ROOT = "ROOT";
		#region public string Root_Schema { get; }
		private string root_schema_ = null;

		[XmlIgnore()]
		public string Root_Schema {
			get { return root_schema_; }
		}
		#endregion

		#region //public string xmlNS_xs { get; set; }
		//		private string xmlns_xs_;
//
//		//[System.Xml.Serialization.XmlElementAttribute("xmlns")]
//		//[XmlElement("xmlns:xs")]
//		[XmlAttribute("xmlns")]
//		//[XmlAttribute(
//		//	AttributeName="xs", 
//		//	//Namespace="http://www.w3.org/2001/XMLSchema-instance"
//		//	Namespace="xs"
//		//)]
//		public string xmlNS_xs {
//			get {
//				return xmlns_xs_;
//			}
//			set {
//				xmlns_xs_ = value;
//			}
//		}
		#endregion
		#region public string TargetNamespace { get; set; }
		private string targetnamespace_;

		//[XmlElement("targetNamespace")]
		[XmlAttribute("targetNamespace")]
		public string TargetNamespace {
			get {
				return targetnamespace_;
			}
			set {
				targetnamespace_ = value;
			}
		}
		#endregion
		#region public string xmlNS { get; set; }
		private string xmlns_;

		//[XmlElement("xmlns")]
		[XmlAttribute("xmlns")]
		public string xmlNS {
			get {
				return xmlns_;
			}
			set {
				xmlns_ = value;
			}
		}
		#endregion
		#region public string ElementFormDefault { get; set; }
		private string elementformdefault_;

		//[XmlElement("elementFormDefault")]
		[XmlAttribute("elementFormDefault")]
		public string ElementFormDefault {
			get {
				return elementformdefault_;
			}
			set {
				elementformdefault_ = value;
			}
		}
		#endregion

		#region public ... SimpleType { get; }
		private XS_SimpleTypeCollection simpletypecollection_
			= new XS_SimpleTypeCollection();

		[XmlElement("simpleType")]
		//[XmlArray("simpleType")]
		//[XmlArrayItem(typeof(XS_SimpleType))]
		public XS_SimpleType[] simpletype__xml {
			get { return simpletypecollection_.cols__; }
			set { simpletypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_SimpleTypeCollection SimpleType {
			get { return simpletypecollection_; }
		}
		#endregion
		#region public ... ComplexType { get; }
		private XS_ComplexTypeCollection complextypecollection_ = new XS_ComplexTypeCollection();

		[XmlElement("complexType")]
		//[XmlArray("complexType")]
		//[XmlArrayItem("complexType", typeof(XS_ComplexType))]
		//[XmlArrayItem("complexType")]
		public XS_ComplexType[] complextype__xml {
			get { return complextypecollection_.cols__; }
			set { complextypecollection_.cols__ = value; }
		}

		[XmlIgnore()]
		public XS_ComplexTypeCollection ComplexType {
			get { return complextypecollection_; }
		}
		#endregion

		#region public XS_Element Element { get; set; }
		private XS_Element element__;

		[XmlIgnore()]
		public XS_Element Element {
			get {
				if (element__ == null) {
					element__ = new XS_Element();
				}
				return element__;
			}
			set {
				element__ = value;
			}
		}

		[XmlElement("element")]
		public XS_Element element__xml {
			get { return element__; }
			set { element__ = value; }
		}
		#endregion

		#region public static XS_Schema[] Load_fromFile(...);
		public static XS_Schema[] Load_fromFile(
			params string[] filePath_in
		) {
			return Load_fromFile(
				null, 
				filePath_in
			);
		}
		public static XS_Schema[] Load_fromFile(
			RootMetadata root_ref_in, 
			params string[] filePath_in
		) {
			FileStream _stream;
			XS_Schema[] _output = new XS_Schema[filePath_in.Length];

			for (int i = 0; i < filePath_in.Length; i++) {
				_stream = new FileStream(
					filePath_in[i],
					FileMode.Open,
					FileAccess.Read,
					FileShare.Read
				);

				try {
					_output[i] = (XS_Schema)new XmlSerializer(typeof(XS_Schema)).Deserialize(
						_stream
					);
					_output[i].root_schema_ = ROOT + "." + SCHEMA + "[" + i + "]";
				} catch (Exception _ex) {
					throw new Exception(string.Format(
						"\n---\n{0}.{1}.Load_fromFile(): - ERROR READING XML:\n{2}\n---\n{3}",
						typeof(XS_Schema).Namespace, 
						typeof(XS_Schema).Name, 
						filePath_in[i],
						_ex.Message
					));
				}

				_output[i].parent_ref = root_ref_in; // ToDos: now!
				if (root_ref_in != null) _output[i].root_ref = root_ref_in;
			}

			return _output;
		}
		#endregion
		#region public void SaveState_toFile(string filePath_in);
		public void SaveState_toFile(string filePath_in) {
			FileStream _file = new FileStream(
				filePath_in,
				FileMode.Create,
				FileAccess.Write,
				FileShare.ReadWrite
			);
			new XmlSerializer(typeof(XS_Schema)).Serialize(
				_file,
				this
			);
			_file.Flush();
			_file.Close();
		}
		#endregion

		public string Read_fromRoot(string what_in) {
			return OGen.lib.generator.utils.ReflectThrough(
				this,
				Root_Schema, 
				null, 
				what_in,
				Root_Schema, 
				true, 
				true
			);
		}

		public void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.lib.generator.utils.IterationFoundDelegate iteration_found_in
		) {
			bool _valuehasbeenfound = false;

			IterateThrough_fromRoot(
				iteration_in, 
				iteration_found_in, 
				ref _valuehasbeenfound
			);
		}
		public void IterateThrough_fromRoot(
			string iteration_in, 
			OGen.lib.generator.utils.IterationFoundDelegate iteration_found_in, 
			ref bool valueHasBeenFound_out
		) {
			OGen.lib.generator.utils.ReflectThrough(
				this,
				Root_Schema, 
				iteration_found_in, 
				iteration_in,
				Root_Schema, 
				false, 
				true, 
				ref valueHasBeenFound_out
			);
		}
	}
}
