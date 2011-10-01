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
SET proj=%2
IF '%proj%' == '' GOTO error7

ECHO uninstalling %proj%...

SET fw=
IF '%1' == '/1_1' SET fw=1.1
IF '%1' == '/2_0' SET fw=2.0
IF '%fw%' == '' GOTO error3


::ECHO "%thisdir%..\bin\OGen-%proj%-Templates-%fw%"
IF EXIST "%thisdir%..\bin\OGen-%proj%-Templates-%fw%" RMDIR /s /q "%thisdir%..\bin\OGen-%proj%-Templates-%fw%"
PAUSE


GOTO eof


:error3
	ECHO.
	ECHO.
	ECHO ERROR 3: - must specify framework version
	PAUSE
GOTO eof
:error7
	ECHO.
	ECHO.
	ECHO ERROR 7: - must specify project
	PAUSE
GOTO eof


:eof
::SET thisdir=
::SET SetEnvironmentPath=
::SET token=
::SET fw=