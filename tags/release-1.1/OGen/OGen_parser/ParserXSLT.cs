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
using System.Collections;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;

namespace OGen.lib.parser {
	public class ParserXSLT { private ParserXSLT() {}
		public static void Parse(
			string			xmlMetadataPath_in, 
			string			xsltTemplateURL_in, 
			Hashtable		xsltParameters_in, 

			StringWriter	parsedOutput_in
		) {
			XmlDocument _xmlMetadata = new XmlDocument();
			_xmlMetadata.Load(xmlMetadataPath_in);

			Parse(
				_xmlMetadata, 
				xsltTemplateURL_in, 
				xsltParameters_in, 

				parsedOutput_in
			);
		}
		public static void Parse(
			XmlDocument		xmlMetadata_in, 
			string			xsltTemplateURL_in, 
			Hashtable		xsltParameters_in, 

			StringWriter	parsedOutput_in
		) {
			#region XsltArgumentList _xsltparameters = new XsltArgumentList().AddParam(...);
			XsltArgumentList _xsltparameters = new XsltArgumentList();
			IDictionaryEnumerator _denum = xsltParameters_in.GetEnumerator();
			_denum.Reset();
			while (_denum.MoveNext()) {
				_xsltparameters.AddParam(
					_denum.Key.ToString(), 
					"", 
					System.Web.HttpUtility.UrlEncode(
						_denum.Value.ToString()
					)
				);
			}
			#endregion

			XPathNavigator _xpathnav = xmlMetadata_in.CreateNavigator();
			XslTransform _xslttransform = new XslTransform();
			_xslttransform.Load(
				xsltTemplateURL_in
			);
			_xslttransform.Transform(
				_xpathnav, 
				_xsltparameters, 
				parsedOutput_in, 
				null
			);
		}
	}
}