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
		#region //public SC0_Permition Serialize();
		//public SC0_Permition Serialize() {
		//	return new SC0_Permition(Record);
		//}
		#endregion
		#region public SC0_Permition Serialize();
		public SC0_Permition Serialize() {
			SO0_Permition[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO0_Permition[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO0_Permition(
							parent_ref_.Fields.IDPermition,
							parent_ref_.Fields.Name
						);
				}

				Current = _current;
			}

			SC0_Permition _serialize_out = new SC0_Permition();
			_serialize_out.SO0_Permition = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC0_Permition serialisablecollection_in);
		public void Open(SC0_Permition serialisablecollection_in) {
			Open(serialisablecollection_in.SO0_Permition);
		}
		#endregion
		#region public void Open(SO0_Permition[] serialisableobject_in);
		public void Open(SO0_Permition[] serialisableobject_in) {
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

			Open(true, _datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate Permition DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			return Read(false);
		}

		/// <summary>
		/// Reads values from Record, assigns them to the appropriate Permition DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <param name="doNOTgetObject_in">do NOT get object: - if set to true, only PKs will be available for reading, you should be carefull (updates aren't advisable, other issues may occur)</param>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read(bool doNOTgetObject_in) {
			if (base.read()) {
				if (base.Fullmode) {
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
				} else {
					parent_ref_.Fields.IDPermition = (long)((base.Record.Rows[Current]["IDPermition"] == System.DBNull.Value) ? 0L : base.Record.Rows[Current]["IDPermition"]);

					if (!doNOTgetObject_in) {
						parent_ref_.getObject();
					}
				}

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