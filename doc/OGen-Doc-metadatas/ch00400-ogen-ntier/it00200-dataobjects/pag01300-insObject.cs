long _iduser = 0L;

DO_User _user = new DO_User();
_user.Login = "fmonteiro";
_user.Password = "passpub";
// assigning selectIdentity parameter to true retrieves Sequence/Identity for IDUser
_iduser = _user.insObject(true);
_user.Dispose(); _user = null;

Console.WriteLine(
  "user inserted, at:\nIDUser = {0}", 
  _iduser
);
