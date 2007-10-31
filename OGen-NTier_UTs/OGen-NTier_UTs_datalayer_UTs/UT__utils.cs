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
using System.Data;
using System.Reflection;

using NUnit.Framework;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.UTs {
	[TestFixture]
	public class UT__utils {
		public UT__utils() { }

		#region public void TestFixtureSetUp();
		[TestFixtureSetUp]
		public void TestFixtureSetUp() {
			// ...
		}
		#endregion
		#region public void TestFixtureTearDown();
		[TestFixtureTearDown]
		public void TestFixtureTearDown() {
			// ...
		}
		#endregion

		#region public void UT_Check_DataObjects_integrity();
		[Test]
		public void UT_Check_DataObjects_integrity() {
			bool _found_Config = false;
			bool _found_vUserGroup = false;
			int _found_Config_Name = 0;
			int _found_Config_Config = 0;
			int _found_Config_Datatype = 0;
			bool _virtualTable_hasPK = false;

			Assembly _assembly = Assembly.Load("OGen.NTier.UTs.lib.datalayer");
			Assert.IsTrue((_assembly != null), "couldn't load OGen.NTier.UTs.lib.datalayer assembly");
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
						for (int _catt = 0; _catt < _doclassattributes.Length; _catt++) {
							DOClassAttribute _classattribute = (DOClassAttribute)_doclassattributes[_catt];

							PropertyInfo[] _properties = _type.GetProperties(
								BindingFlags.Public |
								BindingFlags.Instance
							);
							for (int _prop = 0; _prop < _properties.Length; _prop++) {
								if (Attribute.IsDefined(
									_properties[_prop],
									typeof(DOPropertyAttribute)
								)) {
									Attribute[] _attributes = Attribute.GetCustomAttributes(
										_properties[_prop]
									);
									for (int _att = 0; _att < _attributes.Length; _att++) {
										DOPropertyAttribute _propertyattribute = (DOPropertyAttribute)_attributes[_att];

										Assert.AreEqual(_properties[_prop].Name, _propertyattribute.Name, "\"{0}\" != \"{1}\" ??", _properties[_prop].Name, _propertyattribute.Name);

										switch (_classattribute.Name) {
											case "Config": {
												if (!_found_Config) {
													_found_Config = true;
													Assert.IsTrue(_classattribute.isConfig, "DO_Config shouldn't have isConfig attribute set to false");
													Assert.IsFalse(_classattribute.isVirtualTable, "DO_Config shouldn't have isVirtualTable attribute set to true");
												}
												if (_classattribute.isConfig) {
													if (_propertyattribute.isConfig_Name) _found_Config_Name++;
													if (_propertyattribute.isConfig_Config) _found_Config_Config++;
													if (_propertyattribute.isConfig_Datatype) _found_Config_Datatype++;
												}
												break;
											}
											case "vUserGroup": {
												if (!_found_vUserGroup) {
													_found_vUserGroup = true;
													Assert.IsFalse(_classattribute.isConfig, "DO_vUserGroup shouldn't have isConfig attribute set to true");
													Assert.IsTrue(_classattribute.isVirtualTable, "DO_vUserGroup shouldn't have isVirtualTable attribute set to false");
												}
												if ((!_virtualTable_hasPK) && (_classattribute.isVirtualTable) && (_propertyattribute.isPK)) _virtualTable_hasPK = true;
												break;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			Assert.IsTrue(_found_Config, "couldn't find: DO_Config");
			Assert.IsTrue(_found_vUserGroup, "couldn't find: DO_vUserGroup");
			Assert.AreEqual(1, _found_Config_Name, "DO_Config isConfig_Name properties: {0}, expected 1", _found_Config_Name);
			Assert.AreEqual(1, _found_Config_Config, "DO_Config isConfig_Config properties: {0}, expected 1", _found_Config_Config);
			Assert.AreEqual(1, _found_Config_Datatype, "DO_Config isConfig_Datatype properties: {0}, expected 1", _found_Config_Datatype);
			Assert.IsTrue(_virtualTable_hasPK, "couldn't find any PKs fields at DO_vUserGroup");
		}
		#endregion
	}
}