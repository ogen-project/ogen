// Copyright (C) 2002 Francisco Monteiro

using System;
using System.Reflection;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.howtos {
	class HowTo_Read_and_Write_to_DataObject_Properties {
		public HowTo_Read_and_Write_to_DataObject_Properties() {
			DO_User _user = new DO_User();
			_user.Fields.IDUser = 123;
			_user.Fields.Login = "123";
			_user.Fields.Password = "123";

			PropertyInfo[] _properties = typeof(DO_User).GetProperties(
				BindingFlags.Public | 
				BindingFlags.Instance
			);
			for (int _prop = 0; _prop < _properties.Length; _prop++) {
				if (Attribute.IsDefined(
					_properties[_prop], 
					typeof(DOPropertyAttribute)
				)) {
					Console.Write(
						"{0}: ", 
						_properties[_prop].Name
					);
					Attribute[] _attributes = Attribute.GetCustomAttributes(
						_properties[_prop]
						//, typeof(DOPropertyAttribute)
						//, true
					);
					for (int _att = 0; _att < _attributes.Length; _att++) {
						//if (_attributes[_att].GetType() == typeof(DOPropertyAttribute)) {
							DOPropertyAttribute _attribute = (DOPropertyAttribute)_attributes[_att];
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
						_properties[_prop].GetValue(_user, null)
					);
					_properties[_prop].SetValue(
						_user, 
						Convert.ChangeType(
							456, 
							_properties[_prop].PropertyType
						), 
						null
					);
					Console.WriteLine(
						"new value: {0}", 
						_properties[_prop].GetValue(_user, null)
					);
				}
			}
		}
	}
}