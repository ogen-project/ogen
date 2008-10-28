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
	#region public interface ISO_GroupPermition;
	/// <summary>
	/// Interface for GroupPermition SerializableObject.
	/// </summary>
	public interface ISO_GroupPermition {
		/// <summary>
		/// Indicates if changes have been made to FO0_GroupPermition properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// GroupPermition's IDGroup.
		/// </summary>
		long IDGroup { get; set; }

		/// <summary>
		/// GroupPermition's IDPermition.
		/// </summary>
		long IDPermition { get; set; }
	}
	#endregion

	/// <summary>
	/// GroupPermition SerializableObject which provides fields access at GroupPermition table at Database.
	/// </summary>
	[Serializable()]
	public class SO_GroupPermition : ISO_GroupPermition, ISerializable {
		#region public SO_GroupPermition();
		public SO_GroupPermition(
		) : this (
			0L, 
			0L
		) {
		}
		public SO_GroupPermition(
			long IDGroup_in, 
			long IDPermition_in
		) {
			haschanges_ = false;

			idgroup_ = IDGroup_in;
			idpermition_ = IDPermition_in;
		}
		public SO_GroupPermition(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idgroup_ = (long)info_in.GetValue("IDGroup", typeof(long));
			idpermition_ = (long)info_in.GetValue("IDPermition", typeof(long));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_GroupPermition properties since last time getObject method was run.
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
		#region public long IDGroup { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idgroup_;// = 0L;
		
		/// <summary>
		/// GroupPermition's IDGroup.
		/// </summary>
		[XmlElement("IDGroup")]
		[SoapElement("IDGroup")]
		[DOPropertyAttribute(
			"IDGroup", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"Group", 
			"IDGroup", 
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
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		long IDGroup {
			get {
				return idgroup_;
			}
			set {
				if (
					(!value.Equals(idgroup_))
				) {
					idgroup_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDPermition { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idpermition_;// = 0L;
		
		/// <summary>
		/// GroupPermition's IDPermition.
		/// </summary>
		[XmlElement("IDPermition")]
		[SoapElement("IDPermition")]
		[DOPropertyAttribute(
			"IDPermition", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"Permition", 
			"IDPermition", 
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
#if !USE_PARTIAL_CLASSES || NET_1_1
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
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDGroup", idgroup_);
			info_in.AddValue("IDPermition", idpermition_);
		}
		#endregion
		#endregion
	}
}