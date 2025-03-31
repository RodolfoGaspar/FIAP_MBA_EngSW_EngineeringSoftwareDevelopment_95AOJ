# Sistema de Gerenciamento de Estacionamento  

Repositório para o trabalho final da matéria de Engineering Software Development do MBA de Engenharia de Software da FIAP - 2025.

Solução para gestão de vagas, reservas e pagamentos em estacionamentos, com APIs em .NET Core (C#), base de dados em SQLite, frontend em React.Js e suporte a Docker.  

## Estrutura do Projeto

**Backend**  

- `VagasAPI`: Microserviço de gerenciamento de vagas
- `ReservasAPI`: Microserviço de gerenciamente de reservas, com validação de horários  
- `PagamentosAPI`: Microserviço de gerenciamento de pagamento  
 

**Frontend**  

- `ParkingFrontend`: Aplicação React.Js 

**DevOps**  

- `docker-compose.yml`: Orquestração de containers  
- `Dockerfiles`: Configurações individuais para cada serviço

⚙️ **SmartPark - CI/CD Pipeline.
Este repositório utiliza GitHub Actions para automatizar o build e a publicação das imagens Docker. A cada push na branch main, o pipeline executa os seguintes passos:**

- Checkout do código
- Autenticação no Docker Hub
- Build e publicação dos binários das APIs .NET
- Build das imagens Docker com docker compose
- Push das imagens para o Docker Hub

## 🚀 Primeiros Passos  

### Pré-requisitos  

- .NET Core 6.0 SDK  
- Node.js 22.14 
- Docker 28.0.1  
- Postman/Newman (para testes de API)  

## ▶️ Execução  

### Via Docker  

Com o Docker instalado, execute os comandos na raiz do projeto.

```bash
docker-compose pull
docker-compose up -d
```

## 🧪 Testes  

### Postman  

Importe as collections e environments do diretório `/postman`  

**Workspace Público**: [🔗 Link do Postman](https://www.postman.com/smart-park-7334/fiap-95aoj/overview)  

Como alternativa, as collections e enviroments do postman também estão disponíveis no diretório `Postman` deste repositório, seguindo a seguinte estrutura:

- `Collections`: Collections individuais para cada API, para o fluxo de sucesso e de validações
- `Enviroment`: Enviroment para testes em ambiente local (localhost)
- `Results`: Resultados dos testes (via runner) realizados em ambiente de desenvolvimento

## 🐳 Docker Hub  

- **API's**: [🔗 Imagem Docker - Backend](https://hub.docker.com/r/rodolfogaspar86/fiap_95aoj_smart_park-backend)
- **Frontend**: [🔗 Imagem Docker - Frontend](https://hub.docker.com/r/rodolfogaspar86/fiap_95aoj_smart_park-frontend) 


## 📄 Licença  

Distribuído sob licença MIT. Veja `LICENSE` para detalhes.
