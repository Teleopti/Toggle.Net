@echo off
SET SRCDIR=%~dp0
set SRCDIR=%SRCDIR:~0,-18%
set msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

%msbuild% runtests.msbuild /p:RootFolder=%srcdir%

echo.
pause