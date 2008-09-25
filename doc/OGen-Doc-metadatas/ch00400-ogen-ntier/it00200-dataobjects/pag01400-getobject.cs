long _iduser = 1L;

DO_User _user = new DO_User();
if (_user.getObject(_iduser))
	Console.WriteLine(
	  "user found:\nIDUser = {0}\nLogin = {1}", 
	  _iduser, 
	  _user.Login
	);
else
	Console.WriteLine("user not found");
_user.Dispose(); _user = null;