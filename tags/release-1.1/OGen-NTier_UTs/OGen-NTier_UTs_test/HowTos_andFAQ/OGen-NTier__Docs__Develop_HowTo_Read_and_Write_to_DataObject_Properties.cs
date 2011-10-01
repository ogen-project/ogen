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

namespace OGen.NTier.UTs.howtos {
	class HowTo_Read_and_Write_to_DataObject_Properties {
		public HowTo_Read_and_Write_to_DataObject_Properties() {
//<document>
OGen.NTier.UTs.lib.datalayer.DO_User _user = new OGen.NTier.UTs.lib.datalayer.DO_User();
_user.Fields.IDUser = 123;
_user.Fields.Login = "123";
_user.Fields.Password = "123";

System.Reflection.PropertyInfo[] _properties
	= typeof(OGen.NTier.UTs.lib.datalayer.proxy.SO_User).GetProperties(
		System.Reflection.BindingFlags.Public |
		System.Reflection.BindingFlags.Instance
	);
for (int _prop = 0; _prop < _properties.Length; _prop++) {
	if (Attribute.IsDefined(
		_properties[_prop],
		typeof(OGen.NTier.lib.datalayer.DOPropertyAttribute)
	)) {
		Console.Write(
			"{0}: ", 
			_properties[_prop].Name
		);
		Attribute[] _attributes = Attribute.GetCustomAttributes(
			_properties[_prop],
			typeof(OGen.NTier.lib.datalayer.DOPropertyAttribute), 
			true
		);
		for (int _att = 0; _att < _attributes.Length; _att++) {
			//if (_attributes[_att].GetType() == typeof(DOPropertyAttribute)) {
			OGen.NTier.lib.datalayer.DOPropertyAttribute _attribute
					= (OGen.NTier.lib.datalayer.DOPropertyAttribute)_attributes[_att];
				Console.Write(
					"name:{0};  isPK:{1};  isIdentity:{2};  DefaultValue:{3};  ",
					_attribute.Name,
					_attribute.isPK,
					_attribute.isIdentity,
					_attribute.DefaultValue
				);
			//}
		}
		Console.Write(
			"value: {0}; ", 
			_properties[_prop].GetValue(_user.Fields, null)
		);
		_properties[_prop].SetValue(
			_user.Fields, 
			Convert.ChangeType(
				456, 
				_properties[_prop].PropertyType
			), 
			null
		);
		Console.WriteLine(
			"new value: {0}", 
			_properties[_prop].GetValue(_user.Fields, null)
		);
	}
}
//</document>
		}
	}
}