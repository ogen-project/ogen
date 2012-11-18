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
	/// FRM_Questiontype SerializableObject which provides fields access at FRM_Questiontype table at Database.
	/// </summary>
	[Serializable()]
	public class SO_FRM_Questiontype : 
		ISerializable
	{
		#region public SO_FRM_Questiontype();
		public SO_FRM_Questiontype(
		) {
			this.Clear();
		}
		public SO_FRM_Questiontype(
			int IDQuestiontype_in, 
			string Name_in, 
			string RegularExpression_in
		) {
			this.idquestiontype_ = IDQuestiontype_in;
			this.name_ = Name_in;
			this.regularexpression_ = RegularExpression_in;

			this.haschanges_ = false;
		}
		protected SO_FRM_Questiontype(
			SerializationInfo info,
			StreamingContext context
		) {
			this.idquestiontype_ = (int)info.GetValue("IDQuestiontype", typeof(int));
			this.name_ = (string)info.GetValue("Name", typeof(string));
			this.regularexpression_ 
				= (info.GetValue("RegularExpression", typeof(string)) == null)
					? string.Empty
					: (string)info.GetValue("RegularExpression", typeof(string));
			this.RegularExpression_isNull = (bool)info.GetValue("RegularExpression_isNull", typeof(bool));

			this.haschanges_ = false;
		}
		#endregion

		#region Properties...
		#region public bool HasChanges { get; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_FRM_Questiontype properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public bool HasChanges {
			get { return this.haschanges_; }
			set { this.haschanges_ = value; }
		}
		#endregion

		#region public int IDQuestiontype { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private int idquestiontype_;// = 0;
		
		/// <summary>
		/// FRM_Questiontype's IDQuestiontype.
		/// </summary>
		[XmlElement("IDQuestiontype")]
		[SoapElement("IDQuestiontype")]
		[DOPropertyAttribute(
			"IDQuestiontype", 
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
		public int IDQuestiontype {
			get {
				return this.idquestiontype_;
			}
			set {
				if (
					(!value.Equals(this.idquestiontype_))
				) {
					this.idquestiontype_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string Name { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private string name_;// = string.Empty;
		
		/// <summary>
		/// FRM_Questiontype's Name.
		/// </summary>
		[XmlElement("Name")]
		[SoapElement("Name")]
		[DOPropertyAttribute(
			"Name", 
			"", 
			"", 
			false, 
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
			false, 
			false, 
			true, 
			false, 
			false, 
			255, 
			""
		)]
		public string Name {
			get {
				return this.name_;
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.name_))
				) {
					this.name_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public string RegularExpression { get; set; }
		[NonSerialized()]
		[XmlIgnore()]
		[SoapIgnore()]
		private object regularexpression_;// = string.Empty;
		
		/// <summary>
		/// FRM_Questiontype's RegularExpression.
		/// </summary>
		[XmlElement("RegularExpression")]
		[SoapElement("RegularExpression")]
		[DOPropertyAttribute(
			"RegularExpression", 
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
			1024, 
			""
		)]
		public string RegularExpression {
			get {
				return (string)((this.regularexpression_ == null) ? string.Empty : this.regularexpression_);
			}
			set {
				if (
					(value != null)
					&&
					(!value.Equals(this.regularexpression_))
				) {
					this.regularexpression_ = value;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool RegularExpression_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at FRM_Questiontype's RegularExpression.
		/// </summary>
		[XmlElement("RegularExpression_isNull")]
		[SoapElement("RegularExpression_isNull")]
		public bool RegularExpression_isNull {
			get { return (this.regularexpression_ == null); }
			set {
				//if (value) this.regularexpression_ = null;

				if ((value) && (this.regularexpression_ != null)) {
					this.regularexpression_ = null;
					this.haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public static DataTable getDataTable(...);
		public static DataTable getDataTable(
			SO_FRM_Questiontype[] serializableObjects_in
		) {
			DataTable _output = new DataTable();
			_output.Locale = System.Globalization.CultureInfo.CurrentCulture;
			DataRow _dr;

			DataColumn _dc_idquestiontype = new DataColumn("IDQuestiontype", typeof(int));
			_output.Columns.Add(_dc_idquestiontype);
			DataColumn _dc_name = new DataColumn("Name", typeof(string));
			_output.Columns.Add(_dc_name);
			DataColumn _dc_regularexpression = new DataColumn("RegularExpression", typeof(string));
			_output.Columns.Add(_dc_regularexpression);

			foreach (SO_FRM_Questiontype _serializableObject in serializableObjects_in) {
				_dr = _output.NewRow();

				_dr[_dc_idquestiontype] = _serializableObject.IDQuestiontype;
				_dr[_dc_name] = _serializableObject.Name;
				_dr[_dc_regularexpression] = _serializableObject.RegularExpression;

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
			this.idquestiontype_ = 0;
			this.name_ = string.Empty;
			this.regularexpression_ = string.Empty;

			this.haschanges_ = false;
		}
		#endregion
		#region public virtual void GetObjectData(SerializationInfo info, StreamingContext context);
		[System.Security.Permissions.SecurityPermission(
			System.Security.Permissions.SecurityAction.LinkDemand,
			Flags = System.Security.Permissions.SecurityPermissionFlag.SerializationFormatter
		)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("IDQuestiontype", this.idquestiontype_);
			info.AddValue("Name", this.name_);
			info.AddValue("RegularExpression", this.regularexpression_);
			info.AddValue("RegularExpression_isNull", this.RegularExpression_isNull);
		}
		#endregion
		#endregion
	}
}