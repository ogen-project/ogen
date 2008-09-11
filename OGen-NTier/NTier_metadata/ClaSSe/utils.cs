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

namespace OGen.NTier.lib.metadata {
	public class utils { private utils() {}

		public class SQLScriptOptions { private SQLScriptOptions() {}
			public class convert { private convert() {}

				#region public static cDBMetadata.eSQLScriptOptions FromName(...);
				public static cDBMetadata.eSQLScriptOptions FromName(string Name_) {
					for (int i = 0;; i++) {
						if (((cDBMetadata.eSQLScriptOptions)i).ToString() == Name_) {
							return (cDBMetadata.eSQLScriptOptions)i;
						} else if (((cDBMetadata.eSQLScriptOptions)i).ToString() == cDBMetadata.eSQLScriptOptions.invalid.ToString()) {
							return cDBMetadata.eSQLScriptOptions.invalid;
						}
					}
				}
				#endregion
			}

			#region public static string[] Names(...);
			public static string[] Names() {
				string[] Names_out;

				for (int i = 0;; i++) {
					if (((cDBMetadata.eSQLScriptOptions)i).ToString() == "invalid") {
						Names_out
							= new string[i];
						break;
					}
				}
				for (int i = 0;; i++) {
					if (((cDBMetadata.eSQLScriptOptions)i).ToString() == "invalid") {
						break;
					} else {
						Names_out[i]
							= ((cDBMetadata.eSQLScriptOptions)i).ToString();
					}
				}

				return Names_out;
			}
			#endregion
		}

		//public class convert {
		//	private convert() {}
		//
		//	// ...
		//}
	}
}