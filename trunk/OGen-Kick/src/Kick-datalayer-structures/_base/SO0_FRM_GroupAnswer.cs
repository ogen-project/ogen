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
	/// FRM_GroupAnswer SerializableObject which provides fields access at FRM_GroupAnswer table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_GroupAnswer : 
		ISerializable
	{
		#region public SO_FRM_GroupAnswer();
		public SO_FRM_GroupAnswer(
		) {
			this.Clear();
		}
		public SO_FRM_GroupAnswer(
			long IFGroup_in, 
			long IFAnswer_in, 
			int Order_in, 
			long IFUser__audit_in, 
			DateTime Date__audit_in
		) {
			this.ifgroup_ = IFGroup_in;
			this.ifanswer_ = IFAnswer_in;
			this.order_ = Order_in;
			this.ifuser__audit_ = IFUser__audit_in;
			this.date__audit_ = Date__audit_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_GroupAnswer(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifgroup_ = (long)info.GetValue("IFGroup", typeof(long));
			this.ifanswer_ = (long)info.GetValue("IFAnswer", typeof(long));
			this.order_ 
				= (info.GetValue("Order", typeof(int)) == null)
					? 0
					: (int)info.GetValue("Order", typeof(int));
			this.Order_isNull = (bool)info.GetValue("Order_isNull", typeof(bool));
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
		/// Indicates if changes have been made to FO0_FRM_GroupAnswer properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IFGroup { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifgroup_;// = 0L;
		
		/// <summary>
		/// FRM_GroupAnswer's IFGroup.
		/// </summary>
		[XmlElement("IFGroup")]
		[SoapElement("IFGroup")]
		[DOPropertyAttribute(
			"IFGroup", 
			"", 
			"", 
			true, 
			false, 
			false, 
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
		public long IFGroup {
			get {
				return this.ifgroup_;
			}
			set {
				if (
					(!value.Equals(this.ifgroup_))
				) {
					this.ifgroup_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFAnswer { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifanswer_;// = 0L;
		
		/// <summary>
		/// FRM_GroupAnswer's IFAnswer.
		/// </summary>
		[XmlElement("IFAnswer")]
		[SoapElement("IFAnswer")]
		[DOPropertyAttribute(
			"IFAnswer", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"FRM_Answer", 
			"IDAnswer", 
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
		public long IFAnswer {
			get {
				return this.ifanswer_;
			}
			set {
				if (
					(!value.Equals(this.ifanswer_))
				) {
					this.ifanswer_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int Order { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object order_;// = 0;
		
		/// <summary>
		/// FRM_GroupAnswer's Order.
		/// </summary>
		[XmlElement("Order")]
		[SoapElement("Order")]
		[DOPropertyAttribute(
			"Order", 
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
		public int Order {
			get {
				return (int)((this.order_ == null) ? 0 : this.order_);
			}
			set {
				if (
					(!value.Equals(this.order_))
				) {
					this.order_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Order_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_GroupAnswer's Order.
		/// </summary>
		[XmlElement("Order_isNull")]
		[SoapElement("Order_isNull")]
		public bool Order_isNull {
			get { return (this.order_ == null); }
			set {
				//if (value) this.order_ = null;

				if ((value) && (this.order_ != null)) {
					this.order_ = null;
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
		/// FRM_GroupAnswer's IFUser__audit.
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
		/// Allows assignement of null and check if null at FRM_GroupAnswer's IFUser__audit.
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
		/// FRM_GroupAnswer's Date__audit.
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
		/// Allows assignement of null and check if null at FRM_GroupAnswer's Date__audit.
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
			SO_FRM_GroupAnswer[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_ifgroup = new DataColumn("IFGroup", typeof(long));
			_output.Columns.Add(_dc_ifgroup);
			DataColumn _dc_ifanswer = new DataColumn("IFAnswer", typeof(long));
			_output.Columns.Add(_dc_ifanswer);
			DataColumn _dc_order = new DataColumn("Order", typeof(int));
			_output.Columns.Add(_dc_order);
			DataColumn _dc_ifuser__audit = new DataColumn("IFUser__audit", typeof(long));
			_output.Columns.Add(_dc_ifuser__audit);
			DataColumn _dc_date__audit = new DataColumn("Date__audit", typeof(DateTime));
			_output.Columns.Add(_dc_date__audit);

			foreach (SO_FRM_GroupAnswer _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifgroup] = _serializableObject.IFGroup;
				_dr[_dc_ifanswer] = _serializableObject.IFAnswer;
				_dr[_dc_order] = _serializableObject.Order;
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
			this.ifgroup_ = 0L;
			this.ifanswer_ = 0L;
			this.order_ = 0;
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
			info.AddValue("IFGroup", this.ifgroup_);
			info.AddValue("IFAnswer", this.ifanswer_);
			info.AddValue("Order", this.order_);
			info.AddValue("Order_isNull", this.Order_isNull);
			info.AddValue("IFUser__audit", this.ifuser__audit_);
			info.AddValue("IFUser__audit_isNull", this.IFUser__audit_isNull);
			info.AddValue("Date__audit", this.date__audit_);
			info.AddValue("Date__audit_isNull", this.Date__audit_isNull);
		}
		#endregion
		#endregion
	}
}