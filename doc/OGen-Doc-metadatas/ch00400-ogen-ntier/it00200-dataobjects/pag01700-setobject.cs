long _iduser = 1L;
long _idgroup = 1L;

DO_UserGroup _usergroup = new DO_UserGroup();
_usergroup.IDUser = _iduser;
_usergroup.IDGroup = _idgroup;
_usergroup.Relationdate = DateTime.Now;
_usergroup.Defaultrelation = false;

// if relation exists, it updates, if not it inserts:
_usergroup.setObject();

_usergroup.Dispose(); _user = null;
