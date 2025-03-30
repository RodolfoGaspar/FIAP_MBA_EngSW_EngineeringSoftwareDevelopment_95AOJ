@echo off
REM Verifica se o caminho do projeto foi passado como argumento
IF "%1"=="" (
    echo Por favor, forneça o caminho para o projeto.
    echo Exemplo: update-backend.bat "C:\caminho\para\o\repositorio\backend"
    exit /b 1
)

REM Usar o caminho do projeto fornecido como argumento
set PROJECT_PATH=%1

REM Navega até o diretório do projeto
cd /d %PROJECT_PATH%

REM Limpa os binários antigos
echo Limpando saída anterior...
del /q /f /s PagamentosAPI\out\*
del /q /f /s ReservasAPI\out\*
del /q /f /s VagasAPI\out\*

REM Gera os binários .dll
echo Gerando os binários .dll...
dotnet publish PagamentosAPI -c Release -o PagamentosAPI/out
dotnet publish ReservasAPI -c Release -o ReservasAPI/out
dotnet publish VagasAPI -c Release -o VagasAPI/out

REM Verifica se os binários foram gerados corretamente
IF NOT EXIST "PagamentosAPI\out" (
    echo Falha ao gerar os binários para PagamentosAPI.
    exit /b 1
)

IF NOT EXIST "ReservasAPI\out" (
    echo Falha ao gerar os binários para ReservasAPI.
    exit /b 1
)

IF NOT EXIST "VagasAPI\out" (
    echo Falha ao gerar os binários para VagasAPI.
    exit /b 1
)
