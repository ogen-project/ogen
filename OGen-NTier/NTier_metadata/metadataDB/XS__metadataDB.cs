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
using System.Xml.Serialization;

using OGen.lib.collections;
using OGen.lib.datalayer;

namespace OGen.NTier.lib.metadata.metadataDB {
	[System.Xml.Serialization.XmlRootAttribute("metadataDB")]
	public class XS__metadataDB : XS0__metadataDB {
//		#region public static XS__metadataDB Load_fromDB(...);
		public delegate void Load_fromDBDelegate(
			string message_in, 
			bool onANewLine_in
		);

		public static XS__metadataDB Load_fromDB(
			XS__metadataDB.Load_fromDBDelegate notifyBack_in, 
			string subAppName_in,

			params DBSimpleConnectionstring[] dbConnectionParam_in
		) {
			return Load_fromDB(
				notifyBack_in, 
				subAppName_in, 

				null,
				0, 

				dbConnectionParam_in
			);
		}
		public static XS__metadataDB Load_fromDB(
			XS__metadataDB.Load_fromDBDelegate notifyBack_in, 
			string subAppName_in, 

			XS__RootMetadata root_ref_in, 
			int index_in,

			params DBSimpleConnectionstring[] dbConnectionParam_in
		) {
			#region XS__metadataDB _output = ...;
			XS__metadataDB _output = new XS__metadataDB();

			_output.root_metadatadb_ = ROOT + "." + METADATADB + "[" + index_in.ToString() + "]";
			_output.parent_ref = root_ref_in; // ToDos: now!
			if (root_ref_in != null) _output.root_ref = root_ref_in;
			#endregion

			bool _getTables_exists;
			bool _getTableFields_exists;
			DBConnection _connection;
			cDBTable[] _tables_aux;
			cDBTableField[] _fields_aux;
			XS_tableType _table;
			XS_tableDBType _tabledb;
			XS_tableFieldType _field;
			XS_tableFieldDBType _fielddb;
			int _searchindex;
			const string OGEN_SP0__GETTABLEFIELDS = "OGen_sp0__getTableFields";
			const string OGEN_SP0__GETTABLES = "OGen_sp0__getTables";

			for (int c = 0; c < dbConnectionParam_in.Length; c++) {
				#region notifyBack_in(...);
				if (notifyBack_in != null) {
					notifyBack_in(
						string.Format(
							"#{0}/{1} - {2}",
							c + 1,
							dbConnectionParam_in.Length,
							dbConnectionParam_in[c].DBServerType.ToString()
						),
						true
					);
				}
				#endregion
				_connection = DBConnectionsupport.CreateInstance(
					dbConnectionParam_in[c].DBServerType,
					dbConnectionParam_in[c].Connectionstring
				);

				#region _tables_aux = ...;
				_getTables_exists = _connection.SQLStoredProcedure_exists(OGEN_SP0__GETTABLES);
				_tables_aux = _connection.getTables(
					subAppName_in,
					_getTables_exists 
						? OGEN_SP0__GETTABLES
						: string.Empty
				);
				#endregion
				#region _fields_aux = ...;
				_getTableFields_exists = _connection.SQLStoredProcedure_exists(OGEN_SP0__GETTABLEFIELDS);
				_fields_aux = _connection.getTableFields(
					// _tables_aux[t].Name, // get's specific table fields
					string.Empty, // get's fields for all tables
					_getTableFields_exists
						? OGEN_SP0__GETTABLEFIELDS
						: string.Empty
				);
				#endregion
				for (int t = 0; t < _tables_aux.Length; t++) {
					#region _table = ...; _table.Name = ...;
					_searchindex = _output.Tables.TableCollection.Search(
						_tables_aux[t].Name,
						true
					);
					if (_searchindex >= 0) {
						_table = _output.Tables.TableCollection[_searchindex];
					} else {
						_table = new XS_tableType(
							_tables_aux[t].Name
						);
						_output.Tables.TableCollection.Add(_table);
					}
					#endregion
					_table.isVirtualTable = _tables_aux[t].isVirtualTable;

					#region _tabledb = ...; _tabledb.DBServerType = ...;
					_searchindex = _table.TableDBs.TableDBCollection.Search(
						dbConnectionParam_in[c].DBServerType.ToString(),
						true
					);
					if (_searchindex >= 0) {
						_tabledb = _table.TableDBs.TableDBCollection[_searchindex];
					} else {
						_tabledb = new XS_tableDBType(
							dbConnectionParam_in[c].DBServerType.ToString()
						);
						_table.TableDBs.TableDBCollection.Add(_tabledb);
					}
					#endregion
					_tabledb.DBTableName = _tables_aux[t].Name;
					_tabledb.DBDescription = _tables_aux[t].DBDescription;

					for (int f = 0; f < _fields_aux.Length; f++) {
						if (_tables_aux[t].Name != _fields_aux[f].TableName) {
							continue;
						}

						#region _field = ...; _field.Name = ...;
						_searchindex = _table.TableFields.TableFieldCollection.Search(
							_fields_aux[f].Name,
							true
						);
						if (_searchindex >= 0) {
							_field = _table.TableFields.TableFieldCollection[_searchindex];
						} else {
							_field = new XS_tableFieldType(
								_fields_aux[f].Name
							);
							_table.TableFields.TableFieldCollection.Add(_field);
						}
						#endregion
						_field.isPK = _fields_aux[f].isPK;
						_field.isIdentity = _fields_aux[f].isIdentity;
						_field.isNullable = _fields_aux[f].isNullable;
						_field.NumericPrecision = _fields_aux[f].Numeric_Precision;
						_field.NumericScale = _fields_aux[f].Numeric_Scale;
						_field.Size = _fields_aux[f].Size;
						_field.FKTableName = _fields_aux[f].FK_TableName;
						_field.FKFieldName = _fields_aux[f].FK_FieldName;

						#region _fielddb = ...; _fielddb.DBServerType = ...;
						_searchindex = _field.TableFieldDBs.TableFieldDBCollection.Search(
							dbConnectionParam_in[c].DBServerType.ToString(),
							true
						);
						if (_searchindex >= 0) {
							_fielddb = _field.TableFieldDBs.TableFieldDBCollection[_searchindex];
						} else {
							_fielddb = new XS_tableFieldDBType(
								dbConnectionParam_in[c].DBServerType.ToString()
							);
						}
						#endregion
						_fielddb.DBType = _fields_aux[f].DBType_inDB_name;
						_fielddb.DBDescription = _fields_aux[f].DBDescription;
						_fielddb.DBDefaultValue = _fields_aux[f].DBDefaultValue;
						_fielddb.DBCollationName = _fields_aux[f].DBCollationName;
						_fielddb.DBFieldName = _fields_aux[f].Name;
					}
				}
			}

			return _output;
		}
//		#endregion
	}
}
