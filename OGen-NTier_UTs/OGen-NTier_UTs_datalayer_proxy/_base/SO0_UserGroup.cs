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
	#region public interface ISO_UserGroup;
	/// <summary>
	/// Interface for UserGroup SerializableObject.
	/// </summary>
	public interface ISO_UserGroup {
		/// <summary>
		/// Indicates if changes have been made to FO0_UserGroup properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// UserGroup's IDUser.
		/// </summary>
		long IDUser { get; set; }

		/// <summary>
		/// UserGroup's IDGroup.
		/// </summary>
		long IDGroup { get; set; }

		/// <summary>
		/// UserGroup's Relationdate.
		/// </summary>
		DateTime Relationdate { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at UserGroup's Relationdate.
		/// </summary>
		bool Relationdate_isNull { get; set; }

		/// <summary>
		/// UserGroup's Defaultrelation.
		/// </summary>
		bool Defaultrelation { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at UserGroup's Defaultrelation.
		/// </summary>
		bool Defaultrelation_isNull { get; set; }
	}
	#endregion

	/// <summary>
	/// UserGroup SerializableObject which provides fields access at UserGroup table at Database.
	/// </summary>
	[Serializable()]
	public class SO_UserGroup : ISO_UserGroup, ISerializable {
		#region public SO_UserGroup();
		public SO_UserGroup(
		) : this (
			0L, 
			0L, 
			new DateTime(1900, 1, 1), 
			false
		) {
		}
		public SO_UserGroup(
			long IDUser_in, 
			long IDGroup_in, 
			DateTime Relationdate_in, 
			bool Defaultrelation_in
		) {
			haschanges_ = false;

			iduser_ = IDUser_in;
			idgroup_ = IDGroup_in;
			relationdate_ = Relationdate_in;
			defaultrelation_ = Defaultrelation_in;
		}
		public SO_UserGroup(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			iduser_ = (long)info_in.GetValue("IDUser", typeof(long));
			idgroup_ = (long)info_in.GetValue("IDGroup", typeof(long));
			relationdate_ 
				= (info_in.GetValue("Relationdate", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Relationdate", typeof(DateTime));
			Relationdate_isNull = (bool)info_in.GetValue("Relationdate_isNull", typeof(bool));
			defaultrelation_ 
				= (info_in.GetValue("Defaultrelation", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("Defaultrelation", typeof(bool));
			Defaultrelation_isNull = (bool)info_in.GetValue("Defaultrelation_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_UserGroup properties since last time getObject method was run.
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
		#region public long IDUser { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long iduser_;// = 0L;
		
		/// <summary>
		/// UserGroup's IDUser.
		/// </summary>
		[XmlElement("IDUser")]
		[SoapElement("IDUser")]
		[DOPropertyAttribute(
			"IDUser", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"User", 
			"IDUser", 
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
		long IDUser {
			get {
				return iduser_;
			}
			set {
				if (
					(!value.Equals(iduser_))
				) {
					iduser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IDGroup { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idgroup_;// = 0L;
		
		/// <summary>
		/// UserGroup's IDGroup.
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
		#region public DateTime Relationdate { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public object relationdate_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// UserGroup's Relationdate.
		/// </summary>
		[XmlElement("Relationdate")]
		[SoapElement("Relationdate")]
		[DOPropertyAttribute(
			"Relationdate", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			false, 
			true, 
			false, 
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
		DateTime Relationdate {
			get {
				return (DateTime)((relationdate_ == null) ? new DateTime(1900, 1, 1) : relationdate_);
			}
			set {
				if (
					(!value.Equals(relationdate_))
				) {
					relationdate_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Relationdate_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at UserGroup's Relationdate.
		/// </summary>
		[XmlElement("Relationdate_isNull")]
		[SoapElement("Relationdate_isNull")]
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool Relationdate_isNull {
			get { return (relationdate_ == null); }
			set {
				//if (value) relationdate_ = null;

				if ((value) && (relationdate_ != null)) {
					relationdate_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Defaultrelation { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public object defaultrelation_;// = false;
		
		/// <summary>
		/// UserGroup's Defaultrelation.
		/// </summary>
		[XmlElement("Defaultrelation")]
		[SoapElement("Defaultrelation")]
		[DOPropertyAttribute(
			"Defaultrelation", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"", 
			"", 
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
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
		bool Defaultrelation {
			get {
				return (bool)((defaultrelation_ == null) ? false : defaultrelation_);
			}
			set {
				if (
					(!value.Equals(defaultrelation_))
				) {
					defaultrelation_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Defaultrelation_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at UserGroup's Defaultrelation.
		/// </summary>
		[XmlElement("Defaultrelation_isNull")]
		[SoapElement("Defaultrelation_isNull")]
		public 
#if !USE_PARTIAL_CLASSES || NET_1_1
			virtual 
#endif
		bool Defaultrelation_isNull {
			get { return (defaultrelation_ == null); }
			set {
				//if (value) defaultrelation_ = null;

				if ((value) && (defaultrelation_ != null)) {
					defaultrelation_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDUser", iduser_);
			info_in.AddValue("IDGroup", idgroup_);
			info_in.AddValue("Relationdate", relationdate_);
			info_in.AddValue("Relationdate_isNull", Relationdate_isNull);
			info_in.AddValue("Defaultrelation", defaultrelation_);
			info_in.AddValue("Defaultrelation_isNull", Defaultrelation_isNull);
		}
		#endregion
		#endregion
	}
}