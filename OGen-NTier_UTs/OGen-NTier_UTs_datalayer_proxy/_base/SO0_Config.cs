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
using System.Runtime.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.proxy {
	#region public interface ISO_Config;
	/// <summary>
	/// Interface for Config SerializableObject.
	/// </summary>
	public interface ISO_Config {
		/// <summary>
		/// Indicates if changes have been made to FO0_Config properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// Config's Name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Config's Config.
		/// </summary>
		string Config { get; set; }

		/// <summary>
		/// Config's Type.
		/// </summary>
		int Type { get; set; }

		/// <summary>
		/// Config's Description.
		/// </summary>
		string Description { get; set; }
	}
	#endregion

	/// <summary>
	/// Config SerializableObject which provides fields access at Config table at Database.
	/// </summary>
	[Serializable()]
	public class SO_Config : ISO_Config, ISerializable {
		#region public SO_Config();
		public SO_Config(
		) : this (
			string.Empty, 
			string.Empty, 
			0, 
			string.Empty
		) {
		}
		public SO_Config(
			string Name_in, 
			string Config_in, 
			int Type_in, 
			string Description_in
		) {
			haschanges_ = false;

			name_ = Name_in;
			config_ = Config_in;
			type_ = Type_in;
			description_ = Description_in;
		}
		public SO_Config(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			name_ = (string)info_in.GetValue("Name", typeof(string));
			config_ = (string)info_in.GetValue("Config", typeof(string));
			type_ = (int)info_in.GetValue("Type", typeof(int));
			description_ = (string)info_in.GetValue("Description", typeof(string));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Config properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public string Name { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public string name_;// = string.Empty;
		
		/// <summary>
		/// Config's Name.
		/// </summary>
		[XmlElement("Name")]
		[SoapElement("Name")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
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
		[XmlIgnore()]
		[SoapIgnore()]
		public string config_;// = string.Empty;
		
		/// <summary>
		/// Config's Config.
		/// </summary>
		[XmlElement("Config")]
		[SoapElement("Config")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
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
		[XmlIgnore()]
		[SoapIgnore()]
		public int type_;// = 0;
		
		/// <summary>
		/// Config's Type.
		/// </summary>
		[XmlElement("Type")]
		[SoapElement("Type")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
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
		[XmlIgnore()]
		[SoapIgnore()]
		public string description_;// = string.Empty;
		
		/// <summary>
		/// Config's Description.
		/// </summary>
		[XmlElement("Description")]
		[SoapElement("Description")]
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
#if !USE_PARTIAL_CLASSES || NET_1_1
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

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("Name", name_);
			info_in.AddValue("Config", config_);
			info_in.AddValue("Type", type_);
			info_in.AddValue("Description", description_);
		}
		#endregion
		#endregion
	}
}