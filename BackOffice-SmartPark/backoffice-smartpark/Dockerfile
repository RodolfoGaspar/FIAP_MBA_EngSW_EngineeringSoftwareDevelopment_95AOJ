# Usa uma imagem do Node.js para build
FROM node:18 AS build-frontend

# Define o diretório de trabalho
WORKDIR /app

# Copia apenas os arquivos de dependências primeiro
COPY package.json package-lock.json ./

# Garante que o npm sempre instale as dependências
RUN npm install

# Copia o restante dos arquivos do projeto
COPY . .

# Garante que sempre pega a versão mais recente do build
RUN npm run build

# Usa uma imagem do Nginx para servir os arquivos estáticos
FROM nginx:alpine AS production

# Copia os arquivos do build para o servidor web
COPY --from=build-frontend /app/dist /usr/share/nginx/html

# Expõe a porta 80 para acesso ao frontend
EXPOSE 80

# Define o comando para rodar o servidor Nginx
CMD ["nginx", "-g", "daemon off;"]
