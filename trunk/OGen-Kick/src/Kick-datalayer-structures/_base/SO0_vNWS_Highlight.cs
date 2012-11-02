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
	/// vNWS_Highlight SerializableObject which provides fields access at vNWS_Highlight view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vNWS_Highlight : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_vNWS_Highlight();
		public SO_vNWS_Highlight(
		) {
			this.Clear();
		}
		public SO_vNWS_Highlight(
			long IDHighlight_in, 
			long IFHighlight__parent_in, 
			long IFUser__Approved_in, 
			DateTime Approved_date_in, 
			string Name_in, 
			int IFApplication_in, 
			string ManagerName_in
		) {
			this.idhighlight_ = IDHighlight_in;
			this.ifhighlight__parent_ = IFHighlight__parent_in;
			this.ifuser__approved_ = IFUser__Approved_in;
			this.approved_date_ = Approved_date_in;
			this.name_ = Name_in;
			this.ifapplication_ = IFApplication_in;
			this.managername_ = ManagerName_in;

			this.haschanges_ = false;
		}
		protected SO_vNWS_Highlight(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idhighlight_ = (long)info.GetValue("IDHighlight", typeof(long));
			this.ifhighlight__parent_ 
				= (info.GetValue("IFHighlight__parent", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFHighlight__parent", typeof(long));
			this.IFHighlight__parent_isNull = (bool)info.GetValue("IFHighlight__parent_isNull", typeof(bool));
			this.ifuser__approved_ 
				= (info.GetValue("IFUser__Approved", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFUser__Approved", typeof(long));
			this.IFUser__Approved_isNull = (bool)info.GetValue("IFUser__Approved_isNull", typeof(bool));
			this.approved_date_ 
				= (info.GetValue("Approved_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info.GetValue("Approved_date", typeof(DateTime));
			this.Approved_date_isNull = (bool)info.GetValue("Approved_date_isNull", typeof(bool));
			this.name_ 
				= (info.GetValue("Name", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Name", typeof(string));
			this.Name_isNull = (bool)info.GetValue("Name_isNull", typeof(bool));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.managername_ 
				= (info.GetValue("ManagerName", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("ManagerName", typeof(string));
			this.ManagerName_isNull = (bool)info.GetValue("ManagerName_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_vNWS_Highlight properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return this.idhighlight_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.Name;
			}
		} 
		#endregion

		#region public long IDHighlight { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idhighlight_;// = 0L;
		
		/// <summary>
		/// vNWS_Highlight's IDHighlight.
		/// </summary>
		[XmlElement("IDHighlight")]
		[SoapElement("IDHighlight")]
		[DOPropertyAttribute(
			"IDHighlight", 
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
		public long IDHighlight {
			get {
				return this.idhighlight_;
			}
			set {
				if (
					(!value.Equals(this.idhighlight_))
				) {
					this.idhighlight_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFHighlight__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifhighlight__parent_;// = 0L;
		
		/// <summary>
		/// vNWS_Highlight's IFHighlight__parent.
		/// </summary>
		[XmlElement("IFHighlight__parent")]
		[SoapElement("IFHighlight__parent")]
		[DOPropertyAttribute(
			"IFHighlight__parent", 
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
		public long IFHighlight__parent {
			get {
				return (long)((this.ifhighlight__parent_ == null) ? 0L : this.ifhighlight__parent_);
			}
			set {
				if (
					(!value.Equals(this.ifhighlight__parent_))
				) {
					this.ifhighlight__parent_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFHighlight__parent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Highlight's IFHighlight__parent.
		/// </summary>
		[XmlElement("IFHighlight__parent_isNull")]
		[SoapElement("IFHighlight__parent_isNull")]
		public bool IFHighlight__parent_isNull {
			get { return (this.ifhighlight__parent_ == null); }
			set {
				//if (value) this.ifhighlight__parent_ = null;

				if ((value) && (this.ifhighlight__parent_ != null)) {
					this.ifhighlight__parent_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__Approved { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifuser__approved_;// = 0L;
		
		/// <summary>
		/// vNWS_Highlight's IFUser__Approved.
		/// </summary>
		[XmlElement("IFUser__Approved")]
		[SoapElement("IFUser__Approved")]
		[DOPropertyAttribute(
			"IFUser__Approved", 
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
		public long IFUser__Approved {
			get {
				return (long)((this.ifuser__approved_ == null) ? 0L : this.ifuser__approved_);
			}
			set {
				if (
					(!value.Equals(this.ifuser__approved_))
				) {
					this.ifuser__approved_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFUser__Approved_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Highlight's IFUser__Approved.
		/// </summary>
		[XmlElement("IFUser__Approved_isNull")]
		[SoapElement("IFUser__Approved_isNull")]
		public bool IFUser__Approved_isNull {
			get { return (this.ifuser__approved_ == null); }
			set {
				//if (value) this.ifuser__approved_ = null;

				if ((value) && (this.ifuser__approved_ != null)) {
					this.ifuser__approved_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Approved_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object approved_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// vNWS_Highlight's Approved_date.
		/// </summary>
		[XmlElement("Approved_date")]
		[SoapElement("Approved_date")]
		[DOPropertyAttribute(
			"Approved_date", 
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
		public DateTime Approved_date {
			get {
				return (DateTime)((this.approved_date_ == null) ? new DateTime(1900, 1, 1) : this.approved_date_);
			}
			set {
				if (
					(!value.Equals(this.approved_date_))
				) {
					this.approved_date_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Approved_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Highlight's Approved_date.
		/// </summary>
		[XmlElement("Approved_date_isNull")]
		[SoapElement("Approved_date_isNull")]
		public bool Approved_date_isNull {
			get { return (this.approved_date_ == null); }
			set {
				//if (value) this.approved_date_ = null;

				if ((value) && (this.approved_date_ != null)) {
					this.approved_date_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object name_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Highlight's Name.
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
			true, 
			8000, 
			""
		)]
		public string Name {
			get {
				return (string)((this.name_ == null) ? string.Empty : this.name_);
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
		#region public bool Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Highlight's Name.
		/// </summary>
		[XmlElement("Name_isNull")]
		[SoapElement("Name_isNull")]
		public bool Name_isNull {
			get { return (this.name_ == null); }
			set {
				//if (value) this.name_ = null;

				if ((value) && (this.name_ != null)) {
					this.name_ = null;
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
		/// vNWS_Highlight's IFApplication.
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
		/// Allows assignement of null and check if null at vNWS_Highlight's IFApplication.
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
		#region public string ManagerName { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object managername_;// = string.Empty;
		
		/// <summary>
		/// vNWS_Highlight's ManagerName.
		/// </summary>
		[XmlElement("ManagerName")]
		[SoapElement("ManagerName")]
		[DOPropertyAttribute(
			"ManagerName", 
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
		public string ManagerName {
			get {
				return (string)((this.managername_ == null) ? string.Empty : this.managername_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.managername_))
				) {
					this.managername_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool ManagerName_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vNWS_Highlight's ManagerName.
		/// </summary>
		[XmlElement("ManagerName_isNull")]
		[SoapElement("ManagerName_isNull")]
		public bool ManagerName_isNull {
			get { return (this.managername_ == null); }
			set {
				//if (value) this.managername_ = null;

				if ((value) && (this.managername_ != null)) {
					this.managername_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vNWS_Highlight[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idhighlight = new DataColumn("IDHighlight", typeof(long));
			_output.Columns.Add(_dc_idhighlight);
			DataColumn _dc_ifhighlight__parent = new DataColumn("IFHighlight__parent", typeof(long));
			_output.Columns.Add(_dc_ifhighlight__parent);
			DataColumn _dc_ifuser__approved = new DataColumn("IFUser__Approved", typeof(long));
			_output.Columns.Add(_dc_ifuser__approved);
			DataColumn _dc_approved_date = new DataColumn("Approved_date", typeof(DateTime));
			_output.Columns.Add(_dc_approved_date);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_managername = new DataColumn("ManagerName", typeof(string));
			_output.Columns.Add(_dc_managername);

			foreach (SO_vNWS_Highlight _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idhighlight] = _serializableobject.IDHighlight;
				_dr[_dc_ifhighlight__parent] = _serializableobject.IFHighlight__parent;
				_dr[_dc_ifuser__approved] = _serializableobject.IFUser__Approved;
				_dr[_dc_approved_date] = _serializableobject.Approved_date;
				_dr[_dc_name] = _serializableobject.Name;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_managername] = _serializableobject.ManagerName;

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
			this.idhighlight_ = 0L;
			this.ifhighlight__parent_ = 0L;
			this.ifuser__approved_ = 0L;
			this.approved_date_ = new DateTime(1900, 1, 1);
			this.name_ = string.Empty;
			this.ifapplication_ = 0;
			this.managername_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDHighlight", this.idhighlight_);
			info.AddValue("IFHighlight__parent", this.ifhighlight__parent_);
			info.AddValue("IFHighlight__parent_isNull", this.IFHighlight__parent_isNull);
			info.AddValue("IFUser__Approved", this.ifuser__approved_);
			info.AddValue("IFUser__Approved_isNull", this.IFUser__Approved_isNull);
			info.AddValue("Approved_date", this.approved_date_);
			info.AddValue("Approved_date_isNull", this.Approved_date_isNull);
			info.AddValue("Name", this.name_);
			info.AddValue("Name_isNull", this.Name_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("ManagerName", this.managername_);
			info.AddValue("ManagerName_isNull", this.ManagerName_isNull);
		}
		#endregion
		#endregion
	}
}