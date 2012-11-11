#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.Parser.UnitTests {
	using System;
	using System.Collections;
	using System.IO;
	using NUnit.Framework;

	using OGen.Libraries.Parser;

	[TestFixture]
	public class UT_ParserXSLT { public UT_ParserXSLT() {}
		#region private string resourse_dir { get; }
		private string resourse_dir { 
			get { 
				return 
#if NET_1_1
					System.Configuration.ConfigurationSettings.AppSettings
#else
					System.Configuration.ConfigurationManager.AppSettings
#endif
					["OGen_parser_UTs_resourse_dir"];
			}
		}
		#endregion
		#region private string Metadata_File { get; }
		private string metadata_file = null;
		private string Metadata_File {
			get {
				if (this.metadata_file == null) {
					this.metadata_file = Path.Combine(
						this.resourse_dir, 
						Path.Combine(
							"UT_ParserXSLT", 
							Path.Combine(
								"resources", 
								"metadata.xml"
							)
						)
					);
				}
				return this.metadata_file;
			}
		}
		#endregion
		#region private string Template_File { get; }
		private string template_file = null;
		private string Template_File {
			get {
				if (this.template_file == null) {
					this.template_file = Path.Combine(
						this.resourse_dir, 
						Path.Combine(
							"UT_ParserXSLT", 
							Path.Combine(
								"resources", 
								"template.xslt"
							)
						)
					);
				}
				return this.template_file;
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
			StringWriter _parsedOutput = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
			Hashtable _hash = new Hashtable();
			_hash.Add("TableName", "User");

//Console.WriteLine(Metadata_File);
//Console.WriteLine(Template_File);

			ParserXSLT.Parse(
				this.Metadata_File,
				this.Template_File, 
				_hash, 
				_parsedOutput
			);

Console.WriteLine(_parsedOutput.ToString());

			Assert.IsTrue(true, "some test");
		}
	}
}