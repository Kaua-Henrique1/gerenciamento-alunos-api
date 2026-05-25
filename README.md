# 🚀 Gerenciamento de Alunos API

Uma API RESTful robusta desenvolvida em **.NET 10** para o gerenciamento de registros de alunos. O projeto utiliza **Entity Framework Core** para persistência de dados em um banco de dados **SQL Server** rodando em um container Docker, e conta com segurança via autenticação **JWT (JSON Web Tokens)**.

---

## 🚀 Como Rodar o Projeto do Zero

### 1. Pré-requisitos
Certifique-se de ter instalado em sua máquina:
* SDK do .NET 10
* Docker
* Postman ou outra ferramenta de testes de API

### 2. Verificar o estado do container

O container deve aparecer com informações como estas:

```text
CONTAINER ID   IMAGE                                        COMMAND                  CREATED       STATUS          PORTS                                         NAMES
87927089d879   mcr.microsoft.com/mssql/server:2022-latest   "/opt/mssql/bin/laun…"   7 hours ago   Up 41 minutes   0.0.0.0:1433->1433/tcp, [::]:1433->1433/tcp   sql_server_escola
```

### 4. Configurar a string de conexão

No arquivo `appsettings.json`, a string de conexão para o banco deve apontar para o container Docker:

```json
{
  "ConnectionStrings": {
    "EscolaDB": "Server=localhost,1433;Database=EscolaDB;User Id=sa;Password=senha123;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "A7xK9pQ2mN8vR4tY1uW6cD3sF0jL5hZS",
    "Issuer": "gerenciamento_alunos_api",
    "Audience": "gerenciamento_alunos_api"
  }
}
```

### 5. Restaurar dependências e compilar

Execute na raiz do projeto:

```bash
dotnet restore
dotnet build
```

### 6. Executar a API

Inicie a API com:

```bash
dotnet run
```

---

## Guia de Testes no Postman (Passo a Passo)

### Etapa 1: Autenticação (Login)

Os endpoints de alunos são protegidos, então é necessário gerar um token JWT válido primeiro.

1. Crie uma requisição `POST` para:

   `http://localhost:5054/api/auth/login`

2. Na aba `Body`, selecione `raw` e o formato `JSON`.

3. Envie o seguinte objeto:

```json
{
  "username": "admin",
  "password": "123456"
}
```

4. Clique em `Send` e copie o token gerado no corpo da resposta.

### Etapa 2: Operações de Alunos (CRUD)

 IMPORTANTE: Para todas as requisições abaixo, vá na aba `Authorization`, selecione o tipo `Bearer Token` e cole o token obtido na Etapa 1.

#### Criar Aluno (POST)

* URL: `http://localhost:5054/api/alunos`
* Body (raw JSON):

```json
{
  "nome": "Kauã Henrique",
  "email": "kaua@example.com",
  "curso": "Análise e Desenvolvimento de Sistemas",
  "dataNascimento": "2004-05-24"
}
```

#### Listar Todos os Alunos (GET)

* URL: `http://localhost:5054/api/alunos`
* Body: none

#### Obter Aluno Específico (GET por ID)

* URL: `http://localhost:5054/api/alunos/1`
* Body: none

Substitua `1` pelo ID desejado.

#### Atualizar Dados do Aluno (PUT)

* URL: `http://localhost:5054/api/alunos/1`
* Body (raw JSON):

```json
{
  "id": 1,
  "nome": "Kauã Henrique Alterado",
  "email": "kaua.novo@example.com",
  "curso": "Engenharia de Software",
  "dataNascimento": "2004-05-24"
}
```

#### Deletar Aluno (DELETE)

* URL: `http://localhost:5054/api/alunos/1`
* Body: none