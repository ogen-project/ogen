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
	class HowTo_Read_DataObject_Property_Attributes {
		public HowTo_Read_DataObject_Property_Attributes() {
//<document>
OGen.NTier.lib.datalayer.DOPropertyAttribute _attribute
	= (OGen.NTier.lib.datalayer.DOPropertyAttribute)Attribute.GetCustomAttribute(
		typeof(OGen.NTier.UTs.lib.datalayer.proxy.SO_User).GetProperty("IDUser"),
		typeof(OGen.NTier.lib.datalayer.DOPropertyAttribute),
		true
	);
Console.WriteLine(
	"name:{0};  isPK:{1};  isIdentity:{2};  DefaultValue:{3};",
	_attribute.Name,
	_attribute.isPK,
	_attribute.isIdentity,
	_attribute.DefaultValue,

	// many other properties available, like:
	_attribute.AditionalInfo, 
	_attribute.DefaultValue, 
	_attribute.ExtendedDescription, 
	_attribute.FK_FieldName, 
	_attribute.FK_TableName, 
	_attribute.FriendlyName, 
	_attribute.isBool, 
	_attribute.isConfig_Config, 
	_attribute.isConfig_Datatype, 
	_attribute.isConfig_Name, 
	_attribute.isDateTime, 
	_attribute.isDecimal, 
	_attribute.isInt, 
	_attribute.isListItemText, 
	_attribute.isListItemValue, 
	_attribute.isNullable, 
	_attribute.isText, 
	_attribute.Size
);
//</document>
		}
	}
}