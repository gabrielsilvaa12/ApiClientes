# 🧑‍💻 API de Gerenciamento de Clientes

Uma API RESTful robusta e completa desenvolvida em **ASP.NET Core 8** para o gerenciamento de clientes.  
Este projeto demonstra as melhores práticas de desenvolvimento back-end, incluindo arquitetura de serviços, persistência de dados com Entity Framework Core, validação de dados e integração com serviços externos.

![Demonstração da API](https://i.imgur.com/i8dSmJ9.gif)

---

## ✨ Funcionalidades Principais

- **CRUD Completo para Clientes**: Criar, Ler, Atualizar e Deletar (com exclusão lógica).
- **Validação de CPF em Tempo Real**: Integração com a API do Ministério da Saúde (`scpa-backend.saude.gov.br`) para validar CPFs no momento do cadastro.
- **Segurança e Boas Práticas**:
  - **Exclusão Lógica (Soft Delete)**: preserva histórico de dados.
  - **Projeção de Dados**: listagem geral retorna apenas dados não-sensíveis.
- **Organização Limpa de Código**: `Models`, `Data`, `Services`, `Controllers`.
- **Swagger Interativo**: documentação 100% navegável e testável.

---

## 🚀 Tecnologias Utilizadas

| Tecnologia                 | Descrição                                                                            |
|----------------------------|--------------------------------------------------------------------------------------|
| **.NET 8**                 | Plataforma moderna da Microsoft para aplicações.                                     |
| **ASP.NET Core**           | Framework para APIs de alta performance.                                             |
| **Entity Framework Core**  | ORM para comunicação com o banco de dados.                                           |
| **SQL Server**             | Banco de dados relacional.                                                           |
| **Swagger (Swashbuckle)**  | Geração automática de documentação interativa.                                       |
| **Injeção de Dependência** | Padrão nativo do ASP.NET Core para gerenciar `DbContext` e serviços.                 |

---

## ⚙️ Como Executar o Projeto Localmente

### 🔧 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms)

---

### 📥 1. Clone o Repositório

```bash
git clone <(https://github.com/gabrielsilvaa12/ApiClientes)>
cd ApiClientes
````
###⚙️ 2. Configure a Conexão com o Banco de Dados
O projeto está configurado para usar o SQL Server LocalDB, que já vem com o Visual Studio.

Abra o arquivo appsettings.json e verifique a string de conexão:

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DbClientes;Trusted_Connection=True;MultipleActiveResultSets=true"
}
````
🗄️ 3. Aplique as Migrations
No Console do Gerenciador de Pacotes
(Visual Studio → Ferramentas → Gerenciador de Pacotes NuGet → Console do Gerenciador de Pacotes):

```bash
Update-Database
````
Isso criará o banco DbClientes e a tabela Clientes automaticamente.

▶️ 4. Execute a Aplicação
- Pressione F5 ou clique no botão Play no Visual Studio.
- O navegador abrirá a interface do Swagger automaticamente.

🌐 Endpoints da API
Acesse em:
http://localhost:<porta>/swagger

Verbo	Rota	Descrição
POST	/api/Clientes	Cria um novo cliente. Validação de CPF em tempo real.
GET	/api/Clientes	Lista clientes ativos (retorna apenas 5 campos públicos).
GET	/api/Clientes/{id}	Busca cliente específico por ID, com todos os dados.
PUT	/api/Clientes/{id}	Atualiza os dados de um cliente existente.
DELETE	/api/Clientes/{id}	Inativa o cliente (exclusão lógica).

📌 Observações
O banco de dados não apaga registros, apenas marca como inativo.

A listagem geral retorna apenas dados públicos, preservando informações sensíveis.

Cada cadastro de cliente realiza validação automática de CPF.

