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
	/// DIC_Text SerializableObject which provides fields access at DIC_Text table at Database.
	/// </summary>
	[Serializable()]
	public class SO_DIC_Text : 
		SO__base 
	{
		#region public SO_DIC_Text();
		public SO_DIC_Text(
		) {
			Clear();
		}
		public SO_DIC_Text(
			long IDText_in, 
			int IFApplication_in, 
			int SourceTableField_ref_in
		) {
			haschanges_ = false;

			idtext_ = IDText_in;
			ifapplication_ = IFApplication_in;
			sourcetablefield_ref_ = SourceTableField_ref_in;
		}
		public SO_DIC_Text(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idtext_ = (long)info_in.GetValue("IDText", typeof(long));
			ifapplication_ 
				= (info_in.GetValue("IFApplication", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("IFApplication", typeof(int));
			IFApplication_isNull = (bool)info_in.GetValue("IFApplication_isNull", typeof(bool));
			sourcetablefield_ref_ 
				= (info_in.GetValue("SourceTableField_ref", typeof(int)) == null)
					? 0
					: (int)info_in.GetValue("SourceTableField_ref", typeof(int));
			SourceTableField_ref_isNull = (bool)info_in.GetValue("SourceTableField_ref_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_DIC_Text properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IDText { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long idtext_;// = 0L;
		
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
				return idtext_;
			}
			set {
				if (
					(!value.Equals(idtext_))
				) {
					idtext_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object ifapplication_;// = 0;
		
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
				return (int)((ifapplication_ == null) ? 0 : ifapplication_);
			}
			set {
				if (
					(!value.Equals(ifapplication_))
				) {
					ifapplication_ = value;
					haschanges_ = true;
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
			get { return (ifapplication_ == null); }
			set {
				//if (value) ifapplication_ = null;

				if ((value) && (ifapplication_ != null)) {
					ifapplication_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int SourceTableField_ref { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object sourcetablefield_ref_;// = 0;
		
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
				return (int)((sourcetablefield_ref_ == null) ? 0 : sourcetablefield_ref_);
			}
			set {
				if (
					(!value.Equals(sourcetablefield_ref_))
				) {
					sourcetablefield_ref_ = value;
					haschanges_ = true;
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
			get { return (sourcetablefield_ref_ == null); }
			set {
				//if (value) sourcetablefield_ref_ = null;

				if ((value) && (sourcetablefield_ref_ != null)) {
					sourcetablefield_ref_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_DIC_Text[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idtext = new DataColumn("IDText", typeof(long));
			_output.Columns.Add(_dc_idtext);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_sourcetablefield_ref = new DataColumn("SourceTableField_ref", typeof(int));
			_output.Columns.Add(_dc_sourcetablefield_ref);

			foreach (SO_DIC_Text _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idtext] = _serializableobject.IDText;
				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_sourcetablefield_ref] = _serializableobject.SourceTableField_ref;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idtext_ = 0L;
			ifapplication_ = 0;
			sourcetablefield_ref_ = 0;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDText", idtext_);
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IFApplication_isNull", IFApplication_isNull);
			info_in.AddValue("SourceTableField_ref", sourcetablefield_ref_);
			info_in.AddValue("SourceTableField_ref_isNull", SourceTableField_ref_isNull);
		}
		#endregion
		#endregion
	}
}