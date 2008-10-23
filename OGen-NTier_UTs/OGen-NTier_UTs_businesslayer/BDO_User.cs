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

using OGen.NTier.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.NTier.UTs.lib.datalayer;
using OGen.NTier.UTs.lib.datalayer.proxy;
using OGen.NTier.UTs.lib.businesslayer.proxy;

namespace OGen.NTier.UTs.lib.businesslayer {
	/// <summary>
	/// User BusinessObject which provides access to <see cref="OGen.NTier.UTs.lib.datalayer.DO_User">DO_User</see> for the Business Layer.
	/// </summary>
	[BOClassAttribute("BDO_User", "BDO")]
	public sealed 
#if !NET_1_1
		partial 
#endif
		class BDO_User : 
#if NET_1_1
			BDO0_User, 
#endif
			IBO_User
	{
		#region public BDO_User(...);
		///
		public BDO_User(
		) {
		}
		#endregion

		#region private Properties...
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#region public long insObject(...);
		[BOMethodAttribute("insObject", true)]
		public long insObject(
			SO_User user_in, 
			bool selectIdentity_in, 
			string login_in, 
			out bool constraintExist_out
		) {
			long _iduser;
			DO_User _user = new DO_User();
			_user.Fields = (SO_User)user_in;
			_iduser = _user.insObject(
				selectIdentity_in,
				out constraintExist_out
			);
			_user.Dispose();

			return _iduser;
		}
		#endregion
		#region public SO_User getObject(...);
		[BOMethodAttribute("getObject", true)]
		public SO_User getObject(
			long idUser_in, 
			string login_in, 
			out bool exists_out
		) {
			DO_User _do_user = new DO_User();
			exists_out = _do_user.getObject(idUser_in);
			SO_User _so_user_out = (SO_User)_do_user.Fields;
			_do_user.Dispose();

			return _so_user_out;
		}
		#endregion
		#region public SO_User[] Record_Open_byGroup(...);
		[BOMethodAttribute("Record_Open_byGroup", true)]
		public SO_User[] Record_Open_byGroup(
			long IDGroup_search_in, 
			int page_in, 
			int page_numRecords_in, 
			string login_in
		) {
			SO_User[] _output;

			DO_User _do_user = new DO_User();
			if (
				(page_in > 0) 
				&& 
				(page_numRecords_in > 0)
			) {
				_do_user.Record.Open_byGroup(
					IDGroup_search_in,
					page_in,
					page_numRecords_in
				);
			} else {
				_do_user.Record.Open_byGroup(
					IDGroup_search_in
				);
			}
			_output = _do_user.Record.Serialize().SO_User;
			_do_user.Record.Close();
			_do_user.Dispose();

			return _output;
		}
		#endregion
		#endregion
	}
}
