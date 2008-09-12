#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (c) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion
using System;
using System.Data;

using OGen.lib.datalayer;
using OGen.NTier.lib.datalayer;

namespace OGen.NTier.UTs.lib.datalayer {
	/// <summary>
	/// vUserGroup DataObject which provides access to vUserGroup view at Database.
	/// </summary>
	public sealed 
#if !NET_1_1
		partial
#endif
		class DO_vUserGroup : 
#if NET_1_1
		DO0_vUserGroup, 
#endif
		IDisposable {
#if NET_1_1
		#region public DO_vUserGroup();
		///
		public DO_vUserGroup() : base() {
		}
		/// <summary>
		/// Making the use of Database Transactions possible on a sequence of operations across multiple DataObjects.
		/// </summary>
		/// <param name="connection_in">opened Database connection with an initiated Transaction</param>
		public DO_vUserGroup(DBConnection connection_in) : base(connection_in) {
		}
		#endregion
#endif

		#region public Properties...
		#endregion
		#region public Methods...
		#endregion
	}
}