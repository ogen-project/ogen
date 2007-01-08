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
	public class cClaSSeGen_Link : cClaSS_noR {
		#region public cClaSSeGen_Link(...);
		public cClaSSeGen_Link() : this (string.Empty, string.Empty) { }
		public cClaSSeGen_Link(string from_in, string to_in) {
			From = from_in;
			To = to_in;
			Type = ClaSSPropertyAttribute.eType.standard;
		}
		#endregion

		#region implementing cClaSS_noR...
		#region public override object Property_new(string name_in);
		public override object Property_new(string name_in) {
			switch (name_in) {
				//case "Fields":
				//	return new cFields_R_inherit();
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

		#region public string From { get; set; }
//		private string from_;
//
//		[ClaSSPropertyAttribute("from", ClaSSPropertyAttribute.eType.standard)]
//		public string From {
//			get { return from_; }
//			set { from_ = value; }
//		}
		public string From {
			get { return base.Property_standard["from"]; }
			set { base.Property_standard["from"] = value; }
		}
		#endregion
		#region public string To { get; set; }
//		private string to_;
//
//		[ClaSSPropertyAttribute("to", ClaSSPropertyAttribute.eType.standard)]
//		public string To {
//			get { return to_; }
//			set { to_ = value; }
//		}
		public string To {
			get { return base.Property_standard["to"]; }
			set { base.Property_standard["to"] = value; }
		}
		#endregion
		#region public ClaSSPropertyAttribute.eType Type { get; set; }
//		private ClaSSPropertyAttribute.eType type_;
//		public ClaSSPropertyAttribute.eType Type {
//			get { return type_; }
//			set { type_ = value; }
//		}
//
//		[ClaSSPropertyAttribute("type", ClaSSPropertyAttribute.eType.standard)]
//		private string type__ {
//			get { return type_.ToString(); }
//			set { type_ = utils.ClaSS.PropertyTypes.convert.FromName(value); }
//		}
		public ClaSSPropertyAttribute.eType Type {
			get { return utils.ClaSS.PropertyTypes.convert.FromName(base.Property_standard["type"]); }
			set { base.Property_standard["type"] = value.ToString(); }
		}
		#endregion
	}
}