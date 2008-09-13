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

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// Logcode RecordObject which provides access to searches defined for Logcode table at Database.
	/// </summary>
	public sealed class RO0_Logcode : RO__base {
		#region internal RO0_Logcode();
		internal RO0_Logcode(
#if !NET_1_1
			DO_Logcode 
#else
			DO0_Logcode 
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
#if !NET_1_1
			DO_Logcode 
#else
			DO0_Logcode 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC0_Logcode Serialize();
		//public SC0_Logcode Serialize() {
		//	return new SC0_Logcode(Record);
		//}
		#endregion
		#region public SC0_Logcode Serialize();
		public SC0_Logcode Serialize() {
			SO0_Logcode[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO0_Logcode[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO0_Logcode(
							parent_ref_.Fields.IDLogcode,
							parent_ref_.Fields.Warning,
							parent_ref_.Fields.Error,
							parent_ref_.Fields.Code,
							parent_ref_.Fields.Description
						);
				}

				Current = _current;
			}

			SC0_Logcode _serialize_out = new SC0_Logcode();
			_serialize_out.SO0_Logcode = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC0_Logcode serialisablecollection_in);
		public void Open(SC0_Logcode serialisablecollection_in) {
			Open(serialisablecollection_in.SO0_Logcode);
		}
		#endregion
		#region public void Open(SO0_Logcode[] serialisableobject_in);
		public void Open(SO0_Logcode[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDLogcode"] = serialisableobject_in[i].IDLogcode;
				_datarow["Warning"] = serialisableobject_in[i].Warning;
				_datarow["Error"] = serialisableobject_in[i].Error;
				_datarow["Code"] = serialisableobject_in[i].Code;
				_datarow["Description"] = serialisableobject_in[i].Description;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate Logcode DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["IDLogcode"] == System.DBNull.Value) {
					parent_ref_.Fields.idlogcode_ = 0L;
				} else {
					parent_ref_.Fields.idlogcode_ = (long)base.Record.Rows[Current]["IDLogcode"];
				}
				if (base.Record.Rows[Current]["Warning"] == System.DBNull.Value) {
					parent_ref_.Fields.warning_ = false;
				} else {
					parent_ref_.Fields.warning_ = (bool)base.Record.Rows[Current]["Warning"];
				}
				if (base.Record.Rows[Current]["Error"] == System.DBNull.Value) {
					parent_ref_.Fields.error_ = false;
				} else {
					parent_ref_.Fields.error_ = (bool)base.Record.Rows[Current]["Error"];
				}
				if (base.Record.Rows[Current]["Code"] == System.DBNull.Value) {
					parent_ref_.Fields.code_ = string.Empty;
				} else {
					parent_ref_.Fields.code_ = (string)base.Record.Rows[Current]["Code"];
				}
				if (base.Record.Rows[Current]["Description"] == System.DBNull.Value) {
					parent_ref_.Fields.Description_isNull = true;
				} else {
					parent_ref_.Fields.description_ = (string)base.Record.Rows[Current]["Description"];
				}

				parent_ref_.Fields.haschanges_ = false;

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