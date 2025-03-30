#!/bin/bash

# Verifica se o caminho do projeto foi passado como argumento
if [ -z "$1" ]; then
    echo "Por favor, forneça o caminho para o projeto."
    echo "Exemplo: ./update-backend.sh '/caminho/para/o/repositorio/backend'"
    exit 1
fi

# Usar o caminho do projeto fornecido como argumento
PROJECT_PATH=$1

# Navega até o diretório do projeto
cd $PROJECT_PATH

# Limpa os binários antigos
echo "Limpando saída anterior..."
rm -rf PagamentosAPI/out/*
rm -rf ReservasAPI/out/*
rm -rf VagasAPI/out/*

# Gera os binários .dll
echo "Gerando os binários .dll..."
dotnet publish PagamentosAPI -c Release -o PagamentosAPI/out
dotnet publish ReservasAPI -c Release -o ReservasAPI/out
dotnet publish VagasAPI -c Release -o VagasAPI/out

# Verifica se os binários foram gerados corretamente
if [ ! -d "PagamentosAPI/out" ]; then
    echo "Falha ao gerar os binários para PagamentosAPI."
    exit 1
fi

if [ ! -d "ReservasAPI/out" ]; then
    echo "Falha ao gerar os binários para ReservasAPI."
    exit 1
fi

if [ ! -d "VagasAPI/out" ]; then
    echo "Falha ao gerar os binários para VagasAPI."
    exit 1
fi
