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