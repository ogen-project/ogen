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
using System.Collections.Generic;
using System.Text;

using OGen.Dia.lib.metadata;
using OGen.Dia.lib.metadata.diagram;

namespace OGen.Dia.presentationlayer.test {
	class Program {
		static void Main(string[] args) {
			XS__diagram _dia = XS__diagram.Load_fromFile(
				@"X:\test\modeloDados.dia"
			)[0];

			for (int l = 0; l < _dia.LayerCollection.Count; l++) {
				for (int o = 0; o < _dia.LayerCollection[l].ObjectCollection.Count; o++) {
					switch (_dia.LayerCollection[l].ObjectCollection[o].Type) {
						case "Database - Table":
							for (int a = 0; a < _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection.Count; a++) {
								switch (_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].Name) {
									case "name":
										Console.WriteLine(
											"table-name: {0} ('{1}')", 
											_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String, 
											_dia.LayerCollection[l].ObjectCollection[o].Id
										);
										break;
									case "comment":
										Console.WriteLine("table-comments: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String);
										break;
									case "attributes":
										for (int c = 0; c < _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection.Count; c++) {
											switch (_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].Type) {
												case "table_attribute":
													for (int aa = 0; aa < _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection.Count; aa++) {
														switch (_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Name) {
															case "name":
																Console.WriteLine("\tfield-name: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String);
																break;
															case "type":
																Console.WriteLine("\tfield-type: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String);
																break;
															case "comment":
																Console.WriteLine("\tfield-comments: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].String);
																break;
															case "primary_key":
																Console.WriteLine("\tfield-pk: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val);
																break;
															case "nullable":
																Console.WriteLine("\tfield-nullable: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val);
																break;
															case "unique":
																Console.WriteLine("\tfield-unique: {0}", _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].CompositeCollection[c].AttributeCollection[aa].Boolean.Val);
																break;
															default:
																break;
														}

													}
													break;
											}
										}
										break;
								}
							}
							break;
						case "UML - Association":
							if (_dia.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection.Count != 2)
								break;

							for (int a = 0; a < _dia.LayerCollection[l].ObjectCollection[o].AttributeCollection.Count; a++) {
								switch (_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].Name) {
									case "role_a":
										Console.WriteLine(
											"ROLE_A: {0}.{1}", 
											_dia.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection[0].To, 
											_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String
										);
										break;
									case "role_b":
										Console.WriteLine(
											"ROLE_B: {0}.{1}",
											_dia.LayerCollection[l].ObjectCollection[o].Connections.ConnectionCollection[1].To,
											_dia.LayerCollection[l].ObjectCollection[o].AttributeCollection[a].String
										);
										break;
								}
							}
							break;
					}
				}
			}
		}
	}
}
