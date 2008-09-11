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
:: is a doc project, hence:
IF '%8' == 't' GOTO eof

SET fw=
IF '%1' == '/1_1' SET fw=1.1
IF '%1' == '/2_0' SET fw=2.0
IF '%fw%' == '' GOTO error4

IF NOT '%2' == '' GOTO uninstall


SET SetEnvironmentPath=
IF '%1' == '/1_1' IF EXIST "C:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Tools\vsvars32.bat" SET SetEnvironmentPath="c:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Tools\vsvars32.bat"
IF '%1' == '/2_0' IF EXIST "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" SET SetEnvironmentPath="C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat"
IF '%SetEnvironmentPath%' == '' GOTO error1
::CALL %SetEnvironmentPath% x86
  CALL %SetEnvironmentPath% %PROCESSOR_ARCHITECTURE%


IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-solutions.txt" GOTO error2
IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-projects.txt" GOTO error3


FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9 delims=, " %%a IN (`TYPE "%thisdir%..\distro-metadatas\OGen-projects.txt"`) DO (
	CALL %0 %1 %%a %%b %%c %%d %%e %%f %%g %%h %%i
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
:error4
	ECHO.
	ECHO.
	ECHO ERROR 4: - must specify framework version
	PAUSE
GOTO eof


:uninstall
	SHIFT

	:::: is not a Release, hence:
	::IF '%9' == 'f' GOTO eof
	:::: is a Web App, hence:
	::IF '%5' == 't' GOTO eof
	:::: is an Executable, hence:
	::IF '%6' == 't' GOTO eof
	:::: is a Doc project, hence:
	::IF '%8' == 't' GOTO eof

	IF EXIST "%thisdir%..\bin\%3-%fw%.dll" DEL /q "%thisdir%..\bin\%3-%fw%.dll"
	IF EXIST "%thisdir%..\bin\%3-%fw%.exe" DEL /q "%thisdir%..\bin\%3-%fw%.exe"
GOTO eof


:eof
SET SetEnvironmentPath=
SET thisdir=