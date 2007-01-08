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
	public class cProperty_standard {
		public cProperty_standard() {
			shashtable_ = new SHashtable();
		}

		private SHashtable shashtable_;

		public SHashtable.ISHashtableKeys Keys {
			get { return shashtable_.Keys; }
		}
		public int Count {
			get { return shashtable_.Count; }
		}
		public string this[int index_in] {
			get { return (string)shashtable_[index_in]; }
			set { shashtable_[index_in] = value; }
		}
		public string this[string name_in] {
			get { return (string)shashtable_[name_in]; }
			set { shashtable_[name_in] = value; }
		}

		public int Search(string name_in) {
			return shashtable_.Search(name_in);
		}
		public int Add(SHashtableItem item_in) {
			return shashtable_.Add(item_in);
		}
		public int Add(string name_in, string value_in) {
			return shashtable_.Add(name_in, value_in);
		}
	}
}