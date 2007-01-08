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
	public class cField_noR_aggregate : cClaSS_noR, iClaSS_noR, iField {
		#region public cField_noR_aggregate(...);
		public cField_noR_aggregate() : this (string.Empty) { }
		public cField_noR_aggregate(string name_in) {
			Name = name_in;
			isPK = false;
			DBType_inDB = (int)SqlDbType.Variant;
		}
		#endregion

		#region implementing iClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				default:
					throw new Exception(string.Format(
						"{0}.{1}.Property_new(): - invalid Name.", 
						this.GetType().Namespace,
						this.GetType().Name
					));
			}
		}
		#endregion
		#endregion

		#region public bool isPK { get; set; }
		public bool isPK {
			get { return bool.Parse(Property_standard["isPK"]); }
			set { Property_standard["isPK"] = value.ToString(); }
		}
		#endregion
		#region public object DBType_inDB { get; set; }
		public object DBType_inDB {
			get { return int.Parse(Property_standard["DBType_inDB"]); }
			set { Property_standard["DBType_inDB"] = value.ToString(); }
		}
		#endregion
		#region public string Name { get; set; }
		public string Name {
			get { return Property_standard["Name"]; }
			set { Property_standard["Name"] = value; }
		}
		#endregion
	}
}