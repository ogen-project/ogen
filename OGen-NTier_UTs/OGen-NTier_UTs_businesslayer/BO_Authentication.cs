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
using System.Xml.Serialization;

using OGen.NTier.lib.datalayer;
using OGen.NTier.lib.businesslayer;

using OGen.NTier.UTs.lib.datalayer;

namespace OGen.NTier.UTs.lib.businesslayer {
	/// <summary>
	/// Authentication BusinessObject.
	/// </summary>
	[BOClassAttribute("BO_Authentication", "BO")]
	public class BO_Authentication : BO0_Authentication {
		#region public BO0_Authentication(...);
		public BO_Authentication(
		) : base (
		) {
			// ...
		}
		#endregion

		#region private Properties...
		#endregion
		#region public Properties...
		#endregion

		#region private Methods...
		#endregion
		#region public Methods...
		#region public override string Login(...);
		[BOMethodAttribute("Login", true)]
		public override string Login(
			string login_in, 
			string password_in
		) {
			bool _validLogin;
			long _iduser = -1;

			DO_User _user = new DO_User();
			if (
				_user.getObject_byLogin(login_in)
				&&
				(_user.Fields.Password == password_in)
			) {
				_iduser = _user.Fields.IDUser;
			}
			_user.Dispose();

			return _iduser.ToString();
		}
		#endregion
		#region public override void Logout(...);
		[BOMethodAttribute("Logout", true)]
		public override void Logout(
		) {
			// ...
		}
		#endregion
		#endregion
	}
}
