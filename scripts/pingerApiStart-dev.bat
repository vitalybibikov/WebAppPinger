@echo off

echo Started

SET currentPath=%~dp0
SET path=%~dp0..\backend\WebAppPinger
SET ASPNETCORE_ENVIRONMENT=dev

cd %path%

echo %path%

dotnet run 

cd %currentPath%

echo Finished