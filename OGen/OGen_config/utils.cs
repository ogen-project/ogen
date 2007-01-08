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

namespace OGen.lib.config {
	/// <summary>
	/// Provides a number of classes with static auxiliar methods for the OGen.lib.config namespace.
	/// </summary>
	public class utils { private utils() {}
		static utils() {
			applicationname_ = null;
		}

		#region public static string ApplicationName();
		private static string applicationname_;

		/// <summary>
		/// Gets the current running Application Name.
		/// </summary>
		public static string ApplicationName {
			get {
				if (applicationname_ == null) {
					string _applicationname_aux = Environment.CommandLine.Trim();

					int _end;
					if (_applicationname_aux.IndexOf("\"", 0) == 0) {
						_end = _applicationname_aux.IndexOf("\"", 1);
						_applicationname_aux = _applicationname_aux.Substring(1, _end - 1);
					} else {
						_end = _applicationname_aux.IndexOf(" ");
						if (_end > 0) {
							_applicationname_aux = _applicationname_aux.Substring(0, _end);
						}
					}

					applicationname_ = _applicationname_aux;
				}

				return applicationname_;
			}
		}
		#endregion
	}
}
