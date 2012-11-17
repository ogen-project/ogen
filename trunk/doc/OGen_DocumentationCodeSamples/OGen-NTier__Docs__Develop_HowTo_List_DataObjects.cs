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
	public class HowTo_List_DataObjects {
		public HowTo_List_DataObjects() { }

#if NUnit
		[Test]
#else
		[TestMethod]
#endif
		public void HowTo() {
//<document>
Type[] _types;
System.Reflection.Assembly _assembly;


_assembly = System.Reflection.Assembly.Load(
	#if NET_1_1
	"OGen.NTier.Kick.Libraries.DataLayer-1.1"
	#else // elif NET_2_0
	"OGen.NTier.Kick.Libraries.DataLayer-2.0"
	#endif
);
_types = _assembly.GetTypes();
for (int t = 0; t < _types.Length; t++) {
	Type _type = (Type)_types[t];

	object[] _doclassattributes = _type.GetCustomAttributes(
		typeof(OGen.NTier.Libraries.DataLayer.DOClassAttribute),
		true//false
	);
	for (int c = 0; c < _doclassattributes.Length; c++) {
		if (c == 0) Console.Write("{0}: ", _type.Name.PadRight(35, ' '));

		OGen.NTier.Libraries.DataLayer.DOClassAttribute _classattribute 
			= (OGen.NTier.Libraries.DataLayer.DOClassAttribute)_doclassattributes[c];
		Console.WriteLine(
			"name(db): {0}; isVirtualTable: {1}; isConfig: {2};  ",
			_classattribute.Name.PadRight(35, ' '),
			_classattribute.IsVirtualTable ? "T" : "F",
			_classattribute.IsConfig ? "T" : "F"
		);
	}
}


_assembly = System.Reflection.Assembly.Load(
	#if NET_1_1
	"OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures-1.1"
	#else // elif NET_2_0
	"OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures-2.0"
	#endif
);
_types = _assembly.GetTypes();
for (int t = 0; t < _types.Length; t++) {
	Type _type = (Type)_types[t];

	System.Reflection.PropertyInfo[] _properties = _type.GetProperties(
		System.Reflection.BindingFlags.Public |
		System.Reflection.BindingFlags.Instance
	);
	for (int p = 0; p < _properties.Length; p++) {
		if (Attribute.IsDefined(
			_properties[p],
			typeof(OGen.NTier.Libraries.DataLayer.DOPropertyAttribute)
		)) {
			Console.Write(
				"{0}.{1}: ",
				_type.Name.PadRight(27, ' '),
				_properties[p].Name.PadRight(25, ' ')
			);
			Attribute[] _attributes = Attribute.GetCustomAttributes(
				_properties[p],
				typeof(OGen.NTier.Libraries.DataLayer.DOPropertyAttribute),
				true
			);
			for (int a = 0; a < _attributes.Length; a++) {
				OGen.NTier.Libraries.DataLayer.DOPropertyAttribute _propertyattribute
					= (OGen.NTier.Libraries.DataLayer.DOPropertyAttribute)_attributes[a];
				Console.WriteLine(
					"name(db):{0}; isPK:{1}; isIdentity:{2}; isText:{3};",
					_propertyattribute.Name.PadRight(25, ' '),
					_propertyattribute.IsPK ? "T" : "F",
					_propertyattribute.IsIdentity ? "T" : "F",
					//_propertyattribute.DefaultValue,
					_propertyattribute.IsText ? "T" : "F"
				);
			}
			//Console.WriteLine();
		}
	}
	//Console.WriteLine();
}
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