#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.Kick.lib.datalayer.shared.structures {
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
			Clear();
		}
		public SO_NWS_ContentHighlight(
			long IFContent_in, 
			long IFHighlight_in, 
			DateTime Begin_date_in, 
			DateTime End_date_in
		) {
			haschanges_ = false;

			ifcontent_ = IFContent_in;
			ifhighlight_ = IFHighlight_in;
			begin_date_ = Begin_date_in;
			end_date_ = End_date_in;
		}
		public SO_NWS_ContentHighlight(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			ifcontent_ = (long)info_in.GetValue("IFContent", typeof(long));
			ifhighlight_ = (long)info_in.GetValue("IFHighlight", typeof(long));
			begin_date_ 
				= (info_in.GetValue("Begin_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("Begin_date", typeof(DateTime));
			Begin_date_isNull = (bool)info_in.GetValue("Begin_date_isNull", typeof(bool));
			end_date_ 
				= (info_in.GetValue("End_date", typeof(DateTime)) == null)
					? new DateTime(1900, 1, 1)
					: (DateTime)info_in.GetValue("End_date", typeof(DateTime));
			End_date_isNull = (bool)info_in.GetValue("End_date_isNull", typeof(bool));
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
			get { return haschanges_; }
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
				return ifcontent_;
			}
			set {
				if (
					(!value.Equals(ifcontent_))
				) {
					ifcontent_ = value;
					haschanges_ = true;
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
				return ifhighlight_;
			}
			set {
				if (
					(!value.Equals(ifhighlight_))
				) {
					ifhighlight_ = value;
					haschanges_ = true;
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
				return (DateTime)((begin_date_ == null) ? new DateTime(1900, 1, 1) : begin_date_);
			}
			set {
				if (
					(!value.Equals(begin_date_))
				) {
					begin_date_ = value;
					haschanges_ = true;
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
			get { return (begin_date_ == null); }
			set {
				//if (value) begin_date_ = null;

				if ((value) && (begin_date_ != null)) {
					begin_date_ = null;
					haschanges_ = true;
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
				return (DateTime)((end_date_ == null) ? new DateTime(1900, 1, 1) : end_date_);
			}
			set {
				if (
					(!value.Equals(end_date_))
				) {
					end_date_ = value;
					haschanges_ = true;
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
			get { return (end_date_ == null); }
			set {
				//if (value) end_date_ = null;

				if ((value) && (end_date_ != null)) {
					end_date_ = null;
					haschanges_ = true;
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
			haschanges_ = false;

			ifcontent_ = 0L;
			ifhighlight_ = 0L;
			begin_date_ = new DateTime(1900, 1, 1);
			end_date_ = new DateTime(1900, 1, 1);
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFContent", ifcontent_);
			info_in.AddValue("IFHighlight", ifhighlight_);
			info_in.AddValue("Begin_date", begin_date_);
			info_in.AddValue("Begin_date_isNull", Begin_date_isNull);
			info_in.AddValue("End_date", end_date_);
			info_in.AddValue("End_date_isNull", End_date_isNull);
		}
		#endregion
		#endregion
	}
}