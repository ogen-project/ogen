#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

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