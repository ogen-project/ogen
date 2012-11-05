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
	/// NET_BrowserUser SerializableObject which provides fields access at NET_BrowserUser table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_BrowserUser : 
		ISerializable
	{
		#region public SO_NET_BrowserUser();
		public SO_NET_BrowserUser(
		) {
			this.Clear();
		}
		public SO_NET_BrowserUser(
			long IFBrowser_in, 
			long IFUser_in
		) {
			this.ifbrowser_ = IFBrowser_in;
			this.ifuser_ = IFUser_in;

			this.haschanges_ = false;
		}
		protected SO_NET_BrowserUser(
			SerializationInfo info,
			StreamingContext context
		) {
			this.ifbrowser_ = (long)info.GetValue("IFBrowser", typeof(long));
			this.ifuser_ = (long)info.GetValue("IFUser", typeof(long));

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
		/// Indicates if changes have been made to FO0_NET_BrowserUser properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IFBrowser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifbrowser_;// = 0L;
		
		/// <summary>
		/// NET_BrowserUser's IFBrowser.
		/// </summary>
		[XmlElement("IFBrowser")]
		[SoapElement("IFBrowser")]
		[DOPropertyAttribute(
			"IFBrowser", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"NET_Browser", 
			"IDBrowser", 
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
		public long IFBrowser {
			get {
				return this.ifbrowser_;
			}
			set {
				if (
					(!value.Equals(this.ifbrowser_))
				) {
					this.ifbrowser_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long ifuser_;// = 0L;
		
		/// <summary>
		/// NET_BrowserUser's IFUser.
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
			"NET_User", 
			"IFUser", 
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_BrowserUser[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_ifbrowser = new DataColumn("IFBrowser", typeof(long));
			_output.Columns.Add(_dc_ifbrowser);
			DataColumn _dc_ifuser = new DataColumn("IFUser", typeof(long));
			_output.Columns.Add(_dc_ifuser);

			foreach (SO_NET_BrowserUser _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifbrowser] = _serializableObject.IFBrowser;
				_dr[_dc_ifuser] = _serializableObject.IFUser;

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
			this.ifbrowser_ = 0L;
			this.ifuser_ = 0L;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IFBrowser", this.ifbrowser_);
			info.AddValue("IFUser", this.ifuser_);
		}
		#endregion
		#endregion
	}
}