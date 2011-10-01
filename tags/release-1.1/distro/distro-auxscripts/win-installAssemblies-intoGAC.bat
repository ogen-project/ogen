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
SET fw=
IF '%1' == '/1_1' SET fw=1.1
IF '%1' == '/2_0' SET fw=2.0
IF '%fw%' == '' GOTO error6

IF '%2' == '/install' GOTO install
IF NOT '%2' == '' GOTO error5


::FOR /F "usebackq tokens=1* delims=^|" %%a IN (`cd`) DO (
::	IF NOT "%%~fa\" == "%~dp0" GOTO error7
::)


CALL "%thisdir%win-SET_SDK_PATH.bat"


IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-solutions.txt" GOTO error2
IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-projects.txt" GOTO error3


FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9 delims=, " %%a IN (`TYPE "%thisdir%..\distro-metadatas\OGen-projects.txt"`) DO (
	CALL %0 %1 /install %%a %%b %%c %%d %%e %%f %%g %%h %%i
)
PAUSE
GOTO eof


:error1
	ECHO.
	ECHO.
	ECHO ERROR 1: - Can't set environment for Microsoft Visual Studio .NET tools
	PAUSE
GOTO eof
:error2
	ECHO.
	ECHO.
	ECHO ERROR 2: - Can't find file 'distro-metadatas\OGen-solutions.txt'
	PAUSE
GOTO eof
:error3
	ECHO.
	ECHO.
	ECHO ERROR 3: - Can't find file 'distro-metadatas\OGen-projects.txt'
	PAUSE
GOTO eof
:error5
	ECHO.
	ECHO.
	ECHO ERROR 5: - invalid arguments: %2
	PAUSE
GOTO eof
:error6
	ECHO.
	ECHO.
	ECHO ERROR 6: - must specify framework version
	PAUSE
GOTO eof
:error7
	ECHO.
	ECHO.
	ECHO ERROR 7: - %~nx0 must be called from it's own directory: %~f0
	PAUSE
GOTO eof


:install
	SHIFT
	SHIFT

	:: is not a Release, hence:
	IF '%9' == 'f' GOTO eof

	IF '%5' == 'f' SET binDir=bin\Release
	IF '%5' == 't' SET binDir=bin
	IF '%5' == 't' GOTO eof

	IF '%4' == 'f' GOTO eof
	IF NOT EXIST "%thisdir%..\bin\%3-%fw%.dll" GOTO eof
	::gacutil /u %3
	gacutil /i "%thisdir%..\bin\%3-%fw%.dll"|find "Failure"
	IF NOT ERRORLEVEL 1 ECHO %3-%fw%.dll
GOTO eof


:eof
::SET binDir=
::SET hasErrors=
::SET thisdir=
