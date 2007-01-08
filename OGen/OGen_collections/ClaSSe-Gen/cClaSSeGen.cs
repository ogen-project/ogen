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

namespace OGen.lib.collections {
	public class cClaSSeGen : cClaSS_noR {
		#region public cClaSSeGen(...);
		public cClaSSeGen() : base() {
			classes_ = new cClaSSeGen_cClaSSes();
			links_ = new cClaSSeGen_Links();
		}
		#endregion

		#region implementing cClaSS_noR...
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

		#region public cClaSSeGen_cClaSSes ClaSSes { get; }
//		private cClaSSeGen_cClaSSes classes_;
//
//		[ClaSSPropertyAttribute("claSSes", ClaSSPropertyAttribute.eType.aggregate, true)]
//		public cClaSSeGen_cClaSSes ClaSSes {
//			get { return classes_; }
//		}
		private cClaSSeGen_cClaSSes classes_ {
			get { return (cClaSSeGen_cClaSSes)base.Property_aggregate["claSSes"]; }
			set { base.Property_aggregate["claSSes"] = value; }
		}
		public cClaSSeGen_cClaSSes ClaSSes {
			get { return classes_; }
		}
		#endregion
		#region public cClaSSeGen_Links Links { get; }
//		private cClaSSeGen_Links links_;
//
//		[ClaSSPropertyAttribute("links", ClaSSPropertyAttribute.eType.aggregate)]
//		public cClaSSeGen_Links Links {
//			get { return links_; }
//		}
		private cClaSSeGen_Links links_ {
			get { return (cClaSSeGen_Links)base.Property_aggregate["links"]; }
			set { base.Property_aggregate["links"] = value; }
		}
		public cClaSSeGen_Links Links {
			get { return links_; }
		}
		#endregion

		#region public string Root { get; set; }
//		private string root_;
//
//		[ClaSSPropertyAttribute("root", ClaSSPropertyAttribute.eType.standard)]
//		public string Root {
//			get { return root_; }
//			set { root_ = value; }
//		}
		public string Root {
			get { return base.Property_standard["root"]; }
			set { base.Property_standard["root"] = value; }
		}
		#endregion
	}
}