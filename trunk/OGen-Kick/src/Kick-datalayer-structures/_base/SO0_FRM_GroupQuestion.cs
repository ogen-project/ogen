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
	/// FRM_GroupQuestion SerializableObject which provides fields access at FRM_GroupQuestion table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_GroupQuestion : 
		ISerializable
	{
		#region public SO_FRM_GroupQuestion();
		public SO_FRM_GroupQuestion(
		) {
			this.Clear();
		}
		public SO_FRM_GroupQuestion(
			long IFGroup_in, 
			long IFQuestion_in, 
			int Order_in, 
			long IFUser__audit_in, 
			DateTime Date__audit_in
		) {
			this.ifgroup_ = IFGroup_in;
			this.ifquestion_ = IFQuestion_in;
			this.order_ = Order_in;
			this.ifuser__audit_ = IFUser__audit_in;
			this.date__audit_ = Date__audit_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_GroupQuestion(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifgroup_ = (long)info.GetValue("IFGroup", typeof(long));
			this.ifquestion_ = (long)info.GetValue("IFQuestion", typeof(long));
			this.order_ 
				= (info.GetValue("Order", typeof(int)) == null)
					? 0
					: (int)info.GetValue("Order", typeof(int));
			this.Order_isNull = (bool)info.GetValue("Order_isNull", typeof(bool));
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
		/// Indicates if changes have been made to FO0_FRM_GroupQuestion properties since last time getObject method was run.
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
		/// FRM_GroupQuestion's IFGroup.
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
		#region public long IFQuestion { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifquestion_;// = 0L;
		
		/// <summary>
		/// FRM_GroupQuestion's IFQuestion.
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
		#region public int Order { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object order_;// = 0;
		
		/// <summary>
		/// FRM_GroupQuestion's Order.
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
		/// Allows assignement of null and check if null at FRM_GroupQuestion's Order.
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
		private long ifuser__audit_;// = 0L;
		
		/// <summary>
		/// FRM_GroupQuestion's IFUser__audit.
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
		/// FRM_GroupQuestion's Date__audit.
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
			SO_FRM_GroupQuestion[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_ifgroup = new DataColumn("IFGroup", typeof(long));
			_output.Columns.Add(_dc_ifgroup);
			DataColumn _dc_ifquestion = new DataColumn("IFQuestion", typeof(long));
			_output.Columns.Add(_dc_ifquestion);
			DataColumn _dc_order = new DataColumn("Order", typeof(int));
			_output.Columns.Add(_dc_order);
			DataColumn _dc_ifuser__audit = new DataColumn("IFUser__audit", typeof(long));
			_output.Columns.Add(_dc_ifuser__audit);
			DataColumn _dc_date__audit = new DataColumn("Date__audit", typeof(DateTime));
			_output.Columns.Add(_dc_date__audit);

			foreach (SO_FRM_GroupQuestion _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifgroup] = _serializableObject.IFGroup;
				_dr[_dc_ifquestion] = _serializableObject.IFQuestion;
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
			this.ifquestion_ = 0L;
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
			info.AddValue("IFQuestion", this.ifquestion_);
			info.AddValue("Order", this.order_);
			info.AddValue("Order_isNull", this.Order_isNull);
			info.AddValue("IFUser__audit", this.ifuser__audit_);
			info.AddValue("Date__audit", this.date__audit_);
		}
		#endregion
		#endregion
	}
}