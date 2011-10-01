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


IF NOT EXIST "C:\Program Files\Microsoft SDKs\Windows\v7.0\Bin\x64" GOTO skip
ECHO %ComSpec%|find "SysWOW64">NUL
IF ERRORLEVEL 1 GOTO skip
ECHO "%PATH%"|FIND "C:\Program Files\Microsoft SDKs\Windows\v7.0\Bin\x64">NUL
IF ERRORLEVEL 1 SET PATH=%PATH%;C:\Program Files\Microsoft SDKs\Windows\v7.0\Bin\x64
GOTO eof
:skip


SET SetEnvironmentPath=
IF '%1' == '/1_1' IF EXIST "C:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Tools\vsvars32.bat" SET SetEnvironmentPath="c:\Program Files\Microsoft Visual Studio .NET 2003\Common7\Tools\vsvars32.bat"
IF '%1' == '/2_0' IF EXIST "C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat" SET SetEnvironmentPath="C:\Program Files\Microsoft Visual Studio 8\VC\vcvarsall.bat"
IF NOT EXIST %SetEnvironmentPath% GOTO error2
IF '%SetEnvironmentPath%' == '' GOTO error1
::CALL %SetEnvironmentPath% x86
  CALL %SetEnvironmentPath% %PROCESSOR_ARCHITECTURE%
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
	ECHO ERROR 2: - Can't find Microsoft Visual Studio .NET tools
	PAUSE
GOTO eof


:eof
SET SetEnvironmentPath=
