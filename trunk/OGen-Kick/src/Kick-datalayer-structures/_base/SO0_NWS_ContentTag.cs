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
	/// NWS_ContentTag SerializableObject which provides fields access at NWS_ContentTag table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NWS_ContentTag : 
		ISerializable
	{
		#region public SO_NWS_ContentTag();
		public SO_NWS_ContentTag(
		) {
			this.Clear();
		}
		public SO_NWS_ContentTag(
			long IFContent_in, 
			long IFTag_in
		) {
			this.ifcontent_ = IFContent_in;
			this.iftag_ = IFTag_in;

			this.haschanges_ = false;
		}
		protected SO_NWS_ContentTag(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifcontent_ = (long)info.GetValue("IFContent", typeof(long));
			this.iftag_ = (long)info.GetValue("IFTag", typeof(long));

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
		/// Indicates if changes have been made to FO0_NWS_ContentTag properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IFContent { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifcontent_;// = 0L;
		
		/// <summary>
		/// NWS_ContentTag's IFContent.
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
		#region public long IFTag { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long iftag_;// = 0L;
		
		/// <summary>
		/// NWS_ContentTag's IFTag.
		/// </summary>
		[XmlElement("IFTag")]
		[SoapElement("IFTag")]
		[DOPropertyAttribute(
			"IFTag", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"NWS_Tag", 
			"IDTag", 
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
		public long IFTag {
			get {
				return this.iftag_;
			}
			set {
				if (
					(!value.Equals(this.iftag_))
				) {
					this.iftag_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NWS_ContentTag[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_ifcontent = new DataColumn("IFContent", typeof(long));
			_output.Columns.Add(_dc_ifcontent);
			DataColumn _dc_iftag = new DataColumn("IFTag", typeof(long));
			_output.Columns.Add(_dc_iftag);

			foreach (SO_NWS_ContentTag _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifcontent] = _serializableObject.IFContent;
				_dr[_dc_iftag] = _serializableObject.IFTag;

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
			this.ifcontent_ = 0L;
			this.iftag_ = 0L;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IFContent", this.ifcontent_);
			info.AddValue("IFTag", this.iftag_);
		}
		#endregion
		#endregion
	}
}