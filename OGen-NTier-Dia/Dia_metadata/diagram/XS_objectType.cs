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

using System.Text.RegularExpressions;

using OGen.lib.datalayer;

namespace OGen.NTier.Dia.lib.metadata.diagram {
	#if NET_1_1
	public class XS_objectType : XS0_objectType {
	#else
	public partial class XS_objectType {
	#endif

		private Regex Regex_Length = new Regex(
			"^(?<before>.*)length=(?<length>.*);(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);
		private Regex Regex_Numeric_Precision = new Regex(
			"^(?<before>.*)numericPrecision=(?<numericPrecision>.*);(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);
		private Regex Regex_Numeric_Scale = new Regex(
			"^(?<before>.*)numericScale=(?<numericScale>.*);(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);
		private Regex Regex_PostgreSQL = new Regex(
			"^(?<before>.*)psql=(?<psql>.*);(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);
		private Regex Regex_SQLServer = new Regex(
			"^(?<before>.*)sqlserver=(?<sqlserver>.*);(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);
		private Regex Regex_Identity = new Regex(
			"^(?<before>.*)identity=(?<identity>.*);(?<after>.*)",
			RegexOptions.Compiled |
			RegexOptions.IgnoreCase
		);

		#region private string getAttribute(...);
		[XmlIgnore()]
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

		public DBTableField[] Fields() {
			Match _match;
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
									for (int aa = 0; aa < AttributeCollection[a].CompositeCollection[c].AttributeCollection.Count; aa++) {
										switch (AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Name) {
											case "name":
												_tableField.Name = AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String.Replace("#", "");
												break;
											case "primary_key":
												_tableField.isPK
													= AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val;
												break;
											case "nullable":
												_tableField.isNullable
													= AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val;
												break;
											case "comment":
												_match = Regex_Identity.Match(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String
												);
												if (_match.Success)
													_tableField.isIdentity = bool.Parse(_match.Groups["identity"].Value);


												_match = Regex_SQLServer.Match(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String
												);
												if (_match.Success)
													_tableField.DBType_inDB_name = _match.Groups["sqlserver"].Value;


												_match = Regex_PostgreSQL.Match(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String
												);
												if (_match.Success)
													_tableField.DBType_inDB_name = _match.Groups["psql"].Value;


												_match = Regex_Length.Match(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String
												);
												if (_match.Success)
													_tableField.Size = int.Parse(_match.Groups["length"].Value);


												_match = Regex_Numeric_Precision.Match(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String
												);
												if (_match.Success)
													_tableField.Size = int.Parse(_match.Groups["numericPrecision"].Value);


												_match = Regex_Numeric_Scale.Match(
													AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String
												);
												if (_match.Success)
													_tableField.Size = int.Parse(_match.Groups["numericScale"].Value);


												break;

											//case "type":
											//    Console.WriteLine("\tfield-type: {0}", AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String);
											//    break;
											case "unique":
												//Console.WriteLine("\tfield-unique: {0}", AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val);
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

			string _tableName_a;
			string _tableFieldName_a;
			string _tableName_b;
			string _tableFieldName_b;
			string _direction;
			XS__diagram _root_ref = ((XS__diagram)((XS_layerType)this.parent_ref).parent_ref);
			for (int l = 0; l < _root_ref.LayerCollection.Count; l++) {
				for (int o = 0; o < _root_ref.LayerCollection[l].ObjectCollection.Count; o++) {
					switch (_root_ref.LayerCollection[l].ObjectCollection[o].Type) {
						case "UML - Association":
							if (_root_ref.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection.Count != 2)
								break;

							_tableName_a = "";
							_tableFieldName_a = "";
							_tableName_b = "";
							_tableFieldName_b = "";
							_direction = "";
							for (int a = 0; a < _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection.Count; a++) {
								switch (_root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].Name) {
									case "direction":
										_direction = _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].Enum.Val;
										break;
									case "role_a":
										_tableName_a = _root_ref.Table_search(
											_root_ref.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection[0].To
										).TableName;
										_tableFieldName_a = _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String;
										break;
									case "role_b":
										_tableName_b = _root_ref.Table_search(
											_root_ref.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection[1].To
										).TableName;
										_tableFieldName_b = _root_ref.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String;
										break;
								}
							}

							// ...

							break;
					}
				}
			}

			return _list.ToArray();
		}
	}
}