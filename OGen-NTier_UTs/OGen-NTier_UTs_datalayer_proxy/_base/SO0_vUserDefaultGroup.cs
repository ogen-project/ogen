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
	#region public interface ISO_vUserDefaultGroup;
	/// <summary>
	/// Interface for vUserDefaultGroup SerializableObject.
	/// </summary>
	public interface ISO_vUserDefaultGroup {
		/// <summary>
		/// Indicates if changes have been made to FO0_vUserDefaultGroup properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// vUserDefaultGroup's IDUser.
		/// </summary>
		long IDUser { get; set; }

		/// <summary>
		/// vUserDefaultGroup's Login.
		/// </summary>
		string Login { get; set; }

		/// <summary>
		/// vUserDefaultGroup's IDGroup.
		/// </summary>
		long IDGroup { get; set; }

		/// <summary>
		/// vUserDefaultGroup's Name.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// vUserDefaultGroup's Relationdate.
		/// </summary>
		DateTime Relationdate { get; set; }
	}
	#endregion

	/// <summary>
	/// vUserDefaultGroup SerializableObject which provides fields access at vUserDefaultGroup view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vUserDefaultGroup : ISO_vUserDefaultGroup, ISerializable {
		#region public SO_vUserDefaultGroup();
		public SO_vUserDefaultGroup(
		) : this (
			0L, 
			string.Empty, 
			0L, 
			string.Empty, 
			new DateTime(1900, 1, 1)
		) {
		}
		public SO_vUserDefaultGroup(
			long IDUser_in, 
			string Login_in, 
			long IDGroup_in, 
			string Name_in, 
			DateTime Relationdate_in
		) {
			haschanges_ = false;

			iduser_ = IDUser_in;
			login_ = Login_in;
			idgroup_ = IDGroup_in;
			name_ = Name_in;
			relationdate_ = Relationdate_in;
		}
		public SO_vUserDefaultGroup(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			iduser_ = (long)info_in.GetValue("IDUser", typeof(long));
			login_ = (string)info_in.GetValue("Login", typeof(string));
			idgroup_ = (long)info_in.GetValue("IDGroup", typeof(long));
			name_ = (string)info_in.GetValue("Name", typeof(string));
			relationdate_ = (DateTime)info_in.GetValue("Relationdate", typeof(DateTime));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vUserDefaultGroup properties since last time getObject method was run.
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
		/// vUserDefaultGroup's IDUser.
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
		#region public string Login { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public string login_;// = string.Empty;
		
		/// <summary>
		/// vUserDefaultGroup's Login.
		/// </summary>
		[XmlElement("Login")]
		[SoapElement("Login")]
		[DOPropertyAttribute(
			"Login", 
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
		string Login {
			get {
				return login_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(login_))
				) {
					login_ = value;
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
		/// vUserDefaultGroup's IDGroup.
		/// </summary>
		[XmlElement("IDGroup")]
		[SoapElement("IDGroup")]
		[DOPropertyAttribute(
			"IDGroup", 
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
		#region public string Name { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public string name_;// = string.Empty;
		
		/// <summary>
		/// vUserDefaultGroup's Name.
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
		#region public DateTime Relationdate { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public DateTime relationdate_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// vUserDefaultGroup's Relationdate.
		/// </summary>
		[XmlElement("Relationdate")]
		[SoapElement("Relationdate")]
		[DOPropertyAttribute(
			"Relationdate", 
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
				return relationdate_;
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
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDUser", iduser_);
			info_in.AddValue("Login", login_);
			info_in.AddValue("IDGroup", idgroup_);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Relationdate", relationdate_);
		}
		#endregion
		#endregion
	}
}