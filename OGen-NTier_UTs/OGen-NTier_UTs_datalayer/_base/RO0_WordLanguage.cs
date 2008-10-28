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

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer.proxy;

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// WordLanguage RecordObject which provides access to searches defined for WordLanguage table at Database.
	/// </summary>
	public sealed class RO0_WordLanguage : RO__base {
		#region internal RO0_WordLanguage();
		internal RO0_WordLanguage(
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO_WordLanguage 
#else
			DO0_WordLanguage 
#endif
			parent_ref_in
		) : base(
			parent_ref_in
		) {
			parent_ref_ = parent_ref_in;
		}
		#endregion

		#region private Properties...
		private 
#if USE_PARTIAL_CLASSES && !NET_1_1
			DO_WordLanguage 
#else
			DO0_WordLanguage 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_WordLanguage Serialize();
		//public SC_WordLanguage Serialize() {
		//	return new SC_WordLanguage(Record);
		//}
		#endregion
		#region public SC_WordLanguage Serialize();
		public SC_WordLanguage Serialize() {
			SO_WordLanguage[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_WordLanguage[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_WordLanguage(
							parent_ref_.fields_.IDWord,
							parent_ref_.fields_.IDLanguage,
							parent_ref_.fields_.Translation
						);
				}

				Current = _current;
			}

			SC_WordLanguage _serialize_out = new SC_WordLanguage();
			_serialize_out.SO_WordLanguage = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_WordLanguage serialisablecollection_in);
		public void Open(SC_WordLanguage serialisablecollection_in) {
			Open(serialisablecollection_in.SO_WordLanguage);
		}
		#endregion
		#region public void Open(SO_WordLanguage[] serialisableobject_in);
		public void Open(SO_WordLanguage[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDWord"] = serialisableobject_in[i].IDWord;
				_datarow["IDLanguage"] = serialisableobject_in[i].IDLanguage;
				_datarow["Translation"] = serialisableobject_in[i].Translation;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate WordLanguage DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["IDWord"] == System.DBNull.Value) {
					parent_ref_.fields_.idword_ = 0L;
				} else {
					parent_ref_.fields_.idword_ = (long)base.Record.Rows[Current]["IDWord"];
				}
				if (base.Record.Rows[Current]["IDLanguage"] == System.DBNull.Value) {
					parent_ref_.fields_.idlanguage_ = 0L;
				} else {
					parent_ref_.fields_.idlanguage_ = (long)base.Record.Rows[Current]["IDLanguage"];
				}
				if (base.Record.Rows[Current]["Translation"] == System.DBNull.Value) {
					parent_ref_.fields_.Translation_isNull = true;
				} else {
					parent_ref_.fields_.translation_ = (string)base.Record.Rows[Current]["Translation"];
				}

				parent_ref_.fields_.haschanges_ = false;

				return true;
			} else {
				parent_ref_.clrObject();

				return false;
			}
		}
		#endregion
		//---
		#endregion
	}
}