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

namespace OGen.lib {
	public static class utils {

		#region public static string[] ParamvalueList_Split(...);
		public static string[] ParamvalueList_Split(
			string paramvalueList_in, 

			string paramSplitter_in, 
			string valueSplitter_in, 

			params string[] param_in
		) {
			string[] _output = new string[param_in.Length];
			for (int p = 0; p < param_in.Length; p++) {
				_output[p] = "";
			}

			#region string[] _paramValue = paramvalueList_in.Split(paramSplitter_in);
			string[] _paramValue;
			if (paramSplitter_in.Length == 1) {
				_paramValue = paramvalueList_in.Split(
					paramSplitter_in[0]
				);
			} else {
				_paramValue = paramvalueList_in.Split(
					new string[] { paramSplitter_in }, 
					StringSplitOptions.None
				);
			}
			#endregion

			string[] _paramValue_xxx;
			for (int i = 0; i < _paramValue.Length; i++) {
				#region _paramValue_xxx = _paramValue[i].Split(valueSplitter_in);
				if (valueSplitter_in.Length == 1) {
					_paramValue_xxx = _paramValue[i].Split(valueSplitter_in[0]);
				} else {
					_paramValue_xxx = _paramValue[i].Split(
						new string[] { valueSplitter_in }, 
						StringSplitOptions.None
					);
				}
				#endregion

				for (int p = 0; p < param_in.Length; p++) {
					if (param_in[p] == _paramValue_xxx[0]) {
						_output[p] = _paramValue_xxx[1];
					}
				}
			}

			return _output;
		}
		#endregion

		#region public static string Array_Join<T>(...);
		public static string Array_Join<T>(
			string splitter_in,
			params T[] arguments_in
		) {
			if (
				(arguments_in == null)
				||
				(arguments_in.Length == 0)
			) {
				return "";
			} else {
				bool _isfirst = true;
				System.Text.StringBuilder _sb = new System.Text.StringBuilder();
				foreach (T _argument in arguments_in) {
					if (_isfirst) {
						_isfirst = false;
					} else {
						_sb.Append(splitter_in);
					}
					_sb.Append(_argument.ToString());
				}

				return _sb.ToString();
			}
		}
		#endregion
	}
}