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


IF NOT '%1' == '' GOTO clearBin


IF NOT EXIST "%thisdir%distro-metadatas\OGen-solutions.txt" GOTO error2
IF NOT EXIST "%thisdir%distro-metadatas\OGen-projects.txt" GOTO error3


ECHO about to delete binaries and objects for present solution
ECHO are you sure?
PAUSE


FOR /F "usebackq tokens=1,2,3,4,5,6,7,8 delims=, " %%a IN (`TYPE "%thisdir%distro-metadatas\OGen-projects.txt"`) DO (
	CALL %0 %%a %%b %%c %%d %%e %%f %%g %%h
)
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


:clearBin
	IF EXIST "%thisdir%..\%1\%2\bin" (
		RMDIR /S /Q "%thisdir%..\%1\%2\bin">nul
		::IF NOT ERRORLEVEL 1 ECHO can't delete: "%thisdir%..\%1\%2\bin"
		IF EXIST "%thisdir%..\%1\%2\bin" ECHO can't delete: "%thisdir%..\%1\%2\bin"
	)
	IF EXIST "%thisdir%..\%1\%2\obj" (
		RMDIR /S /Q "%thisdir%..\%1\%2\obj">nul
		::IF NOT ERRORLEVEL 1 ECHO can't delete: "%thisdir%..\%1\%2\obj"
		IF EXIST "%thisdir%..\%1\%2\obj" ECHO can't delete: "%thisdir%..\%1\%2\obj"
	)


:eof
SET thisdir=
