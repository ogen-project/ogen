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
	public interface IRS_Authentication {
		string Login(
			string login_in,
			string password_in
		);
		void Logout(
		);
	}

	public abstract class RC0_Authentication {
		public RC0_Authentication() {
			rs_authentication_ = (IRS_Authentication)RemotingServices.Connect(
				typeof(IRS_Authentication),
				"tcp://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_Authentication.remoting"
				//"http://127.0.0.1:8085/OGen.NTier.UTs.lib.distributed.remoting.server.RS_Authentication.soap"
			);
		}

		#region private Properties...
		private IRS_Authentication rs_authentication_;
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#region public string Login(...);
		public string Login(
			string login_in,
			string password_in
		) {
			return rs_authentication_.Login(
				login_in,
				password_in
			);
		}
		#endregion
		#region public void Logout(...);
		public void Logout(
		) {
			rs_authentication_.Logout(
			);
		}
		#endregion
		#endregion
	}
}