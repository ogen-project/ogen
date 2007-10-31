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
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;

namespace OGen.lib.collections {
	public abstract class cClaSS_R : cClaSS__base {
		#region public cClaSS_R(...);
		/// <summary>
		/// if you are inheriting from cClaSS_R
		/// </summary>
		public cClaSS_R(
		) {
			derived_ref_ = this;
		}

		/// <summary>
		/// if you are aggregating cClaSS_R (use whenever inheritance not possible)
		/// </summary>
		public cClaSS_R(
			iClaSS derived_ref_in
		) {
			derived_ref_ = derived_ref_in;
		}
		#endregion

		#region private Properties...
		private iClaSS derived_ref_;
		#endregion
		#region public Properties...
//		private cProperty_standard property_standard__;
//		public cProperty_standard Property_standard {
//			get {
//				if (property_standard__ == null) {
//					property_standard__ = new cProperty_standard();
//
//					PropertyInfo[] _properties = derived_ref_.GetType().GetProperties(
//						BindingFlags.Public | 
//						BindingFlags.Instance | 
//						BindingFlags.NonPublic
//					);
//					for (int p = 0; p < _properties.Length; p++) {
//						if (
//							Attribute.IsDefined(
//								_properties[p], 
//								typeof(ClaSSPropertyAttribute)
//							)
//						) {
//							Attribute[] _atts = Attribute.GetCustomAttributes(
//								_properties[p]
//							);
//							for (int a = 0; a < _atts.Length; a++) {
//								switch (((ClaSSPropertyAttribute)_atts[a]).Type) {
//									case ClaSSPropertyAttribute.eType.standard: {
//										property_standard__.Add(
//											((ClaSSPropertyAttribute)_atts[a]).Name, 
//											(string)_properties[p].GetValue(derived_ref_, null)
//										);
//										break;
//									}
////									case ClaSSPropertyAttribute.eType.aggregate: {
////										SaveState_toFile_out.AppendChild(
////											((iClaSS)_properties[p].GetValue(derived_ref_, null)).SaveState_toFile(
////												xmlDoc_in, 
////												((ClaSSPropertyAttribute)_atts[a]).Name
////											)
////										);
////
////										break;
////									}
////									case ClaSSPropertyAttribute.eType.aggregate_collection: {
////										ArrayList _someArray = (ArrayList)_properties[p].GetValue(derived_ref_, null);
////										for (int i = 0; i < _someArray.Count; i++) {
////											SaveState_toFile_out.AppendChild(
////												((iClaSS)_someArray[i]).SaveState_toFile(
////													xmlDoc_in, 
////													((ClaSSPropertyAttribute)_atts[a]).Name
////												)
////											);
////										}
////
////										break;
////									}
//								}
//							}
//						}
//					}
//				}
//
//				return property_standard__;
//			}
//		}
//
//		private cProperty_aggregate property_aggregate__;
//		public cProperty_aggregate Property_aggregate {
//			get {
//				if (property_aggregate__ == null) {
//					property_aggregate__ = new cProperty_aggregate();
//				}
//
//				return property_aggregate__;
//			}
//		}
//
//		private cProperty_aggregate_collection property_aggregate_collection__;
//		cProperty_aggregate_collection Property_aggregate_collection {
//			get {
//				if (property_aggregate_collection__ == null) {
//					property_aggregate_collection__ = new cProperty_aggregate_collection();
//				}
//
//				return property_aggregate_collection__;
//			}
//		}
		#endregion

		#region public Methods...
		#region public override XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in);
		// ToDos: here! performance
		public override XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in) {
			XmlElement SaveState_toFile_out = xmlDoc_in.CreateElement(
				name_in
			);

			PropertyInfo[] _properties = derived_ref_.GetType().GetProperties(
				BindingFlags.Public | 
				BindingFlags.Instance | 
				BindingFlags.NonPublic
			);
			for (int p = 0; p < _properties.Length; p++) {
				if (
					Attribute.IsDefined(
						_properties[p], 
						typeof(ClaSSPropertyAttribute)
					) // all properties that have ClaSSPropertyAttribute attribute defined
				) {
					ClaSSPropertyAttribute[] _atts = (ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
						_properties[p], 
						typeof(ClaSSPropertyAttribute)
					); // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined

					for (int a = 0; a < _atts.Length; a++) { // if (_atts[a].GetType() == typeof(ClaSSPropertyAttribute)) {
						switch (_atts[a].Type) {
							case ClaSSPropertyAttribute.eType.standard: {
								SaveState_toFile_out.SetAttributeNode(xmlDoc_in.CreateAttribute(
									_atts[a].Name
								));
								SaveState_toFile_out.Attributes[
									_atts[a].Name
								].Value = 
									(string)_properties[p].GetValue(derived_ref_, null);

								break;
							}
							case ClaSSPropertyAttribute.eType.aggregate: {
								SaveState_toFile_out.AppendChild(
									((iClaSS)_properties[p].GetValue(derived_ref_, null)).SaveState_toFile(
										xmlDoc_in, 
										_atts[a].Name
									)
								);

								break;
							}
							case ClaSSPropertyAttribute.eType.aggregate_collection: {
								ArrayList _someArray = (ArrayList)_properties[p].GetValue(derived_ref_, null);
								for (int i = 0; i < _someArray.Count; i++) {
									SaveState_toFile_out.AppendChild(
										((iClaSS)_someArray[i]).SaveState_toFile(
											xmlDoc_in, 
											_atts[a].Name
										)
									);
								}

								break;
							}
						} // }
					}
				}
			}

			return SaveState_toFile_out;
		}
		#endregion
		#region public override void LoadState_fromFile(XmlNode node_in);
		// ToDos: here! performance
		public override void LoadState_fromFile(XmlNode node_in) {
//			FieldInfo[] _fields = derived_ref_.GetType().GetFields(
//				BindingFlags.Public | 
//				BindingFlags.Instance | 
//				BindingFlags.NonPublic
//			);

			PropertyInfo[] _properties = derived_ref_.GetType().GetProperties(
				BindingFlags.Public | 
				BindingFlags.Instance | 
				BindingFlags.NonPublic
			);

			#region for (int a1 = 0; a1 < node_in.Attributes.Count; a1++);
			for (int a1 = 0; a1 < node_in.Attributes.Count; a1++) {
				for (int p = 0; p < _properties.Length; p++) {
					if (
						Attribute.IsDefined(
							_properties[p], 
							typeof(ClaSSPropertyAttribute)
						) // all properties that have ClaSSPropertyAttribute attribute defined
					) {
						ClaSSPropertyAttribute[] _atts = (ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
							_properties[p], 
							typeof(ClaSSPropertyAttribute)
						); // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined
						for (int a2 = 0; a2 < _atts.Length; a2++) {
							if (_atts[a2].Name == node_in.Attributes[a1].Name) {
								if (_atts[a2].Type == ClaSSPropertyAttribute.eType.standard) {
									_properties[p].SetValue(
										derived_ref_, 
										Convert.ChangeType(
											node_in.Attributes[a1].InnerText, 
											_properties[p].PropertyType
										), 
										null
									);
								}/* else if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate) {
									// ...
								} else if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate_collection) {
									// ...
								}*/

								break; // was found, no need to keep looking...
							}
						}
					}
				}
			}
			#endregion
			#region for (int c = 0; c < node_in.ChildNodes.Count; c++);
			for (int c = 0; c < node_in.ChildNodes.Count; c++) {
				for (int p = 0; p < _properties.Length; p++) {
					if (
						Attribute.IsDefined(
							_properties[p], 
							typeof(ClaSSPropertyAttribute)
						) // all properties that have ClaSSPropertyAttribute attribute defined
					) {
						ClaSSPropertyAttribute[] _atts = (ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
							_properties[p], 
							typeof(ClaSSPropertyAttribute)
						); // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined
						for (int a2 = 0; a2 < _atts.Length; a2++) {
							if (_atts[a2].Name == node_in.ChildNodes[c].Name) {
								/*if (_atts[a2].Type == ClaSSPropertyAttribute.eType.standard) {
									// ...
								} else*/ if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate) {
									((iClaSS)_properties[p].GetValue(derived_ref_, null)).LoadState_fromFile(
										node_in.ChildNodes[c]
									);
								} else if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate_collection) {
									int _newArray = ((ArrayList)_properties[p].GetValue(derived_ref_, null)).Add(
										derived_ref_.Property_new(node_in.ChildNodes[c].Name)
									);
									((iClaSS)((ArrayList)_properties[p].GetValue(derived_ref_, null))[_newArray]).LoadState_fromFile(
										node_in.ChildNodes[c]
									);
								}

								break; // was found, no need to keep looking...
							}
						}
					}
				}
			}
			#endregion
		}
		#endregion
		#endregion
	}
}