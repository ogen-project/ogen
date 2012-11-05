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
	/// CRD_Permission SerializableObject which provides fields access at CRD_Permission table at Database.
	/// </summary>
	[Serializable()]
	public class SO_CRD_Permission : 
		SO__ListItem<long, string>, ISerializable
	{
		#region public SO_CRD_Permission();
		public SO_CRD_Permission(
		) {
			this.Clear();
		}
		public SO_CRD_Permission(
			long IDPermission_in, 
			string Name_in, 
			int IFApplication_in, 
			long IFTable_in, 
			long IFAction_in
		) {
			this.idpermission_ = IDPermission_in;
			this.name_ = Name_in;
			this.ifapplication_ = IFApplication_in;
			this.iftable_ = IFTable_in;
			this.ifaction_ = IFAction_in;

			this.haschanges_ = false;
		}
		protected SO_CRD_Permission(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idpermission_ = (long)info.GetValue("IDPermission", typeof(long));
			this.name_ = (string)info.GetValue("Name", typeof(string));
			this.ifapplication_ 
				= (info.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info.GetValue("IFApplication", typeof(int));
			this.IFApplication_isNull = (bool)info.GetValue("IFApplication_isNull", typeof(bool));
			this.iftable_ 
				= (info.GetValue("IFTable", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFTable", typeof(long));
			this.IFTable_isNull = (bool)info.GetValue("IFTable_isNull", typeof(bool));
			this.ifaction_ 
				= (info.GetValue("IFAction", typeof(long)) == null)
					? 0L
					: (long)info.GetValue("IFAction", typeof(long));
			this.IFAction_isNull = (bool)info.GetValue("IFAction_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_CRD_Permission properties since last time getObject method was run.
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
				return this.idpermission_;
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

		#region public long IDPermission { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long idpermission_;// = 0L;
		
		/// <summary>
		/// CRD_Permission's IDPermission.
		/// </summary>
		[XmlElement("IDPermission")]
		[SoapElement("IDPermission")]
		[DOPropertyAttribute(
			"IDPermission", 
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
		public long IDPermission {
			get {
				return this.idpermission_;
			}
			set {
				if (
					(!value.Equals(this.idpermission_))
				) {
					this.idpermission_ = value;
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
		/// CRD_Permission's Name.
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
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifapplication_;// = 0;
		
		/// <summary>
		/// CRD_Permission's IFApplication.
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
		/// Allows assignement of null and check if null at CRD_Permission's IFApplication.
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
		#region public long IFTable { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object iftable_;// = 0L;
		
		/// <summary>
		/// CRD_Permission's IFTable.
		/// </summary>
		[XmlElement("IFTable")]
		[SoapElement("IFTable")]
		[DOPropertyAttribute(
			"IFTable", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"CRD_Table", 
			"IDTable", 
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
		public long IFTable {
			get {
				return (long)((this.iftable_ == null) ? 0L : this.iftable_);
			}
			set {
				if (
					(!value.Equals(this.iftable_))
				) {
					this.iftable_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFTable_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at CRD_Permission's IFTable.
		/// </summary>
		[XmlElement("IFTable_isNull")]
		[SoapElement("IFTable_isNull")]
		public bool IFTable_isNull {
			get { return (this.iftable_ == null); }
			set {
				//if (value) this.iftable_ = null;

				if ((value) && (this.iftable_ != null)) {
					this.iftable_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFAction { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object ifaction_;// = 0L;
		
		/// <summary>
		/// CRD_Permission's IFAction.
		/// </summary>
		[XmlElement("IFAction")]
		[SoapElement("IFAction")]
		[DOPropertyAttribute(
			"IFAction", 
			"", 
			"", 
			false, 
			false, 
			true, 
			"", 
			"CRD_Action", 
			"IDAction", 
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
		public long IFAction {
			get {
				return (long)((this.ifaction_ == null) ? 0L : this.ifaction_);
			}
			set {
				if (
					(!value.Equals(this.ifaction_))
				) {
					this.ifaction_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool IFAction_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at CRD_Permission's IFAction.
		/// </summary>
		[XmlElement("IFAction_isNull")]
		[SoapElement("IFAction_isNull")]
		public bool IFAction_isNull {
			get { return (this.ifaction_ == null); }
			set {
				//if (value) this.ifaction_ = null;

				if ((value) && (this.ifaction_ != null)) {
					this.ifaction_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_CRD_Permission[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idpermission = new DataColumn("IDPermission", typeof(long));
			_output.Columns.Add(_dc_idpermission);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_iftable = new DataColumn("IFTable", typeof(long));
			_output.Columns.Add(_dc_iftable);
			DataColumn _dc_ifaction = new DataColumn("IFAction", typeof(long));
			_output.Columns.Add(_dc_ifaction);

			foreach (SO_CRD_Permission _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idpermission] = _serializableObject.IDPermission;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;
				_dr[_dc_iftable] = _serializableObject.IFTable;
				_dr[_dc_ifaction] = _serializableObject.IFAction;

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
			this.idpermission_ = 0L;
			this.name_ = string.Empty;
			this.ifapplication_ = 0;
			this.iftable_ = 0L;
			this.ifaction_ = 0L;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDPermission", this.idpermission_);
			info.AddValue("Name", this.name_);
			info.AddValue("IFApplication", this.ifapplication_);
			info.AddValue("IFApplication_isNull", this.IFApplication_isNull);
			info.AddValue("IFTable", this.iftable_);
			info.AddValue("IFTable_isNull", this.IFTable_isNull);
			info.AddValue("IFAction", this.ifaction_);
			info.AddValue("IFAction_isNull", this.IFAction_isNull);
		}
		#endregion
		#endregion
	}
}