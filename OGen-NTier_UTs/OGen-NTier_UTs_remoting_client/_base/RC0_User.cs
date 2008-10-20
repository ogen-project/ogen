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
using System.Runtime.Remoting;

namespace OGen.NTier.UTs.distributed.remoting.client {
	public interface IRS_User {
		long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in,
			out bool constraintExist_out,
			string login_in
		);
		OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(
			long idUser_in,
			out bool exists_out,
			string login_in
		);
	}

	public abstract class RC0_User {
		public RC0_User() {
			rs_user_ = (IRS_User)RemotingServices.Connect(
				typeof(IRS_User),
				"tcp://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_User.remoting"
				//"http://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_User.soap"
			);
		}

		#region private Properties...
		private IRS_User rs_user_;
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#region public long insObject(...);
		public long insObject(
			OGen.NTier.UTs.lib.datalayer.proxy.SO_User user_in,
			bool selectIdentity_in,
			out bool constraintExist_out,
			string login_in
		) {
			return rs_user_.insObject(
				user_in,
				selectIdentity_in,
				out constraintExist_out,
				login_in
			);
		}
		#endregion
		#region public OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(...);
		public OGen.NTier.UTs.lib.datalayer.proxy.SO_User getObject(
			long idUser_in,
			out bool exists_out,
			string login_in
		) {
			return rs_user_.getObject(
				idUser_in,
				out exists_out,
				login_in
			);
		}
		#endregion
		#endregion
	}
}