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
	public class cClaSSeGen_Links : cClaSS_noR {
		#region public cClaSSeGen_Links(...);
		public cClaSSeGen_Links() : base() {
			links_ = new ArrayList();
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				case "link":
					return new cClaSSeGen_Link();
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

		#region private ArrayList links_;
//		private ArrayList links_;
//
//		[ClaSSPropertyAttribute("link", ClaSSPropertyAttribute.eType.aggregate_collection)]
//		private ArrayList links__ {
//			get { return links_; }
//			set { links_ = value; }
//		}
		private ArrayList links_ {
			get { return base.Property_aggregate_collection["link"]; }
			set { base.Property_aggregate_collection["link"] = value; }
		}
		#endregion
		#region public int Count { get; }
		public int Count {
			get { return links_.Count; }
		}
		#endregion
		#region public cClaSSeGen_Link this[int index_in] { get; }
		public cClaSSeGen_Link this[int index_in] {
			get {
				return (cClaSSeGen_Link)links_[index_in];
			}
		}
		#endregion
		#region public cClaSSeGen_Link this[string from_in, string to_in] { get; }
		public cClaSSeGen_Link this[string from_in, string to_in] {
			get {
				int t = Search(from_in, to_in);
				return (t != -1) ? (cClaSSeGen_Link)links_[t] : null;
			}
		}
		#endregion

		#region public int Add(string from_in, string to_in);
		public int Add(string from_in, string to_in) {
			int s = Search(from_in, to_in);
			if (s != -1) return s;

			return links_.Add(
				new cClaSSeGen_Link(from_in, to_in)
			);
		}
		#endregion
		#region public int Search(string from_in, string to_in);
		public int Search(string from_in, string to_in) {
			for (int f = 0; f < links_.Count; f++) {
				if (
					(((cClaSSeGen_Link)links_[f]).From == from_in)
					&&
					(((cClaSSeGen_Link)links_[f]).To == to_in)
				) {
					return f;
				}
			}
			return -1;
		}
		#endregion
	}
}