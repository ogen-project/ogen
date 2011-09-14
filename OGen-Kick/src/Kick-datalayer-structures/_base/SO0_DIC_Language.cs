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
	/// DIC_Language SerializableObject which provides fields access at DIC_Language table at Database.
	/// </summary>
	[Serializable()]
	public class SO_DIC_Language : 
		SO__base 
	{
		#region public SO_DIC_Language();
		public SO_DIC_Language(
		) {
			Clear();
		}
		public SO_DIC_Language(
			int IDLanguage_in, 
			long TX_Name_in
		) {
			haschanges_ = false;

			idlanguage_ = IDLanguage_in;
			tx_name_ = TX_Name_in;
		}
		public SO_DIC_Language(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idlanguage_ = (int)info_in.GetValue("IDLanguage", typeof(int));
			tx_name_ = (long)info_in.GetValue("TX_Name", typeof(long));
		}
		#endregion

		#region Properties...
		#region public override bool hasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_DIC_Language properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public override bool hasChanges {
			get { return haschanges_; }
		}
		#endregion

		#region public int IDLanguage { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public int idlanguage_;// = 0;
		
		/// <summary>
		/// DIC_Language's IDLanguage.
		/// </summary>
		[XmlElement("IDLanguage")]
		[SoapElement("IDLanguage")]
		[DOPropertyAttribute(
			"IDLanguage", 
			"", 
			"", 
			true, 
			true, 
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
		#region public long TX_Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		public long tx_name_;// = 0L;
		
		/// <summary>
		/// DIC_Language's TX_Name.
		/// </summary>
		[XmlElement("TX_Name")]
		[SoapElement("TX_Name")]
		[DOPropertyAttribute(
			"TX_Name", 
			"", 
			"", 
			false, 
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
		public long TX_Name {
			get {
				return tx_name_;
			}
			set {
				if (
					(!value.Equals(tx_name_))
				) {
					tx_name_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_DIC_Language[] serializableobjects_in
		) {
			DataTable _output = new DataTable();
			DataRow _dr;

			DataColumn _dc_idlanguage = new DataColumn("IDLanguage", typeof(int));
			_output.Columns.Add(_dc_idlanguage);
			DataColumn _dc_tx_name = new DataColumn("TX_Name", typeof(long));
			_output.Columns.Add(_dc_tx_name);

			foreach (SO_DIC_Language _serializableobject in serializableobjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idlanguage] = _serializableobject.IDLanguage;
				_dr[_dc_tx_name] = _serializableobject.TX_Name;

				_output.Rows.Add(_dr);
			}

			return _output;
		}
		#endregion
		#region public override void Clear();
		public override void Clear() {
			haschanges_ = false;

			idlanguage_ = 0;
			tx_name_ = 0L;
		}
		#endregion
		#region public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public override void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDLanguage", idlanguage_);
			info_in.AddValue("TX_Name", tx_name_);
		}
		#endregion
		#endregion
	}
}