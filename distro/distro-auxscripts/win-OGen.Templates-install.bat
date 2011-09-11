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
IF NOT '%3' == '' GOTO install

SET thisdir=%~dp0
SET proj=%2
IF '%proj%' == '' GOTO error7

ECHO installing %proj%...

SET fw=
IF '%1' == '/1_1' SET fw=1.1
IF '%1' == '/2_0' SET fw=2.0
IF '%fw%' == '' GOTO error3


IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-solutions.txt" GOTO error4
IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-projects.txt" GOTO error5
IF NOT EXIST "%thisdir%..\distro-keys\OGen-public.snk" GOTO error6


CALL "%thisdir%win-SET_SDK_PATH.bat" %1


SET token=
FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9 delims=, " %%a IN (`sn -t "%thisdir%..\distro-keys\OGen-public.snk"^|find "Public key token is "`) DO (
	SET token=%%e
)
IF '%token%' == '' GOTO error2


IF NOT EXIST "%thisdir%..\bin"                                MKDIR "%thisdir%..\bin"
IF NOT EXIST "%thisdir%..\bin\OGen-%proj%-Templates-%fw%"     MKDIR "%thisdir%..\bin\OGen-%proj%-Templates-%fw%"
IF NOT EXIST "%thisdir%..\bin\OGen-%proj%-Templates-%fw%\bin" MKDIR "%thisdir%..\bin\OGen-%proj%-Templates-%fw%\bin"

TYPE "%thisdir%..\distro-templates\OGen.%proj%.templates-1.Web.config">"%thisdir%..\bin\OGen-%proj%-Templates-%fw%\Web.config"
FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9 delims=, " %%a IN (`TYPE "%thisdir%..\distro-metadatas\OGen-projects.txt"`) DO (
	CALL %0 %1 %proj% %%a %%b %%c %%d %%e %%f %%g %%h %%i
)
TYPE "%thisdir%..\distro-templates\OGen.%proj%.templates-2.Web.config">>"%thisdir%..\bin\OGen-%proj%-Templates-%fw%\Web.config"
FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9 delims=, " %%a IN (`dir /a-d /one /b "%thisdir%..\..\OGen-%proj%\%proj%_templates\*.*"`) DO (
	IF NOT '%%a' == 'AssemblyInfo.cs' IF NOT '%%a' == '%proj%_templates-7.1.csproj' IF NOT '%%a' == '%proj%_templates-7.1.csproj.user' IF NOT '%%a' == '%proj%_templates-8.csproj' IF NOT '%%a' == '%proj%_templates-8.csproj.user' IF NOT '%%a' == 'Web.config' (
		COPY "%thisdir%..\..\OGen-%proj%\%proj%_templates\%%a" "%thisdir%..\bin\OGen-%proj%-Templates-%fw%"
	)
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
	ECHO ERROR 2: - Can't determine token
	PAUSE
GOTO eof
:error3
	ECHO.
	ECHO.
	ECHO ERROR 3: - must specify framework version
	PAUSE
GOTO eof
:error4
	ECHO.
	ECHO.
	ECHO ERROR 4: - Can't find file 'distro-metadatas\OGen-solutions.txt'
	PAUSE
GOTO eof
:error5
	ECHO.
	ECHO.
	ECHO ERROR 5: - Can't find file 'distro-metadatas\OGen-projects.txt'
	PAUSE
GOTO eof
:error6
	ECHO.
	ECHO.
	ECHO ERROR 6: - Can't find file 'distro-keys\OGen-public.snk'
	PAUSE
GOTO eof
:error7
	ECHO.
	ECHO.
	ECHO ERROR 7: - must specify project
	PAUSE
GOTO eof


:install
	SHIFT
	SHIFT

	IF NOT '%1' == 'OGen' IF NOT '%1' == 'OGen-%proj%' GOTO eof

	IF '%5' == 'f' SET binDir=bin\Release
	IF '%5' == 't' SET binDir=bin

	:: is web app
	IF '%5' == 't' (
		COPY "%thisdir%..\..\%1\%2\%binDir%\%3-%fw%.dll" "%thisdir%..\bin\OGen-%proj%-Templates-%fw%\bin"
	) ELSE (
		:: is not a Release, hence:
		IF '%9' == 'f' GOTO eof

		:: not on GAC, hence:
		IF '%4' == 'f' GOTO eof

		ECHO 				^<add assembly="%3-%fw%, Version=0.1.1000.20000, Culture=neutral, PublicKeyToken=%token%" /^>>>"%thisdir%..\bin\OGen-%proj%-Templates-%fw%\Web.config"
	)
GOTO eof


:eof
::SET thisdir=
::SET token=
::SET fw=