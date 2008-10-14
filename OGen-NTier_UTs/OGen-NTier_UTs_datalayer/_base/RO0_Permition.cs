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
	/// Permition RecordObject which provides access to searches defined for Permition table at Database.
	/// </summary>
	public sealed class RO0_Permition : RO__base {
		#region internal RO0_Permition();
		internal RO0_Permition(
#if !NET_1_1
			DO_Permition 
#else
			DO0_Permition 
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
			DO_Permition 
#else
			DO0_Permition 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_Permition Serialize();
		//public SC_Permition Serialize() {
		//	return new SC_Permition(Record);
		//}
		#endregion
		#region public SC_Permition Serialize();
		public SC_Permition Serialize() {
			SO_Permition[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_Permition[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_Permition(
							parent_ref_.Fields.IDPermition,
							parent_ref_.Fields.Name
						);
				}

				Current = _current;
			}

			SC_Permition _serialize_out = new SC_Permition();
			_serialize_out.SO_Permition = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_Permition serialisablecollection_in);
		public void Open(SC_Permition serialisablecollection_in) {
			Open(serialisablecollection_in.SO_Permition);
		}
		#endregion
		#region public void Open(SO_Permition[] serialisableobject_in);
		public void Open(SO_Permition[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDPermition"] = serialisableobject_in[i].IDPermition;
				_datarow["Name"] = serialisableobject_in[i].Name;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate Permition DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["IDPermition"] == System.DBNull.Value) {
					parent_ref_.Fields.idpermition_ = 0L;
				} else {
					parent_ref_.Fields.idpermition_ = (long)base.Record.Rows[Current]["IDPermition"];
				}
				if (base.Record.Rows[Current]["Name"] == System.DBNull.Value) {
					parent_ref_.Fields.name_ = string.Empty;
				} else {
					parent_ref_.Fields.name_ = (string)base.Record.Rows[Current]["Name"];
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