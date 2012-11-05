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
	/// DIC_Text SerializableObject which provides fields access at DIC_Text table at Database.
	/// </summary>
	[Serializable()]
	public class SO_DIC_Text : 
		ISerializable
	{
		#region public SO_DIC_Text();
		public SO_DIC_Text(
		) {
			this.Clear();
		}
		public SO_DIC_Text(
			long IDText_in, 
			int IFApplication_in, 
			int SourceTableField_ref_in
		) {
			this.idtext_ = IDText_in;
			this.ifapplication_ = IFApplication_in;
			this.sourcetablefield_ref_ = SourceTableField_ref_in;

			this.haschanges_ = false;
		}
		protected SO_DIC_Text(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idtext_ = (long)info.GetValue("IDText", typeof(long));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.sourcetablefield_ref_ 
				= (info.GetValue("SourceTableField_ref", typeof(int)) == null)
					? 0
					: (int)info.GetValue("SourceTableField_ref", typeof(int));
			this.SourceTableField_ref_isNull = (bool)info.GetValue("SourceTableField_ref_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_DIC_Text properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDText { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idtext_;// = 0L;
		
		/// <summary>
		/// DIC_Text's IDText.
		/// </summary>
		[XmlElement("IDText")]
		[SoapElement("IDText")]
		[DOPropertyAttribute(
			"IDText", 
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
		public long IDText {
			get {
				return this.idtext_;
			}
			set {
				if (
					(!value.Equals(this.idtext_))
				) {
					this.idtext_ = value;
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
		/// DIC_Text's IFApplication.
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
		/// Allows assignement of null and check if null at DIC_Text's IFApplication.
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
		#region public int SourceTableField_ref { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object sourcetablefield_ref_;// = 0;
		
		/// <summary>
		/// DIC_Text's SourceTableField_ref.
		/// </summary>
		[XmlElement("SourceTableField_ref")]
		[SoapElement("SourceTableField_ref")]
		[DOPropertyAttribute(
			"SourceTableField_ref", 
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
		public int SourceTableField_ref {
			get {
				return (int)((this.sourcetablefield_ref_ == null) ? 0 : this.sourcetablefield_ref_);
			}
			set {
				if (
					(!value.Equals(this.sourcetablefield_ref_))
				) {
					this.sourcetablefield_ref_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool SourceTableField_ref_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at DIC_Text's SourceTableField_ref.
		/// </summary>
		[XmlElement("SourceTableField_ref_isNull")]
		[SoapElement("SourceTableField_ref_isNull")]
		public bool SourceTableField_ref_isNull {
			get { return (this.sourcetablefield_ref_ == null); }
			set {
				//if (value) this.sourcetablefield_ref_ = null;

				if ((value) && (this.sourcetablefield_ref_ != null)) {
					this.sourcetablefield_ref_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_DIC_Text[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idtext = new DataColumn("IDText", typeof(long));
			_output.Columns.Add(_dc_idtext);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_sourcetablefield_ref = new DataColumn("SourceTableField_ref", typeof(int));
			_output.Columns.Add(_dc_sourcetablefield_ref);

			foreach (SO_DIC_Text _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idtext] = _serializableObject.IDText;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_sourcetablefield_ref] = _serializableObject.SourceTableField_ref;

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
			this.idtext_ = 0L;
			this.ifapplication_ = 0;
			this.sourcetablefield_ref_ = 0;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDText", this.idtext_);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("SourceTableField_ref", this.sourcetablefield_ref_);
			info.AddValue("SourceTableField_ref_isNull", this.SourceTableField_ref_isNull);
		}
		#endregion
		#endregion
	}
}