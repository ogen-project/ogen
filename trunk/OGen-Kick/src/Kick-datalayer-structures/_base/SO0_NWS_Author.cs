#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures {
	using System;
	using System.Data;
	using System.Runtime.Serialization;
	using System.Xml.Serialization;

	using OGen.NTier.Libraries.DataLayer;

	/// <summary>
	/// NWS_Author SerializableObject which provides fields access at NWS_Author table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_Author : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_NWS_Author();
		public SO_NWS_Author(
		) {
			this.Clear();
		}
		public SO_NWS_Author(
			long IDAuthor_in, 
			int IFApplication_in, 
			string Name_in, 
			long IFUser__Approved_in, 
			DateTime Approved_date_in
		) {
			this.idauthor_ = IDAuthor_in;
			this.ifapplication_ = IFApplication_in;
			this.name_ = Name_in;
			this.ifuser__approved_ = IFUser__Approved_in;
			this.approved_date_ = Approved_date_in;

			this.haschanges_ = false;
		}
		protected SO_NWS_Author(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idauthor_ = (long)info.GetValue("IDAuthor", typeof(long));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.name_ = (string)info.GetValue("Name", typeof(string));
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

			this.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public bool HasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NWS_Author properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public override long ListItem_Value { get; }
		public override long ListItem_Value {
			get {
				return this.idauthor_;
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

		#region public long IDAuthor { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idauthor_;// = 0L;
		
		/// <summary>
		/// NWS_Author's IDAuthor.
		/// </summary>
		[XmlElement("IDAuthor")]
		[SoapElement("IDAuthor")]
		[DOPropertyAttribute(
			"IDAuthor", 
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
			true, 
			false, 
			0, 
			""
		)]
		public long IDAuthor {
			get {
				return this.idauthor_;
			}
			set {
				if (
					(!value.Equals(this.idauthor_))
				) {
					this.idauthor_ = value;
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
		/// NWS_Author's IFApplication.
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
		/// Allows assignement of null and check if null at NWS_Author's IFApplication.
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
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string name_;// = string.Empty;
		
		/// <summary>
		/// NWS_Author's Name.
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
		#region public long IFUser__Approved { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifuser__approved_;// = 0L;
		
		/// <summary>
		/// NWS_Author's IFUser__Approved.
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
			"NET_User", 
			"IFUser", 
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
		/// Allows assignement of null and check if null at NWS_Author's IFUser__Approved.
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
		/// NWS_Author's Approved_date.
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
		/// Allows assignement of null and check if null at NWS_Author's Approved_date.
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NWS_Author[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idauthor = new DataColumn("IDAuthor", typeof(long));
			_output.Columns.Add(_dc_idauthor);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifuser__approved = new DataColumn("IFUser__Approved", typeof(long));
			_output.Columns.Add(_dc_ifuser__approved);
			DataColumn _dc_approved_date = new DataColumn("Approved_date", typeof(DateTime));
			_output.Columns.Add(_dc_approved_date);

			foreach (SO_NWS_Author _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idauthor] = _serializableObject.IDAuthor;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_ifuser__approved] = _serializableObject.IFUser__Approved;
				_dr[_dc_approved_date] = _serializableObject.Approved_date;

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
			this.idauthor_ = 0L;
			this.ifapplication_ = 0;
			this.name_ = string.Empty;
			this.ifuser__approved_ = 0L;
			this.approved_date_ = new DateTime(1900, 1, 1);

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDAuthor", this.idauthor_);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("Name", this.name_);
			info.AddValue("IFUser__Approved", this.ifuser__approved_);
			info.AddValue("IFUser__Approved_isNull", this.IFUser__Approved_isNull);
			info.AddValue("Approved_date", this.approved_date_);
			info.AddValue("Approved_date_isNull", this.Approved_date_isNull);
		}
		#endregion
		#endregion
	}
}