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
	/// FRM_Answer SerializableObject which provides fields access at FRM_Answer table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_Answer : 
		ISerializable
	{
		#region public SO_FRM_Answer();
		public SO_FRM_Answer(
		) {
			this.Clear();
		}
		public SO_FRM_Answer(
			long IDAnswer_in, 
			long TX_Answer_in, 
			long TX_Details_in, 
			bool IsRequired_in, 
			int IFApplication_in, 
			long IFUser__audit_in, 
			DateTime Date__audit_in
		) {
			this.idanswer_ = IDAnswer_in;
			this.tx_answer_ = TX_Answer_in;
			this.tx_details_ = TX_Details_in;
			this.isrequired_ = IsRequired_in;
			this.ifapplication_ = IFApplication_in;
			this.ifuser__audit_ = IFUser__audit_in;
			this.date__audit_ = Date__audit_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_Answer(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idanswer_ = (long)info.GetValue("IDAnswer", typeof(long));
			this.tx_answer_ 
				= (info.GetValue("TX_Answer", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Answer", typeof(long));
			this.TX_Answer_isNull = (bool)info.GetValue("TX_Answer_isNull", typeof(bool));
			this.tx_details_ 
				= (info.GetValue("TX_Details", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Details", typeof(long));
			this.TX_Details_isNull = (bool)info.GetValue("TX_Details_isNull", typeof(bool));
			this.isrequired_ 
				= (info.GetValue("IsRequired", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("IsRequired", typeof(bool));
			this.IsRequired_isNull = (bool)info.GetValue("IsRequired_isNull", typeof(bool));
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
		/// Indicates if changes have been made to FO0_FRM_Answer properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDAnswer { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idanswer_;// = 0L;
		
		/// <summary>
		/// FRM_Answer's IDAnswer.
		/// </summary>
		[XmlElement("IDAnswer")]
		[SoapElement("IDAnswer")]
		[DOPropertyAttribute(
			"IDAnswer", 
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
		public long IDAnswer {
			get {
				return this.idanswer_;
			}
			set {
				if (
					(!value.Equals(this.idanswer_))
				) {
					this.idanswer_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Answer { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_answer_;// = 0L;
		
		/// <summary>
		/// FRM_Answer's TX_Answer.
		/// </summary>
		[XmlElement("TX_Answer")]
		[SoapElement("TX_Answer")]
		[DOPropertyAttribute(
			"TX_Answer", 
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
		public long TX_Answer {
			get {
				return (long)((this.tx_answer_ == null) ? 0L : this.tx_answer_);
			}
			set {
				if (
					(!value.Equals(this.tx_answer_))
				) {
					this.tx_answer_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Answer_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Answer's TX_Answer.
		/// </summary>
		[XmlElement("TX_Answer_isNull")]
		[SoapElement("TX_Answer_isNull")]
		public bool TX_Answer_isNull {
			get { return (this.tx_answer_ == null); }
			set {
				//if (value) this.tx_answer_ = null;

				if ((value) && (this.tx_answer_ != null)) {
					this.tx_answer_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Details { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_details_;// = 0L;
		
		/// <summary>
		/// FRM_Answer's TX_Details.
		/// </summary>
		[XmlElement("TX_Details")]
		[SoapElement("TX_Details")]
		[DOPropertyAttribute(
			"TX_Details", 
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
		public long TX_Details {
			get {
				return (long)((this.tx_details_ == null) ? 0L : this.tx_details_);
			}
			set {
				if (
					(!value.Equals(this.tx_details_))
				) {
					this.tx_details_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Details_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Answer's TX_Details.
		/// </summary>
		[XmlElement("TX_Details_isNull")]
		[SoapElement("TX_Details_isNull")]
		public bool TX_Details_isNull {
			get { return (this.tx_details_ == null); }
			set {
				//if (value) this.tx_details_ = null;

				if ((value) && (this.tx_details_ != null)) {
					this.tx_details_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IsRequired { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object isrequired_;// = false;
		
		/// <summary>
		/// FRM_Answer's IsRequired.
		/// </summary>
		[XmlElement("IsRequired")]
		[SoapElement("IsRequired")]
		[DOPropertyAttribute(
			"IsRequired", 
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
		public bool IsRequired {
			get {
				return (bool)((this.isrequired_ == null) ? false : this.isrequired_);
			}
			set {
				if (
					(!value.Equals(this.isrequired_))
				) {
					this.isrequired_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IsRequired_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Answer's IsRequired.
		/// </summary>
		[XmlElement("IsRequired_isNull")]
		[SoapElement("IsRequired_isNull")]
		public bool IsRequired_isNull {
			get { return (this.isrequired_ == null); }
			set {
				//if (value) this.isrequired_ = null;

				if ((value) && (this.isrequired_ != null)) {
					this.isrequired_ = null;
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
		/// FRM_Answer's IFApplication.
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
		/// Allows assignement of null and check if null at FRM_Answer's IFApplication.
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
		/// FRM_Answer's IFUser__audit.
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
		/// FRM_Answer's Date__audit.
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
			SO_FRM_Answer[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idanswer = new DataColumn("IDAnswer", typeof(long));
			_output.Columns.Add(_dc_idanswer);
			DataColumn _dc_tx_answer = new DataColumn("TX_Answer", typeof(long));
			_output.Columns.Add(_dc_tx_answer);
			DataColumn _dc_tx_details = new DataColumn("TX_Details", typeof(long));
			_output.Columns.Add(_dc_tx_details);
			DataColumn _dc_isrequired = new DataColumn("IsRequired", typeof(bool));
			_output.Columns.Add(_dc_isrequired);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_ifuser__audit = new DataColumn("IFUser__audit", typeof(long));
			_output.Columns.Add(_dc_ifuser__audit);
			DataColumn _dc_date__audit = new DataColumn("Date__audit", typeof(DateTime));
			_output.Columns.Add(_dc_date__audit);

			foreach (SO_FRM_Answer _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idanswer] = _serializableObject.IDAnswer;
				_dr[_dc_tx_answer] = _serializableObject.TX_Answer;
				_dr[_dc_tx_details] = _serializableObject.TX_Details;
				_dr[_dc_isrequired] = _serializableObject.IsRequired;
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
			this.idanswer_ = 0L;
			this.tx_answer_ = 0L;
			this.tx_details_ = 0L;
			this.isrequired_ = false;
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
			info.AddValue("IDAnswer", this.idanswer_);
			info.AddValue("TX_Answer", this.tx_answer_);
			info.AddValue("TX_Answer_isNull", this.TX_Answer_isNull);
			info.AddValue("TX_Details", this.tx_details_);
			info.AddValue("TX_Details_isNull", this.TX_Details_isNull);
			info.AddValue("IsRequired", this.isrequired_);
			info.AddValue("IsRequired_isNull", this.IsRequired_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("IFUser__audit", this.ifuser__audit_);
			info.AddValue("Date__audit", this.date__audit_);
		}
		#endregion
		#endregion
	}
}