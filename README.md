# Instruções para Rodar a Aplicação Web API em .NET

Este guia descreve como rodar uma aplicação Web API criada com o .NET diretamente do repositório GitHub.

## Requisitos

Antes de começar, verifique se você tem as seguintes ferramentas instaladas:

1. **.NET SDK**: [Baixe e instale o .NET SDK](https://dotnet.microsoft.com/download/dotnet) (versão 6.0 ou superior).
2. **Visual Studio ou Visual Studio Code** (opcional, mas recomendado para desenvolvimento):
    - [Visual Studio](https://visualstudio.microsoft.com/downloads/)
    - [Visual Studio Code](https://code.visualstudio.com/)
3. **Git**: [Baixe e instale o Git](https://git-scm.com/) se não tiver.

## Passos para rodar a aplicação

### 1. Clonando o Repositório

Primeiro, clone o repositório do GitHub para a sua máquina local:

```bash
git clone https://github.com/Dumilson/web-api-asp-net.git
cd nome-do-repositorio
```

### 2. Restaurando Dependências

Dentro do diretório do projeto, execute o comando para restaurar as dependências do projeto:

```bash
dotnet restore
```

Isso irá baixar todas as dependências necessárias, conforme definidas no arquivo de projeto (`.csproj`).

### 3. Configuração de Banco de Dados (se aplicável)

Se a aplicação utilizar um banco de dados, verifique as configurações de conexão no arquivo `appsettings.json` ou nas variáveis de ambiente.

Por exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MinhaAPI;User Id=sa;Password=senha;"
  }
}
```

Certifique-se de ter um banco de dados configurado (SQL Server, PostgreSQL, MySQL, etc.) e ajuste as configurações de acordo com seu ambiente local.

Se for necessário rodar migrações de banco de dados, execute o seguinte comando:

```bash
dotnet ef database update
```

### 4. Compilando a Aplicação

Agora, compile o projeto para garantir que tudo esteja configurado corretamente:

```bash
dotnet build
```

### 5. Executando a Aplicação

Após compilar, inicie o servidor web com o comando:

```bash
dotnet run
```

Isso iniciará a aplicação localmente. Por padrão, a aplicação estará disponível no endereço `http://localhost:5000` para HTTP ou `https://localhost:5001` para HTTPS.

