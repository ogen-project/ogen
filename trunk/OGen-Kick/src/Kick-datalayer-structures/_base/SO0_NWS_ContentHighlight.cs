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
	/// NWS_ContentHighlight SerializableObject which provides fields access at NWS_ContentHighlight table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_ContentHighlight : 
		SO__base 
	{
		#region public SO_NWS_ContentHighlight();
		public SO_NWS_ContentHighlight(
		) {
			this.Clear();
		}
		public SO_NWS_ContentHighlight(
			long IFContent_in, 
			long IFHighlight_in, 
			DateTime Begin_date_in, 
			DateTime End_date_in
		) {
			this.haschanges_ = false;

			this.ifcontent_ = IFContent_in;
			this.ifhighlight_ = IFHighlight_in;
			this.begin_date_ = Begin_date_in;
			this.end_date_ = End_date_in;
		}
		public SO_NWS_ContentHighlight(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			this.haschanges_ = false;

			this.ifcontent_ = (long)info_in.GetValue("IFContent", typeof(long));
			this.ifhighlight_ = (long)info_in.GetValue("IFHighlight", typeof(long));
			this.begin_date_ 
				= (info_in.GetValue("Begin_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Begin_date", typeof(DateTime));
			this.Begin_date_isNull = (bool)info_in.GetValue("Begin_date_isNull", typeof(bool));
			this.end_date_ 
				= (info_in.GetValue("End_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("End_date", typeof(DateTime));
			this.End_date_isNull = (bool)info_in.GetValue("End_date_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NWS_ContentHighlight properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return this.haschanges_; }
		}
		#endregion

		#region public long IFContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifcontent_;// = 0L;
		
		/// <summary>
		/// NWS_ContentHighlight's IFContent.
		/// </summary>
		[XmlElement("IFContent")]
		[SoapElement("IFContent")]
		[DOPropertyAttribute(
			"IFContent", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"NWS_Content", 
			"IDContent", 
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
		public long IFContent {
			get {
				return this.ifcontent_;
			}
			set {
				if (
					(!value.Equals(this.ifcontent_))
				) {
					this.ifcontent_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFHighlight { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifhighlight_;// = 0L;
		
		/// <summary>
		/// NWS_ContentHighlight's IFHighlight.
		/// </summary>
		[XmlElement("IFHighlight")]
		[SoapElement("IFHighlight")]
		[DOPropertyAttribute(
			"IFHighlight", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"NWS_Highlight", 
			"IDHighlight", 
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
		public long IFHighlight {
			get {
				return this.ifhighlight_;
			}
			set {
				if (
					(!value.Equals(this.ifhighlight_))
				) {
					this.ifhighlight_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime Begin_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object begin_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// NWS_ContentHighlight's Begin_date.
		/// </summary>
		[XmlElement("Begin_date")]
		[SoapElement("Begin_date")]
		[DOPropertyAttribute(
			"Begin_date", 
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
		public DateTime Begin_date {
			get {
				return (DateTime)((this.begin_date_ == null) ? new DateTime(1900, 1, 1) : this.begin_date_);
			}
			set {
				if (
					(!value.Equals(this.begin_date_))
				) {
					this.begin_date_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Begin_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_ContentHighlight's Begin_date.
		/// </summary>
		[XmlElement("Begin_date_isNull")]
		[SoapElement("Begin_date_isNull")]
		public bool Begin_date_isNull {
			get { return (this.begin_date_ == null); }
			set {
				//if (value) this.begin_date_ = null;

				if ((value) && (this.begin_date_ != null)) {
					this.begin_date_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public DateTime End_date { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object end_date_;// = new DateTime(1900, 1, 1);
		
		/// <summary>
		/// NWS_ContentHighlight's End_date.
		/// </summary>
		[XmlElement("End_date")]
		[SoapElement("End_date")]
		[DOPropertyAttribute(
			"End_date", 
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
		public DateTime End_date {
			get {
				return (DateTime)((this.end_date_ == null) ? new DateTime(1900, 1, 1) : this.end_date_);
			}
			set {
				if (
					(!value.Equals(this.end_date_))
				) {
					this.end_date_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool End_date_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at NWS_ContentHighlight's End_date.
		/// </summary>
		[XmlElement("End_date_isNull")]
		[SoapElement("End_date_isNull")]
		public bool End_date_isNull {
			get { return (this.end_date_ == null); }
			set {
				//if (value) this.end_date_ = null;

				if ((value) && (this.end_date_ != null)) {
					this.end_date_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NWS_ContentHighlight[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_ifcontent = new DataColumn("IFContent", typeof(long));
			_output.Columns.Add(_dc_ifcontent);
			DataColumn _dc_ifhighlight = new DataColumn("IFHighlight", typeof(long));
			_output.Columns.Add(_dc_ifhighlight);
			DataColumn _dc_begin_date = new DataColumn("Begin_date", typeof(DateTime));
			_output.Columns.Add(_dc_begin_date);
			DataColumn _dc_end_date = new DataColumn("End_date", typeof(DateTime));
			_output.Columns.Add(_dc_end_date);

			foreach (SO_NWS_ContentHighlight _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifcontent] = _serializableobject.IFContent;
				_dr[_dc_ifhighlight] = _serializableobject.IFHighlight;
				_dr[_dc_begin_date] = _serializableobject.Begin_date;
				_dr[_dc_end_date] = _serializableobject.End_date;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			this.haschanges_ = false;

			this.ifcontent_ = 0L;
			this.ifhighlight_ = 0L;
			this.begin_date_ = new DateTime(1900, 1, 1);
			this.end_date_ = new DateTime(1900, 1, 1);
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFContent", this.ifcontent_);
			info_in.AddValue("IFHighlight", this.ifhighlight_);
			info_in.AddValue("Begin_date", this.begin_date_);
			info_in.AddValue("Begin_date_isNull", this.Begin_date_isNull);
			info_in.AddValue("End_date", this.end_date_);
			info_in.AddValue("End_date_isNull", this.End_date_isNull);
		}
		#endregion
		#endregion
	}
}