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
	#region public interface ISO_Permition;
	/// <summary>
	/// Interface for Permition SerializableObject.
	/// </summary>
	public interface ISO_Permition {
		/// <summary>
		/// Indicates if changes have been made to FO0_Permition properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// Permition's IDPermition.
		/// </summary>
		long IDPermition { get; set; }

		/// <summary>
		/// Permition's Name.
		/// </summary>
		string Name { get; set; }
	}
	#endregion

	/// <summary>
	/// Permition SerializableObject which provides fields access at Permition table at Database.
	/// </summary>
	[Serializable()]
	public class SO_Permition : ISO_Permition, ISerializable {
		#region public SO_Permition();
		public SO_Permition(
		) : this (
			0L, 
			string.Empty
		) {
		}
		public SO_Permition(
			long IDPermition_in, 
			string Name_in
		) {
			haschanges_ = false;

			idpermition_ = IDPermition_in;
			name_ = Name_in;
		}
		public SO_Permition(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idpermition_ = (long)info_in.GetValue("IDPermition", typeof(long));
			name_ = (string)info_in.GetValue("Name", typeof(string));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Permition properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public 
#if NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public long IDPermition { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idpermition_;// = 0L;
		
		/// <summary>
		/// Permition's IDPermition.
		/// </summary>
		[XmlElement("IDPermition")]
		[SoapElement("IDPermition")]
		[DOPropertyAttribute(
			"IDPermition", 
			"", 
			"", 
			true, 
			true, 
			false, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
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
		long IDPermition {
			get {
				return idpermition_;
			}
			set {
				if (
					(!value.Equals(idpermition_))
				) {
					idpermition_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public string name_;// = string.Empty;
		
		/// <summary>
		/// Permition's Name.
		/// </summary>
		[XmlElement("Name")]
		[SoapElement("Name")]
		[DOPropertyAttribute(
			"Name", 
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
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDPermition", idpermition_);
			info_in.AddValue("Name", name_);
		}
		#endregion
		#endregion
	}
}