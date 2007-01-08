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

namespace OGen.lib.collections {
	public class cClaSSeGen_cClaSSes : cClaSS_noR {
		#region public cClaSSeGen_cClaSSes(...);
		public cClaSSeGen_cClaSSes() : base() {
			classes_ = new ArrayList();
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "claSS":
					return new cClaSSeGen_ClaSS();
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

		#region private ArrayList classes_;
//		private ArrayList classes_;
//
//		[ClaSSPropertyAttribute("claSS", ClaSSPropertyAttribute.eType.aggregate_collection)]
//		private ArrayList classes__ {
//			get { return classes_; }
//			set { classes_ = value; }
//		}

		private ArrayList classes_ {
			get { return base.Property_aggregate_collection["claSS"]; }
			set { base.Property_aggregate_collection["claSS"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return classes_.Count; }
		}
		#endregion
		#region public cClaSSeGen_ClaSS this[int index_in] { get; }
		public cClaSSeGen_ClaSS this[int index_in] {
			get {
				return (cClaSSeGen_ClaSS)classes_[index_in];
			}
		}
		#endregion
		#region public cClaSSeGen_ClaSS this[string name_in] { get; }
		public cClaSSeGen_ClaSS this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (cClaSSeGen_ClaSS)classes_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return classes_.Add(
				new cClaSSeGen_ClaSS(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < classes_.Count; f++) {
				if (((cClaSSeGen_ClaSS)classes_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}