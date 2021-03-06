#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.NTier.Libraries.DataLayer {
	using System;

	/// <summary>
	/// DataObject Class Attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class DOClassAttribute : System.Attribute {
		#region public DOClassAttribute(...);
		/// <param name="name_in">Name</param>
		/// <param name="friendlyName_in">Friendly name</param>
		/// <param name="dbDescription_in">Description at Database</param>
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
			this.name_ = name_in;
			this.friendlyname_ = friendlyName_in;
			this.dbdescription_ = dbDescription_in;
			this.extendeddescription_ = extendedDescription_in;
			this.isvirtualtable_ = isVirtualTable_in;
			this.isconfig_ = isConfig_in;
		}
		#endregion

		#region public string Name { get; }
		private string name_;

		/// <summary>
		/// Name
		/// </summary>
		public string Name {
			get { return this.name_; }
		}
		#endregion
		#region public string FriendlyName { get; }
		private string friendlyname_;

		/// <summary>
		/// Friendly name
		/// </summary>
		public string FriendlyName {
			get { return this.friendlyname_; }
		}
		#endregion
		#region public string DBDescription { get; }
		private string dbdescription_;

		/// <summary>
		/// Description at Database
		/// </summary>
		public string DBDescription {
			get { return this.dbdescription_; }
		}
		#endregion
		#region public string ExtendedDescription { get; }
		private string extendeddescription_;

		/// <summary>
		/// Extended description
		/// </summary>
		public string ExtendedDescription {
			get { return this.extendeddescription_; }
		}
		#endregion
		#region public bool IsVirtualTable { get; }
		private bool isvirtualtable_;

		/// <summary>
		/// Indicates if it is a View or Table. True if it is a View, False if it is a Table.
		/// </summary>
		public bool IsVirtualTable {
			get { return this.isvirtualtable_; }
		}
		#endregion
		#region public bool IsConfig { get; }
		private bool isconfig_;

		/// <summary>
		/// Indicates if it is a Config Table.
		/// </summary>
		public bool IsConfig {
			get { return this.isconfig_; }
		}
		#endregion
	}
}