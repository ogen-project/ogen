@ECHO OFF
SET configfile=win-05-OGen.configs.no-svn.txt
IF EXIST %configfile% GOTO eof

ECHO OGenPath,C:\OGen.BerliOS.svn>%configfile%
ECHO ReleasePath,_release.no-svn>>%configfile%
::ECHO SVNIgnoreExtension,.no-svn>>%configfile%

:eof
SET %configfile%=