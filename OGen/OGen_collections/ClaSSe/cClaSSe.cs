#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

*/
#endregion
using System;
using System.Collections;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace OGen.lib.collections {
	public abstract class cClaSSe : cClaSS__base, iClaSSe {
		#region public cClaSSe(...);
		/// <summary>
		/// if you are inheriting from cClaSSe
		/// </summary>
		public cClaSSe(
			iClaSSe aggregateloopback_ref_in
		) {
			aggregateloopback_ref_ = aggregateloopback_ref_in;
			inheritloopback_ref_ = this;
		}

		/// <summary>
		/// if you are aggregating cClaSSe (use whenever inheritance not possible)
		/// </summary>
		public cClaSSe(
			iClaSSe aggregateloopback_ref_in, 
			iClaSSe inheritloopback_ref_in
		) {
			aggregateloopback_ref_ = aggregateloopback_ref_in;
			inheritloopback_ref_ = inheritloopback_ref_in;
		}
		#endregion
		#region static cClaSSe();
		static cClaSSe() {
			aggregate_collection_regex__ = null;
		}
		#endregion

		//===
		#region public static Regex aggregate_collection_regex { get; }
		private static Regex aggregate_collection_regex__;
		public static Regex aggregate_collection_regex {
			get {
				if (aggregate_collection_regex__ == null) {
					aggregate_collection_regex__ = new Regex(
						"^(?<name>\\w+)\\[(?<index>\\w+)\\]", //(?<whatever>.*)
						RegexOptions.Compiled // | RegexOptions.IgnoreCase
					);
				}
				return aggregate_collection_regex__;
			}
		}
		#endregion
		//===
		#region public string Path { get; }
		private string path_;
		public string Path {
			get { return path_; }
		}
		#endregion
		#region public void IterateThrough_fromRoot(string iteration_in, string test_in);
		public delegate void dIteration_found(string message_in);
		private dIteration_found runthrough_found_ = null;
		public void IterateThrough_fromRoot(
			string iteration_in, 
			dIteration_found iteration_found_in
		) {
			#region Exception IterateThrough_fromRoot_Exception = new Exception("...");
			Exception IterateThrough_fromRoot_Exception = new Exception(
				string.Format(
					"{0}.{1}.IterateThrough_fromRoot(): - something wrong with iteration: '{2}'", 
					this.GetType().Namespace, 
					this.GetType().Name, 
					iteration_in
				)
			);
			#endregion
			runthrough_found_ = iteration_found_in;

			int _dot = iteration_in.IndexOf(".");
			root().IterateThrough_fromHere(
				(_dot < 0) 
					? iteration_in
					: iteration_in.Substring(_dot + 1)
				, 
				"ROOT", 
				runthrough_found_
			);
		}
		#endregion
//		#region public void IterateThrough_fromHere(string iteration_in, string test_in, string path_in);
		public void IterateThrough_fromHere(
			string iteration_in, 
			string path_in, 
			dIteration_found iteration_found_in
		) {
			#region Exception IterateThrough_fromHere_Exception = new Exception("...");
			Exception IterateThrough_fromHere_Exception = new Exception(
				string.Format(
					"{0}.{1}.IterateThrough_fromHere(): - something wrong with iteration: '{2}'", 
					this.GetType().Namespace, 
					this.GetType().Name, 
					iteration_in
				)
			);
			#endregion
			path_ = path_in;

//Console.WriteLine(
//	"ENTRADA : {0}*{1} : {2}", 
//	Path, 
//	iteration_in, 
//	test_in
//);


if (iteration_in == "ROOT") {
	if (iteration_found_in != null) iteration_found_in(iteration_in);
	return;
}


			string[] _iteration = iteration_in.Split('.');
			string _iteration_name;
			bool _iteration_hasIndex;
			#region string _iteration_next = ...;
			int _dot = iteration_in.IndexOf(".");
			string _iteration_next = (_dot >= 0) 
				? iteration_in.Substring(_dot + 1) 
				: string.Empty;
			#endregion

			Match match = aggregate_collection_regex.Match(_iteration[0]);
			if (match.Success) {
				_iteration_name = match.Groups["name"].Value;
				_iteration_hasIndex = true; // int.Parse(match.Groups["index"].Value);
			} else {
				_iteration_name = _iteration[0];
				_iteration_hasIndex = false;
			}

			int _property_index = PropertyIndex_find(_iteration_name);
			if (_property_index != -1) {
				switch (Attributes[_property_index].Type) {
					case ClaSSPropertyAttribute.eType.aggregate: {
						if (_iteration_hasIndex) throw IterateThrough_fromHere_Exception;

						if (_iteration_next != string.Empty) {
							((iClaSSe)
								Properties[_property_index].GetValue(this, null)
							).IterateThrough_fromHere(
								_iteration_next, 
								Path + "." + _iteration_name, 
								iteration_found_in
							);
						} else {

// ToDos: here!

						}

						break;
					}
					case ClaSSPropertyAttribute.eType.aggregate_collection: {
						if (!_iteration_hasIndex) throw IterateThrough_fromHere_Exception;

						ArrayList _aggregate_collection 
							= (ArrayList)Properties[_property_index].GetValue(this, null);
						for (int a = 0; a < _aggregate_collection.Count; a++) {
							if (_iteration_next != string.Empty) {
								((iClaSSe)
									_aggregate_collection[a]
								).IterateThrough_fromHere(
									_iteration_next, 
									Path + "." + _iteration_name + "[" + a + "]", 
									iteration_found_in
								);
							} else {

// ToDos: here!
string _doit = string.Format(
	"{0}.{1}[{2}]", 
	Path, 
	_iteration_name, 
	a
);
if (iteration_found_in != null) iteration_found_in(_doit);
//Console.WriteLine(
//	"DOIT: {0}", 
//	_doit
//);


							}
						}

						break;
					}
					case ClaSSPropertyAttribute.eType.standard:
					default: {
						throw IterateThrough_fromHere_Exception;
					}
				}
			} else {
				throw IterateThrough_fromHere_Exception;
			}
		}
//		#endregion
		//===
		#region public iClaSSe root();
		public iClaSSe root() {
			iClaSSe root_out = this;

			while (root_out.AggregateLoopback_ref != null)
				root_out = root_out.AggregateLoopback_ref;

			return root_out;
		}
		#endregion
		#region public string Read_fromRoot(string what_in);
		public string Read_fromRoot(string what_in) {
			//return root().Read_fromHere(what_in); // oldstuff
			return root().Read_fromHere(
				what_in.Substring(
					what_in.IndexOf(".") + 1
				)
			);
		}
		#endregion
		#region public string Read_fromHere(string what_in);
		public string Read_fromHere(string what_in) {
			#region Exception Read_fromHere_Exception = new Exception("...");
			Exception Read_fromHere_Exception = new Exception(
				string.Format(
					"{0}.{1}.Read_fromHere(): - can't read: '{2}'", 
					this.GetType().Namespace, 
					this.GetType().Name, 
					what_in
				)
			);
			#endregion

			// ToDos: here! consider using regular expressions instead...
			string[] _whatSplit = what_in.Split('.');
			switch (_whatSplit.Length) {
				case 0: {
					//throw Read_fromHere_Exception;
					return null;
				}
				case 1: {
					#region return ...;
					switch (Property_type(_whatSplit[0])) {
						case ClaSSPropertyAttribute.eType.standard: {
							return (string)Property_get(
								_whatSplit[0], 
								ClaSSPropertyAttribute.eType.standard
							);
						}
						default: {
							return null;
						}
					}
					#endregion
				}
				default: {
					#region return ...;
					#region string _name = ...(_whatSplit[0]);
					string _name;
					int _end = _whatSplit[0].IndexOf("[");
					if (_end >= 0) {
						_name = _whatSplit[0].Substring(0, _end);
					} else {
						_name = _whatSplit[0];
					}
					#endregion

					switch (Property_type(_name)) {
						case ClaSSPropertyAttribute.eType.standard: {
							return (string)Property_get(
								_name, 
								ClaSSPropertyAttribute.eType.standard
							);
						}
						case ClaSSPropertyAttribute.eType.aggregate: {
							#region return ...;
							if (_end >= 0) throw Read_fromHere_Exception;
							return 
								((cClaSSe)Property_get(
									_name, 
									ClaSSPropertyAttribute.eType.aggregate
								)).Read_fromHere(
									what_in.Substring(
										what_in.IndexOf(
											"."//, 
											//what_in.IndexOf(".") + 1
										) + 1
									)
								);
							#endregion
						}
						case ClaSSPropertyAttribute.eType.aggregate_collection: {
							#region return ...;
							if (_end < 0) throw Read_fromHere_Exception;
							int _endForReal = _whatSplit[0].IndexOf("]");
							int _index = int.Parse(_whatSplit[0].Substring(
								_end + 1, 
								_endForReal - (_end + 1)
							));

							return 
								((cClaSSe)(
									((ArrayList)Property_get(
										_name, 
										ClaSSPropertyAttribute.eType.aggregate_collection
									))[_index]
								)).Read_fromHere(
									what_in.Substring(
										what_in.IndexOf(
											"."//, 
											//what_in.IndexOf(".") + 1
										) + 1
									)
								);
							#endregion
						}
						default: {
							return null;
						}
					}
					#endregion
				}
			}

			//return what_in;
		}
		#endregion
		//===
		#region protected void InitializeStaticFields(...);
		protected void InitializeStaticFields(
			ref PropertyInfo[] properties_in, 
			ref ClaSSPropertyAttribute[] attributes_in
		) {
			PropertyInfo[] _properties = inheritloopback_ref_.GetType().GetProperties(
				BindingFlags.Public | 
				BindingFlags.Instance | 
				BindingFlags.NonPublic
			);
			int _c = 0;
			for (int p = 0; p < _properties.Length; p++) {
				if (
					Attribute.IsDefined(
						_properties[p], 
						typeof(ClaSSPropertyAttribute)
					) // all properties that have ClaSSPropertyAttribute attribute defined
				) {
					_c++;
				}
			}
			PropertyInfo[] _properties2 = new PropertyInfo[_c];
			ClaSSPropertyAttribute[] _attribute2 = new ClaSSPropertyAttribute[_c];

			_c = 0;
			for (int p = 0; p < _properties.Length; p++) {
				if (
					Attribute.IsDefined(
						_properties[p], 
						typeof(ClaSSPropertyAttribute) // all properties that have ClaSSPropertyAttribute attribute defined
					)
				) {
					_properties2[_c] = _properties[p];
					_attribute2[_c] = ((ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
						_properties[p], 
						typeof(ClaSSPropertyAttribute) // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined
					))[0];
					_c++;
				}
			}

			// thread safe(r):
			properties_in = _properties2;
			attributes_in = _attribute2;
		}
		#endregion
		public abstract PropertyInfo[] Properties { get; }
		public abstract ClaSSPropertyAttribute[] Attributes { get; }
		//---
		#region public object Property_get(string name_in, ClaSSPropertyAttribute.eType type_in);
		public object Property_get(string name_in, ClaSSPropertyAttribute.eType type_in) {
			PropertyInfo _property = Property_find(name_in, type_in);
			if (_property == null) {
				return null;
			} else {
				return _property.GetValue(this, null);
			}
		}
		#endregion
		#region public ClaSSPropertyAttribute Property_attribute(string name_in);
		public ClaSSPropertyAttribute Property_attribute(string name_in) {
			int _index = PropertyIndex_find(name_in);
			return (_index != -1) ? Attributes[_index] : null;
		}
		#endregion
		#region public ClaSSPropertyAttribute.eType Property_type(string name_in);
		public ClaSSPropertyAttribute.eType Property_type(string name_in) {
			int _index = PropertyIndex_find(name_in);
			return (_index != -1) 
				? Attributes[_index].Type 
				: ClaSSPropertyAttribute.eType.invalid;
		}
		#endregion
		#region public int PropertyIndex_find(string name_in);
		public int PropertyIndex_find(string name_in) {
			for (int a = 0; a < Attributes.Length; a++) {
				if (
					(Attributes[a].Name == name_in)
				) {
					return a;
				}
			}

			return -1;
		}
		#endregion
		#region public PropertyInfo Property_find(string name_in);
		public PropertyInfo Property_find(string name_in) {
			int _index = PropertyIndex_find(name_in);
			return (_index != -1) ? Properties[_index] : null;
		}
		#endregion
		#region public int PropertyIndex_find(string name_in, ClaSSPropertyAttribute.eType type_in);
		public int PropertyIndex_find(string name_in, ClaSSPropertyAttribute.eType type_in) {
			for (int a = 0; a < Attributes.Length; a++) {
				if (
					(Attributes[a].Name == name_in)
					&&
					(Attributes[a].Type == type_in)
				) {
					return a;
				}
			}

			return -1;
		}
		#endregion
		#region public PropertyInfo Property_find(string name_in, ClaSSPropertyAttribute.eType type_in);
		public PropertyInfo Property_find(string name_in, ClaSSPropertyAttribute.eType type_in) {
			int _index = PropertyIndex_find(name_in, type_in);
			return (_index != -1) ? Properties[_index] : null;
		}
		#endregion
		//===

		#region public Properties...
		#region public iClaSSe InheritLoopback_ref { get; }
		private iClaSSe inheritloopback_ref_;
		public iClaSSe InheritLoopback_ref {
			get { return inheritloopback_ref_; }
		}
		#endregion
		#region public iClaSSe AggregateLoopback_ref { get; }
		private iClaSSe aggregateloopback_ref_;
		public iClaSSe AggregateLoopback_ref {
			get { return aggregateloopback_ref_; }
		}
		#endregion
		#endregion

//		#region public Methods...
//		#region public override XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in);
		public override XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in) {
			XmlElement SaveState_toFile_out = xmlDoc_in.CreateElement(
				name_in
			);

// ToDos: here! testing...
//if (xmlText != string.Empty)
//	SaveState_toFile_out.AppendChild(
//		xmlDoc_in.CreateTextNode(xmlText)
//	);

			#region for (int p = 0; p < Properties.Length; p++);
			for (int p = 0; p < Properties.Length; p++) {
				if (Attributes[p].SynchronizeState) {
					switch (Attributes[p].Type) {
						case ClaSSPropertyAttribute.eType.standard: {
							SaveState_toFile_out.SetAttributeNode(xmlDoc_in.CreateAttribute(
								Attributes[p].Name
							));
							SaveState_toFile_out.Attributes[
								Attributes[p].Name
							].Value = 
								(string)Properties[p].GetValue(inheritloopback_ref_, null);
							break;
						}
						case ClaSSPropertyAttribute.eType.aggregate: {
							SaveState_toFile_out.AppendChild(
								((iClaSSe)Properties[p].GetValue(inheritloopback_ref_, null)).SaveState_toFile(
									xmlDoc_in, 
									Attributes[p].Name
								)
							);
							break;
						}
						case ClaSSPropertyAttribute.eType.aggregate_collection: {
							ArrayList _someArray = (ArrayList)Properties[p].GetValue(inheritloopback_ref_, null);
							for (int i = 0; i < _someArray.Count; i++) {
								SaveState_toFile_out.AppendChild(
									((iClaSSe)_someArray[i]).SaveState_toFile(
										xmlDoc_in, 
										Attributes[p].Name
									)
								);
							}
							break;
						}
					}
				}
			}
			#endregion

			return SaveState_toFile_out;
		}
//		#endregion

//#region protected string xmlText { get; set; }
private string xmltext_;
/// <summary>
/// ToDos: here! testing...
/// </summary>
protected string xmlText {
	get { return xmltext_; }
	set { xmltext_ = value; }
}
//#endregion

//		#region public override void LoadState_fromFile(XmlNode node_in);
		public override void LoadState_fromFile(XmlNode node_in) {
			#region for (int xmlAttrib = 0; xmlAttrib < node_in.Attributes.Count; xmlAttrib++);
			for (int xmlAttrib = 0; xmlAttrib < node_in.Attributes.Count; xmlAttrib++) {
				for (int p = 0; p < Properties.Length; p++) {
					if (
						(Attributes[p].SynchronizeState)
						&&
						(Attributes[p].Type == ClaSSPropertyAttribute.eType.standard)
					) {
						if (Attributes[p].Name == node_in.Attributes[xmlAttrib].Name) {
							Properties[p].SetValue(
								inheritloopback_ref_, 
								Convert.ChangeType(
									node_in.Attributes[xmlAttrib].InnerText, 
									Properties[p].PropertyType
								), 
								null
							);

							break; // was found, no need to keep looking...
						}
					}
				}
			}
			#endregion
//			#region for (int xmlCNode = 0; xmlCNode < node_in.ChildNodes.Count; xmlCNode++);
			for (int xmlCNode = 0; xmlCNode < node_in.ChildNodes.Count; xmlCNode++) {

// ToDos: here! testing...
// this is most likely going to be a problem for cross platform
// build unit tests for this one, so it can easily be tracked
if (node_in.ChildNodes[xmlCNode].LocalName.ToLower() == "#text") {
	xmlText = node_in.ChildNodes[xmlCNode].InnerText;
//	Console.WriteLine(
//		"<{0}>{1}</{0}>", 
//		node_in.ChildNodes[xmlCNode].LocalName, 
//		node_in.ChildNodes[xmlCNode].InnerText
//	);
}

				for (int p = 0; p < Properties.Length; p++) {
					if (
						(Attributes[p].SynchronizeState)
						&&
						(Attributes[p].Name == node_in.ChildNodes[xmlCNode].Name)
					) {
						switch (Attributes[p].Type) {
							case ClaSSPropertyAttribute.eType.aggregate: {
								((iClaSSe)Properties[p].GetValue(inheritloopback_ref_, null)).LoadState_fromFile(
									node_in.ChildNodes[xmlCNode]
								);
								break;
							}
							case ClaSSPropertyAttribute.eType.aggregate_collection: {
								int _newArray = ((ArrayList)Properties[p].GetValue(inheritloopback_ref_, null)).Add(
									inheritloopback_ref_.Property_new(node_in.ChildNodes[xmlCNode].Name)
								);
								((iClaSSe)((ArrayList)Properties[p].GetValue(inheritloopback_ref_, null))[_newArray]).LoadState_fromFile(
									node_in.ChildNodes[xmlCNode]
								);
								break;
							}
						}

						break; // was found, no need to keep looking...
					}
				}
			}
//			#endregion
		}
//		#endregion
//		#endregion
	}
}
#region // oldstuff...
//---------------------------------------------------------------------------
//		public override void LoadState_fromFile(XmlNode node_in) {
//			#region // oldstuff...
//			//			PropertyInfo[] _properties = inheritloopback_ref_.GetType().GetProperties(
//			//				BindingFlags.Public | 
//			//				BindingFlags.Instance | 
//			//				BindingFlags.NonPublic
//			//			);
//			#region //for (int xmlAttrib = 0; xmlAttrib < node_in.Attributes.Count; xmlAttrib++);
//			//			for (int xmlAttrib = 0; xmlAttrib < node_in.Attributes.Count; xmlAttrib++) {
//			//				for (int p = 0; p < _properties.Length; p++) {
//			//					if (
//			//						Attribute.IsDefined(
//			//							_properties[p], 
//			//							typeof(ClaSSPropertyAttribute)
//			//						) // all properties that have ClaSSPropertyAttribute attribute defined
//			//					) {
//			//						ClaSSPropertyAttribute[] _atts = (ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
//			//							_properties[p], 
//			//							typeof(ClaSSPropertyAttribute)
//			//						); // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined
//			//						for (int a2 = 0; a2 < _atts.Length; a2++) {
//			//							if (_atts[a2].Name == node_in.Attributes[xmlAttrib].Name) {
//			//								if (_atts[a2].Type == ClaSSPropertyAttribute.eType.standard) {
//			//									_properties[p].SetValue(
//			//										inheritloopback_ref_, 
//			//										Convert.ChangeType(
//			//											node_in.Attributes[xmlAttrib].InnerText, 
//			//											_properties[p].PropertyType
//			//										), 
//			//										null
//			//									);
//			//								}/* else if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate) {
//			//									// ...
//			//								} else if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate_collection) {
//			//									// ...
//			//								}*/
//			//
//			//								break; // was found, no need to keep looking...
//			//							}
//			//						}
//			//					}
//			//				}
//			//			}
//			#endregion
//			#region //for (int xmlCNode = 0; xmlCNode < node_in.ChildNodes.Count; xmlCNode++);
//			//			for (int xmlCNode = 0; xmlCNode < node_in.ChildNodes.Count; xmlCNode++) {
//			//				for (int p = 0; p < _properties.Length; p++) {
//			//					if (
//			//						Attribute.IsDefined(
//			//							_properties[p], 
//			//							typeof(ClaSSPropertyAttribute)
//			//						) // all properties that have ClaSSPropertyAttribute attribute defined
//			//					) {
//			//						ClaSSPropertyAttribute[] _atts = (ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
//			//							_properties[p], 
//			//							typeof(ClaSSPropertyAttribute)
//			//						); // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined
//			//						for (int a2 = 0; a2 < _atts.Length; a2++) {
//			//							if (_atts[a2].Name == node_in.ChildNodes[xmlCNode].Name) {
//			//								/*if (_atts[a2].Type == ClaSSPropertyAttribute.eType.standard) {
//			//									// ...
//			//								} else*/ if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate) {
//			//									((iClaSSe)_properties[p].GetValue(inheritloopback_ref_, null)).LoadState_fromFile(
//			//										node_in.ChildNodes[xmlCNode]
//			//									);
//			//								} else if (_atts[a2].Type == ClaSSPropertyAttribute.eType.aggregate_collection) {
//			//									int _newArray = ((ArrayList)_properties[p].GetValue(inheritloopback_ref_, null)).Add(
//			//										inheritloopback_ref_.Property_new(node_in.ChildNodes[xmlCNode].Name)
//			//									);
//			//
//			//// ToDos: here! works, but doesn't look good!
//			////((iClaSSe)((ArrayList)_properties[p].GetValue(inheritloopback_ref_, null))[_newArray]).XMLName 
//			////	= node_in.ChildNodes[xmlCNode].Name + "[" + _newArray + "]";
//			//
//			//									((iClaSSe)((ArrayList)_properties[p].GetValue(inheritloopback_ref_, null))[_newArray]).LoadState_fromFile(
//			//										node_in.ChildNodes[xmlCNode]
//			//									);
//			//								}
//			//
//			//								break; // was found, no need to keep looking...
//			//							}
//			//						}
//			//					}
//			//				}
//			//			}
//			#endregion
//			#endregion
//		}
//---------------------------------------------------------------------------
//		public override XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in) {
//			XmlElement SaveState_toFile_out = xmlDoc_in.CreateElement(
//				name_in
//			);
//
//			PropertyInfo[] _properties = inheritloopback_ref_.GetType().GetProperties(
//				BindingFlags.Public | 
//				BindingFlags.Instance | 
//				BindingFlags.NonPublic
//			);
//			for (int p = 0; p < _properties.Length; p++) {
//				if (
//					Attribute.IsDefined(
//						_properties[p], 
//						typeof(ClaSSPropertyAttribute)
//					) // all properties that have ClaSSPropertyAttribute attribute defined
//				) {
//					ClaSSPropertyAttribute[] _atts = (ClaSSPropertyAttribute[])Attribute.GetCustomAttributes(
//						_properties[p], 
//						typeof(ClaSSPropertyAttribute)
//					); // only ClaSSPropertyAttribute attributes, note that propertie can have more than one attribute defined
//
//					for (int a = 0; a < _atts.Length; a++) { // if (_atts[a].GetType() == typeof(ClaSSPropertyAttribute)) {
//						switch (_atts[a].Type) {
//							case ClaSSPropertyAttribute.eType.standard: {
//								SaveState_toFile_out.SetAttributeNode(xmlDoc_in.CreateAttribute(
//									_atts[a].Name
//								));
//								SaveState_toFile_out.Attributes[
//									_atts[a].Name
//								].Value = 
//									(string)_properties[p].GetValue(inheritloopback_ref_, null);
//
//								break;
//							}
//							case ClaSSPropertyAttribute.eType.aggregate: {
//								SaveState_toFile_out.AppendChild(
//									((iClaSSe)_properties[p].GetValue(inheritloopback_ref_, null)).SaveState_toFile(
//										xmlDoc_in, 
//										_atts[a].Name
//									)
//								);
//
//								break;
//							}
//							case ClaSSPropertyAttribute.eType.aggregate_collection: {
//								ArrayList _someArray = (ArrayList)_properties[p].GetValue(inheritloopback_ref_, null);
//								for (int i = 0; i < _someArray.Count; i++) {
//									SaveState_toFile_out.AppendChild(
//										((iClaSSe)_someArray[i]).SaveState_toFile(
//											xmlDoc_in, 
//											_atts[a].Name
//										)
//									);
//								}
//
//								break;
//							}
//						} // }
//					}
//				}
//			}
//			#endregion
//
//			return SaveState_toFile_out;
//		}
//---------------------------------------------------------------------------
//		public abstract string XMLName { get; set; }
//		#region public string XMLPath { get; }
//		public string XMLPath {
//			get {
//				return (AggregateLoopback_ref == null) 
//					? XMLName 
//					: AggregateLoopback_ref.XMLPath + "." + XMLName;
//			}
//		}
//		#endregion
//---------------------------------------------------------------------------
//		private cProperty_standard property_standard__;
//		public cProperty_standard Property_standard {
//			get {
//				if (property_standard__ == null) {
//					property_standard__ = new cProperty_standard();
//
//					PropertyInfo[] _properties = inheritloopback_ref_.GetType().GetProperties(
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
//											(string)_properties[p].GetValue(inheritloopback_ref_, null)
//										);
//										break;
//									}
////									case ClaSSPropertyAttribute.eType.aggregate: {
////										SaveState_toFile_out.AppendChild(
////											((iClaSSe)_properties[p].GetValue(inheritloopback_ref_, null)).SaveState_toFile(
////												xmlDoc_in, 
////												((ClaSSPropertyAttribute)_atts[a]).Name
////											)
////										);
////
////										break;
////									}
////									case ClaSSPropertyAttribute.eType.aggregate_collection: {
////										ArrayList _someArray = (ArrayList)_properties[p].GetValue(inheritloopback_ref_, null);
////										for (int i = 0; i < _someArray.Count; i++) {
////											SaveState_toFile_out.AppendChild(
////												((iClaSSe)_someArray[i]).SaveState_toFile(
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
//---------------------------------------------------------------------------
#endregion
