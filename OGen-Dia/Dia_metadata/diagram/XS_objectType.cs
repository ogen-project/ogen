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

namespace OGen.Dia.lib.metadata.diagram {
	#if NET_1_1
	public class XS_objectType : XS0_objectType {
	#else
	public partial class XS_objectType {
	#endif

		#region private string getAttribute(...);
		private string getAttribute(
			string name_in
		) {
			for (int a = 0; a < AttributeCollection.Count; a++) {
				if (AttributeCollection[a].Name == name_in) {
					return AttributeCollection[a].String;
				}
			}

			return string.Empty;
		}
		#endregion

		#region public string TableName { get; }
		[XmlIgnore()]
		[XmlAttribute("tableName")]
		public string TableName {
			get {
				return getAttribute("name").Replace("#", "");
			}
		}
		#endregion
		#region public string TableComment { get; }
		[XmlIgnore()]
		[XmlAttribute("tableComment")]
		public string TableComment {
			get {
				return getAttribute("comment").Replace("#", "");
			}
		}
		#endregion

		#region public DBTableField[] TableFields();
		public DBTableField[] TableFields() {
			DBTableField _tableField;
			System.Collections.Generic.List<DBTableField> _list
				= new System.Collections.Generic.List<DBTableField>();

			for (int a = 0; a < AttributeCollection.Count; a++) {
				switch (AttributeCollection[a].Name) {
					case "attributes":
						#region _list.Add( ... );
						for (int c = 0; c < AttributeCollection[a].CompositeCollection.Count; c++) {
							switch (AttributeCollection[a].CompositeCollection[c].Type) {
								case "table_attribute":
									_list.Add(_tableField = new DBTableField());
									_tableField.isIdentity = false;

									for (int aa = 0; aa < AttributeCollection[a].CompositeCollection[c].AttributeCollection.Count; aa++) {
										switch (AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Name) {
											case "name":
												_tableField.Name = AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String.Replace("#", "");
												break;
											case "primary_key":
												_tableField.isPK
													= AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val;
												break;
											case "unique":
												_tableField.isUnique
													= AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val;
												break;
											case "nullable":
												_tableField.isNullable
													= AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val;
												break;
											case "comment":
												string[] _comment = OGen.lib.utils.ParamvalueList_Split(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String.Replace("#", ""),
													";",
													":",

													"identity", // ___________ 0
													"length", // _____________ 1
													"sqlserver", // __________ 2
													"psql", // _______________ 3
													"numericPrecision", // ___ 4
													"numericScale", // _______ 5
													"type", // _______________ 6
													"unique" // ______________ 7
												);
												if (_comment[0] != "")
													_tableField.isIdentity = bool.Parse(_comment[0]);
												if (_comment[1] != "")
													_tableField.Size = int.Parse(_comment[1]);

												// sql server
												if (_comment[2] != "")
													_tableField.SQLServerTypeName = _comment[2];

												// postgresql
												if (_comment[3] != "")
													_tableField.PostgreSQLTypeName = _comment[3];

												if (_comment[4] != "")
													_tableField.Numeric_Precision = int.Parse(_comment[4]);
												if (_comment[5] != "")
													_tableField.Numeric_Scale = int.Parse(_comment[5]);

												break;
											default:
												break;
										}

									}
									break;
							}
						}
						#endregion
						break;
				}
			}

			return _list.ToArray();
		}
		#endregion
		#region public FK[] TableFKs();
		#region public struct FK { ... }
		public struct FK {
			public FK(
				string tableFieldName_in, 

				string fk_TableName_in, 
				string fk_TableFieldName_in
			) {
				TableFieldName = tableFieldName_in;

				FK_TableName = fk_TableName_in;
				FK_TableFieldName = fk_TableFieldName_in;
			}

			public string TableFieldName;

			public string FK_TableName;
			public string FK_TableFieldName;
		}
		#endregion

		public FK[] TableFKs() {
			FK[] _output;
			System.Collections.Generic.Dictionary<string, FK> _output2;

			TableFKs(
				out _output, 
				out _output2
			);

			return _output;
		}
		public void TableFKs(
			out FK[] fks_out,
			out System.Collections.Generic.Dictionary<string, FK> fks_dic_out
		) {
			System.Collections.Generic.List<FK> _output 
				= new System.Collections.Generic.List<FK>();
			System.Collections.Generic.Dictionary<string, FK> _output2
				= new System.Collections.Generic.Dictionary<string, FK>();

			XS_objectType _table_a;
			string _tableName_a;
			string _tableFieldName_a;

			XS_objectType _table_b;
			string _tableName_b;
			string _tableFieldName_b;

			string _direction;

			XS_objectTypeCollection _objecttypecollection = (XS_objectTypeCollection)this.parent_ref;
			XS_layerType _layertype = (XS_layerType)_objecttypecollection.parent_ref;
			XS_layerTypeCollection _layertypecollection = (XS_layerTypeCollection)_layertype.parent_ref;
			XS__diagram _root_ref = (XS__diagram)_layertypecollection.parent_ref;
			FK _aux;

			for (int l = 0; l < _root_ref.LayerCollection.Count; l++) {
				for (int o = 0; o < _root_ref.LayerCollection[l].ObjectCollection.Count; o++) {
					switch (_root_ref.LayerCollection[l].ObjectCollection[o].Type) {
						case "UML - Association":
							if (_root_ref.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection.Count != 2)
								break;

							_table_a = null;
							_tableName_a = "";
							_tableFieldName_a = "";

							_table_b = null;
							_tableName_b = "";
							_tableFieldName_b = "";

							_direction = "";

							for (int a = 0; a < _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection.Count; a++) {
								switch (_root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].Name) {
									case "direction":
										_direction = _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].Enum.Val;
										break;
									case "role_a":
										_table_a = _root_ref.Table_search(
											_root_ref.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection[0].To
										);
										_tableName_a = _table_a.TableName;
										_tableFieldName_a = _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String.Replace("#", "");
										break;
									case "role_b":
										_table_b = _root_ref.Table_search(
											_root_ref.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection[1].To
										);
										_tableName_b = _table_b.TableName;
										_tableFieldName_b = _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String.Replace("#", "");
										break;
								}
							}

							if (
								(_table_a == this)
								&&
								(_direction == "1")
							) {
								_output2.Add(
									_tableFieldName_a,
									_aux = new FK(
										_tableFieldName_a,
										_tableName_b,
										_tableFieldName_b
									)
								);
								_output.Add(_aux);
							}
							if (
								(_table_b == this)
								&&
								(_direction == "2")
							) {
								_output2.Add(
									_tableFieldName_b,
									_aux = new FK(
										_tableFieldName_b,
										_tableName_a,
										_tableFieldName_a
									)
								);
								_output.Add(_aux);
							}
							break;
					}
				}
			}

			fks_dic_out = _output2;
			fks_out = _output.ToArray();

			//return _output.ToArray();
		}
		#endregion
	}
}