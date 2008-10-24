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
using System.Reflection;
using System.IO;

using OGen.NTier.UTs.lib.businesslayer.proxy;

namespace OGen.NTier.UTs.lib.business.client {
	/// <summary>
	/// User business client.
	/// </summary>
	public abstract class BC0_User : IBO_User {
		static BC0_User(
		) {
			businessobject_ = (IBO_User)utils.BusinessAssembly.CreateInstance(
				"OGen.NTier.UTs.lib.businesslayer.BDO_User"
			);
		}

		protected static IBO_User businessobject_;

		#region public long insObject(...);
		public long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in, 
			bool selectIdentity_in, 
			string login_in, 
			out bool constraintExist_out
		) {
			return businessobject_.insObject(
				user_in, 
				selectIdentity_in, 
				login_in, 
				out constraintExist_out
			);
		}
		#endregion
		#region public OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(...);
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(
			long idUser_in, 
			string login_in, 
			out bool exists_out
		) {
			return businessobject_.getObject(
				idUser_in, 
				login_in, 
				out exists_out
			);
		}
		#endregion
		#region public OGen.NTier.UTs.lib.datalayer.proxy.SO_User[] Record_Open_byGroup(...);
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User[] Record_Open_byGroup(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in, 
			string login_in, 
			out long recordLength_out
		) {
			return businessobject_.Record_Open_byGroup(
				IDGroup_search_in, 
				page_in, 
				page_numRecords_in, 
				login_in, 
				out recordLength_out
			);
		}
		#endregion
	}
}