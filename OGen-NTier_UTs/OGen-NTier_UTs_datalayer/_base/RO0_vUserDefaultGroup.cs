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
	/// vUserDefaultGroup RecordObject which provides access to searches defined for vUserDefaultGroup table at Database.
	/// </summary>
	public sealed class RO0_vUserDefaultGroup : RO__base {
		#region internal RO0_vUserDefaultGroup();
		internal RO0_vUserDefaultGroup(
#if !NET_1_1
			DO_vUserDefaultGroup 
#else
			DO0_vUserDefaultGroup 
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
			DO_vUserDefaultGroup 
#else
			DO0_vUserDefaultGroup 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_vUserDefaultGroup Serialize();
		//public SC_vUserDefaultGroup Serialize() {
		//	return new SC_vUserDefaultGroup(Record);
		//}
		#endregion
		#region public SC_vUserDefaultGroup Serialize();
		public SC_vUserDefaultGroup Serialize() {
			SO_vUserDefaultGroup[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_vUserDefaultGroup[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_vUserDefaultGroup(
							parent_ref_.fields_.IDUser,
							parent_ref_.fields_.Login,
							parent_ref_.fields_.IDGroup,
							parent_ref_.fields_.Name,
							parent_ref_.fields_.Relationdate
						);
				}

				Current = _current;
			}

			SC_vUserDefaultGroup _serialize_out = new SC_vUserDefaultGroup();
			_serialize_out.SO_vUserDefaultGroup = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_vUserDefaultGroup serialisablecollection_in);
		public void Open(SC_vUserDefaultGroup serialisablecollection_in) {
			Open(serialisablecollection_in.SO_vUserDefaultGroup);
		}
		#endregion
		#region public void Open(SO_vUserDefaultGroup[] serialisableobject_in);
		public void Open(SO_vUserDefaultGroup[] serialisableobject_in) {
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
		/// Reads values from Record, assigns them to the appropriate vUserDefaultGroup DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["IDUser"] == System.DBNull.Value) {
					parent_ref_.fields_.iduser_ = 0L;
				} else {
					parent_ref_.fields_.iduser_ = (long)base.Record.Rows[Current]["IDUser"];
				}
				if (base.Record.Rows[Current]["Login"] == System.DBNull.Value) {
					parent_ref_.fields_.login_ = string.Empty;
				} else {
					parent_ref_.fields_.login_ = (string)base.Record.Rows[Current]["Login"];
				}
				if (base.Record.Rows[Current]["IDGroup"] == System.DBNull.Value) {
					parent_ref_.fields_.idgroup_ = 0L;
				} else {
					parent_ref_.fields_.idgroup_ = (long)base.Record.Rows[Current]["IDGroup"];
				}
				if (base.Record.Rows[Current]["Name"] == System.DBNull.Value) {
					parent_ref_.fields_.name_ = string.Empty;
				} else {
					parent_ref_.fields_.name_ = (string)base.Record.Rows[Current]["Name"];
				}
				if (base.Record.Rows[Current]["Relationdate"] == System.DBNull.Value) {
					parent_ref_.fields_.relationdate_ = new DateTime(1900, 1, 1);
				} else {
					parent_ref_.fields_.relationdate_ = (DateTime)base.Record.Rows[Current]["Relationdate"];
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
		#region public void ????_all
		#region public void Open_all(...);
		/// <summary>
		/// Opens Record, based on 'all' search. It selects vUserDefaultGroup values from Database based on the 'all' search and assigns them to the Record, opening it.
		/// </summary>
		public void Open_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};
			base.Open(
				"sp0_vUserDefaultGroup_Record_open_all_fullmode", 
				_dataparameters
			);
		}

		/// <summary>
		/// Opens Record, based on 'all' search. It selects vUserDefaultGroup values from Database based on the 'all' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_all(
			int page_in, 
			int page_numRecords_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
			};
			base.Open(
				"sp0_vUserDefaultGroup_Record_open_all_page_fullmode", 
				_dataparameters
			);
		}
		#endregion
		#region public bool hasObject_all(...);
		/// <summary>
		/// It selects vUserDefaultGroup values from Database based on the 'all' search and checks to see if vUserDefaultGroup Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDUser_in">vUserDefaultGroup's IDUser Key used for checking</param>
		/// <returns>True if vUserDefaultGroup Keys are met in the 'all' search, False if not</returns>
		public bool hasObject_all(
			long IDUser_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0)
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_vUserDefaultGroup_Record_hasObject_all", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_all(...);
		/// <summary>
		/// Count's number of search results from vUserDefaultGroup at Database based on the 'all' search.
		/// </summary>
		/// <returns>number of existing Records for the 'all' search</returns>
		public long Count_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_vUserDefaultGroup_Record_count_all", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion
		#endregion
		#endregion
	}
}