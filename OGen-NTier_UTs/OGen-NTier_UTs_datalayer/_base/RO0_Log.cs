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
	/// Log RecordObject which provides access to searches defined for Log table at Database.
	/// </summary>
	public sealed class RO0_Log : RO__base {
		#region internal RO0_Log();
		internal RO0_Log(
#if !NET_1_1
			DO_Log 
#else
			DO0_Log 
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
			DO_Log 
#else
			DO0_Log 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_Log Serialize();
		//public SC_Log Serialize() {
		//	return new SC_Log(Record);
		//}
		#endregion
		#region public SC_Log Serialize();
		public SC_Log Serialize() {
			SO_Log[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_Log[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_Log(
							parent_ref_.fields_.IDLog,
							parent_ref_.fields_.IDLogcode,
							parent_ref_.fields_.IDUser_posted,
							parent_ref_.fields_.Date_posted,
							parent_ref_.fields_.Logdata
						);
				}

				Current = _current;
			}

			SC_Log _serialize_out = new SC_Log();
			_serialize_out.SO_Log = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_Log serialisablecollection_in);
		public void Open(SC_Log serialisablecollection_in) {
			Open(serialisablecollection_in.SO_Log);
		}
		#endregion
		#region public void Open(SO_Log[] serialisableobject_in);
		public void Open(SO_Log[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDLog"] = serialisableobject_in[i].IDLog;
				_datarow["IDLogcode"] = serialisableobject_in[i].IDLogcode;
				_datarow["IDUser_posted"] = serialisableobject_in[i].IDUser_posted;
				_datarow["Date_posted"] = serialisableobject_in[i].Date_posted;
				_datarow["Logdata"] = serialisableobject_in[i].Logdata;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate Log DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["IDLog"] == System.DBNull.Value) {
					parent_ref_.fields_.idlog_ = 0L;
				} else {
					parent_ref_.fields_.idlog_ = (long)base.Record.Rows[Current]["IDLog"];
				}
				if (base.Record.Rows[Current]["IDLogcode"] == System.DBNull.Value) {
					parent_ref_.fields_.idlogcode_ = 0L;
				} else {
					parent_ref_.fields_.idlogcode_ = (long)base.Record.Rows[Current]["IDLogcode"];
				}
				if (base.Record.Rows[Current]["IDUser_posted"] == System.DBNull.Value) {
					parent_ref_.fields_.iduser_posted_ = 0L;
				} else {
					parent_ref_.fields_.iduser_posted_ = (long)base.Record.Rows[Current]["IDUser_posted"];
				}
				if (base.Record.Rows[Current]["Date_posted"] == System.DBNull.Value) {
					parent_ref_.fields_.date_posted_ = new DateTime(1900, 1, 1);
				} else {
					parent_ref_.fields_.date_posted_ = (DateTime)base.Record.Rows[Current]["Date_posted"];
				}
				if (base.Record.Rows[Current]["Logdata"] == System.DBNull.Value) {
					parent_ref_.fields_.logdata_ = string.Empty;
				} else {
					parent_ref_.fields_.logdata_ = (string)base.Record.Rows[Current]["Logdata"];
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