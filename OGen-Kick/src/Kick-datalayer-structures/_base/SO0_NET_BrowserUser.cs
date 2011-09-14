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
	/// NET_BrowserUser SerializableObject which provides fields access at NET_BrowserUser table at Database.
	/// </summary>
	[Serializable()]
	public class SO_NET_BrowserUser : 
		SO__base 
	{
		#region public SO_NET_BrowserUser();
		public SO_NET_BrowserUser(
		) {
			Clear();
		}
		public SO_NET_BrowserUser(
			long IFBrowser_in, 
			long IFUser_in
		) {
			haschanges_ = false;

			ifbrowser_ = IFBrowser_in;
			ifuser_ = IFUser_in;
		}
		public SO_NET_BrowserUser(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			ifbrowser_ = (long)info_in.GetValue("IFBrowser", typeof(long));
			ifuser_ = (long)info_in.GetValue("IFUser", typeof(long));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_NET_BrowserUser properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IFBrowser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifbrowser_;// = 0L;
		
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
				return ifbrowser_;
			}
			set {
				if (
					(!value.Equals(ifbrowser_))
				) {
					ifbrowser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public long IFUser { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long ifuser_;// = 0L;
		
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
				return ifuser_;
			}
			set {
				if (
					(!value.Equals(ifuser_))
				) {
					ifuser_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_NET_BrowserUser[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_ifbrowser = new DataColumn("IFBrowser", typeof(long));
			_output.Columns.Add(_dc_ifbrowser);
			DataColumn _dc_ifuser = new DataColumn("IFUser", typeof(long));
			_output.Columns.Add(_dc_ifuser);

			foreach (SO_NET_BrowserUser _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifbrowser] = _serializableobject.IFBrowser;
				_dr[_dc_ifuser] = _serializableobject.IFUser;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			ifbrowser_ = 0L;
			ifuser_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFBrowser", ifbrowser_);
			info_in.AddValue("IFUser", ifuser_);
		}
		#endregion
		#endregion
	}
}