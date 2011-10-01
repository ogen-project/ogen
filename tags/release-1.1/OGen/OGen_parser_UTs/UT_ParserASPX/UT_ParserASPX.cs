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
	public class UT_ParserASPX { public UT_ParserASPX() {}
		private string resourse_dir_;
		private string metadata_file_;
		private string template_dir_;
		private string template_file_;

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			resourse_dir_ = System.Configuration.ConfigurationSettings.AppSettings["OGen_parser_UTs_resourse_dir"];
			template_file_ = "template.aspx";

			metadata_file_ = Path.Combine(
				resourse_dir_,
				Path.Combine(
					"UT_ParserASPX",
					Path.Combine(
						"resources",
						"metadata.xml"
					)
				)
			);
			template_dir_ = Path.Combine(
				resourse_dir_, 
				Path.Combine(
					"UT_ParserASPX", 
					"resources"
				)
			);
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
			string _parsedOutput;
			Hashtable _hash = new Hashtable();
			_hash.Add("Lines", 3);

			ParserASPX.Parse(
				template_dir_, 
				template_file_, 
				_hash,
				out _parsedOutput
			);

			Assert.AreEqual(
			    "1#2#3#", 
				_parsedOutput,
				"Expected \"1#2#3#\" output, not: {0}", 
				_parsedOutput
			);
		}
	}
}