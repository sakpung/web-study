@echo OFF

rem Copyright (c) LEAD Technologies, Inc.
rem This batch file checks whether the bit-ness of IIS Express and the specified configuration matches
rem The value is stored in the registry at HKEY_CURRENT_USER\SOFTWARE\Microsoft\VisualStudio\%VERSION%\WebProjects
rem Where %VERSION% is 12.0 for Visual Studio 2013, 14.0 for Visual Studio 2015, etc.
rem Usage: CheckIISExpressBitness %1 %2
rem %1: Current platform, either x86 or x64. Will treat AnyCPU as x86
rem %2: Visual Studio Version (12.0, 14.0, etc)
rem If the values do not match, this batch file will show a warning message to instruct the user on how to change the setting.

setlocal ENABLEEXTENSIONS

if /i "%1" == "x86" set LT_VALUE_TOCHECK=0x0
if /i "%1" == "AnyCPU" set LT_VALUE_TOCHECK=0x0
if /i "%1" == "x64" set LT_VALUE_TOCHECK=0x1

if not defined LT_VALUE_TOCHECK goto usage_label

set LT_KEY_NAME="HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\%2%\WebProjects"
set LT_VALUE_NAME=Use64BitIISExpress
set LT_REG_VALUE=0x0

FOR /F "usebackq skip=2 tokens=1-2*" %%A IN (`REG QUERY %LT_KEY_NAME% /v %LT_VALUE_NAME% 2^>nul`) DO (
    set LT_REG_VALUE=%%C
)

set LT_REG_CONFIG=""
if /i %LT_REG_VALUE% == 0x0 set LT_REG_CONFIG=x86
if /i %LT_REG_VALUE% == 0x1 set LT_REG_CONFIG=x64
set LT_PLATFORM=%1
if /i "%1" == "AnyCPU" set LT_PLATFORM=x86

if defined LT_REG_VALUE (
   rem Check the value against expected
   if not %LT_REG_VALUE% == %LT_VALUE_TOCHECK% (
      rem The values do not match, show the error in VS Errors list
      echo %~f0: Error: IIS Express is currently set to run as %LT_REG_CONFIG% while the current configuration is %LT_PLATFORM%. The service will not run under these options. Go to "Tools/Options/Projects Solutions/Web Projects" in your Visual Studio IDE and check/uncheck the value of "Use the 64 bit version of IIS Express for web sites and projects" accordingly.
      set errorlevel=1
   ) else (
      rem The values match.
      set errorlevel=0
   )
) else (
   echo %~f0: Warning: %LT_KEY_NAME%\%LT_VALUE_NAME% not found in the regsitry.
   set errorlevel=1
)

goto finish_label

:usage_label
echo %~f0: Error: USAGE CheckIISExpressBitness Platform Version
set errorlevel=1
:finish_label
exit %errorlevel%
