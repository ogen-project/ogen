long _iduser = 1L;

DO_User _user = new DO_User();
if (_user.getObject(_iduser))
	Console.Write(
	  "updating user login:\nLogin = {0}\nnew Login = {1} ... ", 
	  _user.Login, 
	  _user.Login = "whatever"
	);

	// makes no update unless changes have been made, 
	// you can force update by sending true parameter
	_user.updObject(false);
	
	Console.WriteLine("DONE!");
else
	Console.WriteLine("user not found");
_user.Dispose(); _user = null;
