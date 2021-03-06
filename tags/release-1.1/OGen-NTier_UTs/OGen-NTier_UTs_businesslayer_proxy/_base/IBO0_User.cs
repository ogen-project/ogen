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

namespace OGen.NTier.UTs.lib.businesslayer.proxy {
	/// <summary>
	/// Interface for User BusinessObject.
	/// </summary>
	public interface IBO0_User {
		#region Properties...
		#endregion

		#region Methods...
		long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in, 
			bool selectIdentity_in, 
			string login_in, 
			out bool constraintExist_out
		);
		OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(
			long idUser_in, 
			string login_in, 
			out bool exists_out
		);
		OGen.NTier.UTs.lib.datalayer.proxy.SO_User[] Record_Open_byGroup(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in, 
			string login_in, 
			out long recordLength_out
		);
		#endregion
	}
}