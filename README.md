# API de Gerenciamento de Clientes 🧑‍💻

Uma API RESTful robusta e completa desenvolvida em **ASP.NET Core 8** para o gerenciamento de clientes. Este projeto demonstra as melhores práticas de desenvolvimento back-end, incluindo arquitetura de serviços, persistência de dados com **Entity Framework Core**, validação de dados e separação de responsabilidades.

---

## ✨ Funcionalidades Principais

- **CRUD Completo para Clientes:** Crie, leia, atualize e delete clientes.  
- **Exclusão Lógica (Soft Delete):** Ao deletar um cliente, o registro não é removido do banco de dados, apenas marcado como inativo (`Ativo = false`), preservando o histórico.  
- **Projeção de Dados (DTO):** A listagem geral de clientes (`GET /api/Clientes`) retorna apenas dados não-sensíveis (`Id`, `Nome`, `Email`, `Telefone`, `Cidade`) para maior segurança. A busca por ID (`GET /api/Clientes/{id}`) retorna todos os dados do cliente.  
- **Validação de CPF em Tempo Real:** Antes de cadastrar um novo cliente, o CPF é validado através de uma consulta a um serviço externo do governo ([scpa-backend.saude.gov.br](https://scpa-backend.saude.gov.br)).  
- **Estrutura Organizada:** Código dividido em `Models`, `Data`, `Services` e `Controllers` para facilitar manutenção e escalabilidade.  
- **Documentação Interativa com Swagger:** A API conta com documentação 100% navegável e testável.

---

## 🚀 Tecnologias Utilizadas

| Tecnologia                | Descrição                                                                                  |
|---------------------------|--------------------------------------------------------------------------------------------|
| **.NET 8**                | Plataforma moderna da Microsoft utilizada como base do projeto.                             |
| **ASP.NET Core**          | Framework para construção de APIs web de alta performance.                                  |
| **Entity Framework Core** | ORM (Mapeador Objeto-Relacional) para comunicação com o banco de dados SQL Server.         |
| **SQL Server**            | Sistema de gerenciamento de banco de dados relacional.                                      |
| **Swagger (Swashbuckle)** | Geração automática de documentação interativa da API.                                       |
| **Injeção de Dependência**| Padrão nativo do ASP.NET Core utilizado para gerenciar o DbContext e serviços da aplicação.|

---

## ⚙️ Como Executar o Projeto Localmente

### 🔧 Pré-requisitos

- .NET 8 SDK  
- Visual Studio 2022 ou outra IDE de sua preferência  
- SQL Server (Express ou LocalDB)

### 📥 1. Clone o Repositório

```bash
git clone https://github.com/gabrielsilvaa12/ApiClientes.git
cd ApiClientes
````

## ⚙️ 2. Configure a Conexão com o Banco de Dados

O projeto está pré-configurado para usar o **SQL Server LocalDB**.  
A string de conexão está no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DbClientes;Trusted_Connection=True;MultipleActiveResultSets=true"
}
````

## 🗄️ 3. Aplique as Migrations

Para criar o banco de dados e a tabela de clientes, execute o seguinte comando no **Console do Gerenciador de Pacotes do Visual Studio**:

```bash
Update-Database
````

## ▶️ 4. Execute a Aplicação

- Pressione **F5** ou clique no botão de execução (▶️) no Visual Studio.  
- O navegador será aberto automaticamente na interface do **Swagger**, em um endereço como:


---

## 🌐 Endpoints da API

A interface do Swagger fornece uma maneira fácil de testar todos os endpoints.

| Verbo  | Rota                  | Descrição                                                  |
|--------|----------------------|------------------------------------------------------------|
| POST   | /api/Clientes        | Cria um novo cliente. A validação de CPF é executada automaticamente. |
| GET    | /api/Clientes        | Lista todos os clientes ativos, retornando apenas campos públicos. |
| GET    | /api/Clientes/{id}   | Busca um cliente específico por ID, retornando todos os seus dados. |
| PUT    | /api/Clientes/{id}   | Atualiza os dados de um cliente existente.               |
| DELETE | /api/Clientes/{id}   | Inativa o cliente (exclusão lógica), alterando `Ativo` para `false`. |
