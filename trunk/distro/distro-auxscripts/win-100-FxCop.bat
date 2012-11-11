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

IF NOT '%1' == '' GOTO error1


IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-solutions.txt" GOTO error2
IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-projects.txt" GOTO error3


SET errorFound=
type "%thisdir%..\distro-templates\OGen-2.0-1.FxCop.txt">"..\..\OGen-2.0.FxCop"
FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9,10 delims=, " %%a IN (`TYPE "%thisdir%..\distro-metadatas\OGen-projects.txt"`) DO (
	CALL :test %%a %%b %%c %%d %%e %%f %%g %%h %%i %%j
)
type "%thisdir%..\distro-templates\OGen-2.0-2.FxCop.txt">>"..\..\OGen-2.0.FxCop"

IF '%errorFound%' == '' ECHO no errors!
SET errorFound=
PAUSE
GOTO eof


:test
	SHIFT

	IF '%3' == 'f' IF '%4' == 'f' IF '%5' == 'f' IF '%8' == 'f' IF '%9' == 'f' (
		SET error=
		GOTO eof
	)
	IF '%0' == 'OGen-NTier_UTs' (
		SET error=
		GOTO eof
	)

	SET slash=
	FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9,10 delims=\" %%a IN (`ECHO %1`) DO (
		IF NOT '%%a' == '' SET slash=%%a
		IF NOT '%%b' == '' SET slash=%%a/%%b
		IF NOT '%%c' == '' SET slash=%%a/%%b/%%c
		IF NOT '%%d' == '' SET slash=%%a/%%b/%%c/%%d
		IF NOT '%%e' == '' SET slash=%%a/%%b/%%c/%%d/%%e
		IF NOT '%%f' == '' SET slash=%%a/%%b/%%c/%%d/%%e/%%f
		IF NOT '%%g' == '' SET slash=%%a/%%b/%%c/%%d/%%e/%%f/%%g
		IF NOT '%%h' == '' SET slash=%%a/%%b/%%c/%%d/%%e/%%f/%%g/%%h
		IF NOT '%%i' == '' SET slash=%%a/%%b/%%c/%%d/%%e/%%f/%%g/%%h/%%i
		IF NOT '%%j' == '' SET slash=%%a/%%b/%%c/%%d/%%e/%%f/%%g/%%h/%%i/%%j
	)

	IF '%5' == 'f' SET extension=dll
	IF '%5' == 't' SET extension=exe
	IF '%4' == 'f' SET debug=/Debug
	IF '%4' == 't' SET debug=
	echo   ^<Target Name="$(ProjectDir)/%0/%slash%/bin%debug%/%2-2.0.%extension%" Analyze="True" AnalyzeAllChildren="True" /^>>>"..\..\OGen-2.0.FxCop"

	SET debug=
	SET extension=
	SET slash=
	SET error=
GOTO eof


:error1
	ECHO.
	ECHO.
	ECHO ERROR 1: - invalid arguments: %1
	PAUSE
GOTO eof
:error2
	ECHO.
	ECHO.
	ECHO ERROR 2: - Can't find file 'OGen-solutions.txt'
	PAUSE
GOTO eof
:error3
	ECHO.
	ECHO.
	ECHO ERROR 3: - Can't find file 'OGen-projects.txt'
	PAUSE
GOTO eof


:eof
SET thisdir=
