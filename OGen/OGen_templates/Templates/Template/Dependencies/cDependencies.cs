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
	public class cDependencies : cClaSS_noR, iClaSS_noR, iDependencies {
		#region public cDependencies(...);
		public cDependencies(cTemplate parent_ref_in) {
			parent_ref_ = parent_ref_in;

			//#region ClaSS_noR...
			dependency_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSS_noR...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "dependency":
					return new cDependency(this, ""); // use any arguments you need
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
		#region private ArrayList dependency_ { get; set; }
		private ArrayList dependency_ {
			get { return base.Property_aggregate_collection["dependency"]; }
			set { base.Property_aggregate_collection["dependency"] = value; }
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
			get { return dependency_.Count; }
		}
		#endregion
		#region public cDependency this[...] { get; }
		public cDependency this[int index_in] {
			get {
				return (cDependency)dependency_[index_in];
			}
		}
		public cDependency this[string name_in] {
			get {
				int _fi = Search(name_in);
				return (_fi >= 0) ? 
					(cDependency)dependency_[_fi] : 
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			dependency_.Clear();
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

			return dependency_.Add(
				new cDependency(
					this, 
					name_in
				)
			); // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string name_in) {
			for (int f = 0; f < dependency_.Count; f++)
				if (((cDependency)dependency_[f]).Name == name_in) // already exists!
					return f; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}