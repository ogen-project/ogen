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
	public class cTable_noR_aggregate : cClaSS_noR, iClaSS_noR, iTable {
		#region public cTable_noR_aggregate(...);
		public cTable_noR_aggregate() : this ("") { }
		public cTable_noR_aggregate(string name_in) {
			fields_ = new cFields_noR_aggregate();
			Name = name_in;
		}
		#endregion

		#region implementing iClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
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

		#region public iFields Fields { get; }
		private iFields fields_ {
			get { return (iFields)Property_aggregate["Fields"]; }
			set { Property_aggregate["Fields"] = value; }
		}

		public iFields Fields {
			get { return fields_; }
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