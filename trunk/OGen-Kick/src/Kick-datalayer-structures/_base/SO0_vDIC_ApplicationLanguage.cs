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
	/// vDIC_ApplicationLanguage SerializableObject which provides fields access at vDIC_ApplicationLanguage view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vDIC_ApplicationLanguage : 
		SO__ListItem<int, string> 
	{
		#region public SO_vDIC_ApplicationLanguage();
		public SO_vDIC_ApplicationLanguage(
		) {
			this.Clear();
		}
		public SO_vDIC_ApplicationLanguage(
			int IFApplication_in, 
			int IDLanguage_in, 
			string Language_in
		) {
			this.haschanges_ = false;

			this.ifapplication_ = IFApplication_in;
			this.idlanguage_ = IDLanguage_in;
			this.language_ = Language_in;
		}
		public SO_vDIC_ApplicationLanguage(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			this.haschanges_ = false;

			this.ifapplication_ = (int)info_in.GetValue("IFApplication", typeof(int));
			this.idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			this.language_ 
				= (info_in.GetValue("Language", typeof(string)) == null)
					? string.Empty
					: (string)info_in.GetValue("Language", typeof(string));
			this.Language_isNull = (bool)info_in.GetValue("Language_isNull", typeof(bool));
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
			get { return this.haschanges_; }
		}
		#endregion

		#region public override int ListItem_Value { get; }
		public override int ListItem_Value {
			get {
				return this.idlanguage_;
			}
		}
		#endregion
		#region public override string ListItem_Text { get; }
		public override string ListItem_Text {
			get {
				return this.Language;
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
			true, 
			false, 
			0, 
			""
		)]
		public int IDLanguage {
			get {
				return this.idlanguage_;
			}
			set {
				if (
					(!value.Equals(this.idlanguage_))
				) {
					this.idlanguage_ = value;
					this.haschanges_ = true;
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
			true, 
			2147483647, 
			""
		)]
		public string Language {
			get {
				return (string)((this.language_ == null) ? string.Empty : this.language_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.language_))
				) {
					this.language_ = value;
					this.haschanges_ = true;
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
			get { return (this.language_ == null); }
			set {
				//if (value) this.language_ = null;

				if ((value) && (this.language_ != null)) {
					this.language_ = null;
					this.haschanges_ = true;
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
			this.haschanges_ = false;

			this.ifapplication_ = 0;
			this.idlanguage_ = 0;
			this.language_ = string.Empty;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IFApplication", this.ifapplication_);
			info_in.AddValue("IDLanguage", this.idlanguage_);
			info_in.AddValue("Language", this.language_);
			info_in.AddValue("Language_isNull", this.Language_isNull);
		}
		#endregion
		#endregion
	}
}