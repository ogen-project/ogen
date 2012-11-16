#region Copyright (C) 2002 Francisco Monteiro
/*

OGen
Copyright (C) 2002 Francisco Monteiro

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/
#endregion

namespace OGen.Libraries.DocumentationCodeSamples.UnitTests {
	using System;
#if NUnit
	using NUnit.Framework;
#else
	using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

#if NUnit
	[TestFixture]
#else
	[TestClass]
#endif
	public class HowTo_UseTransactions_betweenDOs_operations {
		public HowTo_UseTransactions_betweenDOs_operations() {
		}

#if NUnit
		[Test]
#else
		[TestMethod]
#endif
		public void HowTo() {

//<document>
string _testid = DateTime.Now.Ticks.ToString();
bool _constraint;
long _iduser;
long _ifprofile;

// we need a shared connection between Data Objects
OGen.Libraries.DataLayer.DBConnection _con = OGen.NTier.Kick.Libraries.DataLayer.DO__Utilities.DBConnection_createInstance(
	OGen.NTier.Kick.Libraries.DataLayer.DO__Utilities.DBServerType,
	OGen.NTier.Kick.Libraries.DataLayer.DO__Utilities.DBConnectionstring,
	string.Empty
);

Exception _exception = null;
try {
	// before beginning a transaction we need to open the connection
	_con.Open();

	// beginning transaction
	_con.Transaction.Begin();

	OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_User _user 
		= new OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_User();
	// performing some operations on User Data Object
	_user.Login = _testid;
	_user.Password = _testid;
	_user.IFApplication_isNull = true;
	// sharing connection with User Data Object
	_iduser = OGen.NTier.Kick.Libraries.DataLayer.DO_CRD_User.insObject(
		_user,
		true,
		out _constraint,
		_con
	);
	// handling constraint code should be added here

	OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile _profile 
		= new OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_Profile();
	// performing some operations on User Data Object
	_profile.Name = _testid;
	_profile.IFApplication_isNull = true;
	// sharing connection with Group Data Object
	_ifprofile = OGen.NTier.Kick.Libraries.DataLayer.DO_CRD_Profile.insObject(
		_profile,
		true,
		_con
	);

	OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_UserProfile _userprofile
		= new OGen.NTier.Kick.Libraries.DataLayer.Shared.Structures.SO_CRD_UserProfile();
	// performing some operations on User Data Object
	_userprofile.IFProfile = _ifprofile;
	_userprofile.IFUser = _iduser;
	// sharing connection with Group Data Object
	OGen.NTier.Kick.Libraries.DataLayer.DO_CRD_UserProfile.setObject(
		_userprofile,
		false,
		_con
	);

	// commit transaction
	_con.Transaction.Commit();

} catch (Exception _ex) {

	// rollback transaction
	_con.Transaction.Rollback();

	_exception = _ex;

} finally {

	//// terminate transaction
	//if (_con.Transaction.InTransaction) {
	//    _con.Transaction.Terminate();
	//}

	//// closing connection
	//if (_con.IsOpen) {
	//    _con.Close();
	//}

	// no need to (conditionally) terminate transaction and close connection, 
	// simply disposing connection will do all that
	_con.Dispose();
	_con = null;

}
if (_exception != null)
	throw _exception;
//</document>

			// the only porpuses is to keep documentation code samples updated by: 
			// 1) ensure documentation code samples are compiling 
			// 2) no exceptions are beeing thrown by documentation code samples
			Assert.IsTrue(
				true,
				"documentation code sample is failing"
			);

		}
	}
}