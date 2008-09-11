@ECHO OFF
SET OGenPath=

::FOR /F "usebackq tokens=2* delims=> " %%a IN (`subst^|find /i "o:\: => "^|find /i "\ogen"`) DO (
FOR /F "usebackq tokens=2* delims=> " %%a IN (`subst^|find /i "\ogen"`) DO (
	SET OGenPath=%%b
)


IF "%OGenPath%" == "" GOTO eof
ECHO %OGenPath%



:eof
SET OGenPath=
PAUSE