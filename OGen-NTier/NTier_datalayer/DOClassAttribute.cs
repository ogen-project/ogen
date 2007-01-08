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

namespace OGen.NTier.lib.datalayer {
	/// <summary>
	/// DataObject Class Attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class DOClassAttribute : System.Attribute {
		#region public DOClassAttribute(...);
		/// <param name="name_in">Name</param>
		/// <param name="friendlyName_in">Friendly name</param>
		/// <param name="dbDescription_in">Description at DataBase</param>
		/// <param name="extendedDescription_in">Extended description</param>
		/// <param name="isVirtualTable_in">True if it is a View, False if it is a Table</param>
		/// <param name="isConfig_in">True if it is a Config Table, False if not</param>
		public DOClassAttribute(
			string			name_in, 
			string			friendlyName_in, 
			string			dbDescription_in, 
			string			extendedDescription_in, 
			bool			isVirtualTable_in, 
			bool			isConfig_in
		) {
			name_					= name_in;
			friendlyname_			= friendlyName_in;
			dbdescription_			= dbDescription_in;
			extendeddescription_	= extendedDescription_in;
			isvirtualtable_			= isVirtualTable_in;
			isconfig_				= isConfig_in;
		}
		#endregion

		#region public string Name { get; }
		private string name_;

		/// <summary>
		/// Name
		/// </summary>
		public string Name {
			get { return name_; }
		}
		#endregion
		#region public string FriendlyName { get; }
		private string friendlyname_;

		/// <summary>
		/// Friendly name
		/// </summary>
		public string FriendlyName {
			get { return friendlyname_; }
		}
		#endregion
		#region public string DBDescription { get; }
		private string dbdescription_;

		/// <summary>
		/// Description at DataBase
		/// </summary>
		public string DBDescription {
			get { return dbdescription_; }
		}
		#endregion
		#region public string ExtendedDescription { get; }
		private string extendeddescription_;

		/// <summary>
		/// Extended description
		/// </summary>
		public string ExtendedDescription {
			get { return extendeddescription_; }
		}
		#endregion
		#region public bool isVirtualTable { get; }
		private bool isvirtualtable_;

		/// <summary>
		/// Indicates if it is a View or Table. True if it is a View, False if it is a Table.
		/// </summary>
		public bool isVirtualTable {
			get { return isvirtualtable_; }
		}
		#endregion
		#region public bool isConfig { get; }
		private bool isconfig_;

		/// <summary>
		/// Indicates if it is a Config Table.
		/// </summary>
		public bool isConfig {
			get { return isconfig_; }
		}
		#endregion
	}
}