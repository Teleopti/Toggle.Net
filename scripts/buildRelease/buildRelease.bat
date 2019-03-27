@echo off
SET SRCDIR=%~dp0
set SRCDIR=%SRCDIR:~0,-22%

echo.
set /p Version=Please enter version number, eg 1.2.0: 

dotnet msbuild nugetPackage.msbuild /t:BuildRelease

echo -------------------------------
echo.
echo Created a new nuget package with version %Version% to output folder.
echo.
echo Remember to...
echo * Tag current changeset with version %nugetversion%
echo * Push changes (tag) to server repo
echo * Push nuget package to nuget server (and symbol server)
echo.
pause