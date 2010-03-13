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
using System.Data;
using System.Data.OleDb;

namespace OGen.SpreadsheetXML.lib.metadata.spreadsheet {
	[System.Xml.Serialization.XmlRootAttribute("spreadsheet")]
	#if NET_1_1
	public class XS__spreadsheet : XS0__spreadsheet {
	#else
	public partial class XS__spreadsheet {
	#endif

		const string XLSX = ".xlsx";
		const string XLS = ".xls";

		#region public static DataTable[] Spreadsheet_toDataTable(...);
		public static DataTable[] Spreadsheet_toDataTable(
			string ssFilePath_in
		) {
			// NOTE: i haven't tested with Excel 8.0

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

			#region string _connectionString = ...;
			string _connectionString = null;
			if (
				ssFilePath_in.ToLower().LastIndexOf(XLSX)
				==
				ssFilePath_in.Length - XLSX.Length
			) {
				_connectionString =
					"Provider=Microsoft.ACE.OLEDB.12.0;" +
					"Data Source=" + ssFilePath_in + ";" +
					"Extended Properties=\"Excel 12.0;HDR=YES;\""
				;
			} else if (
				ssFilePath_in.ToLower().LastIndexOf(XLS)
				==
				ssFilePath_in.Length - XLS.Length
			) {
				_connectionString =
					"Provider=Microsoft.Jet.OLEDB.4.0;" +
					"Data Source=" + ssFilePath_in + ";" +
					"Extended Properties=\"Excel 8.0;HDR=YES;\""
				;
			}

			if (
				(_connectionString == null)
				||
				(_connectionString == "")
			) {
				Console.WriteLine("invalid file type; {0}", ssFilePath_in);
				return null;
			}
			#endregion

			OleDbConnection _con = new OleDbConnection(_connectionString);
			_con.Open();

			DataTable _information_schema__table = _con.GetOleDbSchemaTable(
				System.Data.OleDb.OleDbSchemaGuid.Tables,
				new object[] { null, null, null, "TABLE" }
			);
			string _table_name;
			string _table_visualName;
			DataTable[] _datatable = new DataTable[_information_schema__table.Rows.Count];
			for (int r = 0; r < _information_schema__table.Rows.Count; r++) {
				_table_name = _information_schema__table.Rows[r]["TABLE_NAME"].ToString();

				OleDbCommand _command = new OleDbCommand(
					string.Format(
						"select * from [{0}]",
						_table_name
					),
					_con
				);
				OleDbDataAdapter _dataadaptar = new OleDbDataAdapter(_command);
				//_dataadaptar.SelectCommand = _command;


				#region _table_visualName = ...;
				_table_visualName = _table_name.Substring(0, _table_name.Length - 1);
				if (_table_visualName[0] == '\'') {
					_table_visualName = _table_visualName.Substring(1);
				}
				#endregion


				_datatable[r] = new DataTable(_table_visualName);
				_dataadaptar.Fill(_datatable[r]);

				_dataadaptar.Dispose();
				_command.Dispose();
			}
			_con.Close(); _con.Dispose();

			return _datatable;
		} 
		#endregion
		#region public static XS__spreadsheet DataTable_toXMLSpreadsheet(...);
		public static XS__spreadsheet DataTable_toXMLSpreadsheet(
			params DataTable[] dt_spreadsheet_in
		) {
			int _pageIndex;
			int _rowIndex;
			int _cellIndex;

			XS__spreadsheet _ss_output = new XS__spreadsheet();

			for (int s = 0; s < dt_spreadsheet_in.Length; s++) {
				_ss_output.PageCollection.Add(
					out _pageIndex,
					new XS_pageType()
				);
				_ss_output.PageCollection[_pageIndex].Name = dt_spreadsheet_in[s].TableName;

				_ss_output.PageCollection[_pageIndex].RowCollection.Add(
					out _rowIndex,
					new XS_rowType()
				);
				_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].isHeader = true;
				for (int c = 0; c < dt_spreadsheet_in[s].Columns.Count; c++) {
					_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection.Add(
						out _cellIndex,
						new XS_cellType()
					);
					_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].Data
						= dt_spreadsheet_in[s].Columns[c].Caption;
				}

				bool _isEmpty;
				for (int r = 0; r < dt_spreadsheet_in[s].Rows.Count; r++) {
					_isEmpty = true;
					for (int c = 0; c < dt_spreadsheet_in[s].Columns.Count; c++) {
						if (dt_spreadsheet_in[s].Rows[r][c] != DBNull.Value) {
							_isEmpty = false;
						}
					}
					if (_isEmpty) continue;

					_ss_output.PageCollection[_pageIndex].RowCollection.Add(
						out _rowIndex,
						new XS_rowType()
					);
					_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].isHeader = false;
					for (int c = 0; c < dt_spreadsheet_in[s].Columns.Count; c++) {
						_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection.Add(
							out _cellIndex,
							new XS_cellType()
						);
						if (dt_spreadsheet_in[s].Rows[r][c] != DBNull.Value) {
							_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].isNull = false;
							_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].Data
								= dt_spreadsheet_in[s].Rows[r][c].ToString();

						} else {
							_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].isNull = true;
							_ss_output.PageCollection[_pageIndex].RowCollection[_rowIndex].CellCollection[_cellIndex].Data
								= "";
						}
					}
				}

			}

			return _ss_output;
		} 
		#endregion
	}
}