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
	public class HowTo_Read_DataObject_Property_Attributes {
		public HowTo_Read_DataObject_Property_Attributes() { }

#if NUnit
		[Test]
#else
		[TestMethod]
#endif
		public void HowTo() {
//<document>
OGen.NTier.Libraries.DataLayer.DOPropertyAttribute _attribute
	= (OGen.NTier.Libraries.DataLayer.DOPropertyAttribute)Attribute.GetCustomAttribute(
		typeof(OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_User).GetProperty("IDUser"),
		typeof(OGen.NTier.Libraries.DataLayer.DOPropertyAttribute),
		true
	);
Console.WriteLine(
	"name:{0};  isPK:{1};  isIdentity:{2};  DefaultValue:{3};",
	_attribute.Name,
	_attribute.IsPK,
	_attribute.IsIdentity,
	_attribute.DefaultValue,

	// many other properties available, like:
	_attribute.AditionalInfo, 
	_attribute.DefaultValue, 
	_attribute.ExtendedDescription, 
	_attribute.ForeignKey_TableName, 
	_attribute.ForeignKey_TableFieldName, 
	_attribute.FriendlyName, 
	_attribute.IsBoolean, 
	_attribute.IsConfig_Config, 
	_attribute.IsConfig_Datatype, 
	_attribute.IsConfig_Name, 
	_attribute.IsDateTime, 
	_attribute.IsDecimal, 
	_attribute.IsInteger, 
	_attribute.IsListItemText, 
	_attribute.IsListItemValue, 
	_attribute.IsNullable, 
	_attribute.IsText, 
	_attribute.Size
);
//</document>

			// the only porpuses is to keep documentation code samples updated by: 
			// 1) ensure documentation code samples are compiling 
			// 2) no exceptions are beeing thrown by documentation code samples
			Assert.IsTrue(
				true,
				"documentation code sample is failing"
			);

		}
	}
}