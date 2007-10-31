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

namespace OGen.lib.collections {
	/// <remarks>
	/// - never tried aggregating, argument passed in constructor (for that case) should inmplement part of iClaSS_noR, some things need to be done
	/// </remarks>
	public abstract class cClaSS_noR : cClaSS__base, iClaSS_noR {
		#region public cClaSS_noR(...);
		/// <summary>
		/// if you are aggregating cClaSS
		/// </summary>
		public cClaSS_noR(cClaSS_noR derived_ref_in) {
			derived_ref_ = derived_ref_in;
			startUp();
		}

		/// <summary>
		/// if you are inheriting from cClaSS
		/// </summary>
		protected cClaSS_noR() {
			derived_ref_ = this;
			startUp();
		}

		private void startUp() {
			property_standard_ = new cProperty_standard();
			property_aggregate_ = new cProperty_aggregate();
			property_aggregate_collection_ = new cProperty_aggregate_collection();
		}
		#endregion

		#region private Properties...
		private cClaSS_noR derived_ref_;
		#endregion
		#region public Properties...
		#region public cProperty_standard Property_standard { get; }
		private cProperty_standard property_standard_;
		public cProperty_standard Property_standard {
			get { return property_standard_; }
		}
		#endregion
		#region public cProperty_aggregate Property_aggregate { get; }
		private cProperty_aggregate property_aggregate_;
		public cProperty_aggregate Property_aggregate {
			get { return property_aggregate_; }
		}
		#endregion
		#region public cProperty_aggregate_collection Property_aggregate_collection { get; }
		private cProperty_aggregate_collection property_aggregate_collection_;
		public cProperty_aggregate_collection Property_aggregate_collection {
			get { return property_aggregate_collection_; }
		}
		#endregion
		#endregion

		#region public Methods...






//		public string Property_standard_get(string name_in) {
//			return (string)property_standard_[name_in];
//		}
//		public void Property_standard_set(string name_in, string value_in) {
//			property_standard_[name_in] = value_in;
//		}
//
//		public iClaSS Property_aggregate_get(string name_in) {
//			return (iClaSS)property_aggregate_[name_in];
//		}
//		public void Property_aggregate_set(string name_in, iClaSS value_in) {
//			property_aggregate_[name_in] = value_in;
//		}
//
//		public ArrayList Property_aggregate_collection_get(string name_in) {
//			return (ArrayList)property_aggregate_collection_[name_in];
//		}
//		public void Property_aggregate_collection_set(string name_in, ArrayList value_in) {
//			property_aggregate_collection_[name_in] = value_in;
//		}







		#region public XmlElement SaveState_toFile(...);
		public override XmlElement SaveState_toFile(XmlDocument xmlDoc_in, string name_in) {
			XmlElement SaveState_toFile_out = xmlDoc_in.CreateElement(name_in);

			for (int i = 0; i < property_standard_.Count; i++) {
				SaveState_toFile_out.SetAttributeNode(xmlDoc_in.CreateAttribute(
					property_standard_.Keys[i]
				));
				SaveState_toFile_out.Attributes[
					property_standard_.Keys[i]
				].Value = 
					(string)property_standard_[i];
			}

			for (int i = 0; i < property_aggregate_.Count; i++) {
				SaveState_toFile_out.AppendChild(
					((cClaSS_noR)property_aggregate_[i]).SaveState_toFile(
						xmlDoc_in, 
						property_aggregate_.Keys[i]
					)
				);
			}

			for (int i = 0; i < property_aggregate_collection_.Count; i++) {
				ArrayList _someArray = (ArrayList)property_aggregate_collection_[i];
				if (_someArray.Count > 0) {
					for (int a = 0; a < _someArray.Count; a++) {
						SaveState_toFile_out.AppendChild(
							((cClaSS_noR)_someArray[a]).SaveState_toFile(
								xmlDoc_in, 
								property_aggregate_collection_.Keys[i]
							)
						);
					}
				}
			}

			return SaveState_toFile_out;
		}
		#endregion
		#region public void LoadState_fromFile(...);
		public override void LoadState_fromFile(XmlNode node_in) {
			for (int a = 0; a < node_in.Attributes.Count; a++) {
				derived_ref_.property_standard_[
					node_in.Attributes[a].Name
				] = 
					node_in.Attributes[a].InnerText
				;
			}

			ArrayList _arraylist;
			for (int c = 0; c < node_in.ChildNodes.Count; c++) {
				for (int i = 0; i < property_aggregate_collection_.Count; i++) {
					if (property_aggregate_collection_.Keys[i] == node_in.ChildNodes[c].Name) {
						_arraylist = (ArrayList)property_aggregate_collection_[node_in.ChildNodes[c].Name];

						int _newItem = _arraylist.Add(
							Property_new(node_in.ChildNodes[c].Name)
						);
						((cClaSS_noR)_arraylist[_newItem]).LoadState_fromFile(
							node_in.ChildNodes[c]
						);
					}
				}
			}

			for (int c = 0; c < node_in.ChildNodes.Count; c++) {
				for (int i = 0; i < property_aggregate_.Count; i++) {
					if (property_aggregate_.Keys[i] == node_in.ChildNodes[c].Name) {
						((cClaSS_noR)property_aggregate_[node_in.ChildNodes[c].Name]).LoadState_fromFile(
							node_in.ChildNodes[c]
						);
					}
				}
			}
		}
		#endregion
		#endregion
	}
}