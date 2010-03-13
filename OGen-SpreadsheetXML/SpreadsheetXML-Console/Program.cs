using System;
using System.Data;
using System.Data.OleDb;

using OGen.SpreadsheetXML.lib.metadata.spreadsheet;

namespace SpreadsheetXML_Console {
	class Program {
		static void Main(string[] args) {
			int _pageIndex;
			int _rowIndex;

			XS__spreadsheet _ss = new XS__spreadsheet();
			_ss.PagesCollection.Add(
				out _pageIndex,
				new XS_pageType()
			);
			_ss.PagesCollection[_pageIndex].Name = "xxxxxxxxxxxxxxxxxxxxxx";
			_ss.PagesCollection[_pageIndex].RowsCollection.Add(
				out _rowIndex,
				new XS_rowType()
			);
			//_ss.PagesCollection[_pageIndex].RowsCollection[_rowIndex].

			return;

			// 2007 Office System Driver: Data Connectivity Components
			// http://www.microsoft.com/downloads/en/confirmation.aspx?familyId=7554f536-8c28-4598-9b72-ef94e038c891&displayLang=en

			// if you don't want to show the header row (first row) in the grid
			// use 'HDR=NO' in the string

			//--- *.xls
			// "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0\"";
			//--- *.xlsx
			// "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"";

			// The 'Microsoft.ACE.OLEDB.12.0' provider is not registered error on 64bit OS
			// http://www.clariusconsulting.net/blogs/kzu/archive/2007/11/15/41639.aspx


			//string connectionString =
			//    @"Provider=Microsoft.Jet.OLEDB.4.0;" +
			//    @"Data Source=C:\Documents and Settings\Administrator\Desktop\TEST\Livro1.xlsx;" +
			//    @"Extended Properties=\"Excel 8.0;\""
			//;
			string _connectionstring_xlsx_OLEDB =
				"Provider=Microsoft.ACE.OLEDB.12.0;" +
				"Data Source=" + @"C:\Documents and Settings\Administrator\Desktop\TEST\Livro1.xlsx" + ";" +
				"Extended Properties=\"Excel 12.0;HDR=YES;\""
			;

			string _query = "SELECT * FROM [Folha3$]";
			OleDbConnection _con = new OleDbConnection(_connectionstring_xlsx_OLEDB);
			_con.Open();

			OleDbCommand _command = new OleDbCommand(_query, _con);
			OleDbDataAdapter _dataadaptar = new OleDbDataAdapter(_command);
			//_dataadaptar.SelectCommand = _command;

			DataTable _datatable = new DataTable();
			_dataadaptar.Fill(_datatable);
			for (int c = 0; c < _datatable.Columns.Count; c++) {
				Console.Write("{0}\t", _datatable.Columns[c].Caption);
			}
			Console.WriteLine();
			for (int r = 0; r < _datatable.Rows.Count; r++) {
				Console.Write("{0})\t", r);
				for (int c = 0; c < _datatable.Columns.Count; c++) {
					if (_datatable.Rows[r][c] != DBNull.Value) {
						Console.Write("{0}\t", _datatable.Rows[r][c]);//, _datatable.Rows[r][c].GetType());
					}
				}
				Console.WriteLine();
			}
			_datatable.Dispose();

			_dataadaptar.Dispose();
			_command.Dispose();

			_con.Close(); _con.Dispose();
		}
	}
}
