#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;
using OGen.lib.datalayer;
using OGen.lib.datalayer.PostgreSQL;

namespace OGen.test {
	class Program {
		public static void Main(string[] args) {
			
			DBConnection _con = new DBConnection_PostgreSQL(
				"Server=127.0.0.1;Port=5432;User ID=postgres;Password=passpub;Database=OGen-NTier_UTs;", 
				#if !NET_1_1
				System.Configuration.ConfigurationManager.AppSettings["DBLogfile"]
				#else
				System.Configuration.ConfigurationSettings.AppSettings["DBLogfile"]
				#endif
			);
			_con.Open();
			_con.Transaction.Begin();
			try {
				
				#region _con.Execute_SQLQuery_returnDataTable(...);
				DataTable _datatable = _con.Execute_SQLQuery_returnDataTable("select * from \"User\"");
				for (int r = 0; r < _datatable.Rows.Count; r++) {
					if (r == 0) {
						for (int c = 0; c < _datatable.Columns.Count; c++) {
							Console.Write("{0}\t", _datatable.Columns[c].Caption);
						}
						Console.WriteLine();
					}
					for (int c = 0; c < _datatable.Columns.Count; c++) {
						Console.Write("{0}\t", _datatable.Rows[r][c]);
					}
					Console.WriteLine();
				}
				#endregion
				
				#region ...; _con.getTables(); ...
				string[] _dbs = _con.getDBs();
				for (int d = 0; d < _dbs.Length; d++) {
					Console.WriteLine("#{0}/{1} - {2}", d + 1, _dbs.Length, _dbs[d]);
				}
				
				cDBTableField[] _fields;
				cDBTable[] _tables = _con.getTables();
				for (int t = 0; t < _tables.Length; t++) {
					Console.WriteLine(
						"\t#{0}/{1} - {2}", 
						t + 1, 
						_tables.Length, 
						_tables[t].Name
					);

					_fields = _con.getTableFields(_tables[t].Name);
					for (int f = 0; f < _fields.Length; f++) {
						Console.WriteLine(
							"\t\t#{0}/{1} - {2}", 
							f + 1, 
							_fields.Length, 
							_fields[f].Name
						);
					}
				}
				#endregion
				
				_con.Transaction.Commit();
			} catch (Exception _ex) {
				Console.WriteLine(_ex.Message);
				_con.Transaction.Rollback();
			} 
			_con.Transaction.Terminate();
			_con.Close();
			//_con.Dispose();
			
			Console.Write("Press any key to continue . . . ");
			#if !NET_1_1
			Console.ReadKey(true);
			#else
			Console.ReadLine();
			#endif
		}
	}
}
