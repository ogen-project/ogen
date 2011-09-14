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
	/// DIC_TextLanguage SerializableObject which provides fields access at DIC_TextLanguage table at Database.
	/// </summary>
	[Serializable()]
	public class SO_DIC_TextLanguage : 
		SO__base 
	{
		#region public SO_DIC_TextLanguage();
		public SO_DIC_TextLanguage(
		) {
			Clear();
		}
		public SO_DIC_TextLanguage(
			long IFText_in, 
			int IFLanguage_in, 
			string CharVar8000_in, 
			string Text_in
		) {
			haschanges_ = false;

			iftext_ = IFText_in;
			iflanguage_ = IFLanguage_in;
			charvar8000_ = CharVar8000_in;
			text_ = Text_in;
		}
		public SO_DIC_TextLanguage(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			iftext_ = (long)info_in.GetValue("IFText", typeof(long));
			iflanguage_ = (int)info_in.GetValue("IFLanguage", typeof(int));
			charvar8000_ 
				= (info_in.GetValue("CharVar8000", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("CharVar8000", typeof(string));
			CharVar8000_isNull = (bool)info_in.GetValue("CharVar8000_isNull", typeof(bool));
			text_ 
				= (info_in.GetValue("Text", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Text", typeof(string));
			Text_isNull = (bool)info_in.GetValue("Text_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_DIC_TextLanguage properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public long IFText { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long iftext_;// = 0L;
		
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
				return iftext_;
			}
			set {
				if (
					(!value.Equals(iftext_))
				) {
					iftext_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public int IFLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int iflanguage_;// = 0;
		
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
				return iflanguage_;
			}
			set {
				if (
					(!value.Equals(iflanguage_))
				) {
					iflanguage_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string CharVar8000 { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object charvar8000_;// = string.Empty;
		
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
				return (string)((charvar8000_ == null) ? string.Empty : charvar8000_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(charvar8000_))
				) {
					charvar8000_ = value;
					haschanges_ = true;
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
			get { return (charvar8000_ == null); }
			set {
				//if (value) charvar8000_ = null;

				if ((value) && (charvar8000_ != null)) {
					charvar8000_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Text { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object text_;// = string.Empty;
		
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
			0, 
			""
		)]
		public string Text {
			get {
				return (string)((text_ == null) ? string.Empty : text_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(text_))
				) {
					text_ = value;
					haschanges_ = true;
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
			get { return (text_ == null); }
			set {
				//if (value) text_ = null;

				if ((value) && (text_ != null)) {
					text_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_DIC_TextLanguage[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_iftext = new DataColumn("IFText", typeof(long));
			_output.Columns.Add(_dc_iftext);
			DataColumn _dc_iflanguage = new DataColumn("IFLanguage", typeof(int));
			_output.Columns.Add(_dc_iflanguage);
			DataColumn _dc_charvar8000 = new DataColumn("CharVar8000", typeof(string));
			_output.Columns.Add(_dc_charvar8000);
			DataColumn _dc_text = new DataColumn("Text", typeof(string));
			_output.Columns.Add(_dc_text);

			foreach (SO_DIC_TextLanguage _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_iftext] = _serializableobject.IFText;
				_dr[_dc_iflanguage] = _serializableobject.IFLanguage;
				_dr[_dc_charvar8000] = _serializableobject.CharVar8000;
				_dr[_dc_text] = _serializableobject.Text;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			iftext_ = 0L;
			iflanguage_ = 0;
			charvar8000_ = string.Empty;
			text_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFText", iftext_);
			info_in.AddValue("IFLanguage", iflanguage_);
			info_in.AddValue("CharVar8000", charvar8000_);
			info_in.AddValue("CharVar8000_isNull", CharVar8000_isNull);
			info_in.AddValue("Text", text_);
			info_in.AddValue("Text_isNull", Text_isNull);
		}
		#endregion
		#endregion
	}
}