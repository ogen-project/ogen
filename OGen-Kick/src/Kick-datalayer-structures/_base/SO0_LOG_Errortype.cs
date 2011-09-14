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
	/// LOG_Errortype SerializableObject which provides fields access at LOG_Errortype table at Database.
	/// </summary>
	[Serializable()]
	public class SO_LOG_Errortype : 
		SO__ListItem<int, string> 
	{
		#region public SO_LOG_Errortype();
		public SO_LOG_Errortype(
		) {
			Clear();
		}
		public SO_LOG_Errortype(
			int IDErrortype_in, 
			string Name_in, 
			string Description_in, 
			int IFApplication_in
		) {
			haschanges_ = false;

			iderrortype_ = IDErrortype_in;
			name_ = Name_in;
			description_ = Description_in;
			ifapplication_ = IFApplication_in;
		}
		public SO_LOG_Errortype(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			iderrortype_ = (int)info_in.GetValue("IDErrortype", typeof(int));
			name_ = (string)info_in.GetValue("Name", typeof(string));
			description_ 
				= (info_in.GetValue("Description", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Description", typeof(string));
			Description_isNull = (bool)info_in.GetValue("Description_isNull", typeof(bool));
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
		/// Indicates if changes have been made to FO0_LOG_Errortype properties since last time getObject method was run.
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
				return iderrortype_;
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

		#region public int IDErrortype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int iderrortype_;// = 0;
		
		/// <summary>
		/// LOG_Errortype's IDErrortype.
		/// </summary>
		[XmlElement("IDErrortype")]
		[SoapElement("IDErrortype")]
		[DOPropertyAttribute(
			"IDErrortype", 
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
		public int IDErrortype {
			get {
				return iderrortype_;
			}
			set {
				if (
					(!value.Equals(iderrortype_))
				) {
					iderrortype_ = value;
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
		/// LOG_Errortype's Name.
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
			255, 
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
		#region public string Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object description_;// = string.Empty;
		
		/// <summary>
		/// LOG_Errortype's Description.
		/// </summary>
		[XmlElement("Description")]
		[SoapElement("Description")]
		[DOPropertyAttribute(
			"Description", 
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
			2048, 
			""
		)]
		public string Description {
			get {
				return (string)((description_ == null) ? string.Empty : description_);
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
		#region public bool Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at LOG_Errortype's Description.
		/// </summary>
		[XmlElement("Description_isNull")]
		[SoapElement("Description_isNull")]
		public bool Description_isNull {
			get { return (description_ == null); }
			set {
				//if (value) description_ = null;

				if ((value) && (description_ != null)) {
					description_ = null;
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
		/// LOG_Errortype's IFApplication.
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
		/// Allows assignement of null and check if null at LOG_Errortype's IFApplication.
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
			SO_LOG_Errortype[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_iderrortype = new DataColumn("IDErrortype", typeof(int));
			_output.Columns.Add(_dc_iderrortype);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_description = new DataColumn("Description", typeof(string));
			_output.Columns.Add(_dc_description);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_LOG_Errortype _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iderrortype] = _serializableobject.IDErrortype;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_description] = _serializableobject.Description;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			iderrortype_ = 0;
			name_ = string.Empty;
			description_ = string.Empty;
			ifapplication_ = 0;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDErrortype", iderrortype_);
			info_in.AddValue("Name", name_);
			info_in.AddValue("Description", description_);
			info_in.AddValue("Description_isNull", Description_isNull);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}