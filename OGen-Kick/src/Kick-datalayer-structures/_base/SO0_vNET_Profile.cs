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
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.Kick.lib.datalayer.shared.structures {
	/// <summary>
	/// vNET_Profile SerializableObject which provides fields access at vNET_Profile view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNET_Profile : 
		SO__base 
	{
		#region public SO_vNET_Profile();
		public SO_vNET_Profile(
		) {
			Clear();
		}
		public SO_vNET_Profile(
			long IDProfile_in, 
			string Name_in, 
			int IFApplication_in, 
			bool isDefaultprofile_in
		) {
			haschanges_ = false;

			idprofile_ = IDProfile_in;
			name_ = Name_in;
			ifapplication_ = IFApplication_in;
			isdefaultprofile_ = isDefaultprofile_in;
		}
		public SO_vNET_Profile(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idprofile_ = (long)info_in.GetValue("IDProfile", typeof(long));
			name_ 
				= (info_in.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Name", typeof(string));
			Name_isNull = (bool)info_in.GetValue("Name_isNull", typeof(bool));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
			isdefaultprofile_ 
				= (info_in.GetValue("isDefaultprofile", typeof(bool)) == null)
					? false
					: (bool)info_in.GetValue("isDefaultprofile", typeof(bool));
			isDefaultprofile_isNull = (bool)info_in.GetValue("isDefaultprofile_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vNET_Profile properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDProfile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idprofile_;// = 0L;
		
		/// <summary>
		/// vNET_Profile's IDProfile.
		/// </summary>
		[XmlElement("IDProfile")]
		[SoapElement("IDProfile")]
		[DOPropertyAttribute(
			"IDProfile", 
			"", 
			"", 
			true, 
			false, 
			true, 
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
		public long IDProfile {
			get {
				return idprofile_;
			}
			set {
				if (
					(!value.Equals(idprofile_))
				) {
					idprofile_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object name_;// = string.Empty;
		
		/// <summary>
		/// vNET_Profile's Name.
		/// </summary>
		[XmlElement("Name")]
		[SoapElement("Name")]
		[DOPropertyAttribute(
			"Name", 
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
			false, 
			false, 
			false, 
			true, 
			false, 
			false, 
			255, 
			""
		)]
		public string Name {
			get {
				return (string)((name_ == null) ? string.Empty : name_);
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
		#region public bool Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNET_Profile's Name.
		/// </summary>
		[XmlElement("Name_isNull")]
		[SoapElement("Name_isNull")]
		public bool Name_isNull {
			get { return (name_ == null); }
			set {
				//if (value) name_ = null;

				if ((value) && (name_ != null)) {
					name_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
		/// <summary>
		/// vNET_Profile's IFApplication.
		/// </summary>
		[XmlElement("IFApplication")]
		[SoapElement("IFApplication")]
		[DOPropertyAttribute(
			"IFApplication", 
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
			false, 
			true, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public int IFApplication {
			get {
				return (int)((ifapplication_ == null) ? 0 : ifapplication_);
			}
			set {
				if (
					(!value.Equals(ifapplication_))
				) {
					ifapplication_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFApplication_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNET_Profile's IFApplication.
		/// </summary>
		[XmlElement("IFApplication_isNull")]
		[SoapElement("IFApplication_isNull")]
		public bool IFApplication_isNull {
			get { return (ifapplication_ == null); }
			set {
				//if (value) ifapplication_ = null;

				if ((value) && (ifapplication_ != null)) {
					ifapplication_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isDefaultprofile { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object isdefaultprofile_;// = false;
		
		/// <summary>
		/// vNET_Profile's isDefaultprofile.
		/// </summary>
		[XmlElement("isDefaultprofile")]
		[SoapElement("isDefaultprofile")]
		[DOPropertyAttribute(
			"isDefaultprofile", 
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
		public bool isDefaultprofile {
			get {
				return (bool)((isdefaultprofile_ == null) ? false : isdefaultprofile_);
			}
			set {
				if (
					(!value.Equals(isdefaultprofile_))
				) {
					isdefaultprofile_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool isDefaultprofile_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNET_Profile's isDefaultprofile.
		/// </summary>
		[XmlElement("isDefaultprofile_isNull")]
		[SoapElement("isDefaultprofile_isNull")]
		public bool isDefaultprofile_isNull {
			get { return (isdefaultprofile_ == null); }
			set {
				//if (value) isdefaultprofile_ = null;

				if ((value) && (isdefaultprofile_ != null)) {
					isdefaultprofile_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNET_Profile[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idprofile = new DataColumn("IDProfile", typeof(long));
			_output.Columns.Add(_dc_idprofile);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_isdefaultprofile = new DataColumn("isDefaultprofile", typeof(bool));
			_output.Columns.Add(_dc_isdefaultprofile);

			foreach (SO_vNET_Profile _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idprofile] = _serializableobject.IDProfile;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_isdefaultprofile] = _serializableobject.isDefaultprofile;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idprofile_ = 0L;
			name_ = string.Empty;
			ifapplication_ = 0;
			isdefaultprofile_ = false;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDProfile", idprofile_);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Name_isNull", Name_isNull);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
			info_in.AddValue("isDefaultprofile", isdefaultprofile_);
			info_in.AddValue("isDefaultprofile_isNull", isDefaultprofile_isNull);
		}
		#endregion
		#endregion
	}
}