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
	/// vUserGroup RecordObject which provides access to searches defined for vUserGroup table at Database.
	/// </summary>
	public sealed class RO0_vUserGroup : RO__base {
		#region internal RO0_vUserGroup();
		internal RO0_vUserGroup(
#if !NET_1_1
			DO_vUserGroup 
#else
			DO0_vUserGroup 
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
			DO_vUserGroup 
#else
			DO0_vUserGroup 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_vUserGroup Serialize();
		//public SC_vUserGroup Serialize() {
		//	return new SC_vUserGroup(Record);
		//}
		#endregion
		#region public SC_vUserGroup Serialize();
		public SC_vUserGroup Serialize() {
			SO_vUserGroup[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_vUserGroup[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_vUserGroup(
							parent_ref_.Fields.IDUser,
							parent_ref_.Fields.Login,
							parent_ref_.Fields.IDGroup,
							parent_ref_.Fields.Name,
							parent_ref_.Fields.Relationdate
						);
				}

				Current = _current;
			}

			SC_vUserGroup _serialize_out = new SC_vUserGroup();
			_serialize_out.SO_vUserGroup = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_vUserGroup serialisablecollection_in);
		public void Open(SC_vUserGroup serialisablecollection_in) {
			Open(serialisablecollection_in.SO_vUserGroup);
		}
		#endregion
		#region public void Open(SO_vUserGroup[] serialisableobject_in);
		public void Open(SO_vUserGroup[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDUser"] = serialisableobject_in[i].IDUser;
				_datarow["Login"] = serialisableobject_in[i].Login;
				_datarow["IDGroup"] = serialisableobject_in[i].IDGroup;
				_datarow["Name"] = serialisableobject_in[i].Name;
				_datarow["Relationdate"] = serialisableobject_in[i].Relationdate;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate vUserGroup DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["IDUser"] == System.DBNull.Value) {
					parent_ref_.Fields.iduser_ = 0L;
				} else {
					parent_ref_.Fields.iduser_ = (long)base.Record.Rows[Current]["IDUser"];
				}
				if (base.Record.Rows[Current]["Login"] == System.DBNull.Value) {
					parent_ref_.Fields.login_ = string.Empty;
				} else {
					parent_ref_.Fields.login_ = (string)base.Record.Rows[Current]["Login"];
				}
				if (base.Record.Rows[Current]["IDGroup"] == System.DBNull.Value) {
					parent_ref_.Fields.idgroup_ = 0L;
				} else {
					parent_ref_.Fields.idgroup_ = (long)base.Record.Rows[Current]["IDGroup"];
				}
				if (base.Record.Rows[Current]["Name"] == System.DBNull.Value) {
					parent_ref_.Fields.name_ = string.Empty;
				} else {
					parent_ref_.Fields.name_ = (string)base.Record.Rows[Current]["Name"];
				}
				if (base.Record.Rows[Current]["Relationdate"] == System.DBNull.Value) {
					parent_ref_.Fields.relationdate_ = new DateTime(1900, 1, 1);
				} else {
					parent_ref_.Fields.relationdate_ = (DateTime)base.Record.Rows[Current]["Relationdate"];
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