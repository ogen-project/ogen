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
	/// UserGroup RecordObject which provides access to searches defined for UserGroup table at Database.
	/// </summary>
	public sealed class RO0_UserGroup : RO__base {
		#region internal RO0_UserGroup();
		internal RO0_UserGroup(
#if !NET_1_1
			DO_UserGroup 
#else
			DO0_UserGroup 
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
			DO_UserGroup 
#else
			DO0_UserGroup 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC0_UserGroup Serialize();
		//public SC0_UserGroup Serialize() {
		//	return new SC0_UserGroup(Record);
		//}
		#endregion
		#region public SC0_UserGroup Serialize();
		public SC0_UserGroup Serialize() {
			SO0_UserGroup[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO0_UserGroup[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO0_UserGroup(
							parent_ref_.Fields.IDUser,
							parent_ref_.Fields.IDGroup,
							parent_ref_.Fields.Relationdate,
							parent_ref_.Fields.Defaultrelation
						);
				}

				Current = _current;
			}

			SC0_UserGroup _serialize_out = new SC0_UserGroup();
			_serialize_out.SO0_UserGroup = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC0_UserGroup serialisablecollection_in);
		public void Open(SC0_UserGroup serialisablecollection_in) {
			Open(serialisablecollection_in.SO0_UserGroup);
		}
		#endregion
		#region public void Open(SO0_UserGroup[] serialisableobject_in);
		public void Open(SO0_UserGroup[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDUser"] = serialisableobject_in[i].IDUser;
				_datarow["IDGroup"] = serialisableobject_in[i].IDGroup;
				_datarow["Relationdate"] = serialisableobject_in[i].Relationdate;
				_datarow["Defaultrelation"] = serialisableobject_in[i].Defaultrelation;

				_datatable.Rows.Add(_datarow);
			}

			Open(true, _datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate UserGroup DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			return Read(false);
		}

		/// <summary>
		/// Reads values from Record, assigns them to the appropriate UserGroup DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <param name="doNOTgetObject_in">do NOT get object: - if set to true, only PKs will be available for reading, you should be carefull (updates aren't advisable, other issues may occur)</param>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read(bool doNOTgetObject_in) {
			if (base.read()) {
				if (base.Fullmode) {
					if (base.Record.Rows[Current]["IDUser"] == System.DBNull.Value) {
						parent_ref_.Fields.iduser_ = 0L;
					} else {
						parent_ref_.Fields.iduser_ = (long)base.Record.Rows[Current]["IDUser"];
					}
					if (base.Record.Rows[Current]["IDGroup"] == System.DBNull.Value) {
						parent_ref_.Fields.idgroup_ = 0L;
					} else {
						parent_ref_.Fields.idgroup_ = (long)base.Record.Rows[Current]["IDGroup"];
					}
					if (base.Record.Rows[Current]["Relationdate"] == System.DBNull.Value) {
						parent_ref_.Fields.Relationdate_isNull = true;
					} else {
						parent_ref_.Fields.relationdate_ = (DateTime)base.Record.Rows[Current]["Relationdate"];
					}
					if (base.Record.Rows[Current]["Defaultrelation"] == System.DBNull.Value) {
						parent_ref_.Fields.Defaultrelation_isNull = true;
					} else {
						parent_ref_.Fields.defaultrelation_ = (bool)base.Record.Rows[Current]["Defaultrelation"];
					}

					parent_ref_.Fields.haschanges_ = false;
				} else {
					parent_ref_.Fields.IDUser = (long)((base.Record.Rows[Current]["IDUser"] == System.DBNull.Value) ? 0L : base.Record.Rows[Current]["IDUser"]);
					parent_ref_.Fields.IDGroup = (long)((base.Record.Rows[Current]["IDGroup"] == System.DBNull.Value) ? 0L : base.Record.Rows[Current]["IDGroup"]);

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
		#region public void ????_byUser_Defaultrelation
		#region public void Open_byUser_Defaultrelation(...);
		/// <summary>
		/// Opens Record, based on 'byUser_Defaultrelation' search. It selects UserGroup values from Database based on the 'byUser_Defaultrelation' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		public void Open_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in
		) {
			Open_byUser_Defaultrelation(
				IDUser_search_in, 
				Relationdate_search_in, 
				true
			);
		}

		/// <summary>
		/// Opens Record, based on 'byUser_Defaultrelation' search. It selects UserGroup values from Database based on the 'byUser_Defaultrelation' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		/// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		public void Open_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in, 
			bool fullmode_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_search_", DbType.DateTime, ParameterDirection.Input, Relationdate_search_in, 0)
			};
			base.Open(
				string.Format(
					"sp{0}_UserGroup_Record_open_byUser_Defaultrelation{1}", 
					fullmode_in ? "0" : "", 
					fullmode_in ? "_fullmode" : ""
				), 
				_dataparameters, 
				fullmode_in
			);
		}

		/// <summary>
		/// Opens Record, based on 'byUser_Defaultrelation' search. It selects UserGroup values from Database based on the 'byUser_Defaultrelation' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			Open_byUser_Defaultrelation(
				IDUser_search_in, 
				Relationdate_search_in, 
				true, 
				page_in, 
				page_numRecords_in
			);
		}

		/// <summary>
		/// Opens Record, based on 'byUser_Defaultrelation' search. It selects UserGroup values from Database based on the 'byUser_Defaultrelation' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		/// <param name="fullmode_in">Sets Record mode to Fullmode if True, or Not if False</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in, 
			bool fullmode_in, 
			int page_in, 
			int page_numRecords_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_search_", DbType.DateTime, ParameterDirection.Input, Relationdate_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
			};
			base.Open(
				string.Format(
					"sp0_UserGroup_Record_open_byUser_Defaultrelation_page{0}", 
					fullmode_in ? "_fullmode" : ""
				), 
				_dataparameters, 
				fullmode_in
			);
		}
		#endregion
		#region public bool Update_SomeUpdateTest_byUser_Defaultrelation(...);
		/// <summary>
		/// Updates (some) UserGroup values on Database based on the 'byUser_Defaultrelation' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		/// <param name="Relationdate_update_in">Relationdate update value</param>
		public void Update_SomeUpdateTest_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in, 
			object Relationdate_update_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_search_", DbType.DateTime, ParameterDirection.Input, Relationdate_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_update_", DbType.DateTime, ParameterDirection.Input, Relationdate_update_in, 0)
			};
			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_UserGroup_Record_update_SomeUpdateTest_byUser_Defaultrelation", 
				_dataparameters
			);
		}
		#endregion
		#region public bool hasObject_byUser_Defaultrelation(...);
		/// <summary>
		/// It selects UserGroup values from Database based on the 'byUser_Defaultrelation' search and checks to see if UserGroup Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDUser_in">UserGroup's IDUser Key used for checking</param>
		/// <param name="IDGroup_in">UserGroup's IDGroup Key used for checking</param>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		/// <returns>True if UserGroup Keys are met in the 'byUser_Defaultrelation' search, False if not</returns>
		public bool hasObject_byUser_Defaultrelation(
			long IDUser_in, 
			long IDGroup_in, 
			long IDUser_search_in, 
			object Relationdate_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0), 
				parent_ref_.Connection.newDBDataParameter("IDGroup_", DbType.Int64, ParameterDirection.Input, IDGroup_in, 0), 
				parent_ref_.Connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_search_", DbType.DateTime, ParameterDirection.Input, Relationdate_search_in, 0)
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_UserGroup_Record_hasObject_byUser_Defaultrelation", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_byUser_Defaultrelation(...);
		/// <summary>
		/// Count's number of search results from UserGroup at Database based on the 'byUser_Defaultrelation' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		/// <returns>number of existing Records for the 'byUser_Defaultrelation' search</returns>
		public long Count_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_search_", DbType.DateTime, ParameterDirection.Input, Relationdate_search_in, 0)
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_UserGroup_Record_count_byUser_Defaultrelation", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion
		#region public void Delete_byUser_Defaultrelation(...);
		/// <summary>
		/// Deletes UserGroup values from Database based on the 'byUser_Defaultrelation' search.
		/// </summary>
		/// <param name="IDUser_search_in">IDUser search condition</param>
		/// <param name="Relationdate_search_in">Relationdate search condition</param>
		public void Delete_byUser_Defaultrelation(
			long IDUser_search_in, 
			object Relationdate_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_search_", DbType.Int64, ParameterDirection.Input, IDUser_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Relationdate_search_", DbType.DateTime, ParameterDirection.Input, Relationdate_search_in, 0)
			};

			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_UserGroup_Record_delete_byUser_Defaultrelation", 
				_dataparameters
			);
		}
		#endregion
		#endregion
		#endregion
	}
}