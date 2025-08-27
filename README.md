# API de Gerenciamento de Clientes

Uma API RESTful robusta e completa desenvolvida em **ASP.NET Core 8** para o gerenciamento de clientes. Este projeto demonstra as melhores práticas de desenvolvimento back-end, incluindo arquitetura de serviços, persistência de dados com Entity Framework Core, validação de dados e integração com serviços externos.

![Demonstração da API](https://i.imgur.com/i8dSmJ9.gif)

---

## ✨ Funcionalidades Principais

* **CRUD Completo para Clientes**: Operações para Criar, Ler, Atualizar e Deletar (com exclusão lógica) clientes.
* **Validação de CPF em Tempo Real**: Integração com a API do Ministério da Saúde (`scpa-backend.saude.gov.br`) para validar a autenticidade de cada CPF no momento do cadastro, garantindo a integridade dos dados.
* **Segurança e Boas Práticas**:
    * **Exclusão Lógica (Soft Delete)**: Clientes não são removidos fisicamente do banco, apenas marcados como inativos, preservando o histórico de dados.
    * **Projeção de Dados**: O endpoint de listagem geral retorna apenas dados não-sensíveis do cliente, protegendo informações privadas.
* **Código Organizado**: A solução segue princípios de organização, separando responsabilidades em `Models`, `Data`, `Services` e `Controllers`.
* **Documentação Interativa com Swagger**: A API é 100% documentada e testável através de uma interface Swagger (OpenAPI) gerada automaticamente.

---

## 🚀 Tecnologias Utilizadas

| Tecnologia              | Descrição                                                                        |
| :---------------------- | :------------------------------------------------------------------------------- |
| **.NET 8** | A mais recente versão da plataforma de desenvolvimento da Microsoft.               |
| **ASP.NET Core** | Framework para a construção de APIs de alta performance.                           |
| **Entity Framework Core** | ORM para a comunicação e mapeamento objeto-relacional com o banco de dados.      |
| **SQL Server** | Sistema de gerenciamento de banco de dados relacional da Microsoft.                |
| **Swagger (Swashbuckle)** | Ferramenta para geração automática de documentação da API.                       |
| **Injeção de Dependência** | Padrão nativo do ASP.NET Core para gerenciar `DbContext` e serviços.             |

---

## ⚙️ Como Executar o Projeto Localmente

Siga os passos abaixo para rodar a aplicação em seu ambiente de desenvolvimento.

### Pré-requisitos

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/)
* [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms)

### 1. Clone o Repositório

```bash
git clone <URL_DO_SEU_REPOSITORIO_AQUI>
cd ApiClientes
2. Configure a Conexão com o Banco de Dados
O projeto está configurado para usar o SQL Server LocalDB, que já vem com o Visual Studio.

Abra o arquivo appsettings.json.

Confira se a string de conexão DefaultConnection está correta para sua máquina. O padrão é:

JSON

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DbClientes;Trusted_Connection=True;MultipleActiveResultSets=true"
}
3. Aplique as Migrations
Este comando irá criar o banco de dados DbClientes e a tabela Clientes automaticamente.

Abra o Console do Gerenciador de Pacotes no Visual Studio (Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciador de Pacotes).

Execute o comando:

PowerShell

Update-Database
4. Execute a Aplicação
Pressione F5 ou clique no botão de "play" no Visual Studio para iniciar a API.

O navegador será aberto automaticamente na página do Swagger.

Endpoints da API
Acesse http://localhost:<porta>/swagger para testar todos os endpoints.

/api/Clientes
Verbo	Rota	Descrição
POST	/	Cria um novo cliente. O CPF é validado em tempo real antes da criação.
GET	/	Retorna uma lista de clientes ativos. Apenas 5 campos não-sensíveis são exibidos.
GET	/{id}	Busca um cliente específico pelo ID. Retorna todos os dados do cliente.
PUT	/{id}	Atualiza os dados de um cliente existente.
DELETE	/{id}	Inativa um cliente (exclusão lógica).
