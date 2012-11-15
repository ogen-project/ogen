#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DocumentationCodeSamples.UnitTests {
	using System;
#if NUnit
	using NUnit.Framework;
#else
	using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

#if NUnit
	[TestFixture]
#else
	[TestClass]
#endif
	public class HowTo_List_Database_TableFields {
		public HowTo_List_Database_TableFields() { }

#if NUnit
		[Test]
#else
		[TestMethod]
#endif
		public void HowTo() {

//<document>
OGen.Libraries.DataLayer.DBConnection _con 
	= OGen.Libraries.DataLayer.DBConnectionsupport.CreateInstance(
		// set your db server type here
		OGen.Libraries.DataLayer.DBServerTypes.PostgreSQL, 
		// and connectionstring
		"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=Kick;"
	);

// you now have a cDBTableField array populated with all
// field names and other properties for specified table
OGen.Libraries.DataLayer.DBTableField[] _fields = _con.SchemaDatabaseTableFields("CRD_User");

for (int f = 0; f < _fields.Length; f++)
	Console.WriteLine(
		"field name: {0}\nis PK: {1}\nis Identity: {2}\nis nullable: {3}", 
		_fields[f].Name, 
		_fields[f].IsPK, 
		_fields[f].IsIdentity, 
		_fields[f].IsNullable, 

		// many other properties available, like:
		_fields[f].DBCollationName, 
		_fields[f].DBDefaultValue, 
		_fields[f].DBDescription,
		_fields[f].ForeignKey_TableName,
		_fields[f].ForeignKey_TableFieldName, 
		_fields[f].Numeric_Precision, 
		_fields[f].Numeric_Scale, 
		_fields[f].Size
	);

_con.Dispose(); _con = null;
//</document>

			// the only porpuses are: 
			// 1) ensure documentation code samples are compiling 
			// 2) no exceptions are beeing thrown by documentation code samples
			Assert.IsTrue(
				true,
				"documentation code sample is failing"
			);

		}
	}
}