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

namespace OGen.NTier.lib.metadata {
	public class cDBMetadata_Table_Fields_FK {
		#region public cDBMetadata_Table_Fields_FK(...);
		public cDBMetadata_Table_Fields_FK(
			cDBMetadata_Table parent_ref_in, 
			bool onlyFK_in
		) {
			onlyFK_ = onlyFK_in;
			parent_ref_ = parent_ref_in;
		}
		#endregion

		#region private Properties...
		private bool onlyFK_;
		#endregion
		#region public Properties...
		#region public cDBMetadata_Table Parent_ref { get; set; }
		private cDBMetadata_Table parent_ref_;
		public cDBMetadata_Table Parent_ref {
			get { return parent_ref_; }
		}
		#endregion
		//---
		#region public int Count { get; }
		public int Count {
			get {
				int Count_out = 0;
				for (int f = 0; f < parent_ref_.Fields.Count; f++)
					// ToDos here! get a proper bool condition!
					if (
						(
							(onlyFK_)
							&&
							(parent_ref_.Fields[f].FK.TableName != "")
						)
						||
						(
							(!onlyFK_)
							&&
							(!(parent_ref_.Fields[f].FK.TableName != ""))
						)
					)
						Count_out++;

						return Count_out;
			}
		}
		#endregion
		#region public cDBMetadata_Table_Field this[int index_in] { get; }
		public cDBMetadata_Table_Field this[int index_in] {
			get {
				int _c = -1;
				for (int f = 0; f < parent_ref_.Fields.Count; f++) {
					if (
						(
							onlyFK_
							&&
							(parent_ref_.Fields[f].FK.TableName != string.Empty)
						)
						||
						(
							!onlyFK_
							&&
							(parent_ref_.Fields[f].FK.TableName == string.Empty)
						)
					) {
						_c++;
						if (_c == index_in)
							return parent_ref_.Fields[f];
					}
				}

				return null;
			}
		}
		#endregion
		#endregion
	}
}