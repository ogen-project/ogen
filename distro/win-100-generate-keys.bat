::
:: OGen
:: Copyright (c) 2002 Francisco Monteiro
:: 
:: Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
:: 
:: The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
:: 
:: THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
:: 
@ECHO OFF
SET thisdir=%~dp0


CALL "%thisdir%win-050-SET_SDK_PATH.bat"


IF NOT EXIST "%thisdir%distro-keys" MKDIR "%thisdir%distro-keys"


:makekey
	IF EXIST "%thisdir%distro-keys\OGen.snk" GOTO eof_makekey
	sn -k "%thisdir%distro-keys\OGen.snk"
	ATTRIB +r "%thisdir%distro-keys\OGen.snk"
:eof_makekey

:makepublickey
	IF EXIST "%thisdir%distro-keys\OGen-public.snk" DEL /q /f "%thisdir%distro-keys\OGen-public.snk"
	sn -p "%thisdir%distro-keys\OGen.snk" "%thisdir%distro-keys\OGen-public.snk"
	ATTRIB +r "%thisdir%distro-keys\OGen-public.snk"
:eof_makepublickey


PAUSE
GOTO eof


:error1
	ECHO.
	ECHO.
	ECHO ERROR 1: - Can't set environment for Microsoft Visual Studio .NET tools
	PAUSE
GOTO eof


:eof
SET thisdir=
