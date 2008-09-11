#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// Config SerializableObject which provides fields access at Config table at Database.
	/// </summary>
	public class SO0_Config {
		#region public SO0_Config();
		public SO0_Config(
		) : this (
			string.Empty, 
			string.Empty, 
			0, 
			string.Empty
		) {
		}
		public SO0_Config(
			string Name_in, 
			string Config_in, 
			int Type_in, 
			string Description_in
		) {
			haschanges_ = false;
			//---
			name_ = Name_in;
			config_ = Config_in;
			type_ = Type_in;
			description_ = Description_in;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		internal bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Config properties since last time getObject method was run.
		/// </summary>
		public 
#if NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public string Name { get; set; }
		internal string name_;// = string.Empty;
		
		/// <summary>
		/// Config's Name.
		/// </summary>
		[XmlElement("Name")]
		[DOPropertyAttribute(
			"Name", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"", 
			"", 
			true, 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			50, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Name {
			get {
				return name_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(name_))
				) {
					name_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Config { get; set; }
		internal string config_;// = string.Empty;
		
		/// <summary>
		/// Config's Config.
		/// </summary>
		[XmlElement("Config")]
		[DOPropertyAttribute(
			"Config", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			true, 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			50, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Config {
			get {
				return config_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(config_))
				) {
					config_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int Type { get; set; }
		internal int type_;// = 0;
		
		/// <summary>
		/// Config's Type.
		/// </summary>
		[XmlElement("Type")]
		[DOPropertyAttribute(
			"Type", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			true, 
			false, 
			false, 
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		int Type {
			get {
				return type_;
			}
			set {
				if (
					(!value.Equals(type_))
				) {
					type_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Description { get; set; }
		internal string description_;// = string.Empty;
		
		/// <summary>
		/// Config's Description.
		/// </summary>
		[XmlElement("Description")]
		[DOPropertyAttribute(
			"Description", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			50, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		string Description {
			get {
				return description_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(description_))
				) {
					description_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion
	}
}