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
				_attribute.DefaultValue
			);
			Console.WriteLine();
		}
	}
}