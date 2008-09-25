long _iduser = 1L;

DO_User _user = new DO_User();
if (_user.getObject(_iduser))
	Console.Write(
	  "deleting user {0} ... ", 
	  _user.Login
	);

	//--- if parameter not specified uses object property _user.IDUser
	//_user.delObject(_iduser);

	//-- so in the case no need to provide IDUser
	_user.delObject();
	
	Console.WriteLine("DONE!");
else
	Console.WriteLine("user not found");
_user.Dispose(); _user = null;