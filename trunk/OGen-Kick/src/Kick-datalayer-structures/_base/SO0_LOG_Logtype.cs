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
	/// LOG_Logtype SerializableObject which provides fields access at LOG_Logtype table at Database.
	/// </summary>
	[Serializable()]
	public class SO_LOG_Logtype : 
		SO__ListItem<int, string>, ISerializable
	{
		#region public SO_LOG_Logtype();
		public SO_LOG_Logtype(
		) {
			this.Clear();
		}
		public SO_LOG_Logtype(
			int IDLogtype_in, 
			int IFLogtype_parent_in, 
			string Name_in, 
			int IFApplication_in
		) {
			this.idlogtype_ = IDLogtype_in;
			this.iflogtype_parent_ = IFLogtype_parent_in;
			this.name_ = Name_in;
			this.ifapplication_ = IFApplication_in;

			this.haschanges_ = false;
		}
		protected SO_LOG_Logtype(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idlogtype_ = (int)info.GetValue("IDLogtype", typeof(int));
			this.iflogtype_parent_ 
				= (info.GetValue("IFLogtype_parent", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFLogtype_parent", typeof(int));
			this.IFLogtype_parent_isNull = (bool)info.GetValue("IFLogtype_parent_isNull", typeof(bool));
			this.name_ = (string)info.GetValue("Name", typeof(string));
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
		/// Indicates if changes have been made to FO0_LOG_Logtype properties since last time getObject method was run.
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
				return this.idlogtype_;
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

		#region public int IDLogtype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int idlogtype_;// = 0;
		
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
				return this.idlogtype_;
			}
			set {
				if (
					(!value.Equals(this.idlogtype_))
				) {
					this.idlogtype_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFLogtype_parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object iflogtype_parent_;// = 0;
		
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
				return (int)((this.iflogtype_parent_ == null) ? 0 : this.iflogtype_parent_);
			}
			set {
				if (
					(!value.Equals(this.iflogtype_parent_))
				) {
					this.iflogtype_parent_ = value;
					this.haschanges_ = true;
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
			get { return (this.iflogtype_parent_ == null); }
			set {
				//if (value) this.iflogtype_parent_ = null;

				if ((value) && (this.iflogtype_parent_ != null)) {
					this.iflogtype_parent_ = null;
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifapplication_;// = 0;
		
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
		/// Allows assignement of null and check if null at LOG_Logtype's IFApplication.
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
			SO_LOG_Logtype[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idlogtype = new DataColumn("IDLogtype", typeof(int));
			_output.Columns.Add(_dc_idlogtype);
			DataColumn _dc_iflogtype_parent = new DataColumn("IFLogtype_parent", typeof(int));
			_output.Columns.Add(_dc_iflogtype_parent);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_LOG_Logtype _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idlogtype] = _serializableObject.IDLogtype;
				_dr[_dc_iflogtype_parent] = _serializableObject.IFLogtype_parent;
				_dr[_dc_name] = _serializableObject.Name;
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
			this.idlogtype_ = 0;
			this.iflogtype_parent_ = 0;
			this.name_ = string.Empty;
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
			info.AddValue("IDLogtype", this.idlogtype_);
			info.AddValue("IFLogtype_parent", this.iflogtype_parent_);
			info.AddValue("IFLogtype_parent_isNull", this.IFLogtype_parent_isNull);
			info.AddValue("Name", this.name_);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
		}
		#endregion
		#endregion
	}
}