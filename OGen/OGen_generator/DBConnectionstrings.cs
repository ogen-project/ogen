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
using System.Collections;
using OGen.lib.datalayer;

namespace OGen.lib.generator {
	public class DBConnectionstrings {
		#region public DBConnectionstrings();
		public DBConnectionstrings() {
			dbconnectionstrings_ = new ArrayList();
		}
		#endregion

		private ArrayList dbconnectionstrings_;

		#region public DBConnectionstring this[int index_in] { get; }
		public DBConnectionstring this[int index_in] {
			get { return (DBConnectionstring)dbconnectionstrings_[index_in]; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return dbconnectionstrings_.Count; }
		}
		#endregion

		#region internal bool Contains_disableIfNot(eDBServerTypes dbServerTypes_in);
		internal bool Contains_disableIfNot(eDBServerTypes dbServerTypes_in) {
			bool contains_disableifnot_out = false;
			for (int d = 0; d < dbconnectionstrings_.Count; d++) {
				if (((DBConnectionstring)dbconnectionstrings_[d]).DBServerType == dbServerTypes_in) {
					((DBConnectionstring)dbconnectionstrings_[d]).enabled_aux__ = true;
					contains_disableifnot_out = true;
				} else {
					((DBConnectionstring)dbconnectionstrings_[d]).enabled_aux__ = false;
				}
			}
			return contains_disableifnot_out;
		}
		#endregion

		#region public bool Contains(eDBServerTypes dbServerTypes_in);
		public bool Contains(eDBServerTypes dbServerTypes_in) {
			for (int d = 0; d < dbconnectionstrings_.Count; d++) {
				if (((DBConnectionstring)dbconnectionstrings_[d]).DBServerType == dbServerTypes_in) {
					return true;
				}
			}
			return false;
		}
		#endregion
		#region public void Clear();
		public void Clear() {
			dbconnectionstrings_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(
			eDBServerTypes dbServerType_in, 
			string connectionstring_in
		) {
			return dbconnectionstrings_.Add(
				new DBConnectionstring(
					dbServerType_in, 
					connectionstring_in
				)
			);
		}
		#endregion
	}
}