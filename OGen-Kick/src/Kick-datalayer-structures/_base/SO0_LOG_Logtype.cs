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
	/// LOG_Logtype SerializableObject which provides fields access at LOG_Logtype table at Database.
	/// </summary>
	[Serializable()]
	public class SO_LOG_Logtype : 
		SO__ListItem<int, string> 
	{
		#region public SO_LOG_Logtype();
		public SO_LOG_Logtype(
		) {
			Clear();
		}
		public SO_LOG_Logtype(
			int IDLogtype_in, 
			int IFLogtype_parent_in, 
			string Name_in, 
			int IFApplication_in
		) {
			haschanges_ = false;

			idlogtype_ = IDLogtype_in;
			iflogtype_parent_ = IFLogtype_parent_in;
			name_ = Name_in;
			ifapplication_ = IFApplication_in;
		}
		public SO_LOG_Logtype(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idlogtype_ = (int)info_in.GetValue("IDLogtype", typeof(int));
			iflogtype_parent_ 
				= (info_in.GetValue("IFLogtype_parent", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFLogtype_parent", typeof(int));
			IFLogtype_parent_isNull = (bool)info_in.GetValue("IFLogtype_parent_isNull", typeof(bool));
			name_ = (string)info_in.GetValue("Name", typeof(string));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_LOG_Logtype properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public override int ListItem_Value { get; }
		public override int ListItem_Value {
			get {
				return idlogtype_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return name_;
			}
		} 
		#endregion

		#region public int IDLogtype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int idlogtype_;// = 0;
		
		/// <summary>
		/// LOG_Logtype's IDLogtype.
		/// </summary>
		[XmlElement("IDLogtype")]
		[SoapElement("IDLogtype")]
		[DOPropertyAttribute(
			"IDLogtype", 
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
			true, 
			false, 
			0, 
			""
		)]
		public int IDLogtype {
			get {
				return idlogtype_;
			}
			set {
				if (
					(!value.Equals(idlogtype_))
				) {
					idlogtype_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFLogtype_parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object iflogtype_parent_;// = 0;
		
		/// <summary>
		/// LOG_Logtype's IFLogtype_parent.
		/// </summary>
		[XmlElement("IFLogtype_parent")]
		[SoapElement("IFLogtype_parent")]
		[DOPropertyAttribute(
			"IFLogtype_parent", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"LOG_Logtype", 
			"IDLogtype", 
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
		public int IFLogtype_parent {
			get {
				return (int)((iflogtype_parent_ == null) ? 0 : iflogtype_parent_);
			}
			set {
				if (
					(!value.Equals(iflogtype_parent_))
				) {
					iflogtype_parent_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFLogtype_parent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Logtype's IFLogtype_parent.
		/// </summary>
		[XmlElement("IFLogtype_parent_isNull")]
		[SoapElement("IFLogtype_parent_isNull")]
		public bool IFLogtype_parent_isNull {
			get { return (iflogtype_parent_ == null); }
			set {
				//if (value) iflogtype_parent_ = null;

				if ((value) && (iflogtype_parent_ != null)) {
					iflogtype_parent_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public string name_;// = string.Empty;
		
		/// <summary>
		/// LOG_Logtype's Name.
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
			true, 
			20, 
			""
		)]
		public string Name {
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
		/// <summary>
		/// LOG_Logtype's IFApplication.
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
			"APP_Application", 
			"IDApplication", 
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
		/// Allows assignement of null and check if null at LOG_Logtype's IFApplication.
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_LOG_Logtype[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idlogtype = new DataColumn("IDLogtype", typeof(int));
			_output.Columns.Add(_dc_idlogtype);
			DataColumn _dc_iflogtype_parent = new DataColumn("IFLogtype_parent", typeof(int));
			_output.Columns.Add(_dc_iflogtype_parent);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_LOG_Logtype _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idlogtype] = _serializableobject.IDLogtype;
				_dr[_dc_iflogtype_parent] = _serializableobject.IFLogtype_parent;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idlogtype_ = 0;
			iflogtype_parent_ = 0;
			name_ = string.Empty;
			ifapplication_ = 0;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDLogtype", idlogtype_);
			info_in.AddValue("IFLogtype_parent", iflogtype_parent_);
			info_in.AddValue("IFLogtype_parent_isNull", IFLogtype_parent_isNull);
			info_in.AddValue("Name", name_);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}