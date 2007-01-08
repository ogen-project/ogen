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

using OGen.lib.collections;

namespace OGen.lib.templates {
	public class cArguments : cClaSS_noR, iClaSS_noR, iArguments {
		#region public cArguments(...);
		public cArguments(cTemplate parent_ref_in) {
			parent_ref_ = parent_ref_in;

			//#region ClaSS_noR...
			argument_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSS_noR...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "argument":
					return new cArgument(this, ""); // use any arguments you need
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
		#region private ArrayList argument_ { get; set; }
		private ArrayList argument_ {
			get { return base.Property_aggregate_collection["argument"]; }
			set { base.Property_aggregate_collection["argument"] = value; }
		}
		#endregion
		#endregion
		#region Properties...
		#region public cTemplate Parent_ref;
		private cTemplate parent_ref_;
		public cTemplate Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return argument_.Count; }
		}
		#endregion
		#region public cArgument this[...] { get; }
		public cArgument this[int index_in] {
			get {
				return (cArgument)argument_[index_in];
			}
		}
		public cArgument this[string name_in] {
			get {
				int _fi = Search(name_in);
				return (_fi >= 0) ? 
					(cArgument)argument_[_fi] : 
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			argument_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(string name_in, bool verifyExistenz_in) {
			int _fi;

			if (verifyExistenz_in) {
				_fi = Search(name_in);
				if (_fi != -1)
					return _fi;
			}

			return argument_.Add(
				new cArgument(
					this, 
					name_in
				)
			); // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string name_in) {
			for (int f = 0; f < argument_.Count; f++)
				if (((cArgument)argument_[f]).Name == name_in) // already exists!
					return f; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}