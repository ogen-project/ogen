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
SET parentdir=%thisdir%..
FOR /f "usebackq tokens=1* delims=^|" %%a IN (`ECHO %parentdir%`) DO (
	SET parentdir=%%~fa
)
IF "%parentdir%" == "" GOTO error1


IF NOT EXIST "%thisdir%bin" MKDIR "%thisdir%bin"


::--- <OGen.Dia.presentationlayer.console>
SET configtemplate=OGen.Dia.presentationlayer.console

SET configdir=%parentdir%\OGen-Dia\Dia-console
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-Dia\Dia_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
SET configdir=%parentdir%\OGen-Dia\Dia-test
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-Dia\Dia_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-1.1.exe.config
SET templatefile=%thisdir%bin\OGen-Dia-templates-1.1\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-2.0.exe.config
SET templatefile=%thisdir%bin\OGen-Dia-templates-2.0\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
::--- </OGen.Dia.presentationlayer.console>
ECHO.

::--- <OGen.Doc.presentationlayer.console>
SET configtemplate=OGen.Doc.presentationlayer.console

SET configdir=%parentdir%\OGen-Doc\Doc-console
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-Doc\Doc_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
SET configdir=%parentdir%\OGen-Doc\Doc-test
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-Doc\Doc_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-1.1.exe.config
SET templatefile=%thisdir%bin\OGen-Doc-templates-1.1\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-2.0.exe.config
SET templatefile=%thisdir%bin\OGen-Doc-templates-2.0\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
::--- </OGen.Doc.presentationlayer.console>
ECHO.

::--- <OGen.Doc.presentationlayer.winforms>
SET configtemplate=OGen.Doc.presentationlayer.winforms

SET configdir=%parentdir%\OGen-Doc\Doc
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-Doc\Doc_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-1.1.exe.config
SET templatefile=%thisdir%bin\OGen-Doc-templates-1.1\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-2.0.exe.config
SET templatefile=%thisdir%bin\OGen-Doc-templates-2.0\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
::--- </OGen.Doc.presentationlayer.winforms>
ECHO.

::--- <OGen.NTier.presentationlayer.console>
SET configtemplate=OGen.NTier.presentationlayer.console

SET configdir=%parentdir%\OGen-NTier\NTier-console
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-NTier\NTier_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%parentdir%\OGen-NTier\NTier-test
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-NTier\NTier_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-1.1.exe.config
SET templatefile=%thisdir%bin\OGen-NTier-templates-1.1\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-2.0.exe.config
SET templatefile=%thisdir%bin\OGen-NTier-templates-2.0\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
::--- </OGen.NTier.presentationlayer.console>
ECHO.

::--- <OGen.NTier.presentationlayer.winforms>
SET configtemplate=OGen.NTier.presentationlayer.winforms

SET configdir=%parentdir%\OGen-NTier\NTier
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-NTier\NTier_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-1.1.exe.config
SET templatefile=%thisdir%bin\OGen-NTier-templates-1.1\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-2.0.exe.config
SET templatefile=%thisdir%bin\OGen-NTier-templates-2.0\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
::--- </OGen.NTier.presentationlayer.winforms>
ECHO.

::--- <OGen.XSD.presentationlayer.console>
SET configtemplate=OGen.XSD.presentationlayer.console

SET configdir=%parentdir%\OGen-XSD\XSD-console
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-XSD\XSD_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%parentdir%\OGen-XSD\XSD-test
SET configfile=%configdir%\app.config
SET templatefile=%parentdir%\OGen-XSD\XSD_templates\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-1.1.exe.config
SET templatefile=%thisdir%bin\OGen-XSD-templates-1.1\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)

SET configdir=%thisdir%bin
SET configfile=%configdir%\%configtemplate%-2.0.exe.config
SET templatefile=%thisdir%bin\OGen-XSD-templates-2.0\templates.config.xml
IF EXIST "%configdir%" (
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-1.config">"%configfile%"
	ECHO     ^<add key="Templates" value="%templatefile%" /^>>>"%configfile%"
	ECHO     ^<add key="ogenPath" value="%thisdir%bin" /^>>>"%configfile%"
	TYPE "%thisdir%distro-templates\%configtemplate%.exe-2.config">>"%configfile%"
	ECHO %configfile%
)
::--- </OGen.XSD.presentationlayer.console>
ECHO.


GOTO eof


:error1
	ECHO.
	ECHO.
	ECHO ERROR 1: - can't determine parent dir
::PAUSE
GOTO eof


:eof
SET thisdir=
SET parentdir=
SET configdir=
SET configfile=
SET templatefile=
PAUSE
