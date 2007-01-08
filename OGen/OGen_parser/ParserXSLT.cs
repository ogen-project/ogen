#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

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