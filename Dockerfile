# Usa a imagem oficial do .NET 6 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia as APIs para o container
COPY PagamentosAPI/out/ ./PagamentosAPI/
COPY ReservasAPI/out/ ./ReservasAPI/
COPY VagasAPI/out/ ./VagasAPI/

# Copiar o banco de dados SQLite para dentro do container
COPY VagasAPI/Vagas.db /app/Vagas.db
COPY ReservasAPI/Reservas.db /app/Reservas.db
COPY PagamentosAPI/Pagamentos.db /app/Pagamentos.db

# Expose as portas
EXPOSE 5001
EXPOSE 5002
EXPOSE 5003

# Rodar as APIs simultaneamente em diferentes portas
CMD ["sh", "-c", "pwd & dotnet VagasAPI/VagasApi.dll --urls=http://0.0.0.0:5001 & dotnet ReservasAPI/ReservasAPI.dll --urls=http://0.0.0.0:5002 & dotnet PagamentosAPI/PagamentosAPI.dll --urls=http://0.0.0.0:5003 & wait"]