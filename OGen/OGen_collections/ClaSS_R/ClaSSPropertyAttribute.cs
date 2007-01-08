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
	[AttributeUsage(
		 AttributeTargets.Property, // | AttributeTargets.Field, 
		 AllowMultiple = false
	)]
	public class ClaSSPropertyAttribute : System.Attribute {
		#region public ClaSSPropertyAttribute(...);
		public ClaSSPropertyAttribute(
			string name_in, 
			eType type_in
		) : this (
			name_in, 
			type_in, 
			true // default
		) {
		}
		public ClaSSPropertyAttribute(
			string name_in, 
			eType type_in, 
			bool synchronizeState_in
		) {
			name_ = name_in;
			type_ = type_in;
			synchronizestate_ = synchronizeState_in;
		}
		#endregion

		public enum eType {
			standard = 0, 
			aggregate = 1, 
			aggregate_collection = 2, 

			invalid = 3
		}

		#region public string Name { get; }
		private string name_;
		public string Name {
			get { return name_; }
		}
		#endregion
		#region public eType Type { get; }
		private eType type_;
		public eType Type {
			get { return type_; }
		}
		#endregion
		#region public bool SynchronizeState { get; }
		private bool synchronizestate_;
		public bool SynchronizeState {
			get { return synchronizestate_; }
			//set { synchronizestate_ = value; }
		}
		#endregion
	}
}