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
using System.Data;
using System.Collections;

using OGen.lib.collections;

namespace OGen.lib.collections.UTs.ClaSS.metadatas {
	public class cTables_noR_aggregate : cClaSS_noR, iClaSS_noR, iTables {
		#region public cTables_noR_aggregate(...);
		public cTables_noR_aggregate() {
			tables_ = new ArrayList();
		}
		#endregion

		#region implementing iClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "Tables":
					return new cTable_noR_aggregate();
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name: {2}", 
						this.GetType().Namespace,
						this.GetType().Name,
						name_in
					));
			}
		}
		#endregion
		#endregion

		#region private ArrayList tables_ { get; set; }
		private ArrayList tables_ {
			get { return Property_aggregate_collection["Tables"]; }
			set { Property_aggregate_collection["Tables"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return tables_.Count; }
		}
		#endregion
		#region public iTable this[int table_in] { get; }
		public iTable this[int table_in] {
			get {
				return (iTable)tables_[table_in];
			}
		}
		#endregion
		#region public iTable this[string name_in] { get; }
		public iTable this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (iTable)tables_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return tables_.Add(
				new cTable_noR_aggregate(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int t = 0; t < tables_.Count; t++) {
				if (((cTable_noR_aggregate)tables_[t]).Name == name_in) {
					return t;
				}
			}
			return -1;
		}
		#endregion
	}
}