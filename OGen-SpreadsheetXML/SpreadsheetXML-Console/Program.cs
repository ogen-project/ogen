using System;
using System.Data;
using System.Data.OleDb;

using OGen.SpreadsheetXML.lib.metadata.spreadsheet;

namespace SpreadsheetXML_Console {
	class Program {
		static XS__spreadsheet ProcessSS(
			DataTable ss_in
		) {
			int _pageIndex;
			int _rowIndex;
			int _cellIndex;

			XS__spreadsheet _ss_output = new XS__spreadsheet();
			_ss_output.PageCollection.Add(
				out _pageIndex,
				new XS_pageType()
			);
			_ss_output.PageCollection[_pageIndex].Name = ss_in.TableName;

			_ss_output.PageCollection[_pageIndex].RowCollection.Add(
				out _rowIndex,
				new XS_rowType()
			);
			_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].isHeader = true;
			for (int c = 0; c < ss_in.Columns.Count; c++) {
				_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection.Add(
					out _cellIndex,
					new XS_cellType()
				);
				_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].Data 
					= ss_in.Columns[c].Caption;
			}

			bool _isEmpty;
			for (int r = 0; r < ss_in.Rows.Count; r++) {
				_isEmpty = true;
				for (int c = 0; c < ss_in.Columns.Count; c++) {
					if (ss_in.Rows[r][c] != DBNull.Value) {
						_isEmpty = false;
					}
				}
				if (_isEmpty) continue;

				_ss_output.PageCollection[_pageIndex].RowCollection.Add(
					out _rowIndex,
					new XS_rowType()
				);
				_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].isHeader = false;
				for (int c = 0; c < ss_in.Columns.Count; c++) {
					_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection.Add(
						out _cellIndex,
						new XS_cellType()
					);
					if (ss_in.Rows[r][c] != DBNull.Value) {
						_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].isNull = false;
						_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].Data
							= ss_in.Rows[r][c].ToString();

					} else {
						_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].isNull = true;
						_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].Data
							= "";
					}
				}
			}

			return _ss_output;
		}
		static void Main(string[] args) {
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
			ProcessSS(_datatable).SaveState_toFile(
				@"C:\Documents and Settings\Administrator\Desktop\TEST\Livro1-xlsx.xml"
			);
			_datatable.Dispose();

			_dataadaptar.Dispose();
			_command.Dispose();

			_con.Close(); _con.Dispose();

			XS__spreadsheet _xxx = XS__spreadsheet.Load_fromFile(
				@"C:\Documents and Settings\Administrator\Desktop\TEST\Livro1-xlsx.xml"
			)[0];
			for (int p = 0; p < _xxx.PageCollection.Count; p++) {
				for (int r = 0; r < _xxx.PageCollection[p].RowCollection.Count; r++) {
					for (int c = 0; c < _xxx.PageCollection[p].RowCollection[r].CellCollection.Count; c++) {
						Console.Write("{0}\t", _xxx.PageCollection[p].RowCollection[r].CellCollection[c].Data);
					}
					Console.WriteLine();
				}
			}
		}
	}
}
