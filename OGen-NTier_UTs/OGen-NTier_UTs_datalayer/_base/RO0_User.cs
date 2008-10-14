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
	/// User RecordObject which provides access to searches defined for User table at Database.
	/// </summary>
	public sealed class RO0_User : RO__base {
		#region internal RO0_User();
		internal RO0_User(
#if !NET_1_1
			DO_User 
#else
			DO0_User 
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
			DO_User 
#else
			DO0_User 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC_User Serialize();
		//public SC_User Serialize() {
		//	return new SC_User(Record);
		//}
		#endregion
		#region public SC_User Serialize();
		public SC_User Serialize() {
			SO_User[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO_User[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO_User(
							parent_ref_.Fields.IDUser,
							parent_ref_.Fields.Login,
							parent_ref_.Fields.Password,
							parent_ref_.Fields.SomeNullValue
						);
				}

				Current = _current;
			}

			SC_User _serialize_out = new SC_User();
			_serialize_out.SO_User = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC_User serialisablecollection_in);
		public void Open(SC_User serialisablecollection_in) {
			Open(serialisablecollection_in.SO_User);
		}
		#endregion
		#region public void Open(SO_User[] serialisableobject_in);
		public void Open(SO_User[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["IDUser"] = serialisableobject_in[i].IDUser;
				_datarow["Login"] = serialisableobject_in[i].Login;
				_datarow["Password"] = serialisableobject_in[i].Password;
				_datarow["SomeNullValue"] = serialisableobject_in[i].SomeNullValue;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate User DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
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
				if (base.Record.Rows[Current]["Password"] == System.DBNull.Value) {
					parent_ref_.Fields.password_ = string.Empty;
				} else {
					parent_ref_.Fields.password_ = (string)base.Record.Rows[Current]["Password"];
				}
				if (base.Record.Rows[Current]["SomeNullValue"] == System.DBNull.Value) {
					parent_ref_.Fields.SomeNullValue_isNull = true;
				} else {
					parent_ref_.Fields.somenullvalue_ = (int)base.Record.Rows[Current]["SomeNullValue"];
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
		#region public void ????_all
		#region public void Open_all(...);
		/// <summary>
		/// Opens Record, based on 'all' search. It selects User values from Database based on the 'all' search and assigns them to the Record, opening it.
		/// </summary>
		public void Open_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};
			base.Open(
				"sp0_User_Record_open_all_fullmode", 
				_dataparameters
			);
		}

		/// <summary>
		/// Opens Record, based on 'all' search. It selects User values from Database based on the 'all' search and assigns them to the Record, opening it.
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
				"sp0_User_Record_open_all_page_fullmode", 
				_dataparameters
			);
		}
		#endregion
		#region public bool hasObject_all(...);
		/// <summary>
		/// It selects User values from Database based on the 'all' search and checks to see if User Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDUser_in">User's IDUser Key used for checking</param>
		/// <returns>True if User Keys are met in the 'all' search, False if not</returns>
		public bool hasObject_all(
			long IDUser_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0)
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_User_Record_hasObject_all", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_all(...);
		/// <summary>
		/// Count's number of search results from User at Database based on the 'all' search.
		/// </summary>
		/// <returns>number of existing Records for the 'all' search</returns>
		public long Count_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_User_Record_count_all", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion
		#region public void Delete_all(...);
		/// <summary>
		/// Deletes User values from Database based on the 'all' search.
		/// </summary>
		public void Delete_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};

			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_User_Record_delete_all", 
				_dataparameters
			);
		}
		#endregion
		#endregion
		#region public void ????_byGroup
		#region public void Open_byGroup(...);
		/// <summary>
		/// Opens Record, based on 'byGroup' search. It selects User values from Database based on the 'byGroup' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="IDGroup_search_in">IDGroup search condition</param>
		public void Open_byGroup(
			long IDGroup_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDGroup_search_", DbType.Int64, ParameterDirection.Input, IDGroup_search_in, 0)
			};
			base.Open(
				"sp0_User_Record_open_byGroup_fullmode", 
				_dataparameters
			);
		}

		/// <summary>
		/// Opens Record, based on 'byGroup' search. It selects User values from Database based on the 'byGroup' search and assigns them to the Record, opening it.
		/// </summary>
		/// <param name="IDGroup_search_in">IDGroup search condition</param>
		/// <param name="page_in">page number</param>
		/// <param name="page_numRecords_in">number of records per page</param>
		public void Open_byGroup(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDGroup_search_", DbType.Int64, ParameterDirection.Input, IDGroup_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_", DbType.Int32, ParameterDirection.Input, page_in, 0), 
				parent_ref_.Connection.newDBDataParameter("page_numRecords_", DbType.Int32, ParameterDirection.Input, page_numRecords_in, 0)
			};
			base.Open(
				"sp0_User_Record_open_byGroup_page_fullmode", 
				_dataparameters
			);
		}
		#endregion
		#region public bool Update_SomeUpdateTest_byGroup(...);
		/// <summary>
		/// Updates (some) User values on Database based on the 'byGroup' search.
		/// </summary>
		/// <param name="IDGroup_search_in">IDGroup search condition</param>
		/// <param name="Password_update_in">Password update value</param>
		public void Update_SomeUpdateTest_byGroup(
			long IDGroup_search_in, 
			string Password_update_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDGroup_search_", DbType.Int64, ParameterDirection.Input, IDGroup_search_in, 0), 
				parent_ref_.Connection.newDBDataParameter("Password_update_", DbType.String, ParameterDirection.Input, Password_update_in, 50)
			};
			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_User_Record_update_SomeUpdateTest_byGroup", 
				_dataparameters
			);
		}
		#endregion
		#region public bool hasObject_byGroup(...);
		/// <summary>
		/// It selects User values from Database based on the 'byGroup' search and checks to see if User Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="IDUser_in">User's IDUser Key used for checking</param>
		/// <param name="IDGroup_search_in">IDGroup search condition</param>
		/// <returns>True if User Keys are met in the 'byGroup' search, False if not</returns>
		public bool hasObject_byGroup(
			long IDUser_in, 
			long IDGroup_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDUser_", DbType.Int64, ParameterDirection.Input, IDUser_in, 0), 
				parent_ref_.Connection.newDBDataParameter("IDGroup_search_", DbType.Int64, ParameterDirection.Input, IDGroup_search_in, 0)
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_User_Record_hasObject_byGroup", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_byGroup(...);
		/// <summary>
		/// Count's number of search results from User at Database based on the 'byGroup' search.
		/// </summary>
		/// <param name="IDGroup_search_in">IDGroup search condition</param>
		/// <returns>number of existing Records for the 'byGroup' search</returns>
		public long Count_byGroup(
			long IDGroup_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDGroup_search_", DbType.Int64, ParameterDirection.Input, IDGroup_search_in, 0)
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_User_Record_count_byGroup", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion
		#region public void Delete_byGroup(...);
		/// <summary>
		/// Deletes User values from Database based on the 'byGroup' search.
		/// </summary>
		/// <param name="IDGroup_search_in">IDGroup search condition</param>
		public void Delete_byGroup(
			long IDGroup_search_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("IDGroup_search_", DbType.Int64, ParameterDirection.Input, IDGroup_search_in, 0)
			};

			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_User_Record_delete_byGroup", 
				_dataparameters
			);
		}
		#endregion
		#endregion
		#endregion
	}
}