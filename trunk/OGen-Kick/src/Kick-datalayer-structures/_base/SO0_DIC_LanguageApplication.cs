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
	/// DIC_LanguageApplication SerializableObject which provides fields access at DIC_LanguageApplication table at Database.
	/// </summary>
	[Serializable()]
	public class SO_DIC_LanguageApplication : 
		ISerializable
	{
		#region public SO_DIC_LanguageApplication();
		public SO_DIC_LanguageApplication(
		) {
			this.Clear();
		}
		public SO_DIC_LanguageApplication(
			int IFLanguage_in, 
			int IFApplication_in
		) {
			this.iflanguage_ = IFLanguage_in;
			this.ifapplication_ = IFApplication_in;

			this.haschanges_ = false;
		}
		protected SO_DIC_LanguageApplication(
			SerializationInfo info,
			StreamingContext context
		) {
			this.iflanguage_ = (int)info.GetValue("IFLanguage", typeof(int));
			this.ifapplication_ = (int)info.GetValue("IFApplication", typeof(int));

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
		/// Indicates if changes have been made to FO0_DIC_LanguageApplication properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public int IFLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int iflanguage_;// = 0;
		
		/// <summary>
		/// DIC_LanguageApplication's IFLanguage.
		/// </summary>
		[XmlElement("IFLanguage")]
		[SoapElement("IFLanguage")]
		[DOPropertyAttribute(
			"IFLanguage", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"DIC_Language", 
			"IDLanguage", 
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
		public int IFLanguage {
			get {
				return this.iflanguage_;
			}
			set {
				if (
					(!value.Equals(this.iflanguage_))
				) {
					this.iflanguage_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int ifapplication_;// = 0;
		
		/// <summary>
		/// DIC_LanguageApplication's IFApplication.
		/// </summary>
		[XmlElement("IFApplication")]
		[SoapElement("IFApplication")]
		[DOPropertyAttribute(
			"IFApplication", 
			"", 
			"", 
			true, 
			false, 
			false, 
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
				return this.ifapplication_;
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
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_DIC_LanguageApplication[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_iflanguage = new DataColumn("IFLanguage", typeof(int));
			_output.Columns.Add(_dc_iflanguage);
			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);

			foreach (SO_DIC_LanguageApplication _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iflanguage] = _serializableObject.IFLanguage;
				_dr[_dc_ifapplication] = _serializableObject.IFApplication;

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
			this.iflanguage_ = 0;
			this.ifapplication_ = 0;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IFLanguage", this.iflanguage_);
			info.AddValue("IFApplication", this.ifapplication_);
		}
		#endregion
		#endregion
	}
}