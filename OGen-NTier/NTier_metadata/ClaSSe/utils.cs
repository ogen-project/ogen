#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

This file is part of OGen.

OGen is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as published by 
the Free Software Foundation; either version 2 of the License, or 
(at your option) any later version.

OGen is distributed in the hope that it will be useful, 
but WITHOUT ANY WARRANTY; without even the implied warranty of 
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the 
GNU General Public License for more details.

You should have received a copy of the GNU General Public License 
along with OGen; if not, write to the

	Free Software Foundation, Inc., 
	59 Temple Place, Suite 330, 
	Boston, MA 02111-1307 USA 

							- or -

	http://www.fsf.org/licensing/licenses/gpl.txt

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