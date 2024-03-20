@echo off
setlocal

set "directory=C:\TestDirectory"
set "extension=.ref"

cd /d "%directory%" || exit /b

echo Удаляем файлы с расширением %extension%:

dir /b *%extension%

del *%extension%

echo Файлы с расширением %extension% удалены.

endlocal
