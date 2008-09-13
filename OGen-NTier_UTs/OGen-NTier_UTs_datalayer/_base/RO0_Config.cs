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
	/// Config RecordObject which provides access to searches defined for Config table at Database.
	/// </summary>
	public sealed class RO0_Config : RO__base {
		#region internal RO0_Config();
		internal RO0_Config(
#if !NET_1_1
			DO_Config 
#else
			DO0_Config 
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
			DO_Config 
#else
			DO0_Config 
#endif
			parent_ref_;
		#endregion

		#region public Methods...
		#region //public SC0_Config Serialize();
		//public SC0_Config Serialize() {
		//	return new SC0_Config(Record);
		//}
		#endregion
		#region public SC0_Config Serialize();
		public SC0_Config Serialize() {
			SO0_Config[] _serialisableobject;

			lock (record__) {
				int _current = Current;

				_serialisableobject = new SO0_Config[Count];

				Reset();
				while (Read()) {
					_serialisableobject[Current] 
						= new SO0_Config(
							parent_ref_.Fields.Name,
							parent_ref_.Fields.Config,
							parent_ref_.Fields.Type,
							parent_ref_.Fields.Description
						);
				}

				Current = _current;
			}

			SC0_Config _serialize_out = new SC0_Config();
			_serialize_out.SO0_Config = _serialisableobject;
			return _serialize_out;
		}
		#endregion
		#region public void Open(SC0_Config serialisablecollection_in);
		public void Open(SC0_Config serialisablecollection_in) {
			Open(serialisablecollection_in.SO0_Config);
		}
		#endregion
		#region public void Open(SO0_Config[] serialisableobject_in);
		public void Open(SO0_Config[] serialisableobject_in) {
			DataTable _datatable = new DataTable();
			_datatable.Columns.Add(new DataColumn("codProfissao", typeof(int)));
			_datatable.Columns.Add(new DataColumn("descProfissao", typeof(string)));

			DataRow _datarow;
			for (int i = 0; i < serialisableobject_in.Length; i++) {
				_datarow = _datatable.NewRow();
				_datarow["Name"] = serialisableobject_in[i].Name;
				_datarow["Config"] = serialisableobject_in[i].Config;
				_datarow["Type"] = serialisableobject_in[i].Type;
				_datarow["Description"] = serialisableobject_in[i].Description;

				_datatable.Rows.Add(_datarow);
			}

			Open(_datatable);
		}
		#endregion
		#region public override bool Read();
		/// <summary>
		/// Reads values from Record, assigns them to the appropriate Config DataObject property, finally it steps current iteration at the Record forward and returns a bool value indicating if End Of Record has been reached.
		/// </summary>
		/// <returns>False if End Of Record has been reached, True if not</returns>
		public override bool Read() {
			if (base.read()) {
				if (base.Record.Rows[Current]["Name"] == System.DBNull.Value) {
					parent_ref_.Fields.name_ = string.Empty;
				} else {
					parent_ref_.Fields.name_ = (string)base.Record.Rows[Current]["Name"];
				}
				if (base.Record.Rows[Current]["Config"] == System.DBNull.Value) {
					parent_ref_.Fields.config_ = string.Empty;
				} else {
					parent_ref_.Fields.config_ = (string)base.Record.Rows[Current]["Config"];
				}
				if (base.Record.Rows[Current]["Type"] == System.DBNull.Value) {
					parent_ref_.Fields.type_ = 0;
				} else {
					parent_ref_.Fields.type_ = (int)base.Record.Rows[Current]["Type"];
				}
				if (base.Record.Rows[Current]["Description"] == System.DBNull.Value) {
					parent_ref_.Fields.description_ = string.Empty;
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
		#region public void ????_all
		#region public void Open_all(...);
		/// <summary>
		/// Opens Record, based on 'all' search. It selects Config values from Database based on the 'all' search and assigns them to the Record, opening it.
		/// </summary>
		public void Open_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};
			base.Open(
				"sp0_Config_Record_open_all_fullmode", 
				_dataparameters
			);
		}

		/// <summary>
		/// Opens Record, based on 'all' search. It selects Config values from Database based on the 'all' search and assigns them to the Record, opening it.
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
				"sp0_Config_Record_open_all_page_fullmode", 
				_dataparameters
			);
		}
		#endregion
		#region public bool hasObject_all(...);
		/// <summary>
		/// It selects Config values from Database based on the 'all' search and checks to see if Config Keys(passed as parameters) are met.
		/// </summary>
		/// <param name="Name_in">Config's Name Key used for checking</param>
		/// <returns>True if Config Keys are met in the 'all' search, False if not</returns>
		public bool hasObject_all(
			string Name_in
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
				parent_ref_.Connection.newDBDataParameter("Name_", DbType.String, ParameterDirection.Input, Name_in, 50)
			};
			return (bool)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_Config_Record_hasObject_all", 
				_dataparameters, 
				DbType.Boolean,
				0
			);
		}
		#endregion
		#region public long Count_all(...);
		/// <summary>
		/// Count's number of search results from Config at Database based on the 'all' search.
		/// </summary>
		/// <returns>number of existing Records for the 'all' search</returns>
		public long Count_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};

			return (long)parent_ref_.Connection.Execute_SQLFunction(
				"fnc0_Config_Record_count_all", 
				_dataparameters, 
				DbType.Int64,
				0
			);
		}
		#endregion
		#region public void Delete_all(...);
		/// <summary>
		/// Deletes Config values from Database based on the 'all' search.
		/// </summary>
		public void Delete_all(
		) {
			IDbDataParameter[] _dataparameters = new IDbDataParameter[] {
			};

			parent_ref_.Connection.Execute_SQLFunction(
				"sp0_Config_Record_delete_all", 
				_dataparameters
			);
		}
		#endregion
		#endregion
		#endregion
	}
}