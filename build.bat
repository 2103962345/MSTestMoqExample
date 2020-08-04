@echo Off
set config=%1
if "%config%" == "" (
    set config=Release
)

set version=
if not "%BuildCounter%" == "" (
   set packversionsuffix=--version-suffix ci-%BuildCounter%
)

REM Detect MSBuild 15.0 path
if exist "%programfiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" (
    set msbuild="%programfiles(x86)%\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe"
REM %msbuild%
)
if exist "%programfiles(x86)%\Microsoft Visual Studio\2019\Professional\MSBuild\15.0\Bin\MSBuild.exe" (
    set msbuild="%programfiles(x86)%\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"
REM %msbuild%
)
if exist "%programfiles(x86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\15.0\Bin\MSBuild.exe" (
    set msbuild="%programfiles(x86)%\Microsoft Visual Studio\2019\Enterprise\MSBuild\15.0\Bin\MSBuild.exe"
REM %msbuild%
)

REM (optional) build.bat is in the root of our repo, cd to the correct folder where sources/projects are


echo Restore
call nuget restore MSTestMoqExample.sln
if not "%errorlevel%"=="0" goto failure

echo Build
call msbuild MSTestMoqExample.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

cd MSTestMoqExampleTests
echo Unit tests
"%programfiles(x86)%\Microsoft Visual Studio\2019\BuildTools\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" bin\%config%\MSTestMoqExampleTests.dll

cd ..

echo Pack
mkdir Build
call nuget pack "MSTestMoqExample\MSTestMoqExample.csproj" -Symbols -OutputDirectory Build -Properties Configuration=%config%;version="%version%"
if not "%errorlevel%"=="0" goto failure

call nuget push "Build\MSTestMoqExample.1.0.0.symbols.nupkg" 0a45457c-55d9-4608-a3c8-6799b67185d8 -Source https://eu.myget.org/F/non-mirror/symbols/api/v2/package
 call nuget help v
:success
exit 0

:failure
exit -1
