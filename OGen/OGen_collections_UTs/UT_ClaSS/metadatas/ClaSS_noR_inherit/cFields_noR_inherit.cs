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
	public class cFields_noR_inherit : cClaSS_noR, iClaSS_noR, iFields {
		#region public cFields_noR_inherit(...);
		public cFields_noR_inherit() {
			field_ = new ArrayList();
		}
		#endregion

		#region implementing iClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "Field":
					return new cField_noR_inherit();
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

		#region private ArrayList field_ { get; set; }
		private ArrayList field_ {
			get { return Property_aggregate_collection["Field"]; }
			set { Property_aggregate_collection["Field"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return field_.Count; }
		}
		#endregion
		#region public iField this[int field_in] { get; }
		public iField this[int field_in] {
			get {
				return (iField)field_[field_in];
			}
		}
		#endregion
		#region public iField this[string name_in] { get; }
		public iField this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (iField)field_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return field_.Add(
				new cField_noR_inherit(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < field_.Count; f++) {
				if (((cField_noR_inherit)field_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}