@echo off

IF NOT "%VS140COMNTOOLS%" == "" (call "%VS140COMNTOOLS%vsvars32.bat")

.paket\paket.bootstrapper.exe
.paket\paket.exe update

msbuild.exe /tv:14.0 "MahApps.Metro.Simple.Demo.sln" /p:configuration=Debug /p:platform="Any CPU" /m /t:Clean,Rebuild
msbuild.exe /tv:14.0 "MahApps.Metro.Simple.Demo.sln" /p:configuration=Release /p:platform="Any CPU" /m /t:Clean,Rebuild
