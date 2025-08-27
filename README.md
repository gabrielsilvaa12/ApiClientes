# 📌 API de Gerenciamento de Clientes

Uma **API RESTful** robusta e completa desenvolvida em **ASP.NET Core 8** para o gerenciamento de clientes.  
Este projeto demonstra as melhores práticas de desenvolvimento back-end, incluindo arquitetura de serviços, persistência de dados com Entity Framework Core, validação de dados e integração com serviços externos.

---

## ✨ Funcionalidades Principais

- **CRUD Completo para Clientes**: Criar, Ler, Atualizar e Deletar (exclusão lógica) clientes.
- **Validação de CPF em Tempo Real**: Integração com a API do Ministério da Saúde (`scpa-backend.saude.gov.br`) para garantir autenticidade no cadastro.
- **Segurança e Boas Práticas**:
  - Exclusão Lógica (**Soft Delete**): clientes inativos, preservando histórico.
  - **Projeção de Dados**: listagem retorna apenas dados não-sensíveis.
  - **Código Organizado**: separação em **Models**, **Data**, **Services** e **Controllers**.
- **Documentação Interativa com Swagger**: interface **OpenAPI** para explorar e testar endpoints.

---

## 🚀 Tecnologias Utilizadas

| Tecnologia               | Descrição                                                                 |
|---------------------------|---------------------------------------------------------------------------|
| **.NET 8**               | Versão mais recente da plataforma da Microsoft.                           |
| **ASP.NET Core**         | Framework para construção de APIs de alta performance.                   |
| **Entity Framework Core**| ORM para comunicação com o banco de dados.                                |
| **SQL Server**           | Sistema de gerenciamento de banco de dados relacional.                   |
| **Swagger (Swashbuckle)**| Geração automática de documentação da API.                                |
| **Injeção de Dependência** | Gerenciamento de `DbContext` e serviços.                                |

---

## ⚙️ Como Executar o Projeto Localmente

### 🔹 Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/)
- [SQL Server Management Studio (SSMS)](https://aka.ms/ssmsfullsetup)

---

### 🔹 Passo 1 – Clone o Repositório
```bash
git clone <URL_DO_SEU_REPOSITORIO_AQUI>
cd ApiClientes
🔹 Passo 2 – Configure a Conexão com o Banco de Dados
O projeto está configurado para usar o SQL Server LocalDB, que já vem com o Visual Studio.

Abra o arquivo appsettings.json e confira a string de conexão:

json
Copiar código
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DbClientes;Trusted_Connection=True;MultipleActiveResultSets=true"
}
🔹 Passo 3 – Aplique as Migrations
Esse comando cria o banco de dados DbClientes e a tabela Clientes automaticamente.

No Console do Gerenciador de Pacotes (Ferramentas > NuGet > Console do Gerenciador de Pacotes), rode:

powershell
Copiar código
Update-Database
🔹 Passo 4 – Execute a Aplicação
Pressione F5 ou clique no botão ▶️ no Visual Studio.

O navegador abrirá automaticamente a documentação do Swagger.

📡 Endpoints da API
Base URL: http://localhost:<porta>/api/Clientes

Verbo	Rota	Descrição
POST	/	Cria um novo cliente (valida CPF em tempo real).
GET	/	Lista clientes ativos (somente 5 campos não-sensíveis).
GET	/{id}	Busca cliente específico pelo ID, retornando todos os dados.
PUT	/{id}	Atualiza os dados de um cliente existente.
DELETE	/{id}	Inativa o cliente (Soft Delete).

📖 Documentação
Acesse:
👉 http://localhost:<porta>/swagger

📂 Estrutura do Projeto
pgsql
Copiar código
ApiClientes/
 ├── Controllers/
 ├── Data/
 ├── Models/
 ├── Services/
 ├── appsettings.json
 └── Program.cs
📦 Exemplo de Payload (POST Cliente)
json
Copiar código
{
  "nome": "João Silva",
  "cpf": "12345678901",
  "email": "joao.silva@email.com",
  "telefone": "(11) 99999-9999",
  "endereco": "Rua Exemplo, 123, São Paulo - SP"
}
📌 Autor
Projeto desenvolvido para estudo e aplicação de boas práticas em ASP.NET Core 8.

Copiar código
