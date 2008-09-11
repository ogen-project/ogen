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
using NUnit.Framework;

using OGen.lib.parser;

namespace OGen.lib.parser.UTs {
	[TestFixture]
	public class UT_ParserXSLT { public UT_ParserXSLT() {}
		#region private string resourse_dir { get; }
		private string resourse_dir { 
			get { 
				return System.Configuration.ConfigurationSettings.AppSettings["OGen_parser_UTs_resourse_dir"];
			}
		}
		#endregion
		#region private string Metadata_File { get; }
		private string metadata_file = null;
		private string Metadata_File {
			get {
				if (metadata_file == null) {
					metadata_file = Path.Combine(
						resourse_dir, 
						Path.Combine(
							"UT_ParserXSLT", 
							Path.Combine(
								"resources", 
								"metadata.xml"
							)
						)
					);
				}
				return metadata_file;
			}
		}
		#endregion
		#region private string Template_File { get; }
		private string template_file = null;
		private string Template_File {
			get {
				if (template_file == null) {
					template_file = Path.Combine(
						resourse_dir, 
						Path.Combine(
							"UT_ParserXSLT", 
							Path.Combine(
								"resources", 
								"template.xslt"
							)
						)
					);
				}
				return template_file;
			}
		}
		#endregion

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			// ...
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			// ...
		}
		#endregion

		[Test]
		public void UT_SomeTest() {
			StringWriter _parsedOutput = new StringWriter();
			Hashtable _hash = new Hashtable();
			_hash.Add("TableName", "User");

//Console.WriteLine(Metadata_File);
//Console.WriteLine(Template_File);

			ParserXSLT.Parse(
				Metadata_File,  
				Template_File, 
				_hash, 
				_parsedOutput
			);

Console.WriteLine(_parsedOutput.ToString());

			Assert.IsTrue(true, "some test");
		}
	}
}