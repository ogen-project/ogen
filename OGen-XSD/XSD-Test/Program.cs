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
//using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;

using OGen.XSD.lib.metadata;

namespace OGen.XSD.presentationlayer.test {
	public class Program {
		public static void PressAnyKey() {
			Console.Write("Press any key to continue . . . ");
#if !NET_1_1
			Console.ReadKey(true);
#else
			Console.ReadLine();
#endif
			Console.WriteLine();
		}
		public static void Main(string[] args) {
			RootMetadata _root = new RootMetadata(
				System.IO.Path.Combine(
					#if !NET_1_1
					System.Configuration.ConfigurationManager.AppSettings
					#else
					System.Configuration.ConfigurationSettings.AppSettings
					#endif
						["ogenPath"],

					@"..\..\OGen-NTier\NTier_metadata\OGenXSD-metadatas\MD_NTier_metadata.OGenXSD-metadata.xml"
				)
			);
			string ntype = string.Empty;
			string name = string.Empty;
			bool must = false;
			for (int c = 0; c < _root.SchemaCollection[0].ComplexType.Count; c++) {
				must = _root.SchemaCollection[0].ComplexType[c].mustImplementCollection(
					"metadata",
					out ntype,
					out name
				);
				Console.WriteLine(
					"{0}:{1}:{2}", 
					must, 
					ntype, 
					name
				);
			}
			PressAnyKey();
			return;

			#region //XmlSchema...
//			string _filepath = @"c:\test.xml";
//
//			FileStream _file = new FileStream(
//				_filepath,
//				FileMode.Create,
//				FileAccess.Write,
//				FileShare.ReadWrite
//			);
//
//			//ValidationEventHandler _eventHandler 
//			//	= new ValidationEventHandler(Program.ShowCompileErrors);
//
//			XmlSerializerNamespaces _xmlserializernamespaces 
//				= new XmlSerializerNamespaces();
//			_xmlserializernamespaces.Add("PREFIX1", "NAMESPACE111");
//			//_xmlserializernamespaces.Add("PREFIX2", "NAMESPACE222");
//
//			XmlSchema _xmlschema = new XmlSchema();
//			//XmlSchema.Read(
//			//	_file2, 
//			//	_eventHandler
//			//);
//			_xmlschema.ElementFormDefault = XmlSchemaForm.Qualified;
//			_xmlschema.Namespaces = _xmlserializernamespaces;
//			//_xmlschema.Elements;
//
//			_xmlschema.Write(_file);
//			_file.Flush();
//			_file.Close();
			#endregion


			XS_Schema _schema = new XS_Schema();
//			_schema.xmlNS_xs = "http://www.w3.org/2001/XMLSchema";
			_schema.TargetNamespace = "http://ogen.berlios.de";
			_schema.xmlNS = "http://ogen.berlios.de";
			_schema.ElementFormDefault = "qualified";
			
			XS_SimpleType _simpletype = new XS_SimpleType();
			_simpletype.Name = "someEnum";
			_simpletype.Restriction.Base = "xs:string";
			_simpletype.Restriction.Enumeration.Add(
				new XS_Enumeration("someenum1"), 
				new XS_Enumeration("someenum2"), 
				new XS_Enumeration("someenum3")
			);
			_schema.SimpleType.Add(
				_simpletype
			);

			XS_Attribute _attrib1 = new XS_Attribute();
			_attrib1.Name = "someAttrib1";
			_attrib1.Type = "xs:string";
			XS_ComplexType _someType1 = new XS_ComplexType();
			_someType1.Name = "someType1";
			_someType1.Attribute.Add(
				_attrib1
			);

			XS_Attribute _attrib2 = new XS_Attribute();
			_attrib2.Name = "someAttrib2";
			_attrib2.Type = "xs:string";
			XS_Attribute _attrib3 = new XS_Attribute();
			_attrib3.Name = "someAttrib3";
			_attrib3.Type = "xs:string";
			XS_ComplexType _someType2 = new XS_ComplexType();
			_someType2.Name = "someType2";
			_someType2.Attribute.Add(
				_attrib2, 
				_attrib3
			);

			XS_Element _element1 = new XS_Element();
			_element1.Name = "someCollection";
			_element1.Type = "someType1";
			_element1.MaxOccurs 
				//= MaxOccursEnum.unbounded;
				= XS_Element.MaxOccursEnum.unbounded;
			XS_Element _element2 = new XS_Element();
			_element2.Name = "someItem";
			_element2.Type = "someType1";
			_someType2.Sequence.Element.Add(
				_element1, 
				_element2
			);

			_schema.ComplexType.Add(
				_someType1, 
				_someType2
			);
			
			//XS_Element _someElement = new XS_Element();
			//_someElement.Name = "someElement";
			//_someElement.Type = "someType2";
			//_schema.Element = _someElement;
			_schema.Element.Name = "someElement";
			_schema.Element.Type = "someType2";

Console.WriteLine(
	"'{0}' == '{1}'", 
	_schema.SimpleType[0].Restriction.Enumeration[2].Value, 
	_schema.Read_fromRoot("ROOT.simpleType[0].restriction.enumeration[2].value")
);
PressAnyKey();
//Console.WriteLine(
//	"'{0}' == '{1}'", 
//	_schema.SimpleType[0].Restriction.Enumeration[2].XXX, 
//	_schema.Read_fromRoot("ROOT.simpleType[0].restriction.enumeration[2].XXX")
//);
//Console.Write("Press any key to continue . . . ");
//Console.ReadKey(true); Console.WriteLine();
//_schema.IterateThrough_fromRoot(
//	"ROOT.simpleType[n].restriction.enumeration[n]", 
//	notifyme//cClaSSe.dIteration_found
//);
//PressAnyKey();

			string _filepath = @"c:\test.xml";
			_schema.SaveState_toFile(_filepath);
			Output(_schema);
			PressAnyKey();
			_schema = XS_Schema.Load_fromFile(_filepath)[0];
			Output(_schema);
			PressAnyKey();
		}

public static void notifyme(string message_in) {
	Console.WriteLine("{{{0}}}", message_in);
}

		public static void Output(XS_Schema schema_in) {
			Console.WriteLine(
				"<xs:schema targetNamespace=\"{0}\" elementFormDefault=\"{1}\">", 
				schema_in.TargetNamespace, 
				schema_in.ElementFormDefault
			);
			for (int i = 0; i < schema_in.SimpleType.Count; i++) {
				Console.WriteLine(
					"\t<xs:simpleType name=\"{0}\" />", 
					schema_in.SimpleType[i].Name
				);
			}
			for (int i = 0; i < schema_in.ComplexType.Count; i++) {
				Console.WriteLine(
					"\t<xs:complexType name=\"{0}\" />", 
					schema_in.ComplexType[i].Name
				);
			}
			Console.WriteLine(
				"\t<xs:element name=\"{0}\" type=\"{1}\" />", 
				schema_in.Element.Name, 
				schema_in.Element.Type
			);
			Console.WriteLine("</xs:schema>");
		}
	}
}
