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
	/// DIC_TextLanguage SerializableObject which provides fields access at DIC_TextLanguage table at Database.
	/// </summary>
	[Serializable()]
	public class SO_DIC_TextLanguage : 
		ISerializable
	{
		#region public SO_DIC_TextLanguage();
		public SO_DIC_TextLanguage(
		) {
			this.Clear();
		}
		public SO_DIC_TextLanguage(
			long IFText_in, 
			int IFLanguage_in, 
			string Text__small_in, 
			string Text__large_in
		) {
			this.iftext_ = IFText_in;
			this.iflanguage_ = IFLanguage_in;
			this.text__small_ = Text__small_in;
			this.text__large_ = Text__large_in;

			this.haschanges_ = false;
		}
		protected SO_DIC_TextLanguage(
			SerializationInfo info,
			StreamingContext context
		) {
			this.iftext_ = (long)info.GetValue("IFText", typeof(long));
			this.iflanguage_ = (int)info.GetValue("IFLanguage", typeof(int));
			this.text__small_ 
				= (info.GetValue("Text__small", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Text__small", typeof(string));
			this.Text__small_isNull = (bool)info.GetValue("Text__small_isNull", typeof(bool));
			this.text__large_ 
				= (info.GetValue("Text__large", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Text__large", typeof(string));
			this.Text__large_isNull = (bool)info.GetValue("Text__large_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_DIC_TextLanguage properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public long IFText { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private long iftext_;// = 0L;
		
		/// <summary>
		/// DIC_TextLanguage's IFText.
		/// </summary>
		[XmlElement("IFText")]
		[SoapElement("IFText")]
		[DOPropertyAttribute(
			"IFText", 
			"", 
			"", 
			true, 
			false, 
			false, 
			"", 
			"DIC_Text", 
			"IDText", 
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
		public long IFText {
			get {
				return this.iftext_;
			}
			set {
				if (
					(!value.Equals(this.iftext_))
				) {
					this.iftext_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int iflanguage_;// = 0;
		
		/// <summary>
		/// DIC_TextLanguage's IFLanguage.
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
		#region public string Text__small { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object text__small_;// = string.Empty;
		
		/// <summary>
		/// DIC_TextLanguage's Text__small.
		/// </summary>
		[XmlElement("Text__small")]
		[SoapElement("Text__small")]
		[DOPropertyAttribute(
			"Text__small", 
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
			false, 
			false, 
			true, 
			false, 
			false, 
			8000, 
			""
		)]
		public string Text__small {
			get {
				return (string)((this.text__small_ == null) ? string.Empty : this.text__small_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.text__small_))
				) {
					this.text__small_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Text__small_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at DIC_TextLanguage's Text__small.
		/// </summary>
		[XmlElement("Text__small_isNull")]
		[SoapElement("Text__small_isNull")]
		public bool Text__small_isNull {
			get { return (this.text__small_ == null); }
			set {
				//if (value) this.text__small_ = null;

				if ((value) && (this.text__small_ != null)) {
					this.text__small_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Text__large { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object text__large_;// = string.Empty;
		
		/// <summary>
		/// DIC_TextLanguage's Text__large.
		/// </summary>
		[XmlElement("Text__large")]
		[SoapElement("Text__large")]
		[DOPropertyAttribute(
			"Text__large", 
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
			false, 
			false, 
			true, 
			false, 
			false, 
			2147483647, 
			""
		)]
		public string Text__large {
			get {
				return (string)((this.text__large_ == null) ? string.Empty : this.text__large_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.text__large_))
				) {
					this.text__large_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Text__large_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at DIC_TextLanguage's Text__large.
		/// </summary>
		[XmlElement("Text__large_isNull")]
		[SoapElement("Text__large_isNull")]
		public bool Text__large_isNull {
			get { return (this.text__large_ == null); }
			set {
				//if (value) this.text__large_ = null;

				if ((value) && (this.text__large_ != null)) {
					this.text__large_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_DIC_TextLanguage[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_iftext = new DataColumn("IFText", typeof(long));
			_output.Columns.Add(_dc_iftext);
			DataColumn _dc_iflanguage = new DataColumn("IFLanguage", typeof(int));
			_output.Columns.Add(_dc_iflanguage);
			DataColumn _dc_text__small = new DataColumn("Text__small", typeof(string));
			_output.Columns.Add(_dc_text__small);
			DataColumn _dc_text__large = new DataColumn("Text__large", typeof(string));
			_output.Columns.Add(_dc_text__large);

			foreach (SO_DIC_TextLanguage _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iftext] = _serializableObject.IFText;
				_dr[_dc_iflanguage] = _serializableObject.IFLanguage;
				_dr[_dc_text__small] = _serializableObject.Text__small;
				_dr[_dc_text__large] = _serializableObject.Text__large;

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
			this.iftext_ = 0L;
			this.iflanguage_ = 0;
			this.text__small_ = string.Empty;
			this.text__large_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IFText", this.iftext_);
			info.AddValue("IFLanguage", this.iflanguage_);
			info.AddValue("Text__small", this.text__small_);
			info.AddValue("Text__small_isNull", this.Text__small_isNull);
			info.AddValue("Text__large", this.text__large_);
			info.AddValue("Text__large_isNull", this.Text__large_isNull);
		}
		#endregion
		#endregion
	}
}