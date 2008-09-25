// Copyright (C) 2002 Francisco Monteiro

using System;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.howtos {
	class HowTo_Read_DataObject_Property_Attributes {
		public HowTo_Read_DataObject_Property_Attributes() {
			DOPropertyAttribute _attribute = (DOPropertyAttribute)Attribute.GetCustomAttribute(
				typeof(DO_User).GetProperty("IDUser"),
				typeof(DOPropertyAttribute),
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
		}
	}
}