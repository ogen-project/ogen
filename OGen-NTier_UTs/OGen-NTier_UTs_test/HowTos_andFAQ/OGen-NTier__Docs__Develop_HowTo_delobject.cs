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

namespace OGen.NTier.UTs.howtos {
	class HowTo_delObject {
		public HowTo_delObject() {
//<document>
long _iduser = 1L;

OGen.NTier.UTs.lib.datalayer.DO_User _user = new OGen.NTier.UTs.lib.datalayer.DO_User();
if (_user.getObject(_iduser)) {
	Console.Write(
	  "deleting user {0} ... ",
	  _user.Fields.Login
	);

	//--- if parameter not specified uses object property _user.IDUser
	//_user.delObject(_iduser);

	//-- so in the case no need to provide IDUser
	_user.delObject();

	Console.WriteLine("DONE!");
} else {
	Console.WriteLine("user not found");
}
_user.Dispose(); _user = null;
//</document>
		}
	}
}