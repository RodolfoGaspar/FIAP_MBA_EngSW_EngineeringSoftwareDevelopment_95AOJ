

# Sistema de Gerenciamento de Estacionamento  

Repositório para trabalho final da matéria Engineering Software Development do MBA de Engenharia de Software da FIAP - 2025.

Solução para gestão de vagas, reservas e pagamentos em estacionamentos, com APIs em .NET Core (C#), frontend em Node.js e suporte a Docker.  

## Estrutura do Projeto  
**Backend**  
- `VagasAPI`: Gerenciamento de vagas  
- `ReservasAPI`: Gerenciamente de reservas, com validação de horários  
- `PagamentosAPI`: Gerenciamento de pagamento  

**Frontend**  
- `ParkingFrontend`: Aplicação Node.js/Express com EJS  

**DevOps**  
- `docker-compose.yml`: Orquestração de containers  
- `Dockerfiles`: Configurações individuais para cada serviço  

## 🚀 Primeiros Passos  

### Pré-requisitos  
- .NET Core 6.0 SDK  
- Node.js 18.x  
- Docker Desktop 4.25+  
- Postman/Newman (para testes de API)  

### Instalação  
```bash
git clone https://github.com/seu-usuario/parking-system.git
cd parking-system
dotnet build ParkingSystem.sln
cd ParkingFrontend && npm install
```

## ▶️ Execução  

### Via Docker  
```bash
docker-compose up -d
```

## 🧪 Testes  

### Postman  
Importe as collections e environments do diretório `/postman`  

**Workspace Público**: [🔗 Link do Postman](https://www.postman.com/smart-park-7334/fiap-95aoj/overview)  

## 🐳 Docker Hub  
- **API's**: [🔗 Imagem Docker](https://hub.docker.com/r/thomasweyand/fiap_95aoj_smart_park-backend) 
- **Frontend**: [🔗 Imagem Docker](https://hub.docker.com/r/thomasweyand/fiap_95aoj_smart_park-frontend) 


## 📄 Licença  
Distribuído sob licença MIT. Veja `LICENSE` para detalhes.
