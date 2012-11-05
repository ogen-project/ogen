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
	/// vDIC_Language SerializableObject which provides fields access at vDIC_Language view at Database.
	/// </summary>
	[Serializable()]
	public class SO_vDIC_Language : 
		SO__ListItem<int, string>, ISerializable
	{
		#region public SO_vDIC_Language();
		public SO_vDIC_Language(
		) {
			this.Clear();
		}
		public SO_vDIC_Language(
			int IDLanguage_in, 
			int IDLanguage_translation_in, 
			string Language_in
		) {
			this.idlanguage_ = IDLanguage_in;
			this.idlanguage_translation_ = IDLanguage_translation_in;
			this.language_ = Language_in;

			this.haschanges_ = false;
		}
		protected SO_vDIC_Language(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idlanguage_ = (int)info.GetValue("IDLanguage", typeof(int));
			this.idlanguage_translation_ = (int)info.GetValue("IDLanguage_translation", typeof(int));
			this.language_ 
				= (info.GetValue("Language", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("Language", typeof(string));
			this.Language_isNull = (bool)info.GetValue("Language_isNull", typeof(bool));

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
		/// Indicates if changes have been made to FO0_vDIC_Language properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool hasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
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

		#region public int IDLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int idlanguage_;// = 0;
		
		/// <summary>
		/// vDIC_Language's IDLanguage.
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
		#region public int IDLanguage_translation { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int idlanguage_translation_;// = 0;
		
		/// <summary>
		/// vDIC_Language's IDLanguage_translation.
		/// </summary>
		[XmlElement("IDLanguage_translation")]
		[SoapElement("IDLanguage_translation")]
		[DOPropertyAttribute(
			"IDLanguage_translation", 
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
		public int IDLanguage_translation {
			get {
				return this.idlanguage_translation_;
			}
			set {
				if (
					(!value.Equals(this.idlanguage_translation_))
				) {
					this.idlanguage_translation_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Language { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object language_;// = string.Empty;
		
		/// <summary>
		/// vDIC_Language's Language.
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
		/// Allows assignement of null and check if null at vDIC_Language's Language.
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
			SO_vDIC_Language[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idlanguage = new DataColumn("IDLanguage", typeof(int));
			_output.Columns.Add(_dc_idlanguage);
			DataColumn _dc_idlanguage_translation = new DataColumn("IDLanguage_translation", typeof(int));
			_output.Columns.Add(_dc_idlanguage_translation);
			DataColumn _dc_language = new DataColumn("Language", typeof(string));
			_output.Columns.Add(_dc_language);

			foreach (SO_vDIC_Language _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idlanguage] = _serializableObject.IDLanguage;
				_dr[_dc_idlanguage_translation] = _serializableObject.IDLanguage_translation;
				_dr[_dc_language] = _serializableObject.Language;

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
			this.idlanguage_ = 0;
			this.idlanguage_translation_ = 0;
			this.language_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDLanguage", this.idlanguage_);
			info.AddValue("IDLanguage_translation", this.idlanguage_translation_);
			info.AddValue("Language", this.language_);
			info.AddValue("Language_isNull", this.Language_isNull);
		}
		#endregion
		#endregion
	}
}