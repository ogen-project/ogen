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
using System.Xml.Serialization;
using System.Runtime.Serialization;

using OGen.NTier.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer.proxy {
	#region public interface ISO_Word;
	/// <summary>
	/// Interface for Word SerializableObject.
	/// </summary>
	public interface ISO_Word {
		/// <summary>
		/// Indicates if changes have been made to FO0_Word properties since last time getObject method was run.
		/// </summary>
		bool hasChanges { get; }

		/// <summary>
		/// Word's IDWord.
		/// </summary>
		long IDWord { get; set; }

		/// <summary>
		/// Word's DeleteThisTestField.
		/// </summary>
		bool DeleteThisTestField { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Word's DeleteThisTestField.
		/// </summary>
		bool DeleteThisTestField_isNull { get; set; }
	}
	#endregion

	/// <summary>
	/// Word SerializableObject which provides fields access at Word table at Database.
	/// </summary>
	[Serializable()]
	public class SO_Word : ISO_Word, ISerializable {
		#region public SO_Word();
		public SO_Word(
		) : this (
			0L, 
			false
		) {
		}
		public SO_Word(
			long IDWord_in, 
			bool DeleteThisTestField_in
		) {
			haschanges_ = false;

			idword_ = IDWord_in;
			deletethistestfield_ = DeleteThisTestField_in;
		}
		public SO_Word(
			SerializationInfo info_in,
			StreamingContext context_in
		) {
			haschanges_ = false;

			idword_ = (long)info_in.GetValue("IDWord", typeof(long));
			deletethistestfield_ = (bool)info_in.GetValue("DeleteThisTestField", typeof(bool));
			DeleteThisTestField_isNull = (bool)info_in.GetValue("DeleteThisTestField_isNull", typeof(bool));
		}
		#endregion

		#region Properties...
		#region public bool hasChanges { get; }
		[XmlIgnore()]
		[SoapIgnore()]
		public bool haschanges_;

		/// <summary>
		/// Indicates if changes have been made to FO0_Word properties since last time getObject method was run.
		/// </summary>
		[XmlIgnore()]
		[SoapIgnore()]
		public 
#if NET_1_1
			virtual 
#endif
		bool hasChanges {
			get { return haschanges_; }
		}
		#endregion
		//---
		#region public long IDWord { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public long idword_;// = 0L;
		
		/// <summary>
		/// Word's IDWord.
		/// </summary>
		[XmlElement("IDWord")]
		[SoapElement("IDWord")]
		[DOPropertyAttribute(
			"IDWord", 
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
		public 
#if NET_1_1
			virtual 
#endif
		long IDWord {
			get {
				return idword_;
			}
			set {
				if (
					(!value.Equals(idword_))
				) {
					idword_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool DeleteThisTestField { get; set; }
		[XmlIgnore()]
		[SoapIgnore()]
		public object deletethistestfield_;// = false;
		
		/// <summary>
		/// Word's DeleteThisTestField.
		/// </summary>
		[XmlElement("DeleteThisTestField")]
		[SoapElement("DeleteThisTestField")]
		[DOPropertyAttribute(
			"DeleteThisTestField", 
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
			true, 
			false, 
			false, 
			false, 
			false, 
			false, 
			false, 
			0, 
			""
		)]
		public 
#if NET_1_1
			virtual 
#endif
		bool DeleteThisTestField {
			get {
				return (bool)((deletethistestfield_ == null) ? false : deletethistestfield_);
			}
			set {
				if (
					(!value.Equals(deletethistestfield_))
				) {
					deletethistestfield_ = value;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#region public bool DeleteThisTestField_isNull { get; set; }
		/// <summary>
		/// Allows assignement of null and check if null at Word's DeleteThisTestField.
		/// </summary>
		[XmlElement("DeleteThisTestField_isNull")]
		[SoapElement("DeleteThisTestField_isNull")]
		public 
#if NET_1_1
			virtual 
#endif
		bool DeleteThisTestField_isNull {
			get { return (deletethistestfield_ == null); }
			set {
				//if (value) deletethistestfield_ = null;

				if ((value) && (deletethistestfield_ != null)) {
					deletethistestfield_ = null;
					haschanges_ = true;
				}
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void GetObjectData(SerializationInfo info_in, StreamingContext context_in);
		public void GetObjectData(SerializationInfo info_in, StreamingContext context_in) {
			info_in.AddValue("IDWord", idword_);
			info_in.AddValue("DeleteThisTestField", deletethistestfield_);
			info_in.AddValue("DeleteThisTestField_isNull", DeleteThisTestField_isNull);
		}
		#endregion
		#endregion
	}
}