@echo off
REM Start the LocalDB instance
sqllocaldb start mssqllocaldb

REM Get the LocalDB instance info and store it in a temporary file
sqllocaldb info mssqllocaldb > temp.txt

REM Extract the Instance pipe name
for /f "tokens=*" %%i in (temp.txt) do (
    echo %%i | findstr "Instance pipe name" > nul && (
        set "pipeLine=%%i"
    )
)

REM Remove the "Instance pipe name: " part from the string
setlocal enabledelayedexpansion
set "pipeName=!pipeLine:Instance pipe name: =!"

REM Set "Server=" in front so we dont need to do that in code
set "connectionString=Server=!pipeName!"

REM Write the pipe name to the specified text file
echo !connectionString! > "C:\Users\Seb H\Documents\GitHub\FlavorMatch\ClassLibrary\DatabaseServer.txt"

REM Display a message confirming the write operation
echo.
echo The Instance pipe name has been written to DatabaseServer.txt:
echo !connectionString!

REM Clean up the temporary file
del temp.txt

REM Pause to keep the command prompt open
pause
