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
	/// NWS_ContentAuthor SerializableObject which provides fields access at NWS_ContentAuthor table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_ContentAuthor : 
		SO__base 
	{
		#region public SO_NWS_ContentAuthor();
		public SO_NWS_ContentAuthor(
		) {
			Clear();
		}
		public SO_NWS_ContentAuthor(
			long IFContent_in, 
			long IFAuthor_in
		) {
			haschanges_ = false;

			ifcontent_ = IFContent_in;
			ifauthor_ = IFAuthor_in;
		}
		public SO_NWS_ContentAuthor(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			ifcontent_ = (long)info_in.GetValue("IFContent", typeof(long));
			ifauthor_ = (long)info_in.GetValue("IFAuthor", typeof(long));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NWS_ContentAuthor properties since last time getObject method was run.
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
		/// NWS_ContentAuthor's IFContent.
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
		#region public long IFAuthor { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifauthor_;// = 0L;
		
		/// <summary>
		/// NWS_ContentAuthor's IFAuthor.
		/// </summary>
		[XmlElement("IFAuthor")]
		[SoapElement("IFAuthor")]
		[DOPropertyAttribute(
			"IFAuthor", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"NWS_Author", 
			"IDAuthor", 
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
		public long IFAuthor {
			get {
				return ifauthor_;
			}
			set {
				if (
					(!value.Equals(ifauthor_))
				) {
					ifauthor_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NWS_ContentAuthor[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_ifcontent = new DataColumn("IFContent", typeof(long));
			_output.Columns.Add(_dc_ifcontent);
			DataColumn _dc_ifauthor = new DataColumn("IFAuthor", typeof(long));
			_output.Columns.Add(_dc_ifauthor);

			foreach (SO_NWS_ContentAuthor _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifcontent] = _serializableobject.IFContent;
				_dr[_dc_ifauthor] = _serializableobject.IFAuthor;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			ifcontent_ = 0L;
			ifauthor_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFContent", ifcontent_);
			info_in.AddValue("IFAuthor", ifauthor_);
		}
		#endregion
		#endregion
	}
}