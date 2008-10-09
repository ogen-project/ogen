// Copyright (C) 2002 Francisco Monteiro

using System;
using System.Reflection;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.howtos {
	class HowTo_List_DataObjects {
		public HowTo_List_DataObjects() {
			Assembly _assembly = Assembly.Load(
				#if NET_1_1
				"OGen.NTier.UTs.lib.datalayer-1.1"
				#elif NET_2_0
				"OGen.NTier.UTs.lib.datalayer-2.0"
				#endif
			);
			if (_assembly != null) {
				Type[] _types = _assembly.GetTypes();
				for (int _tp = 0; _tp < _types.Length; _tp++) {
					Type _type = (Type)_types[_tp];

					object[] _doclassattributes = _type.GetCustomAttributes(
						typeof(DOClassAttribute),
						true//false
					);
					if (
						(_doclassattributes.Length > 0)
						&&
						(_type.Name.IndexOf("DO0_") != 0)
					) {
						Console.Write("{0};  ", _type.Name);
						for (int _catt = 0; _catt < _doclassattributes.Length; _catt++) {
							DOClassAttribute _classattribute = (DOClassAttribute)_doclassattributes[_catt];
							Console.WriteLine(
								"name: {0};  isVirtualTable: {1};  isConfig: {2};  ",
								_classattribute.Name,
								_classattribute.isVirtualTable,
								_classattribute.isConfig
							);

							PropertyInfo[] _properties = _type.GetProperties(
								BindingFlags.Public |
								BindingFlags.Instance
							);
							for (int _prop = 0; _prop < _properties.Length; _prop++) {
								if (Attribute.IsDefined(
									_properties[_prop],
									typeof(DOPropertyAttribute)
								)) {
									Console.Write(
										"\t{0}: ",
										_properties[_prop].Name
									);
									Attribute[] _attributes = Attribute.GetCustomAttributes(
										_properties[_prop]
										//, typeof(DOPropertyAttribute)
										//, true
									);
									//Console.WriteLine("Name \t isPK \t isIdentity \t DefaultValue \t \t \t \t isBool");
									for (int _att = 0; _att < _attributes.Length; _att++) {
										//if (_attributes[_att].GetType() == typeof(DOPropertyAttribute)) {
											DOPropertyAttribute _propertyattribute = (DOPropertyAttribute)_attributes[_att];
											Console.Write(
												"name:{0};  isPK:{1};  isIdentity:{2};  isText:{3};",
												_propertyattribute.Name,
												_propertyattribute.isPK,
												_propertyattribute.isIdentity,
												//att3.DefaultValue,
												//att3.isConfig_Name, 
												//att3.isConfig_Config, 
												//att3.isConfig_Datatype, 
												_propertyattribute.isText
											);
										//}
									}
									Console.WriteLine();
								}
							}
							Console.WriteLine();
						}
					}
				}
			}
		}
	}
}