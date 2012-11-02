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
			string CharVar8000_in, 
			string Text_in
		) {
			this.iftext_ = IFText_in;
			this.iflanguage_ = IFLanguage_in;
			this.charvar8000_ = CharVar8000_in;
			this.text_ = Text_in;

			this.haschanges_ = false;
		}
		protected SO_DIC_TextLanguage(
			SerializationInfo info,
			StreamingContext context
		) {
			this.iftext_ = (long)info.GetValue("IFText", typeof(long));
			this.iflanguage_ = (int)info.GetValue("IFLanguage", typeof(int));
			this.charvar8000_ 
				= (info.GetValue("CharVar8000", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("CharVar8000", typeof(string));
			this.CharVar8000_isNull = (bool)info.GetValue("CharVar8000_isNull", typeof(bool));
			this.text_ 
				= (info.GetValue("Text", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Text", typeof(string));
			this.Text_isNull = (bool)info.GetValue("Text_isNull", typeof(bool));

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
		#region public string CharVar8000 { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object charvar8000_;// = string.Empty;
		
		/// <summary>
		/// DIC_TextLanguage's CharVar8000.
		/// </summary>
		[XmlElement("CharVar8000")]
		[SoapElement("CharVar8000")]
		[DOPropertyAttribute(
			"CharVar8000", 
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
		public string CharVar8000 {
			get {
				return (string)((this.charvar8000_ == null) ? string.Empty : this.charvar8000_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.charvar8000_))
				) {
					this.charvar8000_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool CharVar8000_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at DIC_TextLanguage's CharVar8000.
		/// </summary>
		[XmlElement("CharVar8000_isNull")]
		[SoapElement("CharVar8000_isNull")]
		public bool CharVar8000_isNull {
			get { return (this.charvar8000_ == null); }
			set {
				//if (value) this.charvar8000_ = null;

				if ((value) && (this.charvar8000_ != null)) {
					this.charvar8000_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Text { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object text_;// = string.Empty;
		
		/// <summary>
		/// DIC_TextLanguage's Text.
		/// </summary>
		[XmlElement("Text")]
		[SoapElement("Text")]
		[DOPropertyAttribute(
			"Text", 
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
		public string Text {
			get {
				return (string)((this.text_ == null) ? string.Empty : this.text_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.text_))
				) {
					this.text_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Text_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at DIC_TextLanguage's Text.
		/// </summary>
		[XmlElement("Text_isNull")]
		[SoapElement("Text_isNull")]
		public bool Text_isNull {
			get { return (this.text_ == null); }
			set {
				//if (value) this.text_ = null;

				if ((value) && (this.text_ != null)) {
					this.text_ = null;
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
			DataColumn _dc_charvar8000 = new DataColumn("CharVar8000", typeof(string));
			_output.Columns.Add(_dc_charvar8000);
			DataColumn _dc_text = new DataColumn("Text", typeof(string));
			_output.Columns.Add(_dc_text);

			foreach (SO_DIC_TextLanguage _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iftext] = _serializableObject.IFText;
				_dr[_dc_iflanguage] = _serializableObject.IFLanguage;
				_dr[_dc_charvar8000] = _serializableObject.CharVar8000;
				_dr[_dc_text] = _serializableObject.Text;

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
			this.charvar8000_ = string.Empty;
			this.text_ = string.Empty;

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
			info.AddValue("CharVar8000", this.charvar8000_);
			info.AddValue("CharVar8000_isNull", this.CharVar8000_isNull);
			info.AddValue("Text", this.text_);
			info.AddValue("Text_isNull", this.Text_isNull);
		}
		#endregion
		#endregion
	}
}