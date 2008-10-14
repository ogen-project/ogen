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
using System.IO;
//using System.Text.RegularExpressions;
using OGen.Doc.lib.metadata.documentation;

namespace OGen.Doc.lib.metadata {
	public class utils { private utils() {}

		#region public static string ReadFile(...);
		public static string ReadFile(
			string path1_in, 
			string path2_in
		) {
			string _filePath = 
				Path.Combine(
					path1_in, 
					path2_in.Replace(
						'/', 
						Path.DirectorySeparatorChar
					)
				);
			string _output;
			if (File.Exists(_filePath)) {
				#if NET_1_1
					StreamReader _stream = new StreamReader(_filePath);
					_output = _stream.ReadToEnd().Trim();
					_stream.Close();
				#else
					_output 
						= File.ReadAllText(
							_filePath
						).Trim();
				#endif
			} else {
				_output = "<span class='error'>ERROR: TODOS - FILE DOESN'T EXIST</span><br /><br />";
			}
			return (_output == string.Empty)
				? "<span class='error'>ERROR: TODOS - FILE IS EMPTY</span><br /><br />"
				: _output;
		}
		#endregion
		#region public static string ReadDocument_part(...);
		public static string ReadDocument_part(
			string allDocument_in
		) {
			int _begin;
			int _end;
			if (
				(
					((_begin = allDocument_in.IndexOf("//<document>")) >= 0)
					||
					((_begin = allDocument_in.IndexOf("--<document>")) >= 0)
				)
				&&
				(
					((_end = allDocument_in.IndexOf("//</document>")) >= 0)
					||
					((_end = allDocument_in.IndexOf("--</document>")) >= 0)
				)
			) {
				return allDocument_in.Substring(
					_begin + 12,
					_end - (_begin + 12)
				);
			} else {
				return allDocument_in;
			}
		}
		#endregion
	}
}