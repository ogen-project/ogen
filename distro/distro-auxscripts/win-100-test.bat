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

IF '%1' == '/test' GOTO test
IF NOT '%1' == '' GOTO error1


IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-solutions.txt" GOTO error2
IF NOT EXIST "%thisdir%..\distro-metadatas\OGen-projects.txt" GOTO error3


SET errorFound=
FOR /F "usebackq tokens=1,2,3,4,5,6,7,8,9 delims=, " %%a IN (`TYPE "%thisdir%..\distro-metadatas\OGen-projects.txt"`) DO (
	CALL %0 /test %%a %%b %%c %%d %%e %%f %%g %%h %%i %%j
)
IF '%errorFound%' == '' ECHO no errors!
SET errorFound=
PAUSE
GOTO eof


:test
	SHIFT

	SET paramError=

	IF '%1' == '' SET paramError=%1#%paramError%
	IF '%2' == '' SET paramError=%2#%paramError%
	IF '%3' == '' SET paramError=%3#%paramError%
	IF NOT '%4' == 't' IF NOT '%4' == 'f' SET paramError=%4#%paramError%
	IF NOT '%5' == 't' IF NOT '%5' == 'f' SET paramError=%5#%paramError%
	IF NOT '%6' == 't' IF NOT '%6' == 'f' SET paramError=%6#%paramError%
	IF NOT '%7' == 'MIT' IF NOT '%7' == 'GNU_GPL' IF NOT '%7' == 'GNU_LGPL' IF NOT '%7' == 'GNU_FDL' SET paramError=%7#%paramError%
	IF NOT '%8' == 't' IF NOT '%8' == 'f' SET paramError=%8#%paramError%
	IF NOT '%9' == 't' IF NOT '%9' == 'f' SET paramError=%9#%paramError%
	IF NOT EXIST "..\..\%1" SET paramError="solution does not exist"#%paramError%
	IF NOT EXIST "..\..\%1\%2" SET paramError="project does not exist"#%paramError%

	IF NOT '%paramError%' == '' ECHO %1, %2, %3, %4, %5, %6, %7, %8, %9
	IF NOT '%paramError%' == '' ECHO %paramError%
	IF NOT '%paramError%' == '' SET errorFound=1

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
