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
	/// FRM_UserQuestion SerializableObject which provides fields access at FRM_UserQuestion table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_UserQuestion : 
		ISerializable
	{
		#region public SO_FRM_UserQuestion();
		public SO_FRM_UserQuestion(
		) {
			this.Clear();
		}
		public SO_FRM_UserQuestion(
			long IFUser_in, 
			long IFQuestion_in, 
			string Answer_in, 
			long IFUser__audit_in, 
			DateTime Date__audit_in
		) {
			this.ifuser_ = IFUser_in;
			this.ifquestion_ = IFQuestion_in;
			this.answer_ = Answer_in;
			this.ifuser__audit_ = IFUser__audit_in;
			this.date__audit_ = Date__audit_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_UserQuestion(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifuser_ = (long)info.GetValue("IFUser", typeof(long));
			this.ifquestion_ = (long)info.GetValue("IFQuestion", typeof(long));
			this.answer_ 
				= (info.GetValue("Answer", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Answer", typeof(string));
			this.Answer_isNull = (bool)info.GetValue("Answer_isNull", typeof(bool));
			this.ifuser__audit_ 
				= (info.GetValue("IFUser__audit", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFUser__audit", typeof(long));
			this.IFUser__audit_isNull = (bool)info.GetValue("IFUser__audit_isNull", typeof(bool));
			this.date__audit_ 
				= (info.GetValue("Date__audit", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info.GetValue("Date__audit", typeof(DateTime));
			this.Date__audit_isNull = (bool)info.GetValue("Date__audit_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_FRM_UserQuestion properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifuser_;// = 0L;
		
		/// <summary>
		/// FRM_UserQuestion's IFUser.
		/// </summary>
		[XmlElement("IFUser")]
		[SoapElement("IFUser")]
		[DOPropertyAttribute(
			"IFUser", 
			"", 
			"", 
			true, 
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
		public long IFUser {
			get {
				return this.ifuser_;
			}
			set {
				if (
					(!value.Equals(this.ifuser_))
				) {
					this.ifuser_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFQuestion { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifquestion_;// = 0L;
		
		/// <summary>
		/// FRM_UserQuestion's IFQuestion.
		/// </summary>
		[XmlElement("IFQuestion")]
		[SoapElement("IFQuestion")]
		[DOPropertyAttribute(
			"IFQuestion", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"FRM_Question", 
			"IDQuestion", 
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
		public long IFQuestion {
			get {
				return this.ifquestion_;
			}
			set {
				if (
					(!value.Equals(this.ifquestion_))
				) {
					this.ifquestion_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Answer { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object answer_;// = string.Empty;
		
		/// <summary>
		/// FRM_UserQuestion's Answer.
		/// </summary>
		[XmlElement("Answer")]
		[SoapElement("Answer")]
		[DOPropertyAttribute(
			"Answer", 
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
			8000, 
			""
		)]
		public string Answer {
			get {
				return (string)((this.answer_ == null) ? string.Empty : this.answer_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.answer_))
				) {
					this.answer_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Answer_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_UserQuestion's Answer.
		/// </summary>
		[XmlElement("Answer_isNull")]
		[SoapElement("Answer_isNull")]
		public bool Answer_isNull {
			get { return (this.answer_ == null); }
			set {
				//if (value) this.answer_ = null;

				if ((value) && (this.answer_ != null)) {
					this.answer_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser__audit { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifuser__audit_;// = 0L;
		
		/// <summary>
		/// FRM_UserQuestion's IFUser__audit.
		/// </summary>
		[XmlElement("IFUser__audit")]
		[SoapElement("IFUser__audit")]
		[DOPropertyAttribute(
			"IFUser__audit", 
			"", 
			"", 
			false, 
			false, 
			true, 
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
				return (long)((this.ifuser__audit_ == null) ? 0L : this.ifuser__audit_);
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
		#region public bool IFUser__audit_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_UserQuestion's IFUser__audit.
		/// </summary>
		[XmlElement("IFUser__audit_isNull")]
		[SoapElement("IFUser__audit_isNull")]
		public bool IFUser__audit_isNull {
			get { return (this.ifuser__audit_ == null); }
			set {
				//if (value) this.ifuser__audit_ = null;

				if ((value) && (this.ifuser__audit_ != null)) {
					this.ifuser__audit_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Date__audit { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object date__audit_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// FRM_UserQuestion's Date__audit.
		/// </summary>
		[XmlElement("Date__audit")]
		[SoapElement("Date__audit")]
		[DOPropertyAttribute(
			"Date__audit", 
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
		public DateTime Date__audit {
			get {
				return (DateTime)((this.date__audit_ == null) ? new DateTime(1900, 1, 1) : this.date__audit_);
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
		#region public bool Date__audit_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_UserQuestion's Date__audit.
		/// </summary>
		[XmlElement("Date__audit_isNull")]
		[SoapElement("Date__audit_isNull")]
		public bool Date__audit_isNull {
			get { return (this.date__audit_ == null); }
			set {
				//if (value) this.date__audit_ = null;

				if ((value) && (this.date__audit_ != null)) {
					this.date__audit_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_FRM_UserQuestion[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_ifuser = new DataColumn("IFUser", typeof(long));
			_output.Columns.Add(_dc_ifuser);
			DataColumn _dc_ifquestion = new DataColumn("IFQuestion", typeof(long));
			_output.Columns.Add(_dc_ifquestion);
			DataColumn _dc_answer = new DataColumn("Answer", typeof(string));
			_output.Columns.Add(_dc_answer);
			DataColumn _dc_ifuser__audit = new DataColumn("IFUser__audit", typeof(long));
			_output.Columns.Add(_dc_ifuser__audit);
			DataColumn _dc_date__audit = new DataColumn("Date__audit", typeof(DateTime));
			_output.Columns.Add(_dc_date__audit);

			foreach (SO_FRM_UserQuestion _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifuser] = _serializableObject.IFUser;
				_dr[_dc_ifquestion] = _serializableObject.IFQuestion;
				_dr[_dc_answer] = _serializableObject.Answer;
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
			this.ifuser_ = 0L;
			this.ifquestion_ = 0L;
			this.answer_ = string.Empty;
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
			info.AddValue("IFUser", this.ifuser_);
			info.AddValue("IFQuestion", this.ifquestion_);
			info.AddValue("Answer", this.answer_);
			info.AddValue("Answer_isNull", this.Answer_isNull);
			info.AddValue("IFUser__audit", this.ifuser__audit_);
			info.AddValue("IFUser__audit_isNull", this.IFUser__audit_isNull);
			info.AddValue("Date__audit", this.date__audit_);
			info.AddValue("Date__audit_isNull", this.Date__audit_isNull);
		}
		#endregion
		#endregion
	}
}