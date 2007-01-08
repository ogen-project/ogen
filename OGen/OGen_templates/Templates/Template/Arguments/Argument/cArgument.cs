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

using OGen.lib.collections;

namespace OGen.lib.templates {
	public class cArgument : cClaSS_noR, iClaSS_noR {
		#region public cArgument(...);
		public cArgument(cArguments parent_ref_in, string name_in) {
			parent_ref_ = parent_ref_in;

			//#region ClaSS_noR...
			Name = name_in;
			Value = string.Empty;
			//#endregion
		}
		#endregion

		#region Implementing - iClaSS_noR...
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

		#region Properties - ClaSS_noR...
		#region public string Name { get; set; }
		public string Name {
			get { return base.Property_standard["name"]; }
			set { base.Property_standard["name"] = value; }
		}
		#endregion
		#region public string Value { get; set; }
		public string Value {
			get { return base.Property_standard["value"]; }
			set { base.Property_standard["value"] = value; }
		}
		#endregion
		#endregion
		#region Properties...
		private cArguments parent_ref_;
		#endregion

		#region Methods...
		#region public override string ToString();
		public override string ToString() {
			return Name;
		}
		#endregion
		#endregion
	}
}