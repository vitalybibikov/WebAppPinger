@echo off

echo Started

SET ASPNETCORE_ENVIRONMENT=dev
SET currentPath=%~dp0
SET mainpath=%~dp0..\backend\WebAppPinger.Data

cd %mainpath%

echo mainpath%

dotnet ef database update -c WebPingerDbContext

cd %currentPath%

echo Finished

