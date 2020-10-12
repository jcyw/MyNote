@echo off
for /f "delims=" %%b in (delFilePath.txt) do (
    rd /s /Q %%b
    md %%b
    echo delete suc %%b
    echo suc create empty file %%b
)
pause