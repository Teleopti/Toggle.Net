@echo off
SET SRCDIR=%~dp0
set SRCDIR=%SRCDIR:~0,-22%
set nugetpackages=%srcdir%\code\packages
set nugetexe=%srcdir%\code\.nuget\nuget.exe
set msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

%nugetexe% install  -o %nugetpackages%
%msbuild% runtests.msbuild

echo.
pause