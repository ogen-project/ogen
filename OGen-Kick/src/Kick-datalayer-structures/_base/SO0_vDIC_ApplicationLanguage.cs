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
	/// vDIC_ApplicationLanguage SerializableObject which provides fields access at vDIC_ApplicationLanguage view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vDIC_ApplicationLanguage : 
		SO__ListItem<int, int> 
	{
		#region public SO_vDIC_ApplicationLanguage();
		public SO_vDIC_ApplicationLanguage(
		) {
			Clear();
		}
		public SO_vDIC_ApplicationLanguage(
			int IFApplication_in, 
			int IDLanguage_in, 
			string Language_in
		) {
			haschanges_ = false;

			ifapplication_ = IFApplication_in;
			idlanguage_ = IDLanguage_in;
			language_ = Language_in;
		}
		public SO_vDIC_ApplicationLanguage(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			ifapplication_ = (int)info_in.GetValue("IFApplication", typeof(int));
			idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			language_ 
				= (info_in.GetValue("Language", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Language", typeof(string));
			Language_isNull = (bool)info_in.GetValue("Language_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_vDIC_ApplicationLanguage properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public override int ListItem_Value { get; }
		public override int ListItem_Value {
			get {
				return ifapplication_;
			}
		}
		#endregion
		#region public override int ListItem_Text { get; }
		public override int ListItem_Text {
			get {
				return idlanguage_;
			}
		} 
		#endregion

		#region public int IFApplication { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int ifapplication_;// = 0;
		
		/// <summary>
		/// vDIC_ApplicationLanguage's IFApplication.
		/// </summary>
		[XmlElement("IFApplication")]
		[SoapElement("IFApplication")]
		[DOPropertyAttribute(
			"IFApplication", 
			"", 
			"", 
			true, 
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
			true, 
			false, 
			0, 
			""
		)]
		public int IFApplication {
			get {
				return ifapplication_;
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
		#region public int IDLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int idlanguage_;// = 0;
		
		/// <summary>
		/// vDIC_ApplicationLanguage's IDLanguage.
		/// </summary>
		[XmlElement("IDLanguage")]
		[SoapElement("IDLanguage")]
		[DOPropertyAttribute(
			"IDLanguage", 
			"", 
			"", 
			true, 
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
			true, 
			0, 
			""
		)]
		public int IDLanguage {
			get {
				return idlanguage_;
			}
			set {
				if (
					(!value.Equals(idlanguage_))
				) {
					idlanguage_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Language { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public object language_;// = string.Empty;
		
		/// <summary>
		/// vDIC_ApplicationLanguage's Language.
		/// </summary>
		[XmlElement("Language")]
		[SoapElement("Language")]
		[DOPropertyAttribute(
			"Language", 
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
		public string Language {
			get {
				return (string)((language_ == null) ? string.Empty : language_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(language_))
				) {
					language_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool Language_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at vDIC_ApplicationLanguage's Language.
		/// </summary>
		[XmlElement("Language_isNull")]
		[SoapElement("Language_isNull")]
		public bool Language_isNull {
			get { return (language_ == null); }
			set {
				//if (value) language_ = null;

				if ((value) && (language_ != null)) {
					language_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_vDIC_ApplicationLanguage[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_ifapplication = new DataColumn("IFApplication", typeof(int));
			_output.Columns.Add(_dc_ifapplication);
			DataColumn _dc_idlanguage = new DataColumn("IDLanguage", typeof(int));
			_output.Columns.Add(_dc_idlanguage);
			DataColumn _dc_language = new DataColumn("Language", typeof(string));
			_output.Columns.Add(_dc_language);

			foreach (SO_vDIC_ApplicationLanguage _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_ifapplication] = _serializableobject.IFApplication;
				_dr[_dc_idlanguage] = _serializableobject.IDLanguage;
				_dr[_dc_language] = _serializableobject.Language;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			ifapplication_ = 0;
			idlanguage_ = 0;
			language_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFApplication", ifapplication_);
			info_in.AddValue("IDLanguage", idlanguage_);
			info_in.AddValue("Language", language_);
			info_in.AddValue("Language_isNull", Language_isNull);
		}
		#endregion
		#endregion
	}
}