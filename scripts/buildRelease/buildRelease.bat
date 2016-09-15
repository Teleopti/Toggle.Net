@echo off
SET SRCDIR=%~dp0
set SRCDIR=%SRCDIR:~0,-22%


set nugetfolder="%SRCDIR%\code\.nuget"
set packageFolder="%SRCDIR%\code\packages"
set msbuild="%ProgramFiles(x86)%\MSBuild\14.0\Bin\MSBuild.exe"
set configuration=Release
set msbuildtasksVersion=1.4.0.65


echo Installing msbuildtasks to %PackageFolder%. Please wait...
%nugetFolder%\NuGet install MsBuildTasks -o %PackageFolder% -Version %msbuildtasksVersion%

echo.
set /p Version=Please enter version number, eg 1.2.0: 

%msbuild% nugetPackage.msbuild /v:q /t:BuildRelease

git checkout -- %SRCDIR%\code\Toggle.Net\Properties\AssemblyInfo.cs

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