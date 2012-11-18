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
	/// FRM_Form SerializableObject which provides fields access at FRM_Form table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_Form : 
		ISerializable
	{
		#region public SO_FRM_Form();
		public SO_FRM_Form(
		) {
			this.Clear();
		}
		public SO_FRM_Form(
			long IDForm_in, 
			long TX_Name_in, 
			long TX_Description_in, 
			int IFApplication_in, 
			long IFUser__audit_in, 
			DateTime Date__audit_in
		) {
			this.idform_ = IDForm_in;
			this.tx_name_ = TX_Name_in;
			this.tx_description_ = TX_Description_in;
			this.ifapplication_ = IFApplication_in;
			this.ifuser__audit_ = IFUser__audit_in;
			this.date__audit_ = Date__audit_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_Form(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idform_ = (long)info.GetValue("IDForm", typeof(long));
			this.tx_name_ 
				= (info.GetValue("TX_Name", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Name", typeof(long));
			this.TX_Name_isNull = (bool)info.GetValue("TX_Name_isNull", typeof(bool));
			this.tx_description_ 
				= (info.GetValue("TX_Description", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Description", typeof(long));
			this.TX_Description_isNull = (bool)info.GetValue("TX_Description_isNull", typeof(bool));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.ifuser__audit_ = (long)info.GetValue("IFUser__audit", typeof(long));
			this.date__audit_ = (DateTime)info.GetValue("Date__audit", typeof(DateTime));

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
		/// Indicates if changes have been made to FO0_FRM_Form properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDForm { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idform_;// = 0L;
		
		/// <summary>
		/// FRM_Form's IDForm.
		/// </summary>
		[XmlElement("IDForm")]
		[SoapElement("IDForm")]
		[DOPropertyAttribute(
			"IDForm", 
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
			false, 
			false, 
			0, 
			""
		)]
		public long IDForm {
			get {
				return this.idform_;
			}
			set {
				if (
					(!value.Equals(this.idform_))
				) {
					this.idform_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_name_;// = 0L;
		
		/// <summary>
		/// FRM_Form's TX_Name.
		/// </summary>
		[XmlElement("TX_Name")]
		[SoapElement("TX_Name")]
		[DOPropertyAttribute(
			"TX_Name", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long TX_Name {
			get {
				return (long)((this.tx_name_ == null) ? 0L : this.tx_name_);
			}
			set {
				if (
					(!value.Equals(this.tx_name_))
				) {
					this.tx_name_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Name_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Form's TX_Name.
		/// </summary>
		[XmlElement("TX_Name_isNull")]
		[SoapElement("TX_Name_isNull")]
		public bool TX_Name_isNull {
			get { return (this.tx_name_ == null); }
			set {
				//if (value) this.tx_name_ = null;

				if ((value) && (this.tx_name_ != null)) {
					this.tx_name_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Description { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_description_;// = 0L;
		
		/// <summary>
		/// FRM_Form's TX_Description.
		/// </summary>
		[XmlElement("TX_Description")]
		[SoapElement("TX_Description")]
		[DOPropertyAttribute(
			"TX_Description", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long TX_Description {
			get {
				return (long)((this.tx_description_ == null) ? 0L : this.tx_description_);
			}
			set {
				if (
					(!value.Equals(this.tx_description_))
				) {
					this.tx_description_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Description_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Form's TX_Description.
		/// </summary>
		[XmlElement("TX_Description_isNull")]
		[SoapElement("TX_Description_isNull")]
		public bool TX_Description_isNull {
			get { return (this.tx_description_ == null); }
			set {
				//if (value) this.tx_description_ = null;

				if ((value) && (this.tx_description_ != null)) {
					this.tx_description_ = null;
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
		/// FRM_Form's IFApplication.
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
		/// Allows assignement of null and check if null at FRM_Form's IFApplication.
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
		#region public long IFUser__audit { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifuser__audit_;// = 0L;
		
		/// <summary>
		/// FRM_Form's IFUser__audit.
		/// </summary>
		[XmlElement("IFUser__audit")]
		[SoapElement("IFUser__audit")]
		[DOPropertyAttribute(
			"IFUser__audit", 
			"", 
			"", 
			false, 
			false, 
			false, 
			"", 
			"CRD_User", 
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
		public long IFUser__audit {
			get {
				return this.ifuser__audit_;
			}
			set {
				if (
					(!value.Equals(this.ifuser__audit_))
				) {
					this.ifuser__audit_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Date__audit { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private DateTime date__audit_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// FRM_Form's Date__audit.
		/// </summary>
		[XmlElement("Date__audit")]
		[SoapElement("Date__audit")]
		[DOPropertyAttribute(
			"Date__audit", 
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
		public DateTime Date__audit {
			get {
				return this.date__audit_;
			}
			set {
				if (
					(!value.Equals(this.date__audit_))
				) {
					this.date__audit_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_FRM_Form[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idform = new DataColumn("IDForm", typeof(long));
			_output.Columns.Add(_dc_idform);
			DataColumn _dc_tx_name = new DataColumn("TX_Name", typeof(long));
			_output.Columns.Add(_dc_tx_name);
			DataColumn _dc_tx_description = new DataColumn("TX_Description", typeof(long));
			_output.Columns.Add(_dc_tx_description);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_ifuser__audit = new DataColumn("IFUser__audit", typeof(long));
			_output.Columns.Add(_dc_ifuser__audit);
			DataColumn _dc_date__audit = new DataColumn("Date__audit", typeof(DateTime));
			_output.Columns.Add(_dc_date__audit);

			foreach (SO_FRM_Form _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idform] = _serializableObject.IDForm;
				_dr[_dc_tx_name] = _serializableObject.TX_Name;
				_dr[_dc_tx_description] = _serializableObject.TX_Description;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_ifuser__audit] = _serializableObject.IFUser__audit;
				_dr[_dc_date__audit] = _serializableObject.Date__audit;

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
			this.idform_ = 0L;
			this.tx_name_ = 0L;
			this.tx_description_ = 0L;
			this.ifapplication_ = 0;
			this.ifuser__audit_ = 0L;
			this.date__audit_ = new DateTime(1900, 1, 1);

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDForm", this.idform_);
			info.AddValue("TX_Name", this.tx_name_);
			info.AddValue("TX_Name_isNull", this.TX_Name_isNull);
			info.AddValue("TX_Description", this.tx_description_);
			info.AddValue("TX_Description_isNull", this.TX_Description_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("IFUser__audit", this.ifuser__audit_);
			info.AddValue("Date__audit", this.date__audit_);
		}
		#endregion
		#endregion
	}
}