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
	public class cClaSSeGen_Fields : cClaSS_noR {
		#region public cClaSSeGen_Fields(...);
		public cClaSSeGen_Fields() : base() {
			fields_ = new ArrayList();
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "field":
					return new cClaSSeGen_Field();
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

		#region private ArrayList fields_;
//		private ArrayList fields_;
//
//		[ClaSSPropertyAttribute("field", ClaSSPropertyAttribute.eType.aggregate_collection)]
//		private ArrayList fields__ {
//			get { return fields_; }
//			set { fields_ = value; }
//		}
		private ArrayList fields_ {
			get { return base.Property_aggregate_collection["field"]; }
			set { base.Property_aggregate_collection["field"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return fields_.Count; }
		}
		#endregion
		#region public cClaSSeGen_Field this[int index_in] { get; }
		public cClaSSeGen_Field this[int index_in] {
			get {
				return (cClaSSeGen_Field)fields_[index_in];
			}
		}
		#endregion
		#region public cClaSSeGen_Field this[string name_in] { get; }
		public cClaSSeGen_Field this[string name_in] {
			get {
				int t = Search(name_in);
				return (t != -1) ? (cClaSSeGen_Field)fields_[t] : null;
			}
		}
		#endregion

		#region public int Add(string name_in);
		public int Add(string name_in) {
			int s = Search(name_in);
			if (s != -1) return s;

			return fields_.Add(
				new cClaSSeGen_Field(name_in)
			);
		}
		#endregion
		#region public int Search(string name_in);
		public int Search(string name_in) {
			for (int f = 0; f < fields_.Count; f++) {
				if (((cClaSSeGen_Field)fields_[f]).Name == name_in) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}