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
	public class cConditions : cClaSS_noR, iClaSS_noR, iConditions {
		#region public cConditions(...);
		public cConditions(cTemplate parent_ref_in) {
			parent_ref_ = parent_ref_in;

			//#region ClaSS_noR...
			condition_ = new ArrayList();
			//#endregion
		}
		#endregion

		#region Implementing - iClaSS_noR...
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "condition":
					return new cCondition(this, ""); // use any conditions you need
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
		#region private ArrayList condition_ { get; set; }
		private ArrayList condition_ {
			get { return base.Property_aggregate_collection["condition"]; }
			set { base.Property_aggregate_collection["condition"] = value; }
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
			get { return condition_.Count; }
		}
		#endregion
		#region public cCondition this[...] { get; }
		public cCondition this[int index_in] {
			get {
				return (cCondition)condition_[index_in];
			}
		}
		public cCondition this[string eval_in] {
			get {
				int _fi = Search(eval_in);
				return (_fi >= 0) ? 
					(cCondition)condition_[_fi] : 
					null;
			}
		}
		#endregion
		#endregion

		#region Methods...
		#region public void Clear(...);
		public void Clear() {
			condition_.Clear();
		}
		#endregion
		#region public int Add(...);
		public int Add(string eval_in, bool verifyExistenz_in) {
			int _fi;

			if (verifyExistenz_in) {
				_fi = Search(eval_in);
				if (_fi != -1)
					return _fi;
			}

			return condition_.Add(
				new cCondition(
					this, 
					eval_in
				)
			); // returns it's position
		}
		#endregion
		#region public int Search(...)
		public int Search(string eval_in) {
			for (int f = 0; f < condition_.Count; f++)
				if (((cCondition)condition_[f]).Eval == eval_in) // already exists!
					return f; // returns it's position

			return -1;
		}
		#endregion
		#endregion
	}
}