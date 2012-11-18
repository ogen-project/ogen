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
	/// FRM_Group SerializableObject which provides fields access at FRM_Group table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_Group : 
		ISerializable
	{
		#region public SO_FRM_Group();
		public SO_FRM_Group(
		) {
			this.Clear();
		}
		public SO_FRM_Group(
			long IDGroup_in, 
			long IFGroup__parent_in, 
			long TX_Title_in, 
			long TX_Description_in, 
			bool IsTemplate_in, 
			bool GroupAnswers_in, 
			int IFApplication_in, 
			long IFUser__audit_in, 
			DateTime Date__audit_in
		) {
			this.idgroup_ = IDGroup_in;
			this.ifgroup__parent_ = IFGroup__parent_in;
			this.tx_title_ = TX_Title_in;
			this.tx_description_ = TX_Description_in;
			this.istemplate_ = IsTemplate_in;
			this.groupanswers_ = GroupAnswers_in;
			this.ifapplication_ = IFApplication_in;
			this.ifuser__audit_ = IFUser__audit_in;
			this.date__audit_ = Date__audit_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_Group(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idgroup_ = (long)info.GetValue("IDGroup", typeof(long));
			this.ifgroup__parent_ 
				= (info.GetValue("IFGroup__parent", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFGroup__parent", typeof(long));
			this.IFGroup__parent_isNull = (bool)info.GetValue("IFGroup__parent_isNull", typeof(bool));
			this.tx_title_ 
				= (info.GetValue("TX_Title", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Title", typeof(long));
			this.TX_Title_isNull = (bool)info.GetValue("TX_Title_isNull", typeof(bool));
			this.tx_description_ 
				= (info.GetValue("TX_Description", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("TX_Description", typeof(long));
			this.TX_Description_isNull = (bool)info.GetValue("TX_Description_isNull", typeof(bool));
			this.istemplate_ 
				= (info.GetValue("IsTemplate", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("IsTemplate", typeof(bool));
			this.IsTemplate_isNull = (bool)info.GetValue("IsTemplate_isNull", typeof(bool));
			this.groupanswers_ 
				= (info.GetValue("GroupAnswers", typeof(bool)) == null)
					? false
					: (bool)info.GetValue("GroupAnswers", typeof(bool));
			this.GroupAnswers_isNull = (bool)info.GetValue("GroupAnswers_isNull", typeof(bool));
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
		/// Indicates if changes have been made to FO0_FRM_Group properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IDGroup { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idgroup_;// = 0L;
		
		/// <summary>
		/// FRM_Group's IDGroup.
		/// </summary>
		[XmlElement("IDGroup")]
		[SoapElement("IDGroup")]
		[DOPropertyAttribute(
			"IDGroup", 
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
		public long IDGroup {
			get {
				return this.idgroup_;
			}
			set {
				if (
					(!value.Equals(this.idgroup_))
				) {
					this.idgroup_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFGroup__parent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifgroup__parent_;// = 0L;
		
		/// <summary>
		/// FRM_Group's IFGroup__parent.
		/// </summary>
		[XmlElement("IFGroup__parent")]
		[SoapElement("IFGroup__parent")]
		[DOPropertyAttribute(
			"IFGroup__parent", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"FRM_Group", 
			"IDGroup", 
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
		public long IFGroup__parent {
			get {
				return (long)((this.ifgroup__parent_ == null) ? 0L : this.ifgroup__parent_);
			}
			set {
				if (
					(!value.Equals(this.ifgroup__parent_))
				) {
					this.ifgroup__parent_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFGroup__parent_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Group's IFGroup__parent.
		/// </summary>
		[XmlElement("IFGroup__parent_isNull")]
		[SoapElement("IFGroup__parent_isNull")]
		public bool IFGroup__parent_isNull {
			get { return (this.ifgroup__parent_ == null); }
			set {
				//if (value) this.ifgroup__parent_ = null;

				if ((value) && (this.ifgroup__parent_ != null)) {
					this.ifgroup__parent_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long TX_Title { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object tx_title_;// = 0L;
		
		/// <summary>
		/// FRM_Group's TX_Title.
		/// </summary>
		[XmlElement("TX_Title")]
		[SoapElement("TX_Title")]
		[DOPropertyAttribute(
			"TX_Title", 
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
		public long TX_Title {
			get {
				return (long)((this.tx_title_ == null) ? 0L : this.tx_title_);
			}
			set {
				if (
					(!value.Equals(this.tx_title_))
				) {
					this.tx_title_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool TX_Title_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Group's TX_Title.
		/// </summary>
		[XmlElement("TX_Title_isNull")]
		[SoapElement("TX_Title_isNull")]
		public bool TX_Title_isNull {
			get { return (this.tx_title_ == null); }
			set {
				//if (value) this.tx_title_ = null;

				if ((value) && (this.tx_title_ != null)) {
					this.tx_title_ = null;
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
		/// FRM_Group's TX_Description.
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
		/// Allows assignement of null and check if null at FRM_Group's TX_Description.
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
		#region public bool IsTemplate { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object istemplate_;// = false;
		
		/// <summary>
		/// FRM_Group's IsTemplate.
		/// </summary>
		[XmlElement("IsTemplate")]
		[SoapElement("IsTemplate")]
		[DOPropertyAttribute(
			"IsTemplate", 
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
		public bool IsTemplate {
			get {
				return (bool)((this.istemplate_ == null) ? false : this.istemplate_);
			}
			set {
				if (
					(!value.Equals(this.istemplate_))
				) {
					this.istemplate_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IsTemplate_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Group's IsTemplate.
		/// </summary>
		[XmlElement("IsTemplate_isNull")]
		[SoapElement("IsTemplate_isNull")]
		public bool IsTemplate_isNull {
			get { return (this.istemplate_ == null); }
			set {
				//if (value) this.istemplate_ = null;

				if ((value) && (this.istemplate_ != null)) {
					this.istemplate_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool GroupAnswers { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object groupanswers_;// = false;
		
		/// <summary>
		/// FRM_Group's GroupAnswers.
		/// </summary>
		[XmlElement("GroupAnswers")]
		[SoapElement("GroupAnswers")]
		[DOPropertyAttribute(
			"GroupAnswers", 
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
		public bool GroupAnswers {
			get {
				return (bool)((this.groupanswers_ == null) ? false : this.groupanswers_);
			}
			set {
				if (
					(!value.Equals(this.groupanswers_))
				) {
					this.groupanswers_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool GroupAnswers_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Group's GroupAnswers.
		/// </summary>
		[XmlElement("GroupAnswers_isNull")]
		[SoapElement("GroupAnswers_isNull")]
		public bool GroupAnswers_isNull {
			get { return (this.groupanswers_ == null); }
			set {
				//if (value) this.groupanswers_ = null;

				if ((value) && (this.groupanswers_ != null)) {
					this.groupanswers_ = null;
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
		/// FRM_Group's IFApplication.
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
		/// Allows assignement of null and check if null at FRM_Group's IFApplication.
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
		/// FRM_Group's IFUser__audit.
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
		/// FRM_Group's Date__audit.
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
			SO_FRM_Group[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idgroup = new DataColumn("IDGroup", typeof(long));
			_output.Columns.Add(_dc_idgroup);
			DataColumn _dc_ifgroup__parent = new DataColumn("IFGroup__parent", typeof(long));
			_output.Columns.Add(_dc_ifgroup__parent);
			DataColumn _dc_tx_title = new DataColumn("TX_Title", typeof(long));
			_output.Columns.Add(_dc_tx_title);
			DataColumn _dc_tx_description = new DataColumn("TX_Description", typeof(long));
			_output.Columns.Add(_dc_tx_description);
			DataColumn _dc_istemplate = new DataColumn("IsTemplate", typeof(bool));
			_output.Columns.Add(_dc_istemplate);
			DataColumn _dc_groupanswers = new DataColumn("GroupAnswers", typeof(bool));
			_output.Columns.Add(_dc_groupanswers);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_ifuser__audit = new DataColumn("IFUser__audit", typeof(long));
			_output.Columns.Add(_dc_ifuser__audit);
			DataColumn _dc_date__audit = new DataColumn("Date__audit", typeof(DateTime));
			_output.Columns.Add(_dc_date__audit);

			foreach (SO_FRM_Group _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idgroup] = _serializableObject.IDGroup;
				_dr[_dc_ifgroup__parent] = _serializableObject.IFGroup__parent;
				_dr[_dc_tx_title] = _serializableObject.TX_Title;
				_dr[_dc_tx_description] = _serializableObject.TX_Description;
				_dr[_dc_istemplate] = _serializableObject.IsTemplate;
				_dr[_dc_groupanswers] = _serializableObject.GroupAnswers;
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
			this.idgroup_ = 0L;
			this.ifgroup__parent_ = 0L;
			this.tx_title_ = 0L;
			this.tx_description_ = 0L;
			this.istemplate_ = false;
			this.groupanswers_ = false;
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
			info.AddValue("IDGroup", this.idgroup_);
			info.AddValue("IFGroup__parent", this.ifgroup__parent_);
			info.AddValue("IFGroup__parent_isNull", this.IFGroup__parent_isNull);
			info.AddValue("TX_Title", this.tx_title_);
			info.AddValue("TX_Title_isNull", this.TX_Title_isNull);
			info.AddValue("TX_Description", this.tx_description_);
			info.AddValue("TX_Description_isNull", this.TX_Description_isNull);
			info.AddValue("IsTemplate", this.istemplate_);
			info.AddValue("IsTemplate_isNull", this.IsTemplate_isNull);
			info.AddValue("GroupAnswers", this.groupanswers_);
			info.AddValue("GroupAnswers_isNull", this.GroupAnswers_isNull);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("IFUser__audit", this.ifuser__audit_);
			info.AddValue("Date__audit", this.date__audit_);
		}
		#endregion
		#endregion
	}
}