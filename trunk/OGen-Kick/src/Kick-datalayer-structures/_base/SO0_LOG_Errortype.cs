#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.lib.datalayer.shared.structures {
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using OGen.NTier.lib.datalayer;

	/// <summary>
	/// LOG_Errortype SerializableObject which provides fields access at LOG_Errortype table at Database.
	/// </summary>
	[Serializable()]
	public class SO_LOG_Errortype : 
		SO__ListItem<int, string>, ISerializable
	{
		#region public SO_LOG_Errortype();
		public SO_LOG_Errortype(
		) {
			this.Clear();
		}
		public SO_LOG_Errortype(
			int IDErrortype_in, 
			string Name_in, 
			string Description_in, 
			int IFApplication_in
		) {
			this.iderrortype_ = IDErrortype_in;
			this.name_ = Name_in;
			this.description_ = Description_in;
			this.ifapplication_ = IFApplication_in;

			this.haschanges_ = false;
		}
		protected SO_LOG_Errortype(
			SerializationInfo info,
			StreamingContext context
		) {
			this.iderrortype_ = (int)info.GetValue("IDErrortype", typeof(int));
			this.name_ = (string)info.GetValue("Name", typeof(string));
			this.description_ 
				= (info.GetValue("Description", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Description", typeof(string));
			this.Description_isNull = (bool)info.GetValue("Description_isNull", typeof(bool));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));

			this.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_LOG_Errortype properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override int ListItem_Value { get; }
		public override int ListItem_Value {
			get {
				return this.iderrortype_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.name_;
			}
		} 
		#endregion

		#region public int IDErrortype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int iderrortype_;// = 0;
		
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
				return this.iderrortype_;
			}
			set {
				if (
					(!value.Equals(this.iderrortype_))
				) {
					this.iderrortype_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string name_;// = string.Empty;
		
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
				return this.name_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.name_))
				) {
					this.name_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object description_;// = string.Empty;
		
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
				return (string)((this.description_ == null) ? string.Empty : this.description_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.description_))
				) {
					this.description_ = value;
					this.haschanges_ = true;
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
			get { return (this.description_ == null); }
			set {
				//if (value) this.description_ = null;

				if ((value) && (this.description_ != null)) {
					this.description_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifapplication_;// = 0;
		
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
				return (int)((this.ifapplication_ == null) ? 0 : this.ifapplication_);
			}
			set {
				if (
					(!value.Equals(this.ifapplication_))
				) {
					this.ifapplication_ = value;
					this.haschanges_ = true;
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
			get { return (this.ifapplication_ == null); }
			set {
				//if (value) this.ifapplication_ = null;

				if ((value) && (this.ifapplication_ != null)) {
					this.ifapplication_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_LOG_Errortype[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_iderrortype = new DataColumn("IDErrortype", typeof(int));
			_output.Columns.Add(_dc_iderrortype);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_description = new DataColumn("Description", typeof(string));
			_output.Columns.Add(_dc_description);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_LOG_Errortype _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iderrortype] = _serializableObject.IDErrortype;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_description] = _serializableObject.Description;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public void Clear();
		/// <summary>
		/// Clears SerializableObject's properties.
		/// </summary>
		public void Clear() {
			this.iderrortype_ = 0;
			this.name_ = string.Empty;
			this.description_ = string.Empty;
			this.ifapplication_ = 0;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDErrortype", this.iderrortype_);
			info.AddValue("Name", this.name_);
			info.AddValue("Description", this.description_);
			info.AddValue("Description_isNull", this.Description_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}