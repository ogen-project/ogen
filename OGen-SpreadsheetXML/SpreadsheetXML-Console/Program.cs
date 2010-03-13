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
using System.Data.OleDb;

using OGen.SpreadsheetXML.lib.metadata.spreadsheet;

namespace SpreadsheetXML_Console {
	class Program {
		static void Main(string[] args) {
			#region string _ssFilePath = args[0];
			string _ssFilePath;
#if DEBUG
			if (args.Length != 1) {
				_ssFilePath = @"C:\Documents and Settings\Administrator\Desktop\TEST\Livro1.xlsx";
			} else {
				_ssFilePath = args[0];
			}
#else
			if (
				(args.Length != 1)
			) {
				Console.WriteLine("invalid argument!");
			}

			_ssFilePath = args[0];
			if (
				!System.IO.File.Exists(_ssFilePath)
			) {
				Console.WriteLine("file not found!");
			}
#endif 
			#endregion

			#region DataTable[] _datatable = XS__spreadsheet.Spreadsheet_toDataTable(...);
			DataTable[] _datatable = XS__spreadsheet.Spreadsheet_toDataTable(
				_ssFilePath
			);
			if (_datatable == null) {
				return;
			} 
			#endregion

			#region string _xmlFilePath = ...;
			string _xmlFilePath = System.IO.Path.Combine(
				System.IO.Path.GetDirectoryName(_ssFilePath),
				string.Format(
					"{0}.SpreadsheetXML.xml",
					System.IO.Path.GetFileNameWithoutExtension(_ssFilePath)
				)
			); 
			#endregion
			XS__spreadsheet.DataTable_toXMLSpreadsheet(
				_datatable
			).SaveState_toFile(
				_xmlFilePath
			);

#if DEBUG
			XS__spreadsheet _ss = XS__spreadsheet.Load_fromFile(
				_xmlFilePath
			)[0];
			for (int p = 0; p < _ss.PageCollection.Count; p++) {
				Console.WriteLine("--- {0}", _ss.PageCollection[p].Name);
				for (int r = 0; r < _ss.PageCollection[p].RowCollection.Count; r++) {
					for (int c = 0; c < _ss.PageCollection[p].RowCollection[r].CellCollection.Count; c++) {
						Console.Write("{0}\t", _ss.PageCollection[p].RowCollection[r].CellCollection[c].Data);
					}
					Console.WriteLine();
				}
				Console.WriteLine();
			}
#endif
		}
	}
}